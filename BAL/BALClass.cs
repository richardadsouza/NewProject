using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Models;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace BAL
{
    public class BALClass
    {
        DALClass objDAL = new DALClass();

        const string encryptionKey = "R!chard";

        public DataTable GetZipcodeList()
        {
            return objDAL.GetZipcodeList();
        }

        public List<DateTime> GetCurrentDelDate()
        {
            return objDAL.GetCurrentDelDate(DateTime.Now);
        }

        public DataTable BindAisleTop()
        {
            return objDAL.BindAisleTop();
        }

        public string GetAisleTop(string aisleTopID)
        {
            return objDAL.GetAisleTop(aisleTopID);
        }

        public DataTable GetAisle(string aisleTopID)
        {
            return objDAL.GetAisle(aisleTopID);
        }

        public DataTable GetShelf(string aisleID, string aisleTopID)
        {
            return objDAL.GetShelf(aisleID, aisleTopID);
        }

        public DataTable GetPopularProducts(string shelfID)
        {
            return objDAL.GetPopularProducts(shelfID);
        }

        public DataTable GetProductList(string shelfID)
        {
            return objDAL.GetProductList(shelfID);
        }

        public DataTable InsertDollarSign(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["BeforeSalePrice"] != null && Convert.ToString(row["BeforeSalePrice"]).Trim().Length > 0)
                {
                    decimal beforeSalePrice = Math.Round(Convert.ToDecimal(row["BeforeSalePrice"].ToString()), 2);
                    row["BeforeSalePrice"] = "$" + beforeSalePrice;
                }

                decimal price = Math.Round(Convert.ToDecimal(row["Price"].ToString()), 2);
                row["Price"] = "$" + price;
            }

            return dt;
        }

        public AisleShelfName GetAisleShelfInfo(string aisleTopID, string aisleID, string shelfID)
        {
            DataTable dt = objDAL.GetAisleShelfInfo(aisleTopID, aisleID, shelfID);
            AisleShelfName aisleShelfName = new AisleShelfName();

            if (dt.Rows.Count > 0)
            {
                aisleShelfName = new AisleShelfName()
                {
                    AisleTopID = Convert.ToString(dt.Rows[0]["AisleTopID"]),
                    AisleTopName = Convert.ToString(dt.Rows[0]["AisleTopName"]),
                    AisleID = Convert.ToString(dt.Rows[0]["AisleID"]),
                    AisleName = Convert.ToString(dt.Rows[0]["AisleName"]),
                    ShelfID = Convert.ToString(dt.Rows[0]["ShelfID"]),
                    ShelfName = Convert.ToString(dt.Rows[0]["ShelfName"])
                };
            }

            return aisleShelfName;
        }

        /// <summary>
        /// Function to update the shopping cart
        /// </summary>
        /// <param name="shoppingList">Passing list of name-value pair containing the productID and its quantity</param>
        public string UpdateShoppingCart(Dictionary<string, int> shoppingList)
        {
            string shoppingCartString = String.Empty;

            try
            {
                if (shoppingList.Count > 0)
                {
                    shoppingCartString = CreateShoppingCartCookie(shoppingList);
                }
            }
            catch (Exception ex)
            {
                objDAL.LogError(ex.Message, ex.StackTrace);
            }

            return shoppingCartString;
        }


        /// <summary>
        /// Function to create shopping cart cookie string
        /// </summary>
        /// <param name="shoppingList">Dictionary with the producy ID and its quantity</param>
        /// <returns>Cookie string generated</returns>
        public string CreateShoppingCartCookie(Dictionary<string, int> shoppingList)
        {
            StringBuilder shoppingCartCookie = new StringBuilder();

            if (shoppingList.Count > 0)
            {
                foreach (var item in shoppingList)
                {
                    if (shoppingCartCookie.Length <= 0)
                    {
                        shoppingCartCookie.Append(item.Key + "|@|" + item.Value);
                    }
                    else
                    {
                        shoppingCartCookie.Append("|@|" + item.Key + "|@|" + item.Value);
                    }
                }
            }

            return shoppingCartCookie.ToString();
        }

        /// <summary>
        /// Function to delete selcted items from cart.
        /// </summary>
        /// <param name="shoppingCart">Shopping cart items</param>
        /// <param name="productIDList">List of items that are to be deleted</param>
        /// <returns>Updated shopping cart string</returns>
        public string UpdateShoppingCart(string shoppingCart, List<string> productIDList)
        {
            string shoppingCartString = String.Empty;

            try
            {
                if (productIDList.Count > 0)
                {
                    DataTable dt = GetShoppingCart(shoppingCart);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (string id in productIDList)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (Convert.ToString(row["ProductID"]) == id)
                                {
                                    row.Delete();
                                    break;
                                }
                            }
                        }

                        dt.AcceptChanges();

                        shoppingCartString = CreateShoppingCartCookie(dt);
                    }
                }

                return shoppingCartString;
            }
            catch (Exception ex)
            {
                objDAL.LogError(ex.Message, ex.StackTrace);

                return shoppingCartString;
            }
        }

        /// <summary>
        /// Function to generate cookie string
        /// </summary>
        /// <param name="dt">Data table with product ID and its quantity</param>
        /// <returns>Cookie string generated</returns>
        public string CreateShoppingCartCookie(DataTable dt)
        {
            string returnString = String.Empty;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (returnString.Trim().Length == 0)
                    {
                        returnString = Convert.ToString(row["ProductID"]) + "|@|" + Convert.ToString(row["Qty"]);
                    }
                    else
                    {
                        returnString += "|@|" + Convert.ToString(row["ProductID"]) + "|@|" + Convert.ToString(row["Qty"]);
                    }
                }
            }

            return returnString;
        }       

        /// <summary>
        /// Function to get product details
        /// </summary>
        /// <param name="shoppingCart">Shopping cart cookie string</param>
        /// <returns>Data table containing product details</returns>
        public DataTable GetShoppingCart(string shoppingCart)
        {
            DataTable dt = new DataTable();
            int qty = 0;
            string productID = String.Empty;

            try
            {
                dt.Columns.Add("ProductID");
                dt.Columns.Add("ProductName");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Price");
                dt.Columns.Add("Size");
                dt.Columns.Add("TaxType");

                if (shoppingCart.Trim().Length > 0)
                {
                    string[] splitChar = { "|@|" };
                    string[] productList = shoppingCart.Split(splitChar, StringSplitOptions.None);

                    //Loop through the shopping cart string.
                    for (int i = 0; i < productList.Length; i += 2)
                    {
                        productID = Convert.ToString(productList[i]);
                        qty = Convert.ToInt32(productList[i + 1]);

                        //Get the product details of a product.
                        DataRow row = objDAL.GetProductDetails(productID, qty);

                        //Flag to check if the product is repeated in the shopping cart.
                        bool isRepeated = false;

                        if (dt.Rows.Count > 0)
                        {
                            productID = Convert.ToString(row["ProductID"]);

                            foreach (DataRow dataRow in dt.Rows)
                            {
                                //Check if the product is already stored in the data table.
                                if (productID == Convert.ToString(dataRow["ProductID"]))
                                {
                                    dataRow["Qty"] = Convert.ToInt32(dataRow["Qty"]) + Convert.ToInt32(row["Qty"]);
                                    isRepeated = true;
                                }
                            }
                        }

                        if (!isRepeated)
                        {
                            dt.Rows.Add(GetProductDataRow(dt, row));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objDAL.LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        private DataRow GetProductDataRow(DataTable dt, DataRow row)
        {
            DataRow dtRow = dt.NewRow();
            dtRow["ProductID"] = row["ProductID"];
            dtRow["ProductName"] = row["Name"];
            dtRow["Qty"] = row["Qty"];
            dtRow["Price"] = Math.Round(Convert.ToDecimal(row["Price"]), 2);
            dtRow["Size"] = row["Size"];
            dtRow["TaxType"] = row["TaxType"];

            return dtRow;
        }

        /// <summary>
        /// Function to check if given string is number or not
        /// </summary>
        /// <param name="number">String to be validated</param>
        /// <returns>True if string is a number</returns>
        public bool CheckIsValidNumber(string number)
        {
            bool isValid = Regex.IsMatch(number, @"^\d+$");
            return isValid;
        }

        /// <summary>
        /// Function to decrypt password
        /// </summary>
        /// <param name="password">Password in encrypted format</param>
        /// <returns>Decrypted password</returns>
        public string DecryptPassword(string password)
        {
            string decryptedPass = String.Empty;

            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                byte[] pwdHash, buffer;

                pwdHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(encryptionKey));
                des.Key = pwdHash;
                des.Mode = CipherMode.ECB;
                buffer = Convert.FromBase64String(password);

                decryptedPass = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {
                objDAL.LogError(ex.Message, ex.StackTrace);
            }

            return decryptedPass;
        }

        /// <summary>
        /// Function to encrypt password
        /// </summary>
        /// <param name="password">Password in string format</param>
        /// <returns>Encrypted password</returns>
        public string EncryptPassword(string password)
        {
            string encryptedPass = String.Empty;

            try
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] pwdHash, buffer;

                pwdHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(encryptionKey));
                des.Key = pwdHash;
                des.Mode = CipherMode.ECB;
                buffer = ASCIIEncoding.ASCII.GetBytes(password);

                encryptedPass = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception ex)
            {
                objDAL.LogError(ex.Message, ex.StackTrace);
            }

            return encryptedPass;
        }

        public UserLoginDetails CheckUser(string email, string password)
        {
            password = EncryptPassword(password);

            DataTable dt = objDAL.CheckUser(email, password);

            if (dt.Rows.Count > 0)
            {
                UserLoginDetails loginDetails = new UserLoginDetails
                {
                    UserID = Convert.ToString(dt.Rows[0]["UserID"]),
                    FirstName = Convert.ToString(dt.Rows[0]["FirstName"]),
                    LastName = Convert.ToString(dt.Rows[0]["LastName"]),
                    Email = Convert.ToString(dt.Rows[0]["EmailID"]),
                    AccountFunds = Math.Round(Convert.ToDecimal(dt.Rows[0]["AccountFunds"]), 2)
                };

                return loginDetails;
            }

            return new UserLoginDetails();
        }

        /// <summary>
        /// Function to return shopping cart variables table data
        /// </summary>
        /// <returns>Shoppingcartvaraibles</returns>
        public ShoppingCartVariables GetShoppingCartVariables()
        {
            DataTable dt = objDAL.GetShoppingCartVariables();
            ShoppingCartVariables shoppingCartVariables = new ShoppingCartVariables();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    shoppingCartVariables = new ShoppingCartVariables
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        DeliveryFee = Convert.ToDecimal(row["DeliveryFee"]),
                        FoodTax = Convert.ToDecimal(row["FoodTax"]),
                        NonFoodTax = Convert.ToDecimal(row["NonFoodTax"]),
                        MinOrderSize = Convert.ToDecimal(row["MinOrderSize"]),
                        NoOfTimeSlot = Convert.ToInt32(row["NoOfTimeSlot"]),
                        DeliveryFeeCutOff = Convert.ToDecimal(row["DeliveryFeeCutOff"]),
                        CustomerServiceEmail = Convert.ToString(row["CustomerServiceEmail"]),
                        ContactEmail = Convert.ToString(row["ContactEmail"]),
                        InfoEmail = Convert.ToString(row["InfoEmail"]),
                        Location = Convert.ToString(row["Location"]),
                        StateShortName = Convert.ToString(row["StateShortName"]),
                        StateLongName = Convert.ToString(row["StateLongName"]),
                        ShortCompanyName = Convert.ToString(row["ShortCompanyName"]),
                        LongCompanyName = Convert.ToString(row["LongCompanyName"]),
                        URL = Convert.ToString(row["URL"]),
                        FirstOrderGift = Convert.ToDecimal(row["FirstOrderGift"]),
                        MemberDeliveryFee = Convert.ToDecimal(row["MemberDeliveryFee"])
                    };
                }

                return shoppingCartVariables;
            }

            return shoppingCartVariables;
        }

        /// <summary>
        /// Function to check if the coupon code is valid
        /// </summary>
        /// <param name="couponCode">Coupon code</param>
        /// <param name="userID">User ID</param>
        /// <returns>Coupon validation flag</returns>
        public int CheckCouponCode(string couponCode, string userID)
        {
            DataTable dt = objDAL.CheckCouponCode(couponCode);

            /*Code for coupon validation
            0. Error
            1. Valid
            2. Invalid coupon: Already used.
            3. Invalid coupon: Coupon not applicable.
            4. Wrong coupon code.*/
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                /*Coupon types
                1. Normal coupon: Used 1 per user.
                2. First time coupon: Used only for first order.
                */
                Coupon coupon = new Coupon
                {
                    CouponID = Convert.ToString(row["CouponID"]),
                    CouponCode = Convert.ToString(row["CouponCode"]),
                    CouponType = Convert.ToInt32(row["CouponTYpe"]),
                    Amount = Math.Round(Convert.ToDecimal(row["Amount"]), 2)
                };

                if (coupon.CouponType == 1) //Normal coupon.
                {
                    //Check if the coupon has been already used by the user.
                    bool isValid = objDAL.CheckCouponCode(coupon.CouponID, userID);

                    if (isValid)
                    {
                        return 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (coupon.CouponType == 2) //First time coupon
                {
                    //Check if the user is ordering for the first time.
                    bool isValid = objDAL.CheckOrder(userID);

                    if (isValid)
                    {
                        return 1;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
            else
            {
                return 4;
            }

            return 0;
        }

        public Coupon GetCoupon(string couponCode)
        {
            DataTable dt = objDAL.CheckCouponCode(couponCode);

            if (dt.Rows.Count > 0)
            {
                Coupon coupon = new Coupon
                {
                    CouponID = Convert.ToString(dt.Rows[0]["CouponID"]),
                    CouponCode = Convert.ToString(dt.Rows[0]["CouponCode"]),
                    CouponType = Convert.ToInt32(dt.Rows[0]["CouponType"]),
                    Amount = Math.Round(Convert.ToDecimal(dt.Rows[0]["Amount"]), 2)
                };

                return coupon;
            }
            else
            {
                return new Coupon();
            }
        }
    }
}

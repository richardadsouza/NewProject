using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using groceryguys.Class;
using System.Data;

namespace groceryguys
{
    public partial class Userpremadelistdetails : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                getCompanyName();
                BindSavedList();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public void getCompanyName()
        {

            DbProvider dbGetCompanyName = new DbProvider();
            DataSet dsGetCompanyName = new DataSet();

            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;
            if (imgName != "")
            {

                urlThumbnail = "Admin/thumbnailmainimage.aspx?imgName=" + imgName;

            }
            return urlThumbnail;
        }

        public void BindSavedList()
        {
           // int userId = 0;
            double food_tax = 0.0;
            double nonfood_tax = 0.0;
           // int membershipvalue = 0;
            int intListId = 0;
            intListId = Convert.ToInt32(Request.QueryString["listId"]);
            string strListNm = string.Empty;
            string strTax = string.Empty;
            string strPrice = string.Empty;
            string strSoda = string.Empty;
            int intProdId = 0;
            string strQty = string.Empty;
            double price = 0;
            double Amt = 0;
            double TotAmt = 0;
            double sodaAmt = 0;
            double intTotsodaAmt = 0;
            double rate = 0;
            double intTotTax = 0.00;
            double intGroceryTot = 0.00;
            double deliveryFee = 0.00;
            DataTable dtShopList = new DataTable();
            DataRow rowShop;
            dtShopList.Columns.Add("product_id");
            dtShopList.Columns.Add("product_title");
            dtShopList.Columns.Add("product_image");
            dtShopList.Columns.Add("productlink_price");
            dtShopList.Columns.Add("product_size");
            dtShopList.Columns.Add("Qty");
           // DataSet dsUserItemList;

            //userId = Convert.ToInt32(Request.Cookies["userId"].Value.ToString());

            //dsUserItemList = dbInfo.GetHomeUserInformation(userId);
            //if (dsUserItemList.Tables.Count > 0)
            //{
            //    if (dsUserItemList != null && dsUserItemList.Tables.Count > 0 && dsUserItemList.Tables[0].Rows.Count > 0)
            //    {
            //        userId = Convert.ToInt32(dsUserItemList.Tables[0].Rows[0]["users_id"]);
            //        ViewState["userId"] = Convert.ToString(userId);
            //        membershipvalue = Convert.ToInt32(dsUserItemList.Tables[0].Rows[0]["users_Membership"]);
            //        ViewState["users_Membership"] = Convert.ToString(membershipvalue);
            //    }
            //}

            DataSet dsListInfo = new DataSet();
            DataSet dsShop = new DataSet();
            int type = Convert.ToInt32(AppConstants.savedListTypeadmin);

            dsListInfo = dbInfo.GetUserSavedListDetailsuser(intListId, type);

            if (dsListInfo.Tables.Count > 0)
            {
                if (dsListInfo != null && dsListInfo.Tables.Count > 0 && dsListInfo.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsListInfo.Tables[0].Rows)
                    {
                        strListNm = Convert.ToString(dtrow["list_name"]);
                        strQty = Convert.ToString(dtrow["listlink_qty"]);
                        intProdId = Convert.ToInt32(dtrow["product_id"]);
                        dsShop = dbInfo.SavedListProductInfo(intProdId);
                        if (dsShop.Tables.Count > 0)
                        {
                            if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                            {
                                strTax = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_tax"]);
                                strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                                strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);
                                rowShop = dtShopList.NewRow();
                                rowShop["Qty"] = Convert.ToString(strQty);
                                rowShop["product_title"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);
                                rowShop["product_size"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_size"]);
                                rowShop["productlink_price"] = Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                rowShop["product_id"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_id"]);
                                if (Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]) != "")
                                {
                                    rowShop["product_image"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]);
                                }
                                else
                                {
                                    rowShop["product_image"] = "no_image.gif";

                                }
                                dtShopList.Rows.Add(rowShop);
                                price = Math.Round(Convert.ToDouble(strPrice), 2);
                                Amt = Convert.ToDouble(strQty) * price;
                                TotAmt = TotAmt + Amt;
                                if (strTax != "")
                                {
                                    if (Convert.ToInt32(strTax) == 1)
                                    {
                                        rate = Amt * (Convert.ToDouble(ViewState["TaxRate_Food"]) / 100);
                                        intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);
                                        food_tax = food_tax + Math.Round(Convert.ToDouble(rate), 2);

                                    }
                                    else if (Convert.ToInt32(strTax) == 2)
                                    {
                                        rate = Amt * (Convert.ToDouble(ViewState["TaxRate_NonFood"]) / 100);
                                        intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);
                                        nonfood_tax = nonfood_tax + Math.Round(Convert.ToDouble(rate), 2);

                                    }
                                    else
                                    {
                                        rate = 0.00;
                                        intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);

                                    }
                                }
                                if (strSoda != "" && strSoda != null)
                                {
                                    sodaAmt = Convert.ToDouble(strQty) * Convert.ToDouble(strSoda);
                                    intTotsodaAmt = intTotsodaAmt + Math.Round(Convert.ToDouble(sodaAmt), 2);

                                }
                            }
                        }
                    }
                    gridShopList.DataSource = dtShopList;
                    gridShopList.DataBind();
                    lblListNm.Text = strListNm;
                    lblSubTotVal.Text = Convert.ToString(TotAmt);
                    if (TotAmt < Convert.ToDouble(ViewState["DeliveryFeeCutOff"]))
                    {
                        //int member = Convert.ToInt32(ViewState["users_Membership"].ToString());
                        //if (member == 1)
                        //{
                        //    deliveryFee = 4.95;

                        //}
                        //else
                        //{
                        //    deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);
                        //}
                        deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);

                    }
                    else
                    {
                        deliveryFee = 0.00;


                    }
                    if (intTotsodaAmt == 0)
                    {
                        lblSodaFee.Visible = false;
                        lblSodaSign.Visible = false;
                        lblSodaDepFeeTot.Visible = false;
                    }
                    else
                    {
                        lblSodaFee.Visible = true;
                        lblSodaSign.Visible = true;
                        lblSodaDepFeeTot.Visible = true;
                        lblSodaDepFeeTot.Text = "";
                        // lblSodaDepFeeTot.Text = Convert.ToString(intTotsodaAmt);
                        lblSodaDepFeeTot.Text = Convert.ToDecimal(intTotsodaAmt).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }

                    lblDeliveryFeeTot.Text = Convert.ToDecimal(deliveryFee).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    lblTaxVal.Text = Convert.ToDecimal(food_tax).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    lblTaxVal2.Text = Convert.ToDecimal(nonfood_tax).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    intGroceryTot = TotAmt + intTotTax + deliveryFee + intTotsodaAmt;
                    //lblTotVal.Text = Convert.ToString(intGroceryTot);
                    lblTotVal.Text = Convert.ToDecimal(intGroceryTot).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                }
            }
            dbInfo.dispose();
        }

        protected void gridShopList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridShopList.PageIndex = e.NewPageIndex;
            BindSavedList();
        }



        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Shop.aspx",false);
        //}

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    lblMsg.Text = "";
        //    lblMsg.Visible = false;
        //    int intListID = 0;
        //    intListID = Convert.ToInt32(Request.QueryString["listid"]);

        //    string strShopping = string.Empty;
        //    string strShop = string.Empty;
        //    if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
        //    {

        //        strShopping = AddProductToCart(strShop, intListID);
        //        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
        //        Response.Cookies.Add(ShoppingCart);

        //    }
        //    else
        //    {
        //        strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
        //        strShopping = AddProductToCart(strShop, intListID);
        //        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
        //        Response.Cookies.Add(ShoppingCart);

        //    }

        //    Response.Redirect("product_order.aspx", false);


        //}

        public string AddProductToCart(string strShop, int intListID)
        {
            string strShopping = string.Empty;
            string strTitle = string.Empty;
            string strQty = string.Empty;
            string strPrice = string.Empty;
            int intProdId = 0;
            DataSet dsListInfo = new DataSet();
            DataSet dsShop = new DataSet();
            
            int type = Convert.ToInt32(AppConstants.savedListTypeadmin);

            dsListInfo = dbInfo.GetUserSavedListDetailsuser(intListID, type);

            //dsListInfo = dbInfo.GetUserSavedListDetails(intListID, Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsListInfo.Tables.Count > 0)
            {
                if (dsListInfo != null && dsListInfo.Tables.Count > 0 && dsListInfo.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsListInfo.Tables[0].Rows)
                    {
                        strQty = Convert.ToString(dtrow["listlink_qty"]);
                        intProdId = Convert.ToInt32(dtrow["product_id"]);

                        if (strShop == "" && strShopping == "")
                        {
                            strShopping = Convert.ToString(intProdId) + "|@|" + strQty;
                        }
                        else
                        {
                            if (strShopping == "")
                            {
                                strShopping = strShop + "|@|" + Convert.ToString(intProdId) + "|@|" + strQty;

                            }
                            else
                            {
                                strShopping = strShopping + "|@|" + Convert.ToString(intProdId) + "|@|" + strQty;
                            }
                        }
                    }
                }
            }

            dbInfo.dispose();
            return strShopping;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            lblMsg.Visible = false;
            int intListID = 0;
            intListID = Convert.ToInt32(Request.QueryString["listid"]);

            string strShopping = string.Empty;
            string strShop = string.Empty;
            if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
            {

                strShopping = AddProductToCart(strShop, intListID);
                HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                Response.Cookies.Add(ShoppingCart);

            }
            else
            {
                strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                strShopping = AddProductToCart(strShop, intListID);
                HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                Response.Cookies.Add(ShoppingCart);

            }

            Response.Redirect("product_order.aspx", false);
        }

        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx", false);

        }
    }
}

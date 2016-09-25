using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using groceryguys.Class;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using webresponce.valetgroceryfinal;
using System.Net;


namespace groceryguys
{
    public partial class payment : System.Web.UI.Page
    {
        DropdownProvider dropState = new DropdownProvider();
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Request.Cookies["userId"] == null)
                {
                    Response.Redirect("LoginPage.aspx", false);
                }
                else
                {

                    GetPaymentOptionInformation();
                    getCompanyName();
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();

                    if (!IsPostBack)
                    {
                        dropState.bindStateDropdown(drpState);
                        if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                        {
                            if (lblTotal.Text == null || lblTotal.Text == "")
                            {
                                btnPay.Visible = false;
                                lblTotal.Text = "0.00";
                            }
                        }
                        else
                        {
                            btnPay.Visible = true;
                            string StrShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                            string StrShipping = Convert.ToString(Request.Cookies["UserShopAddInfo"].Value);

                            AddressInfo();
                            SplitShopString(StrShop);
                            if (StrShipping != "")
                            {
                                splitPickTime();
                            }
                            splitTipping();



                            getPaymentDropDown();
                            double totFinal;
                            if (Convert.ToString(ViewState["strTippingAmt"]) != "")
                            {
                                totFinal = Convert.ToDouble(ViewState["strTippingAmt"]);
                            }
                            else
                            {
                                totFinal = 0;
                            }
                            totFinal += Convert.ToDouble(ViewState["intGroceryTot"]);
                            lblTotal.Text = Convert.ToDecimal(totFinal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            ViewState["TotalFinal"] = Convert.ToString(totFinal);
                            BindUserBillingInformation();
                            checkMinimumAmountOfTotal();
                            lblCompTot.Text = Convert.ToDecimal(ViewState["CompCost"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            btnPay.Visible = false;

                        }
                    }
                }
                dbInfo.dispose();
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        //ToCheck Minimum order
        public void checkMinimumAmountOfTotal()
        {

            DataSet dsZipVal = new DataSet();
            string strOrderVal = "";
            dsZipVal = dbInfo.GetMinOrderAmt(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsZipVal.Tables.Count > 0)
            {
                if (dsZipVal != null && dsZipVal.Tables.Count > 0 && dsZipVal.Tables[0].Rows.Count > 0)
                {
                    strOrderVal = Convert.ToString(dsZipVal.Tables[0].Rows[0]["ZipOrderSize"]);

                }
                else
                {

                    string strMsg = AppConstants.pgZipcodeDelete;
                    lblMsg.Text = strMsg;
                    lblMsg.ForeColor = System.Drawing.Color.Red;



                }
            }

            dbInfo.dispose();
            if (strOrderVal != "")
            {
                if ((Convert.ToDouble(ViewState["sutotalMinimum"]) < Convert.ToDouble(strOrderVal)))
                {
                    pnlMinOrder.Visible = false;
                    pnlMin1.Visible = false;
                    pnlMin2.Visible = false;
                    lblMsg.Visible = true;

                    //string strMsg = AppConstants.pgMinimumOrder + " $" + Convert.ToString(Math.Round(Convert.ToDouble(strOrderVal), 2));
                    string strMsg = AppConstants.pgMinimumOrderPayment + " $" + Convert.ToDecimal(strOrderVal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    lblMsg.Text = strMsg;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblMsg.Visible = false;
                    pnlMin1.Visible = true;
                    pnlMin2.Visible = true;
                    pnlMinOrder.Visible = true;
                }
            }


        }


        public void BindUserBillingInformation()
        {
            string fName = string.Empty;
            string lName = string.Empty;
            string phone = string.Empty;

            DataSet dsUserInfo = new DataSet();

            dsUserInfo = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    fName = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_fname"]);
                    ViewState["fName"] = fName;
                    lName = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_lname"]);
                    ViewState["lName"] = lName;
                    phone = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_phone"]);
                    ViewState["phone"] = phone;
                    txtAddress1.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_baddress1"]);
                    txtAddress2.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_baddress2"]);
                    txtCity.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bcity"]);

                    ViewState["EmailId"] = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_email"]);
                    if (Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bstate"]) != "")
                    {
                        drpState.SelectedValue = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bstate"]);
                    }
                    else
                    {
                        drpState.SelectedValue = "Select";


                    }
                    txtZipCode.Text = Convert.ToString(dsUserInfo.Tables[0].Rows[0]["users_bzip"]);
                }
            }
            dbInfo.dispose();
        }

        public void getPaymentDropDown()
        {
            string ComplimentaryCost = string.Empty;
            DataSet dsAccount = new DataSet();
            double drpValue = 0;
            dsAccount = dbInfo.GetAccountInformation(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsAccount.Tables.Count > 0)
            {
                if (dsAccount != null && dsAccount.Tables.Count > 0 && dsAccount.Tables[0].Rows.Count > 0)
                {
                    drpValue = Math.Round(Convert.ToDouble(dsAccount.Tables[0].Rows[0]["users_accountvalue"]), 2);

                }
                else
                {
                    drpValue = 0;

                }
            }
            else
            {
                drpValue = 0;

            }
            if (drpValue == 0 || drpValue <= 0)
            {
                drpPayment.Items.Clear();

                drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
                //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
            }
            else if (drpValue != 0)
            {

                double amt = Convert.ToDouble(ViewState["intGroceryTot"]) + Convert.ToDouble(ViewState["strTippingAmt"]);

                if (drpValue < amt)
                {
                    ComplimentaryCost = Convert.ToString(amt - drpValue);
                    drpPayment.Items.Clear();
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
                    //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + Convert.ToDecimal(drpValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ")+ Credit Card Charge", "3"));
                    //drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + drpValue + ")+ Cash On Delivery", "4"));
                }
                else
                {
                    drpPayment.Items.Clear();
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Select", "Select"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Credit Card Charge ", "1"));
                    // drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Cash On Delivery", "2"));
                    drpPayment.Items.Add(new System.Web.UI.WebControls.ListItem("Account Fund ($" + Convert.ToDecimal(drpValue).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + ")", "5"));


                }
            }
            ViewState["AccountFundAmt"] = drpValue;
            if (ComplimentaryCost != "")
            {
                ViewState["CompCost"] = ComplimentaryCost;
            }
            else
            {
                ViewState["CompCost"] = "0";

            }
            dbInfo.dispose();
        }


        //Function for get short company name for page title
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPayment;
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["TaxRate_Food"] = Convert.ToString(dtrow["TaxRate_Food"]);
                        ViewState["TaxRate_NonFood"] = Convert.ToString(dtrow["TaxRate_NonFood"]);
                        ViewState["LongURL"] = Convert.ToString(dtrow["LongURL"]);
                        lblWebsiteLong.Text = Convert.ToString(ViewState["LongURL"]);
                        ViewState["MembersDeliveryFee"] = Convert.ToString(dtrow["MemberDeliveryFee"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void drpPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strPayment = string.Empty;
            strPayment = drpPayment.SelectedValue;
            if (strPayment == "1" || strPayment == "3")
            {
                if (ViewState["PaymentOption"].ToString() != "")
                {
                    //if (Convert.ToInt32(ViewState["PaymentOption"]) == 1 || Convert.ToInt32(ViewState["PaymentOption"]) == 3)

                    if (strPayment == "1" || strPayment == "3")
                    {
                        pnlAutoCreditCard.Visible = true;
                        btnPay.Visible = true;
                    }
                    if (Convert.ToInt32(ViewState["PaymentOption"]) == 2)
                    {
                        pnlAutoCreditCard.Visible = false;
                        btnPay.Visible = true;
                    }

                }

            }
            else
            {
                pnlAutoCreditCard.Visible = false;
                //pnlPaypal.Visible = false;
                btnPay.Visible = true;

            }


        }

        protected void btnPay_Click(object sender, EventArgs e)
        {

            string strPayment = string.Empty;
            string strOrdPayType = string.Empty;
            string strAccFundVal = string.Empty;
            int intUpdate = 0;
            strPayment = drpPayment.SelectedValue;
            string strState = string.Empty;
            strState = drpState.SelectedValue;
            if (strState == "Select")
            {
                strState = "";

            }
            if (chkAgree.Checked == true)
            {
                intUpdate = dbInfo.UpdateUserBillingInfo(txtAddress1.Text, txtAddress2.Text, txtCity.Text, strState, txtZipCode.Text, Convert.ToInt32(Request.Cookies["userId"].Value));

            }


            if (strPayment == "2" || strPayment == "4" || strPayment == "5")
            {

                if (strPayment == "2")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strCOD);

                }
                if (strPayment == "4")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strAFCOD);


                }
                if (strPayment == "5")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strAF);

                }

                //Insert Order Details

                InsertOrderDetails(strOrdPayType);
            }
            else
            {
                if (strPayment == "1")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strCC);
                    if (Convert.ToString(ViewState["PaymentOption"]) != "")
                    {
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 1)
                        {
                            AuthorizePayment(strOrdPayType);

                        }
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 2)
                        {
                            PayPayment(strOrdPayType);

                        }
                    }
                }
                if (strPayment == "3")
                {
                    strOrdPayType = Convert.ToString(AppConstants.strAFCC);
                    if (Convert.ToString(ViewState["PaymentOption"]) != "")
                    {
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 1)
                        {
                            AuthorizePayment(strOrdPayType);

                        }
                        if (Convert.ToInt32(ViewState["PaymentOption"]) == 2)
                        {

                            PayPayment(strOrdPayType);


                        }
                    }
                }
            }
            dbInfo.dispose();
        }
        public void AuthorizePayment(string strOrdPayType)
        {

            string fName = string.Empty;
            string lName = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            string Gtotal1 = string.Empty;
            string strpay = string.Empty;
            string expdate = string.Empty;
            bool status = false;


            fName = Convert.ToString(ViewState["fName"]);

            lName = Convert.ToString(ViewState["lName"]);

            phone = Convert.ToString(ViewState["phone"]);

            email = Convert.ToString(ViewState["EmailId"]);
            //authorizenet authorize = new authorizenet();

            authorizenet authorize = new authorizenet();
            expdate = txtAutoExpMM.Text + "/" + txtAutoExpYY.Text;

            if (strOrdPayType == Convert.ToString(AppConstants.strCC))
            {

                Gtotal1 = Convert.ToString(ViewState["TotalFinal"]);
            }
            else if (strOrdPayType == Convert.ToString(AppConstants.strAFCC))
            {

                Gtotal1 = Convert.ToString(ViewState["CompCost"]);

            }

            string AddGtotal = string.Empty;

            // Add $10 Site request which is not inserted database and doesnot appear in any invoices.
            AddGtotal = Convert.ToString(Convert.ToDouble(Gtotal1) + 10);

            strpay += Convert.ToString(ViewState["API_Login"]) + "," + Convert.ToString("AUTH_ONLY") + "," + Convert.ToString(ViewState["API_TransKey"]) + "," + Convert.ToString(ViewState["API_PostUrl"]) + "," + ttxPayCCNm.Text + "," + expdate + "," + "ValetGrocery" + "," + AddGtotal + "," + fName + "," + lName + "," + "" + "," + txtAddress1.Text + "," + txtCity.Text.Trim() + "," + drpState.SelectedValue + "," + txtZipCode.Text + "," + phone + "," + email + "," + "United States";
            authorize.Initialize(strpay);

            status = authorize.transmit();
            if (status == false)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "";
               // lblMsg.Text = "Please check Credit card number and Expiration date you have entered";
                lblMsg.Text = "Sorry , Error : " + authorize.strArrayVal[0] + " , " +  authorize.strArrayVal[1] + " , " + authorize.strArrayVal[2] + " , "  +  authorize.strArrayVal[3] + " , " + authorize.strArrayVal[4];   //.strRetval;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string valTid = authorize.get_Tid;
                ViewState["TransactionId"] = valTid;
                InsertOrderDetails(strOrdPayType);
                //int orderID = InsertOrderDetailsdata(strOrdPayType);
                //Response.Redirect("OrderConfirmation.aspx?orderId=" + orderID, false);
            }

        }



        public void PayPayment(string strOrdPayType)
        {
            string strPaypal = string.Empty;
            int orderNum = 0;
            string Gtotal1 = string.Empty;
            DataSet dsUserOrderInfo = new DataSet();
            dsUserOrderInfo = dbInfo.selectAllOrderInfo();
            if (dsUserOrderInfo.Tables.Count > 0)
            {
                if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
                {
                    orderNum = Convert.ToInt32(dsUserOrderInfo.Tables[0].Rows[0]["orders_number"]) + 1;

                }
                else
                {
                    orderNum = Convert.ToInt32(AppConstants.strOrderNm);
                }

            }



            if (strOrdPayType == Convert.ToString(AppConstants.strCC))
            {

                Gtotal1 = lblTotal.Text;
            }
            else if (strOrdPayType == Convert.ToString(AppConstants.strAFCC))
            {

                Gtotal1 = lblCompTot.Text;

            }

            strPaypal = strOrdPayType;
            HttpCookie PaypalShopping = new HttpCookie("PaypalShopping", strOrdPayType);
            Response.Cookies.Add(PaypalShopping);


            string strFund = "NoFund" + "|@|" + "Val";
            HttpCookie DepositFund = new HttpCookie("DepositFund", strFund);
            Response.Cookies.Add(DepositFund);

            string redirect = string.Empty;

            //redirect += Convert.ToString(ViewState["PayPalUrl"]) + "&business=" + Convert.ToString(ViewState["BusinessEmail"]);
            //redirect += "&item_name=" + "Item Name";
            //redirect += "&amount=" + String.Format("{0:0.00} ", Gtotal1);
            //redirect += "&item_number=" + Convert.ToInt32(orderNum);
            //redirect += "&currency_code=USD";
            ////redirect += "&add =1";
            //redirect += "&return=" + ConfigurationManager.AppSettings["paypalReturnUrl"];
            //redirect += "&cancel_return=" + ConfigurationManager.AppSettings["cancel_return"];
            //redirect += "&notify_url=" + ConfigurationManager.AppSettings["notify_url"];
            //redirect += "&custom=" + Convert.ToInt32(orderNum);
            //Response.Redirect(redirect);


            redirect += lblPayPalUrl.Text + "&business=" + lblPayEmail.Text;
            redirect += "&item_name=" + "Item Name";
            redirect += "&amount=" + String.Format("{0:0.00} ", Gtotal1);
            redirect += "&item_number=" + Convert.ToInt32(orderNum);
            redirect += "&currency_code=USD";
            //redirect += "&add =1";
            redirect += "&return=" + lblWebsiteLong.Text + "/Success.aspx";
            redirect += "&cancel_return=" + lblWebsiteLong.Text + "/payPalCancel.aspx";
            redirect += "&notify_url=" + lblWebsiteLong.Text + "/WebForm1.aspx";
            redirect += "&custom=" + Convert.ToInt32(orderNum);
            Response.Redirect(redirect);
            dbInfo.dispose();
        }

        //public void SplitShopString(string StrShop)
        //{
        //    int intProdId = 0;
        //    int intProdQty = 0;
        //    string strProdNm = string.Empty;
        //    string strPrice = string.Empty;
        //    double intGroceryTot = 0;
        //    string strTax = string.Empty;
        //    string strOrderVal = string.Empty;
        //    string strSoda = string.Empty;
        //    double intTotTax = 0.00;
        //    double intTotTax2 = 0.00;
        //    double Amt_food = 0.00;
        //    double Amt_nonfood = 0.00;
        //    double rate = 0;
        //    double deliveryFee = 0;
        //    string image = string.Empty;
        //    DataSet dsShop = new DataSet();
        //    double price = 0;
        //    double Amt = 0;
        //    double TotAmt = 0;
        //    double sodaAmt = 0;
        //    double intTotsodaAmt = 0;
        //    string[] splitter = { "|@|" };
        //    string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
        //    for (int i = 0; i < prodInfo.Length; i++)
        //    {

        //        if (i % 2 == 0)
        //        {
        //            intProdId = Convert.ToInt32(prodInfo[i]);
        //            intProdQty = Convert.ToInt32(prodInfo[i + 1]);
        //            dsShop = dbInfo.GetProductDetails(intProdId);
        //            if (dsShop.Tables.Count > 0)
        //            {
        //                if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
        //                {
        //                    strTax = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_tax"]);
        //                    strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
        //                    strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);
        //                    strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);

        //                    price = Math.Round(Convert.ToDouble(strPrice), 2);
        //                    Amt = Convert.ToDouble(intProdQty) * price;
        //                    TotAmt = TotAmt + Amt;
        //                    if (strTax != "")
        //                    {
        //                        if (Convert.ToInt32(strTax) == 1)
        //                        {
        //                            Amt_food = Amt_food + Amt;
        //                            rate = Amt * (Convert.ToDouble(ViewState["TaxRate_Food"]) / 100);
        //                            intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);

        //                        }
        //                        else if (Convert.ToInt32(strTax) == 2)
        //                        {
        //                            Amt_nonfood = Amt_nonfood + Amt;
        //                            rate = Amt * (Convert.ToDouble(ViewState["TaxRate_NonFood"]) / 100);
        //                            intTotTax2 = intTotTax2 + Math.Round(Convert.ToDouble(rate), 2);

        //                        }
        //                        else
        //                        {
        //                            rate = 0.00;
        //                            intTotTax = intTotTax + Math.Round(Convert.ToDouble(rate), 2);

        //                        }
        //                    }
        //                    if (strSoda != "" && strSoda != null)
        //                    {
        //                        sodaAmt = Convert.ToDouble(intProdQty) * Convert.ToDouble(strSoda);
        //                        intTotsodaAmt = intTotsodaAmt + Math.Round(Convert.ToDouble(sodaAmt), 2);

        //                    }
        //                    i = i + 1;
        //                }
        //            }
        //        }
        //    }

        //    if (TotAmt < Convert.ToDouble(ViewState["DeliveryFeeCutOff"]))
        //    {
        //        deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);

        //    }
        //    else
        //    {
        //        deliveryFee = 0.00;


        //    }

        //    intGroceryTot = TotAmt + intTotTax + intTotTax2 + deliveryFee + intTotsodaAmt;
        //    ViewState["intGroceryTot"] = intGroceryTot;
        //    ViewState["sutotalMinimum"] = TotAmt;
        //    ViewState["OrdTax"] = Convert.ToString(intTotTax);
        //    ViewState["OrdTax1"] = Convert.ToString(intTotTax2);
        //    ViewState["OrdDelFee"] = Convert.ToString(deliveryFee);
        //    ViewState["OrdSoda"] = Convert.ToString(intTotsodaAmt);
        //    ViewState["grocerytotal"] = Convert.ToString(TotAmt);
        //    ViewState["tottaxfood"] = Convert.ToString(Amt_food);
        //    ViewState["tottaxnonfood"] = Convert.ToString(Amt_nonfood); 

        //}

        public void SplitShopString(string StrShop)
        {
            int intProdId = 0;
            double food_tax = 0.0;
            double nonfood_tax = 0.0;
            int intProdQty = 0;
            string strProdNm = string.Empty;
            string strPrice = string.Empty;
            double intGroceryTot = 0;
            string strTax = string.Empty;
            string strOrderVal = string.Empty;
            string strSoda = string.Empty;
            double intTotTax = 0.00;
            double rate = 0;
            double deliveryFee = 0;
            string image = string.Empty;
            DataSet dsShop = new DataSet();
            double price = 0;
            double Amt = 0;
            double TotAmt = 0;
            double sodaAmt = 0;
            double intTotsodaAmt = 0;
            string[] splitter = { "|@|" };

            DataSet dsUserItemList;
            int userId = 0;
            int membershipvalue = 0;
            userId = Convert.ToInt32(Request.Cookies["userId"].Value.ToString());

            dsUserItemList = dbInfo.GetHomeUserInformation(userId);
            if (dsUserItemList.Tables.Count > 0)
            {
                if (dsUserItemList != null && dsUserItemList.Tables.Count > 0 && dsUserItemList.Tables[0].Rows.Count > 0)
                {
                    userId = Convert.ToInt32(dsUserItemList.Tables[0].Rows[0]["users_id"]);
                    ViewState["userId"] = Convert.ToString(userId);
                    membershipvalue = Convert.ToInt32(dsUserItemList.Tables[0].Rows[0]["users_Membership"]);
                    ViewState["users_Membership"] = Convert.ToString(membershipvalue);
                }
            }

            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < prodInfo.Length; i++)
            {

                if (i % 2 == 0)
                {

                    intProdId = Convert.ToInt32(prodInfo[i]);
                    intProdQty = Convert.ToInt32(prodInfo[i + 1]);
                    dsShop = dbInfo.GetProductDetails(intProdId);
                    if (dsShop.Tables.Count > 0)
                    {
                        if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                        {
                            strTax = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_tax"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                            strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);
                            strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);

                            price = Math.Round(Convert.ToDouble(strPrice), 2);
                            Amt = Convert.ToDouble(intProdQty) * price;
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
                                sodaAmt = Convert.ToDouble(intProdQty) * Convert.ToDouble(strSoda);
                                intTotsodaAmt = intTotsodaAmt + Math.Round(Convert.ToDouble(sodaAmt), 2);

                            }
                            i = i + 1;

                        }

                    }
                }


            }


            if (TotAmt < Convert.ToDouble(ViewState["DeliveryFeeCutOff"]))
            {
                int member = Convert.ToInt32(ViewState["users_Membership"].ToString());
                if (member == 1)
                {
                    //deliveryFee = 4.95;
                    // deliveryFee = Convert.ToDouble(ViewState["MembersDeliveryFee"].ToString());
                    deliveryFee = Convert.ToDouble(ViewState["MembersDeliveryFee"]);

                }
                else
                {
                    //deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"].ToString());
                    deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);
                }
                //deliveryFee = Convert.ToDouble(ViewState["DeliveryFee"]);


            }
            else
            {
                deliveryFee = 0.00;


            }

            intGroceryTot = TotAmt + intTotTax + deliveryFee + intTotsodaAmt;
            ViewState["sutotalMinimum"] = TotAmt;
            ViewState["intGroceryTot"] = intGroceryTot;
            ViewState["sutotalMinimum"] = TotAmt;
            ViewState["OrdTaxfood"] = Convert.ToString(food_tax);
            ViewState["OrdTaxnonfood"] = Convert.ToString(nonfood_tax);

            ViewState["OrdTax"] = Convert.ToString(intTotTax);
            ViewState["OrdDelFee"] = Convert.ToString(deliveryFee);
            ViewState["OrdSoda"] = Convert.ToString(intTotsodaAmt);
            ViewState["grocerytotal"] = Convert.ToString(TotAmt);
            dbInfo.dispose();

        }


        public void AddressInfo()
        {
            string strAddress1 = string.Empty;
            string strAddress2 = string.Empty;
            string strCity = string.Empty;
            string strState = string.Empty;
            string strZip = string.Empty;
            string strSpecial = string.Empty;
            DataSet dsAddressInfo = new DataSet();
            DataSet dsDeleteInfo = new DataSet();
            dsAddressInfo = dbInfo.GetAddressInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
            strAddress1 = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["address"]);
            ViewState["strAddress1"] = strAddress1;
            strAddress2 = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["address2"]);
            ViewState["strAddress2"] = "";
            strCity = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["City"]);
            ViewState["strCity"] = strCity;
            strState = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["State"]);
            ViewState["strState"] = strState;
            strZip = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["Zip"]);
            ViewState["strZip"] = strZip;
            strSpecial = Convert.ToString(dsAddressInfo.Tables[0].Rows[0]["instruction"]);
            ViewState["strSpecial"] = ReplaceNewLines(Convert.ToString(strSpecial), true);
            dbInfo.dispose();
        }


        //public void splitTipping()
        //{
        //    string[] splitter = { "!*@!" };
        //    int intVal = 0;
        //    string strTippingAmt = string.Empty;
        //    string StrShipping = Convert.ToString(Request.Cookies["strUserTipping"].Value);
        //    string[] shopInfo = StrShipping.Split(splitter, StringSplitOptions.None);
        //    int intLen = Convert.ToInt32(shopInfo.Length);
        //    if (intLen > 0)
        //    {
        //        strTippingAmt = Convert.ToString(shopInfo[intVal]);
        //        ViewState["strTippingAmt"] = strTippingAmt;
        //    }
        //}


        public void splitTipping()
        {
            string[] splitter = { "!*@!" };
            int intVal = 0;
            string strTippingAmt = string.Empty;
            string StrShipping = Convert.ToString(Request.Cookies["strUserTipping"].Value);
            string[] shopInfo = StrShipping.Split(splitter, StringSplitOptions.None);
            int intLen = Convert.ToInt32(shopInfo.Length);
            string strTip = string.Empty;
            string groceryTotAmt = string.Empty;
            if (intLen > 0)
            {
                groceryTotAmt = Convert.ToString(ViewState["intGroceryTot"]);
                if (groceryTotAmt != "")
                {
                    strTippingAmt = Convert.ToString(shopInfo[intVal]);
                    double selectTipVal = 0.00;
                    if (strTippingAmt == "0")
                    {

                        //strTip = "0.00";
                        if (Convert.ToString(shopInfo[intVal + 1]) == "")
                        {
                            strTip = "0.00";
                        }
                        else
                        {
                            strTip = Convert.ToString(shopInfo[intVal + 1]);
                        }
                    }

                    if (strTippingAmt == "1")
                    {

                        strTip = "0.00";
                    }
                    if (strTippingAmt == "2")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.05), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "3")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.10), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "4")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.15), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "5")
                    {
                        selectTipVal = Math.Round((Convert.ToDouble(groceryTotAmt) * 0.20), 2);
                        strTip = Convert.ToString(selectTipVal);
                    }
                    if (strTippingAmt == "6")
                    {
                        if (Convert.ToString(shopInfo[1]) == "")
                        {
                            strTip = "0.00";
                        }
                        else
                        {
                            strTip = Convert.ToString(shopInfo[1]);

                        }

                    }

                    ViewState["strTippingAmt"] = strTip;
                }
                else
                {
                    ViewState["strTippingAmt"] = "0.00";

                }

            }
        }
        public void splitPickTime()
        {
            string strDelDate = string.Empty;
            string strTime = string.Empty;
            string strTimeValue = string.Empty;
            string strDeldateId = string.Empty;
            string[] splitter = { "!*@!" };
            string StrShipping = Convert.ToString(Request.Cookies["UserShopAddInfo"].Value);
            string[] shopInfo = StrShipping.Split(splitter, StringSplitOptions.None);
            int intLen = Convert.ToInt32(shopInfo.Length);
            int i = 0;
            if (intLen > 0)
            {
                strDeldateId = Convert.ToString(shopInfo[i]);
                ViewState["DelDateID"] = strDeldateId;
                strDelDate = Convert.ToString(shopInfo[i + 1]);
                ViewState["strDelDate"] = strDelDate;

                strTime = Convert.ToString(shopInfo[i + 2]);

                if (strTime != "")
                {
                    DataSet dsDeliveryTimeValue = new DataSet();

                    dsDeliveryTimeValue = dbInfo.GetDelveryTime(Convert.ToInt32(strTime));

                    if (dsDeliveryTimeValue.Tables.Count > 0)
                    {
                        if (dsDeliveryTimeValue != null && dsDeliveryTimeValue.Tables.Count > 0 && dsDeliveryTimeValue.Tables[0].Rows.Count > 0)
                        {
                            strTimeValue = Convert.ToString(dsDeliveryTimeValue.Tables[0].Rows[0]["deliverytime_time"]);
                        }
                    }
                }
                ViewState["strTime"] = strTime;
                ViewState["strTimeValue"] = strTimeValue;
            }
        }
        //Function for the replace the \r\n value for multiline text box
        public static String ReplaceNewLines(String source, bool allowNewLines)
        {
            if (allowNewLines)
                source = source.Replace("%0d%0a", "<br/>");
            else
                source = source.Replace("%0a", " ");
            return source;
        }
        public void GetPaymentOptionInformation()
        {
            DataSet dsGetPaymentOption = new DataSet();

            dsGetPaymentOption = dbInfo.GetPaymentOptionDetails();

            if (dsGetPaymentOption.Tables.Count > 0)
            {
                if (dsGetPaymentOption != null && dsGetPaymentOption.Tables.Count > 0 && dsGetPaymentOption.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetPaymentOption.Tables[0].Rows)
                    {
                        ViewState["PaymentOption"] = Convert.ToString(dtrow["payment_Id"]);
                        //PayPal

                        //ViewState["USER"] = Convert.ToString(dtrow["API_PayPalUserName"]);
                        //ViewState["PWD"] = Convert.ToString(dtrow["API_PayPalPassword"]);
                        //ViewState["SIGNATURE"] = Convert.ToString(dtrow["API_PayPalSignature"]);
                        //ViewState["strNVPSandboxServer"] = Convert.ToString(dtrow["API_PayPalEndPoint"]);

                        //PayPalIpn
                        ViewState["PayPalUrl"] = Convert.ToString(dtrow["PaypalUrl"]);
                        lblPayPalUrl.Text = Convert.ToString(ViewState["PayPalUrl"]);
                        ViewState["BusinessEmail"] = Convert.ToString(dtrow["PaypalEmail"]);
                        lblPayEmail.Text = Convert.ToString(dtrow["PaypalEmail"]);

                        ViewState["PayPalSubmitUrl"] = Convert.ToString(dtrow["PaypalSubUrl"]);
                        ViewState["PDTToken"] = Convert.ToString(dtrow["PDTToken"]);
                        //Authorize
                        ViewState["API_Login"] = Convert.ToString(dtrow["API_Login"]);
                        ViewState["API_TransKey"] = Convert.ToString(dtrow["API_TransKey"]);
                        ViewState["API_PostUrl"] = Convert.ToString(dtrow["API_PostUrl"]);
                    }
                }
            }
            dbInfo.dispose();
        }


        public void InsertOrderDetails(string strOrdPayType)
        {
            string strTransId = string.Empty;
            int insertOrder = 0;
            int orderNum = 0;
            DataSet dsUserOrderInfo = new DataSet();
            dsUserOrderInfo = dbInfo.selectAllOrderInfo();
            if (dsUserOrderInfo.Tables.Count > 0)
            {
                if (dsUserOrderInfo.Tables[0].Rows.Count > 0)
                {
                    orderNum = Convert.ToInt32(dsUserOrderInfo.Tables[0].Rows[0]["orders_number"]) + 1;
                }
                else
                {
                    orderNum = Convert.ToInt32(AppConstants.strOrderNm);
                }

            }
            //if (strOrdPayType == Convert.ToString(AppConstants.strUK))
            //{
            //    insertOrder = dbInfo.InsertOrderInformation1(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToString(ViewState["strAddress1"]), Convert.ToString(ViewState["strAddress2"]), Convert.ToString(ViewState["strCity"]), Convert.ToString(ViewState["strState"]), Convert.ToString(ViewState["strZip"]), Convert.ToString(ViewState["strSpecial"]), DateTime.Now, Convert.ToDateTime(ViewState["strDelDate"]), Convert.ToString(ViewState["strTimeValue"]), Convert.ToDouble(ViewState["TotalFinal"]), Convert.ToDouble(ViewState["grocerytotal"]), Convert.ToDouble(ViewState["strTippingAmt"]), Convert.ToDouble(ViewState["OrdSoda"]), Convert.ToDouble(ViewState["OrdDelFee"]), Convert.ToDouble(ViewState["CompCost"]), orderNum, Convert.ToString(strOrdPayType), Convert.ToDouble(ViewState["OrdTax"]), Convert.ToString(TxtUkAcctName.Text), Convert.ToInt32(TxtUkAcctNo.Text));

            //}
            //else { 


            insertOrder = dbInfo.InsertOrderInformation(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToString(ViewState["strAddress1"]), Convert.ToString(ViewState["strAddress2"]), Convert.ToString(ViewState["strCity"]), Convert.ToString(ViewState["strState"]), Convert.ToString(ViewState["strZip"]), Convert.ToString(ViewState["strSpecial"]), DateTime.Now, Convert.ToDateTime(ViewState["strDelDate"]), Convert.ToString(ViewState["strTimeValue"]), Convert.ToDouble(ViewState["TotalFinal"]), Convert.ToDouble(ViewState["grocerytotal"]), Convert.ToDouble(ViewState["strTippingAmt"]), Convert.ToDouble(ViewState["OrdSoda"]), Convert.ToDouble(ViewState["OrdDelFee"]), Convert.ToDouble(ViewState["CompCost"]), orderNum, Convert.ToString(strOrdPayType), Convert.ToDouble(ViewState["OrdTax"]), Convert.ToDouble(ViewState["OrdTaxfood"]), Convert.ToDouble(ViewState["OrdTaxnonfood"]));
            // }
            if (insertOrder > 0)
            {
                //Insert order product Information               
                InsertProductOrderInfo(insertOrder);
                //Insert Transaction Information  
                if (strOrdPayType == Convert.ToString(AppConstants.strAFCOD) || strOrdPayType == Convert.ToString(AppConstants.strAF) || strOrdPayType == Convert.ToString(AppConstants.strAFCC))
                {
                    if (Convert.ToString(ViewState["TransactionId"]) != "")
                    {
                        strTransId = Convert.ToString(ViewState["TransactionId"]);
                    }
                    InsertTransactionDetails(strOrdPayType, insertOrder, strTransId);

                }
                //Insert Loyality Fund Information  
                InsertLoyalityFund(insertOrder);
                //update delivery capacity information
                UpdateDeliveryTime();
                Response.Redirect("OrderConfirmation.aspx?orderId=" + insertOrder, false);

            }
            dbInfo.dispose();

        }


        //public int InsertOrderDetailsdata(string strOrdPayType)
        //{
        //    string strTransId = string.Empty;
        //    int insertOrder = 0;
        //    int orderNum = 0;
        //    DataSet dsUserOrderInfo = new DataSet();
        //    dsUserOrderInfo = dbInfo.selectAllOrderInfo();
        //    if (dsUserOrderInfo.Tables.Count > 0)
        //    {
        //        if (dsUserOrderInfo != null && dsUserOrderInfo.Tables.Count > 0 && dsUserOrderInfo.Tables[0].Rows.Count > 0)
        //        {
        //            orderNum = Convert.ToInt32(dsUserOrderInfo.Tables[0].Rows[0]["orders_number"]) + 1;

        //        }
        //        else
        //        {
        //            orderNum = Convert.ToInt32(AppConstants.strOrderNm);
        //        }

        //    }
        //    //if (strOrdPayType == Convert.ToString(AppConstants.strUK))
        //    //{
        //    //    insertOrder = dbInfo.InsertOrderInformation1(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToString(ViewState["strAddress1"]), Convert.ToString(ViewState["strAddress2"]), Convert.ToString(ViewState["strCity"]), Convert.ToString(ViewState["strState"]), Convert.ToString(ViewState["strZip"]), Convert.ToString(ViewState["strSpecial"]), DateTime.Now, Convert.ToDateTime(ViewState["strDelDate"]), Convert.ToString(ViewState["strTimeValue"]), Convert.ToDouble(ViewState["TotalFinal"]), Convert.ToDouble(ViewState["grocerytotal"]), Convert.ToDouble(ViewState["strTippingAmt"]), Convert.ToDouble(ViewState["OrdSoda"]), Convert.ToDouble(ViewState["OrdDelFee"]), Convert.ToDouble(ViewState["CompCost"]), orderNum, Convert.ToString(strOrdPayType), Convert.ToDouble(ViewState["OrdTax"]), Convert.ToString(TxtUkAcctName.Text), Convert.ToInt32(TxtUkAcctNo.Text));

        //    //}
        //    //else { 


        //    insertOrder = dbInfo.InsertOrderInformation(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToString(ViewState["strAddress1"]), Convert.ToString(ViewState["strAddress2"]), Convert.ToString(ViewState["strCity"]), Convert.ToString(ViewState["strState"]), Convert.ToString(ViewState["strZip"]), Convert.ToString(ViewState["strSpecial"]), DateTime.Now, Convert.ToDateTime(ViewState["strDelDate"]), Convert.ToString(ViewState["strTimeValue"]), Convert.ToDouble(ViewState["TotalFinal"]), Convert.ToDouble(ViewState["grocerytotal"]), Convert.ToDouble(ViewState["strTippingAmt"]), Convert.ToDouble(ViewState["OrdSoda"]), Convert.ToDouble(ViewState["OrdDelFee"]), Convert.ToDouble(ViewState["CompCost"]), orderNum, Convert.ToString(strOrdPayType), Convert.ToDouble(ViewState["OrdTax"]), Convert.ToDouble(ViewState["OrdTaxfood"]), Convert.ToDouble(ViewState["OrdTaxnonfood"]));
        //    // }
        //    if (insertOrder > 0)
        //    {
        //        //Insert order product Information               
        //        InsertProductOrderInfo(insertOrder);
        //        //Insert Transaction Information  
        //        if (strOrdPayType == Convert.ToString(AppConstants.strAFCOD) || strOrdPayType == Convert.ToString(AppConstants.strAF) || strOrdPayType == Convert.ToString(AppConstants.strAFCC))
        //        {
        //            if (Convert.ToString(ViewState["TransactionId"]) != "")
        //            {
        //                strTransId = Convert.ToString(ViewState["TransactionId"]);
        //            }
        //            InsertTransactionDetails(strOrdPayType, insertOrder, strTransId);

        //        }
        //        //Insert Loyality Fund Information  
        //        InsertLoyalityFund(insertOrder);
        //        //update delivery capacity information
        //        UpdateDeliveryTime();
        //       // Response.Redirect("OrderConfirmation.aspx?orderId=" + insertOrder, false);

        //    }
        //    dbInfo.dispose();
        //    return insertOrder;
        //}

        public void InsertProductOrderInfo(int OrderId)
        {
            int insertProdInfo = 0;
            int intProdId = 0;
            int intProdQty = 0;
            int intCheck = 0;
            //int intQty = 0;
            //double intProdPrice = 0;
            string strProdNm = string.Empty;
            string strQty = string.Empty;
            string strPrice = string.Empty;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            DataSet dsShop = new DataSet();
            dtShop.Columns.Add("productId");
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("price");
            dtShop.Columns.Add("title");
            string StrShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
            string[] splitter = { "|@|" };
            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < prodInfo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    intProdId = Convert.ToInt32(prodInfo[i]);
                    intProdQty = Convert.ToInt32(prodInfo[i + 1]);
                    dsShop = dbInfo.GetProductDetails(intProdId);


                    if (dsShop.Tables.Count > 0)
                    {
                        if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                        {

                            strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                            if (dtShop.Rows.Count > 0)
                            {
                                foreach (DataRow dtrow in dtShop.Rows)
                                {
                                    if (Convert.ToString(dtrow["title"]) == strProdNm && Convert.ToInt32(dtrow["productId"]) == intProdId)
                                    {
                                        dtrow["Qty"] = Convert.ToString(Convert.ToInt32(dtrow["Qty"]) + Convert.ToInt32(intProdQty));
                                        intCheck = 1;
                                    }
                                }
                            }
                            if (intCheck == 0)
                            {
                                rowShop = dtShop.NewRow();
                                rowShop["Qty"] = Convert.ToString(intProdQty);
                                rowShop["productId"] = Convert.ToString(intProdId);
                                rowShop["price"] = Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                rowShop["title"] = strProdNm;
                                dtShop.Rows.Add(rowShop);
                            }
                            intCheck = 0;
                        }
                    }
                    i = i + 1;

                }
            }
            foreach (DataRow dtrow in dtShop.Rows)
            {
                insertProdInfo = dbInfo.InsertOrderProductInfo(OrderId, Convert.ToInt32(dtrow["productId"]), Convert.ToInt32(dtrow["Qty"]), Convert.ToDouble(dtrow["price"]));
            }
            dbInfo.dispose();
        }
        public void InsertTransactionDetails(string strOrdPayType, int insertOrder, string strTransId)
        {
            string debitAccount = string.Empty;
            string accountFund = string.Empty;
            string strComm = string.Empty;
            int intUpdateUser = 0;
            int intTransaction = 0;
            string strAccFundVal = Convert.ToString(ViewState["AccountFundAmt"]);
            if (strOrdPayType == Convert.ToString(AppConstants.strAFCOD) || strOrdPayType == Convert.ToString(AppConstants.strAFCC))
            {
                debitAccount = "0";
                accountFund = Convert.ToString(0 - Convert.ToDouble(ViewState["AccountFundAmt"]));

            }
            if (strOrdPayType == Convert.ToString(AppConstants.strAF))
            {

                debitAccount = Convert.ToString(Convert.ToDouble(ViewState["AccountFundAmt"]) - Convert.ToDouble(ViewState["TotalFinal"]));
                accountFund = debitAccount;
            }
            intUpdateUser = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), Convert.ToDouble(debitAccount));
            if (intUpdateUser > 0)
            {
                intTransaction = dbInfo.InsertTransactionInfo(DateTime.Today, Convert.ToDouble(accountFund), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value), strTransId);
            }
            dbInfo.dispose();
        }
        // Modified by: Shashank            Date: 02-16-2011
        // Before this Loyality fund in this website is not available

        public void InsertLoyalityFund(int insertOrder)
        {
            double totalCost = Convert.ToDouble(ViewState["TotalFinal"]);
            int intUnder100 = 0;
            int intOver100 = 0;
            int intUnder100New = 0;
            int intOver100New = 0;
            int intUpdateAcc = 0;
            int intInsertTrans = 0;
            int intUserAccVal = 0;
            int intUpdateUser = 0;
            string strComm = string.Empty;
            DataSet dsUserInfo = new DataSet();
            dsUserInfo = dbInfo.GetUserDetailsInfoForLoyolity(Convert.ToInt32(Request.Cookies["userId"].Value));

            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    intUnder100 = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["users_under100"]);
                    intOver100 = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["users_over100"]);
                    intUserAccVal = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["users_accountvalue"]);
                    if (totalCost >= 100)
                    {
                        int amtVal = intUserAccVal + 10;
                        if (intOver100 == 4)
                        {
                            intUpdateAcc = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), amtVal);
                            if (intUpdateAcc > 0)
                            {
                                strComm = AppConstants.strLoyalOver;
                                intInsertTrans = dbInfo.InsertTransactionInformation(DateTime.Today, Convert.ToDouble(10), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value));
                                intOver100New = intOver100 + 1;
                                intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);
                            }
                        }
                        else if (intOver100 == 5)
                        {
                            intOver100New = 1;
                            intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);

                        }
                        else
                        {
                            intOver100New = intOver100 + 1;
                            intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);
                        }
                    }
                    else if (totalCost >= 50 && totalCost <= 99.99)
                    {
                        int amtVal = intUserAccVal + 5;
                        if (intUnder100 == 4)
                        {
                            intUpdateAcc = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), amtVal);
                            if (intUpdateAcc > 0)
                            {
                                strComm = AppConstants.strLoyalUnder;
                                intInsertTrans = dbInfo.InsertTransactionInformation(DateTime.Today, Convert.ToDouble(5), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value));
                                intUnder100New = intUnder100 + 1;
                                intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);
                            }
                        }
                        else if (intUnder100 == 5)
                        {
                            intUnder100New = 1;
                            intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);
                        }
                        else
                        {
                            intUnder100New = intUnder100 + 1;
                            intUpdateUser = dbInfo.UpdateUserLoyalityInfo(Convert.ToInt32(Request.Cookies["userId"].Value), intOver100New, intUnder100New);
                        }
                    }
                }
            }
            dbInfo.dispose();
        }
        //public void InsertLoyalityFund(int insertOrder)
        //{
        //    double totalCost = Convert.ToDouble(ViewState["TotalFinal"]);
        //    int OrderCount = 0;
        //    int OrderMonth = 0;
        //    int intUserAccVal = 0;
        //    int intInsertTrans = 0;
        //    int intUpdateAcc = 0;
        //    string strComm = string.Empty;
        //    DataSet dsUserInfo = new DataSet();
        //    dsUserInfo = dbInfo.GetUserDetailsInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
        //    dbInfo.dispose();
        //    if (dsUserInfo.Tables.Count > 0)
        //    {
        //        if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
        //        {

        //            intUserAccVal = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["users_accountvalue"]);
        //        }
        //    }
        //    DataSet dsOrderCountInfo = dbInfo.GetOrderCountInfo(Convert.ToInt32(Request.Cookies["userId"].Value));
        //    dbInfo.dispose();
        //    if (dsOrderCountInfo.Tables.Count > 0)
        //    {
        //        if (dsOrderCountInfo != null && dsOrderCountInfo.Tables.Count > 0 && dsOrderCountInfo.Tables[0].Rows.Count > 0)
        //        {
        //            OrderCount = Convert.ToInt32(dsOrderCountInfo.Tables[0].Rows[0]["OrderCount"]);
        //            OrderMonth = Convert.ToInt32(dsOrderCountInfo.Tables[0].Rows[0]["OrderMonth"]);
        //            if (OrderCount == 0)
        //            {
        //                int amtVal = intUserAccVal + 5;
        //                intUpdateAcc = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), amtVal);
        //                if (intUpdateAcc > 0)
        //                {
        //                    strComm = AppConstants.strLoyalF;
        //                    intInsertTrans = dbInfo.InsertTransactionInformation(DateTime.Today, Convert.ToDouble(5), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value));
        //                    int intUpdateUser = 0;
        //                    OrderCount = OrderCount + 1;
        //                    intUpdateUser = dbInfo.UpdateOrderCountInfo(Convert.ToInt32(Request.Cookies["userId"].Value), OrderCount, Convert.ToInt32(DateTime.Now.Month));
        //                }
        //            }
        //            else if (OrderCount > 0)
        //            {
        //                if (OrderMonth == Convert.ToInt32(DateTime.Now.Month))
        //                {
        //                    int amtVal = intUserAccVal + 10;
        //                    intUpdateAcc = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), amtVal);
        //                    if (intUpdateAcc > 0)
        //                    {
        //                        strComm = AppConstants.strLoyal;
        //                        intInsertTrans = dbInfo.InsertTransactionInformation(DateTime.Today, Convert.ToDouble(10), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value));
        //                        int intUpdateUser = 0;
        //                        OrderCount = OrderCount + 1;
        //                        intUpdateUser = dbInfo.UpdateOrderCountInfo(Convert.ToInt32(Request.Cookies["userId"].Value), OrderCount, Convert.ToInt32(DateTime.Now.Month));
        //                    }
        //                }
        //                else
        //                {
        //                    int amtVal = intUserAccVal + 5;
        //                    intUpdateAcc = dbInfo.UpdateUserAccInfo(Convert.ToInt32(Request.Cookies["userId"].Value), amtVal);
        //                    if (intUpdateAcc > 0)
        //                    {
        //                        strComm = AppConstants.strLoyalF;
        //                        intInsertTrans = dbInfo.InsertTransactionInformation(DateTime.Today, Convert.ToDouble(5), insertOrder, strComm, Convert.ToInt32(Request.Cookies["userId"].Value));
        //                        int intUpdateUser = 0;
        //                        OrderCount = 1;
        //                        intUpdateUser = dbInfo.UpdateOrderCountInfo(Convert.ToInt32(Request.Cookies["userId"].Value), OrderCount, Convert.ToInt32(DateTime.Now.Month));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        public void UpdateDeliveryTime()
        {
            DataSet dsDeliveryInfo = new DataSet();
            string strDelDate = string.Empty;
            string strDelDateID = string.Empty;
            string strTime = string.Empty;
            string deliverydatetimeId = string.Empty;
            string deliveryCapacity = string.Empty;
            int intDeliveryCap = 0;
            int intTime = 0;
            int updateCapacity = 0;
            strDelDateID = Convert.ToString(ViewState["DelDateID"]);
            strDelDate = Convert.ToString(ViewState["strDelDate"]);
            strTime = Convert.ToString(ViewState["strTime"]);
            if (strTime != "")
            {
                intTime = Convert.ToInt32(strTime);
            }
            // dsDeliveryInfo = dbInfo.SelectDeliveryInfo(Convert.ToDateTime(strDelDate), intTime);
            dsDeliveryInfo = dbInfo.SelectDeliveryInfo_Details(Convert.ToInt32(strDelDateID), Convert.ToDateTime(strDelDate), intTime);
            if (dsDeliveryInfo.Tables.Count > 0)
            {
                if (dsDeliveryInfo != null && dsDeliveryInfo.Tables.Count > 0 && dsDeliveryInfo.Tables[0].Rows.Count > 0)
                {
                    deliverydatetimeId = Convert.ToString(dsDeliveryInfo.Tables[0].Rows[0]["deliverydatetime_id"]);
                    deliveryCapacity = Convert.ToString(dsDeliveryInfo.Tables[0].Rows[0]["deliverydatetime_capacity"]);
                    if (deliveryCapacity != "" && deliverydatetimeId != "")
                    {
                        if (Convert.ToInt32(deliveryCapacity) > 0)
                        {
                            intDeliveryCap = Convert.ToInt32(deliveryCapacity) - 1;
                            updateCapacity = dbInfo.UpdateDeliveryInfo(intDeliveryCap, Convert.ToInt32(deliverydatetimeId));
                        }
                    }
                }
            }
            dbInfo.dispose();
        }
    }
}

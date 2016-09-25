﻿using System;
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


namespace groceryguys
{

    public partial class OrderConfirmation : System.Web.UI.Page
    {
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

                    getCompanyName();
                    if (!IsPostBack)
                    {

                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", null);
                        Response.Cookies.Add(ShoppingCart);

                       
                        if (Request.Cookies["strUserTipping"] != null || Request.Cookies["strUserTipping"].Value != "")
                        {
                            HttpCookie strUserTipping = new HttpCookie("strUserTipping", null);
                            Response.Cookies.Add(strUserTipping);
                        }
                        if (Request.Cookies["UserShopAddInfo"] != null || Request.Cookies["UserShopAddInfo"].Value != "")
                        {
                            HttpCookie UserShopAddInfo = new HttpCookie("UserShopAddInfo", null);
                            Response.Cookies.Add(UserShopAddInfo);
                        }

                        HttpCookie PaypalShopping = new HttpCookie("PaypalShopping", null);
                        Response.Cookies.Add(PaypalShopping);

                        HttpCookie DepositFund = new HttpCookie("DepositFund", null);
                        Response.Cookies.Add(DepositFund);

                        DataSet dsDeleteInfo = dbInfo.DeleteAddressInfo(Convert.ToInt32(Request.Cookies["userId"].Value));


                        BindOrderInformation();
                        lblCmpNm.Text = Convert.ToString(ViewState["CompanyNm"]);
                        lblCmpNm1.Text = Convert.ToString(ViewState["CompanyNm"]);
                        lblCmpNm2.Text = Convert.ToString(ViewState["CompanyNm"]);
                        lblCmpNm3.Text = Convert.ToString(ViewState["CompanyNm"]);

                        int orderid = 0;
                        orderid = Convert.ToInt32(Request.QueryString["orderId"]);
                        if (Request.Cookies["EmailCount"] == null)
                        {
                            check();
                        }
                        else
                        {
                            if (Request.Cookies["EmailCount"].Value != orderid.ToString())
                            {
                                check();

                            }
                        }
                    }
                }




            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }


        public void BindOrderInformation()
        {
            try
            {
                string userEmailAddress = string.Empty;

                int orderId = 0;
                int userId = 0;
                orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                string strPaymentType = string.Empty;
                string strText = string.Empty;
                double accountdebit = 0;
                DataSet dsUserItemList = new DataSet();
                dsUserItemList = dbInfo.GetUserDetailsInfo(userId);
                if (dsUserItemList.Tables.Count > 0)
                {
                    if (dsUserItemList != null && dsUserItemList.Tables.Count > 0 && dsUserItemList.Tables[0].Rows.Count > 0)
                    {
                        lblFName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_fname"]);
                        lblLName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_lname"]);
                        lblPhone.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_phone"]);
                        lblPhone2.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_cell"]);
                        userEmailAddress = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_email"]);
                        ViewState["userEmailAddress"] = userEmailAddress;
                    }
                }

                DataSet dsUserOrderList = new DataSet();
                dsUserOrderList = dbInfo.GetUserOrderInfo(userId, orderId);
                if (dsUserOrderList.Tables.Count > 0)
                {
                    if (dsUserOrderList != null && dsUserOrderList.Tables.Count > 0 && dsUserOrderList.Tables[0].Rows.Count > 0)
                    {
                        lblAddress.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address"]);
                        lblAddress2.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address2"]);
                        lblCity.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_city"]);
                        lblState.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_state"]);
                        lblZip.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_zip"]);
                        lblOrderNumber.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_number"]);
                        lblOrederDate.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["ordered"]);
                        lblDeliveryDateTime.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["delivery"]);

                        lblSpecialOrInfo.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_instructions"]).Replace("\r\n", "<br />");

                        lblSubtotal.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_grocerytotal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblTax.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tax"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblTax1.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tax2"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        
                        lblSodaDeposit.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_sodadeposit"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblDeliveryFee.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_deliveryfee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblTips.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblOrderTotal.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);


                        strPaymentType = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_paymenttype"]);
                        if (strPaymentType == Convert.ToString(AppConstants.strCOD))
                        {
                            lblPaymentMethod.Text = Convert.ToString(AppConstants.strCODDetail);

                        }
                        else if (strPaymentType == Convert.ToString(AppConstants.strCC))
                        {
                            lblPaymentMethod.Text = Convert.ToString(AppConstants.strCCDetail);

                        }
                        else if (strPaymentType == Convert.ToString(AppConstants.strAF))
                        {
                            lblPaymentMethod.Text = Convert.ToString(AppConstants.strAFDetail);

                        }
                        else if (strPaymentType == Convert.ToString(AppConstants.strAFCOD))
                        {

                            accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                            // strText = Convert.ToString(accountdebit)+" "+ Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) +" " +Convert.ToString(AppConstants.strCODDetail);
                            strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + " " + Convert.ToString(AppConstants.strCODDetail);

                            lblPaymentMethod.Text = strText;


                        }
                        else if (strPaymentType == Convert.ToString(AppConstants.strAFCC))
                        {

                            accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                            //strText = Convert.ToString(accountdebit) + " " +Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) + " " + Convert.ToString(AppConstants.strCCDetail);
                            strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCCDetail);
                            lblPaymentMethod.Text = strText;


                        }
                        else
                        {
                            lblPaymentMethod.Text = "";
                        }




                    }
                }

                BindProductGrid();
                dbInfo.dispose();

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }

        }
        public void BindProductGrid()
        {
            int orderId = 0;
            int userId = 0;
            orderId = Convert.ToInt32(Request.QueryString["orderId"]);
            userId = Convert.ToInt32(Request.Cookies["userId"].Value);
            DataSet dsUserProductList = new DataSet();
            dsUserProductList = dbInfo.GetUserOrderProductDetail(orderId, userId);
            if (dsUserProductList.Tables.Count > 0)
            {
                if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                    {

                        dtrow["orderproduct_price"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));
                        dtrow["orderproduct_quantity"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_quantity"]), 2));


                    }
                    gridUserProductList.DataSource = dsUserProductList;
                    gridUserProductList.DataBind();

                }
                else
                {
                    gridUserProductList.Visible = false;
                    lblMsg1.Text = "";
                    lblMsg1.Visible = true;
                    lblMsg1.Text = AppConstants.noRecord;
                    lblMsg1.ForeColor = System.Drawing.Color.Red;
                }
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
                        ViewState["CompanyNm"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["ContactEmail"] = Convert.ToString(dtrow["ContactEmail"]);
                        ViewState["CustomerServiceEmail"] = Convert.ToString(dtrow["CustomerServiceEmail"]);


                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public int check()
        {


            int status = 0;
            try
            {
                SmtpClient smtp = new SmtpClient();
                string strEmailContent = string.Empty;
                string strPwd = string.Empty;
                string strCompanyName = string.Empty;
                string orderDetailsString = string.Empty;
                HttpCookie EmailCount = new HttpCookie("EmailCount", "0");
                Response.Cookies.Add(EmailCount);


                DataTable dtCheckUser = new DataTable();

                MailMessage emailToUser = new MailMessage(Convert.ToString(ViewState["CustomerServiceEmail"]), Convert.ToString(ViewState["userEmailAddress"]));
                //Create random password


                strCompanyName = Convert.ToString(ViewState["CompanyNm"]);

                //Fetch file name from AppConstants class file
               string strAdminEmailFileName = AppConstants.strUserOrderConfirmFileName;

               

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.
                string strMessage = string.Empty;
                emailVariable["$CmpName$"] = strCompanyName;
                emailVariable["$ordNm$"] = lblOrderNumber.Text;
                emailVariable["$ordDate$"] = lblOrederDate.Text;
                emailVariable["$DelivDate$"] = lblDeliveryDateTime.Text;
                emailVariable["$PaymentMethod$"] = lblPaymentMethod.Text;
                emailVariable["$SpecialOrInfo$"] = lblSpecialOrInfo.Text;
                emailVariable["$Fname$"] = lblFName.Text;
                emailVariable["$Lname$"] = lblLName.Text;
                emailVariable["$Phone$"] = lblPhone.Text;
                emailVariable["$Phone2$"] = lblPhone2.Text;
                emailVariable["$Add1$"] = lblAddress.Text;
                emailVariable["$Add2$"] = lblAddress2.Text;
                emailVariable["$City$"] = lblCity.Text;
                emailVariable["$State$"] = lblState.Text;
                emailVariable["$Zip$"] = lblZip.Text;

                emailVariable["$Subtotal$"] = lblSubtotal.Text;
                emailVariable["$Tax$"] = lblTax.Text;
                emailVariable["$Tax1$"] = lblTax1.Text;
                emailVariable["$Soda$"] = lblSodaDeposit.Text;
                emailVariable["$Fee$"] = lblDeliveryFee.Text;
                emailVariable["$Tip$"] = lblTips.Text;
                emailVariable["$Total$"] = lblOrderTotal.Text;



                //string orderDetailsString = "<table cellpadding ='0' cellspacing ='1'   width='600px' '><tr style='font-family: Arial, Helvetica, sans-serif;font-size: 15px;font-weight:bold;color:White;background-color: #008D00;'>";
                //orderDetailsString += "<td style ='padding-left :5px;'  align='left' > <strong>Quantity </strong></td>";
                //orderDetailsString += "<td style ='padding-left :5px;' align='left'  ><strong>Product </strong> </td>";
                //orderDetailsString += "<td style ='padding-left :5px;' align='left'  ><strong>Size </strong> </td>";
                //orderDetailsString += "<td style ='padding-left :5px;' align='left' ><strong>Price($)</strong></td></tr>";
                //int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                //int userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                //DataSet dsUserProductList = new DataSet();
                //dsUserProductList = dbInfo.GetUserOrderProductDetail(orderId, userId);
                //if (dsUserProductList.Tables.Count > 0)
                //{
                //    if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                //    {

                //        foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                //        {

                //            string ordPice = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));
                //            string Qty = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_quantity"]), 2));
                //            orderDetailsString += "<tr><td align='left' bgcolor='White' class='formTextSmallPrintUser' style ='padding-left :5px;'>" + Convert.ToString(Qty) + " </td>";
                //            orderDetailsString += "<td align='left' bgcolor='White' class='formTextSmallPrintUser' style ='padding-left :5px;'>" + Convert.ToString(dtrow["product_title"]) + " </td>";
                //            orderDetailsString += "<td align='left' bgcolor='White' class='formTextSmallPrintUser' style ='padding-left :5px;'>" + Convert.ToString(dtrow["product_size"]) + " </td>";
                //            orderDetailsString += "<td align='left' bgcolor='White' class='formTextSmallPrintUser' style ='padding-left :5px;'>" + Convert.ToString(ordPice) + " </td></tr><tr><td height='5px'></td></tr>";
                //        }
                //        orderDetailsString += "</table>";
                //    }
                //}
               
                int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                int userId = Convert.ToInt32(Request.Cookies["userId"].Value);
                DataSet dsUserProductList = new DataSet();
                dsUserProductList = dbInfo.GetUserOrderProductDetail(orderId, userId);
                int Count=0;
                if (dsUserProductList.Tables.Count > 0)
                {
                    if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                        {
                            Count++;
                            orderDetailsString += Count + ") ";
                            string ordPice = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));
                            string Qty = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_quantity"]), 2));
                            orderDetailsString += "" + Convert.ToString(Qty) + "&nbsp;&nbsp;&nbsp;";
                            orderDetailsString += "" + Convert.ToString(dtrow["product_title"]) + "&nbsp;&nbsp;&nbsp;     ";
                            orderDetailsString += "" + Convert.ToString(dtrow["product_size"]) + " &nbsp;&nbsp;&nbsp;    ";
                            orderDetailsString += "" + Convert.ToString(ordPice) ;
                            orderDetailsString += " <br />";
                        }
                    }
                }



                emailVariable["$orderDetails$"] = orderDetailsString;


                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }

                string strsubject = "Confirmation for" + " " + strCompanyName + " " + " order number: " + lblOrderNumber.Text;
                emailToUser.Subject = strsubject;
                emailToUser.Body = strEmailContent;
                emailToUser.IsBodyHtml = true;
               // string strBCC1 = Convert.ToString(ViewState["ContactEmail"]);
                string strBCC2 = Convert.ToString(ViewState["CustomerServiceEmail"]);
 
                //MailAddress bcc1 = new MailAddress(strBCC1);
                //MailAddress bcc2 = new MailAddress(strBCC2);
                //emailToUser.Bcc.Add(bcc1);
               // emailToUser.Bcc.Add(bcc2);
 
            //    MailAddress bcc1 = new MailAddress(strBCC1);
                MailAddress bcc2 = new MailAddress(strBCC2);
               // emailToUser.Bcc.Add(bcc1);
                emailToUser.Bcc.Add(bcc2);
 
                SmtpClient smtpServer = new SmtpClient();
                smtpServer.Send(emailToUser);
                status = 1;
                EmailCount.Value = orderId.ToString();
            }

            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            return status;
        }
    }
}

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
using groceryguys.Class;

namespace groceryguys.Admin
{
    public partial class UserOrderdetailsPrint : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private string address2 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {


                    int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
                    int userId = Convert.ToInt32(Request.QueryString["userId"]);
                    string strPaymentType = string.Empty;
                    string strText = string.Empty;
                    double accountdebit = 0;
                    DataSet dsUserItemList = new DataSet();
                    dsUserItemList = dbListInfo.GetHomeUserInformation(userId);
                    if (dsUserItemList.Tables.Count > 0)
                    {
                        if (dsUserItemList != null && dsUserItemList.Tables.Count > 0 && dsUserItemList.Tables[0].Rows.Count > 0)
                        {

                            lblFName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_fname"]);
                            lblLName.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_lname"]);
                            lblPhone.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_phone"]);
                            lblPhone2.Text = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_cell"]);
                            address2 = Convert.ToString(dsUserItemList.Tables[0].Rows[0]["users_address2"]);
                           
                        }
                    }

                    DataSet dsUserOrderList = new DataSet();
                    dsUserOrderList = dbListInfo.GetUserOrderDetail(userId, orderId);
                    if (dsUserOrderList.Tables.Count > 0)
                    {
                        if (dsUserOrderList != null && dsUserOrderList.Tables.Count > 0 && dsUserOrderList.Tables[0].Rows.Count > 0)
                        {
                            lblAddress.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address"]);
                            lblAddress2.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_address2"]);
                            if (lblAddress2.Text.Trim()==string.Empty)
                            {
                                lblAddress2.Text = address2;
                            }
                            lblCity.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_city"]);
                            lblState.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_state"]);
                            lblZip.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_zip"]);
                            lblOrderNumber.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_number"]);
                            lblOrederDate.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["ordered"]);
                            lblDeliveryDateTime.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["delivery"]);
                            lblSpecialOrInfo.Text = Convert.ToString(dsUserOrderList.Tables[0].Rows[0]["orders_instructions"]);
                            //lblSubtotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_grocerytotal"]), 2));
                            //lblTax.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_tax"]), 2));
                            //lblSodaDeposit.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_sodadeposit"]), 2));
                            //lblDeliveryFee.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_deliveryfee"]), 2));
                            //lblTips.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]), 2));
                            //lblOrderTotal.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2));

                            lblSubtotal.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_grocerytotal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblTax.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tax"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblTax2.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tax2"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblSodaDeposit.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_sodadeposit"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                            lblDeliveryFee.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_deliveryfee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);



                            int tip = Convert.ToInt16(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]);

                            if (Convert.ToInt16(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]) ==0)
                            {
                                lblTips.Text = "___________";
                            }
                            else
                            {

                                lblTips.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                            }




                            lblOrderTotal.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                            if (Convert.ToInt16(dsUserOrderList.Tables[0].Rows[0]["orders_tip"]) == 0)
                            {
                                lblTipTotal.Text = "___________";
                            }
                            else
                            {

                                lblTipTotal.Text = Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                            }
                            // tarsaction amount 
                            double transactions_amount = dbListInfo.deposite_amount(userId, orderId);
                            double Total = Convert.ToDouble(lblOrderTotal.Text) + transactions_amount;

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
                                accountdebit = Math.Round(Convert.ToDouble(System.Math.Abs(transactions_amount)), 2);
                                //accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                                //strText = Convert.ToString(accountdebit) + " "+ Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) + " " + Convert.ToString(AppConstants.strCODDetail);
                                //  strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCODDetail);
                                strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(Total).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCODDetail);
                                lblPaymentMethod.Text = strText;  
                            }
                            else if (strPaymentType == Convert.ToString(AppConstants.strAFCC))
                            {
                                accountdebit = Math.Round(Convert.ToDouble(System.Math.Abs(transactions_amount)), 2);
                                // accountdebit = Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_totalfinal"]), 2) - Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2);
                                //strText = Convert.ToString(accountdebit) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToString(Math.Round(Convert.ToDouble(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]), 2)) + " " + Convert.ToString(AppConstants.strCCDetail);
                                // strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(dsUserOrderList.Tables[0].Rows[0]["orders_complimentary"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCCDetail);
                                 strText = Convert.ToDecimal(accountdebit).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strAFDetail) + "<br>" + Convert.ToDecimal(Total).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " " + Convert.ToString(AppConstants.strCCDetail);
                                lblPaymentMethod.Text = strText;  
                            }
                            else
                            {
                                lblPaymentMethod.Text = "";
                            }


                        }
                    }
                    BindProductGrid();




                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }
            }


        }






        public void BindProductGrid()
        {
            int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
            DataSet dsUserProductList = new DataSet();
            dsUserProductList = dbListInfo.GetUserProductDetail(orderId);
            if (dsUserProductList.Tables.Count > 0)
            {
                if (dsUserProductList != null && dsUserProductList.Tables.Count > 0 && dsUserProductList.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dtrow in dsUserProductList.Tables[0].Rows)
                    {

                        //dtrow["orderproduct_price"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orderproduct_price"]), 2));
                        dtrow["orderproduct_price"] = Convert.ToDecimal(dtrow["orderproduct_price"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
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

        }

        
    }
}

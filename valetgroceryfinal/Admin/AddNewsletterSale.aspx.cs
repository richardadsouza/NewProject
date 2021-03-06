﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Collections.Specialized;
using groceryguys.Class;

namespace groceryguys.Admin
{
    public partial class AddNewsletterSale : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropSales = new DropdownProvider();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                changeLinks();
                getCompanyName();
                if (!Page.IsPostBack)
                {
                    dropSales.bindSalesItemDropdown(drpSaleItem1);
                    dropSales.bindSalesItemDropdown(drpSaleItem2);
                    dropSales.bindSalesItemDropdown(drpSaleItem3);
                    dropSales.bindSalesItemDropdown(drpSaleItem4);
                    dropSales.bindSalesItemDropdown(drpSaleItem5);
                    dropSales.bindSalesItemDropdown(drpSaleItem6);
                    dropSales.bindSalesItemDropdown(drpSaleItem7);
                    dropSales.bindSalesItemDropdown(drpSaleItem8);
                    int intcheck = 0;
                    intcheck = Convert.ToInt32(Request.QueryString["check"]);
                    if (intcheck == 1)
                    {
                        BindSubject();
                        if (Request.Cookies["SaleProdInfo"] != null)
                        {
                            string tempSaleProduct = Convert.ToString(Request.Cookies["SaleProdInfo"].Value);
                            if (tempSaleProduct != "" || tempSaleProduct != null)
                            {
                                string[] splitter = { "|" };
                                string[] prodInfo = tempSaleProduct.Split(splitter, StringSplitOptions.None);

                                drpSaleItem1.SelectedValue = prodInfo[0].ToString();
                                drpSaleItem2.SelectedValue = prodInfo[1].ToString();
                                drpSaleItem3.SelectedValue = prodInfo[2].ToString();
                                drpSaleItem4.SelectedValue = prodInfo[3].ToString();
                                drpSaleItem5.SelectedValue = prodInfo[4].ToString();
                                drpSaleItem6.SelectedValue = prodInfo[5].ToString();
                                drpSaleItem7.SelectedValue = prodInfo[6].ToString();
                                drpSaleItem8.SelectedValue = prodInfo[7].ToString();
                            }
                        }

                    }
                    else
                    {
                        if (Request.Cookies["SaleProdInfo"] != null)
                        {

                            string tempSaleProduct = Convert.ToString(Request.Cookies["SaleProdInfo"].Value);
                            if (tempSaleProduct != "" || tempSaleProduct != null)
                            {
                                string[] splitter = { "|" };
                                string[] prodInfo = tempSaleProduct.Split(splitter, StringSplitOptions.None);

                                drpSaleItem1.SelectedValue = prodInfo[0].ToString();
                                drpSaleItem2.SelectedValue = prodInfo[1].ToString();
                                drpSaleItem3.SelectedValue = prodInfo[2].ToString();
                                drpSaleItem4.SelectedValue = prodInfo[3].ToString();
                                drpSaleItem5.SelectedValue = prodInfo[4].ToString();
                                drpSaleItem6.SelectedValue = prodInfo[5].ToString();
                                drpSaleItem7.SelectedValue = prodInfo[6].ToString();
                                drpSaleItem8.SelectedValue = prodInfo[7].ToString();
                            }
                        }
                    }

                    // BindGrid();

                    Page.ClientScript.RegisterOnSubmitStatement(
                   FCKeditor1.GetType(),
                         "editor1",
                     "FCKeditorAPI.GetInstance('" + FCKeditor1.ClientID + "').UpdateLinkedField();");

                    Page.ClientScript.RegisterOnSubmitStatement(
                        FCKeditor2.GetType(),
                        "editor2",
                        "FCKeditorAPI.GetInstance('" + FCKeditor2.ClientID + "').UpdateLinkedField();");
                    

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        public void BindSubject()
        {
            DataSet dsSubject = new DataSet();
           
            dsSubject = dbListInfo.SelectSubject();
            if (dsSubject.Tables.Count > 0)
            {
                if (dsSubject != null && dsSubject.Tables.Count > 0 && dsSubject.Tables[0].Rows.Count > 0)
                {
                    txtFromDate.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["StarDate"]);
                    txtToDate.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["EndDate"]); ;
                    FCKeditor1.Value = Convert.ToString(dsSubject.Tables[0].Rows[0]["HeaderMsg"]);
                    FCKeditor2.Value = Convert.ToString(dsSubject.Tables[0].Rows[0]["FooterMsg"]);
                    txtSubject.Text = Convert.ToString(dsSubject.Tables[0].Rows[0]["Subject"]);
                    

                }
            }
        }

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminCustomers.Tables[0].Rows.Count > 0)
            {
                if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
                {
                    MyDataListCustomers.DataSource = dsAdminCustomers;
                    MyDataListCustomers.DataBind();
                }

            }
            //for Site Functions

            DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
            sideType = 2;
            DataSet dsAdminSiteFunctions = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
            {
                if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
                {
                    MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
                    MyDataListSiteFunctions.DataBind();
                }

            }

            //for reports

            DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
            sideType = 3;
            DataSet dsAdminReports = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListCustomers.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbCustomers");
                string name = MyLinkButton.Text;
                if (name == "Newsletter (sales)")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }

            // for Payment Options
            //sideType = 5;
            //DataSet dsAdminPayment = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

            //if (dsAdminPayment.Tables[0].Rows.Count > 0)
            //{
            //    if (dsAdminPayment != null && dsAdminPayment.Tables.Count > 0 && dsAdminPayment.Tables[0].Rows.Count > 0)
            //    {
            //        Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
            //        pnlPayment.Visible = true;
            //    }
            //    else
            //    {
            //        Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
            //        pnlPayment.Visible = false;

            //    }

            //}
            //else
            //{
            //    Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
            //    pnlPayment.Visible = false;

            //}
            dbListInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Addnewslettersales;
                        
                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        //public void BindGrid()
        //{

        //    int intCnt = 0;
        //    string strView = string.Empty;
        //    DataSet dsSalesItemList = new DataSet();
        //    dsSalesItemList = dbListInfo.GetSalesDetails(Convert.ToInt32(AppConstants.locationId));
        //    if (dsSalesItemList.Tables.Count > 0)
        //    {
        //        if (dsSalesItemList != null && dsSalesItemList.Tables.Count > 0 && dsSalesItemList.Tables[0].Rows.Count > 0)
        //        {
        //            intCnt = Convert.ToInt32(dsSalesItemList.Tables[0].Rows.Count);
        //            for (int Cnt = 0; Cnt < intCnt; Cnt++)
        //            {
        //                if (Cnt == 0)
        //                {
        //                    txtSaleItem1.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[0]["product_title"]);
        //                }
        //                else if (Cnt == 1)
        //                {

        //                    txtSaleItem2.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[1]["product_title"]);
        //                }
        //                else if (Cnt == 2)
        //                {
        //                    txtSaleItem3.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[2]["product_title"]);
        //                }
        //                else if (Cnt == 3)
        //                {
        //                    txtSaleItem4.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[3]["product_title"]);
        //                }
        //                else if (Cnt == 4)
        //                {
        //                    txtSaleItem5.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[4]["product_title"]);
        //                }
        //                else if (Cnt == 5)
        //                {
        //                    txtSaleItem6.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[5]["product_title"]);
        //                }
        //                else if (Cnt == 6)
        //                {
        //                    txtSaleItem7.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[6]["product_title"]);
        //                }
        //                else if (Cnt == 7)
        //                {
        //                    txtSaleItem8.Text = Convert.ToString(dsSalesItemList.Tables[0].Rows[7]["product_title"]);
        //                }
        //            }

        //        }

        //    }

        //}


        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_newsletter_sale.aspx", false);

        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_newsletter_sale.aspx", false);

        }

        protected void btnPreviewNewsletter_Click(object sender, EventArgs e)
        {
            int intlocId = 0;
            intlocId = Convert.ToInt32(Request.QueryString["intlocId"]);
            string strHeader=string.Empty;
            int intPreview = 0;
             string strFooter=string.Empty;
             string strStartDate = string.Empty;
             string strToDate = string.Empty;
             string strProd1 = string.Empty;
             string strProd2 = string.Empty;
             string strProd3 = string.Empty;
             string strProd4 = string.Empty;
             string strProd5 = string.Empty;
             string strProd6 = string.Empty;
             string strProd7 = string.Empty;
             string strProd8 = string.Empty;

            strStartDate = txtFromDate.Text;
             strToDate = txtToDate.Text;          
        
           int intDate = CheckDate();
           if (intDate == 0)
           {
              
              strHeader = FCKeditor1.Value;
               strFooter = FCKeditor2.Value;

               string tempProd1 = drpSaleItem1.SelectedValue;
               string tempProd2 = drpSaleItem2.SelectedValue;
               string tempProd3 = drpSaleItem3.SelectedValue;
               string tempProd4 = drpSaleItem4.SelectedValue;
               string tempProd5 = drpSaleItem5.SelectedValue;
               string tempProd6 = drpSaleItem6.SelectedValue;
               string tempProd7 = drpSaleItem7.SelectedValue;
               string tempProd8 = drpSaleItem8.SelectedValue;

               string strTemSaleProd = tempProd1 + "|" + tempProd2 + "|" + tempProd3 + "|" + tempProd4 + "|" + tempProd5 + "|" + tempProd6 + "|" + tempProd7 + "|" + tempProd8;
               HttpCookie SaleProdInfo = new HttpCookie("SaleProdInfo", strTemSaleProd);
               Response.Cookies.Add(SaleProdInfo);
               SaleProdInfo.Expires = DateTime.Now.AddDays(1);


                DataSet dsPreview = new DataSet();
                dsPreview = dbListInfo.GetPreviewDetails(intlocId);
                if (dsPreview.Tables.Count > 0)
                {
                    if (dsPreview != null && dsPreview.Tables.Count > 0 && dsPreview.Tables[0].Rows.Count > 0)
                    {
                        int intPreviewId = Convert.ToInt32(AppConstants.intPreview);
                        intPreview = dbListInfo.UpdatePreviewInfo(txtSubject.Text, strStartDate, strToDate, strHeader, strFooter, intlocId, intPreviewId, strProd1, strProd2, strProd3, strProd4, strProd5, strProd6, strProd7, strProd8);
                        Response.Redirect("Newsletter.aspx?zipcode="+ Request.QueryString["zipcode"]);
                       // Response.Redirect("Test.aspx");


                    }
                    else
                    {
                        intPreview = dbListInfo.InsertPreviewInfo(txtSubject.Text, strStartDate, strToDate, strHeader, strFooter, intlocId,intlocId, strProd1, strProd2, strProd3, strProd4, strProd5, strProd6, strProd7, strProd8);
                        Response.Redirect("Newsletter.aspx?zipcode=" + Request.QueryString["zipcode"]);
                        // Response.Redirect("Test.aspx");
                    }
                }
                else
                {
                    intPreview = dbListInfo.InsertPreviewInfo(txtSubject.Text, strStartDate, strToDate, strHeader, strFooter, intlocId, intlocId, strProd1, strProd2, strProd3, strProd4, strProd5, strProd6, strProd7, strProd8);
                    Response.Redirect("Newsletter.aspx?zipcode=" + Request.QueryString["zipcode"]);
                    //Response.Redirect("Test.aspx");


                }
                    
         

               
           }
           else
           {

           }

        }

        public int CheckDate()
        {
            int returnDate = 0;
            int returnDate1 = 0;

            DataValidator dataValidator = new DataValidator();
            returnDate = DataValidator.checkDateEntered(txtFromDate.Text);
            returnDate1 = DataValidator.checkDateEntered(txtToDate.Text);
            if (returnDate ==   1 || returnDate1 == 1)
            {
                if (returnDate == 1 && returnDate1 == 1)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidSEDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;
                }
                else if (returnDate == 1)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidSDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;

                }
                else if (returnDate1 == 1)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidEDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;

                }

            }
            else
            {




                returnDate = DataValidator.IsValidDateGreaterToday(txtFromDate.Text);
                if (returnDate == 0)
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.invalidNewsStartDate;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    returnDate = 1;

                }
                else
                {
                    returnDate = DataValidator.IsValidNewsLetterDate(txtFromDate.Text, txtToDate.Text);
                    if (returnDate == 2)
                    {

                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.invalidNewsEndDate;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        returnDate = 2;

                    }
                    else
                    {
                        lblMsg.Text = "";
                        returnDate = 0;


                    }

                }
            }

            return returnDate;

        }
    }
}

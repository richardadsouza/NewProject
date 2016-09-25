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
using System.Configuration;
using System.Collections;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Specialized;
using System.Drawing.Drawing2D;
using System.IO;




namespace groceryguys.Admin
{
    public partial class AddAisle : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        DropdownProvider dropTopAisle = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                dropTopAisle.bindTopAisleCheckbox(chkTopAisles);//Bind Checkbox into dropdown
                lblMsg.Text = "";
              
            }

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.AddAisle;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Aisles")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
           

            // for Payment Options
            //sideType = 5;
            //DataSet dsAdminPayment = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

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
            dbAddInfo.dispose();
        }


        public void clear()
        {

            txtAisleName.Text = "";
            rdShow.SelectedValue = "1";

            for (int intTopAisleVal = 0; intTopAisleVal < chkTopAisles.Items.Count; intTopAisleVal++)
            {
                if (chkTopAisles.Items[intTopAisleVal].Selected == true)
                {
                    chkTopAisles.Items[intTopAisleVal].Selected = false;

                }
            }

        }

        public int checkValidation()
        {

            DataValidator dataValidator = new DataValidator();

            int intReturn = 0;
            int intChkCnt = 0;
            string strMsg = string.Empty;
            for (int intTopAisleVal = 0; intTopAisleVal < chkTopAisles.Items.Count; intTopAisleVal++)
            {
                if (chkTopAisles.Items[intTopAisleVal].Selected == true)
                {
                    intChkCnt = 1;

                }
            }
            if (intChkCnt == 0)
            {
                strMsg = AppConstants.strSelectTopAisles;
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;

            }
            else
            {
                intReturn = 0;

            }

            return intReturn;



        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int intChkErr = checkValidation();              
                int intInsertAisles = 0;              
                int intAisle = 0;
                int intInsertTopAisleMapping = 0;
               
                if (intChkErr == 0)
                {
                    intAisle = dbAddInfo.AisleNameAlreadyExist(txtAisleName.Text);
                    if (intAisle == 0)
                    {

                            intInsertAisles = dbAddInfo.InsertAisleInfo(txtAisleName.Text, Convert.ToInt32(AppConstants.locationId), rdShow.SelectedValue);
                            if (intInsertAisles != 0)
                            {
                                for (int intTopAisleVal = 0; intTopAisleVal < chkTopAisles.Items.Count; intTopAisleVal++)
                                {
                                    if (chkTopAisles.Items[intTopAisleVal].Selected == true)
                                    {
                                        int chkValue = Convert.ToInt32(chkTopAisles.Items[intTopAisleVal].Value);
                                        intInsertTopAisleMapping = dbAddInfo.InsertTopAisleMappingInfo(chkValue, intInsertAisles);

                                    }
                                }
                                clear();
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.asileAddSuccess;
                                lblMsg.ForeColor = System.Drawing.Color.Black;

                            }
                            else
                            {
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.asileAddFailed;
                                lblMsg.ForeColor = System.Drawing.Color.Red;

                            }
                        
                        
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.asileAlreadyExist;
                        lblMsg.ForeColor = System.Drawing.Color.Red;


                    }


                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }


        }


        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_category.aspx", false);
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            lblMsg.Text = "";
            Response.Redirect("admin_category.aspx", false);

        }
    }
}

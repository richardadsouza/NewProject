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
    public partial class admin_product : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                dropLocation.bindLocationDropdown(drpLocation);//Bind location  into dropdown
                dropLocation.bindShelfDropdown(drpShelf);//Bind shelf  into dropdown
                string Check=string.Empty;
                Check = Request.QueryString["check"];
                if (Check != "" && Check!=null)
                {

                    drpLocation.SelectedValue = Request.QueryString["loc"];
                    drpShelf.SelectedValue = Request.QueryString["shefId"];
                    txtKeyWord.Text = Request.QueryString["strKey"];
                    int perPage = Convert.ToInt32(Request.QueryString["perPage"]);
                    if (perPage == 10)
                    {
                        drpPerPage.SelectedValue = "Select";
                    }
                    else
                    {
                        drpPerPage.SelectedValue = Convert.ToString(perPage);
                    }
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


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Products")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.Product;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("AddProduct.aspx", false);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }

        protected void btnBegin_Click(object sender, EventArgs e)
        {
            try
            {
                int locationId = 0;
                int perPage = 0;
                int shefId = 0;
                string strKey = string.Empty;
                locationId = Convert.ToInt32(drpLocation.SelectedValue);
                if (drpShelf.SelectedValue != "Select")
                {
                    shefId = Convert.ToInt32(drpShelf.SelectedValue);
                }
                else
                {
                    shefId = 0;
                }
                if (drpPerPage.SelectedValue != "Select")
                {
                    perPage = Convert.ToInt32(drpPerPage.SelectedValue);
                }
                else
                {
                    perPage = 10;
                }
                
                strKey = txtKeyWord.Text;
                Response.Redirect("ViewProductdDetails.aspx?loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }
    }
}

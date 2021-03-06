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
using System.Data.SqlClient;

namespace groceryguys.Admin
{
    public partial class index3 : System.Web.UI.Page
    {
        DbProvider dbloginInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                try
                {
                    string admin = string.Empty;
                    string strName = string.Empty;
                    
                    DataSet dsAdminList = new DataSet();
                    admin = Convert.ToString(Request.Cookies["adminId"].Value);
                    dsAdminList = dbloginInfo.SelectEmployeeDetails(Convert.ToInt32(admin));
                    if (dsAdminList.Tables.Count > 0)
                     {
                         if (dsAdminList != null && dsAdminList.Tables.Count > 0 && dsAdminList.Tables[0].Rows.Count > 0)
                         {
                             strName = Convert.ToString(dsAdminList.Tables[0].Rows[0]["admin_lname"]) + " " + Convert.ToString(dsAdminList.Tables[0].Rows[0]["admin_fname"]);                           
                         }
                     }

                    lblUserName.Text = strName;
                    lblCmpyNm.Text = Convert.ToString(ViewState["CompanyName"]);
                    BindOrderGrid();
                    BindUSerGrid();

                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }

        //public void changeLinks()
        //{

        //    int sideType = 0;
        //    string admin = Convert.ToString(Request.Cookies["adminId"].Value);

        //    //For Customers 
        //    DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
        //    sideType = 1;
        //    DataSet dsAdminCustomers = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
        //    if (dsAdminCustomers.Tables[0].Rows.Count > 0)
        //    {
        //        if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
        //        {
        //            MyDataListCustomers.DataSource = dsAdminCustomers;
        //            MyDataListCustomers.DataBind();
        //        }
        //        //else
        //        //{
        //        //    Panel pnlCustomer = (Panel)Page.Master.FindControl("pnlCustomer");
        //        //    pnlCustomer.Visible = false;

        //        //}

        //    }
        //    //else
        //    //{
        //    //    Panel pnlCustomer = (Panel)Page.Master.FindControl("pnlCustomer");
        //    //    pnlCustomer.Visible = false;

        //    //}

        //    //for Site Functions

        //    DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
        //    sideType = 2;
        //    DataSet dsAdminSiteFunctions = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
        //    if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
        //    {
        //        if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
        //        {
        //            MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
        //            MyDataListSiteFunctions.DataBind();
        //        }
        //        //else
        //        //{
        //        //    Panel pnlSiteFunction = (Panel)Page.Master.FindControl("pnlSiteFunction");
        //        //    pnlSiteFunction.Visible = false;

        //        //}

        //    }
        //    //else
        //    //{
        //    //    Panel pnlSiteFunction = (Panel)Page.Master.FindControl("pnlSiteFunction");
        //    //    pnlSiteFunction.Visible = false;

        //    //}

        //    //for reports

        //    DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
        //    sideType = 3;
        //    DataSet dsAdminReports = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
        //    if (dsAdminReports.Tables[0].Rows.Count > 0)
        //    {
        //        if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
        //        {
        //            MyDataListReports.DataSource = dsAdminReports;
        //            MyDataListReports.DataBind();
        //        }
        //        //else
        //        //{
        //        //    Panel pnlReports = (Panel)Page.Master.FindControl("pnlReports");
        //        //    pnlReports.Visible = false;

        //        //}

        //    }
        //    //else
        //    //{
        //    //    Panel pnlReports = (Panel)Page.Master.FindControl("pnlReports");
        //    //    pnlReports.Visible = false;

        //    //}
            
            
        //    // for Payment Options
        //    //sideType = 5;
        //    //DataSet dsAdminPayment = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

        //    //if (dsAdminPayment.Tables[0].Rows.Count > 0)
        //    //{
        //    //    if (dsAdminPayment != null && dsAdminPayment.Tables.Count > 0 && dsAdminPayment.Tables[0].Rows.Count > 0)
        //    //    {
        //    //        Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
        //    //        pnlPayment.Visible = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
        //    //        pnlPayment.Visible = false;

        //    //    }

        //    //}
        //    //else
        //    //{
        //    //    Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
        //    //    pnlPayment.Visible = false;

        //    //}
        //}
        public void changeLinks()
        {
            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

            if (dsAdminCustomers.Tables[0].Rows.Count > 0)
            {
                if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
                {
                    MyDataListCustomers.DataSource = dsAdminCustomers;
                    MyDataListCustomers.DataBind();
                }
                //else
                //{
                //    Panel pnlCustomer = (Panel)Page.Master.FindControl("pnlCustomer");
                //    pnlCustomer.Visible = false;

                //}

            }
            //else
            //{
            //    Panel pnlCustomer = (Panel)Page.Master.FindControl("pnlCustomer");
            //    pnlCustomer.Visible = false;

            //}

            //for Site Functions

            DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
            sideType = 2;
            DataSet dsAdminSiteFunctions = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

            if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
            {
                if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
                {
                    MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
                    MyDataListSiteFunctions.DataBind();
                }
                //else
                //{
                //    Panel pnlSiteFunction = (Panel)Page.Master.FindControl("pnlSiteFunction");
                //    pnlSiteFunction.Visible = false;

                //}
            }
            //else
            //{
            //    Panel pnlSiteFunction = (Panel)Page.Master.FindControl("pnlSiteFunction");
            //    pnlSiteFunction.Visible = false;

            //}

            //for reports

            DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
            sideType = 3;
            DataSet dsAdminReports = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }
                //else
                //{
                //    Panel pnlReports = (Panel)Page.Master.FindControl("pnlReports");
                //    pnlReports.Visible = false;

                //}
            }
            //else
            //{
            //    Panel pnlReports = (Panel)Page.Master.FindControl("pnlReports");
            //    pnlReports.Visible = false;

            //}

            // for Payment Options
            sideType = 5;
            DataSet dsAdminPayment = dbloginInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

            if (dsAdminPayment.Tables[0].Rows.Count > 0)
            {
                if (dsAdminPayment != null && dsAdminPayment.Tables.Count > 0 && dsAdminPayment.Tables[0].Rows.Count > 0)
                {
                    Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
                    pnlPayment.Visible = true;
                }
                else
                {
                    Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
                    pnlPayment.Visible = false;
                }

            }
            else
            {
                Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
                pnlPayment.Visible = false;
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.HomePage;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindOrderGrid()
        {
            DataSet dsOrderList = new DataSet();
            DateTime dtToday = DateTime.Today;
            string strMonth = string.Empty;
            string strDay = string.Empty;
            if (Convert.ToInt32(dtToday.Month) < 10)
            {
                strMonth = '0' + Convert.ToString(dtToday.Month);
            }
            else
            {
                strMonth = Convert.ToString(dtToday.Month);

            }
            if (Convert.ToInt32(dtToday.Day) < 10)
            {
                strDay = '0' + Convert.ToString(dtToday.Day);
            }
            else
            {
                strDay = Convert.ToString(dtToday.Day);

            }
            string strToday = strMonth + "/" + strDay + "/" + Convert.ToString(dtToday.Year);
            //dsOrderList = dbloginInfo.GetHomeOrderDetailInfo(Convert.ToInt32(AppConstants.locationId),strToday);
            dsOrderList = dbloginInfo.GetHomeOrderDetailInfo1(Convert.ToInt32(AppConstants.locationId));
            if (dsOrderList.Tables.Count > 0)
            {
                if (dsOrderList != null && dsOrderList.Tables.Count > 0 && dsOrderList.Tables[0].Rows.Count > 0)
                {
                    gridOrderList.DataSource = dsOrderList;
                    gridOrderList.DataBind();

                }
                else
                {
                    gridOrderList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridOrderList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }










          
        }


        protected void gridOrderList_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection1 == SortDirection.Descending)
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection1 = SortDirection.Ascending;
                    SortGridView1(sortExpression, ASCENDING);
                }
                else
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection1 = SortDirection.Descending;
                    SortGridView1(sortExpression, DESCENDING);
                }
            }
            catch (Exception Addadvert_grid_Sortinge)
            {
                lblMsg1.Visible = true;
                lblMsg1.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
                lblMsg1.ForeColor = System.Drawing.Color.Red;
            }
        }


        public SortDirection GridViewSortDirection1
        {
            get
            {
                if (ViewState["sortDirection1"] == null)
                    ViewState["sortDirection1"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection1"];
            }
            set { ViewState["sortDirection1"] = value; }
        }

        private void SortGridView1(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance

            DataSet dsOrderList = new DataSet();
            DateTime dtToday = DateTime.Today;
            string strMonth = string.Empty;
            string strDay= string.Empty;
            if (Convert.ToInt32(dtToday.Month) < 10)
            {
                strMonth = '0' + Convert.ToString(dtToday.Month);
            }
            else
            {
                strMonth = Convert.ToString(dtToday.Month);

            }
            if (Convert.ToInt32(dtToday.Day) < 10)
            {
                strDay = '0' + Convert.ToString(dtToday.Day);
            }
            else
            {
                strDay = Convert.ToString(dtToday.Day);

            }
            string strToday = strMonth + "/" + strDay + "/" + Convert.ToString(dtToday.Year);
          //  dsOrderList = dbloginInfo.GetHomeOrderDetailInfo(Convert.ToInt32(AppConstants.locationId),strToday);
            dsOrderList = dbloginInfo.GetHomeOrderDetailInfo1(Convert.ToInt32(AppConstants.locationId));
            if (dsOrderList.Tables.Count > 0)
            {
                if (dsOrderList != null && dsOrderList.Tables.Count > 0 && dsOrderList.Tables[0].Rows.Count > 0)
                {
                    DataTable dtSorting = dsOrderList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridOrderList.DataSource = dvSorting;
                    gridOrderList.DataBind();

                }
            }
            dbloginInfo.dispose();
        }


        public void BindUSerGrid()
        {
            DataSet dsUserList = new DataSet();
            dsUserList = dbloginInfo.GetHomeUserDetailInfo();
            if (dsUserList.Tables.Count > 0)
            {
                if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                {
                    griduserList.DataSource = dsUserList;
                    griduserList.DataBind();

                }
                else
                {
                    griduserList.Visible = false;
                    lblMsg1.Text = "";
                    lblMsg1.Visible = true;
                    lblMsg1.Text = AppConstants.noRecord;
                    lblMsg1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                griduserList.Visible = false;
                lblMsg1.Text = "";
                lblMsg1.Visible = true;
                lblMsg1.Text = AppConstants.noRecord;
                lblMsg1.ForeColor = System.Drawing.Color.Red;
            }



            
        }


        protected void griduserList_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection == SortDirection.Descending)
                {
                    lblMsg1.Visible = false;
                    GridViewSortDirection = SortDirection.Ascending;
                    SortGridView(sortExpression, ASCENDING);
                }
                else
                {
                    lblMsg1.Visible = false;
                    GridViewSortDirection = SortDirection.Descending;
                    SortGridView(sortExpression, DESCENDING);
                }
            }
            catch (Exception Addadvert_grid_Sortinge)
            {
                lblMsg1.Visible = true;
                lblMsg1.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
                lblMsg1.ForeColor = System.Drawing.Color.Red;
            }
        }


        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        private void SortGridView(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance

            DataSet dsUserList = new DataSet();
            dsUserList = dbloginInfo.GetHomeUserDetailInfo();
            if (dsUserList.Tables.Count > 0)
            {
                if (dsUserList != null && dsUserList.Tables.Count > 0 && dsUserList.Tables[0].Rows.Count > 0)
                {

                    DataTable dtSorting = dsUserList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    griduserList.DataSource = dvSorting;
                    griduserList.DataBind();

                }
            }
            dbloginInfo.dispose();
        }
              
    }
}

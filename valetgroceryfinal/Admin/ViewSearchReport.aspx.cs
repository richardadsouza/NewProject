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
    public partial class ViewSearchReport : System.Web.UI.Page
    {
        DbProvider dbSearchReport = new DbProvider();
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
                    BindGrid();
                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.searchReportPageTitle;
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
            DataSet dsAdminCustomers = dbSearchReport.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbSearchReport.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbSearchReport.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListReports.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbreports");
                string name = MyLinkButton.Text;
                if (name == "Searched Report")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbSearchReport.dispose();


        }


        public void BindGrid()
        {
            string popular = "";
            string pages = "";

            popular = Convert.ToString(Request.QueryString["popular"]);
            pages = Convert.ToString(Request.QueryString["pages"]);

            string strStartDate = Request.QueryString["startDate"];
            string strToDate = Request.QueryString["endDate"];

            lblStartDate.Text = strStartDate;
            lblEndDate.Text = strToDate;


            if (popular == "1")
            {
                DataSet dsSelectSearchReport = new DataSet();
                dsSelectSearchReport = dbSearchReport.getSearchReportsByDescOrderbydate(strStartDate, strToDate);


                if (dsSelectSearchReport.Tables.Count > 0)
                {
                    if (dsSelectSearchReport != null && dsSelectSearchReport.Tables.Count > 0 && dsSelectSearchReport.Tables[0].Rows.Count > 0)
                    {
                        //check when no posts or photos found

                        gridSearchReport.DataSource = dsSelectSearchReport;
                        gridSearchReport.DataBind();

                    }
                    else
                    {
                        gridSearchReport.Visible = false;
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.noRecord;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    gridSearchReport.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                DataSet dsSelectSearchReport = new DataSet();
                dsSelectSearchReport = dbSearchReport.getSearchReportsByAscOrderbydate(strStartDate, strToDate);


                if (dsSelectSearchReport.Tables.Count > 0)
                {
                    if (dsSelectSearchReport != null && dsSelectSearchReport.Tables.Count > 0 && dsSelectSearchReport.Tables[0].Rows.Count > 0)
                    {
                        //check when no posts or photos found

                        gridSearchReport.DataSource = dsSelectSearchReport;
                        gridSearchReport.DataBind();

                    }
                    else
                    {
                        gridSearchReport.Visible = false;
                        lblMsg.Text = "";
                        lblMsg.Text = AppConstants.noRecord;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    gridSearchReport.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }


            dbSearchReport.dispose();

        }
        protected void gridSearchReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridSearchReport.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        //Code for zip code grid sorting
        protected void gridSearchReport_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Descending;
                    SortGridView(sortExpression, DESCENDING);
                }
                else
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Ascending;
                    SortGridView(sortExpression, ASCENDING);
                }
            }
            catch (Exception Addadvert_grid_Sortinge)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Sorry, " + Addadvert_grid_Sortinge.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
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

            string strStartDate = Request.QueryString["startDate"];
            string strToDate = Request.QueryString["endDate"];


            DataSet dsSelectUser = new DataSet();
            //dsSelectUser = dbSearchReport.SelectAdminZipCodes();

            dsSelectUser = dbSearchReport.selectSearchReportAscbydateSort(strStartDate, strToDate);;

            if (dsSelectUser != null && dsSelectUser.Tables.Count > 0 && dsSelectUser.Tables[0].Rows.Count > 0)
            {
                DataTable ds1 = dsSelectUser.Tables[0];
                DataView dv = new DataView(ds1);
                dv.Sort = sortExpression + direction;
                gridSearchReport.DataSource = dv;
                gridSearchReport.DataBind();
            }
            dbSearchReport.dispose();
        }




        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            string popular = "";
            string pages = "";
            popular = Convert.ToString(Request.QueryString["popular"]);
            pages = Convert.ToString(Request.QueryString["pages"]);
            Response.Redirect("admin_search_report.aspx?check=1&popular=" + popular + "&pages=" + pages);
            
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
           

            string popular = "";
            string pages = "";
            popular = Convert.ToString(Request.QueryString["popular"]);
            pages = Convert.ToString(Request.QueryString["pages"]);
            Response.Redirect("admin_search_report.aspx?check=1&popular=" + popular + "&pages=" + pages);
        }

        protected void gridSearchReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSerial = (Label)e.Row.FindControl("lblSerial");

                lblSerial.Text = ((gridSearchReport.PageIndex * gridSearchReport.PageSize) + e.Row.RowIndex + 1).ToString();
            }
        }
    }
}

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
    public partial class ViewSavedListUserInfo : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
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


            foreach (DataListItem row1 in MyDataListReports.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbreports");
                string name = MyLinkButton.Text;
                if (name == "Saved List Report")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.SavedListReport;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {

            int intList = 0;
            int intLoc = 0;
            intList = Convert.ToInt32(Request.QueryString["intList"]);
            intLoc = Convert.ToInt32(Request.QueryString["intLoc"]);
            Response.Redirect("admin_list_report.aspx?check=2&intList=" + intList  + "&intLoc=" + intLoc, false);


        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {

            int intList = 0;
            int intLoc = 0;
            intList = Convert.ToInt32(Request.QueryString["intList"]);
            intLoc = Convert.ToInt32(Request.QueryString["intLoc"]);
            Response.Redirect("admin_list_report.aspx?check=2&intList=" + intList + "&intLoc=" + intLoc, false);

        }

        public void BindGrid()
        {
            int intList = 0;
            int intLoc = 0;
            intList = Convert.ToInt32(Request.QueryString["intList"]);
            intLoc = Convert.ToInt32(Request.QueryString["intLoc"]);
            DataSet dsSavedList = new DataSet();
            DataSet dsTotal = new DataSet();          
            dsSavedList = dbListInfo.GetSavedUserListReports(intList,intLoc);
            if (dsSavedList.Tables.Count > 0)
            {
                if (dsSavedList != null && dsSavedList.Tables.Count > 0 && dsSavedList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsSavedList.Tables[0].Rows)
                    {
                        dsTotal = dbListInfo.GetSavedTotalReports(Convert.ToInt32(dtrow["list_id"]));
                        dtrow["TotalItem"] = dsTotal.Tables[0].Rows[0]["itemnumber"];
                        
                    }
                    gridUserList.DataSource = dsSavedList;
                    gridUserList.DataBind();

                }
                else
                {
                    gridUserList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridUserList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void gridUserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUserList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["UserSortExpression"]) == "" && Convert.ToString(ViewState["UserDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["UserSortExpression"]), Convert.ToString(ViewState["UserDirection"]));

            }

        }

        protected void gridUserList_Sorting(object sender, GridViewSortEventArgs e)
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
                lblMsg.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
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

            int intList = 0;
            int intLoc = 0;
            intList = Convert.ToInt32(Request.QueryString["intList"]);
            intLoc = Convert.ToInt32(Request.QueryString["intLoc"]);
            DataSet dsSavedList = new DataSet();
            DataSet dsTotal = new DataSet();
            dsSavedList = dbListInfo.GetSavedUserListReports(intList, intLoc);
            if (dsSavedList.Tables.Count > 0)
            {
                if (dsSavedList != null && dsSavedList.Tables.Count > 0 && dsSavedList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsSavedList.Tables[0].Rows)
                    {
                        dsTotal = dbListInfo.GetSavedTotalReports(Convert.ToInt32(dtrow["list_id"]));
                        dtrow["TotalItem"] = dsTotal.Tables[0].Rows[0]["itemnumber"];

                    }
                    DataTable dtSorting = dsSavedList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridUserList.DataSource = dvSorting;
                    gridUserList.DataBind();

                }
            }
            ViewState["UserSortExpression"] = sortExpression;
            ViewState["UserDirection"]=direction;
            dbListInfo.dispose();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using groceryguys.Class;
using System.Data;

namespace groceryguys.Admin
{
    public partial class ViewTaxReportDetail : System.Web.UI.Page
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

                string strStartDate = Request.QueryString["startDate"];
                string strToDate = Request.QueryString["endDate"];
                int locId = Convert.ToInt32(Request.QueryString["locId"]);
                lblStartDate.Text = strStartDate;
                lblEndDate.Text = strToDate;


                BindGrid();

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

            // for Payment Options
            sideType = 5;
            DataSet dsAdminPayment = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

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
            foreach (DataListItem row1 in MyDataListReports.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbreports");
                string name = MyLinkButton.Text;
                if (name == "Tax Report")
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.TaxReport;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
        public void BindGrid()
        {
            string strStartDate = Request.QueryString["startDate"];
            string strToDate = Request.QueryString["endDate"];
            int locId = Convert.ToInt32(Request.QueryString["locId"]);
            double orders_taxtotal = 0;
            double orders_GroceriesTaxtotal = 0;
            double totfoodtotal = 0;
            double totnonfoodtotal = 0;
            double totaltotalfinal = 0;
            DataSet dsOrderList = new DataSet();
            dsOrderList = dbListInfo.GetTaxReportList(strStartDate, strToDate, locId);
            if (dsOrderList.Tables.Count > 0)
            {
                if (dsOrderList != null && dsOrderList.Tables.Count > 0 && dsOrderList.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dsOrderList.Tables[0].Rows[0]["total_tax"].ToString()))
                    {

                        foreach (DataRow dtrow in dsOrderList.Tables[0].Rows)
                        {
                            

                            if (!string.IsNullOrEmpty(dtrow["total_tax"].ToString()))
                            {
                                dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
                                orders_taxtotal = orders_taxtotal + Convert.ToDouble(dtrow["orders_tax"]);
                            }
                            else
                            {
                                dtrow["orders_tax"] = 0;
                                orders_taxtotal = orders_taxtotal + Convert.ToDouble(dtrow["orders_tax"]);

                            }

                            if (!string.IsNullOrEmpty(dtrow["orders_GroceriesTax"].ToString()))
                            {
                                dtrow["orders_GroceriesTax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_GroceriesTax"]), 2));
                                orders_GroceriesTaxtotal = orders_GroceriesTaxtotal + Convert.ToDouble(dtrow["orders_GroceriesTax"]);
                            }
                            else
                            {
                                dtrow["orders_GroceriesTax"] = 0;
                                orders_GroceriesTaxtotal = orders_GroceriesTaxtotal + Convert.ToDouble(dtrow["orders_GroceriesTax"]);

                            }


                            if (!string.IsNullOrEmpty(dtrow["totfood"].ToString()))
                            {
                                dtrow["totfood"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["totfood"]), 2));
                                totfoodtotal = totfoodtotal + Convert.ToDouble(dtrow["totfood"]);
                            }
                            else
                            {
                                dtrow["totfood"] = 0;
                                totfoodtotal = totfoodtotal + Convert.ToDouble(dtrow["totfood"]);

                            }

                            if (!string.IsNullOrEmpty(dtrow["totnonfood"].ToString()))
                            {
                                dtrow["totnonfood"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["totnonfood"]), 2));
                                totnonfoodtotal = totnonfoodtotal + Convert.ToDouble(dtrow["totnonfood"]);
                            }
                            else
                            {
                                dtrow["totnonfood"] = 0;
                                totnonfoodtotal = totnonfoodtotal + Convert.ToDouble(dtrow["totnonfood"]);

                            }
                           
                            

                          

                            dtrow["total_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["total_tax"]), 2));
                            totaltotalfinal = totaltotalfinal + Convert.ToDouble(dtrow["total_tax"]);

                        }
                        lblTotorders_tax.Text = Convert.ToString("$" + orders_taxtotal);
                        lblTotTip.Text = Convert.ToString("$" + orders_GroceriesTaxtotal);
                        lblTotTax.Text = Convert.ToString("$" + totfoodtotal);
                        lblTotDelivery.Text = Convert.ToString("$" + totnonfoodtotal);
                        lblTotal.Text = Convert.ToString("$" + totaltotalfinal);

                        //lblTotGrocery.Text = Convert.ToString("$" + Convert.ToDecimal(grocerytotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                        //lblTotTip.Text = Convert.ToString("$" + Convert.ToDecimal(tiptotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                        //lblTotTax.Text = Convert.ToString("$" + Convert.ToDecimal(taxtotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                        //lblTotDelivery.Text = Convert.ToString("$" + Convert.ToDecimal(deliverytotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                        //lblTotal.Text = Convert.ToString("$" + Convert.ToDecimal(totaltotalfinal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));

                        gridSearchOrders.DataSource = dsOrderList;
                        gridSearchOrders.DataBind();




                    }
                    else
                    {
                        gridSearchOrders.Visible = false;
                        lblMsg.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = AppConstants.noRecord;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    gridSearchOrders.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridSearchOrders.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }
        protected void gridSearchOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSearchOrders.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["OrdersSortExpression"]) == "" && Convert.ToString(ViewState["OrdersDirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView(Convert.ToString(ViewState["OrdersSortExpression"]), Convert.ToString(ViewState["OrdersDirection"]));

            }

        }
        protected void gridSearchOrders_Sorting(object sender, GridViewSortEventArgs e)
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

            string strStartDate = Request.QueryString["startDate"];
            string strToDate = Request.QueryString["endDate"];
            int locId = Convert.ToInt32(Request.QueryString["locId"]);
            //double grocerytotal = 0;
            //double tiptotal = 0;
            //double taxtotal = 0;
            //double deliverytotal = 0;
            double totaltotalfinal = 0;
            double orders_taxtotal = 0;
            double orders_GroceriesTaxtotal = 0;
            double totfoodtotal = 0;
            double totnonfoodtotal = 0;
           // double totaltotalfinal = 0;
            DataSet dsOrderList = new DataSet();
            //dsOrderList = dbListInfo.GetOrderReportList(strStartDate, strToDate, locId);
            //if (dsOrderList.Tables.Count > 0)
            //{
            //    if (dsOrderList != null && dsOrderList.Tables.Count > 0 && dsOrderList.Tables[0].Rows.Count > 0)
            //    {
            //        foreach (DataRow dtrow in dsOrderList.Tables[0].Rows)
            //        {
            //            dtrow["orders_grocerytotal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_grocerytotal"]), 2));
            //            grocerytotal = grocerytotal + Convert.ToDouble(dtrow["orders_grocerytotal"]);

            //            dtrow["orders_tip"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tip"]), 2));
            //            tiptotal = tiptotal + Convert.ToDouble(dtrow["orders_tip"]);

            //            dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
            //            taxtotal = taxtotal + Convert.ToDouble(dtrow["orders_tax"]);

            //            dtrow["orders_deliveryfee"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_deliveryfee"]), 2));
            //            deliverytotal = deliverytotal + Convert.ToDouble(dtrow["orders_deliveryfee"]);

            //            dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));
            //            totaltotalfinal = totaltotalfinal + Convert.ToDouble(dtrow["orders_totalfinal"]);
            //        }

            dsOrderList = dbListInfo.GetTaxReportList(strStartDate, strToDate, locId);
            if (dsOrderList.Tables.Count > 0)
            {
                if (dsOrderList != null && dsOrderList.Tables.Count > 0 && dsOrderList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsOrderList.Tables[0].Rows)
                    {
                        dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
                        orders_taxtotal = orders_taxtotal + Convert.ToDouble(dtrow["orders_tax"]);

                        dtrow["orders_GroceriesTax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_GroceriesTax"]), 2));
                        orders_GroceriesTaxtotal = orders_GroceriesTaxtotal + Convert.ToDouble(dtrow["orders_GroceriesTax"]);

                        dtrow["totfood"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["totfood"]), 2));
                        totfoodtotal = totfoodtotal + Convert.ToDouble(dtrow["totfood"]);

                        dtrow["totnonfood"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["totnonfood"]), 2));
                        totnonfoodtotal = totnonfoodtotal + Convert.ToDouble(dtrow["totnonfood"]);

                        //dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));
                        //totaltotalfinal = totaltotalfinal + Convert.ToDouble(dtrow["orders_totalfinal"]);

                        dtrow["total_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["total_tax"]), 2));
                        totaltotalfinal = totaltotalfinal + Convert.ToDouble(dtrow["total_tax"]);

                    }

                    DataTable dtSorting = dsOrderList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridSearchOrders.DataSource = dvSorting;
                    gridSearchOrders.DataBind();

                }
            }
            ViewState["OrdersSortExpression"] = sortExpression;
            ViewState["OrdersDirection"] = direction;
            dbListInfo.dispose();
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            string strStartDate = Request.QueryString["startDate"];
            string strToDate = Request.QueryString["endDate"];
            int locId = Convert.ToInt32(Request.QueryString["locId"]);
            Response.Redirect("admin_taxreport.aspx?check=1&startDate=" + strStartDate + "&endDate=" + strToDate + "&locId=" + locId, false);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            string strStartDate = Request.QueryString["startDate"];
            string strToDate = Request.QueryString["endDate"];
            int locId = Convert.ToInt32(Request.QueryString["locId"]);
            Response.Redirect("admin_taxreport.aspx?check=1&startDate=" + strStartDate + "&endDate=" + strToDate + "&locId=" + locId, false);

        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            DataSet dsOrderList = new DataSet();
            string strStartDate = Request.QueryString["startDate"];
            string strToDate = Request.QueryString["endDate"];
            int locId = Convert.ToInt32(Request.QueryString["locId"]);
            //double grocerytotal = 0;
            //double tiptotal = 0;
            //double taxtotal = 0;
            //double deliverytotal = 0;
            double totaltotalfinal = 0;
           // int orderid = 0;
             double orders_taxtotal = 0;
            double orders_GroceriesTaxtotal = 0;
            double totfoodtotal = 0;
            double totnonfoodtotal = 0;

            //dsOrderList = dbListInfo.GetOrderReportList(strStartDate, strToDate, locId);
            //if (dsOrderList.Tables.Count > 0)
            //{
            //    if (dsOrderList != null && dsOrderList.Tables.Count > 0 && dsOrderList.Tables[0].Rows.Count > 0)
            //    {
            //        foreach (DataRow dtrow in dsOrderList.Tables[0].Rows)
            //        {

                       

            //            dtrow["orders_grocerytotal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_grocerytotal"]), 2));
            //            grocerytotal = grocerytotal + Convert.ToDouble(dtrow["orders_grocerytotal"]);

            //            dtrow["orders_tip"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tip"]), 2));
            //            tiptotal = tiptotal + Convert.ToDouble(dtrow["orders_tip"]);

            //            dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
            //            taxtotal = taxtotal + Convert.ToDouble(dtrow["orders_tax"]);

            //            dtrow["orders_deliveryfee"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_deliveryfee"]), 2));
            //            deliverytotal = deliverytotal + Convert.ToDouble(dtrow["orders_deliveryfee"]);

            //            dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));
            //            totaltotalfinal = totaltotalfinal + Convert.ToDouble(dtrow["orders_totalfinal"]);
            //        }

           
            //double totaltotalfinal = 0;

            dsOrderList = dbListInfo.GetTaxReportList(strStartDate, strToDate, locId);
            if (dsOrderList.Tables.Count > 0)
            {
                if (dsOrderList != null && dsOrderList.Tables.Count > 0 && dsOrderList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsOrderList.Tables[0].Rows)
                    {
                        dtrow["orders_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_tax"]), 2));
                        orders_taxtotal = orders_taxtotal + Convert.ToDouble(dtrow["orders_tax"]);

                        dtrow["orders_GroceriesTax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_GroceriesTax"]), 2));
                        orders_GroceriesTaxtotal = orders_GroceriesTaxtotal + Convert.ToDouble(dtrow["orders_GroceriesTax"]);

                        dtrow["totfood"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["totfood"]), 2));
                        totfoodtotal = totfoodtotal + Convert.ToDouble(dtrow["totfood"]);

                        dtrow["totnonfood"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["totnonfood"]), 2));
                        totnonfoodtotal = totnonfoodtotal + Convert.ToDouble(dtrow["totnonfood"]);

                        //dtrow["orders_totalfinal"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["orders_totalfinal"]), 2));
                        //totaltotalfinal = totaltotalfinal + Convert.ToDouble(dtrow["orders_totalfinal"]);

                        dtrow["total_tax"] = Convert.ToString(Math.Round(Convert.ToDouble(dtrow["total_tax"]), 2));
                        totaltotalfinal = totaltotalfinal + Convert.ToDouble(dtrow["total_tax"]);

                    }
                    lblTotorders_tax.Text = Convert.ToString("$" + orders_taxtotal);
                    lblTotTip.Text = Convert.ToString("$" + orders_GroceriesTaxtotal);
                    lblTotTax.Text = Convert.ToString("$" + totfoodtotal);
                    lblTotDelivery.Text = Convert.ToString("$" + totnonfoodtotal);
                    lblTotal.Text = Convert.ToString("$" + totaltotalfinal);

                    //lblTotGrocery.Text = Convert.ToString("$" + grocerytotal);
                    //lblTotTip.Text = Convert.ToString("$" + tiptotal);
                    //lblTotTax.Text = Convert.ToString("$" + taxtotal);
                    //lblTotDelivery.Text = Convert.ToString("$" + deliverytotal);
                    //lblTotal.Text = Convert.ToString("$" + totaltotalfinal);
                    //lblTotGrocery.Text = Convert.ToString("$" + Convert.ToDecimal(grocerytotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                    //lblTotTip.Text = Convert.ToString("$" + Convert.ToDecimal(tiptotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                    //lblTotTax.Text = Convert.ToString("$" + Convert.ToDecimal(taxtotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                    //lblTotDelivery.Text = Convert.ToString("$" + Convert.ToDecimal(deliverytotal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                   // lblTotal.Text = Convert.ToString("$" + Convert.ToDecimal(totaltotalfinal).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));



                    gridSearchOrders.DataSource = dsOrderList;
                    Response.Clear();
                    Response.Charset = "";
                    string strDate = string.Empty;
                    strDate = Convert.ToString(DateTime.Now.Month) + "/" + Convert.ToString(DateTime.Now.Day) + "/" + Convert.ToString(DateTime.Now.Year);

                    string strFileName = "TaxReport(" + strStartDate + "upto" + strToDate + ")On_" + strDate + ".xls";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment;filename=" + strFileName);
                    //string tempStream = "<table border='1' cellpadding='0' cellspacing='0' class='MsoTableGrid' style='border-collapse:collapse;border:none;mso-border-alt:solid black .5pt; mso-border-themecolor:text1;mso-yfti-tbllook:1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt'> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                    <b style='mso-bidi-font-weight:normal'>User Name</b></td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='190px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Email<o:p></o:p></b></p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='140px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Address <o:p></o:p></b>                </p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Phone<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>City<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>State<o:p></o:p></b></p> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='50px'> <b style='mso-bidi-font-weight: normal'>Zip</b> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='90px'> <b style='mso-bidi-font-weight: normal'>Registered Date</b> </td></tr>";

                    string tempStream = "<table border='1' cellpadding='0' cellspacing='0' class='MsoTableGrid' style='border-collapse:collapse;border:none;mso-border-alt:solid black .5pt; mso-border-themecolor:text1;mso-yfti-tbllook:1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt'>";

                    tempStream = tempStream + "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'><td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top'  colspan='8' align='center'><b style='mso-bidi-font-weight:normal'>Order Report(" + strStartDate + " up to " + strToDate + ")</b></td></tr>";

                    tempStream = tempStream + "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px' >                    <b style='mso-bidi-font-weight:normal'>Date</b></td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='190px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Customer<o:p></o:p></b></p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='140px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Location <o:p></o:p></b>                </p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Groceries($)<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Tips($)<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='100px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Tax($)<o:p></o:p></b></p>            </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='123px'> <b style='mso-bidi-font-weight: normal'>Delivery($)</b> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='123px'> <b style='mso-bidi-font-weight: normal'>Total($)</b> </td></tr>";



                    Response.Write(tempStream);


                    if (dsOrderList.Tables.Count > 0)
                    {
                        string enxportstr = string.Empty;
                        foreach (DataRow drr in dsOrderList.Tables[0].Rows)
                        {

                            enxportstr = "<tr><td valign='top' align='left'>" + Convert.ToString(drr["orders_id"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<tr><td valign='top' align='left'>" + Convert.ToString(drr["ordDate"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["tax_food"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["tax_nonfood"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["orders_tax"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["orders_GroceriesTax"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["total_tax"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["totfood"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["totnonfood"]) + "</td></tr>";
                            Response.Write(enxportstr);




                        }
                        enxportstr = "<tr><td colspan='3' align='right' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt'><b>Total</b></td><td valign='top' align='left' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt'><b>" + lblTotorders_tax.Text + "</b></td>";
                        Response.Write(enxportstr);
                        enxportstr = "<td valign='top' align='left' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt'><b>" + lblTotTip.Text + "</b></td>";
                        Response.Write(enxportstr);
                        enxportstr = "<td valign='top' align='left' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt'><b>" + lblTotTax.Text + "</b></td>";
                        Response.Write(enxportstr);
                        enxportstr = "<td valign='top' align='left' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt'><b>" + lblTotDelivery.Text + "</b></td>";
                        Response.Write(enxportstr);
                        enxportstr = "<td valign='top' align='left' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt'><b>" + lblTotal.Text + "</b></td>";
                        Response.Write(enxportstr);
                    }



                    Response.Write("</table>");

                    Response.End();
                    Response.Close();
                    lblMsg.Text = "File export";
                }
            }
        }
    }
}

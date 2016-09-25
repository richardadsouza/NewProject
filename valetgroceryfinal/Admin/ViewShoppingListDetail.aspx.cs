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
    public partial class ViewShoppingListDetail : System.Web.UI.Page
    {
        DbProvider dbShoppingListDetails = new DbProvider();
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
                    getTotal();

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
            DataSet dsAdminCustomers = dbShoppingListDetails.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbShoppingListDetails.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbShoppingListDetails.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
                if (name == "Shopping Lists")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbShoppingListDetails.dispose();
        }

        //Function for get short company name for page title
        public void getCompanyName()
        {

            DbProvider dbGetCompanyName = new DbProvider();
            DataSet dsGetCompanyName = new DataSet();
            string strDate = Request.QueryString["deliveryId"];
            dsGetCompanyName = dbGetCompanyName.getShortCompanyName();

            if (dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.shoppingListPageTitle;
                        lblLocation.Text = Convert.ToString(dtrow["LocationName"]);
                    }
                }
            }
            lblDate.Text = strDate;
            dbGetCompanyName.dispose();
        }


        public void BindGrid()
        {
           
            string strDate = SplitDateNew(Request.QueryString["deliveryId"]);        
            DataSet dtShoppingList = new DataSet();
            dtShoppingList = dbShoppingListDetails.getShoppingCartListDateWise(strDate);
            if (dtShoppingList.Tables.Count > 0)
            {
                if (dtShoppingList != null && dtShoppingList.Tables.Count > 0 && dtShoppingList.Tables[0].Rows.Count > 0)
                {
                    //check when no posts or photos found

                    gridShoppingList.DataSource = dtShoppingList;
                    gridShoppingList.DataBind();


                }
                else
                {
                    lblMsg.Text = "";
                    gridShoppingList.Visible = false;
                    lblAmount.Visible = false;
                    lblTotalText.Visible = false;                   
                    imgBtnPrint.Visible = false;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "";
                gridShoppingList.Visible = false;
                lblAmount.Visible = false;
                lblTotalText.Visible = false;                
                imgBtnPrint.Visible = false;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            dbShoppingListDetails.dispose();

        }

        //Funcation for getting Info Email from database(Constant).
        public void getTotal()
        {

            string strDate = SplitDateNew(Request.QueryString["deliveryId"]);  
            DataSet dsGetTotal = new DataSet();
            dbShoppingListDetails.dispose();
            dsGetTotal = dbShoppingListDetails.getShoppingCartListDateWise(strDate);

            string amount = "";
            string quentity = "";


            if (dsGetTotal.Tables[0].Rows.Count > 0)
            {
                if (dsGetTotal != null && dsGetTotal.Tables.Count > 0 && dsGetTotal.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetTotal.Tables[0].Rows)
                    {
                        quentity += Convert.ToString(dtrow["orderproduct_quantity"]) + ",";
                        amount += Convert.ToString(dtrow["orderproduct_price"]) + ",";
                    }
                }
            }

            string[] strAllTotalQuentity = quentity.Split(',');
            string[] strTotalAmountByProduct = amount.Split(',');
            double[] strTotalAmount = new double[strAllTotalQuentity.Length];
            double totalAmountFprTheDay = 0;



            for (int totalAmount = 0; totalAmount < strAllTotalQuentity.Length - 1; totalAmount++)
            {
                totalAmountFprTheDay += Convert.ToDouble(strAllTotalQuentity[totalAmount]) * Convert.ToDouble(strTotalAmountByProduct[totalAmount]);
            }
            string strAmt = "$" + Convert.ToString(totalAmountFprTheDay);
            lblAmount.Text = Convert.ToString(strAmt);

        }
        protected void gridShoppingList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridShoppingList.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gridShoppingList_Sorting(object sender, GridViewSortEventArgs e)
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

            string strDate = SplitDateNew(Request.QueryString["deliveryId"]);        
            DataSet dtShoppingList = new DataSet();
            dtShoppingList = dbShoppingListDetails.getShoppingCartListDateWise(strDate);
            if (dtShoppingList.Tables.Count > 0)
            {
                if (dtShoppingList != null && dtShoppingList.Tables.Count > 0 && dtShoppingList.Tables[0].Rows.Count > 0)
                {
                    DataTable ds1 = dtShoppingList.Tables[0];
                    DataView dv = new DataView(ds1);
                    dv.Sort = sortExpression + direction;
                    gridShoppingList.DataSource = dv;
                    gridShoppingList.DataBind();
                }
            }
            dbShoppingListDetails.dispose();
        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_shoplist.aspx", false);

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("admin_shoplist.aspx", false);

        }

        public string SplitDateNew(string StrDate)
        {
            string[] dateInfo = new string[2];
            char[] splitter = { '/' };
            dateInfo = StrDate.Split(splitter);
            string day = dateInfo[1];
            string month = dateInfo[0];
            string year = dateInfo[2];
           // string strReturn = day + '/' + month + '/' + year;
            string strReturn = year + '-' + month + '-' + day;
            return strReturn;
        }

       

      

        protected void imgBtnPrint_Click(object sender, ImageClickEventArgs e)
        {
            string strDate = SplitDateNew(Request.QueryString["deliveryId"]);
            //DateTime dtDate = Convert.ToDateTime(strDate);
               Response.Redirect(("ShoppingListPrint.aspx?deliveryId=" + strDate), false);
            //Response.Write("<script>window.open('ShoppingListPrint.aspx?deliveryId=" + strDate +"');</script>");


        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            string strDate = SplitDateNew(Request.QueryString["deliveryId"]);
            DataSet dtShoppingList = new DataSet();
            dtShoppingList = dbShoppingListDetails.getShoppingCartListDateWise(strDate);
            if (dtShoppingList.Tables.Count > 0)
            {
                if (dtShoppingList != null && dtShoppingList.Tables.Count > 0 && dtShoppingList.Tables[0].Rows.Count > 0)
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
                                Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.shoppingListPageTitle;
                                lblLocation.Text = Convert.ToString(dtrow["LocationName"]);
                            }
                        }
                    }
                    lblDate.Text = strDate;
                    dbGetCompanyName.dispose();
                    Response.Clear();
                    Response.Charset = "";

                    string strFileName = "ShoppingListDetailReportfor(" + strDate + ").xls";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "attachment;filename=" + strFileName);
                    //string tempStream = "<table border='1' cellpadding='0' cellspacing='0' class='MsoTableGrid' style='border-collapse:collapse;border:none;mso-border-alt:solid black .5pt; mso-border-themecolor:text1;mso-yfti-tbllook:1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt'> <tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                    <b style='mso-bidi-font-weight:normal'>User Name</b></td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='190px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Email<o:p></o:p></b></p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='140px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Address <o:p></o:p></b>                </p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Phone<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>City<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>State<o:p></o:p></b></p> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='50px'> <b style='mso-bidi-font-weight: normal'>Zip</b> </td><td style='width: 92.4pt; border: solid black 1.0pt; mso-border-themecolor: text1; mso-border-alt: solid black .5pt; mso-border-themecolor: text1; padding: 0cm 5.4pt 0cm 5.4pt'  valign='top' width='90px'> <b style='mso-bidi-font-weight: normal'>Registered Date</b> </td></tr>";

                    string tempStream = "<table border='1' cellpadding='0' cellspacing='0' class='MsoTableGrid' style='border-collapse:collapse;border:none;mso-border-alt:solid black .5pt; mso-border-themecolor:text1;mso-yfti-tbllook:1184;mso-padding-alt:0cm 5.4pt 0cm 5.4pt'>";

                    tempStream = tempStream + "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'><td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top'  colspan='5' align='center'><b style='mso-bidi-font-weight:normal'>Shopping List for (" + lblDate.Text + " ) at " + lblLocation.Text + "</b></td></tr>";

                    tempStream = tempStream + "<tr style='mso-yfti-irow:0;mso-yfti-firstrow:yes'>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='123px' >                    <b style='mso-bidi-font-weight:normal'>Qty</b></td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='190px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Product<o:p></o:p></b></p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='140px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Category<o:p></o:p></b>                </p>            </td>            <td style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Size<o:p></o:p></b></p>            </td>            <td style='width:92.45pt;border:solid black 1.0pt;  mso-border-themecolor:text1;border-left:none;mso-border-left-alt:solid black .5pt;  mso-border-left-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' valign='top' width='110px'>                <p class='MsoNormal' style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:  normal'>                    <b style='mso-bidi-font-weight:normal'>Price($)<o:p></o:p></b></p>            </td>            </tr>";



                    Response.Write(tempStream);


                    if (dtShoppingList.Tables.Count > 0)
                    {
                        string enxportstr = string.Empty;
                        foreach (DataRow drr in dtShoppingList.Tables[0].Rows)
                        {
                            //enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["shelf_position"]) + "</td>";
                            //Response.Write(enxportstr);
                            enxportstr = "<tr><td valign='top' align='left'>" + Convert.ToString(drr["orderproduct_quantity"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["product_title"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["shelf_name"]) + "</td>";
                            Response.Write(enxportstr);
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["product_size"]) + "</td>";
                            Response.Write(enxportstr);
                            //enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["orderproduct_price"]) + "</td></tr>";
                            enxportstr = "<td valign='top' align='left'>" + Convert.ToString(drr["productlink_buyprice"]) + "</td></tr>";
                            Response.Write(enxportstr);






                        }


                        DataSet dsGetTotal = new DataSet();
                        dbShoppingListDetails.dispose();
                        dsGetTotal = dbShoppingListDetails.getShoppingCartListDateWise(strDate);

                        string amount = "";
                        string quentity = "";


                        if (dsGetTotal.Tables[0].Rows.Count > 0)
                        {
                            if (dsGetTotal != null && dsGetTotal.Tables.Count > 0 && dsGetTotal.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dtrow in dsGetTotal.Tables[0].Rows)
                                {
                                    quentity += Convert.ToString(dtrow["orderproduct_quantity"]) + ",";
                                    amount += Convert.ToString(dtrow["orderproduct_price"]) + ",";

                                }
                            }
                        }

                        string[] strAllTotalQuentity = quentity.Split(',');
                        string[] strTotalAmountByProduct = amount.Split(',');
                        double[] strTotalAmount = new double[strAllTotalQuentity.Length];
                        double totalAmountFprTheDay = 0;



                        for (int totalAmount = 0; totalAmount < strAllTotalQuentity.Length - 1; totalAmount++)
                        {
                            totalAmountFprTheDay += Convert.ToDouble(strAllTotalQuentity[totalAmount]) * Convert.ToDouble(strTotalAmountByProduct[totalAmount]);
                        }
                        //string strAmt = "$" + Convert.ToString(totalAmountFprTheDay);
                        string strAmt = "$" + Convert.ToDecimal(totalAmountFprTheDay).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        lblAmount.Text = Convert.ToString(strAmt);



                        enxportstr = "<tr><td colspan='4' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt' align='right'><b>Total</b></td><td valign='top' align='left' style='width:92.4pt;border:solid black 1.0pt;  mso-border-themecolor:text1;mso-border-alt:solid black .5pt;mso-border-themecolor:  text1;padding:0cm 5.4pt 0cm 5.4pt'><b>" + lblAmount.Text + "</b></td>";
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

using System;
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

namespace groceryguys
{
    public partial class picktime : System.Web.UI.Page
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
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    if (!IsPostBack)
                    {
                        lblMsg.Visible = false;
                        lblMsg.Text = "";
                        BindDeliveryInfo();
                    }
                }
                dbInfo.dispose();
            }

            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }


        }
        public void BindDeliveryInfo()
        {
            DataTable dtDelivery = new DataTable();
            DataRow rowDelivery;
            dtDelivery.Columns.Add("deliverydate_id");
            dtDelivery.Columns.Add("deliverydate_date");


            DataSet dsDeleryDateTime = new DataSet();
            DataSet dsUserDeliveryList = new DataSet();
            DataSet dsUserInfo = new DataSet();
            string strZone = string.Empty;
            //strZone = Convert.ToString(Request.Cookies["UserZoneInfo"].Value);
            // dsDeleryDateTime = dbInfo.GetDelveryTimeInformation();
            dsDeleryDateTime = dbInfo.GetUserNewDelveryTimeInformation();
            dsUserInfo = dbInfo.GetUserDetailsInfoGetZip(Convert.ToInt32(Request.Cookies["userId"].Value));
            if (dsUserInfo.Tables.Count > 0)
            {
                if (dsUserInfo != null && dsUserInfo.Tables.Count > 0 && dsUserInfo.Tables[0].Rows.Count > 0)
                {
                    int intZipId = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["Zip"]);
                    dsUserDeliveryList = dbInfo.GetUserPickTimeDelDateInfo(Convert.ToInt32(AppConstants.locationId), intZipId);
                    if (dsUserDeliveryList.Tables.Count > 0)
                    {
                        if (dsUserDeliveryList != null && dsUserDeliveryList.Tables.Count > 0 && dsUserDeliveryList.Tables[0].Rows.Count > 0)
                        {

                            if (dsDeleryDateTime.Tables.Count > 0)
                            {
                                if (dsDeleryDateTime != null && dsDeleryDateTime.Tables.Count > 0 && dsDeleryDateTime.Tables[0].Rows.Count > 0)
                                {

                                    foreach (DataRow dtrow in dsDeleryDateTime.Tables[0].Rows)
                                    {
                                        foreach (DataRow dtrow1 in dsUserDeliveryList.Tables[0].Rows)
                                        {
                                            if (Convert.ToString(dtrow1["deliverydate_id"]) == Convert.ToString(dtrow["deliverydate_id"]))
                                            {

                                                rowDelivery = dtDelivery.NewRow();
                                                rowDelivery["deliverydate_id"] = Convert.ToString(dtrow1["deliverydate_id"]);
                                                rowDelivery["deliverydate_date"] = Convert.ToString(dtrow1["deliverydate_date"]);
                                                dtDelivery.Rows.Add(rowDelivery);
                                            }
                                        }


                                    }
                                    if (dtDelivery.Rows.Count > 0)
                                    {
                                        DataSet dsDelivery = new DataSet();
                                        dsDelivery.Tables.Add(dtDelivery);
                                        BindDelivery(dsDelivery);


                                    }
                                    else
                                    {
                                        lblMsg.Text = "";
                                        lblMsg.Visible = true;
                                        lblMsg.Text = AppConstants.strNoDelDateAva;
                                        pnlDeldate.Visible = false;
                                        btnChoose.Visible = false;

                                    }
                                }
                                else
                                {
                                    lblMsg.Text = "";
                                    lblMsg.Visible = true;
                                    lblMsg.Text = AppConstants.strNoDelDateAva;
                                    pnlDeldate.Visible = false;
                                    btnChoose.Visible = false;
                                }
                            }
                            else
                            {
                                lblMsg.Text = "";
                                lblMsg.Visible = true;
                                lblMsg.Text = AppConstants.strNoDelDateAva;
                                pnlDeldate.Visible = false;
                                btnChoose.Visible = false;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Visible = true;
                            lblMsg.Text = AppConstants.strNoDelDateAva;
                            pnlDeldate.Visible = false;
                            btnChoose.Visible = false;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "";
                        lblMsg.Visible = true;
                        lblMsg.Text = AppConstants.strNoDelDateAva;
                        pnlDeldate.Visible = false;
                        btnChoose.Visible = false;
                    }
                }
            }
            dbInfo.dispose();
        }

        public void BindDelivery(DataSet dsDeleryDateTime)
        {
            DataTable dtDelivery = new DataTable();
            DataRow rowDel;
            dtDelivery.Columns.Add("DelDate");
            dtDelivery.Columns.Add("DelId");
            dtDelivery.Columns.Add("DDate");
            int delevryId = 0;
            DateTime delveryDate;
            string strDay = string.Empty;
            string strMonth = string.Empty;
            string strYear = string.Empty;
            string strDayVal = string.Empty;
            string strDate = string.Empty;
            if (dsDeleryDateTime.Tables.Count > 0)
            {
                if (dsDeleryDateTime != null && dsDeleryDateTime.Tables.Count > 0 && dsDeleryDateTime.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsDeleryDateTime.Tables[0].Rows)
                    {
                        delevryId = Convert.ToInt32(dtrow["deliverydate_id"]);
                        delveryDate = Convert.ToDateTime(dtrow["deliverydate_date"]);
                        strDayVal = delveryDate.Day.ToString();
                        strDay = delveryDate.DayOfWeek.ToString();
                        strMonth = MonthName(delveryDate.Month.ToString());
                        strYear = delveryDate.Year.ToString();
                        strDate = strDay + ", " + strMonth + " " + strDayVal + ", " + strYear;
                        rowDel = dtDelivery.NewRow();
                        rowDel["DelId"] = delevryId;
                        rowDel["DelDate"] = strDate;
                        rowDel["DDate"] = delveryDate;
                        dtDelivery.Rows.Add(rowDel);


                    }

                    dtlDeliveryGrid.DataSource = dtDelivery;
                    dtlDeliveryGrid.DataBind();
                    foreach (DataListItem dtList in dtlDeliveryGrid.Items)
                    {

                        RadioButtonList rdList;
                        rdList = (RadioButtonList)dtList.FindControl("rdChkTime");
                        Label lblDelId;

                        //int intZoneID = Convert.ToInt32(Request.Cookies["UserZoneInfo"].Value);
                        lblDelId = (Label)dtList.FindControl("lblDelId");
                        DataSet dsDelivery = new DataSet();
                        dsDelivery = dbInfo.GetDelveryTimeInfo(Convert.ToInt32(lblDelId.Text));
                        if (dsDelivery.Tables.Count > 0)
                        {
                            if (dsDelivery != null && dsDelivery.Tables.Count > 0 && dsDelivery.Tables[0].Rows.Count > 0)
                            {
                                rdList.DataSource = dsDelivery;
                                rdList.DataTextField = "deliverytime_time";
                                rdList.DataValueField = "deliverytime_id";
                                rdList.DataBind();
                            }
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.strNoDelDateAva;
                    pnlDeldate.Visible = false;
                    btnChoose.Visible = false;
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.strNoDelDateAva;
                pnlDeldate.Visible = false;
                btnChoose.Visible = false;
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgPickTime;

                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnChoose_Click(object sender, EventArgs e)
        {

            int intChk = 0;
            foreach (DataListItem dtList in dtlDeliveryGrid.Items)
            {
                RadioButtonList rdList;
                rdList = (RadioButtonList)dtList.FindControl("rdChkTime");
                for (int i = 0; i < rdList.Items.Count; i++)
                {
                    if (rdList.Items[i].Selected == true)
                    {
                        ViewState["DeliveryTime"] = rdList.Items[i].Value;
                        intChk = 1;

                    }

                }

            }
            if (intChk == 1)
            {
                lblMsg.Visible = false;
                lblMsg.Text = "";
                string strUserPickTimeInfo = string.Empty;
                strUserPickTimeInfo = Convert.ToString(ViewState["DelDateID"]) + "!*@!" + Convert.ToString(ViewState["DelDate"]) + "!*@!" + Convert.ToString(ViewState["DeliveryTime"]);
                HttpCookie strUserPickTime = new HttpCookie("UserShopAddInfo", strUserPickTimeInfo);
                Response.Cookies.Add(strUserPickTime);
                Response.Redirect("tipping.aspx", false);
                

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "";
                lblMsg.Text = AppConstants.selectDeliverytime;

            }
        }

        public string MonthName(string strMonth)
        {
            string strReturn = string.Empty;
            if (strMonth == "1")
            {
                strReturn = "January";

            }
            if (strMonth == "2")
            {
                strReturn = "February";

            }
            if (strMonth == "3")
            {
                strReturn = "March";

            }
            if (strMonth == "4")
            {
                strReturn = "April";

            }
            if (strMonth == "5")
            {
                strReturn = "May";

            }
            if (strMonth == "6")
            {
                strReturn = "June";

            }
            if (strMonth == "7")
            {
                strReturn = "July";

            }
            if (strMonth == "8")
            {
                strReturn = "August";

            }
            if (strMonth == "9")
            {
                strReturn = "September";

            }
            if (strMonth == "10")
            {
                strReturn = "October";


            }
            if (strMonth == "11")
            {
                strReturn = "November";


            }
            if (strMonth == "12")
            {
                strReturn = "December";


            }
            return strReturn;

        }

        protected void rdChkTime_SelectedIndexChanged(object sender, EventArgs e)
        {

            int intCheck = 0;
            string strNew = string.Empty;
            string strDeliveryCntId = string.Empty;
            foreach (DataListItem dtList in dtlDeliveryGrid.Items)
            {
                RadioButtonList rdList;
                rdList = (RadioButtonList)dtList.FindControl("rdChkTime");
                Label lblDelId;
                lblDelId = (Label)dtList.FindControl("lblDelId");
                Label lblDelDate;
                lblDelDate = (Label)dtList.FindControl("lblDelDate");

                for (int i = 0; i < rdList.Items.Count; i++)
                {
                    if (rdList.Items[i].Selected == true)
                    {


                        if (Convert.ToString(ViewState["SelectedValue"]) == "")
                        {
                            strNew = lblDelId.Text;
                            intCheck = 1;
                            ViewState["DelDate"] = lblDelDate.Text;
                            ViewState["DelDateID"] = strNew;
                        }
                        else
                        {


                            if (Convert.ToString(ViewState["SelectedValue"]) != lblDelId.Text)
                            {
                                ViewState["DelDate"] = lblDelDate.Text;
                                strNew = lblDelId.Text;
                                intCheck = 1;
                                ViewState["DelDateID"] = strNew;
                            }
                        }
                    }
                }
            }
            strDeliveryCntId = strNew;
            if (intCheck == 1)
            {
                foreach (DataListItem dtList in dtlDeliveryGrid.Items)
                {
                    RadioButtonList rdList;
                    rdList = (RadioButtonList)dtList.FindControl("rdChkTime");
                    Label lblDelId;
                    lblDelId = (Label)dtList.FindControl("lblDelId");

                    if (lblDelId.Text != strDeliveryCntId)
                    {
                        for (int i = 0; i < rdList.Items.Count; i++)
                        {
                            rdList.Items[i].Selected = false;
                        }
                    }
                }
            }
            ViewState["SelectedValue"] = strNew;
            ViewState["DelDateID"] = strNew;
            strNew = "";
            intCheck = 0;

        }
    }
}
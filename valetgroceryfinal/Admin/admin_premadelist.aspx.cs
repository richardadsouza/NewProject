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
    public partial class admin_premadelist : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        DropdownProvider dropLocation = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
          //  btnAdd.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                dropLocation.bindLocationDropdown(drpLocation);//Bind location  into dropdown
                dropLocation.bindShelfDropdown(drpShelf);//Bind shelf  into dropdown
               // dropLocation.bindProductDropdown(drpProduct);//bind all product intodropdown
                string Check = string.Empty;
                Check = Request.QueryString["check"];
                if (Check != "" && Check != null)
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
            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Pre-Made List")
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

                Response.Redirect("premadelist.aspx", false);

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
                int strproductid = 0;
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
                if (drpProduct.SelectedValue != "Select")
                {
                    if (drpProduct.SelectedValue == "")
                    {
                        strproductid = 0;
                    }
                    else
                    {
                        strproductid = Convert.ToInt32(drpProduct.SelectedValue);
                    }
                }
                else
                {
                    strproductid = 0;
                }

                strKey = txtKeyWord.Text;
                Response.Redirect("premadelist.aspx?loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey + "&strproduct=" + strproductid, false);



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }

        protected void drpShelf_SelectedIndexChanged(object sender, EventArgs e)
        {
           // int strproduct = 0;
            if (drpShelf.SelectedValue != "Select")
            {
                dropLocation.bindPrductShelfDropdownNew(drpProduct, Convert.ToInt32(drpShelf.SelectedValue));//bind all product intodropdown
            }
        }
    }
}


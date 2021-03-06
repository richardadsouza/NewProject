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
using System.Drawing;

namespace groceryguys.Admin
{
    public partial class ShoppingCartVariables : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnUpdate.Attributes.Add("onclick", "clcontent();");
                changeLinks();
                getCompanyName();
                if (!Page.IsPostBack)
                {
                    getShoppingCartVariables();
                    

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        public void changeLinks()
        {
            DbProvider dbSelectZip = new DbProvider();
            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbSelectZip.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbSelectZip.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbSelectZip.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }

            dbSelectZip.dispose();


        }

        //Funcation for getting shopping cart variables(Constant).
        public void getShoppingCartVariables()
        {
            int constantId = 1;
            DbProvider dbGetShoppingCartVariables = new DbProvider();
            DataSet dsGetShoppingCartVariables = new DataSet();
            dbGetShoppingCartVariables.dispose();
            dsGetShoppingCartVariables = dbGetShoppingCartVariables.GetShoppingCartConstant(constantId);

            if (dsGetShoppingCartVariables.Tables.Count > 0)
            {
                if (dsGetShoppingCartVariables.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetShoppingCartVariables.Tables[0].Rows)
                    {
                        //txtDeliveryFee.Text = Convert.ToString(dtrow["DeliveryFee"]);
                        txtDeliveryFee.Text = Convert.ToDecimal(dtrow["DeliveryFee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        txtMemberDeliveryFee.Text = Convert.ToDecimal(dtrow["MemberDeliveryFee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        txtTaxRate.Text = Convert.ToString(dtrow["TaxRate_Food"]);
                        txtTaxRate1.Text = Convert.ToString(dtrow["TaxRate_NonFood"]);                        
                        //txtMinimumDeposit.Text = Convert.ToString(dtrow["MinimumDeposit"]);
                        txtMinimumDeposit.Text = Convert.ToDecimal(dtrow["MinimumDeposit"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        txtNoOfTimeSlot.Text = Convert.ToString(dtrow["Numberoftimeslot"]);
                        //txtDeliveryFeeCutOff.Text = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        txtDeliveryFeeCutOff.Text = Convert.ToDecimal(dtrow["DeliveryFeeCutOff"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        txtCustomerServiceemail.Text = Convert.ToString(dtrow["CustomerServiceEmail"]);
                        txtContactEmail.Text = Convert.ToString(dtrow["ContactEmail"]);
                        txtInfoEmail.Text = Convert.ToString(dtrow["InfoEmail"]);
                        txtLocationName.Text = Convert.ToString(dtrow["LocationName"]);
                        txtStateShortName.Text = Convert.ToString(dtrow["StateShortName"]);
                        txtStateLongName.Text = Convert.ToString(dtrow["StateLongName"]);
                        txtCompanyName.Text = Convert.ToString(dtrow["CompanyShortName"]);
                        txtCompanyLongName.Text=Convert.ToString(dtrow["CompanyLongName"]);
                        txtShortURL.Text = Convert.ToString(dtrow["ShortURL"]);
                        txtLongURL.Text = Convert.ToString(dtrow["LongURL"]);
                        txtFirstOrderGift.Text = Convert.ToDecimal(dtrow["FirstOrderGift"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.shoppingCartConstant;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }
        

        // Code for Shopping cart variables update
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DataValidator dataValidator = new DataValidator();
            bool returnCustomerServiceEmail;
            bool returnContactEmail;
            bool returnInfoEmail;
            int intUpdateConstants = 0;
            int constantId = 1;
            int intUpdateLocation = 0;
            int location_id=1;
            DbProvider dbUpdateConstants = new DbProvider();

            if (Page.IsValid)
            {
                //Check email validation
                returnCustomerServiceEmail = DataValidator.IsValidEmail(Convert.ToString(txtCustomerServiceemail.Text));
                returnContactEmail = DataValidator.IsValidEmail(Convert.ToString(txtContactEmail.Text));
                returnInfoEmail = DataValidator.IsValidEmail(Convert.ToString(txtInfoEmail.Text));

                if (returnCustomerServiceEmail == false)
                {
                    lblMsg.Text = AppConstants.customerServiceEmail;
                    lblMsg.ForeColor = Color.Red;
                }
                else if (returnContactEmail == false)
                {
                    lblMsg.Text = AppConstants.contactEmail;
                    lblMsg.ForeColor = Color.Red;
                }
                else if (returnInfoEmail == false)
                {
                    lblMsg.Text = AppConstants.infoEmail;
                    lblMsg.ForeColor = Color.Red;
                }
                else
                {

                   // intUpdateConstants = dbUpdateConstants.updateShoppingCartConstant(constantId, Convert.ToDouble(txtDeliveryFee.Text), Convert.ToDouble(txtTaxRate.Text), Convert.ToDouble(txtTaxRate1.Text), Convert.ToDouble(txtMinimumDeposit.Text), Convert.ToInt32(txtNoOfTimeSlot.Text), Convert.ToDouble(txtDeliveryFeeCutOff.Text), Convert.ToString(txtCustomerServiceemail.Text), Convert.ToString(txtContactEmail.Text), Convert.ToString(txtInfoEmail.Text), Convert.ToString(txtLocationName.Text), Convert.ToString(txtStateShortName.Text), Convert.ToString(txtStateLongName.Text), Convert.ToString(txtCompanyName.Text), Convert.ToString(txtCompanyLongName.Text), Convert.ToString(txtShortURL.Text), Convert.ToString(txtLongURL.Text), Convert.ToDouble(txtFirstOrderGift.Text));

                    intUpdateConstants = dbUpdateConstants.updateShoppingCartConstant(constantId, Convert.ToDouble(txtDeliveryFee.Text), Convert.ToDouble(txtMemberDeliveryFee.Text), Convert.ToDouble(txtTaxRate.Text), Convert.ToDouble(txtTaxRate1.Text), Convert.ToDouble(txtMinimumDeposit.Text), Convert.ToInt32(txtNoOfTimeSlot.Text), Convert.ToDouble(txtDeliveryFeeCutOff.Text), Convert.ToString(txtCustomerServiceemail.Text), Convert.ToString(txtContactEmail.Text), Convert.ToString(txtInfoEmail.Text), Convert.ToString(txtLocationName.Text), Convert.ToString(txtStateShortName.Text), Convert.ToString(txtStateLongName.Text), Convert.ToString(txtCompanyName.Text), Convert.ToString(txtCompanyLongName.Text), Convert.ToString(txtShortURL.Text), Convert.ToString(txtLongURL.Text), Convert.ToDouble(txtFirstOrderGift.Text));
                    
                    intUpdateLocation= dbUpdateConstants.updateLocationName(location_id,Convert.ToString(txtLocationName.Text));
                    //updateLocationName
                    if (intUpdateConstants == 1 && intUpdateLocation == 1)
                    {
                        lblMsg.Text = AppConstants.shoppingUpdateSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Black;
                        getShoppingCartVariables();
                        
                    }
                    dbUpdateConstants.dispose();
                }

            }
        }
    }
}
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

namespace groceryguys
{
    public partial class DeliveryInfo : System.Web.UI.Page
    {
       
        DbProvider dbInfo = new DbProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                    //lblCompanyNm.Text = Convert.ToString(ViewState["CompanyName"]);
                    //lblCompanyNm1.Text = Convert.ToString(ViewState["CompanyName"]);
                    //lblDeliveryFee.Text = Convert.ToString(ViewState["DeliveryFee"]);                    
                    lblDeliveryFee.Text = Convert.ToDecimal(ViewState["DeliveryFee"]).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);                    
                    //lblOrderCutoff.Text = Convert.ToString(ViewState["OrderCutoff"]);
                    
                    //lblOrderCutoff1.Text = Convert.ToString(ViewState["OrderCutoff"]);
                    BindZipCode();

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        public void BindSideLink()
        {
            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = true;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgDeliveryInformation;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["OrderCutoff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);

                    }
                }
            }
            dbGetCompanyName.dispose();
        }


        public void BindZipCode()
        {
           
           //double amt=0.00;
            DataSet dsZipcode = new DataSet();
            dsZipcode = dbInfo.GetZipCodeAndOrdAmtInfo();
            if (dsZipcode.Tables.Count > 0)
            {
                if (dsZipcode != null && dsZipcode.Tables.Count > 0 && dsZipcode.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsZipcode.Tables[0].Rows)
                    {
                        //if (dtrow["ZipOrderSize"] != "")
                        //{

                        //    amt = Math.Round(Convert.ToDouble(dtrow["ZipOrderSize"]), 2);                          
                        //}
                        //else
                        //{
                        //    amt =0.00;
                        //}

                        //dtrow["ZipOrderSize"] = Convert.ToString(amt);

                    }
                  
                }
            }

            dbInfo.dispose();  
        }

        protected void btnShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx", false);
        
        }

    }
}

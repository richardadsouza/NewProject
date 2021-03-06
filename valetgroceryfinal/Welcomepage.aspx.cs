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
    public partial class Welcomepage : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DropdownProvider dropZip = new DropdownProvider();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getCompanyName();
                
            }
        }
        
         public void getCompanyName()
        {
            DataSet dsGetHomePageTxt = new DataSet();
            DataSet dsGetCompanyName = new DataSet();
            dsGetCompanyName = dbInfo.getShortCompanyName();
            if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0)
            {
                if (dsGetCompanyName != null && dsGetCompanyName.Tables.Count > 0 && dsGetCompanyName.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsGetCompanyName.Tables[0].Rows)
                    {
                        string strNm = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgIndex;
                       ViewState["LocationName"] = Convert.ToString(dtrow["LocationName"]);

                       string loactionname = Convert.ToString(dtrow["LocationName"]);
                       Page.Header.Title = strNm + loactionname;
                        ViewState["CompanyNm"] = Convert.ToString(dtrow["CompanyShortName"]);
                    }
                }
            }
            dsGetHomePageTxt = dbInfo.GetHomePageTxt();
            if (dsGetHomePageTxt != null && dsGetHomePageTxt.Tables.Count > 0)
            {
                if (dsGetHomePageTxt != null && dsGetHomePageTxt.Tables.Count > 0 && dsGetHomePageTxt.Tables[0].Rows.Count > 0)
                {

                    string result = string.Empty;
                    string homepagetxt = Convert.ToString(dsGetHomePageTxt.Tables[0].Rows[0]["homepage_text"]);

                    lblHomepageText.Text = homepagetxt;
                    //lblHomepageText.Text = Convert.ToString(dsGetHomePageTxt.Tables[0].Rows[0]["homepage_text"]);
                   
                    
                }
            }
            dbInfo.dispose();
        }
        
        
        
        
        
    }
}

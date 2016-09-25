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
using BAL;

namespace groceryguys
{
    public partial class UserLoginMasterPage : System.Web.UI.MasterPage
    {
        BALClass objBAL = new BALClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtSearch.Attributes.Add("onKeyPress", "doClick('" + btnGo.ClientID + "',event)");

            if (Session["UserID"] == null || Convert.ToString(Session["UserID"]) == "")
            {
                pnlLogIn.Visible = false;
                pnlSignUp.Visible = true;
            }
            else
            {
                pnlLogIn.Visible = true;
                pnlSignUp.Visible = false;
            }

            if (Session["ShoppingCart"] != null)
            {
                DataTable dt = objBAL.GetShoppingCart(Convert.ToString(Session["ShoppingCart"]));

                if (dt.Rows.Count > 0)
                {
                    lblCart.Text = Convert.ToString(dt.Rows.Count) + " items";
                }
                else
                    lblCart.Text = "0 items";
            }
            else
            {
                lblCart.Text = "0 items";
            }
        }

        protected void btnGo_Click(object sender, ImageClickEventArgs e)
        {
            string strSearch = string.Empty;
            int intChk = 0;
            strSearch = txtSearch.Value;

            if (strSearch == "#")
            {
                intChk = 1;
            }
            else if (strSearch == "&")
            {
                intChk = 2;
            }

            Response.Redirect("searchresults.aspx?intChk=" + intChk + "&keyword=" + strSearch, false);
        }
    }
}
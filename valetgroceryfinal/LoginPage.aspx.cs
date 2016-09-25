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
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Specialized;
using System.IO;
using BAL;
using Models;

namespace groceryguys
{
    public partial class LoginPage : System.Web.UI.Page
    {
        BALClass objBAL = new BALClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindSideLink();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void BindSideLink()
        {
            Panel pnlCatgeory = (Panel)this.Master.FindControl("pnlCategory");
            pnlCatgeory.Visible = true;
            Panel pnlHow = (Panel)this.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlAccount = (Panel)this.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length > 0 && txtPassword.Text.Trim().Length > 0)
            {
                UserLoginDetails userDetails = objBAL.CheckUser(txtEmail.Text, txtPassword.Text);

                if (userDetails != null)
                {
                    if (!String.IsNullOrWhiteSpace(userDetails.UserID))
                    {
                        lblMsg.Text = "";

                        Session["UserDetails"] = userDetails;
                        Session["UserID"] = userDetails.UserID;

                        Response.Redirect("Product_Order.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Incorrect User Name/Password entered";
                    }
                }
            }
        }
    }
}

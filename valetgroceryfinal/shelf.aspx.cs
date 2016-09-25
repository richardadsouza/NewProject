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
using BAL;

namespace groceryguys
{
    public partial class shelf : System.Web.UI.Page
    {
        BALClass objBAL = new BALClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindSideLink();

            if (!IsPostBack)
            {
                lblErrMsg.Visible = false;

                string aisleTopID = String.Empty;
                aisleTopID = Request.QueryString["AT"].ToString();

                string aisleTopName = String.Empty;
                aisleTopName = objBAL.GetAisleTop(aisleTopID);

                if (aisleTopName != null)
                {
                    lblAisleName.Text = lblAisleName1.Text = aisleTopName;
                }

                DataTable dtAisle = objBAL.GetAisle(aisleTopID);

                if (dtAisle != null && dtAisle.Rows.Count > 0)
                {
                    dtlAisle.DataSource = dtAisle;
                    dtlAisle.DataBind();

                    foreach (DataListItem item in dtlAisle.Items)
                    {
                        Label lblAisleID = (Label)item.FindControl("lblAisleID");

                        DataTable dtShelf = objBAL.GetShelf(lblAisleID.Text, aisleTopID);

                        DataList dtlShelf = (DataList)item.FindControl("dtlShelf");
                        dtlShelf.DataSource = dtShelf;
                        dtlShelf.DataBind();
                    }
                }
                else
                {
                    lblErrMsg.Text = "No aisles found";
                    lblErrMsg.Visible = true;
                }
            }
        }

        private void BindSideLink()
        {
            Panel pnlHow = (Panel)this.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlAccount = (Panel)this.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)this.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;
        }
    }
}

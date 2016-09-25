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
using System.Globalization;
using BAL;

namespace groceryguys
{
    public partial class Shop : System.Web.UI.Page
    {
        BALClass objBAL = new BALClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DateTime> delDateList = objBAL.GetCurrentDelDate();

                if (delDateList.Count > 0)
                {
                    pnlDeliveryInfo.Visible = true;
                    lblDeliveryDate1.Text = delDateList[0].ToString();
                    lblDeliveryDate2.Text = delDateList[1].ToString();
                }
                else
                {
                    pnlDeliveryInfo.Visible = false;
                }

                BindAisleTop();
            }
        }

        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;

            if (imgName != "")
            {
                urlThumbnail = "thumbnailUserAisileimg.aspx?imgName=" + imgName;
            }

            return urlThumbnail;
        }

        public void BindAisleTop()
        {
            DataTable dt = objBAL.BindAisleTop();

            dtlAisleList.DataSource = dt;
            dtlAisleList.DataBind();
            dtlAisleList.Visible = true;

            Panel pnlCategory = (Panel)this.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;

            Panel pnlHow = (Panel)this.Master.FindControl("pnlHow");
            pnlHow.Visible = false;

            Panel pnlAccount = (Panel)this.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
        }
    }
}

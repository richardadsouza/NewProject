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
using BAL;

namespace groceryguys
{
    public partial class savelist : System.Web.UI.Page
    {
        private BALClass objBAL = new BALClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null || String.IsNullOrWhiteSpace(Convert.ToString(Session["UserID"])))
                {
                    Response.Redirect("~/LoginPage.aspx");
                }

                if (Session["ShoppingCart"] != null)
                {
                    string shoppingCart = (Convert.ToString(Session["ShoppingCart"]));
                    DataTable dt = objBAL.GetShoppingCart(shoppingCart);

                    if (dt.Rows.Count > 0)
                    {
                        dtlShopList.DataSource = dt;
                        dtlShopList.DataBind();
                    }
                    else
                    {
                        lblMsg.Text = "Shopping list is empty";
                    }
                }
                else
                {
                    lblMsg.Text = "Shopping list is empty";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["ShoppingCart"] != null && String.IsNullOrWhiteSpace(Convert.ToString(Session["ShoppingCart"])))
            {
                string saveListName = txtListNm.Text;
                string userID = String.Empty;

                if (Session["UserID"] != null && String.IsNullOrWhiteSpace(Convert.ToString(Session["UserID"])))
                {
                    userID = Convert.ToString(Session["UserID"]);

                    //Check if the savelist name is already used or not.
                    bool isUnique = objBAL.CheckSaveListName(saveListName, userID);

                    if (isUnique)
                    {
                        string saveListID = objBAL.CreateSaveList(saveListName, userID);                        
                    }
                    else
                    {
                        lblMsg.Text = "Save list name already used";
                    }
                }
            }
        }
    }
}

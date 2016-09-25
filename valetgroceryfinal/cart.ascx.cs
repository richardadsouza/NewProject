using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BAL;

namespace groceryguys
{
    public partial class cart : System.Web.UI.UserControl
    {
        BALClass objBAL = new BALClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillCart();
        }


        private void FillSubTotal(DataTable dt)
        {
            decimal total = 0;
            int qty = 0;
            decimal price = 0;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    qty = Convert.ToInt32(row["Qty"]);
                    price = Convert.ToDecimal(row["Price"]);

                    total += qty * price;
                }

                lblTotal.Text = Math.Round(total, 2).ToString();               
            }
        }

        public int FillCart()
        {
            int cartItems = 0;

            if (Session["ShoppingCart"] != null && Session["ShoppingCart"].ToString().Trim().Length > 0)
            {
                string shoppingCart = Convert.ToString(Session["ShoppingCart"]);

                DataTable dt = objBAL.GetShoppingCart(shoppingCart);

                if (dt.Rows.Count > 0)
                {
                    cartItems = dt.Rows.Count;

                    dtlCart.DataSource = dt;
                    dtlCart.DataBind();

                    FillSubTotal(dt);

                    pnlNoProd.Visible = false;
                    pnlProduct.Visible = true;
                }
                else
                {
                    cartItems = 0;
                    lblTotal.Text = "0.00";
                    pnlNoProd.Visible = true;
                    pnlProduct.Visible = false;
                }
            }

            return cartItems;
        }
    }
}

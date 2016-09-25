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
using System.Text;
using System.IO;
using System.Drawing;
using groceryguys.Class;
using BAL;
using Models;

namespace groceryguys
{
    public partial class products : System.Web.UI.Page
    {
        BALClass objBAL = new BALClass();
        string aisleID = "";
        string aisleTopID = "";
        string shelfID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSideLink();

                aisleID = Request.QueryString["AL"].ToString();
                aisleTopID = Request.QueryString["AT"].ToString();
                shelfID = Request.QueryString["SF"].ToString();

                AisleShelfName aisleShelfName = objBAL.GetAisleShelfInfo(aisleTopID, aisleID, shelfID);

                if (aisleShelfName != null)
                {
                    lblAisleName.Text = aisleShelfName.AisleName;
                    lblShelfName.Text = aisleShelfName.ShelfName;
                }

                int popularGridCount = GetPopularProducts();
                int itemGridCount = GetProductList();

                if (itemGridCount <= 0)
                {
                    pnlAllProduct.Visible = false;

                    pnlMessage.Visible = true;
                }
                else
                {
                    if (popularGridCount <= 0)
                    {
                        pnlPopularProduct.Visible = false;
                    }

                    pnlMessage.Visible = false;
                }
            }
        }

        private int GetProductList()
        {
            int count = 0;

            DataTable dtProductList = objBAL.GetProductList(shelfID);
            count = dtProductList.Rows.Count;

            if (count > 0)
            {
                dtProductList = objBAL.InsertDollarSign(dtProductList);

                dltAllItems.DataSource = dtProductList;
                dltAllItems.DataBind();
            }

            return count;
        }

        private int GetPopularProducts()
        {
            int count = 0;

            DataTable dtPopularProduct = objBAL.GetPopularProducts(shelfID);
            count = dtPopularProduct.Rows.Count;

            if (count > 0)
            {
                dtPopularProduct = objBAL.InsertDollarSign(dtPopularProduct);

                dltPopularProduct.DataSource = dtPopularProduct;
                dltPopularProduct.DataBind();
            }

            return count;
        }

        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;

            if (imgName != "")
            {
                urlThumbnail = "Admin/thumbnailmainimage.aspx?imgName=" + imgName;
            }

            return urlThumbnail;
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

        protected void dltPopularProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string productID = Convert.ToString(e.CommandArgument);
        }

        protected void dltAllItems_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string productID = Convert.ToString(e.CommandArgument);
            int cartItems = 0;

            Label lblCart = (Label)this.Master.FindControl("lblCart");

            foreach (DataListItem item in dltAllItems.Items)
            {
                HiddenField hdnProductID = (HiddenField)item.FindControl("hdnProductID");

                if (hdnProductID.Value == productID)
                {
                    TextBox txtQty = (TextBox)item.FindControl("txtQty");

                    bool isValidNumber = objBAL.CheckIsValidNumber(txtQty.Text);

                    if (!isValidNumber)
                    {
                        Panel pnlQtyErr = (Panel)item.FindControl("pnlQtyErr");
                        pnlQtyErr.Visible = true;
                    }
                    else
                    {
                        if (Convert.ToInt32(txtQty.Text) > 0)
                        {
                            Panel pnlQtyErr = (Panel)item.FindControl("pnlQtyErr");
                            pnlQtyErr.Visible = false;

                            if (Session["ShoppingCart"] == null || Session["ShoppingCart"].ToString().Trim().Length <= 0)
                            {
                                string shoppingCart = productID + "|@|" + txtQty.Text;
                                Session["ShoppingCart"] = shoppingCart;

                                lblCart.Text = Convert.ToString(UserScript1.FillCart()) + " items";
                            }
                            else
                            {
                                string shoppingCart = Session["ShoppingCart"].ToString();
                                shoppingCart += "|@|" + productID + "|@|" + txtQty.Text;
                                Session["ShoppingCart"] = shoppingCart;

                                lblCart.Text = Convert.ToString(UserScript1.FillCart()) + " items";
                            }
                        }
                    }

                    break;
                }
            }
        }
    }
}
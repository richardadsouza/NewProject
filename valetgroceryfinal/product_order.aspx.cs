using System;
using groceryguys.Class;
using BAL;
using System.Web.UI.WebControls;
using System.Data;
using Models;
using System.Collections.Generic;

namespace groceryguys
{
    public partial class product_order : System.Web.UI.Page
    {
        BALClass objBAL = new BALClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCouponError.Text = "";

                if (Session["UserID"] != null && !String.IsNullOrWhiteSpace(Convert.ToString(Session["UserID"])))
                {
                    BindSideLink();

                    if (Session["ShoppingCart"] != null)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(Session["ShoppingCart"])))
                        {
                            HideCart(true);
                        }
                        else
                        {
                            HideCart(false);
                            FillCart();

                            if (Session["Coupon"] == null)
                            {
                                ShowHideDiscount(false);
                            }
                            else
                            {
                                ShowHideDiscount(true);
                                lblDiscount.Text = Convert.ToString(((Coupon)Session["Coupon"]).Amount);
                            }
                        }
                    }
                    else
                    {
                        HideCart(true);
                    }
                }
                else
                {
                    Server.Transfer("LoginPage.aspx");
                }
            }
        }

        private void HideCart(bool flag)
        {
            pnlCart.Visible = !flag;
            lblMsg.Visible = flag;
            lblMsg.Text = ConstantString.emptyCart;
        }

        private void BindSideLink()
        {
            Panel pnlCategory = (Panel)this.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;
            Panel pnlHow = (Panel)this.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlAccount = (Panel)this.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
        }

        private void CalculateTotal(DataTable dt)
        {
            int taxType = 0;
            decimal total, subTotal, tax, deliveryFee, totalAfterDiscount;
            total = subTotal = tax = deliveryFee = totalAfterDiscount = 0;

            ShoppingCartVariables shoppingCartVariables;

            if (Application["ShoppingCartVariables"] == null)
            {
                shoppingCartVariables = objBAL.GetShoppingCartVariables();
                Application["ShoppingCartVariables"] = shoppingCartVariables;
            }
            else
            {
                shoppingCartVariables = (ShoppingCartVariables)Application["ShoppingCartVariables"];
            }

            deliveryFee = shoppingCartVariables.DeliveryFee;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    decimal itemAmt = Convert.ToDecimal(row["Qty"]) * Convert.ToDecimal(row["Price"]);
                    subTotal += itemAmt;
                    taxType = Convert.ToInt16(row["TaxType"]);

                    if (taxType == 1)
                    {
                        tax += Math.Round((itemAmt * shoppingCartVariables.FoodTax / 100), 2);
                    }
                    else
                    {
                        tax += Math.Round((itemAmt * shoppingCartVariables.NonFoodTax / 100), 2);
                    }
                }

                total += subTotal + tax;

                if (subTotal < shoppingCartVariables.DeliveryFeeCutOff)
                {
                    total += deliveryFee;
                }

                if (Session["Coupon"] != null)
                {
                    totalAfterDiscount = total;

                    decimal couponAmt = ((Coupon)Session["Coupon"]).Amount;

                    totalAfterDiscount -= couponAmt;

                    if (totalAfterDiscount < 0)
                    {
                        totalAfterDiscount = 0;
                    }

                    lblTotValueAfterDiscount.Text = Convert.ToString(totalAfterDiscount);
                    ShowHideDiscount(true);
                }
                else
                {
                    ShowHideDiscount(false);
                }

                lblDeliveryFeeTot.Text = deliveryFee.ToString();
                lblTaxVal.Text = tax.ToString();
                lblTotVal.Text = Math.Round(total, 2).ToString();
                lblSubTotVal.Text = subTotal.ToString();
            }
        }

        private void ShowHideDiscount(bool flag)
        {
            Label1.Visible = flag;
            lblDiscount.Visible = flag;
            lblTotAfterDiscount.Visible = flag;
            lblTotValueAfterDiscount.Visible = flag;
            lblSign5.Visible = flag;
            lblSign6.Visible = flag;
        }

        private void FillCart()
        {
            DataTable dt = new DataTable();

            if (Session["ShoppingCart"] != null)
            {
                dt = objBAL.GetShoppingCart(Convert.ToString(Session["ShoppingCart"]));

                if (dt.Rows.Count > 0)
                {
                    grvOrderDetails.DataSource = dt;
                    grvOrderDetails.DataBind();

                    CalculateTotal(dt);
                }
                else
                {
                    HideCart(true);
                }
            }
            else
            {
                HideCart(true);
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            /*Variable to find if the coupon is valid or not.
            0. Error
            1. Valid
            2. Invalid coupon: Already used.
            3. Invalid coupon: Coupon not applicable.
            4. Wrong coupon code.*/

            if (Session["Coupon"] != null)
            {
                lblCouponError.Text = "Only 1 coupon can be applied for each order";
            }
            else
            {
                int couponFlag = objBAL.CheckCouponCode(txtCouponCode.Text, Convert.ToString(Session["UserID"]));

                switch (couponFlag)
                {
                    case 0:
                        lblCouponError.Text = "ERROR: Please try after sometime";
                        break;
                    case 1:
                        lblCouponError.Text = "";
                        lblSign5.Visible = true;
                        lblDiscount.Visible = true;

                        Coupon coupon = objBAL.GetCoupon(txtCouponCode.Text);

                        lblDiscount.Text = coupon.Amount.ToString();
                        Session["Coupon"] = coupon;
                        break;
                    case 2:
                        lblCouponError.Text = "Coupon already used";
                        break;
                    case 3:
                        lblCouponError.Text = "Coupon is not applicable for you";
                        break;
                    case 4:
                        lblCouponError.Text = "Invalid coupon code";
                        break;
                }

                txtCouponCode.Text = "";
            }
        }

        protected void imgCheck_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("~/confirmaddress.aspx");
        }

        protected void imgSaveList_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("~/savelist.aspx");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/shop.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            foreach (GridViewRow row in grvOrderDetails.Rows)
            {
                TextBox txtQty = (TextBox)row.FindControl("txtQty");              

                if (!objBAL.CheckIsValidNumber(txtQty.Text))
                {
                    isValid = false;
                }
            }

            if (isValid)
            {
                Dictionary<string, int> shoppingCartList = new Dictionary<string, int>();

                foreach (GridViewRow row in grvOrderDetails.Rows)
                {
                    shoppingCartList.Add(((HiddenField)row.FindControl("hdnProductID")).Value, Convert.ToInt32(((TextBox)row.FindControl("txtQty")).Text));
                }

                string shoppingCartString = objBAL.UpdateShoppingCart(shoppingCartList);

                Session["ShoppingCart"] = shoppingCartString;
                FillCart();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> productIDList = new List<string>();

            foreach (GridViewRow row in grvOrderDetails.Rows)
            {
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

                if (chkSelect.Checked)
                {
                    HiddenField hdnProductID = (HiddenField)row.FindControl("hdnProductID");

                    productIDList.Add(hdnProductID.Value);
                }

                if (productIDList.Count > 0)
                {
                    string shoppingCartString = objBAL.UpdateShoppingCart(Convert.ToString(Session["ShoppingCart"]), productIDList);

                    Session["ShoppingCart"] = shoppingCartString;
                    FillCart();
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using groceryguys.Class;

namespace groceryguys.Admin
{
    public partial class premadelist : System.Web.UI.Page
    {
        DbProvider dbListInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
            getCompanyName();
            if (!IsPostBack)
            {
                try
                {

                    BindGrid();


                }
                catch (Exception ex)
                {

                    Response.Write(ex.Message);
                }

            }

        }
        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminCustomers.Tables[0].Rows.Count > 0)
            {
                if (dsAdminCustomers != null && dsAdminCustomers.Tables.Count > 0 && dsAdminCustomers.Tables[0].Rows.Count > 0)
                {
                    MyDataListCustomers.DataSource = dsAdminCustomers;
                    MyDataListCustomers.DataBind();
                }

            }
            //for Site Functions

            DataList MyDataListSiteFunctions = (DataList)Page.Master.FindControl("dtlsitefunctions");
            sideType = 2;
            DataSet dsAdminSiteFunctions = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
            {
                if (dsAdminSiteFunctions != null && dsAdminSiteFunctions.Tables.Count > 0 && dsAdminSiteFunctions.Tables[0].Rows.Count > 0)
                {
                    MyDataListSiteFunctions.DataSource = dsAdminSiteFunctions;
                    MyDataListSiteFunctions.DataBind();
                }

            }

            //for reports

            DataList MyDataListReports = (DataList)Page.Master.FindControl("dtlreports");
            sideType = 3;
            DataSet dsAdminReports = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }

            // for Payment Options
            sideType = 5;
            DataSet dsAdminPayment = dbListInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

            if (dsAdminPayment.Tables[0].Rows.Count > 0)
            {
                if (dsAdminPayment != null && dsAdminPayment.Tables.Count > 0 && dsAdminPayment.Tables[0].Rows.Count > 0)
                {
                    Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
                    pnlPayment.Visible = true;
                }
                else
                {
                    Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
                    pnlPayment.Visible = false;

                }

            }
            else
            {
                Panel pnlPayment = (Panel)Page.Master.FindControl("pnlPayment");
                pnlPayment.Visible = false;

            }
            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Pre-Made List")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbListInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.ProductList;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        public void BindGrid()
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            int strproductId = 0;
            string strKey = string.Empty;
            string image = string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strproductId = Convert.ToInt32(Request.QueryString["strproduct"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsProductList = new DataSet();
            double price = 0;
            //double preprice = 0;
            //double buyprice = 0;
            //dsProductList = dbListInfo.GetProductListdetails(locationId, shefId, strKey);
            dsProductList = dbListInfo.GetProductListDetails_New1(locationId, shefId, strKey,strproductId);
            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProductList.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }

                       
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }

                    }

                    gridProductList.PageSize = perPage;
                    gridProductList.DataSource = dsProductList;
                    gridProductList.DataBind();


                }
                else
                {
                    gridProductList.Visible = false;
                    lblMsg.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = AppConstants.noRecord;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gridProductList.Visible = false;
                lblMsg.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.noRecord;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }

        public string Thumbnail(string imgName)
        {
            string urlThumbnail = string.Empty;
            if (imgName != "")
            {

                urlThumbnail = "thumbnailmainimage.aspx?imgName=" + imgName;

            }
            return urlThumbnail;
        }

        protected void gridProductList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                string strShopping = string.Empty;
                string strShop = string.Empty;


                DataValidator dataValidator = new DataValidator();
                if (e.CommandName == "AddQty")
                {

                    int intProductID = Convert.ToInt32(e.CommandArgument);
                    int prodID = 0;
                    int intErr = 0;
                    bool returnText;
                    string strFun = string.Empty;
                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        TextBox txtQty;
                        ImageButton btnAdd;
                        Label lblErrQty;
                        GridViewRow item = gridProductList.Rows[i];
                        txtQty = (TextBox)item.FindControl("txtQty");
                        btnAdd = (ImageButton)item.FindControl("btnAdd");
                        lblErrQty = (Label)item.FindControl("lblErrQty1");
                        Panel pnlQtyErr;
                        pnlQtyErr = (Panel)item.FindControl("pnlQtyErr");
                        prodID = Convert.ToInt32(btnAdd.CommandArgument);
                        if (intProductID == prodID)
                        {
                            if (txtQty.Text != "")
                            {
                                returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                                if (returnText == false)
                                {
                                    pnlQtyErr.Visible = true;
                                    intErr = 1;
                                    lblErrQty.Visible = true;
                                    lblErrQty.Text = AppConstants.pgOnlyNumber;

                                }
                                else
                                {
                                    pnlQtyErr.Visible = false;
                                    intErr = 0;
                                    lblErrQty.Visible = false;
                                    HideErrorBox();
                                    if (Request.Cookies["ShoppingCart"] == null || Request.Cookies["ShoppingCart"].Value == "")
                                    {


                                        strShopping = prodID + "|@|" + txtQty.Text;
                                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                        Response.Cookies.Add(ShoppingCart);
                                        UserScript2.bindCart();
                                        

                                    }
                                    else
                                    {
                                        strShop = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                                        strShopping = strShop + "|@|" + prodID + "|@|" + txtQty.Text;
                                        HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                                        Response.Cookies.Add(ShoppingCart);

                                    }


                                }

                            }
                        }


                    }
                    if (intErr == 0)
                    {
                        UserScript2.Update(strShopping);
                        clearTxt(2);
                    }




                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
        }


        public void HideErrorBox()
        {
            for (int i = 0; i < gridProductList.Rows.Count; i++)
            {

                GridViewRow item = gridProductList.Rows[i];
                Panel pnlQtyErr;
                Label lblErrQty;
                pnlQtyErr = (Panel)item.FindControl("pnlQtyErr");
                lblErrQty = (Label)item.FindControl("lblErrQty1");
                pnlQtyErr.Visible = false;
                lblErrQty.Visible = false;
                lblErrQty.Text = "";
            }


        }

        public void clearTxt(int intCheck)
        {
            if (intCheck == 2)
            {
                for (int i = 0; i < gridProductList.Rows.Count; i++)
                {
                    GridViewRow item = gridProductList.Rows[i];
                    TextBox txtQty;
                    txtQty = (TextBox)item.FindControl("txtQty");
                    txtQty.Text = "1";
                }
            }
            //else if (intCheck == 1)
            //{
            //    for (int i = 0; i < gridPopProdList.Rows.Count; i++)
            //    {
            //        TextBox txtQty;
            //        GridViewRow item = gridPopProdList.Rows[i];
            //        txtQty = (TextBox)item.FindControl("txtPopQty");
            //        txtQty.Text = "1";
            //    }
            //}
        }
        protected void gridProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridProductList.PageIndex = e.NewPageIndex;
            if (Convert.ToString(ViewState["pagingsortExpression"]) == "" && Convert.ToString(ViewState["pagingsortdirection"]) == "")
            {
                BindGrid();
            }
            else
            {
                SortGridView1(Convert.ToString(ViewState["pagingsortExpression"]), Convert.ToString(ViewState["pagingsortdirection"]));
            }
        }

        //protected void gridProductList_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    string sortExpression = e.SortExpression;
        //    try
        //    {
        //        if (GridViewSortDirection1 == SortDirection.Descending)
        //        {
        //            lblMsg1.Visible = false;
        //            GridViewSortDirection1 = SortDirection.Ascending;
        //            SortGridView1(sortExpression, ASCENDING);
        //        }
        //        else
        //        {
        //            lblMsg1.Visible = false;
        //            GridViewSortDirection1 = SortDirection.Descending;
        //            SortGridView1(sortExpression, DESCENDING);
        //        }
        //    }
        //    catch (Exception Addadvert_grid_Sortinge)
        //    {
        //        lblMsg1.Visible = true;
        //        lblMsg1.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
        //        lblMsg1.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

        public SortDirection GridViewSortDirection1
        {
            get
            {
                if (ViewState["sortDirection1"] == null)
                    ViewState["sortDirection1"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection1"];
            }
            set { ViewState["sortDirection1"] = value; }
        }

        private void SortGridView1(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance

            //int intAisle = 0;
            //int intShelf = 0;
            double price = 0;
            //double sale = 0;
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            string image = string.Empty;

           
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsProduct = new DataSet();
            //dsProduct = dbListInfo.GetShopProductInfo(intAisle, intShelf, Convert.ToInt32(AppConstants.locationId));
            dsProduct = dbListInfo.GetProductListDetails(locationId, shefId, strKey);
            if (dsProduct.Tables.Count > 0)
            {
                if (dsProduct != null && dsProduct.Tables.Count > 0 && dsProduct.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProduct.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }
                        //if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        //{
                        //    sale = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                        //    dtrow["productlink_presale"] = Convert.ToString(sale);
                        //}


                    }
                    DataTable dtSorting = dsProduct.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridProductList.DataSource = dvSorting;
                    gridProductList.DataBind();

                    for (int i = 0; i < gridProductList.Rows.Count; i++)
                    {
                        Label lblProductImage2;
                        Label lblProdDesc;
                        Panel pnlImg2;
                        Panel pnlNoImg;
                        Panel pnlDescImg2;
                        Panel PnlNoDescImg;
                        GridViewRow item = gridProductList.Rows[i];
                        lblProductImage2 = (Label)item.FindControl("lblProductImage2");
                        lblProdDesc = (Label)item.FindControl("lblProdDesc");
                        pnlImg2 = (Panel)item.FindControl("pnlImg2");
                        pnlNoImg = (Panel)item.FindControl("pnlNoImg");
                        pnlDescImg2 = (Panel)item.FindControl("pnlDescImg2");
                        PnlNoDescImg = (Panel)item.FindControl("PnlNoDescImg");


                        Panel pnlPrice;
                        Label lblPrice;
                        Label lblPreSalePrice;
                        lblPrice = (Label)item.FindControl("lblPrice");
                        lblPreSalePrice = (Label)item.FindControl("lblPreSalePrice");
                        pnlPrice = (Panel)item.FindControl("pnlPrice");

                        if (lblPreSalePrice.Text == "" || lblPreSalePrice.Text == null)
                        {
                            lblPrice.Visible = true;
                            lblPreSalePrice.Visible = false;
                            pnlPrice.Visible = false;
                        }
                        else
                        {
                            lblPrice.Visible = true;
                            lblPreSalePrice.Visible = true;
                            pnlPrice.Visible = true;

                        }

                        if ((lblProductImage2.Text == "" || lblProductImage2.Text == null) && (lblProdDesc.Text == "" || lblProdDesc.Text == null))
                        {
                            PnlNoDescImg.Visible = true;
                            pnlDescImg2.Visible = false;


                            pnlImg2.Visible = false;
                            pnlNoImg.Visible = true;
                        }
                        else
                        {
                            PnlNoDescImg.Visible = false;
                            pnlDescImg2.Visible = true;


                            pnlImg2.Visible = true;
                            pnlNoImg.Visible = false;
                        }
                    }
                }
            }
            ViewState["pagingsortExpression"] = sortExpression;
            ViewState["pagingsortdirection"] = direction;
            dbListInfo.dispose();

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            Response.Redirect("admin_product.aspx?check=1&loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);



        }

        protected void imgBack1_Click(object sender, ImageClickEventArgs e)
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            Response.Redirect("admin_product.aspx?check=1&loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);

        }

        protected void gridProductList_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression;
            try
            {
                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Descending;
                    SortGridView(sortExpression, DESCENDING);
                }
                else
                {
                    lblMsg.Visible = false;
                    GridViewSortDirection = SortDirection.Ascending;
                    SortGridView(sortExpression, ASCENDING);
                }
            }
            catch (Exception Addadvert_grid_Sortinge)
            {
                lblMsg.Visible = true;
                lblMsg.Text = AppConstants.adminSorry + Addadvert_grid_Sortinge.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        private void SortGridView(string sortExpression, string direction)
        {
            //  You can cache the DataTable for improving performance

            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            string image = string.Empty;
            double price = 0;
            double preprice = 0;
            double buyprice = 0;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);
            DataSet dsProductList = new DataSet();
            dsProductList = dbListInfo.GetProductListDetails(locationId, shefId, strKey);
            if (dsProductList.Tables.Count > 0)
            {
                if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow in dsProductList.Tables[0].Rows)
                    {
                        if (Convert.ToString(dtrow["productlink_price"]) != "")
                        {
                            price = Math.Round(Convert.ToDouble(dtrow["productlink_price"]), 2);
                            dtrow["productlink_price"] = Convert.ToString(price);
                        }

                        if (Convert.ToString(dtrow["productlink_buyprice"]) != "")
                        {
                            buyprice = Math.Round(Convert.ToDouble(dtrow["productlink_buyprice"]), 2);
                            dtrow["productlink_buyprice"] = Convert.ToString(buyprice);
                        }
                        if (Convert.ToString(dtrow["productlink_presale"]) != "")
                        {
                            preprice = Math.Round(Convert.ToDouble(dtrow["productlink_presale"]), 2);
                            dtrow["productlink_presale"] = Convert.ToString(preprice);
                        }
                        image = Convert.ToString(dtrow["product_image"]);
                        if (image == "")
                        {
                            dtrow["product_image"] = "no_image.gif";
                        }

                    }

                    gridProductList.PageSize = perPage;
                    DataTable dtSorting = dsProductList.Tables[0];
                    DataView dvSorting = new DataView(dtSorting);
                    dvSorting.Sort = sortExpression + direction;
                    gridProductList.DataSource = dvSorting;
                    gridProductList.DataBind();

                }
            }
            ViewState["ProductSortExpression"] = sortExpression;
            ViewState["ProductDirection"] = direction;
            dbListInfo.dispose();
        }
    }
}

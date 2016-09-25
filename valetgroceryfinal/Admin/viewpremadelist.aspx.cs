using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using groceryguys.Class;
using System.Data;

namespace groceryguys.Admin
{
    public partial class viewpremadelist : System.Web.UI.Page
    {
        DbProvider dbAddInfo = new DbProvider();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            changeLinks();
                    Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetNoStore();
                    if (!IsPostBack)
                    {

                        lblCartEmpty.Visible = false;
                        if (Request.Cookies["ShoppingCart"] == null)
                        {
                            lblCartEmpty.Visible = true;
                            lblCartEmpty.Text = "Your List is Empty.";
                            pnlCart.Visible = false;
                        }
                        else
                        {
                            lblCartEmpty.Visible = false;
                            lblCartEmpty.Text = "";
                            pnlCart.Visible = true;
                            bindShoppingList();
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
            DataSet dsAdminCustomers = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminPayment = dbAddInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);

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
            dbAddInfo.dispose();


        }
        
        public void bindShoppingList()
        {
            string strShopVal = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
            if (strShopVal == "")
            {
                lblCartEmpty.Visible = true;
                lblCartEmpty.Text = AppConstants.pgCartEmpty;
                pnlCart.Visible = false;

            }
            else
            {
                SplitShopString(strShopVal);
            }

        }

        public void SplitShopString(string StrShop)
        {

            int intProdId = 0;
            int intProdQty = 0;
            string strProdNm = string.Empty;
            string strPrice = string.Empty;

            string strTax = string.Empty;
            string strOrderVal = string.Empty;
            string strSoda = string.Empty;

            string image = string.Empty;
            int intCheck = 0;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            dtShop.Columns.Add("product_id");
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("product_title");
            dtShop.Columns.Add("productlink_price");
            dtShop.Columns.Add("product_image");
            dtShop.Columns.Add("product_size");
            dtShop.Columns.Add("product_image2");
            dtShop.Columns.Add("product_description");
            DataSet dsShop = new DataSet();

            string[] splitter = { "|@|" };
            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
          //  lblCartEmpty.Text = "";




            for (int i = 0; i < prodInfo.Length; i++)
            {
                rowShop = dtShop.NewRow();
                if (i % 2 == 0)
                {
                    intProdId = Convert.ToInt32(prodInfo[i]);
                    intProdQty = Convert.ToInt32(prodInfo[i + 1]);
                    dsShop = dbAddInfo.GetProductDetails(intProdId);
                    if (dsShop.Tables.Count > 0)
                    {
                        if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                        {
                            strTax = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_tax"]);
                            strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);
                            strSoda = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_soda"]);
                            if (dtShop.Rows.Count > 0)
                            {
                                foreach (DataRow dtrow in dtShop.Rows)
                                {
                                    if (Convert.ToString(dtrow["product_title"]) == strProdNm && Convert.ToInt32(dtrow["product_id"]) == intProdId)
                                    {
                                        dtrow["Qty"] = Convert.ToString(Convert.ToInt32(dtrow["Qty"]) + Convert.ToInt32(intProdQty));
                                        intCheck = 1;
                                    }


                                }
                            }
                            if (intCheck == 0)
                            {
                                rowShop = dtShop.NewRow();

                                rowShop["Qty"] = Convert.ToString(intProdQty);
                                rowShop["product_title"] = strProdNm;
                                rowShop["product_size"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_size"]);
                                rowShop["productlink_price"] = Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                rowShop["product_id"] = Convert.ToString(intProdId);
                                rowShop["product_image2"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_image2"]);
                                rowShop["product_description"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_description"]);
                                if (Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]) != "")
                                {
                                    rowShop["product_image"] = Convert.ToString(dsShop.Tables[0].Rows[0]["product_image"]);
                                }
                                else
                                {
                                    rowShop["product_image"] = "no_image.gif";

                                }
                                dtShop.Rows.Add(rowShop);
                            }



                        }
                        i = i + 1;

                    }
                }


            }
            dbAddInfo.dispose();
            gridShopList.DataSource = dtShop;
            gridShopList.DataBind();
            for (int i = 0; i < gridShopList.Rows.Count; i++)
            {
                Label lblProductImage2;
                Label lblProdDesc;
                Panel pnlImg2;
                Panel pnlNoImg;
                Panel pnlDescImg2;
                Panel PnlNoDescImg;
                GridViewRow item = gridShopList.Rows[i];
                lblProductImage2 = (Label)item.FindControl("lblProductImage2");
                lblProdDesc = (Label)item.FindControl("lblProdDesc");
                pnlImg2 = (Panel)item.FindControl("pnlImg2");
                pnlNoImg = (Panel)item.FindControl("pnlNoImg");
                pnlDescImg2 = (Panel)item.FindControl("pnlDescImg2");
                PnlNoDescImg = (Panel)item.FindControl("PnlNoDescImg");





            }







            dbAddInfo.dispose();

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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string strShopping = string.Empty;
                string strShop = string.Empty;
                DataValidator dataValidator = new DataValidator();
                bool returnText;
                bool returnZero;
                int intErr = 0;
                lblCartEmpty.Text = "";
                for (int i = 0; i < gridShopList.Rows.Count; i++)
                {
                    Panel pnlShopQtyErr;
                    TextBox txtQty;
                    Label lblErrQty;
                    Label lblShopProductId;
                    GridViewRow item = gridShopList.Rows[i];
                    txtQty = (TextBox)item.FindControl("txtShopQty");
                    lblErrQty = (Label)item.FindControl("lblErrQty");
                    lblShopProductId = (Label)item.FindControl("lblShopProductId");

                    pnlShopQtyErr = (Panel)item.FindControl("pnlShopQtyErr");
                    if (txtQty.Text != "")
                    {
                        returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));

                        if (returnText == false)
                        {
                            pnlShopQtyErr.Visible = true;
                            intErr = 1;
                            lblErrQty.Visible = true;
                            lblErrQty.Text = AppConstants.pgOnlyNumber;

                        }
                        returnZero = DataValidator.IsZeroNumber(Convert.ToString(txtQty.Text));
                        if (returnZero == false)
                        {
                            pnlShopQtyErr.Visible = true;
                            intErr = 1;
                            lblErrQty.Visible = true;
                            lblErrQty.Text = AppConstants.pgOnlyZeroNumber;

                        }
                        else
                        {
                            pnlShopQtyErr.Visible = false;
                            intErr = 0;
                            lblErrQty.Visible = false;
                            lblErrQty.Text = "";
                            if (strShopping == "")
                            {
                                strShopping = lblShopProductId.Text + "|@|" + txtQty.Text;
                            }
                            else
                            {
                                strShopping = strShopping + "|@|" + lblShopProductId.Text + "|@|" + txtQty.Text;

                            }
                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                            Response.Cookies.Add(ShoppingCart);
                            lblCartEmpty.Visible = true;
                            lblCartEmpty.Text = "List is updated successfully.";
                        }
                    }
                }
                if (intErr == 0)
                {
                   // HideErrorBox1();
                    SplitShopString(strShopping);

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        
      
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                string strShopping = string.Empty;
                string strShop = string.Empty;
                DataValidator dataValidator = new DataValidator();
                bool returnText;
                int intErr = 0;
                int intCnt = 0;
                for (int i = 0; i < gridShopList.Rows.Count; i++)
                {
                    CheckBox chkId;
                    GridViewRow item = gridShopList.Rows[i];
                    chkId = (CheckBox)item.FindControl("chkId");
                    if (chkId.Checked == true)
                    {
                        intCnt = 1;
                    }

                }


                if (intCnt == 1)
                {
                    lblCartEmpty.Visible = false;
                    lblCartEmpty.Text = "";
                    for (int i = 0; i < gridShopList.Rows.Count; i++)
                    {
                        CheckBox chkId;
                        TextBox txtQty;
                        Label lblErrQty;
                        Label lblShopProductId;
                        GridViewRow item = gridShopList.Rows[i];
                        txtQty = (TextBox)item.FindControl("txtShopQty");
                        lblErrQty = (Label)item.FindControl("lblErrQty");
                        chkId = (CheckBox)item.FindControl("chkId");
                        lblShopProductId = (Label)item.FindControl("lblShopProductId");
                        if (txtQty.Text != "")
                        {
                            returnText = DataValidator.IsValidNumber(Convert.ToString(txtQty.Text));
                            if (returnText == false)
                            {
                                intErr = 1;
                                lblErrQty.Visible = true;
                                lblErrQty.Text = AppConstants.pgOnlyNumber;

                            }
                            else
                            {
                                intErr = 0;
                                lblErrQty.Visible = false;
                                lblErrQty.Text = "";
                                if (chkId.Checked == false)
                                {
                                    if (strShopping == "")
                                    {
                                        strShopping = lblShopProductId.Text + "|@|" + txtQty.Text;
                                    }
                                    else
                                    {
                                        strShopping = strShopping + "|@|" + lblShopProductId.Text + "|@|" + txtQty.Text;
                                    }
                                }
                            }
                        }
                    }
                    if (intErr == 0)
                    {
                        if (strShopping == "")
                        {
                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", null);
                            Response.Cookies.Add(ShoppingCart);
                            lblCartEmpty.Visible = true;
                            lblCartEmpty.Text = "";
                            lblCartEmpty.Text = "Your List is Emply.";
                            pnlCart.Visible = false;

                        }
                        else
                        {
                            HttpCookie ShoppingCart = new HttpCookie("ShoppingCart", strShopping);
                            Response.Cookies.Add(ShoppingCart);
                            SplitShopString(strShopping);
                        }
                    }
                }
                else
                {
                    lblCartEmpty.Visible = true;
                    lblCartEmpty.Text = "";
                    lblCartEmpty.Text = AppConstants.pgSelectProdDel;


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

      

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                int intInsertList = 0;
                DataSet dsListName = new DataSet();

                dsListName = dbAddInfo.CheckListNameAlreadyExistadmin(txtListNm.Text, Convert.ToInt32(AppConstants.savedListTypeadmin));

                if (dsListName.Tables.Count > 0)
                {
                    if (dsListName != null && dsListName.Tables.Count > 0 && dsListName.Tables[0].Rows.Count > 0)
                    {
                        lblCartEmpty.Visible = true;
                        lblCartEmpty.Text = "";
                        lblCartEmpty.Text = AppConstants.strSaveListNmAlreadyExist;

                    }
                    else
                    {
                        string strShopVal = Convert.ToString(Request.Cookies["ShoppingCart"].Value);
                       
                            lblCartEmpty.Text = "";
                            intInsertList = dbAddInfo.InsertSavedListInfoadmin(txtListNm.Text,  Convert.ToInt32(AppConstants.locationId), Convert.ToInt32(AppConstants.savedListTypeadmin));
                            if (intInsertList > 0)
                            {

                                int intReturn = AddListProdInfo(strShopVal, intInsertList);
                                if (intReturn == 0)
                                {
                                    lblCartEmpty.Visible = true;
                                    lblCartEmpty.Text = "List is saved successfully.";
                                    HttpCookie myCookie = new HttpCookie("ShoppingCart");
                                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                                    Response.Cookies.Add(myCookie);
                                }
                            }
                            else
                            {
                                lblCartEmpty.Visible = true;
                                lblCartEmpty.Text = "";
                                lblCartEmpty.Text = AppConstants.strSaveListFailed;
                            }
                       // }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public int AddListProdInfo(string StrShop, int intListId)
        {
            int intReturn = 0;
            int intListMap = 0;
            int intCheck = 0;
            string strProdNm = string.Empty;
            string strPrice = string.Empty;
            int intProdId = 0;
            int intProdQty = 0;
            string strQtyNew = string.Empty;
            string strProdIdNew = string.Empty;
            DataTable dtShop = new DataTable();
            DataRow rowShop;
            dtShop.Columns.Add("Qty");
            dtShop.Columns.Add("ProdNm");
            dtShop.Columns.Add("Price");
            dtShop.Columns.Add("ProdId");
            DataSet dsShop = new DataSet();
            string[] splitter = { "|@|" };
            string[] prodInfo = StrShop.Split(splitter, StringSplitOptions.None);
            for (int i = 0; i < prodInfo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    intProdId = Convert.ToInt32(prodInfo[i]);
                    intProdQty = Convert.ToInt32(prodInfo[i + 1]);
                    dsShop = dbAddInfo.GetProductDetails(intProdId);
                    if (dsShop.Tables.Count > 0)
                    {
                        if (dsShop != null && dsShop.Tables.Count > 0 && dsShop.Tables[0].Rows.Count > 0)
                        {
                            strProdNm = Convert.ToString(dsShop.Tables[0].Rows[0]["product_title"]);
                            strPrice = Convert.ToString(dsShop.Tables[0].Rows[0]["productlink_price"]);

                            if (dtShop.Rows.Count > 0)
                            {
                                foreach (DataRow dtrow in dtShop.Rows)
                                {
                                    if (Convert.ToString(dtrow["ProdNm"]) == strProdNm && Convert.ToInt32(dtrow["ProdId"]) == intProdId)
                                    {
                                        dtrow["Qty"] = Convert.ToString(Convert.ToInt32(dtrow["Qty"]) + Convert.ToInt32(intProdQty));
                                        intCheck = 1;
                                    }
                                }
                            }
                            if (intCheck == 0)
                            {
                                rowShop = dtShop.NewRow();
                                rowShop["Qty"] = Convert.ToString(intProdQty);
                                rowShop["ProdNm"] = strProdNm;
                                string strPriceval = "$" + Convert.ToString(Math.Round(Convert.ToDouble(strPrice), 2));
                                rowShop["Price"] = strPriceval;
                                rowShop["ProdId"] = Convert.ToString(intProdId);
                                dtShop.Rows.Add(rowShop);
                            }
                            intCheck = 0;
                        }
                    }
                    i = i + 1;

                }
            }
            foreach (DataRow dtrow in dtShop.Rows)
            {
                strProdIdNew = Convert.ToString(dtrow["ProdId"]);
                strQtyNew = Convert.ToString(dtrow["Qty"]);

                intListMap = dbAddInfo.InsertSavedListMappingInfo(intListId, Convert.ToInt32(strProdIdNew), Convert.ToInt32(strQtyNew));
            }
            return intReturn;
        }

       
    }
}

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
    public partial class Editpremadelist : System.Web.UI.Page
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
                lblCartEmpty.Text = "";
                pnlCart.Visible = true;
                SplitShopString();

               
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

       

        public void SplitShopString()
        {
            int listid = Convert.ToInt32(Request.QueryString["listid"].ToString());

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
            DataSet dsList = new DataSet();

            dsList = dbAddInfo.GetListadminDetails(listid);
            if (dsList.Tables.Count > 0)
            {
                if (dsList != null && dsList.Tables.Count > 0 && dsList.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtrow1 in dsList.Tables[0].Rows)
                    {
                        intProdId = Convert.ToInt32(dtrow1["product_id"]);
                        intProdQty = Convert.ToInt32(dtrow1["listlink_qty"]);
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


                        }
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


        public void BindDeleteGrid(int intProductID, int ListId)
        {
            int intDeleteProduct = 0;
            intDeleteProduct = dbAddInfo.DeleteListproduct(intProductID, ListId);
            SplitShopString();

        }

        protected void gridShopList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {


            try
            {
                int intProductID = 0;
                int ListId = Convert.ToInt32(Request.QueryString["listid"].ToString());
                if (e.CommandName == "DeleteProduct")
                {
                   
                    intProductID = Convert.ToInt32(e.CommandArgument);
                    BindDeleteGrid(intProductID, ListId);
                }
                     int intProductID1 = 0;
                int ListId1 = Convert.ToInt32(Request.QueryString["listid"].ToString());

                if (e.CommandName == "UpdateProduct")
                {
                    intProductID1 = Convert.ToInt32(e.CommandArgument);

                    int intUpdate = 0;


                  //  for (int i = 0; i < gridShopList.Rows.Count; i++)
                  //  {

                    ImageButton img = (ImageButton)e.CommandSource; 
                    GridViewRow row = img.Parent.Parent as GridViewRow;
                        
                     
                    

                        TextBox txtShopQty;
                        txtShopQty = (TextBox)row.FindControl("txtShopQty");

                        if (txtShopQty.Text != "")
                        {
                            intUpdate = dbAddInfo.Updatelistprodqty(ListId1, intProductID1, Convert.ToInt32(txtShopQty.Text));
                            lblCartEmpty.Visible = true;
                            lblCartEmpty.Text = "List updated successfully.";
                        }

                   // }
                   
                }

                }

           
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

           
        }

       

    }
}

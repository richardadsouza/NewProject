﻿using System;
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
using System.Configuration;
using System.Collections;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Globalization;
using System.Collections.Specialized;
using System.Drawing.Drawing2D;
using System.IO;


namespace groceryguys.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        DbProvider dbEditInfo = new DbProvider();
        DropdownProvider dropSelf = new DropdownProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Attributes.Add("onclick", "clcontent();");
            changeLinks();
            getCompanyName();
             try
            {
                if (!IsPostBack)
                {
                   string filename = uploadLargeImg.FileName;

                 
                    DataSet dsProductList = new DataSet();
                    dropSelf.bindShelfDropdown(drpShelf);//Bind shelf  into dropdown
                    lblMsg.Text = "";
                    int productId = Convert.ToInt32(Request.QueryString["productId"]);
                    int asileId = Convert.ToInt32(Request.QueryString["asileId"]);
                     int shelf=Convert.ToInt32(Request.QueryString["shf"]);
                     dsProductList = dbEditInfo.SelectProductDetails(productId, asileId, shelf);
                    if (dsProductList.Tables.Count > 0)
                     {
                         if (dsProductList != null && dsProductList.Tables.Count > 0 && dsProductList.Tables[0].Rows.Count > 0)
                         {

                             txtTitle.Text = Convert.ToString(dsProductList.Tables[0].Rows[0]["product_title"]);
                             drpShelf.SelectedValue = Convert.ToString(dsProductList.Tables[0].Rows[0]["shelf_id"]);
                             //drpType.SelectedValue = Convert.ToString(dsProductList.Tables[0].Rows[0]["ProductType"]);
                             drpType.SelectedValue = Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_tax"]);
                             ViewState["ShelfInfo"] = Convert.ToString(dsProductList.Tables[0].Rows[0]["shelf_id"]);
                             ViewState["imageName"] = Convert.ToString(dsProductList.Tables[0].Rows[0]["product_image"]);
                             ViewState["imageNameLarge"] = Convert.ToString(dsProductList.Tables[0].Rows[0]["product_image2"]);
                             txtSize.Text = Convert.ToString(dsProductList.Tables[0].Rows[0]["product_size"]);
                             if (Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_presale"]) == null ||Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_presale"]) =="")
                             {
                                 txtPrePrice.Text = "";
                             }
                             else
                             {
                                 txtPrePrice.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsProductList.Tables[0].Rows[0]["productlink_presale"]),2));
                             }
                             txtPrice.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsProductList.Tables[0].Rows[0]["productlink_price"]),2));
                             txtBuyPrice.Text = Convert.ToString(Math.Round(Convert.ToDouble(dsProductList.Tables[0].Rows[0]["productlink_buyprice"]),2));
                             txtSodaDeposit.Text = Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_soda"]);
                             txtStore.Text = Convert.ToString(dsProductList.Tables[0].Rows[0]["product_store"]);
                             if (Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_suggest"]) == "1")
                             {
                                 chkSuggestItem.Checked = true;
                             }
                             //if (Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_tax"]) == "1")
                             //{
                             //    chkTaxItem.Checked = true;
                             //}
                             if (Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_featured"]) == "1")
                             {
                                 chkRecomItem.Checked = true;
                             }
                             if (Convert.ToString(dsProductList.Tables[0].Rows[0]["productlink_hide"]) == "1")
                             {
                                 chkHideItem.Checked = true;
                             }

                             FCKeditor1.Value =Convert.ToString(dsProductList.Tables[0].Rows[0]["product_description"]);
                             FCKeditor2.Value = Convert.ToString(dsProductList.Tables[0].Rows[0]["product_comments"]);

                             lblSmallImg.Text= Convert.ToString(ViewState["imageName"]);
                             lblLargeImag.Text = Convert.ToString(ViewState["imageNameLarge"]);
                         }
                     }
 
                }
               
            }
             catch (Exception ex)
             {
                 Response.Write(ex.Message);


             }

        }

        public void changeLinks()
        {

            int sideType = 0;
            string admin = Convert.ToString(Request.Cookies["adminId"].Value);

            //For Customers 
            DataList MyDataListCustomers = (DataList)Page.Master.FindControl("dtlcustomers");
            sideType = 1;
            DataSet dsAdminCustomers = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminSiteFunctions = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
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
            DataSet dsAdminReports = dbEditInfo.GetSideLinkInfo(Convert.ToInt32(admin), sideType);
            if (dsAdminReports.Tables[0].Rows.Count > 0)
            {
                if (dsAdminReports != null && dsAdminReports.Tables.Count > 0 && dsAdminReports.Tables[0].Rows.Count > 0)
                {
                    MyDataListReports.DataSource = dsAdminReports;
                    MyDataListReports.DataBind();
                }

            }


            foreach (DataListItem row1 in MyDataListSiteFunctions.Items)
            {
                LinkButton MyLinkButton = new LinkButton();
                MyLinkButton = (LinkButton)row1.FindControl("lkbSitefunctions");
                string name = MyLinkButton.Text;
                if (name == "Products")
                {
                    MyLinkButton.CssClass = "sublinkactive1";
                }
            }
            dbEditInfo.dispose();


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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.UpdateProduct;
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(Request.QueryString["productId"]);
                int asileId = Convert.ToInt32(Request.QueryString["asileId"]);
               
                int intProduct = 0;
                int intUpdateProductMapping = 0;
                int intUpdateProduct = 0;
                string imgName = string.Empty;
                string imgNameLarge = string.Empty;
                int intShelfId = 0;
                int intAsileId = 0;
                int intAsileLink = 0;
                int intDeleteProduct=0;
                int intSuggest = 0;
                int intTax = 0;
                int intRecom = 0;
                int intHide = 0;
                double soda = 0;
                int intProductMapping = 0;
                int intCheckImg = 0;
                intProduct = dbEditInfo.ProductNameUpdateAlreadyExist(txtTitle.Text, txtSize.Text, productId);
                if (intProduct == 0)
                {
                    intCheckImg= UploadProductImage();
                    if (intCheckImg == 0)
                    {
                        imgName = Convert.ToString(ViewState["filename"]);
                        imgNameLarge = Convert.ToString(ViewState["fileLargename"]);
                        if (imgName == "")
                        {
                            imgName = Convert.ToString(ViewState["imageName"]);
                        }
                        else 
                        {
                            lblSmallImg.Visible = true;
                            lblSmallImg.Text = imgName;
                        }
                        if (imgNameLarge == "")
                        {
                            imgNameLarge = Convert.ToString(ViewState["imageNameLarge"]);
                        }

                        else 
                        {

                            lblLargeImag.Visible = true;
                            lblLargeImag.Text = imgNameLarge;
                        
                        }
                        if (txtSmallImg.Text != "")
                        {
                            imgName = txtSmallImg.Text;
                        }
                        if(txtLargeImag.Text!="")
                        {
                            imgNameLarge = txtLargeImag.Text;
                        }
                        intUpdateProduct = dbEditInfo.UpdateProductInfo(txtTitle.Text, FCKeditor1.Value, imgName, txtSize.Text, imgNameLarge, FCKeditor2.Value, txtStore.Text, productId);
                        if (intUpdateProduct != 0)
                        {
                            intShelfId = Convert.ToInt32(drpShelf.SelectedValue);
                            if (chkSuggestItem.Checked == true)
                            {
                                intSuggest = 1;

                            }
                            if (chkRecomItem.Checked == true)
                            {
                                intRecom = 1;

                            }
                            //if (chkTaxItem.Checked == true)
                            //{
                            //    intTax = 1;

                            //}
                            intTax = Convert.ToInt32(drpType.SelectedValue);
                            if (chkHideItem.Checked == true)
                            {
                                intHide = 1;

                            }
                            if (txtSodaDeposit.Text != "")
                            {
                                soda = Convert.ToDouble(txtSodaDeposit.Text);
                            }

                            if (intShelfId == Convert.ToInt32(ViewState["ShelfInfo"]))
                            {
                                if (txtPrePrice.Text != "")
                                {
                                    intUpdateProductMapping = dbEditInfo.UpdateProductMappingInfo(productId, asileId, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtBuyPrice.Text), Convert.ToDouble(txtPrePrice.Text), soda, Convert.ToString(intSuggest), Convert.ToString(intTax), Convert.ToString(intRecom), Convert.ToString(intHide));
                                }
                                else
                                {
                                    intUpdateProductMapping = dbEditInfo.UpdateProductMappingInfo1(productId, asileId, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtBuyPrice.Text), soda, Convert.ToString(intSuggest), Convert.ToString(intTax), Convert.ToString(intRecom), Convert.ToString(intHide));


                                }


                            }
                            else
                            {
                                intDeleteProduct = dbEditInfo.DeleteProductMapping(productId);
                                if (intDeleteProduct != 0)
                                {
                                    DataSet dsShelfinfo = dbEditInfo.SelectAsileInfo(intShelfId);
                                    if (dsShelfinfo.Tables.Count > 0)
                                    {
                                        if (dsShelfinfo != null && dsShelfinfo.Tables.Count > 0 && dsShelfinfo.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow drShelfinfo in dsShelfinfo.Tables[0].Rows)
                                            {

                                                intAsileId = Convert.ToInt32(drShelfinfo["aisle_id"]);
                                                intAsileLink = Convert.ToInt32(drShelfinfo["aislelink_id"]);
                                                if (txtPrePrice.Text != "")
                                                {
                                                    intProductMapping = dbEditInfo.InsertProductMappingInfo(Convert.ToInt32(AppConstants.locationId), productId, intShelfId, intAsileId, intAsileLink, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtBuyPrice.Text), Convert.ToDouble(txtPrePrice.Text), soda, Convert.ToString(intSuggest), Convert.ToString(intTax), Convert.ToString(intRecom), Convert.ToString(intHide));
                                                }
                                                else
                                                {
                                                    intProductMapping = dbEditInfo.InsertProductMappingInfo1(Convert.ToInt32(AppConstants.locationId), productId, intShelfId, intAsileId, intAsileLink, Convert.ToDouble(txtPrice.Text), Convert.ToDouble(txtBuyPrice.Text), soda, Convert.ToString(intSuggest), Convert.ToString(intTax), Convert.ToString(intRecom), Convert.ToString(intHide));


                                                }
                                            }

                                        }
                                    }



                                }


                            }

                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.productUpdateSuccess;
                            lblMsg.ForeColor = System.Drawing.Color.Black;
                            Back();
                        }
                        else
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.productUpdateFailed;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                     {
                         lblMsg.Text = "";
                         lblMsg.Text = AppConstants.imgError;
                         lblMsg.ForeColor = System.Drawing.Color.Red;

                     }
                   
                    
                    
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.productAlreadyExist;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }


                //lblMsg.Text = "";
                //lblMsg.Text = AppConstants.productUpdateSuccess;

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);


            }

        }


        private int UploadProductImage()
        {
            string strFileName2, imgType3;
            string path = Server.MapPath("..\\Product\\");
            int file_append = 0;
            bool chkImg = true;
            int intReturn = 0;
            int nFileLen = uploadImg.PostedFile.ContentLength;
            if (nFileLen != 0)
            {
                strFileName2 = uploadImg.PostedFile.FileName;
                imgType3 = uploadImg.PostedFile.ContentType;
                chkImg = CheckFileType(strFileName2);
                if (chkImg == true)
                {

                    strFileName2 = System.IO.Path.GetFileName(strFileName2);

                    while (System.IO.File.Exists(Server.MapPath("..\\Product\\") + strFileName2))
                    {
                        HttpPostedFile myFile;
                        myFile = uploadImg.PostedFile;
                        file_append = file_append + 1;
                        strFileName2 = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + file_append.ToString() + ".jpg";
                    }
                    uploadImg.PostedFile.SaveAs(path + strFileName2);
                    int nFileLenLarge = uploadLargeImg.PostedFile.ContentLength;
                    if (nFileLenLarge != 0)
                    {
                        UploadProductLargeImage();
                    }
                    else
                    {

                        ViewState["fileLargename"] = "";
                        ViewState["Largecontent"] = "";
                    }

                    intReturn = 0;
                }

                else
                {
                    intReturn = 1;

                }
            }

            else
            {
                int nFileLenLarge = uploadLargeImg.PostedFile.ContentLength;
                if (nFileLenLarge != 0)
                {
                    UploadProductLargeImage();
                }
                else
                {

                    ViewState["fileLargename"] = "";
                    ViewState["Largecontent"] = "";
                }
                strFileName2 = "";
                imgType3 = "";
                intReturn = 0;
            }
            ViewState["filename"] = strFileName2;
            ViewState["content"] = imgType3;
            return intReturn;
            //else
            //{
            //    strFileName2 = "";
            //    imgType3 = "";
            //    intReturn = 0;
            //}
            //ViewState["filename"] = strFileName2;
            //ViewState["content"] = imgType3;
            //return intReturn;

        
        }




        private int UploadProductLargeImage()
        {
            string strFileName2, imgType3;
            string path = Server.MapPath("..\\Product\\");
            int file_append = 0;
            bool chkImg = true;
            int intReturn = 0;
            int nFileLen = uploadLargeImg.PostedFile.ContentLength;
            if (nFileLen != 0)
            {
                strFileName2 = uploadLargeImg.PostedFile.FileName;
                imgType3 = uploadLargeImg.PostedFile.ContentType;
                chkImg = CheckFileType(strFileName2);
                if (chkImg == true)
                {

                    strFileName2 = System.IO.Path.GetFileName(strFileName2);

                    while (System.IO.File.Exists(Server.MapPath("..\\Product\\") + strFileName2))
                    {
                        HttpPostedFile myFile;
                        myFile = uploadLargeImg.PostedFile;
                        file_append = file_append + 1;
                        strFileName2 = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + file_append.ToString() + ".jpg";
                    }
                    uploadLargeImg.PostedFile.SaveAs(path + strFileName2);

                    intReturn = 0;


                }

                else
                {
                    intReturn = 1;

                }
            }
            else
            {
                strFileName2 = "";
                imgType3 = "";
                intReturn = 0;
            }
            ViewState["fileLargename"] = strFileName2;
            ViewState["Largecontent"] = imgType3;
            return intReturn;


        }


        public bool CheckFileType(string FileName)
        {

            string Ext = Path.GetExtension(FileName);

            switch (Ext.ToLower())
            {

                case ".gif":

                    return true;

                   // break;

                case ".jpeg":

                    return true;

                   // break;

                case ".jpg":

                    return true;

                   // break;

                case ".png":

                    return true;

                   // break;
                case ".bmp":

                    return true;

                    //break;

                default:

                    return false;

                   // break;

            }

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

            Response.Redirect("ViewProductdDetails.aspx?loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);

            

        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            Back();
        }
        private void Back()
        {
            int locationId = 0;
            int perPage = 0;
            int shefId = 0;
            string strKey = string.Empty;
            locationId = Convert.ToInt32(Request.QueryString["loc"]);
            shefId = Convert.ToInt32(Request.QueryString["shefId"]);
            strKey = Request.QueryString["strKey"];
            perPage = Convert.ToInt32(Request.QueryString["perPage"]);

            Response.Redirect("ViewProductdDetails.aspx?loc=" + locationId + "&shefId=" + shefId + "&perPage=" + perPage + "&strKey=" + strKey, false);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;

namespace groceryguys.Admin
{
    public partial class thumbnailBig: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateThumbsBig();

        }

        public void CreateThumbsBig()
        {
            try
            {

                string QryString = Request.QueryString["imgName"];

                //int height = 50;
                //int width = 50;

                // Response.ContentType = "image/gif";
                string strBigServerPath = Server.MapPath("..//Product//") + QryString;

                System.Drawing.Image.GetThumbnailImageAbort dummyCallBack;
                dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);

                System.Drawing.Image fullSizeImg = null;
                if (System.IO.File.Exists(strBigServerPath))
                {
                    fullSizeImg = System.Drawing.Image.FromFile(strBigServerPath);
                }
                else
                {
                    return;
                }

                System.Drawing.Image thumbNailImg;

                //if (fullSizeImg.Height < 50)
                //{
                //    height = fullSizeImg.Height;
                //}
                //if (fullSizeImg.Width < 50)
                //{
                //    width = fullSizeImg.Width;
                //}
                thumbNailImg = fullSizeImg.GetThumbnailImage(Convert.ToInt32(fullSizeImg.Width), Convert.ToInt32(fullSizeImg.Height), dummyCallBack, IntPtr.Zero);
                if (System.IO.File.Exists(strBigServerPath))
                {
                    thumbNailImg.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }


            catch (Exception ex)
            {
                Response.Write(ex.Message + "PageLoad");

            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}

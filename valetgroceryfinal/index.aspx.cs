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
using BAL;

namespace groceryguys
{
    public partial class index : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DropdownProvider dropZip = new DropdownProvider();
        BALClass objBAL = new BALClass();
        
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
                ddlZipCode.DataSource = objBAL.GetZipcodeList();
                ddlZipCode.DataTextField = "Zipcode";
                ddlZipCode.DataValueField = "ZipcodeID";
                ddlZipCode.DataBind();
            }
        }       
    }
}

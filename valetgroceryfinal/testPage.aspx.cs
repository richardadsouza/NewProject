﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using groceryguys.Class;

namespace groceryguys
{
    public partial class testPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



           string[] image_arr=new string[]{};

           // image_arr[0];

           DbProvider dbListInfo = new DbProvider();


          griduserList.DataSource= dbListInfo.GetAllUser();
          griduserList.DataBind();
          dbListInfo.dispose();
        }
    }
}

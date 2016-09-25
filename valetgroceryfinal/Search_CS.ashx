<%@ WebHandler Language="C#" Class="Search_CS" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public class Search_CS : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string prefixText = context.Request.QueryString["q"];
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                
          //  "SELECT  dbo.product_details_vw.productlink_hide,  dbo.product_details_vw.product_title,  FROM  dbo.product_details_vw  WHERE ( (dbo.product_details_vw.productlink_hide = 0) AND (dbo.product_details_vw.product_title LIKE '%' + @strKey + '%') ";    
                
                
                //cmd.CommandText = "select product_title from product where " +
                //"product_title like '%'+ @SearchText + '%'";

            cmd.CommandText = "SELECT  dbo.product_details_vw.productlink_hide,  dbo.product_details_vw.product_title  FROM  dbo.product_details_vw  where (dbo.product_details_vw.productlink_hide = 0) AND " +
            "dbo.product_details_vw.product_title like '%'+ @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", prefixText);
                cmd.Connection = conn;
                StringBuilder sb = new StringBuilder(); 
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        sb.Append(sdr["product_title"])
                            .Append(Environment.NewLine);
                    }
                }
                conn.Close();
                context.Response.Write(sb.ToString()); 
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}
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
using System.Security.Cryptography;
using System.Net.Mail;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;
using groceryguys.Class;

namespace groceryguys
{
    public partial class UserForgotPasssword : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        PasswordRestrictions EncryptDecrypt = new PasswordRestrictions();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                if (!IsPostBack)
                {
                   

                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }
        public void BindSideLink()
        {
            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = false;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = true;

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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgForgotpassword;
                        ViewState["CustomerServiceEmail"] = Convert.ToString(dtrow["CustomerServiceEmail"]);
                        ViewState["CompanyShortName"] = Convert.ToString(dtrow["CompanyShortName"]);
                    }
                }
            }
            dbGetCompanyName.dispose();
        }

        
        protected void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                string strpassword = string.Empty;
                string strEncrypt = string.Empty;
                string usernm = string.Empty;
                int intStatus = 0;
                int UpdateForgotPass = 0;
                DataSet dsUserLogin = dbInfo.GetUserEmailInfo(txtEmail.Text);//To fetch admin id from database with the username and  password provided by user.
                if (dsUserLogin.Tables[0].Rows.Count > 0)
                {
                    if (dsUserLogin != null && dsUserLogin.Tables.Count > 0 && dsUserLogin.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drLogin in dsUserLogin.Tables[0].Rows)
                        {
                            string strName=dsUserLogin.Tables[0].Rows[0]["users_fname"]+" "+dsUserLogin.Tables[0].Rows[0]["users_lname"];
                            ViewState["UserName"] = strName;
                            intStatus = check();
                            if (intStatus == 1)
                            {
                                strpassword = Convert.ToString(ViewState["Password"]);
                               // strEncrypt = EncryptDecrypt.encryptPassword(strpassword);
                                strEncrypt = strpassword;
                                UpdateForgotPass = dbInfo.UpdateUserForgotPassword(txtEmail.Text, strEncrypt);
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.userForgotPasswordSuccess;
                                lblMsg.ForeColor = System.Drawing.Color.Black;
                                txtEmail.Text = "";

                            }
                            else
                            {
                                lblMsg.Text = "";
                                lblMsg.Text = AppConstants.forgotPasswordFailed;
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                               

                            }


                        }
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = AppConstants.noEmailExist;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    


                }


                dbInfo.dispose();



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }
           
        }


        public string GetRandomPasswordUsingGUID(int length)
        {
            //Function to create random password

            // Get the GUID
            string strGuidResult = Convert.ToString(System.Guid.NewGuid());
            // Remove the hyphens
            strGuidResult = strGuidResult.Replace("-", string.Empty);
            // Make sure length is valid
            if (length <= 6 || length > strGuidResult.Length)
                throw new ArgumentException(AppConstants.adminLength + strGuidResult.Length);
            // Return the first length bytes
            return strGuidResult.Substring(7, length);
        }



        public int check()
        {


            int status = 0;
            try
            {
                SmtpClient smtp = new SmtpClient();
                string strEmailContent = string.Empty;
                string strPwd = string.Empty;
                string strCompanyName = string.Empty;
                

                DataTable dtCheckUser = new DataTable();
                MailMessage emailToUser = new MailMessage(Convert.ToString(ViewState["CustomerServiceEmail"]), txtEmail.Text);
                //Create random password

                strPwd = GetRandomPasswordUsingGUID(7);
                ViewState["Password"] = strPwd;
                strCompanyName = Convert.ToString(ViewState["CompanyShortName"]);

                //Fetch file name from AppConstants class file
                string strAdminEmailFileName = AppConstants.strUserForgotPasswordFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.
                
                string emailText = txtEmail.Text;
                emailVariable["$Username$"] = Convert.ToString(ViewState["UserName"]);
                emailVariable["$emailId$"] = emailText;
                emailVariable["$password$"] = strPwd;
                emailVariable["$companyName$"] = strCompanyName;
                 
                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];
                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }
                string strsubject = strCompanyName + " " + AppConstants.strForgotPwdMailSubject;

                emailToUser.Subject = strsubject;
                emailToUser.Body = strEmailContent;
                emailToUser.IsBodyHtml = true;

                SmtpClient smtpServer = new SmtpClient();

                smtpServer.Send(emailToUser);
                status = 1;

            }

            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            return status;
        }
    }
}

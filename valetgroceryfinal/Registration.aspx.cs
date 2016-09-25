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
    public partial class Registration : System.Web.UI.Page
    {
        DbProvider dbInfo = new DbProvider();
        DropdownProvider dropState= new DropdownProvider();
        PasswordRestrictions pwdRestrict = new PasswordRestrictions();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindSideLink();
                getCompanyName();
                txtEmail.Attributes.Add("onblur", "CheckEmailAvailability();");
                btnRegister.Attributes.Add("onclick", "clcontent();");

                if (!IsPostBack)
                {
                    pnlSignIn.Visible = true;
                    pnlSuccess.Visible = false;

                    txtAddress1.Text = txtAddress2.Text = txtCity.Text = txtEmail.Text = txtFName.Text = txtLName.Text = txtPassword.Text = txtPhone1.Text = txtReEmail.Text = txtRePassword.Text = txtSiteReferBy.Text = txtSpend.Text = "";

                   // dropState.bindStateDropdown(drpState);
                    dropState.bindStateDropdownNew(drpState, Convert.ToString(ViewState["StateShortName"]));//Bind state  into dropdown
                    dropState.bindZipDropdown_hide(drpZip);//Bind zip  into dropdown
                    //dropState.bindStateDropdownNew(drpState, Convert.ToString(ViewState["StateShortName"]));//Bind state  into dropdown
                    lblMsg.Text = "";
                    lblMsg.Text = "";
                    string Zip = string.Empty;
                    Zip = Convert.ToString(Request.QueryString["zip"]);
                    //txtZipCode.Text = Zip;
                    //txtZipCode.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        public void BindSideLink()
        {
            Panel pnlHow = (Panel)Page.Master.FindControl("pnlHow");
            pnlHow.Visible = true;
            Panel pnlAccount = (Panel)Page.Master.FindControl("pnlAccount");
            pnlAccount.Visible = false;
            Panel pnlCategory = (Panel)Page.Master.FindControl("pnlCategory");
            pnlCategory.Visible = false;
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
                        Page.Header.Title = Convert.ToString(dtrow["CompanyShortName"]) + AppConstants.pgSignUp;
                        ViewState["CompanyName"] = Convert.ToString(dtrow["CompanyShortName"]);
                        ViewState["DeliveryFee"] = Convert.ToString(dtrow["DeliveryFee"]);
                        ViewState["CustomerServiceEmail"] = Convert.ToString(dtrow["CustomerServiceEmail"]);
                        ViewState["StateShortName"] = Convert.ToString(dtrow["StateShortName"]);
                        ViewState["DeliveryFeeCutOff"] = Convert.ToString(dtrow["DeliveryFeeCutOff"]);
                        ViewState["FirstOrderGift"] = Convert.ToString(dtrow["FirstOrderGift"]);
                    }
                }
            }

            dbGetCompanyName.dispose();
        }

        public int checkValidation()
        {
            DataValidator dataValidator = new DataValidator();
            bool returnEmail;
            bool returnPhone1;
            bool returnPhone2;
            int intCheck = 0;
            int intReturn = 0;
            string strMsg = string.Empty;

            returnEmail = DataValidator.IsValidEmail(Convert.ToString(txtEmail.Text));
            returnPhone1 = DataValidator.IsValidPhone(Convert.ToString(txtPhone1.Text));

            if (txtPhone2.Text != "")
            {
                returnPhone2 = DataValidator.IsValidPhone(Convert.ToString(txtPhone2.Text));
            }
            else
            {
                returnPhone2 = true;
            }

            if (returnEmail == false)
            {
                strMsg = AppConstants.invalidUserRegEmail;
                intCheck = 1;
            }

            if (returnPhone1 == false)
            {
                strMsg = strMsg + "<br>" + AppConstants.invalidUserRegPhone1;
                intCheck = 1;
            }

            if (returnPhone2 == false)
            {
                strMsg = strMsg + "<br>" + AppConstants.invalidUserRegPhone2;
                intCheck = 1;
            }

            if (chkAgree.Checked == false)
            {
                strMsg = strMsg + "<br>" + AppConstants.userSelectAgree;
                intCheck = 1;
            }

            if (intCheck != 0)
            {     
                lblMsg.Text = "";
                lblMsg.Text = strMsg;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                intReturn = 1;
            }

            return intReturn;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                pnlSignIn.Visible = true;
                pnlSuccess.Visible = false;
                int intChkValidation = 0;
                int insertData = 0;
                int intUnder100 = 0;
                int intOver100 = 0;
                //double accValue=5.00;
                string strPassNew = string.Empty;

                intChkValidation = checkValidation();

                if (intChkValidation == 0)
                {
                    DataSet dsEmail = new DataSet();
                    dsEmail = dbInfo.GetUserEmailInfo(txtEmail.Text);

                    if (dsEmail.Tables.Count > 0)
                    {
                        if (dsEmail != null && dsEmail.Tables.Count > 0 && dsEmail.Tables[0].Rows.Count > 0)
                        {
                            lblMsg.Text = "";
                            lblMsg.Text = AppConstants.userEmailAlreadyExist;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            DataSet dsZip = new DataSet();
                            dsZip = dbInfo.GetUserZipInfo(drpZip.SelectedItem.ToString());

                            if (dsZip.Tables.Count > 0)
                            {
                                if (dsZip != null && dsZip.Tables.Count > 0 && dsZip.Tables[0].Rows.Count > 0)
                                {
                                    if (dsZip.Tables[0].Rows[0]["ZipOrderSize"].ToString() != "")
                                    {
                                        //ViewState["OrderAmt"] = Convert.ToString(Math.Round(Convert.ToDouble(dsZip.Tables[0].Rows[0]["ZipOrderSize"]), 2));
                                    }
                                    else
                                    {
                                        ViewState["OrderAmt"] = "";
                                    }
                                    //strPassNew = pwdRestrict.encryptPassword(Convert.ToString(txtPassword.Text));
                                    strPassNew = (Convert.ToString(txtPassword.Text));
                                    insertData = dbInfo.InsertNewUserInformation(txtFName.Text, txtLName.Text, txtPhone1.Text, txtPhone2.Text, txtEmail.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, drpState.SelectedValue, drpZip.SelectedItem.ToString(), strPassNew, Convert.ToInt32(AppConstants.locationId), txtSiteReferBy.Text, txtSpend.Text, DateTime.Now, Convert.ToDouble(ViewState["FirstOrderGift"]), Convert.ToInt32(AppConstants.intUsersNewsletter), Convert.ToInt32(AppConstants.intUsersStatusId), intUnder100, intOver100);                                    if (insertData > 0)
                                    {
                                        int intTranc = 0;
                                        intTranc = dbInfo.InsertRegisterTransInfo(DateTime.Now, Convert.ToDouble(ViewState["FirstOrderGift"]), Convert.ToString(ViewState["CompanyName"]), "$ " + Convert.ToString(ViewState["FirstOrderGift"]) + " for registering.", insertData);

                                        int currentMonth = Convert.ToInt32(DateTime.Now.Month);
                                        int orderCountInfo = dbInfo.InsertOrderCountInfo(insertData, 0, currentMonth);
                                        dbInfo.dispose();

                                        int intsend = sendMail();

                                        if (intsend == 1)
                                        {
                                            pnlSignIn.Visible = false;
                                            pnlSuccess.Visible = true;
                                            lblCmpnm.Text = Convert.ToString(ViewState["CompanyName"]);
                                            lblMsg.Text = "";
                                            lblMsg.Text = AppConstants.userRegisterSuccuss;
                                            lblMsg.ForeColor = System.Drawing.Color.Black;
                                        }
                                    }
                                }
                                else
                                {
                                    Response.Redirect("AddNonDeliveryZone.aspx?zip=" + drpZip.SelectedItem.ToString(), false);
                                }
                            }
                            else
                            {
                                Response.Redirect("AddNonDeliveryZone.aspx?zip=" + drpZip.SelectedItem.ToString(), false);
                            }
                        }
                    }
                }

                dbInfo.dispose();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        public int sendMail()
        {
            int status = 0;

            try
            {
                SmtpClient smtp = new SmtpClient();
                string strEmailContent = string.Empty;
                string strPwd = string.Empty;
                string strCompanyName = string.Empty;               

                DataTable dtCheckUser = new DataTable();
                MailMessage emailToUser = new MailMessage(Convert.ToString(ViewState["CustomerServiceEmail"]),txtEmail.Text);
                                
                //Fetch file name from AppConstants class file
                string strAdminEmailFileName = AppConstants.strRegistrationFileName;

                //object created for NameValueCollection
                NameValueCollection emailVariable = new NameValueCollection();

                //Store values in NameValueCollection from database, for now it is fetch from datatable 
                //which is hardcoded.
                string strName =txtFName.Text+" "+txtLName.Text;
                emailVariable["$Username$"] = strName;
                emailVariable["$companyName$"] = Convert.ToString(ViewState["CompanyName"]);
                emailVariable["$DeliveryFee$"] = Convert.ToString(ViewState["DeliveryFee"]);
                emailVariable["$DeliveryFeeCutOff$"] = Convert.ToString(ViewState["DeliveryFeeCutOff"]);
                emailVariable["$emailId$"] = txtEmail.Text;
                emailVariable["$password$"] = txtPassword.Text;                

                //object created for EmailGenerator class file 

                EmailGenerator getEmailContent = new EmailGenerator();
                string strChkEmailFromDatabaseorFile = string.Empty;
                strChkEmailFromDatabaseorFile = ConfigurationSettings.AppSettings["mailtoread"];

                if (strChkEmailFromDatabaseorFile == "fromtextfile")
                {
                    strEmailContent = getEmailContent.SendEmailFromFile(strAdminEmailFileName, emailVariable);
                }

                string strsubject = Convert.ToString(ViewState["CompanyName"]) + " " + AppConstants.strRegistrationMailSubject;
                emailToUser.Subject = strsubject;
                emailToUser.Body = strEmailContent;
                emailToUser.IsBodyHtml = true;
                string strCC1 = "James@valetgrocery.com";

                MailAddress cc1 = new MailAddress(strCC1);
                emailToUser.CC.Add(cc1);

                SmtpClient smtpServer = new SmtpClient();

                smtpServer.Send(emailToUser);
                status = 1;
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }

            return status;
        }

        protected void btnShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx", false);
        }       
    }
}

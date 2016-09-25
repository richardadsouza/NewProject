<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Registration.aspx.cs" Inherits="groceryguys.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type=text], input[type=password]
        {
            width: 250px;
        }
    </style>

    <script type="text/javascript">
        var xmlhttp;

        function CheckEmailAvailability() {
            xmlhttp = null;
            var email = document.getElementById('<%=txtEmail.ClientID %>').value;
            var ShowImage1 = document.getElementById("ShowImage");

            if (email == "" || email.length < 3) {
                document.getElementById("<%=lblUserName.ClientID%>").innerHTML = "";
                ShowImage1.style.display = "none";
                return false;
            }

            if (window.XMLHttpRequest) {
                // code for all new browsers  
                xmlhttp = new XMLHttpRequest();
            }
            else if (window.ActiveXObject) {
                // code for IE5 and IE6xmlhttp=  
                new ActiveXObject("Microsoft.XMLHTTP");
            }

            if (xmlhttp != null) {

                xmlhttp.onreadystatechange = state_Change;
                xmlhttp.open("GET", "CheckEmailAddress.aspx?Email=" + email + "&.rand=" + Math.random(), true);
                xmlhttp.send(null);
            }
            else {
                alert("Oops..Your browser does not support XMLHTTP.");
            }
        }

        function state_Change() {
            if (xmlhttp.readyState == 4) {
                // 4 = �loaded� 

                if (xmlhttp.status == 200) {
                    //request was successful                
                    //check if email address is available and message  
                    var lblMesg = document.getElementById("<%=lblUserName.ClientID%>");
                    // alert(lblMesg); 
                    var imgSuccessUserName = document.getElementById("imgSuccessUserName");
                    //  alert(imgSuccessUserName); 
                    var ShowImage = document.getElementById("ShowImage");
                    // alert(xmlhttp.responseText); 

                    if (xmlhttp.responseText == "True") {
                        //  alert(xmlhttp.responseText);
                        ShowImage.style.display = "block";
                        imgSuccessUserName.src = "images/icon_success.png";

                        lblMesg.style.color = "Green";

                        lblMesg.innerHTML = "Email address available.";
                    }
                    else if (xmlhttp.responseText == "False") {
                        //   alert(xmlhttp.responseText);
                        ShowImage.style.display = "block";
                        imgSuccessUserName.src = "images/icon_error.png";
                        lblMesg.innerHTML = "Email address already in use.";
                        lblMesg.style.color = "Red";
                    }
                }
                else {
                    // alert(xmlhttp.responseText);
                    alert("Oops..email address availability could not be checked.");
                }
            }
        }
    </script>
    <script type="text/javascript">
        function clcontent() {
            var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
            lb1.innerHTML = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="90%" style="padding-left: 10px;">
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td align="left" class="formHeading">
                        <strong>Sign Up</strong>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUser">
                        <asp:Panel ID="pnlSignIn" runat="server">
                            <table cellpadding="3" cellspacing="0" border="0" style="width:100%;">
                                <tr>
                                    <td height="10px"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="formTextUser" colspan="2">We are currently delivering to your area!
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px"></td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">Field with a <span class="star1">*</span> are required
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px"></td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-left: 20%;" colspan="2">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                        <asp:Label ID="lblMsg" CssClass="ErrorTxtNew2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="formHeadingText" align="center">Personal and Delivery Information
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right" width="25%">
                                        <span class="star1">*</span>First Name:</td>
                                    <td>
                                        <asp:TextBox ID="txtFName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvFName" runat="server" Text="*" ControlToValidate="txtFName"
                                            ErrorMessage="First name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Last Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvLName" runat="server" Text="*" ControlToValidate="txtLName"
                                            ErrorMessage="Last name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Primary Phone Number:
                                    <br />
                                        <span class="formTextSmall1">(111-111-1111)</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhone1" runat="server" CssClass="textbox1" MaxLength="12"
                                            AutoPostBack="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" Text="*" ControlToValidate="txtPhone1"
                                            ErrorMessage="Primary phone number is required" ForeColor="White"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">Secondary Phone Number:
                                      <br />
                                        <span class="formTextSmall1">(111-111-1111)</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPhone2" runat="server" CssClass="textbox1" MaxLength="12"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Email Address:
                                    <br />
                                        <span class="formTextSmall1">Your email address will serve as your username.</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                            ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                        <div id="ShowImage" style="display: none">
                                            <img id="imgSuccessUserName" />
                                            <asp:Label ID="lblUserName" runat="server" CssClass="formTextUser"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Retype Email:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                            ControlToValidate="txtReEmail" ErrorMessage="Retype email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cmpEmail" runat="server" Text="*" ControlToValidate="txtReEmail"
                                            ControlToCompare="txtEmail" ErrorMessage="Email and retype email should be same"
                                            ForeColor="White"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span class="horizontalLine1"></span>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td align="left" colspan="2">
                                        <strong>Delivery Address</strong> - Please enter the address where the majority
                                    of your deliveries will be going.This address can be changed at any time.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Address 1:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" Text="*" ControlToValidate="txtAddress1"
                                            ErrorMessage="Address 1 is required" ForeColor="White"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">Address 2:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>City:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCity" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" Text="*" ControlToValidate="txtCity"
                                            ErrorMessage="City is required" ForeColor="White"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>State:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpState" runat="server" CssClass="DropDown">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" Text="*" ControlToValidate="drpState"
                                            ErrorMessage="Select state" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Zip Code:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpZip" runat="server" CssClass="DropDown">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvZip" runat="server" Text="*" ControlToValidate="drpZip"
                                            ErrorMessage="Select zip code" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span class="horizontalLine1"></span>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td align="left" colspan="2">Specify your desired account password.<br />
                                        <strong>NOTE:</strong> Passwords must be 7 to 20 characters long.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Password:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox1" MaxLength="20" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="*"
                                            ControlToValidate="txtPassword" ErrorMessage="Password is required" ForeColor="White"></asp:RequiredFieldValidator>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">
                                        <span class="star1">*</span>Retype Password:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRePassword" runat="server" CssClass="textbox1" MaxLength="20"
                                            TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvRePassword" runat="server" Text="*" ControlToValidate="txtRePassword"
                                            ErrorMessage="Retype password is required" ForeColor="White"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cmpPassword" runat="server" Text="*" ControlToValidate="txtRePassword"
                                            ControlToCompare="txtPassword" ErrorMessage="Password and retype password should be same"
                                            ForeColor="White"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="formHeadingText" align="center">Optional
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td align="left" colspan="2">Please take a minute and answer the following questions. These questions are <b>optional</b>.
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">How did you hear about the site?<br />
                                        <span class="formTextSmall1">If referred by a friend, please put their name here.</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSiteReferBy" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr valign="top">
                                    <td align="right">What store you normally shop for groceries at?                                  
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSpend" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span class="horizontalLine1"></span>
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td align="left" colspan="2">Before you may become a member, you must read and agree to our <a href="terms.aspx"
                                        class="Userlink1">terms and conditions.</a>
                                    </td>
                                </tr>                                
                                <tr valign="top">
                                    <td align="left" colspan="2">
                                        <asp:CheckBox ID="chkAgree" runat="server" />&nbsp <strong>I Agree.</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="padding-left: 250px;">
                                        <asp:Button ID="btnRegister" runat="server" Text="Click Here to Register" CssClass="buttonUser"
                                            OnClick="btnRegister_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
                            <table cellpadding="3" cellspacing="0" border="0">
                                <tr>
                                    <td height="10px"></td>
                                </tr>
                                <tr>
                                    <td align="left" class="formTextUser" colspan="2">Thank you for registering with &nbsp;<asp:Label ID="lblCmpnm" runat="server"></asp:Label>&nbsp;! You have been sent a confirmation email with your registration information.
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20px"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding-left: 250px;">
                                        <asp:Button ID="btnShop" runat="server" Text="Start Shopping" CssClass="buttonUser"
                                            OnClick="btnShop_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td height="5px">&nbsp;
                    </td>
                </tr>
            </table>
            <script type="text/javascript">
                var _gaq = _gaq || [];
                _gaq.push(['_setAccount', 'UA-20584458-1']);
                _gaq.push(['_trackPageview']);
                (function () {
                    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
                    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
                    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
                })();
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

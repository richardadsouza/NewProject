<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="groceryguys.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="formHeading">
                        <strong>Log In</strong>
                    </td>
                </tr>
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td align="center" class="formTextUser">
                        <center>Please enter your Grocery Guys username and password below to login:</center>
                    </td>
                </tr>
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td align="center">
                        <table cellpadding="3" cellspacing="0" border="0" class="formTextUser">
                            <tr>
                                <td colspan="2" align="center">Fields with an <span class="star1">*</span> are required.                           
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" ValidationGroup="LoginPage" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <asp:Label ID="lblMsg" CssClass="ErrorTxtNew2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Username(email):
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" Width="300px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                        ErrorMessage="Username(email) is required" ForeColor="White" ValidationGroup="LoginPage"></asp:RequiredFieldValidator>
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
                                    <asp:TextBox ID="txtPassword" Width="300px" runat="server" CssClass="textbox1" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPAssword" runat="server" Text="*" ControlToValidate="txtPassword"
                                        ErrorMessage="Password is required" ForeColor="White" ValidationGroup="LoginPage"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td style="padding-left: 5px;">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttonUser"
                                        OnClick="btnLogin_Click" ValidationGroup="LoginPage" CausesValidation="True" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td align="center">
                        <table cellpadding="4" cellspacing="0" border="0" class="border">
                            <tr bgcolor="#F5F5F5" valign="top">
                                <td width="300" class="formTextUser">
                                    <strong>Become a Member</strong><br />
                                    Not a member? Click below to become a member now!
		<p />
                                    <a href="CheckZipCode.aspx" class="Userlink1"><strong>Register Now!</strong></a>
                                </td>
                                <td width="30" align="center" class="formTextUser"></td>
                                <td width="300" class="formTextUser">
                                    <strong>Forgot Your Password?</strong><br />
                                    Have you lost or forgotten your account password? Click below to retrieve it.
		<br />
                                    <a href="UserForgotPasssword.aspx" class="Userlink1"><strong>Retrieve Password</strong></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

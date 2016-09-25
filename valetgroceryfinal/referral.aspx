﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="referral.aspx.cs" Inherits="groceryguys.referral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var Image1 = document.getElementById("Image9");
        var Image2 = document.getElementById("Image10");
        var Image3 = document.getElementById("Image11");
        var Image4 = document.getElementById("Image12");
        var Image5 = document.getElementById("Image13");
        var Image6 = document.getElementById("Image14");

        Image1.src = "images/subtab1-h.png";
        Image2.src = "images/subtab2.png";
        Image3.src = "images/subtab3.png";
        Image4.src = "images/subtab4.png";
        Image5.src = "images/subtab5.png";
        Image6.src = "images/subtab6.png";
    </script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table width="580px">
                <tr>
                    <td class="formHeading">Referral Rewards
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser"></td>
                </tr>
                <tr>
                    <td class="formTextUser" style="padding-right: 20px;">
                        <b>How?</b><br />
                        Use the form below to email your friends about
                        <asp:Label ID="lblCmpNm" runat="server"></asp:Label>. When they sign up and place an order, you will receive $5
                        of Account Funds! There are no limits on how many friends you can refer. 
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser"></td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>To get your name as the referral:</strong>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser" style="padding-right: 20px;">Your friend must add your name in the bottom of the "Become a Member" form (shown
                        below). Once they place their first order, we will deposit $5 into your account
                        and you will be notified by email.
                    </td>
                </tr>
                <tr>
                    <td>
                        <center>
                            <img src="images/referral.gif" alt="" width="457" height="222" border="0" /></center>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td class="formTextUser">Use the form below to email your friends. <a href="#" class="Userlink1" onclick='openReferFriendsPopUp()'>View the email message that is sent </a>:
                    </td>
                </tr>
                <tr>
                    <td height="10px"></td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td></td>
                                <td align="left">Fields with an <span class="star1">*</span> are required.                                
                                </td>
                            </tr>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="padding-left: 100px;">
                                    <asp:Label ID="lblMsg" CssClass="formTextUser" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="3px"></td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Your Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYourName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" Text="*" ControlToValidate="txtYourName"
                                        ErrorMessage="Your name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Your Email:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYourEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFName" runat="server" Text="*" ControlToValidate="txtYourEmail"
                                        ErrorMessage="Your email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">Personal Message:
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtPerMsg" runat="server" CssClass="textMultiline" MaxLength="2000"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="5px"></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left: 10px; color: #003b65;">
                                    <strong>Friend Information</strong>
                                </td>
                            </tr>
                            <tr>
                                <td height="5px"></td>
                            </tr>
                            <tr valign="top">
                                <td colspan="2" style="padding-left: 10px;">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr valign="top">
                                            <td align="right">1. <span class="star1">*</span>Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName1" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtName1"
                                                    ErrorMessage="Name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right">
                                                <span class="star1">*</span>Email:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail1" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                    ControlToValidate="txtEmail1" ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <hr size="-1" color="#fcd500" />
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td align="right">2.&nbsp;&nbsp; Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName2" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td align="right">Email:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail2" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <hr size="-1" color="#fcd500" />
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td align="right">3.&nbsp;&nbsp; Name:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtName3" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td align="right">Email:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail3" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left" style="padding-left: 15px;">
                                    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="buttonUser" OnClick="btnSend_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10px">&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

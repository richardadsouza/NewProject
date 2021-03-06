<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="ContactUsPage.aspx.cs" Inherits="groceryguys.ContactUsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                            <tr>
                                <td align="left" class="formHeading">
                                    <strong>Contact Us </strong>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td class="formTextUser" align="left" style="padding-right: 20px;">
                                    General Contact Information
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="formTextUser">
                                    Email:<a href="mailto:richard11.dsouza@gmail.com" class="Userlink11_new"> info@GroceryGuys.com </a>
                                    <br />
                                    Phone: <span class="Apple-style-span" 
                                        style="border-collapse: separate; color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: -webkit-auto; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-border-horizontal-spacing: 0px; -webkit-border-vertical-spacing: 0px; -webkit-text-decorations-in-effect: none; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; ">
                                    <span class="Apple-style-span" style="font-family: Tahoma; font-size: 13px; ">
                                   225-236-7922</span></span><br />                                   
                                    <br />
                                    Valet Grocery
                                    <br />
                                    8867 Highland Road #8A
                                    <br />
                                    Baton Rouge, LA 70808 
                                   <br />
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <tr>
                        <td  class="formTextUser" style="padding-left: 10px;">
                            <strong>Online Contact Form </strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                                <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="0" border="0" class="formTextUser">
                                            <tr>
                                                <td colspan="2">
                                                    Please use the form below for general inquiries.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    Field with an <span class="star1">*</span> are required
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2" style="padding-left: 150px;">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                                                    <asp:Label ID="lblMsg" CssClass="formTextUser" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="right">
                                                    <span class="star1">*</span>Name:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvNm" runat="server" Text="*" ControlToValidate="txtName"
                                                        ErrorMessage="Name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="right">
                                                    <span class="star1">*</span>Email:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtEmail"
                                                        ErrorMessage="Email is required" ForeColor="White"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="right">
                                                    <span class="star1">*</span>Questions/Comments:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQuestion" runat="server" CssClass="textMultiline" MaxLength="2000"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*"
                                                        ControlToValidate="txtQuestion" ErrorMessage="Questions/Comments is required"
                                                        ForeColor="White"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="left" style="padding-left: 6px;">
                                                    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="buttonUser" OnClick="btnSend_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true"
    CodeBehind="confirmaddress.aspx.cs" Inherits="groceryguys.confirmaddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
          <table width="100%" cellpadding="0" cellspacing="0" border="0">
          <tr>
          <td align="center" background="images/bodypagebg.jpg">          
            <table cellpadding="0" cellspacing="0" border="0" width="80%" style="padding-left: 10px;">
                <tr>
                    <td height="20px">
                        <asp:Label ID="lblAdd" runat="server"></asp:Label><br />
                        <asp:Label ID="lblAdd3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formHeading">
                        <strong>Confirm Delivery Address</strong>
                    </td>
                </tr>
                <tr>
                    <td height="20px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr valign="top">
                                <td width="135">
                                    <img src="images/checkout_2c.gif" alt="confirm delivery address" width="135" height="37"
                                        border="0" />
                                </td>
                                <td width="122">
                                    <img src="images/checkout_1b.gif" alt="pick a delivery time" width="122" height="37"
                                        border="0" />
                                </td>
                                <td width="131">
                                    <img src="images/checkout_3b.gif" alt="tip the delivery driver" width="131" height="37"
                                        border="0" />
                                </td>
                                <td width="109">
                                    <img src="images/checkout_4b.gif" alt="payment method" width="109" height="37" border="0" />
                                </td>
                                <td width="103">
                                    <img src="images/checkout_5b.gif" alt="complete order" width="103" height="37" border="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUser">
                        Please confirm your delivery address below.
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formTextUser" style="padding-left: 10px;">
                        <table cellpadding="3" cellspacing="0" border="0" style="width:100%;">
                            <tr>
                                <td colspan="2" align="left">
                                    Fields with a <span class="star1">*</span> are required
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" nowrap="nowrap" style="padding-left: 200px" colspan="2">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                                    <asp:Label ID="lblMsg" CssClass="formTextUser" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table>
                                        <tr valign="top">
                                            <td align="right">
                                                <span class="star1">*</span>Address:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAddress1" Width="200px" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" Text="*" ControlToValidate="txtAddress1"
                                                    ErrorMessage="Address is required" ForeColor="White"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr valign="top">
                                            <td align="right">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAddress2" Width="200px" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
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
                                                <asp:TextBox ID="txtCity" runat="server" Width="200px" CssClass="textbox1" MaxLength="50"></asp:TextBox>
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
                                                <asp:DropDownList ID="drpState" runat="server" CssClass="DropDown" Width="200px">
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
                                                <asp:DropDownList ID="drpZip" runat="server" CssClass="DropDown" Width="200px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvZip" runat="server" Text="*" ControlToValidate="drpZip"
                                                    ErrorMessage="Select zip code" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" align="left">
                                    <table>
                                        <tr>
                                            <td class="formTextUser">
                                                <strong>Any Special Instructions?<br />
                                                </strong>(e.g. it's the 2nd floor, buzzer doesn't work, etc.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtSpecial" runat="server" CssClass="textMultiline" MaxLength="1000" Width="400px"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="padding-left: 300px;">
                                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="buttonUser" OnClick="btnConfirm_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                        &nbsp;
                    </td>
                </tr>
            </table> 
          </td>
          </tr>          
          </table>          
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

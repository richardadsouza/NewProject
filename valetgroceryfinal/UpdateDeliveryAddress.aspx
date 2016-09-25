﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="UpdateDeliveryAddress.aspx.cs" Inherits="groceryguys.UpdateDeliveryAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td align="left" class="formHeading">
                        <strong>Update Delivery Address </strong>
                    </td>
                </tr>
                <tr>
                    <td height="10px"></td>
                </tr>
                <tr>
                    <td align="left" class="formTextUser">Please use the form below to update your delivery address: 
                    </td>
                </tr>
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td align="left" class="formTextUser" style="padding-left: 10px;">
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td colspan="2" align="left">Field with a <span class="star1">*</span> are required
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left" nowrap="nowrap">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />
                                    <asp:Label ID="lblMsg" CssClass="formTextUser" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td align="right">
                                    <span class="star1">*</span>Address:                           
                                </td>
                                <td style="width:70%;">
                                    <asp:TextBox ID="txtAddress1" Width="200px" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" Text="*" ControlToValidate="txtAddress1"
                                        ErrorMessage="Address  is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
                            </tr>                           
                            <tr valign="top">
                                <td align="right"></td>
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
                                    <asp:TextBox ID="txtCity" Width="200px" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" Text="*" ControlToValidate="txtCity"
                                        ErrorMessage="City is required" ForeColor="White"></asp:RequiredFieldValidator>
                                </td>
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
                                <td></td>
                                <td align="left" style="padding-left: 5px;">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="buttonUser" OnClick="btnUpdate_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

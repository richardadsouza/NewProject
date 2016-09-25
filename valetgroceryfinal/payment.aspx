﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="groceryguys.payment" %>

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
                                <td height="20px"></td>
                            </tr>
                            <tr>
                                <td align="left" class="formHeading">
                                    <strong>Payment Method</strong>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr valign="top">
                                            <td width="135">
                                                <img src="images/checkout_2.gif" alt="confirm delivery address" width="135" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="122">
                                                <img src="images/checkout_1.gif" alt="pick a delivery time" width="122" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="131">
                                                <img src="images/checkout_3.gif" alt="tip the delivery driver" width="131" height="37"
                                                    border="0" />
                                            </td>
                                            <td width="109">
                                                <img src="images/checkout_4c.gif" alt="payment method" width="109" height="37" border="0" />
                                            </td>
                                            <td width="103">
                                                <img src="images/checkout_5b.gif" alt="complete order" width="103" height="37" border="0" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="20px"></td>
                            </tr>
                            <tr>
                                <td class="formTextUser">
                                    <strong>The total for this order is:&nbsp;<asp:Label ID="lblArr" runat="server" Text="$"
                                        CssClass="ErrorTxt1"></asp:Label><asp:Label ID="lblTotal" runat="server" CssClass="ErrorTxt1"></asp:Label></strong>
                                    <asp:Label ID="lblCompTot" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <asp:Panel ID="pnlMin2" runat="server" Visible="false">
                                <tr>
                                    <td class="formTextUser">Please choose your payment method below:
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td class="formTextUser">
                                    <table cellpadding="3" cellspacing="0" style="width: 100%;" border="0">
                                        <asp:Panel ID="pnlMin1" runat="server" Visible="false">
                                            <tr>
                                                <td colspan="2" align="left">Fields with a <span class="star1">*</span> are required
                                                </td>
                                            </tr>
                                        </asp:Panel>
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
                                        <asp:Panel ID="pnlMinOrder" runat="server" Visible="false">
                                            <tr>
                                                <td align="right" style="width: 20%;">
                                                    <span class="star1">*</span>Payment Option:
                                                </td>
                                                <td class="formTextUser">
                                                    <asp:DropDownList ID="drpPayment" runat="server" CssClass="DropDown2" OnSelectedIndexChanged="drpPayment_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvPay" runat="server" Text="*" ControlToValidate="drpPayment"
                                                        ErrorMessage="Select Payment Option" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td height="10px" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="formTextUser" align="left">
                                                <asp:Panel ID="pnlAutoCreditCard" runat="server" Visible="false">
                                                    <table>
                                                        <tr valign="top">
                                                            <td align="right" style="width:27%;">
                                                                <span class="star1">*</span>Billing Address:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAddress1" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" Text="*" ControlToValidate="txtAddress1"
                                                                    ErrorMessage="Billing address  is required" ForeColor="White"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px" colspan="2"></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="right"></td>
                                                            <td>
                                                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px" colspan="2"></td>
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
                                                            <td height="10px" colspan="2"></td>
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
                                                           <td height="10px" colspan="2"></td>
                                                       </tr>
                                                        <tr valign="top">
                                                            <td align="right">
                                                                <span class="star1">*</span>Zip Code:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtZipCode" runat="server" CssClass="textbox1" MaxLength="5"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" Text="*" ControlToValidate="txtZipCode"
                                                                    ErrorMessage="Zip code is required" ForeColor="White"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="reqZip" runat="server" ControlToValidate="txtZipCode"
                                                                    ErrorMessage="Invalid zip code,exactly  five digits allowed" Text="*" ValidationExpression="\d{5}"
                                                                    ForeColor="White"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px" colspan="2"></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="right">
                                                                <span class="star1">*</span>Credit Card Number:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="ttxPayCCNm" runat="server" CssClass="textbox1" MaxLength="16"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="Rfvccc" runat="server" Text="*" ControlToValidate="ttxPayCCNm"
                                                                    ErrorMessage="Credit card number is required" ForeColor="White"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="right"></td>
                                                            <td style="padding-left: 10px;">
                                                                <img src="images/CC1.gif" border="0" />
                                                                <img src="images/CC2.gif" border="0" />
                                                                <img src="images/CC3.gif" border="0" />
                                                                <img src="images/CC4.gif" border="0" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px" colspan="2"></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="right">
                                                                <span class="star1">*</span>Card Type:
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="drpCardType" runat="server" CssClass="DropDown">
                                                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                                                    <asp:ListItem Value="amex">Amex</asp:ListItem>
                                                                    <asp:ListItem Value="Discover">Discover</asp:ListItem>
                                                                    <asp:ListItem Value="MasterCard">Master Card</asp:ListItem>
                                                                    <asp:ListItem Value="Visa">Visa</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvType" runat="server" Text="*" ControlToValidate="drpCardType"
                                                                    ErrorMessage="Select card type" ForeColor="White" InitialValue="Select"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px" colspan="2"></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="right">
                                                                <span class="star1">*</span> Expiration Date:
                                                            </td>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtAutoExpMM" runat="server" MaxLength="2" CssClass="textbox3small"> </asp:TextBox>
                                                                        </td>
                                                                        <td>/
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtAutoExpYY" runat="server" MaxLength="4" CssClass="textbox3small"></asp:TextBox>
                                                                        </td>
                                                                        <td style="padding-left: 5px;">
                                                                            <strong>Format:</strong>&nbsp;MM/YYYY
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px" colspan="2"></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="right">
                                                                <span class="star1">*</span>3-Digit Security Code:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPayCvv" runat="server" CssClass="textbox3small" MaxLength="4"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvCVV" runat="server" Text="*" ControlToValidate="txtPayCvv"
                                                                    ErrorMessage="4-digit security code is required" ForeColor="White"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px" colspan="2"></td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td align="right" colspan="2">
                                                                <asp:CheckBox ID="chkAgree" runat="server" />
                                                                &nbsp; &nbsp;Check here if you would to save this information on file for future
                                                                orders
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10px"></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="left" style="padding-left: 7px;">
                                                <asp:Button ID="btnPay" runat="server" Text="Finalize Order" CssClass="buttonUser"
                                                    OnClick="btnPay_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPayPalUrl" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblPayEmail" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblWebsiteLong" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="updateProgress1" runat="server" DisplayAfter="0" DynamicLayout="true"
        AssociatedUpdatePanelID="updatePnl1">
        <ProgressTemplate>
            <div id="TransparentGrayBackground">
            </div>
            <div id="UpdateProgress" class="padding">
                <asp:Image ID="ajaxLoadNotificationImage1" runat="server" ImageUrl="images/loader.gif"
                    AlternateText="[image]" />
                <span class="UpdateProgressText">Please Wait....</span>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

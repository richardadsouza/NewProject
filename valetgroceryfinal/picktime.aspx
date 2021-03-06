﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserLoginMasterPage.Master" AutoEventWireup="true"
    CodeBehind="picktime.aspx.cs" Inherits="groceryguys.picktime" %>
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
                                    <strong>Pick Your Delivery Time</strong>
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
                                <td height="20px"></td>
                            </tr>
                            <tr>
                                <td class="formTextUser">Please choose a delivery time below from the next upcoming delivery dates:
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td style="padding-left: 50px;">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td style="padding-left: 50px;" valign="top" align="center">
                                    <asp:Panel ID="pnlDeldate" runat="server">
                                        <asp:DataList ID="dtlDeliveryGrid" runat="server" GridLines="None" RepeatDirection="Horizontal"
                                            RepeatColumns="3" ItemStyle-VerticalAlign="Top">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Panel ID="pnlGrid" runat="server">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                                <table border="0" align="center" cellpadding="0" cellspacing="0" class="tableBorderPickTime" width="100%">
                                                                    <tr>
                                                                        <td valign="top" align="left" class="picktimeHeaderText" nowrap="nowrap">
                                                                            <asp:Label ID="lblDeliveryDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DelDate")%>'> </asp:Label>
                                                                            <asp:Label ID="lblDelId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DelId")%>'
                                                                                Visible="false"> </asp:Label>
                                                                            <asp:Label ID="lblDelDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DDate")%>'
                                                                                Visible="false"> </asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="left" class="formTextUser">
                                                                            <asp:RadioButtonList ID="rdChkTime" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdChkTime_SelectedIndexChanged">
                                                                            </asp:RadioButtonList>
                                                                            <asp:Label ID="lblNoTime" runat="server" Visible="false" CssClass="ErrorTxt1"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="padding-left: 10px;"></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:DataList>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td height="10px">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left:44%;">
                                    <asp:Button ID="btnChoose" runat="server" Text="Choose Date/Time" CssClass="buttonUser"
                                        OnClick="btnChoose_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td height="65px">&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

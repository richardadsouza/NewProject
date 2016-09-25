﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UserOrderDeatils.aspx.cs" Inherits="groceryguys.Admin.UserOrderDeatils" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table border="0" cellpadding="3" cellspacing="0" class="table-border ">
            <tr>
                <td style="padding-left: 550px" colspan="2">
                    <a href='UserOrderDeatilsPrint.aspx?orderId=<%=Request.QueryString["orderId"]%>&userId=<%=Request.QueryString["userId"]%>' target="_blank">
                        <img src="../images/printButton.jpg" border="0" />
                    </a>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="formHeadingText">
                    <strong>Order #: </strong>
                    <asp:Label ID="lblOrderNumber" runat="server" CssClass="formText"></asp:Label>
                </td>
            </tr>
            <tr valign="top" class="formText">
                <td width="300">
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td align="right">
                                <strong>Ordered:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblOrederDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="formText" align="right">
                                <strong>Delivery:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblDeliveryDateTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top" align="right">
                            <td>
                                <strong>Payment method:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="300">
                    <strong>Special Order Instructions?</strong><br />
                    <asp:Label ID="lblSpecialOrInfo" runat="server" CssClass="formTextSmall"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>
            <tr class="formHeadingText">
                <td>
                    <strong>Customer Information</strong>
                </td>
                <td>
                    <strong>Delivery Address</strong>
                </td>
            </tr>
            <tr valign="top" class="formText">
                <td width="300">
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td width="120" align="right">
                                <strong>First Name:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblFName" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Last Name:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblLName" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Phone:</strong>
                            </td>
                            <td class="formTextSmall">
                                <asp:Label ID="lblPhone" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>Phone 2:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblPhone2" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="300">
                    <table cellpadding="3" cellspacing="0" border="0">
                        <tr>
                            <td width="120" align="right">
                                <strong>Address:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblAddress" runat="server">
                                </asp:Label>
                                <br />
                                <asp:Label ID="lblAddress2" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <strong>City, State Zip:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                                ,
                                <asp:Label ID="lblState" runat="server"></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblZip" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gridUserProductList" runat="server" AutoGenerateColumns="False"
                        PageSize="5" Width="600" CssClass="gridBorder" CellPadding="0" CellSpacing="0">
                        <Columns>

                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'></asp:Label>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Product">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Price">
                                <ItemTemplate>
                                    <asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                        <HeaderStyle CssClass="gridheading" ForeColor="#404248" />
                        <AlternatingRowStyle CssClass="gridAlternatetext" />
                        <RowStyle CssClass="gridtext" />
                    </asp:GridView>
                    <span style="padding-left: 80px;">
                        <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label></span>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right" class="formText" style="padding-right: 40px;">
                    <table>
                        <tr>
                            <td></td>
                            <td align="right">
                                <strong>Sub Total: </strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <strong>Tax(3%):</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblTax" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <strong>Tax(9%):</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblTax2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <strong>Soda Deposit:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblSodaDeposit" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <strong>Delivery Fee:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblDeliveryFee" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <strong>Tip:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblTips" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">
                                <hr size="-1" color="#000000" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="right">
                                <strong>ORDER TOTAL:</strong>
                            </td>
                            <td align="left" class="formTextSmall">
                                <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

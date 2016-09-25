<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cart.ascx.cs" Inherits="groceryguys.cart" %>

<link rel="stylesheet" href="../CSS/style.css" type="text/css" />
<table cellpadding="0" cellspacing="0" border="0" width="165">
    <tr>
        <td width="165">
            <img src="images/your_cart.gif" alt="your shopping cart" width="165" height="22"
                border="0" />
        </td>
    </tr>
    <tr>
        <td width="165" bgcolor="#e6e6e6">
            <table cellpadding="4" cellspacing="0" border="0">
                <tr>
                    <td>
                        <asp:Panel ID="pnlProduct" runat="server" Visible="false">
                            <table>
                                <tr valign="top">
                                    <td>
                                        <asp:DataList ID="dtlCart" runat="server" RepeatDirection="Vertical">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td width="20" class="formTextSmall1" align="right" valign="top">
                                                            <asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Qty") %>'></asp:Label>
                                                        </td>
                                                        <td width="145" class="formTextSmall1" valign="top">
                                                            <asp:Label ID="lblProductName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProductName") %>'></asp:Label>
                                                        </td>
                                                        <td width="20" class="formTextSmall1" valign="top">
                                                            <asp:Label ID="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Price") %>'
                                                                Visible="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextSmall1" align="right" style="padding-right: 10px;">
                                        <strong>Sub Total:<asp:Label ID="lblTotal" runat="server"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlNoProd" runat="server" Visible="true">
                            <strong class="ErrorTxt1">Your shopping cart is empty.</strong>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <br />
        </td>
    </tr>
    <tr>
        <td width="165" bgcolor="#e6e6e6">
            <a href="Product_Order.aspx">
                <img src="images/edit_cart.gif" alt="edit cart" width="165" height="32" border="0" /></a>
        </td>
    </tr>
    <tr>
        <td width="165" bgcolor="#e6e6e6">
            <a href="Product_Order.aspx">
                <img src="images/checkout.gif" alt="checkout" width="165" height="32" border="0" />
            </a>
        </td>
    </tr>
</table>

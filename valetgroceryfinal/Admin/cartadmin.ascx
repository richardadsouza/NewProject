<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cartadmin.ascx.cs" Inherits="groceryguys.Admin.cartadmin" %>
<%--<link rel="Stylesheet" href="../CSS/UserSide.css" type="text/css" />--%> 
<link rel="stylesheet" href="../CSS/style.css" type="text/css" />
<table cellpadding="0" cellspacing="0" border="0" width="165">
    <tr>
        <td width="165">
            <img src="../images/your_cart.gif" alt="your shopping cart" width="165" height="22"
                border="0" /></td>
    </tr>
    <tr>
        <td width="165" bgcolor="#e6e6e6">
            <table cellpadding="4" cellspacing="0" border="0">
                <tr>
                    <td>
                        <asp:Panel ID="pnlProduct" runat="server">

                            <table>

                                <tr valign="top">
                                    <td>
                                        <asp:DataList ID="dtlShopList" runat="server" RepeatDirection="Vertical">
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td width="20" class="formTextSmall1" align="right" valign="top">
                                                            <asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Qty") %>'></asp:Label>
                                                            <asp:Label ID="lblPrice" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Price") %>' Visible="false"></asp:Label>

                                                        </td>
                                                        <td width="145" class="formTextSmall1" valign="top">
                                                            <asp:Label ID="lblProductNm" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ProdNm") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextSmall1" align="right" style="padding-right: 10px;">
                                        <strong>Sub Total:<asp:Label ID="lblTot" runat="server"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlNoProd" runat="server">
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
            <asp:Button ID="btnDelete" runat="server" CssClass="buttonUser" Text="Delete" OnClick="btnDelete_Click"
                CausesValidation="false" />
        </td>
    </tr>
    <tr>
        <td width="165" bgcolor="#e6e6e6">
            <a href="../admin/viewpremadelist.aspx">
                <img src="../images/checkout.gif" alt="checkout" width="165" height="32" border="0" />
            </a>
        </td>
    </tr>
</table>




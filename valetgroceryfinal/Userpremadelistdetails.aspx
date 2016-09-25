﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Userpremadelistdetails.aspx.cs" Inherits="groceryguys.Userpremadelistdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="formHeading" style="padding-left: 10px;">
                <asp:Label ID="lblListNm" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;">
                <asp:GridView ID="gridShopList" runat="server" AutoGenerateColumns="False" Width="530px"
                    GridLines="None" CellPadding="0" CellSpacing="0" AllowPaging="true" PageSize="17"
                    OnPageIndexChanging="gridShopList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image"
                            HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Image ID="imgShopProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Height="45px" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name" SortExpression="product_title" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>                                
                                <asp:Label ID="lblShopPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblShopQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                    <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                    <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                    <RowStyle CssClass="gridUsertext" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" align="right" style="padding-right: 5px;">
                <table class="formTextUser">
                    <tr>
                        <td style="padding-left: 2px;" align="right">
                            <strong>
                                <asp:Label ID="lblSubTot" runat="server" Text="Sub Total:"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblSubTotVal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblTax" runat="server" Text="Tax(3%)"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign1" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblTaxVal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="Label1" runat="server" Text="Tax(9%)"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="Label2" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblTaxVal2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblDeliveryFee" runat="server" Text="Delivery Fee"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign2" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblDeliveryFeeTot" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblSodaFee" runat="server" Text="Soda Deposit"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSodaSign" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblSodaDepFeeTot" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span class="horizontalLine1"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <strong>
                                <asp:Label ID="lblTot" runat="server" Text="Total"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 2px;">
                            <asp:Label ID="lblSign3" runat="server" Text="$"></asp:Label>
                            <asp:Label ID="lblTotVal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add All Items" CssClass="button" OnClick="btnAdd_Click" />
                <asp:Button ID="btnAdd2" runat="server" Text="Do Not Add All Items" CssClass="button" OnClick="btnAdd2_Click" />
            </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
    </table>
</asp:Content>

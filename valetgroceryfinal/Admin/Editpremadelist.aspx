﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Editpremadelist.aspx.cs" Inherits="groceryguys.Admin.Editpremadelist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../CSS/UserSide.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
     <script language="javascript" type="text/javascript">
         function confirmsubmit() {
             if (confirm("You are about to delete the data, please confirm?") == true) {
                 return true;
             }
             else {
                 return false;
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("sitefunctions");</script>
    <script type="text/javascript">
        var Image2 = document.getElementById("Image2");
        var Image3 = document.getElementById("Image3");
        var Image4 = document.getElementById("Image4");
        var Image5 = document.getElementById("Image5");
        var Image6 = document.getElementById("Image6");

        Image2.src = "images/tab1.png";
        Image3.src = "images/tab2.png";
        Image4.src = "images/tab3.png";
        Image5.src = "images/tab4.png";
        Image6.src = "images/tab5-h.png";
    </script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table border="0" cellspacing="0" cellpadding="0" style="width:100%;">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formHeading" style="padding-left: 10px;">
                        <asp:Label ID="lblHead" runat="server" Text="Edit Pre-Made List"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px;" width="100%">
                        <asp:Label ID="lblCartEmpty" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                        <asp:Panel ID="pnlCart" Width="100%" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td align="left">
                                        <asp:GridView ID="gridShopList" runat="server" AutoGenerateColumns="False" Width="100%"
                                            GridLines="None" CellPadding="0" CellSpacing="0" HeaderStyle-CssClass="" OnRowCommand="gridShopList_OnRowCommand">
                                            <Columns>
                                                <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShopProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                                                        <asp:Label ID="lblProductImage2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_image2")%>'></asp:Label>
                                                        <asp:Label ID="lblProdDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_description")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Image" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'>
                                                            <asp:Image ID="imgShopProduct2" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product" SortExpression="product_title" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShopTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShopSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>                                                        
                                                        <asp:Label ID="lblShopPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("productlink_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Panel ID="pnlShopQtyErr" runat="server" Visible="false">
                                                            <asp:Label ID="lblErrQty" runat="server" CssClass="ErrorTxtNew1" Visible="false"> </asp:Label><br />
                                                        </asp:Panel>
                                                        <asp:TextBox ID="txtShopQty" runat="server" CssClass="textboxSmallNew" Text='<%# DataBinder.Eval(Container.DataItem, "Qty")%>'
                                                            MaxLength="3"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="../images/gtk-edit.png"
                                                            Width="18" Height="18" border="0" CommandName="UpdateProduct" CommandArgument='<%#Eval("product_id")%>'
                                                            CausesValidation="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../images/delete.png" Width="18" Height="18" border="0" CommandName="DeleteProduct" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "product_id")%>' OnClientClick="return confirmsubmit();" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                                            <HeaderStyle CssClass="gridUserheading" ForeColor="White" />
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
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

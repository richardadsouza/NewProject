<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProductdDetails.aspx.cs" Inherits="groceryguys.Admin.ViewProductdDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Logoutlink">&nbsp;</td>
        </tr>
        <tr>
            <td class="Logoutlink">Product Administration 
            </td>
        </tr>
        <tr>
            <td align="right" style="width:100%">
                <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 50px;">
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 50px;">
                <span style="color: Red; font-size:14px;">
                    <img src="../images/red_square.gif" width="10" height="10" border="0" />&nbsp;&nbsp;Denotes that Product is Hidden.</span>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" class="formText">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%">
                            <asp:UpdatePanel ID="update1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gridProductList" runat="server" AutoGenerateColumns="False" Width="100%"
                                        AllowPaging="true" OnPageIndexChanging="gridProductList_PageIndexChanging" OnRowDataBound="gridProductList_RowDataBound"
                                        CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridProductList_Sorting" OnRowCommand="gridProductList_OnRowCommand">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAsileId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHide" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_hide")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShelfId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Image" ItemStyle-Height="45px" ItemStyle-VerticalAlign="Middle">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Title" SortExpression="product_title">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price($)">
                                                <ItemTemplate>                                                    
                                                    <asp:TextBox ID="txtPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_price")%>' Width="50px"></asp:TextBox>
                                                    <asp:Label ID="lblPrice1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_price")%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Per Sale($)">
                                                <ItemTemplate>                                                    
                                                    <asp:TextBox ID="txtPerSale" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_presale")%>' Width="50px"></asp:TextBox>
                                                    <asp:Label ID="lblPerSale1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_presale")%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Buy Price($)">
                                                <ItemTemplate>                                                   
                                                    <asp:TextBox ID="txtBuyPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_buyprice")%>' Width="50px"></asp:TextBox>
                                                    <asp:Label ID="lblBuyPrice1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "productlink_buyprice")%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product Image">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProductImage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_image")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>                                                   
                                                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="../images/gtk-edit.png"
                                                        Width="18" Height="18" border="0" CommandName="UpdatePrice" CommandArgument='<%# Eval("product_id") %>'
                                                        CausesValidation="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>                                            
                                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href='EditProduct.aspx?productId=<%# DataBinder.Eval(Container.DataItem, "product_id")%>&shf=<%# DataBinder.Eval(Container.DataItem, "shelf_id")%>&asileId=<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>&loc=<%=Request.QueryString["loc"]%>&shefId=<%=Request.QueryString["shefId"]%>&strKey=<%=Request.QueryString["strKey"] %>&perPage=<%=Request.QueryString["perPage"]%>'>
                                                        <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../images/delete.png" Width="18" Height="18" border="0" CommandName="DeleteProduct" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "product_id")%>' OnClientClick="return confirmsubmit();" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                                        <HeaderStyle CssClass="gridheading" ForeColor="#404248" />
                                        <AlternatingRowStyle CssClass="gridAlternatetext" />
                                        <RowStyle CssClass="gridtext" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="15px"></td>
        </tr>
        <tr>
            <td align="right" style="width:100%;">

                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Content>

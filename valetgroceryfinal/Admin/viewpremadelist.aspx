<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="viewpremadelist.aspx.cs" Inherits="groceryguys.Admin.viewpremadelist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../CSS/UserSide.css" rel="stylesheet" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formHeading" style="padding-left: 10px;">
                        <asp:Label ID="lblHead" runat="server" Text="Your Shopping Cart"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px;">
                        <asp:Label ID="lblCartEmpty" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                        <asp:Panel ID="pnlCart" runat="server">
                            <table>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:GridView ID="gridShopList" runat="server" AutoGenerateColumns="False" Width="600px"
                                            GridLines="None" CellPadding="0" CellSpacing="0" HeaderStyle-CssClass="">
                                            <Columns>
                                                <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblShopProductId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>'></asp:Label>
                                                        <asp:Label ID="lblProductImage2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_image2")%>'></asp:Label>
                                                        <asp:Label ID="lblProdDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_description")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkId" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Image" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'>
                                                            <asp:Image ID="imgShopProduct2" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"product_image").ToString()) %>' />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product" SortExpression="product_title" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="#" onclick='openProductDetailsPopUp(<%# DataBinder.Eval(Container.DataItem, "product_id")%>)'
                                                            class="ProdLink1">
                                                            <asp:Label ID="lblShopTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                        </a>
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
                                    <td colspan="2">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="buttonUser" Text="Update" OnClick="btnUpdate_Click"
                                                        CausesValidation="false" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="buttonUser" Text="Delete" OnClick="btnDelete_Click"
                                                        CausesValidation="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td nowrap="nowrap" valign="top">
                                                    <strong><span class="star1">*</span>List Name:</strong>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtListNm" runat="server" CssClass="textbox1"></asp:TextBox><asp:RequiredFieldValidator ID="rfvFName" runat="server" Text="*" ControlToValidate="txtListNm"
                                                        ErrorMessage="List name is required" ForeColor="White"></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td style="padding-left: 10px;" valign="top">
                                                    <asp:Label ID="lblExample" runat="server" Text="Ex:My Lunch List" CssClass="ErrorTxt1"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save List" CssClass="buttonUser" OnClick="btnSave_Click" />
                                                </td>
                                            </tr>
                                        </table>
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

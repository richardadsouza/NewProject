<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="products.aspx.cs" Inherits="groceryguys.products" %>

<%@ Register Src="~/cart.ascx" TagName="UserScript" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script language="javascript" type="text/javascript">
        function alertError() {
            alert("Please make sure your quantity is a number.");
        }
    </script>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
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
                    <td class="formTextUser" style="padding-left: 10px;">
                        <a href="Shop.aspx" class="Userlink_aisle">All Aisles</a>&nbsp;
                        <asp:Label ID="lblArrow" runat="server" Text=">"></asp:Label>&nbsp;
                         <a href='shelf.aspx?aisle=<%=Request.QueryString["aisletop"] %>' class="Userlink_aisle">
                             <asp:Label ID="lblAisleName" runat="server"></asp:Label></a>&nbsp;
                        <asp:Label ID="lblArrow1" runat="server" Text=">"></asp:Label>&nbsp;
                        <asp:Label ID="lblShelfName" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formHeading" style="padding-bottom: 10px;">
                        <asp:Label ID="lblShelfName1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 50px;">
                        <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser" width="100%" valign="top">
                        <table>
                            <tr>
                                <td valign="top" width="90%">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td valign="top">
                                                <asp:Panel ID="pnlPopularProduct" runat="server" Width="100%">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td class="formTextUser">
                                                                <strong>Most Popular Items List</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataList runat="server" ID="dltPopularProduct" BackColor="Transparent" RepeatColumns="4" OnItemCommand="dltPopularProduct_ItemCommand">
                                                                    <ItemTemplate>
                                                                        <table class="gridUsertext" style="height: 200px;">
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <a href="#" onclick='openProductDetailPopUp(<%#DataBinder.Eval(Container.DataItem, "ProductID") %>)'>
                                                                                        <asp:Image Width="50" Height="50" runat="server" ID="imgImage" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem, "Image").ToString()) %>' />
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <a href="#" onclick='openProductDetailPopUp(<%#DataBinder.Eval(Container.DataItem, "ProductID") %>)'>
                                                                                        <asp:Label runat="server" ID="lblPopularName" Text='<%#DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <asp:Label runat="server" ID="lblPopularSize" Text='<%#DataBinder.Eval(Container.DataItem, "Size") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <asp:Label runat="server" Font-Bold="true" ID="lblPopularBeforeSalePrice" Text='<%#DataBinder.Eval(Container.DataItem, "BeforeSalePrice") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <asp:Label runat="server" Font-Bold="true" ID="lblPopularPrice" Text='<%#DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center; padding-bottom: 10px;">
                                                                                    <asp:TextBox runat="server" ID="txtPopularQty" CssClass="textboxSmallNew">1</asp:TextBox>
                                                                                    <asp:ImageButton runat="server" ID="imgPopularAdd" ImageUrl="images/AddIcon.png" Height="16" border="0" CommandName="AddPopularQty"
                                                                                        CommandArgument='<%#Eval("ProductID") %>' CausesValidation="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="10px"></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlAllProduct" runat="server" Width="100%">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td class="formTextUser" style="margin-top: 20px;">
                                                                <strong>All Items List</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DataList runat="server" ID="dltAllItems" RepeatColumns="4" OnItemCommand="dltAllItems_ItemCommand">
                                                                    <ItemTemplate>
                                                                        <table class="gridUsertext" style="height: 150px; width: 200px; margin-top: 10px;">
                                                                            <tr>
                                                                                <td style="text-align: center; height: 50px;">
                                                                                    <a href="#" style="max-height: 50px;" onclick='openProductDetailPopUp(<%#DataBinder.Eval(Container.DataItem, "ProductID") %>)' style="text-align: center;">
                                                                                        <asp:Image runat="server" ID="imgImage" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem, "Image").ToString()) %>' />
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center; padding-top: 10px; padding-left: 10px; padding-right: 10px; height: 75px; vertical-align: top;">
                                                                                    <a href="#" onclick='openProductDetailPopUp(<%#DataBinder.Eval(Container.DataItem, "ProductID") %>)'>
                                                                                        <asp:Label runat="server" ID="lblName" Text='<%#DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                                                                                        <asp:HiddenField runat="server" ID="hdnProductID" Value='<%#DataBinder.Eval(Container.DataItem, "ProductID") %>' />
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <asp:Label runat="server" ID="lblSize" Text='<%#DataBinder.Eval(Container.DataItem, "Size") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <asp:Label runat="server" ID="lblBeforeSalePrice" Font-Bold="true" Text='<%#DataBinder.Eval(Container.DataItem, "BeforeSalePrice") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center;">
                                                                                    <asp:Label runat="server" Font-Bold="true" ID="lblPrice" Text='<%#DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align: center; padding-bottom: 20px;">
                                                                                    <asp:Panel ID="pnlQtyErr" runat="server" Visible="false">
                                                                                        <asp:Label ID="lblErrQty" runat="server" CssClass="ErrorTxtNew1">Enter only numbers</asp:Label><br />
                                                                                    </asp:Panel>
                                                                                    <asp:TextBox runat="server" ID="txtQty" CssClass="textboxSmallNew">1</asp:TextBox>
                                                                                    <asp:ImageButton runat="server" ID="imgAdd" ImageUrl="images/AddIcon.png" Height="16" border="0" CommandName="AddQty"
                                                                                        CommandArgument='<%#Eval("ProductID") %>' CausesValidation="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlMessage" runat="server" Visible="false">
                                                    <div style="color: red; font-size: 16px;">
                                                        No products found.
                                                    </div>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10px"></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 15px;">
                                                <asp:Button ID="btnContinue" runat="server" CssClass="buttonUser" Text="Continue Shopping" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" align="left" style="padding-left: 2px; padding-top: 20px;" width="20%">
                                    <uc1:UserScript ID="UserScript1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

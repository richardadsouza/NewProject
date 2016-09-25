<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingListPrint.aspx.cs"
    Inherits="groceryguys.Admin.ShoppingListPrint" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping List Print</title>   
<style type="text/css">
    #printable { display: none; }
    @media print
    {
    	#non-printable { display: none; }
    	#printable { display: block; }
    }
    </style>
 <%--<link rel="Stylesheet" href="../CSS/general.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
   <script type="text/javascript" >
       function tablePrint(body) {
           return false;
       }   
   </script> 
</head> 
<body onload="javascript:self.print();" style="background-image:none; background-color:white;">
    <form id="form1" runat="server">
        <br />
        <strong class="printformTextSmall">Shopping List for&nbsp;
        <asp:Label ID="lblDate" runat="server"></asp:Label>&nbsp;
        at&nbsp;
        <asp:Label ID="lblLocation" runat="server"></asp:Label>
        </strong>
        <br />
        <br />
        <table cellpadding="3" cellspacing="0" border="0">
            <tr valign="top">
                <td width="100" class="formText">
                    <strong>Start Time:</strong>
                </td>
                <td width="300" class="formText">_____________________
                </td>
            </tr>
            <tr valign="top">
                <td class="formText">
                    <strong>End Time:</strong>
                </td>
                <td class="formText">_____________________
                </td>
            </tr>
        </table>
        <br />

        <div id="non-printable">
            <table>
                <tr>
                    <td>
                        <asp:ScriptManager runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gridShoppingList" runat="server" AutoGenerateColumns="False" Width="600px"
                                    PageSize="20" CellPadding="0" CellSpacing="0" GridLines="None" AllowPaging="true" OnPageIndexChanging="gridShoppingList_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkShop" runat="server" Width="20px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Aisle" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStore" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_position")%>'
                                                    Width="40px"> </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty" SortExpression="orderproduct_quantity" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuentity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'
                                                    Width="20px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'
                                                    Width="200px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShelfName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_name")%>'
                                                    Width="120px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Size" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'
                                                    Width="75px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price($)" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem, "orderproduct_price"))%>'
                                                    Width="50px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="printpadding">
                                            <ItemTemplate>
                                                ______
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="gridheadingNewprint" ForeColor="#404248" />
                                    <AlternatingRowStyle CssClass="gridAlternatetextPrint" />
                                    <RowStyle CssClass="gridtextPrint" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 440px;">
                        <table>
                            <tr>
                                <td class="formText">
                                    <strong>
                                        <asp:Label ID="lblTotalText" runat="server" Text="TOTAL:"></asp:Label>
                                    </strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblAmount" runat="server" CssClass="formTextSmall"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>

        <div id="printable">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GVPrint" runat="server" AutoGenerateColumns="False" Width="600px"
                            PageSize="20" CellPadding="0" CellSpacing="0" GridLines="None" AllowPaging="false">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkShop" runat="server" Width="20px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aisle" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStore" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_position")%>'
                                            Width="40px"> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty" SortExpression="orderproduct_quantity" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuentity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'
                                            Width="20px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'
                                            Width="200px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShelfName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shelf_name")%>'
                                            Width="120px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Size" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'
                                            Width="75px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price($)" ItemStyle-VerticalAlign="Top" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# String.Format("{0:0.00}",DataBinder.Eval(Container.DataItem, "productlink_buyprice"))%>'
                                            Width="50px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="printpadding">
                                    <ItemTemplate>
                                        ______
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="gridheadingNewprint" ForeColor="#404248" />
                            <AlternatingRowStyle CssClass="gridAlternatetextPrint" />
                            <RowStyle CssClass="gridtextPrint" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 440px;">
                        <table>
                            <tr>
                                <td class="formText">
                                    <strong>TOTAL: 
                                    </strong>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalPrint" runat="server" CssClass="formTextSmall"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

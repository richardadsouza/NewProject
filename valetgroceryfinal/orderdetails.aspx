<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="orderdetails.aspx.cs" Inherits="groceryguys.orderdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td align="right" class="formHeading">
                        <strong>Order Details</strong>
                        <span style="padding-left:95%;">
                            <asp:ImageButton ID="imgBtn" runat="server" ImageUrl="images/back.gif"
                                OnClick="imgBtn_Click" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td height="20px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px;">
                        <table border="0" width="100%" cellpadding="3" cellspacing="0" class="tableBorder">
                            <tr>
                                <td colspan="2" class="formHeadingText">
                                    <strong>Order #: </strong>
                                    <asp:Label ID="lblOrderNumber" runat="server" CssClass="formHeadingText" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top" class="formTextUser">
                                <td width="300">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr>
                                            <td align="right">
                                                <strong>Ordered:</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblOrederDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Delivery:</strong>
                                            </td>
                                            <td align="left" class="formTextUser"  style="padding-left:5px;">
                                                <asp:Label ID="lblDeliveryDateTime" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr valign="top" align="right">
                                            <td>
                                                <strong>Payment method:</strong>
                                            </td>
                                            <td align="left" class="formTextUser"  style="padding-left:5px;">
                                                <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label>                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="300">
                                    <strong>Special Order Instructions? </strong><br />
                                    <asp:Label ID="lblSpecialOrInfo" runat="server" CssClass="formTextUser"></asp:Label>
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
                            <tr valign="top" class="formTextUser">
                                <td width="300">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr>
                                            <td width="120" align="right">
                                                <strong>First Name:</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblFName" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Last Name:</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblLName" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Phone:</strong>
                                            </td>
                                            <td class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblPhone" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <strong>Phone 2:</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblPhone2" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="300">
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr>
                                            <td width="120" align="right" valign="top">
                                                <strong>Address:</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblAddress" runat="server">
                                                </asp:Label>
                                                <br />
                                                <asp:Label ID="lblAddress2" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <strong>City, State Zip:</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
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
                                <td>
                                    <asp:Label ID="lbErrlMsg" runat="server" CssClass="ErrorTxt1"></asp:Label>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gridUserProductList" runat="server" AutoGenerateColumns="False"
                                        PageSize="5" Width="100%" CellPadding="0" CellSpacing="0"
                                        GridLines="None">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkProd" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProdId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_id")%>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Size" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price($)" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>                                                    
                                                    <asp:Label ID="lblProductPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("orderproduct_price")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                                        <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                                        <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                        <RowStyle CssClass="gridUsertext" />
                                    </asp:GridView>
                                    <span style="padding-left: 80px;">
                                        <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label></span>
                                </td>
                            </tr>
                            <tr>
                                <td height="1px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnProd" runat="server" CssClass="buttonUser"
                                                    Text="Add Checked Items to Cart" OnClick="btnProd_Click" />
                                            </td>
                                            <td style="padding-left: 15px">
                                                <asp:Button ID="btnCheckAll" runat="server" CssClass="buttonUser"
                                                    Text="Check All" OnClick="btnCheckAll_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="1px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right" style="padding-right: 40px;">
                                    <table class="formTextUser">
                                        <tr>
                                            <td></td>
                                            <td align="right">
                                                <strong>Sub Total($): </strong>
                                            </td>
                                            <td align="left" style="padding-left:5px;">
                                                <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="right">
                                                <strong>Tax(3%):</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblTax" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="right">
                                                <strong>Tax(%9):</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblTax1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="right">
                                                <strong>Soda Deposit($):</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblSodaDeposit" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="right">
                                                <strong>Delivery Fee($):</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblDeliveryFee" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="right">
                                                <strong>Tip($):</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
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
                                                <strong>ORDER TOTAL($):</strong>
                                            </td>
                                            <td align="left" class="formTextUser" style="padding-left:5px;">
                                                <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="20px">&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

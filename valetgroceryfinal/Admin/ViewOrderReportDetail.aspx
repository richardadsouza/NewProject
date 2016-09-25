<%@ Page Title="Order Report List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="ViewOrderReportDetail.aspx.cs" Inherits="groceryguys.Admin.ViewOrderReportDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            display: block;
            height: 17px;
            width: 700px;
            border-bottom: dotted 1px #666666;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("reports");</script>
    <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="Logoutlink">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">Order Report
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 0%;">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="formText">
                <strong>
                    <asp:Label ID="lblStartDate" runat="server"></asp:Label>&nbsp;up to&nbsp;
                    <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                </strong>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 200px;">
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="formText">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%">
                            <asp:UpdatePanel ID="update1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gridSearchOrders" runat="server" AllowPaging="true" AllowSorting="True"
                                        AutoGenerateColumns="False" CellPadding="0" CellSpacing="0" CssClass="gridBorder"
                                        OnPageIndexChanging="gridSearchOrders_PageIndexChanging" OnSorting="gridSearchOrders_Sorting"
                                        PageSize="10" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Date" SortExpression="ordDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ordDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer" SortExpression="customer">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustomer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "customer")%>'></asp:Label></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAisleShow" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "location_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Groceries($)">
                                                <ItemTemplate>                                                   
                                                    <asp:Label ID="lblGroceries" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_grocerytotal")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tip($)">
                                                <ItemTemplate>                                                    
                                                    <asp:Label ID="lblTip" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_tip")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax(3%)">
                                                <ItemTemplate>                                                    
                                                    <asp:Label ID="lblTax" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_tax")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax(9%)">
                                                <ItemTemplate>                                                    
                                                    <asp:Label ID="lblTax2" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_tax2")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delivery($)">
                                                <ItemTemplate>                                                   
                                                    <asp:Label ID="lblDelivery" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_deliveryfee")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total($)">
                                                <ItemTemplate>                                                    
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_totalfinal")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Shopping Funds Amount($)" ItemStyle-Width="50px">
                                                <ItemTemplate>                                                    
                                                    <asp:Label ID="lblTransationamt" Width="50px" runat="server" Text='<%# (String.IsNullOrEmpty(Eval("transactions_amount").ToString()) ? " " :Convert.ToDecimal(Eval("transactions_amount")).ToString("0.00")) %>'></asp:Label>
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
                    <tr>
                        <td height="3px"></td>
                    </tr>
                    <tr>
                        <td class="horizontalLineNew"></td>
                    </tr>
                    <tr>
                        <td width="100%" class="gridtext">
                            <table width="100%">
                                <tr>
                                    <td width="350px">&nbsp;
                                    </td>
                                    <td width="100px" align="center">
                                        <asp:Label ID="lblTotGrocery" runat="server"></asp:Label>
                                    </td>
                                    <td width="60px" align="center">
                                        <asp:Label ID="lblTotTip" runat="server"></asp:Label>
                                    </td>
                                    <td width="50px">
                                        <asp:Label ID="lblTotTax" runat="server"></asp:Label>
                                    </td>
                                    <td width="50px">
                                        <asp:Label ID="lblTotTax2" runat="server"></asp:Label>
                                    </td>
                                    <td width="80px">
                                        <asp:Label ID="lblTotDelivery" runat="server"></asp:Label>
                                    </td>
                                    <td width="70px">
                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                    </td>
                                    <td width="70px">
                                        <asp:Label ID="lblShoppingFund" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 0%;">
                <asp:Button ID="btnExcel" runat="server" Text="Convert To Excel" CssClass="button" OnClick="btnExcel_Click" />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewTaxReportDetail.aspx.cs" Inherits="groceryguys.Admin.ViewTaxReportDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
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
            <td class="Logoutlink">Tax Report
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
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
                <table width="721" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="721">
                            <asp:UpdatePanel ID="update1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gridSearchOrders" runat="server" AllowPaging="true" AllowSorting="True"
                                        AutoGenerateColumns="False" CellPadding="0" CellSpacing="0" CssClass="gridBorder"
                                        OnPageIndexChanging="gridSearchOrders_PageIndexChanging" OnSorting="gridSearchOrders_Sorting"
                                        PageSize="10" Width="850px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Order ID" SortExpression="ordDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" SortExpression="ordDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ordDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Food Tax" SortExpression="tax_food">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustomer" runat="server" Text='<%# Convert.ToDecimal(Eval("tax_food")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Non Food Tax" SortExpression="tax_nonfood">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAisleShow" runat="server" Text='<%# Convert.ToDecimal(Eval("tax_nonfood")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Food Tax($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGroceries" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_tax")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Non Food Tax($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTip" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_GroceriesTax")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Tax($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTax" runat="server" Text='<%# Convert.ToDecimal(Eval("total_tax")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Food($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDelivery" runat="server" Text='<%# Convert.ToDecimal(Eval("totfood")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Non Food($)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Convert.ToDecimal(Eval("totnonfood")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
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
                        <td width="700" class="gridtext">
                            <table border="0">
                                <tr>
                                    <td width="290px">&nbsp;
                                    </td>
                                    <td width="100px" align="center">
                                        <asp:Label ID="lblTotorders_tax" runat="server"></asp:Label>
                                    </td>
                                    <td width="150px" align="center">
                                        <asp:Label ID="lblTotTip" runat="server"></asp:Label>
                                    </td>
                                    <td width="80px">
                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                    </td>
                                    <td width="85px">
                                        <asp:Label ID="lblTotTax" runat="server"></asp:Label>
                                    </td>
                                    <td width="115px">
                                        <asp:Label ID="lblTotDelivery" runat="server"></asp:Label>
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
            <td align="right" style="padding-right: 200px;">                
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
    </table>
</asp:Content>
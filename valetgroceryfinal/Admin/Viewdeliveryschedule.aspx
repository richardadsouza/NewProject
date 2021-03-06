﻿<%@ Page Title="Delivery Schedules List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Viewdeliveryschedule.aspx.cs" Inherits="groceryguys.Admin.Viewdeliveryschedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function confirmsubmit() {
            if (confirm("You are about to update the data, please confirm?") == true) {
                return true;
            }
            else {
                return false;
            }
        }
        function formatcurrency(strValue) {
            strValue = strValue.toString().replace(/\$|\,/g, '');
            dblValue = parseFloat(strValue);

            blnSign = (dblValue == (dblValue = Math.abs(dblValue)));
            dblValue = Math.floor(dblValue * 100 + 0.50000000001);
            intCents = dblValue % 100;
            strCents = intCents.toString();
            dblValue = Math.floor(dblValue / 100).toString();
            if (intCents < 10)
                strCents = "0" + strCents;
            for (var i = 0; i < Math.floor((dblValue.length - (1 + i)) / 3) ; i++)
                dblValue = dblValue.substring(0, dblValue.length - (4 * i + 3)) + ',' +
		dblValue.substring(dblValue.length - (4 * i + 3));
            return (((blnSign) ? '' : '-') + dblValue + '.' + strCents);           
        }
    </script>
    <style type="text/css">
        .style2 {
            width: 220px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("sitefunctions");</script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-left: 20px;">
        <tr>
            <td class="Logoutlink">&nbsp;
            </td>
        </tr>
        <tr>
            <td class="Logoutlink">Delivery Schedules
            </td>
        </tr>
        <tr>
            <td align="right">
                <table>
                    <tr>
                        <td>                           
                            <asp:ImageButton ID="imgBtnPrint" runat="server" ImageUrl="../images/printButton.jpg"
                                border="0" CausesValidation="false" OnClick="imgBtnPrint_Click" />
                        </td>
                        <td align="right" style="padding-right: 200px;">
                            <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                                Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td class="formText">
                <strong>Viewing all deliveries for &nbsp;<asp:Label ID="lblDate" runat="server"></asp:Label>
                </strong>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 100px;">
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="formText">
                <table width="850" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="850">
                            <asp:UpdatePanel ID="update1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gridDeliveryList" runat="server" AutoGenerateColumns="False" Width="850px"
                                        AllowPaging="true" PageSize="25" OnPageIndexChanging="gridDeliveryList_PageIndexChanging"
                                        CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridDeliveryList_Sorting"
                                        OnRowCommand="gridDeliveryList_OnRowCommand">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                                                    <asp:Label ID="lblPayType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_paymenttype")%>'></asp:Label>
                                                    <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order #" SortExpression="orders_number" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderNum" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer" SortExpression="customer">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustomer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "customer")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Time" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliverytime")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                           
                                            <asp:TemplateField HeaderText="Groceries($)" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtGroceries" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_grocerytotal")%>'
                                                        CssClass="textBoxGridSmall" OnTextChanged="textBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delivery($)" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDelivery" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_deliveryfee")%>'
                                                        CssClass="textBoxGridSmall" OnTextChanged="textBox1_TextChanged" AutoPostBack="true"></asp:TextBox>                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax1($)" HeaderStyle-Width="60px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTax1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_tax")%>'
                                                        CssClass="textBoxGridSmall" OnTextChanged="textBox1_TextChanged" AutoPostBack="true"></asp:TextBox>                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax2($)" HeaderStyle-Width="60px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTax2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_tax2")%>'
                                                        CssClass="textBoxGridSmall" OnTextChanged="textBox1_TextChanged" AutoPostBack="true"></asp:TextBox>                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tip($)" HeaderStyle-Width="60px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_tip")%>'
                                                        CssClass="textBoxGridSmall" OnTextChanged="textBox1_TextChanged" AutoPostBack="true"></asp:TextBox>                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total($)" HeaderStyle-Width="60px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_totalfinal")%>'
                                                        CssClass="textBoxGridSmall"></asp:TextBox>
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_totalfinal")%>'
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Charges($)" HeaderStyle-Width="60px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCharges" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_complimentary")%>'
                                                        CssClass="textBoxGridSmall"></asp:TextBox>
                                                    <asp:Label ID="lblCharges" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_complimentary")%>'
                                                        Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>                                                    
                                                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="../images/gtk-edit.png"
                                                        Width="18" Height="18" border="0" CommandName="UpdateDelievry" CommandArgument='<%# Eval("orders_id") %>'
                                                        CausesValidation="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Details" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="#" onclick='openOrderDetailPopUp(<%# DataBinder.Eval(Container.DataItem, "orders_id")%>,<%# DataBinder.Eval(Container.DataItem, "users_id")%>)'>
                                                        <img src="../images/view-icon.jpg" width="18" height="18" border="0" />
                                                    </a>
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
            <td align="right">
                <table>
                    <tr>
                        <td style="padding-right: 200px;">
                            <table>
                                <tr>
                                    <td class="style2">                                        
                                        <asp:Button ID="btnViewShopping" runat="server" Text="View Shopping List" CssClass="button"
                                            CausesValidation="false" OnClick="btnViewShopping_Click" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgBtnPrintAll" runat="server" ImageUrl="../images/Print-Btn.gif"
                                            border="0" CausesValidation="false" OnClick="imgBtnPrintAll_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" style="padding-right: 200px;">
                            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                                Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

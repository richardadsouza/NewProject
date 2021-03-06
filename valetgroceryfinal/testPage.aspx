﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testPage.aspx.cs" Inherits="groceryguys.testPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="griduserList" runat="server" AutoGenerateColumns="False" Width="700px"
                                        AllowPaging="true"   
                                        CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True"  >
                                        <Columns>
                                            <asp:TemplateField  >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Last Name" SortExpression="users_lname">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Pass")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                        </Columns>
                                        <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                                        <HeaderStyle CssClass="gridheading" ForeColor="#404248" />
                                        <AlternatingRowStyle CssClass="gridAlternatetext" />
                                        <RowStyle CssClass="gridtext" />
                                    </asp:GridView>
    </div>
    </form>
</body>
</html>

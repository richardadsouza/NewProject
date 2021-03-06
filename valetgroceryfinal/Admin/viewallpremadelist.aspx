﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="viewallpremadelist.aspx.cs" Inherits="groceryguys.Admin.viewallpremadelist" %>
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
            <td class="Logoutlink">Pre-Made List Administration 
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
            <td align="left" class="formText">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%">
                            <asp:UpdatePanel ID="update1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gridProductList" runat="server" AutoGenerateColumns="False" Width="80%"
                                        AllowPaging="true" OnPageIndexChanging="gridProductList_PageIndexChanging"
                                        CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridProductList_Sorting" OnRowCommand="gridProductList_OnRowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Pre-made List" SortExpression="product_title">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "list_name")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href='Editpremadelist.aspx?listid=<%# DataBinder.Eval(Container.DataItem, "list_id")%>'>
                                                        <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../images/delete.png" Width="18" Height="18" border="0" CommandName="DeleteProduct" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "list_id")%>' OnClientClick="return confirmsubmit();" />
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
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" OnClick="btnAdd_Click"
                    CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Content>

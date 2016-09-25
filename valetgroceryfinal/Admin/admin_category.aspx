<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_category.aspx.cs" ValidateRequest="false" Inherits="groceryguys.Admin.admin_category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function confirmsubmit() {
            if (confirm("You are about to delete the Aisle, please confirm?") == true) {
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
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="update1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Logoutlink">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="Logoutlink">Aisles Administration
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt" Visible="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="formText">
                        <table width="721" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="721">
                                    <asp:GridView ID="gridAislesList" runat="server" AutoGenerateColumns="False" Width="600px"
                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gridAislesList_PageIndexChanging"
                                        OnRowCommand="gridAislesList_OnRowCommand" CssClass="gridBorder" CellPadding="0"
                                        CellSpacing="0" AllowSorting="True" OnSorting="gridAislesList_Sorting">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAislesId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                          
                                            <asp:TemplateField HeaderText="Aisle Name" SortExpression="aisle_name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAisleName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "aisle_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Show" SortExpression="status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAisleShow" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "status")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href='EditAisle.aspx?aislesId=<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'>
                                                        <img src="../images/gtk-edit.png" width="18" height="18" border="0" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../images/delete.png" Width="18"
                                                        Height="18" border="0" CommandName="DeleteAisle" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "aisle_id")%>'
                                                        OnClientClick="return confirmsubmit();" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                                        <HeaderStyle CssClass="gridheading" ForeColor="#404248" />
                                        <AlternatingRowStyle CssClass="gridAlternatetext" />
                                        <RowStyle CssClass="gridtext" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="15px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 50px;">
                        <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="button" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

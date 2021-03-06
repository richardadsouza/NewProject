﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewClientZipReport.aspx.cs" Inherits="groceryguys.Admin.ViewClientZipReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("reports");</script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>User Reports</legend>

                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td align="right">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" class="FieldTextSearch">Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        <tr>
                            <td width="46%" align="left" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                            </td>
                        </tr>

                        <tr>
                            <td height="40">
                                <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="right">&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" align="right" nowrap="nowrap" valign="top">
                                            <span class="formText"><span class="star">*</span> Zip Code/Area:</span>
                                        </td>
                                        <td width="80%">
                                            <asp:DropDownList ID="drpZip" runat="server" CssClass="DropDownBox">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="drpZip"
                                                ErrorMessage="Select zip code/Area" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">&nbsp;
                                        </td>
                                        <td style="padding-left: 10px;">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnView" runat="server" Text="View Report" CssClass="button" OnClick="btnView_Click" />
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" OnClick="btnBack_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left"></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlClient" runat="server" Visible="false">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="padding-left: 10px;">
            <tr>
                <td class="Logoutlink">All Users Details For Zip Code/Area(<asp:Label ID="lblZipNm" runat="server" ForeColor="Red"></asp:Label>)
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
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
                                        <asp:GridView ID="griduserList" runat="server" AutoGenerateColumns="False"
                                            Width="100%" AllowPaging="true"
                                            PageSize="10"
                                            CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="griduserList_Sorting" OnPageIndexChanging="griduserList_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" SortExpression="userName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUserLName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "userName")%>'></asp:Label>
                                                        </a>                                                                                                                    
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_email")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Address">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_address1")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Phone">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_phone")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="City">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_city")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblState" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_state")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Zip">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblZip" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "users_zip")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Registered Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJoined" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "date1")%>'></asp:Label>
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
                <td style="padding-left: 50px;">
                    <asp:Button ID="btnExcel" runat="server" Text="Convert To Excel" CssClass="button" OnClick="btnExcel_Click" />
                </td>
            </tr>
            <tr>
                <td height="15px"></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

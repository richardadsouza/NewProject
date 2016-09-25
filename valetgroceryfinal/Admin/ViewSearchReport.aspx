<%@ Page Title="Search Report List" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="ViewSearchReport.aspx.cs" Inherits="groceryguys.Admin.ViewSearchReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <td class="Logoutlink">Search Report
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" CausesValidation="false" OnClick="imgBack1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <tr>
                    <td>
                        <strong style="font-size:14px;">
                            <asp:Label ID="lblStartDate" runat="server"></asp:Label>&nbsp;up to&nbsp;
                            <asp:Label ID="lblEndDate" runat="server"></asp:Label>
                        </strong>
                    </td>
                </tr>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 50px;">
                <asp:Label ID="lblMsg" CssClass="ErrorTxt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="formText">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100%">
                            <asp:UpdatePanel ID="update1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gridSearchReport" runat="server" AutoGenerateColumns="False" Width="80%"
                                        AllowPaging="true" PageSize="10" OnPageIndexChanging="gridSearchReport_PageIndexChanging"
                                        CssClass="gridBorder" CellPadding="0" CellSpacing="0" AllowSorting="True" OnSorting="gridSearchReport_Sorting"
                                        OnRowDataBound="gridSearchReport_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Time Searched">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTimeSearched" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "crap")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Term" SortExpression="search_word">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTerm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "search_word")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Results">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblResults" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "search_results")%>'></asp:Label>
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
            <td align="right" style="padding-right: 200px;">
                <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                    Width="71" Height="23" border="0" CausesValidation="false" OnClick="imgBack_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

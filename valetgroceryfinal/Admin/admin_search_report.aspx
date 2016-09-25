﻿<%@ Page Title="Search Report" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_search_report.aspx.cs" ValidateRequest="false" Inherits="groceryguys.Admin.admin_search_report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("reports");</script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="10px"></td>
                </tr>
                <tr>
                    <td>
                        <fieldset>
                            <legend>Search Report</legend>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="40">
                                        <table width="80%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                                    <asp:Label ID="lblMsg" runat="server" CssClass="formText"></asp:Label>
                                                </td>                                               
                                            </tr>
                                            <tr>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="right" class="formText">Searched Terms:
                                                </td>
                                                <td width="80%">
                                                    <asp:DropDownList ID="drpTotalPages" runat="server" CssClass="DropDownBox">
                                                        <asp:ListItem Value="0">10</asp:ListItem>
                                                        <asp:ListItem Value="1">50</asp:ListItem>
                                                        <asp:ListItem Value="2">100</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="drpSearchPopular" runat="server" CssClass="DropDownBox">
                                                        <asp:ListItem Value="1">Most Popular</asp:ListItem>
                                                        <asp:ListItem Value="2">Least Popular</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="right" nowrap="nowrap" class="formText">Location:
                                                </td>
                                                <td width="80%">
                                                    <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="right" nowrap="nowrap">
                                                    <span class="formText"><span class="star">*</span>Start Date:</span>
                                                </td>
                                                <td width="80%">
                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textBox" Enabled="false"></asp:TextBox>
                                                    <span style="padding-left: 3px;">
                                                        <img src="../images/CalendorIcon.jpg" id="imgFromCalendar" /></span>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                                        CssClass="AjaxCalendar" Format="MM/dd/yyyy"
                                                        PopupButtonID="imgFromCalendar" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="txtFromDate"
                                                        ErrorMessage="Select start date" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" align="right" nowrap="nowrap">
                                                    <span class="formText"><span class="star">*</span>End Date:</span>
                                                </td>
                                                <td width="80%">
                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textBox" Enabled="false"></asp:TextBox>
                                                    <span style="padding-left: 5px;">
                                                        <img src="../images/CalendorIcon.jpg" id="imgToCalendar" /></span>
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                                        CssClass="AjaxCalendar" Format="MM/dd/yyyy" PopupButtonID="imgToCalendar"
                                                        Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="rfvTodate" runat="server" ControlToValidate="txtToDate"
                                                        ErrorMessage="Select end date" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
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
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;
                                                </td>
                                                <td style="padding-left: 10px;">
                                                    <asp:Button ID="btnView" runat="server" Text="View Report" CssClass="button"
                                                        OnClick="btnView_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

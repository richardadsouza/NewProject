﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="testimonials.aspx.cs" Inherits="groceryguys.testimonials" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" style="padding-right: 20px;" width="580px">
        <tr>
            <td class="formHeading">Testimonials
            </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td class="formTextUser">We really value your opinion at
                <asp:Label ID="lblCmpNm" runat="server"></asp:Label>.  Try our service and let us know what you think.
Read below to see what other customers have told us about their experience with
                <asp:Label ID="lblCmpNm1" runat="server"></asp:Label>.
            </td>
        </tr>
        <tr align="center">
            <td class="formTextUser">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="buttonUser1" NavigateUrl="mailto:customerservice@valetgrocery.com">Leave a Comment</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td height="260px"></td>
        </tr>
    </table>
</asp:Content>

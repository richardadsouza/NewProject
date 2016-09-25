<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Welcomepage.aspx.cs" Inherits="groceryguys.Welcomepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="580px">
        <tr>
            <td align="left" valign="top" width="259">
                <img height="11" src="images/cc1.png" width="259" /></td>
            <tr>
                <td align="left" height="30" valign="top">
                    <img border="0" height="19" src="images/wlcome1.png" width="223" /></td>
            </tr>
            <tr>
                <td align="left" class="formTextUser" height="120" valign="top">
                    <asp:Label ID="lblHomepageText" runat="server"></asp:Label><br />
                    <br />
                </td>
            </tr>
        </tr>
    </table>
</asp:Content>

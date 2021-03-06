﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Userpremadelist.aspx.cs" Inherits="groceryguys.Userpremadelist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="formHeading">Pre-Made Shopping Lists </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td class="formTextUser">For your convenience, we have prepared a number of lists to help you with your shopping experience. These lists can give you new cooking ideas, expedite the shopping process, balance your meals, or just help to get you started with filling your fridge. </td>
        </tr>
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td valign="top" align="left" height="20">
                <asp:DataList ID="dtlCatgory2" runat="server" GridLines="None" RepeatDirection="Vertical">
                    <HeaderTemplate>
                        <table border="0" align="center" cellpadding="1" cellspacing="0">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td valign="top" style="padding-top: 3px;">
                                <img src="images/arrow0.gif" width="16" height="11" border="0" />
                            </td>
                            <td valign="top" align="left">
                                <a href='Userpremadelistdetails.aspx?listid=<%#Eval("list_id") %>' class="sideLink1">
                                    <asp:Label ID="lblAisleText" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"list_name") %>'></asp:Label>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td height="3px"></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

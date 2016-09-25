<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="shelf.aspx.cs" Inherits="groceryguys.shelf" %>

<%@ Register Src="~/cart.ascx" TagName="UserScript" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .style1 {
            font-family: OpenSans-Regular, Arial, Helvetica, sans-serif;
            font-size: 20px;
            font-weight: bold;
            color: #5FA766;
            text-align: left;
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser" style="padding-left: 10px;">
                        <a class="Userlink1" href="Shop.aspx">All Aisles</a>&nbsp;
                         <asp:Label ID="lblArrow" runat="server" Text="&gt;"></asp:Label>
                        &nbsp;
                         <asp:Label ID="lblAisleName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formHeading">
                        <asp:Label ID="lblAisleName1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser" width="100%" valign="top">
                        <table>
                            <tr>
                                <td valign="top" width="90%">
                                    <asp:Label ID="lblErrMsg" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                    <asp:Panel ID="pnlAisle" runat="server">
                                        <table cellpadding="0" cellspacing="0" border="0" width="450px">
                                            <tr>
                                                <td class="formTextUserGrid" style="vertical-align: top;" valign="top">
                                                    <asp:DataList ID="dtlAisle" runat="server" GridLines="None" RepeatDirection="Horizontal"
                                                        RepeatColumns="1" ItemStyle-VerticalAlign="Top">
                                                        <ItemTemplate>
                                                            <table width="170" border="0" cellpadding="1" cellspacing="0">
                                                                <tr>
                                                                    <td width="4" valign="top">
                                                                        <img src="images/arrow.gif" width="4" height="10" border="0" />
                                                                    </td>
                                                                    <td valign="top" align="left">
                                                                        <asp:Label ID="lblAisleID" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"AisleID") %>'></asp:Label>
                                                                        <asp:Label ID="lblAisleName" Font-Bold="true" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>' CssClass="Userlink3_new1"></asp:Label>
                                                                        <br />
                                                                        <br />
                                                                        <asp:DataList ID="dtlShelf" runat="server" GridLines="None" RepeatDirection="Horizontal" ItemStyle-VerticalAlign="Top" AlternatingItemStyle-VerticalAlign="Top" RepeatColumns="4">
                                                                            <ItemTemplate>
                                                                                <table width="170" border="0" cellpadding="1" cellspacing="0">
                                                                                    <tr>
                                                                                        <td width="4" valign="top">
                                                                                            <img src="images/arrow.gif" width="4" height="10" border="0" />
                                                                                        </td>
                                                                                        <td valign="top" align="left">
                                                                                            <a href='products.aspx?SF=<%#Eval("ShelfID")%>&AL=<%#Eval("AisleID") %>&AT=<%=Request.QueryString["AT"] %>'
                                                                                                class="linkNew1">
                                                                                                <asp:Label ID="lblShelfName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                                                                                            </a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                            </FooterTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" colspan="2" height="15px"></td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </asp:Panel>
                                </td>
                                <td valign="top" align="left" style="padding-right: 10px;" width="10%">
                                    <uc1:UserScript ID="UserScript1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

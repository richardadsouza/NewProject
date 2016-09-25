<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="Shop.aspx.cs" Inherits="groceryguys.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">   
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table border="0" style="width:100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="10px;"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlDeliveryInfo" runat="server">
                            <span class="formTextUser" style="padding-top: 2px; padding-left: 45px;"><strong>Next
                                delivery dates are: </strong>
                                <asp:Label ID="lblDeliveryDate1" runat="server" CssClass="ErrorTxt1" Text=""></asp:Label>
                                &nbsp;&nbsp;&nbsp;<asp:Label ID="lbland" runat="server" Text="and" CssClass="formTextUser"></asp:Label>
                                <asp:Label ID="lblDeliveryDate2" runat="server" CssClass="ErrorTxt1" Text=""></asp:Label></span>
                            <br />
                            <hr size="-1" color="#fcd500">
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td height="2px"></td>
                </tr>
                <tr>
                    <td align="center">
                        <span class="formHeading"><strong>Choose an Aisle</strong></span>
                    </td>
                </tr>
                <tr>
                    <td height="2px"></td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="dtlAisleList" Width="100%" runat="server" RepeatDirection="Vertical" RepeatColumns="4">
                            <ItemTemplate>
                                <table>
                                    <tr style="height:85px;">
                                        <td>
                                            <a href='shelf.aspx?AT=<%# Eval("AisleTopID") %>'>
                                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Thumbnail(DataBinder.Eval(Container.DataItem,"Image").ToString()) %>'
                                                    Width="84" Height="78"  Border="0" />
                                            </a>
                                        </td>
                                        <td width="10px">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

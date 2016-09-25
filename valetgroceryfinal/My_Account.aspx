<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="My_Account.aspx.cs" Inherits="groceryguys.My_Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var Image2 = document.getElementById("Image2");
        var Image3 = document.getElementById("Image3");
        var Image4 = document.getElementById("Image4");
        var Image5 = document.getElementById("Image5");
        var Image6 = document.getElementById("Image6");

        Image2.src = "images/tab1.png";
        Image3.src = "images/tab2.png";
        Image4.src = "images/tab3.png";
        Image5.src = "images/tab4-h.png";
        Image6.src = "images/tab5-h.png";
    </script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
                <tr>
                    <td align="left" class="formHeading">My Account
                    </td>
                </tr>
                <tr>
                    <td height="10px"></td>
                </tr>
                <tr>
                    <td align="left" class="formTextUser">You must  <a href="LoginPage.aspx" class="Userlink1">log in</a> to access your account information.
                    </td>
                </tr>
                <tr>
                    <td height="10px"></td>
                </tr>
                <tr>
                    <td align="left" class="formTextUser">If you have not registered yet, you may &nbsp; <a href="CheckZipCode.aspx" class="Userlink1">register here.</a> &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="250px"></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="ShopNew.aspx.cs" Inherits="groceryguys.ShopNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var Image2 = document.getElementById("Image2");
        var Image3 = document.getElementById("Image3");
        var Image4 = document.getElementById("Image4");
        var Image5 = document.getElementById("Image5");
        var Image6 = document.getElementById("Image6");

        Image2.src = "images/hometab.png";
        Image3.src = "images/howitwork-tab.png";
        Image4.src = "images/shop-act.png";
        Image5.src = "images/myac-tab.png";
        Image6.src = "images/viewcart-tab.png";
    </script>
    <table cellpadding="0" cellspacing="0" border="0" width="570px" height="265px">
        <tr>
            <td style="padding-bottom: 40px; padding-top: 40px;" align="center" class="commingsoon">Online shopping available starting Jan 10th!    
            </td>
        </tr>
    </table>
</asp:Content>

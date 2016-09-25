<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="DeliveryInfo.aspx.cs" Inherits="groceryguys.DeliveryInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            font-family: OpenSans-Regular, Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: normal;
            color: #000000;
            text-align: justify;
            padding-right: 20px;
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var Image1 = document.getElementById("Image9");
        var Image2 = document.getElementById("Image10");
        var Image3 = document.getElementById("Image11");
        var Image4 = document.getElementById("Image12");
        var Image5 = document.getElementById("Image13");
        var Image6 = document.getElementById("Image14");

        //alert(img1);
        Image1.src = "images/subtab1.png";
        Image2.src = "images/subtab2.png";
        Image3.src = "images/subtab3-h.png";
        Image4.src = "images/subtab4.png";
        Image5.src = "images/subtab5.png";
        Image6.src = "images/subtab6.png";   
    </script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="4" cellspacing="0" border="0" width="100%">
                <tr>
                    <td class="formHeading">
                        Delivery Information
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Place your order today and we will deliver it tomorrow!</strong>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Delivery Days : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        5 Days a Week (Monday - Friday)
                    </td>
                </tr>                
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Delivery Times : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        2PM - 7PM
                    </td>
                </tr>                
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Minimum Order : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        $75
                    </td>
                </tr>                
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Delivery Fees : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        $<asp:Label ID="lblDeliveryFee" runat="server" Text=""></asp:Label>
                    </td>
                </tr>                
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser"><strong>Payment Accepted : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Visa, MasterCard,
                        Discover and American Express
                    </td>
                </tr>               
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Order Cut-off Time : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 8PM for next
                        day delivery
                    </td>
                </tr>                
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        <strong>Delivery Areas : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;See Home Page*
                    </td>
                </tr>                
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formTextUser">
                        *More delivery areas to be added in the near future. If you don't see your zip code
                        <a href="AddNonDeliveryZone.aspx">click here</a><br />
                        and we will notify you as soon as delivery is available in your area.
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

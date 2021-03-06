﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="LoyaltyProgram.aspx.cs" Inherits="groceryguys.LoyaltyProgram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
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
        Image2.src = "images/subtab2-h.png";
    Image3.src = "images/subtab3.png";
    Image4.src = "images/subtab4.png";
    Image5.src = "images/subtab5.png";
    Image6.src = "images/subtab6.png";   
    </script>    
<asp:ScriptManager ID="script1" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table  width="100%">
        <tr>
            <td  class="formHeading">
                Loyalty Program
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="formTextUser" style="padding-right:20px;">            
               At <asp:Label ID="lblCompanyNm" runat="server"></asp:Label> &nbsp;we value our loyal customers. To show our appreciation we give free Account Funds to customers that place repeat orders. For every 5 orders under $100, you will receive $5 in free Account Funds. For every 5 orders over $100, we will add $10 dollars into your Account.
            </td>
        </tr>       
        <tr>
            <td>
               <center><img src="images/loyalty_diagram_Loy.gif" alt="loyalty program" width="326" height="155" border="0" /></center>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="formTextUser">
                <strong>How it’s Tracked</strong>                      
            </td>
        </tr>
        <tr>
            <td class="formTextUser" style="padding-right:20px;">
            Your orders are tracked
		 automatically for you and can be viewed anytime in the <a href="My_Account.aspx" class="Userlink1" >My Account</a> section of our website.  Once you complete either level of our loyalty program, we will deposit the respective amount into your Account.
            </td>
        </tr>
         <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="formTextUser" style="padding-right:20px;">                
                   <strong>Start shopping today and earn your FREE GROCERY FUNDS!</strong>
            </td>
        </tr>
          <tr><td height="10px">&nbsp;</td></tr>
        <tr>
            <td style="padding-left:40%;">
                <asp:Button ID="btnShopping" runat="server" CssClass="buttonUser" 
                    Text="Start shopping" onclick="btnShopping_Click" />
            </td>
        </tr>
        <tr><td height="10px">&nbsp;</td></tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

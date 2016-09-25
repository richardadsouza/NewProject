﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="How.aspx.cs" Inherits="groceryguys.How" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
      var Image2 = document.getElementById("Image2");
      var Image3 = document.getElementById("Image3");
      var Image4 = document.getElementById("Image4");
      var Image5 = document.getElementById("Image5");
      var Image6 = document.getElementById("Image6");

      //alert(img1);
      Image2.src = "images/tab1.png";
      Image3.src = "images/tab2-h.png";
      Image4.src = "images/tab3.png";
      Image5.src = "images/tab4.png";
      Image6.src = "images/tab5.png";  
    </script>    
<asp:ScriptManager ID="script1" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table>
        <tr>
            <td  class="formHeading">
                How It Works
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="formTextUser" style="padding-right:20px;">
                <strong>Shop Today, Get Groceries Tomorrow!</strong>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <img src="images/howitworks_steps.gif" alt="how it works" width="547" height="184" border="0" />
            </td>
        </tr>     
        <tr>
            <td class="formTextUser" style="padding-right:20px;">
                <ol>
                    <li><strong>Shop for items on your grocery list</strong>                       
                         <br />Browse our store of over 10,000 available items. As you browse our aisles simply add the items that you need to your cart. Once you have completed your shopping you simply proceed to our convenient and secure checkout. After setting up your account you will be able to save grocery lists, create new lists from your past orders and more!
<br /> <br /> 
                         </li>
                    <li><strong>Choose a delivery date</strong>
                       <br />
                       Choose your delivery date and a one hour time slot when you would like us to deliver.                     
                       <br /> <br />                 
                    </li>
                    <li><strong>Groceries are delivered to your Door </strong>
                       <br />
                          At the designated date and time that you chose we will have one of our professional and courteous staff members deliver your order right to your door.<br /> <br /> 
                    </li>
                </ol>
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
            <td style="padding-left:225px;"  >
                <asp:Button ID="btnShopping" runat="server" CssClass="buttonUser" 
                    Text="Start Shopping" onclick="btnShopping_Click" />
            </td>
        </tr>
        <tr><td height="10px">&nbsp;</td></tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="AccountFunds.aspx.cs" Inherits="groceryguys.AccountFunds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <script type="text/javascript">
        function clcontent() {
            var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
            lb1.innerHTML = "";
        }
    </script>
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
    Image3.src = "images/subtab3.png";
    Image4.src = "images/subtab4.png";
    Image5.src = "images/subtab5.png";
    Image6.src = "images/subtab6-h.png";   
    </script>   
    <asp:ScriptManager ID="script1" runat="server"> 
</asp:ScriptManager>
   <asp:UpdatePanel ID="updatePnl1" runat="server"  >
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding-left: 10px;">
        <tr>
            <td align="left" class="formHeading">
                <strong><asp:Label ID="lblCompanyName" runat="server"></asp:Label> &nbsp;Shopping 
                Funds</strong>
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
        
        <td>
        <asp:Panel ID="pnlForm" runat="server">
        <table>
         <tr><td align="left" class="formTextUserSubTitle">
        What Are Accounts Funds? 
        </td></tr>        
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUser" style="padding-right:20px;">
            Whether you are supporting someone or planning your expenses ahead, we can help. Our unique Shopping Funds and online deposit system allows you to quickly deposit money into your own account or into an account of someone else you are supporting. Funds are available for use immediately.
            </td>
        </tr>       
        <tr>
            <td height="10px">
            </td>
        </tr>       
        <tr><td align="left" class="formTextUserSubTitle">
        Adding Funds to an Account 
        </td></tr>        
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="left" class="formTextUser" style="padding-right:20px;">
                <asp:Label ID="lblCompanyName1" runat="server"></asp:Label>&nbsp;Funds are great for parents of students 18 and over or those caring for a senior relative. 
               First, your loved one must have an account set up with us. Then you can deposit funds into their account at any time.
                 The funds you deposit will be available for withdrawal immediately. This program allows them to shop for their groceries 
                 online using funds that you deposited for them. We will deliver right to their door.
            </td>
        </tr>       
        <tr>
            <td height="10px">
            </td>
        </tr>  
        <tr>
            <td class="formTextUser">
                <table cellpadding="3" cellspacing="0" border="0" width="100%" >
                    <tr>
                        <td colspan="2" align="left">
                            Fields with an <span class="star1">*</span> are required.
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                    <tr>                    
                        <td align="left" colspan="2" style="padding-left:20px;" >
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1"/>
                            <asp:Label ID="lblMsg" CssClass="formTextUser" runat="server"></asp:Label>
                        </td>
                    </tr>                    
                     <tr valign="top">
                        <td align="right" style="width:15%;">
                            <span class="star1">*</span><strong>Email Address: </strong><br />
                            <span class="formTextSmall1">(of recipient)</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRecipientEmail" Width="200px" runat="server" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Text="*" ControlToValidate="txtRecipientEmail"
                                ErrorMessage="Recipient email is required" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>  
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>                                      
                    <tr valign="top">
                        <td align="right">
                              <span class="star1">*</span><strong>Your First Name: </strong>
                        </td>
                        <td>
                           <asp:TextBox ID="txtFName" runat="server" Width="200px" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFName" runat="server" Text="*" ControlToValidate="txtFName"
                                ErrorMessage="First name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFirstName" runat="server" Text="*" ForeColor="White"
                                    ErrorMessage="Invalid first name,only characters allowed" ControlToValidate="txtFName"
                                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                        </td>
                    </tr> 
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr valign="top">
                        <td align="right">
                              <span class="star1">*</span><strong>Your Last Name: </strong>
                        </td>
                        <td>
                         <asp:TextBox ID="txtLName" runat="server" Width="200px" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLName" runat="server" Text="*" ControlToValidate="txtFName"
                                ErrorMessage="Last name is required" ForeColor="White"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revLName" runat="server" Text="*" ForeColor="White"
                                    ErrorMessage="Invalid last name,only characters allowed" ControlToValidate="txtLName"
                                    ValidationExpression="^[A-Za-z]+$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>       
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>            
                    <tr valign="top">
                       <td align="right">
                              <span class="star1">*</span><strong>Your Email: </strong>
                        </td>
                        <td>
                         <asp:TextBox ID="txtEmail" runat="server" Width="200px" CssClass="textbox1" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="txtEmail"
                                ErrorMessage="Your email is required" ForeColor="White"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                    <td></td>
                        <td  align="left" style="padding-left: 15px;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="buttonUser" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
         </table>         
         </asp:Panel>
         <asp:Panel ID="pnlSuccess" runat="server" Visible="false">
         <table>
         <tr>
            <td height="10px">
            </td>
        </tr>
         <tr>
            <td align="left">
             <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="images/back.gif" 
                onclick="imgBack1_Click" />
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
         <tr>
         <td class="formTextUser">
         The email address entered is connected to the following customer:&nbsp;<strong><asp:Label ID="lblUserName" runat="server"></asp:Label></strong>
       </td>         
         </tr>
          <tr>
            <td height="10px">
            </td>
        </tr>
         <tr>
         <td class="formTextUser">
         If this is correct, click <strong>NEXT</strong>. If this is not correct, please check the email you entered and try again.
         </td>
         </tr>
       <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
        <td align="left"> 
        <asp:ImageButton ID="imgNext" runat="server" ImageUrl="images/next.gif" 
                onclick="imgNext_Click" />
        </td>
        </tr>         
         </table>         
         </asp:Panel>         
         <asp:Panel ID="pnlFailed" runat="server" Visible="false">         
         <table>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="ErrorTxt1" align="left">
            The person's information you entered is not in our database.
            </td>
        </tr>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUser">
            This may have occurred for the following reasons:
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUser">
            <li><strong>They have not yet signed up</strong>
		<br />We have just sent an email to the address you specified asking them to sign up! For security reasons, they must be a member for you to deposit money into their account. If they are not yet signed up, you may want to contact them and let them know they need to be signed up before you can deposit money into their account.</li>
            </td>
        </tr>
        <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUser">
            <li><strong>They may have signed up with a different email address</strong>
		<br />They may have signed up with their school email address, or another one you are unaware of. Please check with them to make sure you have their correct email address and try again.
            </td>
        </tr>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUser">
            <li><strong>The email was entered incorrectly</strong>
		<br />If you think it may be incorrect, simply click back and re-enter the email correctly.</li>
		<br />		
		 <asp:ImageButton ID="imgBack" runat="server" ImageUrl="images/back.gif" 
                onclick="imgBack_Click"  />		
            </td>
        </tr>
         <tr>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td  class="formTextUser">           
		If you are still having problems, please  <a href="ContactUsPage.aspx" class="linkNew1">contact us</a>  for help...
            </td>
        </tr>         
         </table>         
         </asp:Panel>        
        </td>
        </tr>
    </table>   
  </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>

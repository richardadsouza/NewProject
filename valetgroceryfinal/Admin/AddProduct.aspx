<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="AddProduct.aspx.cs" Inherits="groceryguys.Admin.AddProduct" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function clcontent() {
        var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
        lb1.innerHTML = "";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("sitefunctions");</script>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" class="Logoutlink">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="91%">&nbsp;
                        </td>
                        <td width="9%">
                            <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../images/backbutton.jpg"
                                Width="71" Height="23" border="0" OnClick="imgBack_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Add Product </legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="23%"></td>
                                        <td align="left" class="FieldTextNew">Field with a <span class="star">*</span> are required
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10px"></td>
                                    </tr>
                                    <tr>
                                        <td width="23%"></td>
                                        <td align="left">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                            <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="44%" align="right" class="formText">
                                            <span class="star">*</span>Title:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="textBox" MaxLength="65"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                                                ErrorMessage="Title is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Shelf:
                                        </td>
                                        <td height="40">
                                            <asp:DropDownList ID="drpShelf" runat="server" CssClass="DropDownBox">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvShelf" runat="server" ControlToValidate="drpShelf"
                                                ErrorMessage="Select Shelf" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Product Type:<br />
                                            <span class="formTextSmall">(for Tax)</span>
                                        </td>
                                        <td height="40" valign="top">
                                            <asp:DropDownList ID="drpType" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="Select">Select</asp:ListItem>                                                
                                                <asp:ListItem Value="1">Food Product</asp:ListItem>
                                                <asp:ListItem Value="2">Non Food Product</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="drpType"
                                                ErrorMessage="Select product type" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Size:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtSize" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvSize" runat="server" ControlToValidate="txtSize"
                                                ErrorMessage="Size is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span> Price($):
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtPrice" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                                                ErrorMessage="Price is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for price"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                           Pre-Sale Price($):
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtPrePrice" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="revPreSalPrice" runat="server" ControlToValidate="txtPrePrice"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for pre-sale price"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Buy Price($):
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtBuyPrice" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvBuyPrice" runat="server" ControlToValidate="txtBuyPrice"
                                                ErrorMessage="Buy price is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revBuyPrice" runat="server" ControlToValidate="txtBuyPrice"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for buy price"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">Soda Deposit:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtSodaDeposit" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSodaDeposit"
                                                ValidationExpression="^(?=.*[0-9].*$)\d*(?:\.\d+)?$" ErrorMessage="Only number for soda deposit"
                                                Text="*" ForeColor="White"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">Suggested Item:
                                        </td>
                                        <td height="40" style="padding-left: 5px;">
                                            <asp:CheckBox ID="chkSuggestItem" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">Recommended Item:
                                        </td>
                                        <td height="40" style="padding-left: 5px;">
                                            <asp:CheckBox ID="chkRecomItem" runat="server" />
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td align="right" class="formText">Hide Item:
                                        </td>
                                        <td height="40" style="padding-left: 5px;">
                                            <asp:CheckBox ID="chkHideItem" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">Upload Small Image:
                                             <br />
                                            <br />
                                            Or Enter SmallImage Name :
                                        </td>
                                        <td height="40" style="padding-left: 5px;">
                                            <asp:FileUpload ID="uploadImg" runat="server" /><br />
                                            <br />
                                            <asp:TextBox ID="txtSmallImage" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">Upload Large Image:
                                             <br />
                                            <br />
                                            Or Enter LargeImage Name :
                                        </td>
                                        <td height="40" style="padding-left: 5px;">
                                            <asp:FileUpload ID="uploadLargeImg" runat="server" /><br />
                                            <br />
                                            <asp:TextBox ID="txtLargeImage" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">Store:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtStore" runat="server" CssClass="textBox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right" valign="top" class="formText">Description:
                                        </td>
                                        <td height="40">                                           
                                            <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="550px" Height="400px">
                                            </FCKeditorV2:FCKeditor>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px"></td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" class="formText">Comments:
                                        </td>
                                        <td height="40">                                           
                                            <FCKeditorV2:FCKeditor ID="FCKeditor2" runat="server" Width="550px" Height="400px">
                                            </FCKeditorV2:FCKeditor>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="2px"></td>
                                    </tr>

                                    <tr>
                                        <td align="right" class="formText">&nbsp;
                                        </td>
                                        <td height="20" style="padding-left: 10px;">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">&nbsp;
                                        </td>
                                        <td height="40" style="padding-left: 10px;">
                                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="91%">&nbsp;
                        </td>
                        <td width="9%">
                            <asp:ImageButton ID="imgBack1" runat="server" ImageUrl="../images/backbutton.jpg"
                                Width="71" Height="23" border="0" OnClick="imgBack1_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

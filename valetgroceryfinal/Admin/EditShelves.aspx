<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="EditShelves.aspx.cs" Inherits="groceryguys.Admin.EditShelves" %>
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
                    <legend>Update Shelf </legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2" class="FieldText">Field with a <span class="star">*</span> are required
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
                                            <span class="star">*</span>Shelf Name:
                                        </td>
                                        <td width="56%" height="40">
                                            <asp:TextBox ID="txtShelfName" runat="server" CssClass="textBox" MaxLength="65"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvShelfName" runat="server" ControlToValidate="txtShelfName"
                                                ErrorMessage="Shelf name is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText" valign="top">Show:
                                        </td>
                                        <td height="40" class="formText">
                                            <asp:RadioButtonList ID="rdShow" runat="server" CssClass="Radiobutton">
                                                <asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
                                                <asp:ListItem Value="1">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">
                                            <span class="star">*</span>Mapping:
                                        </td>
                                        <td height="40">
                                            <asp:TextBox ID="txtMapping" runat="server" CssClass="textBox" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMapping" runat="server" ControlToValidate="txtMapping"
                                                ErrorMessage="Mapping is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revMapping" runat="server" ControlToValidate="txtMapping"
                                                ErrorMessage="Invalid mapping,only number allowed" ValidationExpression="[0-9]+" ForeColor="White" Text="*"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText">Show as Popular:
                                        </td>
                                        <td height="40" class="formText" style="padding: 3px;">
                                            <asp:CheckBox ID="chkPopular" runat="server" Text="Yes" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="formText" valign="top">
                                            <span class="star">*</span>Aisles:
                                        </td>
                                        <td height="40" class="formText" style="padding: 3px;">
                                            <asp:CheckBoxList ID="chkAisles" runat="server">
                                            </asp:CheckBoxList>
                                        </td>
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
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click" />
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

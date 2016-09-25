<%@ Page Title="Sale Items" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="admin_sales.aspx.cs"  ValidateRequest="false" Inherits="groceryguys.Admin.admin_sales"  %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("sitefunctions");</script>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="10px"></td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>Sale Items</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="30" class="formText" nowrap="nowrap">To begin editing sale items, please choose your location below. This will pull up all sale items at that location. 
                            </td>
                        </tr>
                        <tr>
                            <td height="3px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" colspan="2" class="FieldTextSearch">Field with a <span class="star">*</span> are required
                            </td>
                        </tr>
                        <tr>
                            <td height="1px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" colspan="2" style="padding-left: 125px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" />
                                <asp:Label ID="lblMsg" runat="server" CssClass="formText"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="40">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="50%" align="right"><span class="formText"><span class="star">*</span>Location:</span></td>
                                        <td width="50%">
                                            <asp:DropDownList ID="drpLocation" runat="server" CssClass="DropDownBox">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvDelivery" runat="server" ControlToValidate="drpLocation"
                                                ErrorMessage="Select location" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="50%" align="right"><span class="formText"><span class="star">*</span>Action:</span></td>
                                        <td width="50%">
                                            <asp:DropDownList ID="drpAction" runat="server" CssClass="DropDownBox">
                                                <asp:ListItem Value="Select">Select an action...</asp:ListItem>
                                                <asp:ListItem Value="1">Edit Existing Sales / Add More</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="revAction" runat="server" ControlToValidate="drpAction"
                                                ErrorMessage="Select action" ForeColor="White" Text="*" InitialValue="Select"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td style="padding-left: 10px;">
                                            <asp:Button ID="btncontinue" runat="server" Text="continue" CssClass="button" OnClick="btncontinue_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2"><span class="horizontalLine"></span></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top"><span class="formText">Home Page:</span></td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td style="padding-left: 4px;">
                                                        <asp:TextBox ID="txtHome" runat="server" CssClass="textBox2" MaxLength="300"></asp:TextBox>

                                                    </td>
                                                    <td valign="top" style="padding-left: 10px;">
                                                        <span class="formText">$</span>
                                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="textBoxGridSmall" MaxLength="10"></asp:TextBox>
                                                    </td>

                                                    <td valign="top" style="padding-left: 10px;">
                                                        <asp:TextBox ID="txtVal" runat="server" CssClass="textBoxGridSmall" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" nowrap="nowrap" valign="top"><span class="formText">Upload Image:
                                        </span>
                                        </td>
                                        <td style="padding-left: 5px;">
                                            <asp:FileUpload ID="uploadImg" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" nowrap="nowrap" valign="top"><span class="formText">Welcome Text:
                    <br />
                                            (HTML allowed)</span>
                                        </td>
                                        <td style="padding-left: 5px;">
                                            <FCKeditorV2:FCKeditor ID="FCKWelcome" runat="server" Width="550px" Height="400px">
                                            </FCKeditorV2:FCKeditor>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" nowrap="nowrap" valign="top"><span class="formText">Left Box Title:
                                            <br />
                                            (HTML allowed)</span>
                                        </td>
                                        <td style="padding-left: 5px;">
                                            <FCKeditorV2:FCKeditor ID="FCKLeft_Box_Title" runat="server" Width="550px" Height="400px">
                                            </FCKeditorV2:FCKeditor>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" nowrap="nowrap" valign="top"><span class="formText">Left Box:
                                            <br />
                                            (HTML allowed)</span>
                                        </td>
                                        <td style="padding-left: 5px;">
                                            <FCKeditorV2:FCKeditor ID="FCKLeft_Box" runat="server" Width="550px" Height="400px">
                                            </FCKeditorV2:FCKeditor>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" nowrap="nowrap" valign="top"></td>
                                        <td style="padding-left: 20px;">
                                            <asp:Button ID="btnSet" runat="server" Text="Set" CssClass="button" OnClick="btnSet_Click" CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>

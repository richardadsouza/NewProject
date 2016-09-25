<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CouponPop.aspx.cs" Inherits="groceryguys.CouponPop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link rel="Stylesheet" href="CSS/UserSide.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
    <script type="text/javascript">
        function clcontent() {
            var lb1 = document.getElementById("<%= lblMsg.ClientID %>");
            lb1.innerHTML = "";
        }
    </script>
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="380px">
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td class="formHeading" style="padding-left: 10px;" colspan="2">
                    <asp:Label ID="lblNm" runat="server" Text="Coupon Code"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" align="left" class="formTextUser">
                    <asp:Panel ID="pnlCoupon" runat="server">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="2" align="center">Field with a <span class="star1">*</span> are required
                                </td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td width="22%"></td>
                                <td align="left">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt1" />

                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left" style="padding-left: 5px;">
                                    <asp:Label ID="lblMsg" runat="server" class="ErrorTxt1"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="5px"></td>
                            </tr>
                            <tr>
                                <td width="44%" align="right" valign="top">
                                    <strong><span class="star1">*</span>Coupon Code:</strong>
                                </td>
                                <td width="56%">
                                    <asp:TextBox ID="txtCouponName" runat="server" CssClass="textbox1" MaxLength="12"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvCouponName" runat="server" ControlToValidate="txtCouponName"
                                        ErrorMessage="Coupon code is required" ForeColor="White" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td height="10px"></td>
                            </tr>
                            <tr>
                                <td align="right">&nbsp;
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:Button ID="btnAdd" runat="server" Text="Redeem" CssClass="buttonUser" OnClick="btnAdd_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlMSg" runat="server">
                        <table>
                            <tr>
                                <td class="formTextUser">Thank you &nbsp;<strong><asp:Label ID="lblName" runat="server"></asp:Label>
                                </strong>&nbsp;        
       for redeeming your coupon.     
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="formTextUser">Your account has been credited with &nbsp;<strong><asp:Label ID="lblAr" runat="server" CssClass="ErrorTxt1" Text="$"></asp:Label><asp:Label ID="lblAccVal" runat="server" CssClass="ErrorTxt1"></asp:Label>
                                </strong>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="formTextUser">To cash in your funds be sure to select <strong>"pay with account funds"</strong> during the checkout process.
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

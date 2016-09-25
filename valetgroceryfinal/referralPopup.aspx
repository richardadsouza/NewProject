<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="referralPopup.aspx.cs"
    Inherits="groceryguys.referralPopup" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link rel="Stylesheet" href="CSS/UserSide.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="380px">
            <tr>
                <td class="formTextUser">
                    <br />
                    <br />
                    Hi <em>(friend's name)</em> -
                </td>
            </tr>
            <tr>
                <td height="1px">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="formTextUser">Your friend <em>(your name)</em> asked us to inform you about the new online grocery
                delivery service in your area -<asp:Label ID="lblCmpyNm3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="1px">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="formTextUser">
                    <em>(your name)</em> also asked us to send this personal message:
                </td>
            </tr>
            <tr>
                <td height="1px">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="formTextUser">
                    <em>(your message)</em>
                </td>
            </tr>
            <tr>
                <td height="1px">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="formTextUser">
                    <asp:Label ID="lblCmpyNm" runat="server"></asp:Label>
                    &nbsp;is an online grocery delivery service allowing you to avoid the hassles of
                traditional grocery shopping. You can shop online and have your selections delivered
                to your door at the time of your choosing. With over 4000 fresh groceries, delivery
                for only
                <asp:Label ID="lblDeliverCharge" runat="server"></asp:Label>
                    &nbsp;and extensive online features,&nbsp;
                <asp:Label ID="lblCmpyNm1" runat="server"></asp:Label>
                    &nbsp; offers the ultimate grocery shopping experience. Customers often tell us
                that once they experienced our service, they never wanted to visit the grocery store
                again.
                </td>
            </tr>
            <tr>
                <td height="1px">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="formTextUser">The best part is, if you get your friends to order you can get FREE groceries! If
                you sign up and place an order, your friend <em>(your name)</em> will receive $5
                in account funds. For each friend that you get to order, you will also get $5 Visit
                <asp:Literal ID="litSitURl" runat="server"></asp:Literal>
                    to sign-up, refer your friends, and start saving time today.
                </td>
            </tr>
            <tr>
                <td height="1px">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="formTextUser">Sincerely,
                </td>
            </tr>
            <tr>
                <td class="formTextUser">
                    <asp:Label ID="lblCmpyNm2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

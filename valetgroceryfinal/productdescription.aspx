<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productdescription.aspx.cs" Inherits="groceryguys.productdescription" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <%--<link rel="Stylesheet" href="CSS/UserSide.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
 </head>
<body bgcolor="white">
    <form id="form1" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="400px">
            <tr>
                <td class="formTextUser">
                    <br />
                </td>
            </tr>
            <tr>
                <td class="formHeadingNew">
                    <asp:Label ID="lblProdNm" runat="server"></asp:Label>
                    <asp:Panel ID="pnlSze" runat="server" Visible="false">
                        (
                        <asp:Label ID="lblSize" runat="server"></asp:Label>)
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="formTextUser">&nbsp;  
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="600px">
                        <tr>
                            <td class="formTextUser" valign="top">
                                <asp:Label ID="lblDesc" runat="server"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td class="formTextUser" valign="top" style="padding-top: 10px;" align="center">                                
                                <div style="border: 1px; background-position: center;">
                                    <center>
                                        <asp:Image ID="imgPopProduct" runat="server" /></center>
                                </div>
                                <div style="position: absolute; opacity: 0.1; filter: alpha(opacity=10); width: 1400px; height: 2000px; top: 0px; left: 0px;">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

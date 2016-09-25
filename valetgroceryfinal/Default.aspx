<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="groceryguys._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn" runat="server" Text="Button" onclick="btn_Click" /><br />        
        <asp:ImageButton ID="ImageButton1" runat="server" style="height: 16px" 
            ImageUrl="images/add-all-items.gif" onclick="ImageButton1_Click" />
    </div>
    </form>
</body>
</html>

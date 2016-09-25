<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="MyAccount.aspx.cs" Inherits="groceryguys.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3 {
            font-family: OpenSans-Regular, Arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: normal;
            color: #000000;
            height: 31px;
        }

        .style4 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        var Image2 = document.getElementById("Image2");
        var Image3 = document.getElementById("Image3");
        var Image4 = document.getElementById("Image4");
        var Image5 = document.getElementById("Image5");
        var Image6 = document.getElementById("Image6");

        Image2.src = "images/tab1.png";
        Image3.src = "images/tab2.png";
        Image4.src = "images/tab3.png";
        Image5.src = "images/tab4-h.png";
        Image6.src = "images/tab5.png";
    </script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="formHeading">My Account
                    </td>
                </tr>
                <tr valign="top">
                    <td class="style3" align="left">Welcome &nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label>!&nbsp;(<a href="UserLogout.aspx"
                        class="Userlink1">log out</a>)<br />
                        <br />
                    </td>
                    <td class="style4"></td>
                    <td align="center" class="style3" >
                        <strong class="star1">Account Balance:</strong>&nbsp;$<asp:Label ID="lblAccBAl" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="60%">
                        <!--- table for account details --->
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td width="100%" colspan="3">
                                    <img src="images/account_details.gif" alt="account details" width="100%" height="25"
                                        border="0" />
                                </td>
                            </tr>
                            <tr valign="top">
                                <td width="10" background="images/account_left.gif">
                                    <img src="images/account_left.gif" width="10" height="1" border="0" />
                                </td>
                                <td width="100%">
                                    <br />
                                    <table cellpadding="3" cellspacing="0" border="0">
                                        <tr valign="top">
                                            <td width="25%" class="formTextUser">
                                                <strong>Name:</strong>
                                            </td>
                                            <td class="formTextUser" width="60%">
                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                            </td>
                                            <td width="15%"></td>
                                        </tr>
                                        <tr valign="top">
                                            <td width="25%" class="formTextUser">
                                                <strong>Phone:</strong>
                                            </td>
                                            <td class="formTextUser" width="70%">
                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                            </td>
                                            <td width="5%" class="formTextUser">
                                                <a href="UpdatePhoneInfo.aspx" class="linkNew1">change</a>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td class="formTextUser">
                                                <strong>Username:</strong>
                                            </td>
                                            <td class="formTextUser">
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                            </td>
                                            <td class="formTextUser">
                                                <a href="UpdateLoginInfo.aspx" class="linkNew1">change</a>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td class="formTextUser" nowrap="nowrap">
                                                <strong>Delivery Address:</strong>
                                            </td>
                                            <td class="formTextUser">
                                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="lblCity" runat="server"></asp:Label>,
                                                <asp:Label ID="lblState" runat="server"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblZip"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="formTextUser">
                                                <a href="UpdateDeliveryAddress.aspx" class="linkNew1">change</a>
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td class="formTextUser">
                                                <strong>Billing Address:</strong>
                                            </td>
                                            <td class="formTextUser">
                                                <asp:Panel ID="pnlBillAdd" runat="server">
                                                    <asp:Label ID="lblBillAddress" runat="server"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblBillCity" runat="server"></asp:Label>,
                                                    <asp:Label ID="lblBillState" runat="server"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblBillZip"
                                                        runat="server"></asp:Label>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlNoBillAdd" runat="server" Visible="false">
                                                    <asp:Label ID="lblNoBillInfo" runat="server" CssClass="ErrorTxt1">
                                                    </asp:Label>
                                                </asp:Panel>
                                            </td>
                                            <td class="formTextUser">
                                                <a href="UpdateBillingAddress.aspx" class="linkNew1">change</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                                <td width="10" background="images/account_right.gif">
                                    <img src="images/account_right.gif" width="10" height="1" border="0" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="images/account_bottom.gif" width="100%" height="9" border="0" />
                                </td>
                            </tr>
                        </table>
                        <p />
                        <!-- past orders -->
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="100%" colspan="3">
                                    <img src="images/order_history2.gif" alt="order history" width="100%" height="25"
                                        border="0" />
                                </td>
                            </tr>
                            <tr valign="top">
                                <td width="10" background="images/account_left.gif">
                                    <img src="images/account_left.gif" width="10" height="1" border="0" />
                                </td>
                                <td width="100%">
                                    <br />
                                    <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNoOrder" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                                                <asp:GridView ID="gridOrderList" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CellPadding="0" CellSpacing="0" GridLines="None">
                                                    <Columns>
                                                        <asp:TemplateField Visible="false" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOrederId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Order #" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOrderNm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_number")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Order Date" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOrderDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderDate1")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount($)" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("orders_totalfinal")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ReOrder" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <a href='orderdetails.aspx?chk=2&orderId=<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'
                                                                    class="linkNew1">ReOrder </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                                                    <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                                    <RowStyle CssClass="gridUsertext" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <strong><a href="viewallpast.aspx" class="Userlink1">
                                                    <asp:Label ID="lblView" runat="server" Text="View All"></asp:Label></a></strong>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                                <td width="10" background="images/account_right.gif">
                                    <img src="images/account_right.gif" width="10" height="1" border="0" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="images/account_bottom.gif" width="100%" height="9" border="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <!--- end account details --->
                    <td width="22">&nbsp;
                    </td>
                    <td width="100%">
                        <table cellpadding="1" cellspacing="0" border="0" bgcolor="#e6e6e6" width="100%">
                            <tr>
                                <td>
                                    <asp:GridView ID="gridBalanceList" runat="server" AutoGenerateColumns="False" Width="100%"
                                        AllowPaging="true" OnPageIndexChanging="gridBalanceList_PageIndexChanging" CellPadding="0"
                                        CellSpacing="0" PageSize="5" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTranId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "transactions_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTranType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "transactions_comment")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTranDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Date1")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount($)" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOpnBracket" runat="server" Text="(" Visible="false"></asp:Label>
                                                    <asp:Label ID="lblTranAmount1" runat="server" Text='<%# Convert.ToDecimal(Eval("transactions_amount")).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) %>'></asp:Label>
                                                    <asp:Label ID="lblClsBracket" runat="server" Text=")" Visible="false"></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orders_id")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrderNm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "transactions_fname")%>'></asp:Label>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridUserheading" ForeColor="#404248" />
                                        <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                        <RowStyle CssClass="gridUsertext" />
                                        <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" bgcolor="#E6E6E6" style="background-color:#E6E6E6;">
                            <tr>
                                <td width="100%" colspan="3">
                                    <img src="images/myaccount_rewards.gif" alt="loyalty program" width="100%" height="32"
                                        border="0" />
                                </td>
                            </tr>
                            <tr>                               
                                <td colspan="3" width="100%" class="formTextUserLoyaltyMyAccount" align="center">
                                    <center><a href="LoyaltyProgram.aspx" style="font-weight: bold;" class="Userlink1">What's this?</a></center>
                                    </span>
                                                                     <strong>Under $100</strong>
                                    <asp:Image ID="imgUnderFifty" runat="server" Width="202" Height="52" border="0" />
                                    <asp:Label ID="lblUnderFifty" runat="server"></asp:Label>
                                    <br />
                                    <strong>Over $100</strong>
                                    <asp:Image ID="imgOverFifty" runat="server" Width="202" Height="52" border="0" />
                                    <asp:Label ID="lblOverFifty" runat="server"></asp:Label>
                                </td>                               
                            </tr>
                            <tr>
                                <td width="100%" colspan="3">
                                    <img src="images/myaccount_rewardsbottom.gif" width="100%" height="10" border="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="20px">&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

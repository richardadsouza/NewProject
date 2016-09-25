<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="product_order.aspx.cs" Inherits="groceryguys.product_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
        .style2 {
            width: 125px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="formHeading" style="padding-left: 10px;">
                        <asp:Label ID="lblHead" runat="server" Text="Your Shopping Cart"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; text-align: left; width: 100%;">
                        <asp:Label ID="lblCartEmpty" runat="server" CssClass="ErrorTxt1" Visible="false"></asp:Label>
                        <asp:Panel ID="pnlCart" runat="server" Width="100%">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="2" align="left"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView runat="server" ID="grvOrderDetails" AutoGenerateColumns="False" Width="100%"
                                            GridLines="None" CellPadding="0" CellSpacing="0">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" ID="chkSelect" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product">
                                                    <ItemTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnProductID" Value='<%#DataBinder.Eval(Container.DataItem, "ProductID") %>' />
                                                        <asp:Label runat="server" ID="lblProductName" Text='<%#DataBinder.Eval(Container.DataItem, "ProductName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Size">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblSize" Text='<%#DataBinder.Eval(Container.DataItem, "Size") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Price ($)">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblPrice" Text='<%#DataBinder.Eval(Container.DataItem, "Price") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:TextBox CssClass="textboxSmallNew" runat="server" ID="txtQty" MaxLength="3" Text='<%#DataBinder.Eval(Container.DataItem, "Qty") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="pagingUsertext" ForeColor="#FFFFFF" />
                                            <HeaderStyle CssClass="gridUserheading" ForeColor="white" />
                                            <AlternatingRowStyle CssClass="gridUserAlternatetext" />
                                            <RowStyle CssClass="gridUsertext" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="20px"></td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click"
                                                         runat="server" CssClass="buttonUser" Text="Update" CausesValidation="false" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" CssClass="buttonUser" Text="Delete" CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formTextUser" style="padding-left: 10px;" valign="top">
                                        <table>
                                            <tr>
                                                <td style="padding-left: 2px;" align="right" class="style2">
                                                    <strong>
                                                        <asp:Label ID="lblSubTot" runat="server" Text="Sub Total:"></asp:Label></strong>
                                                </td>
                                                <td style="padding-left: 2px;">
                                                    <asp:Label ID="lblSign" runat="server" Text="$"></asp:Label>
                                                    <asp:Label ID="lblSubTotVal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="style2">
                                                    <strong>
                                                        <asp:Label ID="lblTax" runat="server" Text="Tax(3%):"></asp:Label></strong>
                                                </td>
                                                <td style="padding-left: 2px;">
                                                    <asp:Label ID="lblSign4" runat="server" Text="$"></asp:Label>
                                                    <asp:Label ID="lblTaxVal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="style2">
                                                    <strong>
                                                        <asp:Label ID="lblDeliveryFee" runat="server" Text="Delivery Fee"></asp:Label></strong>
                                                </td>
                                                <td style="padding-left: 2px;">
                                                    <asp:Label ID="lblSign2" runat="server" Text="$"></asp:Label>
                                                    <asp:Label ID="lblDeliveryFeeTot" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span class="horizontalLine1"></span>
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <td align="right" class="style2">
                                                    <strong>
                                                        <asp:Label ID="lblTot" runat="server" Text="Total"></asp:Label></strong>
                                                </td>
                                                <td style="padding-left: 2px;">
                                                    <asp:Label ID="lblSign3" runat="server" Text="$"></asp:Label>
                                                    <asp:Label ID="lblTotVal" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td align="right" class="style2">
                                                    <strong>
                                                        <asp:Label ID="Label1" runat="server" Text="Discount"></asp:Label></strong>
                                                </td>
                                                <td style="padding-left: 2px;">
                                                    <asp:Label ID="lblSign5" runat="server" Text="$"></asp:Label>
                                                    <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <span class="horizontalLine1"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="style2">
                                                    <strong>
                                                        <asp:Label ID="lblTotAfterDiscount" runat="server" Text="Total After Discount"></asp:Label></strong>
                                                </td>
                                                <td style="padding-left: 2px;">
                                                    <asp:Label ID="lblSign6" runat="server" Text="$"></asp:Label>
                                                    <asp:Label ID="lblTotValueAfterDiscount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="right" style="padding-right: 20px;" valign="top">
                                        <table cellpadding="0" cellspacing="0" border="0" bgcolor="#e6e6e6">
                                            <tr>
                                                <td>
                                                    <img src="images/coupon_box.gif" alt="coupon code" width="196" height="23" border="0" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <span class="formTextUser">&nbsp;Redeem your coupon and
                                                        <br />
                                                        promotional codes here:&nbsp;</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" colspan="2">
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxtNew1" />
                                                                <asp:Label runat="server" ID="lblCouponError" runat="server" CssClass="ErrorTxtNew1"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="padding-left: 10px; padding-right: 10px;">
                                                                <asp:TextBox ID="txtCouponCode" Width="" runat="server" CssClass="textboxSmall" MaxLength="12"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator ID="rfvCouponName" runat="server" ControlToValidate="txtCouponCode"
                                                                    ErrorMessage="Coupon code is required" ForeColor="#D7F0EE" Text="*"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="buttonUserNew" OnClick="btnGo_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:ImageButton ID="imgCheck" runat="server" ImageUrl="images/proceed_checkout.gif" AlternateText="PROCEED TO CHECKOUT"
                                            CausesValidation="false" OnClick="imgCheck_Click" />
                                        <span style="padding-left: 10px;">
                                            <asp:ImageButton ID="imgSaveList" OnClick="imgSaveList_Click" runat="server" ImageUrl="images/save_list.gif" AlternateText="SAVE THIS LIST"
                                                CausesValidation="false" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10px"></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblMsg" runat="server" CssClass="ErrorTxt1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px;">
                        <asp:Button ID="btnContinue" runat="server" CssClass="buttonUser" Text="Continue Shopping"
                            CausesValidation="false" OnClick="btnContinue_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="10px"></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

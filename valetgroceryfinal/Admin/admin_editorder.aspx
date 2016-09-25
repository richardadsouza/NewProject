<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true"
    CodeBehind="admin_editorder.aspx.cs" Inherits="groceryguys.Admin.admin_editoreder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            height: 94px;
        }
        .style3
        {
            width: 102px;
            font-style: italic;
        }
    </style>
    <%--<link type ="text/css" rel=Stylesheet href="../CSS/UpdateProgress.css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="JavaScript1.2">showHide("customers");</script>
    <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePnl1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="3" cellspacing="0" class="table-border " width="80%">
                <tr>
                    <td style="padding-left: 80%" colspan="2">
                        <a href='UserOrderDetailsPrint.aspx?orderId=<%=Request.QueryString["orderId"]%>&userId=<%=Request.QueryString["userId"]%>'
                            target="_blank">
                            <img src="../images/printButton.jpg" border="0" />
                        </a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="formHeadingText">
                        <strong>Order #: </strong>
                        <asp:Label ID="lblOrderNumber" ForeColor="White" runat="server" CssClass="formText"></asp:Label>
                    </td>
                </tr>
                <tr valign="top" class="formText">
                    <td>
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td align="right">
                                    <strong>Ordered:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblOrederDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="formText" align="right">
                                    <strong>Delivery:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblDeliveryDateTime" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top" align="right">
                                <td>
                                    <strong>Payment method:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label><%--<br />
                                <asp:Label ID="lblCreditInfo" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="300">
                        <strong>Special Order Instructions?</strong><br />
                        <asp:Label ID="lblSpecialOrInfo" runat="server" CssClass="formTextSmall"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr class="formHeadingText">
                    <td>
                        <strong>Customer Information</strong>
                    </td>
                    <td>
                        <strong>Delivery Address</strong>
                    </td>
                </tr>
                <tr valign="top" class="formText">
                    <td width="300" class="style2">
                        <table cellpadding="3" cellspacing="0" border="0">
                            <tr>
                                <td width="120" align="right">
                                    <strong>First Name:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblFName" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Last Name:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblLName" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Phone:</strong>
                                </td>
                                <td class="formTextSmall">
                                    <asp:Label ID="lblPhone" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <strong>Phone 2:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblPhone2" runat="server">
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="300" class="style2">
                        <table cellpadding="3" cellspacing="0" border="0">                           
                            <tr>
                                <td width="100" align="left">
                                    <strong>Address1 :</strong>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="lblAddress"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Address2 :</strong>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="lblAddress2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" rowspan="3">
                                    <strong>City, State Zip:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:TextBox runat="server" ID="lblCity"></asp:TextBox>
                                    ,
                                    </td>                                
                                </tr>
                            <tr>
                                <td align="left" class="formTextSmall"> 
                                    <asp:TextBox runat="server" ID="lblState"></asp:TextBox>
                                   </td>
                            </tr>
                            <tr>
                                <td align="left" class="formTextSmall"><asp:TextBox runat="server" ID="lblZip"></asp:TextBox></td>
                            </tr>  
                            <tr>
                                <td></td>
                                <td align="left">
                                    <asp:Button ID="Button3" runat="server" Text="Update" CssClass="button" OnClick="Button3_Click" />
                                    <br />
                                    <asp:Label ID="lblMsg" CssClass="formText" runat="server"></asp:Label>
                                </td>
                            </tr> 
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gridUserProductList" runat="server" AutoGenerateColumns="False"
                            Width="100%" CssClass="gridBorder" CellPadding="0" CellSpacing="0" OnRowCommand="gridUserProductList_OnRowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'
                                            Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtTotalProductQty" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_quantity")%>'
                                            CssClass="textBoxSmall"></asp:TextBox>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_title")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "product_size")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'
                                            Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtTotalProductPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "orderproduct_price")%>'
                                            CssClass="textBoxSmall"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="../images/gtk-edit.png"
                                            Width="18" Height="18" border="0" CommandName="UpdateDelievry" CommandArgument='<%# Eval("product_id") %>'
                                            CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../images/delete.png" Width="18"
                                            Height="18" border="0" CommandName="DeleteDelievry" CommandArgument='<%# Eval("product_id") %>'
                                            CausesValidation="false" OnClientClick="return confirmsubmit();" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pagingtext" ForeColor="#FFFFFF" />
                            <HeaderStyle CssClass="gridheading" ForeColor="#404248" />
                            <AlternatingRowStyle CssClass="gridAlternatetext" />
                            <RowStyle CssClass="gridtext" />
                        </asp:GridView>
                        <span style="padding-left: 80px;">
                            <asp:Label ID="lblMsg1" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label></span><br />
                        <span style="padding-left: 80px;">
                            <asp:Label ID="Label1" runat="server" Font-Size="15px" CssClass="ErrorTxt" Text="Products with * are edited or updated"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                        <strong>Add Comments:</strong>
                    </td>
                </tr>
                <tr>
                    <td height="10px" style="width:30%;">
                        <asp:TextBox ID="txtcomment" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btncomment" runat="server" Text="Add" CssClass="button" OnClick="btncomment_Click" />
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                        <strong>Add a Product:</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="ErrorTxt" ValidationGroup="NewProduct" />
                        <asp:Label ID="lblAddError" runat="server" CssClass="ErrorTxt" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td height="10px" colspan="2">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <span class="star">*</span>
                                    <asp:Label ID="Label3" runat="server" Text="QTY:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtqty" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvtxtqty" runat="server" ControlToValidate="txtqty"
                                        ErrorMessage="QTY is required" ForeColor="White" Text="*" ValidationGroup="NewProduct"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <span class="star">*</span>
                                    <asp:Label ID="Label4" runat="server" Text="ID:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtproductid" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="txtproductid"
                                        ErrorMessage="ID is required" ForeColor="White" Text="*" ValidationGroup="NewProduct"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="Add" CssClass="button" OnClick="Button1_Click"
                                        ValidationGroup="NewProduct" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right" class="formText" style="padding-right: 120px;">
                        <table>
                            <tr>
                                <td></td>
                                <td align="right" class="style3">
                                    <strong>Sub Total: </strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right" class="style3">
                                    <strong>Tax(3%):</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblTax" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right" class="style3">
                                    <strong>Tax(9%):</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblTax2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right" class="style3">
                                    <strong>Soda Deposit:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblSodaDeposit" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right" class="style3">
                                    <strong>Delivery Fee:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblDeliveryFee" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right" class="style3">
                                    <strong>Tip:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblTips" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="2">
                                    <hr size="-1" color="#000000" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="right" class="style3">
                                    <strong>ORDER TOTAL:</strong>
                                </td>
                                <td align="left" class="formTextSmall">
                                    <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="updateProgress1" runat="server" DisplayAfter="0" DynamicLayout="true"
        AssociatedUpdatePanelID="updatePnl1">
        <ProgressTemplate>
            <div id="TransparentGrayBackground">
            </div>
            <div id="UpdateProgress" class="padding">
                <asp:Image ID="ajaxLoadNotificationImage1" runat="server" ImageUrl="images/loader.gif"
                    AlternateText="[image]" />
                <span class="UpdateProgressText">Please Wait....</span>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

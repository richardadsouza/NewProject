﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewLetterPopup.aspx.cs"
    Inherits="groceryguys.Admin.NewLetterPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link rel="Stylesheet" href="../CSS/general.css" type="text/css" />--%>
    <link rel="stylesheet" href="../CSS/style.css" type="text/css" />
</head>
<body bgcolor="white">
    <form id="form1" runat="server">
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="MainTableBorder">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="82">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">                                
                                <tr>
                                    <td colspan="2">
                                        <img src="../images/newsletter_header.gif" height="95" border="0" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="2" class="underheaderbgblack">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 2px;">
                                        <asp:Label ID="lblWeekDate" runat="server" Text="" CssClass="formTextSmall"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 5px;">
                                        <asp:Label ID="lblEmailHeader" runat="server" Text="" CssClass="formTextSmall"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="headingbox">
                            THIS WEEK SPECIALS
                        </td>
                    </tr>
                    <tr>
                        <td class="underheaderbgblack">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f6f6f6">
                            <asp:Panel ID="pnlProduct" runat="server">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <br />
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="MainTableBorderNew">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlProd1" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd1" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm1" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle1" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litProdView1" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice1" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId1" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl1" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlProd2" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd2" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm2" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litProdView2" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice2" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId2" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl2" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlProd3" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd3" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm3" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle3" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                      
                                                                        <asp:Literal ID="litProdView3" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice3" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId3" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl3" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlProd4" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd4" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm4" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle4" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litProdView4" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice4" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId4" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl4" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlProd5" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd5" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm5" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle5" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                       
                                                                        <asp:Literal ID="litProdView5" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice5" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId5" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl5" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlProd6" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd6" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm6" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle6" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litProdView6" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice6" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId6" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl6" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlProd7" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd7" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm7" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle7" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                       
                                                                        <asp:Literal ID="litProdView7" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice7" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId7" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl7" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnlProd8" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgProd8" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblProdImageNm8" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblProdTitle8" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litProdView8" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblProdPrice8" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblProductId8" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblPnl8" runat="server" Text="No Item available" CssClass="formText"
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">                                           
                                            <asp:Literal ID="litViewAllSaleItems" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="headingbox">
                            FEATURED PRODUCTS
                        </td>
                    </tr>
                    <tr>
                        <td class="underheaderbgblack">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f6f6f6">
                            <asp:Panel ID="pnlFeatured" runat="server">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <br />
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="MainTableBorderNew">
                                                <tr>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat1" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat1" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm1" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle1" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                       
                                                                        <asp:Literal ID="litFeatView1" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice1" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId1" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat1" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat2" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat2" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm2" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle2" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litFeatView2" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice2" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId2" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat2" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat3" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat3" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm3" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle3" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                       
                                                                        <asp:Literal ID="litFeatView3" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice3" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId3" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat3" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat4" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat4" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm4" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle4" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litFeatView4" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice4" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId4" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat4" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat5" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat5" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm5" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle5" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                      
                                                                        <asp:Literal ID="litFeatView5" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice5" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId5" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat5" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat6" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat6" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm6" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle6" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                        
                                                                        <asp:Literal ID="litFeatView6" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice6" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId6" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat6" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat7" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat7" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm7" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle7" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>                                                                      
                                                                        <asp:Literal ID="litFeatView7" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice7" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId7" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat7" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                    <td width="25%">
                                                        <asp:Panel ID="pnlFeat8" runat="server" Visible="false">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" valign="middle" width="50px">
                                                                        <asp:Image ID="imgFeat8" runat="server" Width="50px" Height="50px" />
                                                                        <asp:Label ID="lblFeatImageNm8" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td align="left" valign="middle" width="100px" class="formTextSmall">
                                                                        <asp:Label ID="lblFeatTitle8" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="litFeatView8" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td class="ErrorTxt">
                                                                        <asp:Label ID="lblFeatPrice8" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblFeatProductId8" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <asp:Label ID="lblFeat8" runat="server" Text="No Item available" CssClass="formText"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="padding-left: 5px;">
                                        <asp:Label ID="lblFooterText" runat="server" Text="" CssClass="formTextSmall"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="headingbox">
                            We look forward to delivering to you!
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="formTextSmall" align="center">
                                        If you would like to un-subscribe to this newsletter please contact us at                                       
                                        <asp:Literal ID="litcustomerservice" runat="server"></asp:Literal>
                                        with UNSUBSCRIBE in the email subject. But please don't because you will be missing
                                        out on some great specials!
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<%@ Page Language="c#" Inherits="tx_r16.Shoebox.Evaluation.Pages.Eval" CodeFile="Eval.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 Transitional//EN" >
<html lang="en" xml:lang="en">
<head>
    <title>escWorks® .NET Evaluation Form</title>
    <link href="../../lib/css/local.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
			function Page_OnInit()
			{
				<asp:PlaceHolder ID="pCloser" Runat="Server" Visible="False">self.close();</asp:PlaceHolder>
			}
			function LoadEvaluation(id)
			{
				window.open("../evaluation/?registrationId=" + id, "Evaluation", "width=575, height=600, resizable=no, scrollbars=no, status=no, menubar=no");
			}
					
			function LoadCertificate(id)
			{
			 //top.location.href = "../../lib/report.aspx?reportName=certificate&instruction=download:pdf&attendee_id=" + id; 
			}
    </script>
</head>
<body onload="Page_OnInit();" style="margin: 0px;">
    <div align="center">
        <br />
        <form id="aspnetForm" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" align="center" border="0" style="width: 550px;
            border-collapse: collapse; height: 250px">
            <tr>
                <td class="LayoutRule" colspan="3" width="1">
                    <img src="../../lib/standard/img/trans.gif" border="0" width="1" height="1" alt="Transparent Gif" />
                </td>
            </tr>
            <tr>
                <td class="LayoutRule" width="1">
                    <img src="../../lib/standard/img/trans.gif" border="0" width="1" height="1" alt="Transparent Gif" />
                </td>
                <td class="LayoutContent">
                    <table cellpadding="0" cellspacing="5" width="100%" height="100%">
                        <tr>
                            <td bgcolor="#ffffff">
                                &nbsp;<img src="../../lib/standard/img/Evaluation.gif" width="32" height="32" alt=""
                                    border="0" align="absMiddle" />
                            </td>
                            <td bgcolor="#ffffff" colspan="2">
                                <span style="font-weight: bold; font-size: 12pt; color: #191970">Evaluation Form Verification</span><br>
                            </td>
                        </tr>
                        <tr>
                            <td class="LayoutRule" height="1" colspan="3">
                                <img src="../../lib/standard/img/trans.gif" border="0" width="1" height="1" alt="Transparent Gif" />
                            </td>
                        </tr>
                        <asp:PlaceHolder ID="pSignIn" runat="server">
                            <tr>
                                <td align="center" width="100%" colspan="3" height="25">
                                    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="#FF0000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="FormInput" nowrap align="right" width="150">
                                    Session ID:
                                </td>
                                <td class="FormInput" align="left">
                                    <asp:TextBox ID="tbSessionId" runat="Server"></asp:TextBox>
                                </td>
                                <td nowrap align="left" width="100%">
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="Server" Font-Size="9pt"
                                        Display="Dynamic" ErrorMessage="Session ID field is required!" ControlToValidate="tbSessionId"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ControlToValidate="tbSessionId" ValidationExpression="^\d+$" Font-Size="9pt"
                                            Display="Dynamic" ErrorMessage="Session ID contains numeric values only." runat="Server"
                                            ID="Regularexpressionvalidator1"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="FormInput" nowrap align="right" width="150">
                                    Registration ID:
                                </td>
                                <td class="FormInput" align="left">
                                    <asp:TextBox ID="tbUserId" runat="Server"></asp:TextBox>
                                </td>
                                <td nowrap align="left" width="100%">
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="Server" Font-Size="9pt"
                                        Display="Dynamic" ErrorMessage="Registration ID field is required!" ControlToValidate="tbUserId"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ControlToValidate="tbUserId" ValidationExpression="^\d+$" Font-Size="9pt" Display="Dynamic"
                                            ErrorMessage="User ID contains numeric values only." runat="Server" ID="Regularexpressionvalidator2"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="FormInput" nowrap align="right" width="150">
                                    Last Name:
                                </td>
                                <td class="FormInput" align="left">
                                    <asp:TextBox ID="tbLastName" runat="Server"></asp:TextBox>
                                </td>
                                <td nowrap align="left" width="100%">
                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="Server" Font-Size="9pt"
                                        Display="Dynamic" ErrorMessage="Last Name field is required!" ControlToValidate="tbLastName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="btnValidate" OnClick="Click_btnValidate" runat="Server" Text="Submit">
                                    </asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%" colspan="3" height="100%">
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pEvaluation" Visible="False" runat="Server">
                            <tr valign="middle">
                                <td class="FormInput" width="100%" colspan="3">
                                    <i><b>We value your feedback.</b><br />
                                        <br />
                                        Please click on the <b>Evaluation</b> button in order to answer a very short evaluation.<br>
                                        After submitting your feedback, you will be able to return to your Registration
                                        History and print a copy of your certificate.</i>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td class="FormInput" align="center" width="100%" colspan="3">
                                    <asp:PlaceHolder ID="btnEvaluation" runat="Server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pCertificate" Visible="False" runat="Server">
                            <tr valign="middle">
                                <td class="FormInput" align="center" width="100%" colspan="3">
                                    <i><b>Thank you for completing the evaluation form.</b><br />
                                        <br />
                                        Please click on the <b>Certificate</b> button in order to download your Certificate
                                        of Completion.</i>
                                </td>
                            </tr>
                            <tr valign="middle">
                                <td class="FormInput" align="center" width="100%" colspan="3">
                                    <asp:PlaceHolder ID="btnCertificate" runat="Server"></asp:PlaceHolder>
                                </td>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pNoEvaluation" Visible="False" runat="Server">
                            <tr valign="middle">
                                <td class="FormInput" align="center" width="100%" colspan="3">
                                    <i><b>There are no evaluation at this time.</b><br />
                                        <br />
                                        Please check back at a later time.</i>
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                        <tr height="1">
                            <td class="LayoutRule" colspan="3">
                                <img src="../../lib/standard/img/trans.gif" border="0" width="1" height="1" alt="Transparent Gif" />
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="3">
                                &nbsp;<img src="../../lib/standard/img/secure.gif" width="32" height="32" alt=""
                                    border="0" align="absMiddle" />&nbsp; <span style="font-weight: bold; font-size: 8pt;
                                        color: #191970">escWorks<small><sup>&reg;</sup></small> .NET Evaluation Form © 2015
                                    </span>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="LayoutRule" width="1">
                    <img src="../../lib/standard/img/trans.gif" border="0" width="1" height="1" alt="Transparent Gif" />
                </td>
            </tr>
            <tr>
                <td class="LayoutRule" colspan="3" width="1">
                    <img src="../../lib/standard/img/trans.gif" border="0" width="1" height="1" alt="Transparent Gif" />
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="lib_collaboration_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head runat="server">
    <title>Share a Page</title>
    <script src='https://www.google.com/recaptcha/api.js' type="text/javascript" async defer></script>
</head>
<script language="javascript" type="text/javascript">
    function Page_OnInit() {
        resizeTo(350, 650);
    }
</script>
<body onload="Page_OnInit();">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
            <tr>
                <td colspan="2" height="1" bgcolor="#191970">
                    <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="Transparent Gif" />
                </td>
            </tr>
            <tr>
                <td colspan="2" height="4" bgcolor="#ffffff">
                    <img src="../../lib/standard/img/trans.gif" border="0" height="4" alt="Transparent Gif" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#ffffff">
                    &nbsp;<img src="../../lib/standard/img/share.gif" width="32" height="32" alt="" border="0"
                        align="absmiddle" />
                </td>
                <td bgcolor="#ffffff">
                    <span style="color: #191970; font-weight: bold; font-size: 12pt;">Collaboration: Share
                        a page</span><br>
                    <span style="font-size: 8pt;">Share a resource with a colleague or friend.</span>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="4" bgcolor="#ffffff">
                    <img src="../../lib/standard/img/trans.gif" border="0" height="4" alt="Transparent Gif" />
                </td>
            </tr>
            <tr>
                <td colspan="2" height="1" bgcolor="#191970">
                    <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="Transparent Gif" />
                </td>
            </tr>
            <tr>
                <td colspan="2" height="100%" valign="top">
                    <table border="0" width="100%">
                        <tr>
                            <td class="FormInput">
                                You are sharing the following resource:<br />
                                <asp:Label ID="ResourceSource" runat="server" Font-Size="9pt" Font-Italic="True"></asp:Label>
                                <br />
                                <br />
                                <asp:Label ID="RecipeintLabel"
            text="Friend or Colleagues Email:"
            AssociatedControlID="ResourceRecipient"
            runat="server"></asp:Label>
                                <asp:RequiredFieldValidator ID="Require_EmailText" runat="Server" ControlToValidate="ResourceRecipient"
                                    ErrorMessage="Email is missing.<br>" CssClass="RequiredText"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="Validate_EmailText" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>"
                                    Display="Dynamic" ControlToValidate="ResourceRecipient" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="ResourceRecipient" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                <asp:PlaceHolder ID="pSenderInfo" runat="server">
                                    <br />
                                    <asp:Label ID="YourNameLabel"
            text="Your Name:"
            AssociatedControlID="ResourceSender"
            runat="server"></asp:Label><br />
                                    <asp:TextBox ID="ResourceSender" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                    <br />
                                    <asp:Label ID="YourEmailLabel"
            text="Your E-mail:"
            AssociatedControlID="ResourceSenderEmail"
            runat="server"></asp:Label>
                                    <asp:RequiredFieldValidator ID="Require_EmailText2" runat="Server" ControlToValidate="ResourceSenderEmail"
                                        ErrorMessage="Email is missing.<br>" CssClass="RequiredText"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Validate_EmailText2" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>"
                                        Display="Dynamic" ControlToValidate="ResourceSenderEmail" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="ResourceSenderEmail" runat="server" CssClass="TextBox" Width="100%"></asp:TextBox>
                                </asp:PlaceHolder>
                                <br />
                                <asp:Label ID="MessageLabel"
            text="Short Message:"
            AssociatedControlID="ResourceMessage"
            runat="server"></asp:Label><br />
                                <asp:TextBox ID="ResourceMessage" runat="server" CssClass="TextBox" TextMode="MultiLine"
                                    Rows="7" Columns="35" Width="100%" Height="60px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
                <tr>
                    <td>
                        <div class="g-recaptcha" data-sitekey="6LeRZBETAAAAAKN3XmAIQW4yM6xh0icj4W6SOvsv">
                        </div>
                        <br />
                        <br />
                    </td>
                </tr>
            <tr>
                <td colspan="2" bgcolor="#191970" align="right">
                    <table border="0" width="100%">
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" CssClass="error" ID="lblError" />
                                <asp:Button runat="server" ID="btnSend" Text="Send" CssClass="forminput" />
                                <input type="button" value="Cancel" style="width: 100px;" class="button" onclick="self.close();" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

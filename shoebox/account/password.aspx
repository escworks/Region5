<%@ Page Language="C#" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="shoebox_account_password"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="PlaceHolder1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="PlaceHolder1" UpdatePanelCssClass="" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <table border="0" cellpadding="4" cellspacing="0">
            <tr>
                <td>
                    <asp:PlaceHolder ID="pForgot" runat="server" Visible="False">
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td class="mainBody" width="300">
                                    In order to retrieve a lost password, you must supply your email address and click
                                    'Send'.
                                    <br />
                                    <br />
                                    You will be emailed a link that will enable you to change your password.
                                </td>
                                <td rowspan="3" width="20" valign="top" nowrap>
                                    &nbsp;
                                </td>
                                <td rowspan="3" valign="top" width="100%" class="mainBody">
                                    <table border="0" cellpadding="0" cellspacing="0" width="200">
                                        <tr>
                                            <td colspan="2" class="mainBody">
                                                <span style="font-size: 12pt;"><b>Account F.A.Q.s</b></span>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td height="4" nowrap>
                                                            <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="*">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="1" bgcolor="#cccccc" background="../../lib/standard/img/dash_h.gif">
                                                            <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="*" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="4" nowrap>
                                                            <img src="../../lib/standard/img/trans.gif" border="0" height="1" alt="*" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="10">
                                                <img src="../../lib/standard/img/trans.gif" alt="" border="0" height="10" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="5" align="right" class="mainBody" valign="top" nowrap>
                                                <b>Q</b>:
                                            </td>
                                            <td class="mainBody">
                                                <b>What do I do now that my email address has changed?</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="5" align="right" class="mainBody" valign="top" nowrap>
                                                <b>A</b>:
                                            </td>
                                            <td class="mainBody">
                                                <i>If you know your previous email address, <a href="email.aspx" class="link">click
                                                    here</a> to update your account.</i>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="mainBody">
                                    <br />
                                    <asp:Label ID="EmailAddressLabel"
            text="Email Address:"
            AssociatedControlID="ForgotEmail"
            runat="server"></asp:Label><br />
                                    <asp:RequiredFieldValidator ID="Require_EmailText" runat="Server" ControlToValidate="ForgotEmail"
                                        ErrorMessage="Email is missing.<br>" CssClass="RequiredText" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Validate_EmailText" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="The email address is not in an acceptable format. (user@domain.com)<br>"
                                        Display="Dynamic" ControlToValidate="ForgotEmail" CssClass="RequiredText"></asp:RegularExpressionValidator>
                                    <asp:TextBox ID="ForgotEmail" runat="server" Width="300px" class="forminput"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="mainBody" align="right">
                                    <asp:Button ID="SendEmailButton" runat="server" Text="Send" Width="80px" OnClick="OnSendEmail" />
                                </td>
                            </tr>
                        </table>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="pChangeCode" runat="server" Visible="False">
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td class="mainBody">
                                    <i>To change your password, you need to provide the information below. Once you have
                                        entered the data required, click on the 'Change Password' button located at the
                                        bottom of this page. </i>
                                    <br />
                                    <br />
                                   <asp:Label ID="Label1"
            text="Email Address:"
            AssociatedControlID="ChangeEmailUsingCode"
            runat="server"></asp:Label><br />
                                    <asp:TextBox ID="ChangeEmailUsingCode" runat="server" Width="300px" CssClass="forminput"
                                        ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td class="mainBody">
                                    <asp:PlaceHolder ID="PasswordPlaceHolder" runat="server">
                                        <asp:Label ID="OldPasswordLabel"
            text="Old Password:"
            AssociatedControlID="OldPasswordTextBox"
            runat="server"></asp:Label><br />
                                        <asp:TextBox ID="OldPasswordTextBox" runat="server" Width="300px" TextMode="Password"
                                            CssClass="forminput"></asp:TextBox>
                                        <br />
                                        <br />
                                    </asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                        <br>
                        <table border="0" cellpadding="0" cellspacing="0" width="400">
                            <tr>
                                <td>
                                    <fieldset>
                                        <legend><span style="font-weight: bold; font-size: 10pt; color: #000000;">What should
                                            your new password be?&nbsp;</span></legend>
                                        <table border="0" cellspacing="0" cellpadding="4">
                                            <tr>
                                                <td class="mainBody" width="150" nowrap>
                                                    <asp:Label ID="NewPasswordLabel"
            text="New Password:"
            AssociatedControlID="TNewPassUsingCode"
            runat="server"></asp:Label><br />
                                                    <asp:RequiredFieldValidator ID="PasswordValidatorUsingCode" runat="Server" ControlToValidate="TNewPassUsingCode"
                                                        ErrorMessage="A valid password is required.<br>" Display="Dynamic" Font-Size="9pt"></asp:RequiredFieldValidator>
                                                    <asp:TextBox ID="TNewPassUsingCode" runat="server" Width="150" TextMode="Password"
                                                        CssClass="forminput"></asp:TextBox>
                                                </td>
                                                <td width="10" nowrap>
                                                    &nbsp;
                                                </td>
                                                <td rowspan="2" class="mainBody" width="100%" valign="top">
                                                    Choose your new password carefully. We recommend using a password that has at least
                                                    5 characters that are alpha-numeric.
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="mainBody">
                                                    <asp:Label ID="ConfirmPasswordLabel"
            text="Confirm New Password:"
            AssociatedControlID="TConfirmPassUsingCode"
            runat="server"></asp:Label><br />
                                                    <asp:CompareValidator ID="ComparePasswordUsingCode" runat="Server" ErrorMessage="The password entered must match!<br>"
                                                        ControlToValidate="TNewPassUsingCode" ControlToCompare="TConfirmPassUsingCode"
                                                        Display="Dynamic"></asp:CompareValidator>
                                                    <asp:TextBox ID="TConfirmPassUsingCode" runat="server" Width="150" TextMode="Password"
                                                        CssClass="forminput"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <br />
                                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" Width="150px"
                                        OnClick="OnChangePassword" />
                                </td>
                            </tr>
                        </table>
                    </asp:PlaceHolder>
                    <br />
                    <br />
                    <asp:PlaceHolder ID="pMessage" runat="server" Visible="False">
                        <asp:Label ID="labelMessageHeader" runat="server" Text="Label"></asp:Label>
                        <hr />
                        <asp:Label ID="labelMessageDetail" runat="server"></asp:Label>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>
    </asp:PlaceHolder>
</asp:Content>

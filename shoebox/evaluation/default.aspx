<%@ Page Language="c#" Inherits="tx_r16.Shoebox.Evaluation.Pages.DefaultPage" EnableViewState="False"
    EnableViewStateMac="False" CodeFile="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 Transitional//EN" >
<html lang="en" xml:lang="en">
<head>
    <title>escWorks® .NET Evaluation Form</title>
    <link href="../../lib/css/local.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/jscript">
			function Page_OnInit()
			{
				<asp:PlaceHolder ID="pCloser" Runat="Server" Visible="False">self.close();</asp:PlaceHolder>
			}
			
			function SendPage()
			{
				if(!Page_ClientValidate())
					return;
					
				//
				// Submit the form
				document.EvaluationForm.submit();
			}
    </script>
</head>
<body onload="Page_OnInit();" style="margin: 0px;">
    <table cellspacing="0" cellpadding="0" width="100%" height="100%" border="0">
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
                &nbsp;<img src="../../lib/standard/img/Evaluation.gif" width="32" height="32" alt=""
                    border="0" align="absMiddle" />
            </td>
            <td bgcolor="#ffffff">
                <span style="font-weight: bold; font-size: 12pt; color: #191970">
                    <asp:Label ID="ctrlFormTitle" runat="Server" /></span><br>
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
        <tr valign="middle">
            <td colspan="2">
                <asp:PlaceHolder ID="pIFrameContent" runat="server"></asp:PlaceHolder>
            </td>
        </tr>
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
                &nbsp;<img src="../../lib/standard/img/secure.gif" width="32" height="32" alt=""
                    border="0" align="absMiddle" />
            </td>
            <td bgcolor="#ffffff">
                <span style="font-weight: bold; font-size: 8pt; color: #191970">escWorks<small><sup>&reg;</sup></small>
                    .NET Evaluation Form &copy; 2015 </span>
                <br />
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
    </table>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personal.aspx.cs" Inherits="shoebox_transcripts_personal"
    MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody">

<script type="text/javascript">
function CheckForOther(ddlControl)
	{
		if(ddlControl[ddlControl.selectedIndex].value == "0")
		{
			//
			// They need the option to enter the credit
			// name for the report.
			document.aspnetForm['<%# txtCreditName.UniqueID %>'].disabled = false;
		}
		else
		{
			//
			// A valid credit name already exists
			document.aspnetForm['<%# txtCreditName.UniqueID %>'].disabled = true;
			document.aspnetForm['<%# txtCreditName.UniqueID %>'].value = "";
		}
	}
	
	function RemoveCredit(creditID)
	{
	if(confirm("Are you sure you want to remove this credit?"))
	{
	    document.aspnetForm['<%# hiddenField.UniqueID %>'].value = creditID;
	    document.forms[0].submit();
	}
	}
</script>

    <table style="border-collapse: collapse; border: solid 1px gray; vertical-align: top;" align="center">
        <tr>
            <td colspan="2" valign="top">
                <asp:Label ID="TitleLabel"
                    text="Title:"
                    AssociatedControlID="txtTitle"
                    runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="DateLabel"
                    text="Date:"
                    AssociatedControlID="txtDate"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="bottom">
                <asp:TextBox runat="server" ID="txtTitle" CssClass="forminput" Width="290px" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtDate" CssClass="forminput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar1" AlternateText="Calendar Button" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                    PopupButtonID="btnCalendar1" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="CreditTypeLabel"
                    text="Credit Type:"
                    AssociatedControlID="ddlCreditType"
                    runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="CreditNameLabel"
                    text="***Credit Name:"
                    AssociatedControlID="txtCreditName"
                    runat="server"></asp:Label>
                    </td>
            <td>
                <asp:Label ID="CreditEarnedlabel"
                    text="Credit Earned:"
                    AssociatedControlID="txtCreditEarned"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td><asp:DropDownList runat="server" ID="ddlCreditType" CssClass="formInput"  OnChange="CheckForOther(this);"/></td>
        <td><asp:TextBox runat="server" ID="txtCreditName" CssClass="formInput" /></td>
        <td><asp:TextBox runat="server" ID="txtCreditEarned" CssClass="forminput" /></td>
        </tr>
        <tr>
        <td colspan="3">
        <span style="font-size: smaller; font-style: italic;">*** When the credit type 'Other' is selected, you have the option of entering a custom credit type. </span><br /><asp:Label runat="server" id="lblError" CssClass="error" /><br />
        <asp:Button runat="server" ID="btnAddCredit" Text="Add Credit" CssClass="formInput" /></td>
        </tr>
    </table>
    <br /><br />
    <table style="border-collapse: collapse; border: solid 1px gray; width: 100%">
    <tr>
    <td> <asp:Label ID="StartDateLabel"
        text="Start Date:"
        AssociatedControlID="txtStartDate"
        runat="server"></asp:Label>
        <asp:TextBox runat="server" ID="txtStartDate" CssClass="formInput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar2" alt="Start Date Calendar Button" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                    PopupButtonID="btnCalendar2" /> - 
        <asp:Label ID="EndDateLabel"
            text="End Date:"
            AssociatedControlID="txtEndDate"
            runat="server"></asp:Label>
        <asp:TextBox runat="server" ID="txtEndDate" CssClass="formInput" />&nbsp;<asp:ImageButton
                    runat="server" ID="btnCalendar3" AlternateText="End Date Calendar Button" ImageUrl="~/lib/img/buttons/calendar.png" />
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEndDate"
                    PopupButtonID="btnCalendar3" />&nbsp;<asp:Button runat="server" ID="btnGo" Text="Go" CssClass="formInput" /> &nbsp;
                    <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="formInput" />&nbsp;<asp:CheckBox 
            runat="server" ID="chkIncludeOffical" Text="Include Official Credits" Visible= "false"   /></td>
    </tr>
    <tr><td><asp:PlaceHolder runat="server" ID="pTableResults" /></td></tr>
    </table>
    
    <asp:HiddenField runat="server" id="hiddenField" />
</asp:Content>

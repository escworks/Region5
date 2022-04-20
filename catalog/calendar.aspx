<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="calendar.aspx.cs" Inherits="catalog_calendar" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
<br />
<table width="100%" style="border-collapse: collapse;">
<%-- 
<tr>
<td colspan="2"><asp:Label runat="server" ID="lblCalendarTitle" /></td>
</tr>
<tr>
<td align="left"><asp:DropDownList runat="server" ID="ddlMonthList" /> <asp:DropDownList runat="server" ID="ddlYearList" /> <asp:ImageButton runat="server" ID="btnSetDate" AlternateText="Go" /></td>
<td align="right"><asp:ImageButton runat="server" ID="btnPrevious" AlternateText="Previous Month" /> <asp:ImageButton runat="server" ID="btnNext" AlternateText="Next Month" /></td>
</tr>
--%>
<tr>
<td colspan="2"><escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;" SetDateText="Go"  /></td>
</tr>
</table>

</asp:Content>


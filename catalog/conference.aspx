<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="conference.aspx.cs" Inherits="catalog_conference" Title="Untitled Page" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server">
<asp:Label runat="server" ID="txtTitle" CssClass="heading" />
<br />
<asp:Label runat="server" ID="txtDescription" Font-Italic="true" />
<br /><br />
<asp:PlaceHolder ID="plttess" runat="server" Visible="false">
<b>T-TESS/T-PESS:</b><br />
<asp:Label runat="server" ID="libT_PRESS" Font-Italic="true" /><br /><br />
</asp:PlaceHolder>
<escWorks:ConferenceSelection runat="server" ID="sessionDisplay" CollapseBreakoutByDefault="false" />
</asp:Content>


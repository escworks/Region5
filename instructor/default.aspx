<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="instructor_default"
    MasterPageFile="~/masterpage.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainBody">
    <script type="text/javascript" language="javascript">
        function OnTabSelected(sender, args) {
            var hidField = document.getElementById("<%=hiddenFieldTabValue.ClientID%>");
            hidField.value = args.get_tab().get_value();
        }
    </script>
    <telerik:RadTabStrip ID="radTabStrip" AutoPostBack="true" runat="server" OnClientTabSelected="OnTabSelected" >
        <Tabs>
            <telerik:RadTab runat="server" Text="Upcoming Events" Value="FutureEvents" Selected="true">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Past Events" Value="PastEvents">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Online Event" Value="OnlineEvents">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <asp:PlaceHolder runat="server" ID="pPlaceHolder" />
    <asp:HiddenField ID="hiddenFieldTabValue" runat="server" Value="FutureEvents" />
    <script language="javascript" type="text/javascript">
        function getAttendee(param) {
            window.open('instructor.aspx?session_id=' + param, '_blank', 'width=900, height=650, resizable=1');
        }
    </script>
</asp:Content>

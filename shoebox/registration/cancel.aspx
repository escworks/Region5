<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cancel.aspx.cs" Inherits="shoebox_registration_cancel" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainBody">

    <script language="javascript" type="text/javascript">
        function CancellationMessage() {

            alert("Cancellations must be completed online or sent to cancellations@esc5.net no later than 7 calendar days prior to event. "
                    + " Phone cancellations are not accepted. Registrations are transferrable if there is another workshop at a later date."
                    + " A cancellation fee of $10.00 will be charged if workshop is cancelled 1-6 days prior to event. No refunds for online courses, or nonattendance. Participants will receive a full refund for events cancelled by Region 5 Education Service Center.");
        }

    </script>

    <asp:Panel runat="server" ID="pCancelDetails" Visible="true">
        <br />
        <br />
        This is the registration cancellation page. Please read the message below before
        continuing.
        <br />
        <br />
        <table width="100%" align="center">
            <tr>
                <td class="forminput">
                    <b>Cancellation and Refund Policy:
                        <br />
                    </b>Cancellations <b>must</b> be completed online or sent to  <a href=mailto:cancellations@esc5.net?subject=escWorks%20Registration%20Cancellation:%20<%= participantName %>,%20<%= sessionID %>,%20<%= title %>>  cancellations@esc5.net</a>no later than 7 calendar days prior to event.<br>
                    <br />
                    Phone cancellations are not accepted. Registrations are transferrable if there is another workshop at a later date.
                    <br />
                    A cancellation fee of $10.00 will be charged if workshop is cancelled 1-6 days prior to event. No refunds for online courses, or nonattendance. 
                    Participants will receive a full refund for events cancelled by Region 5 Education Service Center.
                </td>
            </tr>
        </table>
        <br />
        You are currently registered for:
        <br />
        <br />
        <div style="width: 75%; background-color: #f5f5f5; border: solid 1px gray">
            <asp:Label runat="server" ID="lblTitle" CssClass="mainBodyBold" />
            <br />
            <asp:Label runat="server" ID="lblDescription" CssClass="mainBodySmall" />
            <br />
            <b>
                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                ID:</b>
            <asp:Label runat="server" ID="lblSessionID" />
            <br />
            <b>Fee:</b>
            <asp:Label runat="server" ID="lblFee" />
            <br />
            <b>Start Date: </b>
            <asp:Label runat="server" ID="lblStartDate" />
            <br />
            <b>Location:</b>
            <asp:Label runat="server" ID="lblLocation" />
            <br />
            <br />
        </div>
        <br />
        <br />
        By clicking on 'Cancel Registration', you will be removed from the
        <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>
        listed above. Depending on your payment status and the number of days before this
        <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>, you maybe eligible
        for a refund. For more information please contact Registration Services.
        <br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Cancel Registration" CssClass="formInput" />
        <input type="button" onclick="javascript:history.back()" title="Previous Page" value="Previous Page"
            class="formInput" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pUnavailable" Visible="false">
        The cancellation period for this session has passed.
        <br />
        <a class="link" onclick="javascript:history.back()">Click here</a> to return to
        the previous page.
    </asp:Panel>
    <asp:Panel runat="server" ID="pSuccess" Visible="false">
        <br />
        <br />
        You have been successfully removed from:
        <br />
        <br />
        <b>Title: </b>
        <asp:Label runat="server" ID="lblTitle2" />
        <br />
        <b>
            <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
            ID:</b>
        <asp:Label runat="server" ID="lblSessionId2" />
        <br />
        <b>Start Date:</b>
        <asp:Label runat="server" ID="lblStartDate2" />
        <br />
        <b>Location: </b>
        <asp:Label runat="server" ID="lblLocation2" />
        <br />
        <br />
        <a id="A1" runat="server" href="~/shoebox/registration/default.aspx">
            <img id="Img1" runat="server" style="border: none;" src="~/lib/img/buttons/next.png"
                alt="Return to Registration Summary" /></a>
        <br />
    </asp:Panel>
    <asp:Panel runat="server" ID="pAdmin" Visible="false">
        Please contact Region 5 Registration Services to cancell out Online session from
        Administrative site.
        <br />
        <br />
        <a class="link" onclick="javascript:history.back()">Click here</a> to return to
        the previous page.
    </asp:Panel>
    <asp:Panel runat="server" ID="pError" Visible="false">
        An error occurred while processing your request.
        <br />
        <br />
        <a class="link" onclick="javascript:history.back()">Click here</a> to return to
        the previous page.
    </asp:Panel>
</asp:Content>

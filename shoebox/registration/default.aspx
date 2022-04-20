<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="shoebox_registration_default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content runat="server" ContentPlaceHolderID="mainBody" ID="content1">

    <script language="javascript" type="text/javascript">
        function OpenTraining(strOrgOrAtt, thisLinkButton) {

            // open training content; <strOrgOrAtt> is either of the form "Org:<organizationId>"
            // (for content that has not been launched yet) or "Att:<attemptId>" for content that's
            // previously been launched -- in the former case we need to create an attempt for the
            // content...
            var a;
            if ((a = strOrgOrAtt.match(/^Org:([0-9]+)$/)) != null) {

                thisLinkButton.disable = true;
                // display the dialog to create an attempt on this organization; if the attempt is
                // successfully created, OnAttemptCreated() will be called from the the dialog to
                // update TrainingGrid and display the training
                var args = new Object;
                args.OrganizationId = a[1];
                args.OnAttemptCreated = OnAttemptCreated;
                window.ThisLinkButton = thisLinkButton;

                ShowDialog("../../Scorm/CreateAttempt.aspx", args, 450, 250, false);
            }
            else
                if ((a = strOrgOrAtt.match(/^Att:([0-9]+)$/)) != null) {
                // open training in a new window
                OpenFramesetOrganization(a[1]);
            }
        }
        function OnAttemptCreated(strAttemptId) {
            // called after CreateAttempt.aspx has successfully created an attempt; update the
            // anchor tag to include the attempt number, then open the frameset

            // open the frameset for viewing training content; <strAttemptId> is the attempt ID
            window.open("Frameset/Frameset.aspx?View=0&AttemptId=" + strAttemptId, "_blank",
			            "status=yes,toolbar=no,menubar=no,resizable=yes,location=no");
            window.ThisLinkButton.onclick = function() { OpenTraining("Att:" + strAttemptId, window.ThisLinkButton); return false; }
            window.ThisLinkButton.disable = false;
        }

        function OpenFramesetOrganization(strAttemptId) {
            // open the frameset for viewing training content; <strAttemptId> is the attempt ID
            window.open("../../Scorm/Frameset/Frameset.aspx?View=0&AttemptId=" + strAttemptId, "_blank",
			            "status=yes,toolbar=no,menubar=no,resizable=yes,location=no");
        }

        function ShowLog(strAttemptId) {
            // displays the sequencing log for this attempt
            ShowDialog("../../Scorm/SequencingLog.aspx?AttemptId=" + strAttemptId, null, 900, 650, true);
        }

        function ShowDialog(strUrl, args, cx, cy, fScroll) {
            // display a dialog box with URL <strUrl>, arguments <args>, width <cx>, height <cy>,
            // scrollbars if <fScroll>; this can be done using either showModalDialog() or
            // window.open(): the former has better modal behavior; the latter allows selection
            // within the window
            var useShowModalDialog = false;
            var strScroll = fScroll ? "yes" : "no";
            if (useShowModalDialog) {
                showModalDialog(strUrl, args,
				    "dialogWidth: " + cx + "px; dialogHeight: " + cy +
					"px; center: yes; resizable: yes; scroll: " + strScroll + ";");
            }
            else {
                dialogArguments = args; // global variable accessed by dialog
                var x = Math.max(0, (screen.width - cx) / 2);
                var y = Math.max(0, (screen.height - cy) / 2);
                window.open(strUrl, "_blank", "left=" + x + ",top=" + y +
					",width=" + cx + ",height=" + cy +
					",location=no,menubar=no,scrollbars=" + strScroll +
					",status=no,toolbar=no,resizable=yes");
            }
        }

    </script>

    <script type="text/javascript" language="javascript">
        function OnClientRated(controlRating, args) {
            var toolTipControlId = controlRating.get_element().getAttribute("ToolTipControlId");
            var toolTipClientId = "ctl00_mainBody_regHistory_" + toolTipControlId;
            var tooltip = $find(toolTipClientId);
            tooltip.show();
        }

        function CloseCurrentToolTip() {
            var tooltip = Telerik.Web.UI.RadToolTip.getCurrent();
            if (tooltip) {
                tooltip.hide();
            }
        }

        function OnClientPostComment(buttonControl) {
            var attendee_pk = buttonControl.getAttribute("attendee_pk");

            var RatingID = buttonControl.getAttribute("RatingID");
            var RatingClientID = "ctl00_mainBody_regHistory_" + RatingID;
            var RatingControl = $find(RatingClientID);

            var CommentsID = buttonControl.getAttribute("CommentsID");
            var CommentsClientID = "ctl00_mainBody_regHistory_" + CommentsID;
            var commentsControl = document.getElementById(CommentsClientID);

            var LabelCommentsID = buttonControl.getAttribute("LabelCommentsID");
            var LabelCommentsClientID = "ctl00_mainBody_regHistory_" + LabelCommentsID;
            var LabelCommentsControl = document.getElementById(LabelCommentsClientID);
            LabelCommentsControl.innerHTML = commentsControl.value;

            PageMethods.PostComment(attendee_pk, RatingControl.get_value(), commentsControl.value, null);

            CloseCurrentToolTip();            
        }
            
    </script>

    <br />
    <br />

    <script type="text/javascript" language="javascript">
        function OnTabSelected(sender, args) {
            var hidField = document.getElementById("<%=hiddenFieldTabValue.ClientID%>");
            hidField.value = args.get_tab().get_value();
        }
    </script>

    <telerik:RadTabStrip ID="radTabStrip" AutoPostBack="true" runat="server" OnClientTabSelected="OnTabSelected">
        <Tabs>
            <telerik:RadTab runat="server" Text="Upcoming Events" Value="FutureEvents" Selected="true">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Past Events" Value="PastEvents">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="WaitingList" Value="WaitingList">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Online Event" Value="OnlineEvents">
                <Tabs>
                    <telerik:RadTab runat="server" Text="In Progress" Value="OnlineInProgress" Selected="true">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Complete" Value="OnlineComplete">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Incomplete" Value="OnlineIncomplete">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <asp:HiddenField ID="hiddenFieldTabValue" runat="server" Value="FutureEvents" />
    <escWorks:RegistrationHistory runat="server" ID="regHistory" />    
</asp:Content>

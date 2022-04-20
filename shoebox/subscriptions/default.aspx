<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="shoebox_subscriptions_default"
    EnableEventValidation="false" MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainBody">
    <script language="javascript" type="text/javascript">
        // Global variables
        // -------------------------
        // Written by: Andrew Lieng
        // -------------------------
        var http = createRequestObject();
        objElement = new Object();
        var responseUrl = "default.aspx";

        // Create an XMLHttpRequest for IE, Mozilla, and Safari browswers
        // -------------------------
        // Written by: Andrew Lieng
        // -------------------------
        function createRequestObject() {
            var ro;
            var browser = navigator.appName;
            if (browser == "Microsoft Internet Explorer") {
                ro = new ActiveXObject("Microsoft.XMLHTTP");
            } else {
                ro = new XMLHttpRequest();
            }
            return ro;
        }

        function SaveSubscription() {
            var dd1 = document.getElementById('ctl00_mainBody_ddSubscribed');
            var dd2 = document.getElementById('ctl00_mainBody_ddRecommended');

            var xmlString = '<?xml version="1.0" encoding="utf-8"?>';
            xmlString += '<xmlData>';

            xmlString += '<Item><Subscribed>' + dd1.options[dd1.selectedIndex].value + '</Subscribed></Item>';
            xmlString += '<Item><Recommended>' + dd2.options[dd2.selectedIndex].value + '</Recommended></Item>';

            var listBox2 = $find("<%= lsbSubscription2.ClientID %>");
            var items = listBox2.get_items();

            for (var i = 0; i < items.get_count(); i++) {
                xmlString += '<Item><Key>' + listBox2.getItem(i).get_value() + '</Key></Item>';
            }

            xmlString += '</xmlData>';

            http.open('post', responseUrl + '?action=SaveSubscription', true);
            //	http.setRequestHeader('Content-Type','text/xml');
            http.onreadystatechange = handleSaveSubscription;
            http.send(xmlString);
        }

        function SaveSubscriptionWithoutRecomanded() {
            var listBox2 = document.getElementById('ctl00_mainBody_lsbSubscription2');
            var dd1 = document.getElementById('ctl00_mainBody_ddSubscribed');
            var dd2 = document.getElementById('ctl00_mainBody_ddRecommended');

            var xmlString = '<?xml version="1.0" encoding="utf-8"?>';
            xmlString += '<xmlData>';

            xmlString += '<Item><Subscribed>' + dd1.options[dd1.selectedIndex].value + '</Subscribed></Item>';
            //    xmlString += '<Item><Recommended>' + dd2.options[dd2.selectedIndex].value + '</Recommended></Item>';

            //for loop
            for (var i = listBox2.options.length - 1; i > -1; i--) {
                xmlString += '<Item><Key>' + listBox2.options[i].value + '</Key></Item>'
            }

            xmlString += '</xmlData>';

            http.open('post', responseUrl + '?action=SaveSubscription', true);
            //	http.setRequestHeader('Content-Type','text/xml');
            http.onreadystatechange = handleSaveSubscription;
            http.send(xmlString);
        }

        function handleSaveSubscription() {

            // Loaded
            if (http.readyState == 4) {
                // OK
                if (http.status == 200) {
                    var response = http.responseXML;
                    document.getElementById('SaveStatus').innerText = response.getElementsByTagName('Response')[0].firstChild.data;

                    var response = http.responseText;
                    //	document.getElementById('SaveStatus').innerText = response;
                    setTimeout(ClearStatus, 3000);
                }
                else {
                    alert("Problem retrieving XML data from server.");
                }
            }
            else {
                document.getElementById('SaveStatus').innerText = 'Saving...';
                setTimeout(ClearStatus, 3000);
            }
        }

        function ClearStatus() {
            document.getElementById('SaveStatus').innerText = '';
        }

        function Cancel() {
            top.location.href = "../Default.aspx";
        }
    </script>
    <table border="0" cellpadding="4" cellspacing="0" width="100%">
        <tr>
            <td class="mainBody">
                Use the subscriptions area to request email notifications when new
                <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
                of interest are made available.
            </td>
        </tr>
    </table>
    <div align="center">
        <table>
            <tr>
                <td class="mainBody">
                    Subjects
                </td>
                <td class="mainBody">
                    Subscription List
                </td>
            </tr>
            <tr>
                <td class="mainBody">
                    <telerik:RadListBox ID="lsbSubscription1" Width="300" Height="250" runat="Server"
                        SelectionMode="Multiple" CssClass="mainBody" AllowTransfer="true" AllowTransferOnDoubleClick="true"
                        EnableDragAndDrop="true" TransferToID="lsbSubscription2" >
                        <ButtonSettings AreaWidth="100" Position="Right" RenderButtonText="true" ShowTransferAll="false" />
                        <Localization  ToLeft="Remove" ToRight="Add" AllToLeft="Remove All" AllToRight="Add All"/>
                    </telerik:RadListBox>
                </td>
                <td class="mainBody">
                    <telerik:RadListBox ID="lsbSubscription2" Width="200" Height="250" runat="Server"
                        SelectionMode="Multiple" CssClass="mainBody" AllowTransferOnDoubleClick="true"
                        EnableDragAndDrop="true" />
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td class="mainBody" colspan="2">
                    <font color="red"><span id="SaveStatus"></span></font>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td class="mainBody" align="left" colspan="2">
                    <asp:Label ID="SubscriptionStatusLabel"
                        text="Subscription status:&nbsp;&nbsp;"
                        AssociatedControlID="ddSubscribed"
                        runat="server"></asp:Label>
                    <asp:DropDownList ID="ddSubscribed" runat="Server"
                        CssClass="DropDownList">
                        <asp:ListItem Value="1">Subscribed</asp:ListItem>
                        <asp:ListItem Value="0">Unsubscribed</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td class="mainBody" align="left" colspan="2">
                    <asp:label ID="RecommendedEventsLabel"
                        text="Would you like to receive Recommended Events by email?&nbsp;&nbsp;"
                        AssociatedControlID="ddRecommended"
                        runat="server"></asp:label>
                        <asp:DropDownList
                        ID="ddRecommended" runat="Server" CssClass="DropDownList">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="mainBody" align="left" colspan="3">
                    <font size="1" color="Gray"><i>(Recommended Events are based upon your prior participation.)</i></font>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td class="mainBody" align="left" colspan="2">
                    <input type="button" name="btnCancel" value="Cancel" class="Button" onclick="top.location.href='../../Default.aspx';" />
                    <input type="button" name="btnSave" value="Save Subscriptions" class="Button" onclick="SaveSubscription()" />
                </td>
            </tr>
            <tr>
                <td class="mainBody" colspan="3">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

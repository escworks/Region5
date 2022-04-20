<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="groupregistration.aspx.cs" Inherits="catalog_groupregistration"
    Title="Group Registration" ValidateRequest="false"%>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <script language="javascript" type="text/javascript">

        var timer;
        var count = 0;
        function DoSearch(value) {
            if (value.length < 1) return;
            window.clearTimeout(timer);
            count = count + 1;
            timer = window.setTimeout(function () { FilterItems(value, count); }, 250);
        }

        function FilterItems(value, currentcount) {
            if (currentcount == count) {
                count = 0;
                var hiddenFieldSessionID = document.getElementById("<%=hiddenFieldSessionID.ClientID%>");
                PageMethods.Search(hiddenFieldSessionID.value, value, OnSucceeded);
            }
        }

        function OnSucceeded(results) {

            var listBox1 = $find("<%= listBoxAvailableUsers.ClientID %>");
            var items = listBox1.get_items();
            listBox1.trackChanges();
            items.clear();
            for (var i = 0; i < results.length; i++) {

                var user = results[i].split("|");
                if (!AlreadyInSelectedListBox(user[0])) {
                    var item = new Telerik.Web.UI.RadListBoxItem();
                    item.set_text(user[1]);
                    item.set_value(user[0]);
                    items.add(item);
                }
            }
            listBox1.commitChanges();
        }

        function AlreadyInSelectedListBox(userSid) {
            var listBox2 = $find("<%= listBoxSelectedUsers.ClientID %>");
            var items = listBox2.get_items();
            for (var i = 0; i < items.get_count(); i++) {
                if (listBox2.getItem(i).get_value() == userSid)
                    return true;
            }
            return false;
        }

        function CheckAvailableSeats() {

            var listBox1 = $find("<%= listBoxAvailableUsers.ClientID %>");
            var listBox2 = $find("<%= listBoxSelectedUsers.ClientID %>");
            var hiddenFieldAvailableSeats = document.getElementById("<%=hiddenFieldAvailableSeats.ClientID%>");

            var items = listBox2.get_items();
            var selectedusersCount = items.get_count();

            if (selectedusersCount < 1) return false; //If no users selected, can not leave the page

            if (hiddenFieldAvailableSeats.value < selectedusersCount) {

                var OverLimit = selectedusersCount - hiddenFieldAvailableSeats.value;
                var warning = "Session has only " + hiddenFieldAvailableSeats.value + " seats available. You have selected "
                                + selectedusersCount + " users. Please remove "
                                + OverLimit + " users in order to continue checkout process.";
                alert(warning);
                return false;
            }
            else {
                var hiddenFieldSelectedUsers = document.getElementById("<%=hiddenFieldSelectedUsers.ClientID%>");
                for (var i = 0; i < selectedusersCount; i++) {
                    if (i == 0)
                        hiddenFieldSelectedUsers.value = items.getItem(i).get_value();
                    else
                        hiddenFieldSelectedUsers.value += "|" + items.getItem(i).get_value();
                }
                return true;
            }
        }

    </script>
    <table border="0" cellpadding="4" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblSessionID" />-<asp:Label runat="server" ID="lblTitle"
                    CssClass="mainBodyBold" /><br />
                <asp:HiddenField ID="hiddenFieldSessionID" runat="server" />
                <br />
                <asp:Label runat="server" ID="lblDescription" CssClass="mainBodySmall" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <div align="center">
        <table>
            <tr>
                <td>
                    <asp:Label ID="SearchBoxLabel"
                        text="Search users by name, email address, or school name (first 300 results)."
                        AssociatedControlID="txtSearch"
                        runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSearch" runat="server" Width="100%" onkeyup="DoSearch(this.value)">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="10">
                    <asp:HiddenField ID="hiddenFieldAvailableSeats" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="mainBody">
                    Available Users
                </td>
                <td class="mainBody">
                    Selected Users
                </td>
            </tr>
            <tr>
                <td class="mainBody">
                    <telerik:RadListBox ID="listBoxAvailableUsers" Width="440px" Height="250px" Style="text-align: left;"
                        runat="Server" SelectionMode="Multiple" AllowTransfer="true" AllowTransferOnDoubleClick="true"
                        EnableDragAndDrop="true" TransferToID="listBoxSelectedUsers">
                        <ButtonSettings AreaWidth="96" Position="Right" RenderButtonText="true" ShowTransferAll="true" />
                        <Localization  ToLeft="Remove" ToRight="Add" AllToLeft="Remove All" AllToRight="Add All"/>
                    </telerik:RadListBox>
                </td>
                <td class="mainBody">
                    <telerik:RadListBox ID="listBoxSelectedUsers" CssClass="mainBody" Style="text-align: left;"
                        runat="server" Width="340px" Height="250px" SelectionMode="Multiple" EnableDragAndDrop="true" />
                    <asp:HiddenField ID="hiddenFieldSelectedUsers" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="mainBody" colspan="2">
                    <font color="gray"><i>(Hold &lt;Ctrl&gt; for multiple selections. Double click or Drag&amp;Drop
                        to transfer.)</i></font>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td class="mainBody" align="left" colspan="3">
                </td>
            </tr>
        </table>
    </div>
    <input type="button" name="btnCancel" value="Cancel" class="Button" onclick="top.location.href='../Default.aspx';" />
    <asp:Button runat="server" ID="btnCheckout" Text="Continue" UseSubmitBehavior="true"
        OnClientClick="return CheckAvailableSeats();" />
</asp:Content>

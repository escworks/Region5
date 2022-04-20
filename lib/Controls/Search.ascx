<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Search" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .RadGrid A:hover
    {
        color: black;
    }
</style>
<script language="javascript" type="text/javascript">
    function OnClientSelectedIndexChanged(sender, eventArgs) {
        var item = eventArgs.get_item();
        var combo = $find("<%= ddItems.ClientID %>");
        var s, e, len;

        //sender.set_text("You selected " + item.get_text());
        if (item.get_value() == "9000") {
            s = getIndex('9000');
            e = getIndex('9001');
            len = e - s;
            check_unchecl_all(combo, item, s, e);
        }
        else if (item.get_value() == "9001") {
            s = getIndex('9001');
            e = getIndex('9002');
            check_unchecl_all(combo, item, s, e);
        }
        else if (item.get_value() == "9002") {
            s = getIndex('9002');
            e = getIndex('9003');
            check_unchecl_all(combo, item, s, e);
        }
        else if (item.get_value() == "9003") {
            s = getIndex('9003');
            e = getIndex('9004');
            check_unchecl_all(combo, item, s, e);
        }
        else if (item.get_value() == "9004") {
            s = getIndex('9004');
            e = combo.get_items().get_count();
            check_unchecl_all(combo, item, s, e);

        }
        //sender.set_text("");
    }

    function getIndex(i) {
        var combo = $find("<%= ddItems.ClientID %>");
        var items = combo.get_items();
      
        var itemsCount = items.get_count();
      
        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++) {
            var item = combo.get_items().getItem(itemIndex).get_value();
            if (item == i) { return itemIndex;}
        }
    }

    function check_unchecl_all(combo, item, s, e)
    {
            if (item.get_checked()) {
                for (var i = s; i < e - 1; i++) 
                    combo.get_items().getItem(i + 1).set_checked(true);
            }
            else {
                for (var i = s; i < e - 1; i++)
                    combo.get_items().getItem(i + 1).set_checked(false);
            }
    }

</script>

<table width="100%">
    <tr>
        <td>
            <table width="90%">
                <tr>
                    <td><asp:Label ID="SearchBoxLabel"
                        text="Search:"
                        AssociatedControlID="txtSearch"
                        runat="server"></asp:Label>
                        <telerik:RadTextBox ID="txtSearch" runat="server" Width="100%">
                        </telerik:RadTextBox>
                    </td>
                    <td><br />
                        <telerik:RadButton ID="btnSearch" runat="server" Text="Search" CausesValidation="false"
                            OnClick="btnSearch_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="btnReset" runat="server" Text="Reset" CausesValidation="false"
                            OnClick="btnReset_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkFF" runat="server" Text="Face-to-Face" Checked="true" Font-Size="X-Small"
                            Width="15%" />
                        <asp:CheckBox ID="chkVideo" runat="server" Text="Online" Checked="true" Font-Size="X-Small"
                            Width="10%" />

                         <asp:CheckBox ID="chkTETN" runat="server" Text="TETN" Checked="false" Font-Size="X-Small"
                            Width="10%" />
                         <asp:CheckBox ID="chkVideoConference" runat="server"  Text="Video Conferencing" Checked="false" Font-Size="X-Small"
                            Width="20%"/>

                        <asp:CheckBox ID="chkFree" runat="server" Text="Free" Font-Size="X-Small" Width="10%" />
                        <asp:CheckBox ID="chkWeekend" runat="server" Text="Weekend" Font-Size="X-Small" Width="20%" />
                    </td>
                </tr>
                <tr>
                   <td style="vertical-align:top;" colspan="2">
                        <font size="1">T-TESS/T-PESS:</font>
                        <telerik:RadComboBox ID="ddItems" runat="server" ToolTip="Please domains/dimensions/standards" CheckBoxes="true" CheckedItemsTexts="DisplayAllInInput" Width="460px" OnClientItemChecked="OnClientSelectedIndexChanged">
                            <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation> 
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="grdSearch" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                Skin="Outlook" CellPadding="0" Width="100%" GridLines="None" AllowPaging="True"
                PagerStyle-Position="TopAndBottom" BorderStyle="Solid" BorderColor="#0066FF">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <AlternatingItemStyle BackColor="#CFDDF3" />
                 <PagerStyle ChangePageSizeButtonToolTip="Change Page Size" 
                    ChangePageSizeComboBoxTableSummary="The table which holds the composite controls for the ChangePageSize RadComboBox control."
                    ChangePageSizeComboBoxToolTip="Change Page Size"
                    ChangePageSizeTextBoxToolTip="Change Page Size" GoToPageButtonToolTip="Go To Page"
                    GoToPageTextBoxToolTip="Go To Page" />
                <MasterTableView Width="100%" DataKeyNames="ID" Font-Size="X-Small" AllowMultiColumnSorting="false">
                    <SortExpressions>
                        <telerik:GridSortExpression FieldName="StartDate" SortOrder="Ascending" />
                    </SortExpressions>
                    <CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridHyperLinkColumn DataNavigateUrlFields="URL" DataTextField="ID" UniqueName="ID"
                            HeaderText="ID" DataNavigateUrlFormatString="{0}">
                            <HeaderStyle Width="6%" Font-Size="Small" />
                        </telerik:GridHyperLinkColumn>
                        <telerik:GridBoundColumn DataField="StartDate" DataFormatString="{0:d}" UniqueName="StartDate"
                            HeaderText="Start Date" AllowSorting="true" ShowSortIcon="true" AllowFiltering="false"
                            Groupable="false" Reorderable="false" Visible="true">
                            <HeaderStyle Width="10%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Title" UniqueName="Title" HeaderText="Title"
                            AllowSorting="true" ShowSortIcon="true" AllowFiltering="false" Groupable="false"
                            Reorderable="false" Visible="true">
                            <HeaderStyle Width="30%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DescriptionDisplay" UniqueName="DescriptionDisplay"
                            HeaderText="Description" AllowSorting="false" AllowFiltering="false" Groupable="false"
                            Reorderable="false" Visible="true">
                            <HeaderStyle Width="40%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EventTypeDisplay" UniqueName="EventTypeDisplay" HeaderText="Type"
                            AllowSorting="true" ShowSortIcon="true" AllowFiltering="false" Groupable="false"
                            Reorderable="true" Visible="true">
                            <HeaderStyle Width="14%" Font-Size="Small" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
            <asp:Label ID="lbError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>

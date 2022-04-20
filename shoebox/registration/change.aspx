<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change.aspx.cs" Inherits="shoebox_registration_change"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainBody">
    <asp:Panel runat="server" ID="pChangeDetail" Visible="false">
        This is the change registration page. It allows you to change your current registration
        to a
        <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>
        that has the same cost, but occurs at a different date, time, or location. <em>Once
            you have submitted this page, you will be removed from the current
            <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>
            and registered for the new
            <%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>
            .</em>
        <br />
        <br />
        <asp:Label runat="server" ID="lblTitle" CssClass="mainBodyBold" />
        <br />
        <asp:Label runat="server" ID="lblDescription" CssClass="mainBodySmall" />
        <br />
        <br />
        <table class="mainBody">
            <tr>
                <td>
                    Current
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized %>
                </td>
                <td>
                    Available
                    <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralNameCapitalized %>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="width: 75%; background-color: #f5f5f5; border: solid 1px gray">
                        <b>
                            <%# region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized%>
                            ID:</b>
                        <asp:Label runat="server" ID="lblSessionID" />
                        <br />
                        <b>Fee: </b>
                        <asp:Label runat="server" ID="lblFee" />
                        <br />
                        <b>Start Date: </b>
                        <asp:Label runat="server" ID="lblStartDate" />
                        <br />
                        <b>Location: </b>
                        <asp:Label runat="server" ID="lblLocation" />
                    </div>
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblSessions" CssClass="mainBody" />
                    <br /><asp:Label runat="server" ID="lblNoSessions" CssClass="mainBody" Text="There are no available sessions" /></td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Change Registration" 
            CssClass="formInput" />
        <input type="button" onclick="javascript:history.back()" title="Previous Page" value="Previous Page"
            class="formInput" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pSuccess" Visible="false">
  
    <b>Your registration has been successfully changed.</b>  <br />
  Be sure to print out a confirmation page that indicates the change was made.
<br /><br /><a runat="server" href="~/shoebox/registration/default.aspx" class="link">Return to Registration History</a>      
    </asp:Panel>
    <asp:Panel runat="server" ID="pError" Visible="false">
  <b>An error occurred while processing your request</b>  
<br />Please contact registration services for assistance.
<br /><br /><a id="A1" runat="server" href="~/shoebox/registration/default.aspx" class="link">Return to Registration History</a>      
    </asp:Panel>
    <asp:Panel runat="server" ID="pUnavailable" Visible="false">
    The registration change period was passed.  Please contact registration services for assistance.
  <br /><br /><a id="A2" runat="server" href="~/shoebox/registration/default.aspx" class="link">Return to Registration History</a>        
    </asp:Panel>
</asp:Content>

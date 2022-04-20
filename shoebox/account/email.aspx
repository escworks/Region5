<%@ Page Language="C#" AutoEventWireup="true" CodeFile="email.aspx.cs" Inherits="shoebox_account_email" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="mainBody">
<asp:Panel runat="server" ID="pStep1">
    If your email address needs to be changed provide your old email address and 
    password to specify a new email address.
<br /><br /><%--<label for="txtEmailAddres">--%>
    <asp:Label ID="CurrentEmailLabel"
        text="Current Email Address:"
        AssociatedControlID="txtEmailAddress"
        runat="server"></asp:Label>
        <%--</label>--%>
    <br />
<asp:TextBox runat="server" ID="txtEmailAddress" Enabled="false" 
        CssClass="formInput" Width="216px" />
<br /><br />
    <%--<label for="txtNewEmail">--%>
    
    <asp:Label ID="NewEmailLabel"
        text="New Email Address:"
        AssociatedControlID="txtNewEmail"
        runat="server"></asp:Label>
        <%--</label>--%><br />
<asp:TextBox runat="server" ID="txtNewEmail" CssClass="formInput" Width="216px" />
<br /><br />
    <%--<Label for="txtNewEmail2">--%>
    <asp:Label ID="ConfirmEmailLabel"
        text="Confirm Email Address:"
        AssociatedControlID="txtNewEmail2"
        runat="server"></asp:Label>
        <%--</Label>--%><br />
<asp:TextBox runat="server" ID="txtNewEmail2" CssClass="formInput" Width="215px" />
<br /><br />
<asp:Label runat="server" id="lblError" CssClass="error" />
    <br />
<asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="formInput" />
</asp:Panel>
<asp:Panel runat="server" ID="pStep2" Visible="false">
You have successfully saved the changes to your account!<br /><a id="A1" href="~/default.aspx" runat="server" class="link">Please click here to continue</a>
</asp:Panel>
</asp:Content>


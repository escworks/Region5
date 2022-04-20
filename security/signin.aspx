<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="security_signin" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody">
    <div>
    
    <h1 class="heading">Account Sign-in</h1><br />
   
   <table border=0>
   <tr><td style="width: 144px">
       <asp:Label ID="UserNameLabel"
           text="E-mail Address:"
           AssociatedControlID="txtUserName"
           runat="server"></asp:Label>

       </td><td> <asp:TextBox runat="server" 
           ID="txtUserName" Width="220px" /></td></tr>
   <tr><td style="width: 144px">
       <asp:Label ID="PasswordLabel"
           text="Password:"
           AssociatedControlID="txtPassword"
           runat="server"></asp:Label>

       </td><td> <asp:TextBox runat="server" 
           ID="txtPassword" TextMode="Password" Width="220px" /></td></tr>
   </table>
    
    <br />
    <asp:Label runat="server" ID="lblMessage" CssClass="error" />
    <a id="A1" href="~/shoebox/account/signup.aspx" runat="server" class="link">Create a new account, click here</a>
   <br />
   If you have  <a href="../shoebox/account/password.aspx?mode=forgot" class="link">
							<b><i>forgotten your password</i></b>, click here</a>.
        <br />
    <br />
    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
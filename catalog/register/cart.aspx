<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="cart.aspx.cs" Inherits="catalog_register_cart" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <escWorks:CartDisplay runat="server" ID="cartDisplay1" DisplayRemoveButton="true"  />
    <br />
    <br />
   
<asp:Panel runat="server" ID="pPromoCode">
    Promotional Code:
    <asp:TextBox runat="server" ID="txtPromoCode" />
    <asp:Button runat="server" ID="btnApplyCode" Text="Apply Code" />

    </asp:Panel><br /><br /><br />
    <asp:ImageButton runat="server" alt="Checkout Button" ID="btnCheckOut" />    
</asp:Content>  

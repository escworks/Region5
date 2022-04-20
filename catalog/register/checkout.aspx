<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="checkout.aspx.cs" Inherits="catalog_register_checkout" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" runat="Server">
    <br />
    <br />
    <asp:Label runat="server" ID="lblErrorMessage" CssClass="error" />
    <br />
    <asp:Panel ID="panelCheckoutMsg" runat="server">
    <span style="font-size: 1.25em">Click the 'Complete Checkout' button to register for
        the
        <%# region4.escWeb.SiteVariables.ObjectProvider.SessionPluralName %>
        displayed below.</span></asp:Panel>
    <br />
    <br />
    <escWorks:CartDisplay runat="server" ID="cart1" DisplayRemoveButton="false" />
 <b>Cancellation and Refund Policy: </b>
    <br />
    Cancellations <b>must</b> be completed online or sent to <a href=mailto:account@esc5.net>cancellations@esc5.net</a> no later than 7 calendar days prior to event.<br />
    <br />
   Phone cancellations are not accepted. Registrations are transferrable if there is another workshop at a later date.
    <br />
  A cancellation fee of $10.00 will be charged if workshop is cancelled 1-6 days prior to event.
  No refunds for online courses, or nonattendance.
  Participants will receive a full refund for events cancelled by Region 5 Education Service Center.
    <br />
    <br />
    <br />
    <br />
    <asp:Label runat="server" ID="lblPaymentPrompt" Text="Please select a method of payment to continue" />
    <br />
    <table class="mainBody">
        <tr >
            <td>
                <asp:RadioButtonList runat="server" ID="rblPaymentList" AutoPostBack="true" CssClass="mainBody">
                    
                   <%-- <asp:ListItem Text="Money Order" Value="MO" />--%>
                    <asp:ListItem Text="Purchase Order" Value="PO" />
                    <asp:ListItem Text="Credit Card" Value="CC" />
                    
                    <asp:ListItem Text="Electronic Check" Value="ACH" />
                    <asp:ListItem Text="Cash" Value="CS" />
                    <asp:ListItem Text="Check" Value="CK" />

                </asp:RadioButtonList>
            </td>
            <td>
            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
            </td>
            <td>
                <asp:Panel runat="server" ID="pCheck" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="PDCheck" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pMoneyOrder" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pPurchaseOrder" Visible="false">
                    <asp:Label ID="PONumberLabel"
                        text="PO Number:"
                        AssociatedControlID="txtPONumber"
                        runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPONumber" />
                </asp:Panel>
                <asp:Panel runat="server" ID="pCreditCard" Visible="false">
                    <asp:Label ID="CreditCardNumberLabel"
                        text="Credit Card Number:"
                        AssociatedControlID="txtCardNumber"
                        runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCardNumber" />
                    <br />
                    <asp:Label ID="CCExpMonthLabel"
                        text="Exp&nbsp;"
                        AssociatedControlID="ddlMonth"
                        runat="server"></asp:Label>
                    
                    <asp:Label ID="CCExpYearLabel"
                        text="Date:"
                        AssociatedControlID="ddlYear"
                        runat="server"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlMonth" />
                    <asp:DropDownList runat="server" ID="ddlYear" />
                    <br />
                    <asp:Label ID="CCNameOnCardLabel"
                        text="Name as it appears on card:"
                        AssociatedControlID="txtNameOnCard"
                        runat="server"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNameOnCard" />
                </asp:Panel>
                <asp:Panel runat="server" ID="pCash" Visible="false">
                </asp:Panel>
                <asp:Panel runat="server" ID="pElectronicCheck" Visible="false">
                    Please provide the following information. All information is required
                    <br />
                    <asp:Label ID="AcctHolderNameLabel"
                        text="Account Holder's Name:"
                        AssociatedControlID="txtChkAccountHolder"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtChkAccountHolder" />
                    <br />
                    <asp:Label ID="ABARoutingNumberLabel"
                        text="ABA Routing Number:"
                        AssociatedControlID="txtABANumber"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtABANumber" />
                    <br />
                    <asp:Label ID="ChkAcctNumberLabel"
                        text="Checking Account Number:"
                        AssociatedControlID="txtCheckAcctNumber"
                        runat="server"></asp:Label>
                    <br />
                    <asp:TextBox runat="server" ID="txtCheckAcctNumber" />
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:ImageButton runat="server" ID="btnCheckout" AlternateText="Complete Checkout Button" />
     <asp:ImageButton runat="server" ID="btnCancelCheckout" Visible=false alt="Cancel Checkout Button"/>
</asp:Content>

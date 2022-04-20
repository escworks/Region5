using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class catalog_register_checkout : region4.escWeb.BasePages.Catalog.Register.checkout_aspx
{

    protected override void AssignControlsToBase()
    {
        base._lblErrorMessage = lblErrorMessage;
        base._btnCheckout = btnCheckout;
        base._rblPaymentMethod = rblPaymentList;
        base._pCashDetails = pCash;
        base._pCCDetails = pCreditCard;
        base._pCheckDetails = pCheck;
        base._pDCheckDetails = PDCheck;
        base._pMODetails = pMoneyOrder;
        base._pPurchaseOrder = pPurchaseOrder;

        base._expMonth = ddlMonth;
        base._expYear = ddlYear;
        base._nameOnCard = txtNameOnCard;
        base._cardNumber = txtCardNumber;
        base._poNumber = txtPONumber;

        base._lblPaymentPrompt = lblPaymentPrompt;

        base._chkABANumber = txtABANumber;
        base._chkAccountHolder = txtChkAccountHolder;
        base._chkAccountNumber = txtCheckAcctNumber;
        base._pElectronicCheck = pElectronicCheck;
        base._CancellButton = btnCancelCheckout;
    }

    protected override void AssignCustomerPaymentMethod(string paymentMethod)
    {
        
    }

    protected override void HideCustomerPaymentPanels()
    { // As per Bing , this feature is unique to Region4 and doesnt applies to any other customer - Commented by Mohana on 24th April 2014
        //escWeb.tx_r5.ObjectModel.User currentUser = this.CurrentUser as escWeb.tx_r5.ObjectModel.User;
        //if (currentUser != null)
        //{
        //    escWeb.tx_r5.ObjectModel.Room currentLocation = currentUser.Location as escWeb.tx_r5.ObjectModel.Room;
        //    if (currentLocation != null)
        //    {
        //        if (currentLocation.NoPOPayment && _rblPaymentMethod.Items.Count > 2)
        //        {
        //            _rblPaymentMethod.Items.RemoveAt(2); //Remove PO
        //            return;
        //        }
        //        escWeb.tx_r5.ObjectModel.Site currentSite = currentLocation.Site as escWeb.tx_r5.ObjectModel.Site;
        //        if (currentSite != null && currentSite.NoPOPayment && _rblPaymentMethod.Items.Count > 2)
        //        {
        //            _rblPaymentMethod.Items.RemoveAt(2); //Remove PO
        //            return;
        //        }
        //    }
        //}

        //if (!this.ShoppingCart.AllowPO)
        //{
        //    if (_rblPaymentMethod.Items.Count > 2)
        //        _rblPaymentMethod.Items.RemoveAt(2); //Remove PO
        //}
    }

    protected override region4.ObjectModel.IPaymentMethod SetCustomerPaymentMethodDisplay(string paymentMethod)
    {
        return null;
    }

    protected override void _btnCheckout_Click(object sender, EventArgs e)
    {
        if (_cbCancellationPolicy != null && !_cbCancellationPolicy.Checked)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "agreement", "<script language=\"javascript\">alert('You must click the checkbox to indicate you have read and understand our cancellation policy.')</script>");
            return;
        }
        if (this.ShoppingCart.ItemCount == 0)
            return;
        region4.ObjectModel.IPaymentMethod paymentMethod = null;

        //Assign payment method
        if (this.ShoppingCart.CartTotal != 0)
        {
            switch (_rblPaymentMethod.SelectedValue)
            {
                case "CC":
                    string cardNumber, nameOnCard;
                    DateTime expDate;

                    cardNumber = _cardNumber.Text.Trim();
                    nameOnCard = _nameOnCard.Text.Trim();
                    if (!DateTime.TryParse(String.Format("{0}/1/{1}", _expMonth.SelectedValue, _expYear.SelectedValue), out expDate))
                    {
                        _lblErrorMessage.Text = "Please select a valid expiration date";
                        return;
                    }

                    if (cardNumber == "")
                    {
                        _lblErrorMessage.Text = "Please enter your credit card number";
                        return;
                    }
                    if (nameOnCard == "")
                    {
                        _lblErrorMessage.Text = "Please enter the name on the credit card";
                        return;
                    }

                    paymentMethod = new region4.ObjectModel.Commerce.CreditCard(cardNumber, expDate, nameOnCard, this.ShoppingCart, this.CurrentUser);
                    break;
                case "ACH":
                    string accountNumber, accountHolder, abaNumber;
                    accountHolder = _chkAccountHolder.Text;
                    accountNumber = _chkAccountNumber.Text;
                    abaNumber = _chkABANumber.Text;

                    paymentMethod = new region4.ObjectModel.Commerce.ElectronicCheck(abaNumber, accountHolder, accountNumber, this.ShoppingCart, this.CurrentUser);

                    break;
                case "MO":
                    paymentMethod = new region4.ObjectModel.Commerce.MoneyOrder();
                    break;
                case "CK":
                    paymentMethod = new region4.ObjectModel.Commerce.CheckPayment();
                    break;
                case "DCK":
                    paymentMethod = new region4.ObjectModel.Commerce.DCheckPayment();
                    break;
                case "CS":
                    paymentMethod = new region4.ObjectModel.Commerce.CashPayment();
                    break;
                case "TF":
                    paymentMethod = new region4.ObjectModel.Commerce.TexasFellows();
                    break;
                case "MV":
                    paymentMethod = new region4.ObjectModel.Commerce.MentorVoucher();
                    break;
                case "PO":
                    if (_poNumber.Text.Trim() == "") // Added by VM 4-23-2012
                    {
                        _lblErrorMessage.Text = "Please enter your PO number";
                        return;
                    }
                    if (_poDistrict == null) // Modified by VM 3-20-2012
                        paymentMethod = new region4.ObjectModel.Commerce.PurchaseOrder(_poNumber.Text);
                    else
                    {
                        if (_poDistrictContact == null && _poDistrictContactEmail == null) //ONlY District name is required
                        {
                            if (_poDistrict.Text.Trim() == "") // Added by VM 4-23-2012
                            {
                                _lblErrorMessage.Text = "Please enter your district";
                                return;
                            }

                            paymentMethod = new region4.ObjectModel.Commerce.PurchaseOrder(_poNumber.Text, _poDistrict.Text);
                        }
                        else
                        {
                            if (_poDistrict.Text.Trim() == "")
                            {
                                _lblErrorMessage.Text = "Please enter your district";
                                return;
                            }
                            if (_poDistrictContact.Text.Trim() == "")
                            {
                                _lblErrorMessage.Text = "Please enter your district contact person name";
                                return;
                            }
                            if (_poDistrictContactEmail.Text.Trim() == "")
                            {
                                _lblErrorMessage.Text = "Please enter your district contact person email";
                                return;
                            }

                            paymentMethod = new region4.ObjectModel.Commerce.PurchaseOrder(_poNumber.Text, _poDistrict.Text, _poDistrictContact.Text, _poDistrictContactEmail.Text);
                        }
                    }
                    break;
                default:
                    paymentMethod = SetCustomerPaymentMethodDisplay(_rblPaymentMethod.SelectedValue);
                    if (paymentMethod == null)
                        return;
                    break;
            }
        }
        else
        {
            //If Session fee is $0, then NoFeeMethod, otherwise, CashMethod
            if (this.ShoppingCart.HasDiscountReason)
                paymentMethod = new region4.ObjectModel.Commerce.CashPayment();
            else
                paymentMethod = new region4.ObjectModel.Commerce.NoFeeMethod();
        }

        //Authorize the payment
        string output;
        if (!paymentMethod.AuthorizePayment(out output))
        {
            _lblErrorMessage.Text = output;
            return;
        }

        Guid registrationID = Guid.NewGuid();

        //Complete registration
        foreach (region4.ObjectModel.ICartItem item in this.ShoppingCart)
        {
            string message = string.Empty;
            if (item.AvailableToCheckOut(ref message))
                item.CompleteCheckOut(registrationID, paymentMethod, true);
        }

        this.ShoppingCart.Clear();

        //More items to checkout
        if (this.ShoppingCart2.ItemCount > 0)
        {
            this.ShoppingCart2.MoveItems(this.ShoppingCart);
        }

        this.CurrentUser.Clear(); //Reload user's RegistrationHistory

        Response.Redirect("~/catalog/register/complete.aspx?id=" + registrationID.ToString());

    }
}

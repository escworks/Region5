using System;


/// <summary>
/// Summary description for Attendee
/// </summary>

namespace escWeb.tx_r5.ObjectModel
{
    [Serializable]
    public class Attendee : region4.ObjectModel.Attendee
    {

        public Attendee(Session session, User user)
            : base(session, user)
        {
        }

        public Attendee(int attendee_pk)
            : base(attendee_pk)
        {
        }

    }

    [Serializable]
    public class SessionRegistration : region4.ObjectModel.SessionRegistration
    {
        public SessionRegistration(Session session, User user)
            : base(session, user)
        {
        }

        public SessionRegistration(Session session, User user, bool overrideLimit)
        :base(session,user,overrideLimit)
        {        
        }

        public override void CompleteCheckOut(Guid registrationGrouping, region4.ObjectModel.IPaymentMethod paymentMethod, bool sendEmail, decimal additionalDiscount)
        {
            this.SaveRegistration(registrationGrouping, additionalDiscount);
            this.SaveAdditionalRegistrationData();
            Attendee attendee = (Attendee)region4.escWeb.SiteVariables.ObjectProvider.ReturnAttendee(_session, _user);
            //Record the payment
            if (attendee == null)
                throw new Exception("unable to save registration information");

            paymentMethod.RecordPaymentToAttendee(attendee, this);

            //Refresh the attendee object
            attendee = (Attendee)region4.escWeb.SiteVariables.ObjectProvider.ReturnAttendee(attendee.ID);

            //Send the confirmation email
            bool appendVoucher = !paymentMethod.ElectronicPayment && attendee.Fee > 0 && region4.escWeb.SiteVariables.SendPaymentVoucherEmails;

            //Ticket 278
            if (paymentMethod is region4.ObjectModel.Commerce.PurchaseOrder)
                appendVoucher = false;

            if (sendEmail)
                region4.escWeb.SiteVariables.ObjectProvider.EmailProvider.SendConfirmationEmail(attendee, appendVoucher);            
        }

    }
}
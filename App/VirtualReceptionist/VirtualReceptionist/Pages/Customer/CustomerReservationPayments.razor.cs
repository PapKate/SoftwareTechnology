using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Linq;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist.Pages.Customer
{
    public partial class CustomerReservationPayments
    {
        #region Private Members

        private IEnumerable<CustomerEventReservation> mEventReservations = new List<CustomerEventReservation>();
        private CustomerEventReservation mCustomerEventReservation;
        private double mPrice;
        private PaymentType mPaymentMethodInputValue = PaymentType.Paypal;

        #endregion

        #region Public Properties

        /// <summary>
        /// The customer
        /// </summary>
        [Parameter]
        public CustomerUser Customer { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerReservationPayments() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnInitialized()
        {
            Customer = GlobalData.Customer;
            mEventReservations = Customer.CustomerEventReservations.Where(x => x.IsPaid == false).ToList();
        }

        #endregion

        #region Private Methods

        private async void EventReservation_OnClick(CustomerEventReservation reservation)
        {
            mCustomerEventReservation = reservation;

            // Calculates the total price for the event reservation
            mPrice = HelperMethods.CalculateTotalPrice(reservation.Event.Price, reservation.NumberOfGuests);
            // Show payments form
            // Show form
            var result = await DialogHelpers.ShowValidationDialogAsync<PaymentDialog>("Event payment", "Please choose a payment method.", CashPath, x =>
            {
                x.NegativeFeddbackButtonConfigure = n =>
                {
                    n.Text = "Cancel";
                    n.BackColor = Red;
                    n.ForeColor = White;
                };
                x.PositiveFeddbackButtonConfigure = p =>
                {
                    p.Text = "Submit";
                    p.BackColor = Green;
                    p.ForeColor = White;
                };
            });

            if (!result.Feedback)
                return;

            GoToThirdPartyPayment();
        }

        private void GoToThirdPartyPayment()
        {
            var result = HelperMethods.ThirdPartyPayment(mPaymentMethodInputValue, mPrice);

            // If the transaction was NOT successful
            if (!result)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Unsuccessful Payment", "The transaction was not successful. Please try again.");
                return;
            }

            // Sets the reservation as paid
            mCustomerEventReservation.IsPaid = true;

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Successful Payment", "Your transaction has been completed and your reservation created. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(Customer.Phone, $"Your reservation has been confirmed. The total amount of your transaction was {mPrice}€. Thank you from Sahara Resort!");

            var newReservations = mEventReservations.ToList();
            // Removes the paid reservation
            newReservations.Remove(mCustomerEventReservation);
            mEventReservations = newReservations;
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Linq;

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
            mEventReservations = Customer.CustomerEventReservations.Where(x => x.IsPaid == false).ToList();
        }

        #endregion

        #region Private Methods

        private void EventReservation_OnClick(CustomerEventReservation reservation)
        {
            // Calculates the total price for the event reservation
            mPrice = HelperMethods.CalculateTotalPrice(reservation.Event.Price, reservation.NumberOfGuests);
            // Show payments form
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

            mCustomerEventReservation.IsPaid = true;

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Successful Payment", "Your transaction has been completed and your reservation created. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(Customer.Phone, $"Your reservation has been confirmed. The total amount of your transaction was {mPrice}€. Thank you from Sahara Resort!");
        }

        #endregion
    }
}

using Microsoft.AspNetCore.Components;

namespace VirtualReceptionist.Pages.Staff
{
    public partial class StaffRoomPaymentsPage
    {
        #region Private Members

        private Pin mCustomerPin;

        private RoomCheckIn mRoomCheckIn;
        private double mPrice;
        private double mGiven;
        private PaymentType mPaymentMethodInputValue = PaymentType.Paypal;

        #endregion

        #region Public Properties

        /// <summary>
        /// The hotel's pin
        /// </summary>
        [Parameter]
        public Pin HotelPin { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StaffRoomPaymentsPage() : base()
        {

        }

        #endregion

        #region Private Methods

        private void GetCustomerRoomPaymentData()
        {
            var customer = CustomerUser.GetCustomer(HotelPin, mCustomerPin);
            mRoomCheckIn = customer.RoomCheckIn;
            if(customer.RoomCheckIn.IsPaid)
            {
                HelperMethods.ShowMessage(MessageType.Information, "No due payments", "The stay in this room is already paid. Thank you for choosing us from Sahara Resort!");
                return;
            }

            var numberOfNights = (uint)(mRoomCheckIn.DateEnded - mRoomCheckIn.DateCreated).Days;

            mPrice = HelperMethods.CalculateTotalPrice(mRoomCheckIn.Room.Price, numberOfNights); 
            // Show payments form
            // -> PaymentsFormOKButton_OnClick()
        }

        private void PaymentsFormOKButton_OnClick()
        {
            if (mPaymentMethodInputValue == PaymentType.Cash)
            {
                var change = HelperMethods.SubmitPaymentWithCash(mPrice, mGiven);
                RoomCheckInPaymentConfirmed();
                return;
            }

            HelperMethods.SubmitPaymentWithPOS();
        }

        /// <summary>
        /// The third party payment procedure for the creation of an event check in
        /// </summary>
        private void GoToPOSPayment()
        {
            var result = HelperMethods.ThirdPartyPayment(mPaymentMethodInputValue, mPrice);

            // If the transaction was NOT successful
            if (!result)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Unsuccessful Payment", "The transaction was not successful. Please try again.");
                return;
            }
            RoomCheckInPaymentConfirmed();
        }

        private void RoomCheckInPaymentConfirmed()
        {
            mRoomCheckIn.IsPaid = true;
            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Successful Payment", "Your transaction has been completed and your check in paid. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(mRoomCheckIn.Customer.Phone, $"Your payment for your stay has been confirmed. The total amount of your transaction was {mPrice}€. Thank you from Sahara Resort!");
        }

        #endregion
    }
}

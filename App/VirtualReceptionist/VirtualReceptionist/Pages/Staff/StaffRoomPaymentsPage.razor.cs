using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class StaffRoomPaymentsPage
    {
        #region Private Members

        private bool mIsPinPadVisible = true;

        private CustomerUser mCustomer;

        private RoomCheckIn mRoomCheckIn;
        private double mPrice;
        private double mGiven;
        private PaymentType mPaymentMethodInputValue = PaymentType.Cash;

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

        #region Protected Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();

            HotelPin = GlobalData.Hotel.Pin;
        }

        #endregion

        #region Private Methods

        private void GetCustomerCheckInData(CustomerUser customer)
        {
            mCustomer = customer;
            mRoomCheckIn = customer.RoomCheckIn;
        }

        private async void GetCustomerRoomPaymentData()
        {
            if(mCustomer.RoomCheckIn.IsPaid)
            {
                HelperMethods.ShowMessage(MessageType.Information, "No due payments", "The stay in this room is already paid. Thank you for choosing us from Sahara Resort!");
                return;
            }

            var numberOfNights = (uint)(mRoomCheckIn.DateEnded - mRoomCheckIn.DateCreated).Days;

            mPrice = HelperMethods.CalculateTotalPrice(mRoomCheckIn.Room.Price, numberOfNights);

            // Show form
            var result = await DialogHelpers.ShowValidationDialogAsync<PaymentDialog>("Room payment", "Please choose a payment method.", CashPath, x =>
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
                x.Configure = y =>
                {
                    y.PaymentMethods = new List<PaymentMethodModel>() 
                    {
                        new PaymentMethodModel("Visa", VisaPath, PaymentType.Visa),
                        new PaymentMethodModel("MasterCard", MasterCardPath, PaymentType.Mastercard),
                        new PaymentMethodModel("PayPal", PayPalPath, PaymentType.Paypal),
                        new PaymentMethodModel("Cash", CashPath, PaymentType.Cash),
                    };
                };
            });

            if (!result.Feedback)
                return;

            // Show payments form
            PaymentsFormOKButton_OnClick();
        }

        private async void PaymentsFormOKButton_OnClick()
        {
            if (mPaymentMethodInputValue == PaymentType.Cash)
            {
                var result = await HelperMethods.SubmitPaymentWithCash(mPrice, mGiven);
                
                if(result)
                    RoomCheckInPaymentConfirmed();
                
                return;
            }

            GoToPOSPayment();
        }

        /// <summary>
        /// The third party payment procedure for the creation of an event check in
        /// </summary>
        private void GoToPOSPayment()
        {
            var result = HelperMethods.SubmitPaymentWithPOS(mPaymentMethodInputValue, mPrice);

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

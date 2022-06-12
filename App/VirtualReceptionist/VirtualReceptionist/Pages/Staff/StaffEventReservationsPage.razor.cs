using Atom;
using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Linq;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class StaffEventReservationsPage
    {
        #region Private Members
        
        private DropDownMenu<ReservationField> dropDownMenu;
        private TextInput mSearchTextInput;

        private IEnumerable<EventReservation> mEventReservations;

        private string mFirstNameInputValue;
        private string mLaststNameInputValue;
        private uint mNumberOfGuestsInputValue;
        private int mCountryCodeInputValue;
        private string mPhoneNumberInputValue;

        private Event mEvent;
        private double mPrice;
        private double mGiven;
        private PaymentType mPaymentMethodInputValue = PaymentType.Paypal;

        private StaffEventReservationDialog mEventReservationDialog;

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
        public StaffEventReservationsPage() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnInitialized()
        {
            HotelPin = GlobalData.Hotel.Pin;
            mEventReservations = EventReservation.GetEventReservations(HotelPin);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                var models = new List<ReservationField>()
                {
                    new ReservationField()
                    {
                        Name = "Event",
                        VectorSource = FireworkPath
                    },
                    new ReservationField()
                    {
                        Name = "Date",
                        VectorSource = CalendarHeartPath
                    },
                    new ReservationField()
                    {
                        Name = "Room",
                        VectorSource = BedEmptyPath
                    },
                    new ReservationField()
                    {
                        Name = "Participants",
                        VectorSource = StarPath
                    },
                };

                dropDownMenu.AddRange(models);
                dropDownMenu.Value = models.First(x => x.Name == "Date");
            }
        }

        #endregion

        #region Private Methods

        private async void ShowEventReservationForm()
        {
            // Show form
            var result = await DialogHelpers.ShowValidationDialogAsync<StaffEventReservationDialog>(null, null, null, x =>
            {
                x.Style = "padding: 0;";
                x.NegativeFeddbackButtonConfigure = n =>
                {
                    n.Text = "Cancel";
                    n.BackColor = Red;
                    n.ForeColor = White;
                };
                x.PositiveFeddbackButtonConfigure = p =>
                {
                    p.Text = "Save";
                    p.BackColor = Green;
                    p.ForeColor = White;
                };
                x.Configure = y =>
                {
                    mEventReservationDialog = y;
                };
            });

            if (result.Feedback)
            {
                EventReservationFormSaveButton_OnClick();
            }
            else
            {
                CancelButton_OnClick();
            }
        }

        /// <summary>
        /// Cancels a reservation
        /// </summary>
        private void CancelButton_OnClick()
        {
            mEvent = null;
            mFirstNameInputValue = string.Empty;
            mLaststNameInputValue = string.Empty;
            mPhoneNumberInputValue = string.Empty;
            mNumberOfGuestsInputValue = 0;
            mCountryCodeInputValue = 0;
        }

        private void SortBy(string type)
        {
            mEventReservations.ToList().Sort();
        }

        /// <summary>
        /// Searches the reservations if any field contains the given <paramref name="text"/>
        /// </summary>
        /// <param name="text">The text</param>
        private void Search(string text)
        {
            // If the text is null or empty...
            if (string.IsNullOrEmpty(text))
            {
                mEventReservations = EventReservation.GetEventReservations(HotelPin);
                // Return
                return;
            }

            mEventReservations = mEventReservations.ToList()
                                .Where(x => x.Event.Name.Contains(text) 
                                    || x.FirstName.Contains(text)
                                    || x.LastName.Contains(text)
                                    || x.Phone.PhoneNumber.Contains(text)
                                    || x.Event.Facility.Name.Contains(text)).ToList();
        }

        private async void EventReservationFormSaveButton_OnClick()
        {
            mFirstNameInputValue = mEventReservationDialog.FirstNameInput.Text;
            mLaststNameInputValue = mEventReservationDialog.LastNameInput.Text;
            mPhoneNumberInputValue = mEventReservationDialog.PhoneNumberInput.Text;

            // If there is at least an empty input...
            if (string.IsNullOrEmpty(mFirstNameInputValue)
            || string.IsNullOrEmpty(mLaststNameInputValue)
            || string.IsNullOrEmpty(mPhoneNumberInputValue)
            || string.IsNullOrEmpty(mEventReservationDialog.NumberOfGuestsInput.Text)
            || string.IsNullOrEmpty(mEventReservationDialog.CountryCodeInput.Text)
            || mEventReservationDialog.EventInput.Value == null)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Empty form input", "Please fill out every input in the form");
                return;
            }

            mNumberOfGuestsInputValue = uint.Parse(mEventReservationDialog.NumberOfGuestsInput.Text);
            mCountryCodeInputValue = int.Parse(mEventReservationDialog.CountryCodeInput.Text);
            mEvent = mEventReservationDialog.EventInput.Value;

            // The number of guests to be in the event
            uint eventCheckInGuests = 0;

            // For each event check in the event that is NOT a reservation add the number of guests to the eventCheckInGuests
            mEvent.EventCheckIns?.Where(x => x.IsReservation != true).ToList().ForEach(x => eventCheckInGuests += x.NumberOfguests);

            // For each event reservation in the event add the number of guests to the eventCheckInGuests
            mEvent.EventReservations?.ToList().ForEach(x => eventCheckInGuests += x.NumberOfGuests);

            var remainingNumberOfGuests = mEvent.MaxNumberOfGuests - eventCheckInGuests;

            // If the guests are more than the remaining capacity...
            if (remainingNumberOfGuests < mNumberOfGuestsInputValue)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Capacity overflow", "The number of guests exceeds the remaining capacity of this event. PLease fill a different number and try again.");
                return;
            }

            mPrice = HelperMethods.CalculateTotalPrice(mEvent.Price, mNumberOfGuestsInputValue);

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

                if (result)
                    CreateEventReservation();

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

            // Creates the check in
            CreateEventReservation();
        }

        private void CreateEventReservation()
        {
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            EventReservation.CreateEventReservation(mFirstNameInputValue, mLaststNameInputValue, phone, mNumberOfGuestsInputValue, false, mEvent, HotelPin);

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Reservation created", "Your reservation has been created. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(phone, $"Your reservation has been confirmed. Thank you from Sahara Resort!");

            mEventReservations = EventReservation.GetEventReservations(HotelPin).ToList();
            StateHasChanged();
        }

        private void EventReservationForm_Cancel()
        {
            mFirstNameInputValue = null;
            mLaststNameInputValue = null;
            mPhoneNumberInputValue = null;
            mNumberOfGuestsInputValue = 0;
            mEvent = null;
            mGiven = 0;
            mPrice = 0;
        }

        #endregion
    }

    public class ReservationField
    {
        #region Public Properties

        public string Name { get; set; }

        public VectorSource VectorSource { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReservationField() : base()
        {

        }

        #endregion
    }
}

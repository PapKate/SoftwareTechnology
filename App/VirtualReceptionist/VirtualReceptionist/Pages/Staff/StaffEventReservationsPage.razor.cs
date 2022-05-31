using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist.Pages.Staff
{
    public partial class StaffEventReservationsPage
    {
        #region Private Members

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
            mEventReservations = EventReservation.GetEventReservations(HotelPin);
        }

        #endregion

        #region Private Methods

        private void ShowEventReservationForm()
        {
            // Show form
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
                // Return
                return;

            mEventReservations = mEventReservations.ToList()
                                .Where(x => x.Event.Name.Contains(text) 
                                || x.FirstName.Contains(text)
                                || x.LastName.Contains(text)
                                || x.Phone.PhoneNumber.Contains(text)
                                || x.Event.Description.Contains(text)
                                || x.Event.Facility.Name.Contains(text)
                                || x.Event.Facility.Description.Contains(text)).ToList();
        }

        private void EventReservationFormSaveButton_OnClick()
        {
            // If there is at least an empty input...
            if (string.IsNullOrEmpty(mFirstNameInputValue)
            || string.IsNullOrEmpty(mLaststNameInputValue)
            || string.IsNullOrEmpty(mPhoneNumberInputValue)
            || mNumberOfGuestsInputValue == 0
            || mCountryCodeInputValue == 0)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Empty form input", "Please fill out every input in the form");
                return;
            }

            // The number of guests to be in the event
            uint eventCheckInGuests = 0;

            // For each event check in the event that is NOT a reservation add the number of guests to the eventCheckInGuests
            mEvent.EventCheckIns.Where(x => x.IsReservation != true).ToList().ForEach(x => eventCheckInGuests += x.NumberOfguests);

            // For each event reservation in the event add the number of guests to the eventCheckInGuests
            mEvent.EventReservations.ToList().ForEach(x => eventCheckInGuests += x.NumberOfGuests);

            var remainingNumberOfGuests = mEvent.MaxNumberOfGuests - eventCheckInGuests;

            // If the guests are more than the remaining capacity...
            if (remainingNumberOfGuests < mNumberOfGuestsInputValue)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Capacity overflow", "The number of guests exceeds the remaining capacity of this event. PLease fill a different number and try again.");
                return;
            }

            // Show payments form
            // -> PaymentsFormOKButton_OnClick()
            return;
        }

        private void PaymentsFormOKButton_OnClick()
        {
            if (mPaymentMethodInputValue == PaymentType.Cash)
            {
                var change = HelperMethods.SubmitPaymentWithCash(mPrice, mGiven);
                CreateEventReservation();
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

            // Creates the check in
            CreateEventReservation();
        }

        private void CreateEventReservation()
        {
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(mEvent))));

            EventReservation.CreateEventReservation(mFirstNameInputValue, mLaststNameInputValue, phone, mNumberOfGuestsInputValue, false, mEvent, hotel.Pin);

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Reservation created", "Your reservation has been created. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(phone, $"Your reservation has been confirmed. Thank you from Sahara Resort!");
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
}

using Microsoft.AspNetCore.Components;

using System.Linq;

namespace VirtualReceptionist.Pages.Staff
{
    public partial class StaffEventsPage
    {
        #region Private Members

        private bool mIsReservationInputValue;
        private int mCountryCodeInputValue;
        private string mPhoneNumberInputValue;
        private uint mNumberOfGuestsInputValue;
        private int mLockPINInputValue;

        private Event mEvent;
        private EventReservation mEventReservation;
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
        public StaffEventsPage() : base()
        {

        }

        #endregion

        #region Private Methods

        private void ShowEventCheckinForm(Event @event)
        {
            // Show form

            mEvent = @event;
        }

        private void EventCheckinFormSaveButton_OnClick()
        {
            // If there is at least an empty input...
            if (string.IsNullOrEmpty(mPhoneNumberInputValue)
            || (mIsReservationInputValue == false && mNumberOfGuestsInputValue == 0)
            || mCountryCodeInputValue == 0
            || (mEvent.IsPrivate && mLockPINInputValue == 0))
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Empty form input", "Please fill out every input in the form");
                return;
            }

            var phone = new Phone() 
            { 
                CountryCode = mCountryCodeInputValue, 
                PhoneNumber = mPhoneNumberInputValue 
            };
            
            // If the event is private...
            if(mEvent.IsPrivate)
            {
                // If the pin is incorrect...
                if(mLockPINInputValue != mEvent.Pin.Code)
                {
                    // Show the error
                    HelperMethods.ShowMessage(MessageType.Error, "Incorrect PIN", "Please enter your PIN and try again.");
                    return;
                }
                // Create the event check in
                CreateEventCheckIn();
            }

            // If it is a reservation...
            if(mIsReservationInputValue)
            {
                // Get the reservation
                mEventReservation = mEvent.EventReservations.FirstOrDefault(x => x.Phone == phone);

                // If the reservation does no exist....
                if(mEventReservation == null)
                {
                    // Show the error
                    HelperMethods.ShowMessage(MessageType.Error, "No reservation", "There is no reservation under this phone number. Please check for a different phone number.");
                    return;
                }
                mNumberOfGuestsInputValue = mEventReservation.NumberOfGuests;

                // If the reservation is not paid...
                if(!mEventReservation.IsPaid)
                {
                    // Calculates the total price for the event reservation
                    mPrice = HelperMethods.CalculateTotalPrice(mEvent.Price, mNumberOfGuestsInputValue);

                    // Show payments form
                    // -> PaymentsFormOKButton_OnClick()
                    return;
                }

                // Creates the check in
                CreateEventCheckIn();
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
            if(mPaymentMethodInputValue == PaymentType.Cash)
            {
                var change = HelperMethods.SubmitPaymentWithCash(mPrice, mGiven);
                CreateEventCheckIn();
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
            CreateEventCheckIn();
        }

        private void CreateEventCheckIn()
        {
            // Creates the phone
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(mEvent))));

            // Creates an event check in
            EventChekcIn.CreateEventCheckIn(mEvent, mIsReservationInputValue, mEventReservation, phone, mNumberOfGuestsInputValue, HotelPin);

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Successful Payment", "Your transaction has been completed and your check in created. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(phone, $"Your check in has been confirmed. The total amount of your transaction was {mPrice}€. Thank you from Sahara Resort!");
        }

        private void Event_RightClick()
        {
            // Show context menu
        }

        private void ShowEditEventForm(Event eventToEdit)
        {
            // Show the edit form
        }

        private void EditEventFormSaveButton_OnClick(Event eventToEdit)
        {

        }

        private void DeleteEventSaveButton_OnClick(Event eventToDetele)
        {
            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(eventToDetele))));

            var events = hotel.Floors.First(x => x == eventToDetele.Facility.Floor).Facilities.First(x => x == eventToDetele.Facility).Events.ToList();

            events.Remove(eventToDetele);

            hotel.Floors.First(x => x == eventToDetele.Facility.Floor).Facilities.First(x => x == eventToDetele.Facility).Events = events;
        }

        #endregion
    }
}

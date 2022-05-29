using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist.Pages
{
    public partial class VisitorEventsPage
    {
        #region Private Members

        /// <summary>
        /// A list containing all the events
        /// </summary>
        private IEnumerable<Event> mEvents = new List<Event>();

        private string mFirstNameInputValue;
        private string mLaststNameInputValue;
        private uint mNumberOfGuestsInputValue;
        private int mCountryCodeInputValue;
        private string mPhoneNumberInputValue;

        private Event mEvent;
        private double mPrice;
        private PaymentType mPaymentMethodInputValue = PaymentType.Paypal;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public VisitorEventsPage() : base()
        {

        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Method invoked when the component is ready to start, having received its initial
        /// parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            mEvents = Event.GetEvents();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Opens the form for an event reservation
        /// </summary>
        /// <param name="event">The event</param>
        private void OpenEventReservationForm(Event @event)
        {
            mEvent = @event;
            // Show form
        }

        /// <summary>
        /// Save the event reservation
        /// </summary>
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

            HelperMethods.ShowMessage(MessageType.Information, "Payment", "Would you like to pay now?");
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

        /// <summary>
        /// Confirms and shows the payment form
        /// </summary>
        private void PaymentsFormYesButton_OnClick()
        {
            // Close the Payment dialog

            // Opens the payment form
        }

        /// <summary>
        /// Shows the payments form
        /// </summary>
        private void ShowPaymentsForm()
        {
            // Calculates the total price for the event reservation
            mPrice = HelperMethods.CalculateTotalPrice(mEvent.Price, mNumberOfGuestsInputValue);

            // Show form
        }

        private void GoToThirdPartyPayment()
        {
            var result = HelperMethods.ThirdPartyPayment(mPaymentMethodInputValue, mPrice);

            // If the transaction was NOT successful
            if(!result)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Unsuccessful Payment", "The transaction was not successful. Please try again.");
                return;
            }

            // Creates the phone
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(mEvent))));

            EventReservation.CreateEventReservation(mFirstNameInputValue, mLaststNameInputValue, phone, mNumberOfGuestsInputValue, mEvent, hotel.Pin);

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Successful Payment", "Your transaction has been completed and your reservation created. Thank you!");
            
            // Sends the text to the phone
            HelperMethods.SendPhoneText(phone, $"Your reservation has been confirmed. The total amount of your transaction was {mPrice}€. Thank you from Sahara Resort!");
        }

        #endregion
    }
}

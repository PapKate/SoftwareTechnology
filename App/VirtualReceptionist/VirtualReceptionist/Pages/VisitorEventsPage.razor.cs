using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using System;
using System.Collections.Generic;
using System.Linq;

using static VirtualReceptionist.Constants;

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

        private EventReservationDialog mEventReservationDialog;

        private Event mEvent;
        private double mPrice;
        private PaymentType mPaymentMethodInputValue = PaymentType.Paypal;

        #endregion

        #region Protected Properties

        [Inject]
        protected IDialogsManager DialogsManager { get; set; }

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

        /// <summary>
        /// Opens the form for an event reservation
        /// </summary>
        /// <param name="event">The event</param>
        protected async void OpenEventReservationForm(Event @event)
        {
            mEvent = @event;
            // Show form
            var result = await DialogHelpers.ShowValidationDialogAsync<EventReservationDialog>(null, null, null, x =>
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
                    y.Model = mEvent;
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
        /// Save the event reservation
        /// </summary>
        protected async void EventReservationFormSaveButton_OnClick()
        {
            mFirstNameInputValue = mEventReservationDialog.FirstNameInput.Text;
            mLaststNameInputValue = mEventReservationDialog.LastNameInput.Text;
            mPhoneNumberInputValue = mEventReservationDialog.PhoneNumberInput.Text;
            

            // If there is at least an empty input...
            if (string.IsNullOrEmpty(mFirstNameInputValue)
            || string.IsNullOrEmpty(mLaststNameInputValue)
            || string.IsNullOrEmpty(mPhoneNumberInputValue)
            || string.IsNullOrEmpty(mEventReservationDialog.NumberOfGuestsInput.Text)
            || string.IsNullOrEmpty(mEventReservationDialog.CountryCodeInput.Text))
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Empty form input", "Please fill out every input in the form.");
                return;
            }

            mNumberOfGuestsInputValue = uint.Parse(mEventReservationDialog.NumberOfGuestsInput.Text);
            mCountryCodeInputValue = int.Parse(mEventReservationDialog.CountryCodeInput.Text);

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
                HelperMethods.ShowMessage(MessageType.Error, "Capacity overflow", "The number of guests exceeds the remaining capacity of this event. Please fill a different number and try again.");
                return;
            }

            var result = await DialogHelpers.ShowTransitionalDialogAsync("Payment", "Would you like to pay now? If you do not, then your reservation shall not be created.", "Yes", "No", CashPath);

            if (!result.Feedback)
                return;

            ShowPaymentsForm();

        }

        /// <summary>
        /// Cancels a reservation
        /// </summary>
        protected void CancelButton_OnClick()
        {
            mEvent = null;
            mFirstNameInputValue = string.Empty;
            mLaststNameInputValue = string.Empty;
            mPhoneNumberInputValue = string.Empty;
            mNumberOfGuestsInputValue = 0;
            mCountryCodeInputValue = 0;
        }

        /// <summary>
        /// Shows the payments form
        /// </summary>
        protected async void ShowPaymentsForm()
        {
            // Calculates the total price for the event reservation
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
            });

            if (!result.Feedback)
                return;

            GoToThirdPartyPayment();
        }

        protected void GoToThirdPartyPayment()
        {
            var result = HelperMethods.ThirdPartyPayment(mPaymentMethodInputValue, mPrice);

            // If the transaction was NOT successful
            if (!result)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Unsuccessful Payment", "The transaction was not successful. Please try again.");
                return;
            }

            // Creates the phone
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(mEvent))));

            CreateReservation();

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Successful Payment", "Your transaction has been completed and your reservation created. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(phone, $"Your reservation has been confirmed. The total amount of your transaction was {mPrice}€. Thank you from Sahara Resort!");
        }

        protected virtual void CreateReservation()
        {
            // Creates the phone
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(mEvent))));

            EventReservation.CreateEventReservation(mFirstNameInputValue, mLaststNameInputValue, phone, mNumberOfGuestsInputValue, true, mEvent, hotel.Pin);
        }

        #endregion
    }
}

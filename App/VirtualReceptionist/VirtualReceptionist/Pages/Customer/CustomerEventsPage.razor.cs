using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class CustomerEventsPage
    {
        #region Public Properties

        /// <summary>
        /// The customer
        /// </summary>
        [Parameter]
        public CustomerUser Customer { get; set; }

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
        public CustomerEventsPage() : base()
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
            HotelPin = GlobalData.Hotel.Pin;
            mEvents = Event.GetEvents(HotelPin);
        }

        protected override async Task<bool> ShowPaymentsDialog()
        {
            var result = await DialogHelpers.ShowTransitionalDialogAsync("Payment", "Would you like to pay now? If you do not, you can pay later at the 'Reservation payments' page.", "Yes", "No", CashPath);

            if (!result.Feedback)
            {
                PaymentsFormNoButton_OnClick();
                return false;
            }
            return true;
        }

        protected override void CreateReservation()
        {
            // Creates the phone
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(mEvent))));

            CustomerEventReservation.CreateEventReservation(mFirstNameInputValue, mLaststNameInputValue, phone, mNumberOfGuestsInputValue, true, mEvent, hotel.Pin, Customer);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates an unpaid reservation
        /// </summary>
        private void PaymentsFormNoButton_OnClick()
        {
            // Close the Payment dialog
            // Creates the phone
            var phone = new Phone() { CountryCode = mCountryCodeInputValue, PhoneNumber = mPhoneNumberInputValue };

            var hotel = Data.Hotels.First(x => x.Floors.Any(x => x.Facilities.Any(x => x.Events.Contains(mEvent))));

            EventReservation.CreateEventReservation(mFirstNameInputValue, mLaststNameInputValue, phone, mNumberOfGuestsInputValue, false, mEvent, hotel.Pin);

            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Reservation created", "Your reservation has been created. Please enter the event 20 minutes before its start or else your reservation will be canceled. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(phone, $"Your reservation has been confirmed. Thank you from Sahara Resort!");
        }

        #endregion
    }
}

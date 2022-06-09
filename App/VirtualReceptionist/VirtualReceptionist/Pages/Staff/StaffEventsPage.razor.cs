using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class StaffEventsPage
    {
        #region Private Members

        private bool mIsReservationInputValue;
        private int mCountryCodeInputValue;
        private string mPhoneNumberInputValue;
        private uint mNumberOfGuestsInputValue;
        private int mLockPINInputValue;
        
        private EventCheckInDialog mEventCheckInDialog;

        private IEnumerable<Event> mEvents;
        private Event mEvent;
        private EventReservation mEventReservation;
        private double mPrice;
        private double mGiven;
        private PaymentType mPaymentMethodInputValue = PaymentType.Cash;

        private EventPreview mEventPreview;

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

        #region Protected Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HotelPin = GlobalData.Hotel.Pin;
            //HotelPin = Data.Hotels.Last().Pin;
            mEvents = Data.Events.Where(x => x.Facility.Floor.Hotel.Pin == HotelPin);
        }

        #endregion

        #region Private Methods

        private async void OpenEventCheckInForm(Event @event)
        {
            mEvent = @event;
            // Show form
            var result = await DialogHelpers.ShowValidationDialogAsync<EventCheckInDialog>(null, null, null, x =>
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
                    mEventCheckInDialog = y;
                };
            });

            if (result.Feedback)
            {
                EventCheckinFormSaveButton_OnClick();
            }
            else
            {
                CancelButton_OnClick();
            }
        }

        /// <summary>
        /// Cancels a check in
        /// </summary>
        protected void CancelButton_OnClick()
        {
            mEvent = null;
            mPhoneNumberInputValue = string.Empty;
            mNumberOfGuestsInputValue = 0;
            mCountryCodeInputValue = 0;
        }

        private void EventCheckinFormSaveButton_OnClick()
        {
            mPhoneNumberInputValue = mEventCheckInDialog.PhoneNumberInput.Text;
            mIsReservationInputValue = mEventCheckInDialog.IsReservationCheckbox?.Value ?? false;

            // If there is at least an empty input...
            if (string.IsNullOrEmpty(mPhoneNumberInputValue)
            || (mIsReservationInputValue == false && string.IsNullOrEmpty(mEventCheckInDialog.NumberOfGuestsInput.Text))
            || string.IsNullOrEmpty(mEventCheckInDialog.CountryCodeInput.Text)
            || (mEvent.IsPrivate && string.IsNullOrEmpty(mEventCheckInDialog.LockPinInput.Text)))
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Empty form input", "Please fill out every input in the form");
                return;
            }

            mCountryCodeInputValue = int.Parse(mEventCheckInDialog.CountryCodeInput.Text);

            var phone = new Phone() 
            { 
                CountryCode = mCountryCodeInputValue, 
                PhoneNumber = mPhoneNumberInputValue 
            };
            
            // If the event is private...
            if(mEvent.IsPrivate)
            {
                mLockPINInputValue = int.Parse(mEventCheckInDialog.LockPinInput.Text);
                // If the pin is incorrect...
                if(mLockPINInputValue != mEvent.Pin.Code)
                {
                    // Show the error
                    HelperMethods.ShowMessage(MessageType.Error, "Incorrect PIN", "Please enter your PIN and try again.");
                    return;
                }
                // Create the event check in
                CreateEventCheckIn();
                return;
            }


            // If it is a reservation...
            if (mIsReservationInputValue)
            {
                // Get the reservation
                mEventReservation = mEvent.EventReservations?.FirstOrDefault(x => x.Phone.PhoneNumber == mPhoneNumberInputValue);

                // If the reservation does no exist....
                if(mEventReservation == null)
                {
                    // Show the error
                    HelperMethods.ShowMessage(MessageType.Error, "No reservation", "There is no reservation under this phone number. Please check for a different phone number.");
                    return;
                }
                mNumberOfGuestsInputValue = mEventReservation.NumberOfGuests;
                mPrice = HelperMethods.CalculateTotalPrice(mEvent.Price, mNumberOfGuestsInputValue);

                // If the reservation is not paid...
                if (!mEventReservation.IsPaid)
                {
                    // Show payments form
                    GoToPaymentMethods();
                    return;
                }

                // Creates the check in
                CreateEventCheckIn();
                return;
            }

            mNumberOfGuestsInputValue = uint.Parse(mEventCheckInDialog.NumberOfGuestsInput.Text);
            mPrice = HelperMethods.CalculateTotalPrice(mEvent.Price, mNumberOfGuestsInputValue);

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
            GoToPaymentMethods();
        }

        private async void GoToPaymentMethods()
        {

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
                    CreateEventCheckIn();

                return;
            }

            GoToPOSPayment();
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

            // Creates an event check in
            EventChekIn.CreateEventCheckIn(mEvent, mIsReservationInputValue, mEventReservation, phone, mNumberOfGuestsInputValue, HotelPin);

            if(mEvent.IsPrivate)
            {
                // Show the message
                HelperMethods.ShowMessage(MessageType.Information, "Successful Check In", "Your check in has been created. Thank you!");

                // Sends the text to the phone
                HelperMethods.SendPhoneText(phone, $"Your check in has been confirmed. Thank you from Sahara Resort!");
                return;
            }
            // Show the message
            HelperMethods.ShowMessage(MessageType.Information, "Successful Payment", "Your transaction has been completed and your check in created. Thank you!");

            // Sends the text to the phone
            HelperMethods.SendPhoneText(phone, $"Your check in has been confirmed. The total amount of your transaction was {mPrice}€. Thank you from Sahara Resort!");
        }

        /// <summary>
        /// Adds the option buttons to the context menu
        /// </summary>
        private void AddButtons()
        {
            if (mEventPreview.ContextMenuRef.ItemsCount > 0)
                return;
            mEventPreview.ContextMenuRef.Add(new OptionModel("edit", x =>
            {
                x.BackColor = White;
                x.ForeColor = Gray;
                x.Info = "Edit";
                x.Action = () => Console.WriteLine("Edit");
                x.VectorSource = PencilPath;
            }));

            mEventPreview.ContextMenuRef.Add(new Separator()
            {
                Color = PalePurple,
                Margin = "4px 0"
            });

            mEventPreview.ContextMenuRef.Add(new OptionModel("delete", x =>
            {
                x.BackColor = White;
                x.ForeColor = Red;
                x.Info = "Delete";
                x.Action = () => EventDeleteButton_OnClick(mEventPreview.Model);
                x.VectorSource = Atom.IconPaths.TrashCanPath;
            }));
        }

        private void ShowEditEventForm(Event eventToEdit)
        {
            // Show the edit form
        }

        private void EditEventFormSaveButton_OnClick(Event eventToEdit)
        {

        }

        private void EventDeleteButton_OnClick(Event eventToDetele)
        {
            var hotel = Data.Hotels.First(x => x.Pin == HotelPin);

            var events = hotel.Floors.First(x => x == eventToDetele.Facility.Floor).Facilities.First(x => x == eventToDetele.Facility).Events.ToList();

            events.Remove(eventToDetele);

            hotel.Floors.First(x => x == eventToDetele.Facility.Floor).Facilities.First(x => x == eventToDetele.Facility).Events = events;
            events = hotel.Floors.SelectMany(x => x.Facilities ?? Enumerable.Empty<Facility>()).SelectMany(x => x.Events ?? Enumerable.Empty<Event>()).ToList();
            mEvents = events;
            
            StateHasChanged();
        }

        #endregion
    }
}

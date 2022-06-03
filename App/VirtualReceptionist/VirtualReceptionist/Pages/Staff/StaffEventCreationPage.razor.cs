using Microsoft.AspNetCore.Components;

using System;
using System.Linq;

namespace VirtualReceptionist.Pages.Staff
{
    public partial class StaffEventCreationPage
    {
        #region Private Members

        private string mNameInputValue;
        private string mDescripitonInputValue;
        private string mFacilityInputValue;
        private string mImageInputValue;
        private double mPriceInputValue;
        private uint mMaxNumberOfGuestsInputValue;
        private int mCodeInputValue;
        private bool mIsPrivateInputValue;
        private DateTime mDateStartInputValue;
        private TimeSpan mDurationValue;

        private string mFacilityNameInputValue;
        private string mFacilityDescriptionInputValue;
        private Floor mFacilityFloorInputValue;
        private string mFacilityImageInputValue;
        private double mFacilityAreaInputValue;
        private uint mFacilityCapacityInputValue;

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
        public StaffEventCreationPage() : base()
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private void EventFormSaveButton_OnClick()
        {
            // If there is at least an empty input...
            if(string.IsNullOrEmpty(mNameInputValue) 
            || string.IsNullOrEmpty(mDescripitonInputValue) 
            || string.IsNullOrEmpty(mFacilityInputValue) 
            || string.IsNullOrEmpty(mImageInputValue) 
            || mPriceInputValue == 0 
            || mMaxNumberOfGuestsInputValue == 0
            || mDateStartInputValue < DateTime.Now
            || mDurationValue == new TimeSpan(0))
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Empty form input", "Please fill out every input in the form");
                return;
            }

            Pin eventPin = null;

            // If the event is private...
            if(mIsPrivateInputValue)
            {
                if(mCodeInputValue == 0)
                {
                    // Show the error
                    HelperMethods.ShowMessage(MessageType.Error, "Invalid PIN value", "Please fill out a PIN value for the event");
                    return;
                }
                eventPin = new Pin() 
                {
                    Code = mCodeInputValue,
                    IsActive = true
                };
            }

            // Gets all the facilities of the hotel
            var facilities = Facility.GetFacilities(HotelPin);

            // If there is no facility with name the value in the input...
            if(!facilities.Any(x => x.Name == mFacilityInputValue))
            {
                // Show facility form 

                return;
            }

            var facility = facilities.First(x => x.Name == mFacilityInputValue);

            // If the max number of guests is greater than the facility's capacity...
            if(facility.Capacity <= mMaxNumberOfGuestsInputValue)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Overflow", "The maximum number of guest exceeds this facility's capacity. Please fill a different value.");
                // Return
                return;
            }

            // If the date time is previous to now...
            if(mDateStartInputValue < DateTime.Now)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Invalid date start", "The date and time is invalid. Please try again.");
                // Return
                return;
            }

            // Calculates the date and time the event ends
            var dateEnd = mDateStartInputValue.Add(mDurationValue);

            // If any event begins or ends during the desired timespan...
            if(!facility.Events.Any(x => x.DateStart > dateEnd || x.DateStart.Add(x.Duration) < mDateStartInputValue))
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Invalid date and duration", "There is already an event at the given time. PLease try again.");
                // Return
                return;
            }

            // Create the event
            var newEvent = Event.CreateEvent(HotelPin, mNameInputValue, mDescripitonInputValue,mMaxNumberOfGuestsInputValue,mPriceInputValue, mImageInputValue, eventPin, facility, mDateStartInputValue, mDurationValue, mIsPrivateInputValue);

            // Add the event 
            Event.AddEvent(newEvent, HotelPin);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FacilityFormSaveButton_OnClick()
        {
            // If there is at least an empty input...
            if (string.IsNullOrEmpty(mFacilityNameInputValue)
            || string.IsNullOrEmpty(mFacilityDescriptionInputValue)
            || string.IsNullOrEmpty(mFacilityImageInputValue)
            || mFacilityAreaInputValue == 0
            || mFacilityCapacityInputValue == 0
            || mFacilityFloorInputValue == null)
            {
                HelperMethods.ShowMessage(MessageType.Error, "Error", "Please fill out every input in the form");
                return;
            }

            var facilityImage = mFacilityImageInputValue;

            Facility.CreateFacility(HotelPin, mFacilityNameInputValue, mFacilityFloorInputValue, facilityImage, mFacilityAreaInputValue, mFacilityCapacityInputValue, false, mFacilityDescriptionInputValue);

            // Close form
        }

        #endregion
    }
}

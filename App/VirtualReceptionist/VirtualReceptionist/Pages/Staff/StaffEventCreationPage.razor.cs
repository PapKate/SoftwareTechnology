using Atom;
using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class StaffEventCreationPage
    {
        #region Private Members

        private string mNameInputValue;
        private string mDescripitonInputValue;
        private Facility mFacilityInputValue;
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

        private bool mIsChecked = false;

        private FacilityFormDialog mFacilityFormDialog;

        #endregion

        #region Public Properties

        /// <summary>
        /// The hotel's pin
        /// </summary>
        [Parameter]
        public Pin HotelPin { get; set; }

        /// <summary>
        /// The name input
        /// </summary>
        public TextInput NameInput { get; set; }

        /// <summary>
        /// The date start input
        /// </summary>
        public DateTimePicker DateStartInput { get; set; }

        /// <summary>
        /// The duration input
        /// </summary>
        public TimeSpanInput DurationInput { get; set; }

        /// <summary>
        /// The image input
        /// </summary>
        public TextInput ImageInput { get; set; }

        /// <summary>
        /// The description input
        /// </summary>
        public TextInput DescriptionInput { get; set; }

        /// <summary>
        /// The image input
        /// </summary>
        public SearchMenuInput<Facility> LocationInput { get; set; }

        /// <summary>
        /// The capacity input
        /// </summary>
        public NumericInput CapacityInput { get; set; }

        /// <summary>
        /// The price input
        /// </summary>
        public NumericInput PriceInput { get; set; }

        /// <summary>
        /// The is private input
        /// </summary>
        public CheckBox IsPrivateInput { get; set; }

        /// <summary>
        /// The pin inputs
        /// </summary>
        public TextInput PinInput { get; set; }
        public TextInput ConfirmPinInput { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StaffEventCreationPage() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                HotelPin = GlobalData.Hotel.Pin;

                LocationInput.DataRetriever = (async search =>
                {
                    var facilities = Data.Hotels.First(x => x.Pin == HotelPin).Floors.SelectMany(x => x.Facilities ?? Enumerable.Empty<Facility>()).ToList();

                    var result = new Failable<IEnumerable<Facility>>(facilities.Where(x => x.Name.Contains(search)).ToList());

                    return await Task.FromResult<IFailable<IEnumerable<Facility>>>(result);
                });

                LocationInput.TextSelector = x => x.Name;
                LocationInput.VectorSourceSelector = x => x.Name;
            }    
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private void EventFormSaveButton_OnClick()
        {
            mFacilityInputValue = LocationInput.Value;

            // If there is no facility with name the value in the input...
            if (mFacilityInputValue == null)
            {
                // Show facility form 
                ShowFacilityForm();

                return;
            }

            mNameInputValue = NameInput.Text;
            mDescripitonInputValue = DescriptionInput.Text;
            mImageInputValue = ImageInput.Text;
            mMaxNumberOfGuestsInputValue = uint.Parse(CapacityInput.Value.ToString());
            mPriceInputValue = (double)PriceInput.Value;

            // If there is at least an empty input...
            if (string.IsNullOrEmpty(mNameInputValue) 
            || string.IsNullOrEmpty(mDescripitonInputValue) 
            || string.IsNullOrEmpty(mImageInputValue) 
            || mPriceInputValue == 0 
            || mMaxNumberOfGuestsInputValue == 0
            || DateStartInput.Value.HasValue == false 
            || DateStartInput.Value.Value < DateTime.Now
            || DurationInput.Value.HasValue == false
            || DurationInput.Value.Value == new TimeSpan(0))
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Empty form input", "Please fill out every input in the form");
                return;
            }

            mDateStartInputValue = DateStartInput.Value.Value;
            mDurationValue = DurationInput.Value.Value;
            mIsPrivateInputValue = IsPrivateInput.Value;

            Pin eventPin = null;

            // If the event is private...
            if(mIsPrivateInputValue)
            {
                if(string.IsNullOrEmpty(PinInput.Text) || string.IsNullOrEmpty(ConfirmPinInput.Text))
                {
                    HelperMethods.ShowMessage(MessageType.Error, "No pin created", "Please fill out a PIN value in both inputs for the event");
                    return;
                }

                if(PinInput.Text != ConfirmPinInput.Text)
                {
                    HelperMethods.ShowMessage(MessageType.Error, "PIN do not match", "The two PIN are different. PLease try again.");
                    return;
                }

                mCodeInputValue = int.Parse(PinInput.Text);

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

            var facility = mFacilityInputValue;

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

            if(facility.Events != null)
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

            HelperMethods.ShowMessage(MessageType.Information, "Event created", $"The event {newEvent.Name} has been created! You can find it in the 'Events' page.");
        }

        private async void ShowFacilityForm()
        {
            var result = await DialogHelpers.ShowValidationDialogAsync<FacilityFormDialog>(null, null, null, x =>
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
                    mFacilityFormDialog = y;
                };
            });

            if (result.Feedback)
            {
                FacilityFormSaveButton_OnClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FacilityFormSaveButton_OnClick()
        {
            mFacilityNameInputValue = mFacilityFormDialog.NameInput.Text;
            mFacilityDescriptionInputValue = mFacilityFormDialog.DescriptionInput.Text;
            mFacilityImageInputValue = mFacilityFormDialog.NameInput.Text;
            mFacilityAreaInputValue = (double)mFacilityFormDialog.AreaInput.Value;
            mFacilityCapacityInputValue = (uint)mFacilityFormDialog.CapacityInput.Value;
            mFacilityFloorInputValue = mFacilityFormDialog.FloorInput.Value;

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

            HelperMethods.ShowMessage(MessageType.Information, "Facility created!", $"The facility '{mFacilityNameInputValue}' has been created!");
        }

        private void ClearData()
        {
            mNameInputValue = string.Empty;
            mDescripitonInputValue = string.Empty;
            mImageInputValue = string.Empty;
            mFacilityInputValue = null;
            mMaxNumberOfGuestsInputValue = 0;
            mPriceInputValue = 0;
            mDateStartInputValue = DateTime.Now;
            mDurationValue = new TimeSpan(0);
            mIsPrivateInputValue = false;

            mFacilityNameInputValue = string.Empty;
            mFacilityDescriptionInputValue = string.Empty;
            mFacilityImageInputValue = string.Empty;
            mFacilityAreaInputValue = 0;
            mFacilityCapacityInputValue = 0;
            mFacilityFloorInputValue = null;

        }

        #endregion
    }
}

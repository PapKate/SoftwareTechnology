using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

namespace VirtualReceptionist
{
    public partial class EventCheckInDialog
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Model"/> property
        /// </summary>
        private Event mModel;

        private bool mIsChecked = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// The service's model
        /// </summary>
        [Parameter]
        public Event Model
        {
            get => mModel;
            set
            {
                mModel = value;
                StateHasChanged();
            }
        }

        /// <summary>
        /// The is reservation checkbox
        /// </summary>
        public CheckBox IsReservationCheckbox { get; set; }

        /// <summary>
        /// The country code input
        /// </summary>
        public TextInput CountryCodeInput { get; set; }

        /// <summary>
        /// The phone number input
        /// </summary>
        public TextInput PhoneNumberInput { get; set; }

        /// <summary>
        /// The number of guests input
        /// </summary>
        public TextInput NumberOfGuestsInput { get; set; }

        /// <summary>
        /// The lock pin input
        /// </summary>
        public TextInput LockPinInput { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventCheckInDialog() : base()
        {

        }

        #endregion
    }
}

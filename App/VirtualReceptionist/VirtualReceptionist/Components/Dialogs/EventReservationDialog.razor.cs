using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System;

namespace VirtualReceptionist
{
    public partial class EventReservationDialog
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Model"/> property
        /// </summary>
        private Event mModel;

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
        /// The first name input
        /// </summary>
        public TextInput FirstNameInput { get; set; }

        /// <summary>
        /// The last name input
        /// </summary>
        public TextInput LastNameInput { get; set; }

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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventReservationDialog() : base()
        {

        }

        #endregion
    }
}

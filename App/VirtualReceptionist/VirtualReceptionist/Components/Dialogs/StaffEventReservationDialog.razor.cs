using Atom;
using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualReceptionist
{
    public partial class StaffEventReservationDialog
    {
        #region Public Properties

        /// <summary>
        /// The hotel's pin
        /// </summary>
        [Parameter]
        public Pin HotelPin { get; set; }

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

        /// <summary>
        /// The image input
        /// </summary>
        public SearchMenuInput<Event> EventInput { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StaffEventReservationDialog() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                HotelPin = GlobalData.Hotel.Pin;

                var events = Data.Hotels.First(x => x.Pin == HotelPin).Floors.SelectMany(x => x.Facilities ?? Enumerable.Empty<Facility>()).SelectMany(x => x.Events ?? Enumerable.Empty<Event>()).ToList();

                EventInput.DataRetriever = (async search =>
                {
                    var result = new Failable<IEnumerable<Event>>(events.Where(x => x.Name.Contains(search)).ToList());

                    return await Task.FromResult<IFailable<IEnumerable<Event>>>(result);
                });

                EventInput.TextSelector = x => x.Name;
                EventInput.VectorSourceSelector = x => x.Name;
            }
        }

        #endregion

    }
}

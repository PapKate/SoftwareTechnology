using Atom;
using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualReceptionist
{
    public partial class FacilityFormDialog
    {
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
        /// The image input
        /// </summary>
        public TextInput ImageInput { get; set; }

        /// <summary>
        /// The description input
        /// </summary>
        public TextInput DescriptionInput { get; set; }

        /// <summary>
        /// The area input
        /// </summary>
        public NumericInput AreaInput { get; set; }

        /// <summary>
        /// The capacity input
        /// </summary>
        public NumericInput CapacityInput { get; set; }

        /// <summary>
        /// The floor search input
        /// </summary>
        public SearchMenuInput<Floor> FloorInput { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public FacilityFormDialog() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                HotelPin = GlobalData.Hotel.Pin;

                var floors = Data.Hotels.First(x => x.Pin == HotelPin).Floors.ToList();

                FloorInput.DataRetriever = (async search =>
                {
                    var result = new Failable<IEnumerable<Floor>>(floors.Where(x => x.Name.Contains(search)).ToList());

                    return await Task.FromResult<IFailable<IEnumerable<Floor>>>(result);
                });

                FloorInput.TextSelector = x => x.Name;
                FloorInput.VectorSourceSelector = x => x.Name;
            }
        }

        #endregion
    }
}

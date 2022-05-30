using Microsoft.AspNetCore.Components;

namespace VirtualReceptionist
{
    public partial class Header
    {
        #region Public Properties

        /// <summary>
        /// The hotel's name
        /// </summary>
        [Parameter]
        public string HotelName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Header() : base()
        {

        }

        #endregion
    }
}

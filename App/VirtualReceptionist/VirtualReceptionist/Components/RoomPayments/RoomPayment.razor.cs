using Atom;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using System;
using System.Threading.Tasks;

namespace VirtualReceptionist
{
    public partial class RoomPayment
    {
        #region Private Members

        /// <summary>
        /// The default icon's style
        /// </summary>
        private string mDefaultIconStyle;

        /// <summary>
        /// The image's style
        /// </summary>
        private string mImageStyle;

        private double mTotalPrice;

        #endregion

        #region Public Properties

        /// <summary>
        /// The model
        /// </summary>
        [Parameter]
        public RoomCheckIn Model { get; set; }

        /// <summary>
        /// Indicates whether the small description is displayed
        /// </summary>
        [Parameter]
        public bool IsPreview { get; set; } = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RoomPayment() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnInitialized()
        {
        
            var days = (Model.DateEnded - Model.DateCreated).Days;
            mTotalPrice = Model.Room.Price * days;
        }

        protected void OnImageError()
        {
            // Shows the default icon element
            mDefaultIconStyle = "display:flex;";
            // Hides the image element
            mImageStyle = "display:none;";
        }

        /// <summary>
        /// Checks into or out of the service when clicked
        /// </summary>
        /// <returns></returns>
        protected async Task EventClicked(MouseEventArgs args)
        {
            await OnClick.InvokeAsync(Model);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fires when the right click is pressed
        /// </summary>
        [Parameter]
        public EventCallback<RoomCheckIn> OnClick { get; set; }

        #endregion
    }
}

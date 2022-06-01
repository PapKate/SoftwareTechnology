using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using System.Threading.Tasks;

namespace VirtualReceptionist
{
    public partial class EventPreview
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

        #endregion

        #region Public Properties

        /// <summary>
        /// The model
        /// </summary>
        [Parameter]
        public Event Model { get; set; }

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
        public EventPreview() : base()
        {

        }

        #endregion

        #region Protected Methods

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
            if (args.Button == 2 || args.Button == -1)
            {
                await RightClick.InvokeAsync(Model);

                return;
            }
            await OnClick.InvokeAsync(Model);
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Fires when the right click is pressed
        /// </summary>
        [Parameter]
        public EventCallback<Event> OnClick { get; set; }

        /// <summary>
        /// Fires when the right click is pressed
        /// </summary>
        [Parameter]
        public EventCallback<Event> RightClick { get; set; }

        #endregion
    }
}

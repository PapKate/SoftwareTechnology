using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace VirtualReceptionist
{
    public partial class UserTypeButton
    {
        #region Public Properties

        /// <summary>
        /// The image
        /// </summary>
        [Parameter]
        public string Image { get; set; }

        /// <summary>
        /// The user type
        /// </summary>
        [Parameter]
        public UserType Type { get; set; }

        /// <summary>
        /// The background color
        /// </summary>
        [Parameter]
        public string BackColor { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserTypeButton() : base()
        {

        }

        #endregion

        #region Public Events

        /// <summary>
        /// Handles the click
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        #endregion
    }
}

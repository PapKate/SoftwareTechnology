using Microsoft.AspNetCore.Components;

namespace VirtualReceptionist
{
    public partial class EventPreviewDialog
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

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventPreviewDialog() : base()
        {

        }

        #endregion
    }
}

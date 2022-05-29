using System.Collections.Generic;

namespace VirtualReceptionist.Pages
{
    public partial class VisitorEventsPage
    {
        #region Private Members

        /// <summary>
        /// A list containing all the events
        /// </summary>
        private IEnumerable<Event> mEvents = new List<Event>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public VisitorEventsPage() : base()
        {

        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Method invoked when the component is ready to start, having received its initial
        /// parameters from its parent in the render tree.
        /// </summary>
        protected override void OnInitialized()
        {
            mEvents = Event.GetEvents();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Opens the form for an event reservation
        /// </summary>
        /// <param name="event">The event</param>
        private void OpenEventReservationForm(Event @event)
        {

        }

        #endregion
    }
}

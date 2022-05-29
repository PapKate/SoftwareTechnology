namespace VirtualReceptionist
{
    /// <summary>
    /// Represents an event check in
    /// </summary>
    public class EventChekcIn
    {
        #region Public Properties

        /// <summary>
        /// A flag indicating whether it is a reservation
        /// </summary>
        public bool IsReservation { get; set; }

        /// <summary>
        /// The event reservation
        /// </summary>
        public EventReservation EventReservation { get; set; }

        /// <summary>
        /// The number of guests
        /// </summary>
        public uint NumberOfguests { get; set; }

        /// <summary>
        /// The event
        /// </summary>
        public Event Event { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventChekcIn() : base()
        {

        }

        #endregion

        #region Public Methods

        public EventChekcIn CreateEventCheckIn(Event @event, bool isReservation, Phone phone, uint numberOfGuests)
        {
            return new EventChekcIn();
        }

        public EventChekcIn CreatePrivateEventCheckIn(Event @event, Pin eventPin , Phone phone, uint numberOfGuests)
        {
            return new EventChekcIn();
        }

        #endregion
    }
}

using System.Linq;

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
        /// The event
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        /// The phone
        /// </summary>
        public Phone Phone { get; set; }    

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

        public static EventChekcIn CreateEventCheckIn(Event @event, bool isReservation, EventReservation reservation, Phone phone, uint numberOfGuests, Pin hotelPin)
        {
            var eventCheckIn = new EventChekcIn()
            {
                Event = @event,
                EventReservation = reservation,
                IsReservation = isReservation,
                NumberOfguests = numberOfGuests,
                Phone = phone
            };

            AddEventCheckIn(eventCheckIn, hotelPin);

            return eventCheckIn;
        }

        /// <summary>
        /// Adds an event check in to the hotel with the given  <paramref name="hotelPin"/>
        /// </summary>
        /// <param name="eventChekcIn"></param>
        /// <param name="hotelPin"></param>
        public static void AddEventCheckIn(EventChekcIn eventChekcIn, Pin hotelPin)
        {
            // Gets the hotel with the given pin
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            var currentEvent = hotel.Floors.First(x => x == eventChekcIn.Event.Facility.Floor).Facilities.First(x => x == eventChekcIn.Event.Facility).Events.First(x => x == eventChekcIn.Event);

            var eventCheckIns = currentEvent.EventCheckIns.ToList();

            eventCheckIns.Add(eventChekcIn);

            currentEvent.EventCheckIns = eventCheckIns;
        }

        #endregion
    }
}

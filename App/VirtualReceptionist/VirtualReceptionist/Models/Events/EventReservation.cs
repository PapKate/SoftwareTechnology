using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents an event reservation
    /// </summary>
    public class EventReservation
    {
        #region Public Properties

        /// <summary>
        /// The event
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        /// The phone
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// A flag indicating whether it is paid
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// The number of guests
        /// </summary>
        public uint NumberOfGuests { get; set; }

        /// <summary>
        /// The first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The date created
        /// </summary>
        public DateTime DateCreated { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventReservation() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates an event reservation
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="numberOfGuests"></param>
        /// <param name="isPaid"></param>
        /// <param name="event"></param>
        /// <returns></returns>

        public static EventReservation CreateEventReservation(string firstName, string lastName, Phone phone, uint numberOfGuests, bool isPaid, Event @event, Pin hotelPin)
        {

            var eventReservation = new EventReservation()
            { 
                FirstName = firstName,
                LastName = lastName,    
                Phone = phone,
                NumberOfGuests = numberOfGuests,
                Event = @event,

                IsPaid = isPaid,

                DateCreated = DateTime.Now
            };

            // Adds the reservation
            AddEventReservation(hotelPin, eventReservation);

            return eventReservation;

        }

        /// <summary>
        /// Adds an <paramref name="eventReservation"/> to the hotel with the given <paramref name="hotelPin"/>
        /// </summary>
        /// <param name="hotelPin"></param>
        /// <param name="eventReservation"></param>
        public static void AddEventReservation(Pin hotelPin, EventReservation eventReservation)
        {
            // Gets the hotel from the hotels with pin the given pin
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            // Gets the floor where the facility needs to be added
            var floor = hotel.Floors.First(x => x == eventReservation.Event.Facility.Floor);

            var facility = floor.Facilities.First(x => x == eventReservation.Event.Facility);

            var currentEvent = facility.Events.First(x => x == eventReservation.Event);

            var eventReservations = currentEvent.EventReservations.ToList();

            // Adds the event
            eventReservations.Add(eventReservation);

            currentEvent.EventReservations = eventReservations;
        }

        /// <summary>
        /// Gets the reservations of the hotel with the given <paramref name="hotelPin"/>
        /// </summary>
        /// <param name="hotelPin"></param>
        /// <returns></returns>
        public static IEnumerable<EventReservation> GetEventReservations(Pin hotelPin)
        {
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            return hotel.Floors.SelectMany(x => x.Facilities).SelectMany(x => x.Events).SelectMany(x => x.EventReservations);
        }

        #endregion
    }
}

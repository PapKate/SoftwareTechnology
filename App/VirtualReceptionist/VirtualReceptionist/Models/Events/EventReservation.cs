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
        /// <param name="event"></param>
        /// <returns></returns>
        public EventReservation CreateEventReservation(string firstName, string lastName, Phone phone, uint numberOfGuests, Event @event)
        {
            return new EventReservation();
        }

        public EventReservation AddEventReservation(EventReservation eventReservation)
        {
            return eventReservation;
        }

        public IEnumerable<EventReservation> GetEventReservations()
        {
            return Enumerable.Empty<EventReservation>();
        }

        #endregion
    }
}

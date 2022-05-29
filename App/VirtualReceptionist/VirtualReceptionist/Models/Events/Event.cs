using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    /// <summary>
    ///  Represents an event
    /// </summary>
    public class Event
    {
        #region Public Properties

        /// <summary>
        /// The image
        /// </summary>
        public Uri Image { get; set; }

        /// <summary>
        /// The facility
        /// </summary>
        public Facility Facility { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The price per person
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The maximum number of guests for this event
        /// </summary>
        public uint MaxNumberOfGuests { get; set; }

        /// <summary>
        /// A flag indicating whether it is private
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// The pin of the private event 
        /// </summary>
        public Pin Pin { get; set; }

        /// <summary>
        /// The date start
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// The duration
        /// </summary>
        public TimeSpan Duration { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Event() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates and returns an event
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="maxNumberOfGuests"></param>
        /// <param name="price"></param>
        /// <param name="image"></param>
        /// <param name="pin"></param>
        /// <param name="facility"></param>
        /// <param name="dateStart"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static Event CreateEvent(Pin hotelPin, string name, string description, uint maxNumberOfGuests, double price, Uri image, Pin pin, Facility facility, DateTime dateStart, TimeSpan duration, bool isPrivate = false)
        {
            var newEvent = new Event()
            {
                Name = name,
                DateStart = dateStart,
                Description = description,
                Price = price,
                Duration = duration,
                Facility = facility,
                Image = image,
                Pin = pin,
                IsPrivate = isPrivate,
                MaxNumberOfGuests = maxNumberOfGuests
            };

            AddEvent(newEvent, hotelPin);

            return newEvent;
        }

        /// <summary>
        /// Adds an event to the hotel with pin the given pin
        /// </summary>
        /// <param name="event"></param>
        /// <param name="hotelPin"></param>
        public static void AddEvent(Event @event, Pin hotelPin)
        {
            // Gets the hotel from the hotels with pin the given pin
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            // Gets the floor where the facility needs to be added
            var floor = hotel.Floors.First(x => x == @event.Facility.Floor);

            var facility = floor.Facilities.First(x => x == @event.Facility);

            var events = facility.Events.ToList();

            events.Add(@event);

            facility.Events = events;
        }

        /// Gets all the events of each hotel
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Event> GetEvents()
        {
            // Gets all the facilities of the hotel
            var facilities = Data.Hotels.SelectMany(x => x.Floors).SelectMany(x => x.Facilities).ToList();

            // Gets all the events from all the facilities
            var events = facilities.SelectMany(x => x.Events).ToList();

            // Returns the events
            return events;
        }

        /// <summary>
        /// Gets all the events
        /// </summary>
        /// <param name="hotelPin">The hotel's pin</param>
        /// <returns></returns>
        public IEnumerable<Event> GetEvents(Pin hotelPin)
        {
            // Gets the hotel with the given pin
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            // Gets all the facilities of the hotel
            var facilities = hotel.Floors.SelectMany(x => x.Facilities).ToList();

            // Gets all the events from all the facilities
            var events = facilities.SelectMany(x => x.Events).ToList();

            // Returns the events
            return events;
        }

        /// <summary>
        /// Edits the given <paramref name="event"/>
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns></returns>
        public Event EditEvent(Event @event)
        {
            return new Event();
        }

        /// <summary>
        /// Deletes the given <paramref name="event"/>
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns></returns>
        public Event DeleteEvent(Event @event)
        {
            return new Event();
        }

        #endregion
}

﻿using System;
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
        /// Gets all the events
        /// </summary>
        /// <param name="hotelPin">The hotel's pin</param>
        /// <returns></returns>
        public IEnumerable<Event> GetEvents(Pin hotelPin)
        {
            return Enumerable.Empty<Event>();
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
}
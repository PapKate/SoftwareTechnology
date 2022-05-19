using System;
using System.Collections.Generic;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a hotel
    /// </summary>
    public class Hotel
    {
        #region Public Properties
        
        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The hotel's representative pin
        /// </summary>
        public Pin Pin { get; set; }

        /// <summary>
        /// The date created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The floors
        /// </summary>
        public IEnumerable<Floor> Floors { get; set; }

        /// <summary>
        /// The events
        /// </summary>
        public IEnumerable<Event> Events { get; set; }

        /// <summary>
        /// The staff
        /// </summary>
        public IEnumerable<Staff> Staff { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Hotel() : base()
        {

        }

        #endregion
    }
}

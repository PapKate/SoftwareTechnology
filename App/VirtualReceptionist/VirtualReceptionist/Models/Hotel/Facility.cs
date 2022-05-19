using System;
using System.Collections;
using System.Collections.Generic;

namespace VirtualReceptionist
{
    public class Facility
    {
        #region Public Properties

        /// <summary>
        /// The events
        /// </summary>
        public IEnumerable<Event> Events { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Facility() : base()
        {

        }

        #endregion

        #region Public Methods

        public IEnumerable<Facility> GetFacilities(Pin hotelPin)
        {
            return null;
        }

        public Facility CreateFacility(string name, Floor floor, Uri image, double area, uint capacity, bool isOccupied, string descripiton)
        {
            return new Facility(); 
        }

        public void AddFacility(Facility facility, Pin hotelPin)
        {

        }
     
        #endregion
    }
}

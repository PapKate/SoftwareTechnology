using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    public class Facility : FloorArea
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

        /// <summary>
        /// Gets all the facilities of the hotel with the given <paramref name="hotelPin"/>
        /// </summary>
        /// <param name="hotelPin">The hotel's unique pin</param>
        /// <returns></returns>
        public static IEnumerable<Facility> GetFacilities(Pin hotelPin)
        {
            // Gets the hotel from the hotels with pin the given pin
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            // Gets all the facilities from the hotel's floors
            var facilities = hotel.Floors.SelectMany(x => x.Facilities).ToList();

            // Returns the facilities
            return facilities;
        }

        /// <summary>
        /// Creates and returns a new facility
        /// </summary>
        /// <returns></returns>
        public static Facility CreateFacility(Pin hotelPin, string name, Floor floor, Uri image, double area, uint capacity, bool isOccupied, string descripiton)
        {
            var newFacility = new Facility()
            { 
                Name = name,
                Floor = floor,
                Area = area,
                Capacity = capacity,
                IsOccupied = isOccupied,
                Description = descripiton,
                Image = image,
            };

            AddFacility(newFacility, hotelPin);

            return newFacility;
        }

        /// <summary>
        /// Adds the facility to the hotel with the given <paramref name="hotelPin"/>
        /// </summary>
        /// <param name="facility"></param>
        /// <param name="hotelPin">The hotel's unique pin</param>
        public static void AddFacility(Facility facility, Pin hotelPin)
        {
            // Gets the hotel from the hotels with pin the given pin
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            // Gets the floor where the facility needs to be added
            var floor = hotel.Floors.First(x => x == facility.Floor);

            //TODO 
            var facilities = floor.Facilities.ToList();
            facilities.Add(facility);

            floor.Facilities = facilities;
        }
     
        #endregion
    }
}

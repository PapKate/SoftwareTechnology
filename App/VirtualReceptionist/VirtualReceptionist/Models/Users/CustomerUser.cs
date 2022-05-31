using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public class CustomerUser : User
    {
        #region Public Properties

        /// <summary>
        /// The customer's event reservations
        /// </summary>
        public IEnumerable<CustomerEventReservation> CustomerEventReservations { get; set; }

        /// <summary>
        /// The room check in
        /// </summary>
        public RoomCheckIn RoomCheckIn { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerUser() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public CustomerUser CreateCustomer(Phone phone, Pin hotelPin)
        {
            var pin = HelperMethods.GeneratePin();

            return new CustomerUser() 
            {
                Phone = phone,
                Pin = pin
            };
        }

        /// <summary>
        /// Gets the customer with the specified <paramref name="customerPin"/>
        /// </summary>
        /// <param name="hotelPin"></param>
        /// <param name="customerPin"></param>
        /// <returns></returns>
        public static CustomerUser GetCustomer(Pin hotelPin, Pin customerPin)
        {
            // Gets the hotel
            var hotel = Data.Hotels.First(x => x.Pin == hotelPin);

            // Gets the room check ins that are active
            var activeRoomCheckins = hotel.Floors.SelectMany(x => x.Rooms).SelectMany(x => x.RoomCheckIns).Where(x => x.DateEnded > DateTime.Now).ToList();
            // Gets the customers from the room check ins
            var customers = activeRoomCheckins.Select(x => x.Customer).ToList();

            // Return the customer with pin the given pin
            return customers.FirstOrDefault(x => x.Pin == customerPin);
        }

        #endregion
    }
}

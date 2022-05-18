using System;
using System.Collections.Generic;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a customer
    /// </summary>
    public class Customer : User
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
        public Customer() : base()
        {

        }

        #endregion

        #region Public Methods

        public Customer CreateCustomer(Phone phone)
        {
            return new Customer();
        }

        #endregion
    }
}

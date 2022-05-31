using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a customer's event reservation
    /// </summary>
    public class CustomerEventReservation : EventReservation
    {
        #region Public Properties

        /// <summary>
        /// The customer
        /// </summary>
        public CustomerUser Customer { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerEventReservation() : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a customer event reservation
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="numberOfGuests"></param>
        /// <param name="event"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerEventReservation CreateEventReservation(string firstName, string lastName, Phone phone, uint numberOfGuests, bool isPaid, Event @event, Pin hotelPin, CustomerUser customer)
        {
            var eventReservation = new CustomerEventReservation()
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

        public static IEnumerable<CustomerEventReservation> GetCustomerReservations(CustomerUser customer)
        {
            return customer.CustomerEventReservations;
        }

        public static IEnumerable<CustomerEventReservation> GetCustomerUnpaidReservations(CustomerUser customer)
        {
            return customer.CustomerEventReservations.Where(x => x.IsPaid == false).ToList();
        }

        #endregion
    }
}

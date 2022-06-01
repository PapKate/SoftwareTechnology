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
        public Customer Customer { get; set; }

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
        public static CustomerEventReservation CreateEventReservation(string firstName, string lastName, Phone phone, uint numberOfGuests, Event @event, Customer customer)
        {
            return new CustomerEventReservation();
        }

        public static void AddCustomerEventReservation(CustomerEventReservation customerEventReservation)
        {
        }

        public static IEnumerable<CustomerEventReservation> GetCustomerReservations(Customer customer)
        {
            return Enumerable.Empty<CustomerEventReservation>();
        }

        public static IEnumerable<CustomerEventReservation> GetCustomerUnpaidReservations(Customer customer)
        {
            return Enumerable.Empty<CustomerEventReservation>();
        }

        #endregion
    }
}

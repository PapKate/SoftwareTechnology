using System;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a room check in
    /// </summary>
    public class RoomCheckIn
    {
        #region Public Properties

        /// <summary>
        /// The room
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// The customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// The number of guests
        /// </summary>
        public uint NumberOfGuests { get; set; }

        /// <summary>
        /// The room's review
        /// </summary>
        public RoomReview RoomReview { get; set; }
    
        /// <summary>
        /// The date the check in was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RoomCheckIn() : base()
        {

        }

        #endregion

        #region Public Methods
         
        /// <summary>
        /// Creates a room check in
        /// </summary>
        /// <param name="room"></param>
        /// <param name="numberOfGuests"></param>
        /// <param name="phone"></param>
        public void CreateRoomCheckIn(Room room, uint numberOfGuests, Phone phone)
        {
            // creates the customer first
        }



        #endregion
    }

}

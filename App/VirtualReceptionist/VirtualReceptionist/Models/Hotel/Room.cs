using System.Collections.Generic;
using System.Linq;

namespace VirtualReceptionist
{
    public class Room
    {
        #region Public Properties

        /// <summary>
        /// A flag indicating whether it is occupied
        /// </summary>
        public bool IsOccupied { get; set; }

        /// <summary>
        /// The price per night
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// The room's reviews
        /// </summary>
        public IEnumerable<RoomReview> RoomReviews { get; set; }

        /// <summary>
        /// The room check ins
        /// </summary>
        public IEnumerable<RoomCheckIn> RoomCheckIns { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Room() : base()
        {

        }

        #endregion

        #region Public Methods

        public IEnumerable<Room> GetRooms(Pin hotelPin)
        {
            return Enumerable.Empty<Room>();
        }

        #endregion
    }
}

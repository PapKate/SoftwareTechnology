using System.Collections.Generic;

namespace VirtualReceptionist
{
    public class RoomReview
    {
        #region Public Properties

        /// <summary>
        /// The comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// The room's reviews
        /// </summary>
        public IEnumerable<Review> Reviews { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RoomReview() : base()
        {

        }

        #endregion

        #region Public Methods

        public RoomReview CreateRoomReview(RoomCheckIn roomCheckIn, string comments, IEnumerable<Review> reviews)
        {
            return new RoomReview();
        }

        public RoomReview EditRoomReview(RoomReview roomReview)
        {
            return new RoomReview();
        }

        public RoomReview DeleteRoomReview(RoomReview roomReview)
        {
            return new RoomReview();
        }

        #endregion
    }
}

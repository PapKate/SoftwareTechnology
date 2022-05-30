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

        public static RoomReview CreateRoomReview(RoomCheckIn roomCheckIn, string comments, IEnumerable<Review> reviews)
        {
            var roomReview = new RoomReview() 
            {
                Reviews = reviews,
                Comments = comments
            };

            roomCheckIn.RoomReview = roomReview;

            return roomReview;
        }

        public static RoomReview EditRoomReview(RoomCheckIn roomCheckIn, string comments, IEnumerable<Review> reviews)
        {
            if(roomCheckIn.RoomReview.Comments != comments)
                roomCheckIn.RoomReview.Comments = comments;
            if(roomCheckIn.RoomReview.Reviews != reviews)
                roomCheckIn.RoomReview.Reviews = reviews;

            return roomCheckIn.RoomReview;
        }

        public static RoomReview DeleteRoomReview(RoomCheckIn roomCheckIn, RoomReview roomReview)
        {
            roomCheckIn.RoomReview = null;
            
            return roomReview;
        }

        #endregion
    }
}

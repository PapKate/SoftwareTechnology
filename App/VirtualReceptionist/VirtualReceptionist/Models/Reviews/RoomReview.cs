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
    }
}

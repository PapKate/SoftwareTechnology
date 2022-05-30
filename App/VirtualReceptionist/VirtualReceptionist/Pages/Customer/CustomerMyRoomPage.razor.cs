using Microsoft.AspNetCore.Components;

using System.Collections.Generic;

namespace VirtualReceptionist.Pages.Customer
{
    public partial class CustomerMyRoomPage
    {
        #region Private Members

        private Review mStaffReview;
        private Review mCleanlinessReview;
        private Review mComfortReview;
        private Review mFacilitiesReview;
        private string mComments = string.Empty;

        private bool mIsEditable;
        private RoomReview mRoomReview;

        #endregion

        #region Public Properties

        /// <summary>
        /// The room check in
        /// </summary>
        [Parameter]
        public RoomCheckIn RoomCheckIn { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomerMyRoomPage() : base()
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Edits the review
        /// </summary>
        private void EditReview()
        {
            mIsEditable = true;
        }

        /// <summary>
        /// Sets a new review
        /// </summary>
        private void SetReview()
        {
            mIsEditable = false;

            // If any review is empty...
            if(mStaffReview.NumberOfStars == 0
            || mCleanlinessReview.NumberOfStars == 0
            || mComfortReview.NumberOfStars == 0
            || mFacilitiesReview.NumberOfStars == 0)
            {
                // Show the error
                HelperMethods.ShowMessage(MessageType.Error, "Invalid review", "Please fill the stars and try again.");
                return;
            }

            var reviews = new List<Review>() { mStaffReview, mCleanlinessReview, mComfortReview, mFacilitiesReview };

            mRoomReview = RoomReview.CreateRoomReview(RoomCheckIn, mComments, reviews);

            if(RoomCheckIn.RoomReview == null)
                HelperMethods.ShowMessage(MessageType.Error, "Review created", $"Your review of the room {RoomCheckIn.Room.Name} has been created.");
            else
                HelperMethods.ShowMessage(MessageType.Error, "Review updated", $"Your review of the room {RoomCheckIn.Room.Name} has been updated.");
        }

        /// <summary>
        /// Deleted a review
        /// </summary>
        private void DeleteReview()
        {
            RoomReview.DeleteRoomReview(RoomCheckIn, mRoomReview);
            
            HelperMethods.ShowMessage(MessageType.Error, "Review deleted", $"Your review of the room {RoomCheckIn.Room.Name} has been removed.");
        }

        /// <summary>
        /// Cancel's a review
        /// </summary>
        private void CancelReview()
        {
            mIsEditable = false;
        }

        #endregion
    }
}

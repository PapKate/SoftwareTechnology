using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;

namespace VirtualReceptionist
{
    public partial class CustomerMyRoomPage
    {
        #region Private Members

        private Review mStaffReview = new Review() { Name = "Staff" };
        private Review mCleanlinessReview = new Review() { Name = "Cleanliness" };
        private Review mComfortReview = new Review() { Name = "Comfort" };
        private Review mFacilitiesReview = new Review() { Name = "Facilities" };
        private TextInput mComments;

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

        #region Protected Methods

        protected override void OnInitialized()
        {
            RoomCheckIn = GlobalData.RoomCheckIn;
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

            var firstReview = RoomCheckIn.RoomReview == null;

            mRoomReview = RoomReview.CreateRoomReview(RoomCheckIn, mComments.Text, reviews);

            if(firstReview)
                HelperMethods.ShowMessage(MessageType.Information, "Review created", $"Your review of the room {RoomCheckIn.Room.Name} has been created.");
            else
                HelperMethods.ShowMessage(MessageType.Information, "Review updated", $"Your review of the room {RoomCheckIn.Room.Name} has been updated.");
        }

        /// <summary>
        /// Deleted a review
        /// </summary>
        private void DeleteReview()
        {
            CancelReview();
            RoomReview.DeleteRoomReview(RoomCheckIn, mRoomReview);
            
            HelperMethods.ShowMessage(MessageType.Error, "Review deleted", $"Your review of the room {RoomCheckIn.Room.Name} has been removed.");
        }

        /// <summary>
        /// Cancel's a review
        /// </summary>
        private void CancelReview()
        {
            mIsEditable = false;
            mCleanlinessReview.NumberOfStars = 0;
            mStaffReview.NumberOfStars = 0;
            mComfortReview.NumberOfStars = 0;
            mFacilitiesReview.NumberOfStars = 0;
        }

        #endregion
    }
}

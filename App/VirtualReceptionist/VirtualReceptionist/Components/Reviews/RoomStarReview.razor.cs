using Atom;
using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class RoomStarReview
    {
        #region Private Members

        private VectorSource mFirstStar = StarOutlinePath;
        private VectorSource mSecondStar = StarOutlinePath;
        private VectorSource mThirdStar = StarOutlinePath;
        private VectorSource mForthStar = StarOutlinePath;
        private VectorSource mFifthStar = StarOutlinePath;

        private Review mModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The model
        /// </summary>
        [Parameter]
        public Review Model 
        { 
            get => mModel;
            set
            {
                mModel = value;
                if(Model.NumberOfStars == 1)
                {
                    mFirstStar = StarPath;

                    mSecondStar = StarOutlinePath;

                    mThirdStar = StarOutlinePath;

                    mForthStar = StarOutlinePath;

                    mFifthStar = StarOutlinePath;
                }
                else if (Model.NumberOfStars == 2)
                {
                    mFirstStar = StarPath;

                    mSecondStar = StarPath;

                    mThirdStar = StarOutlinePath;

                    mForthStar = StarOutlinePath;

                    mFifthStar = StarOutlinePath;
                }
                else if (Model.NumberOfStars == 3)
                {
                    mFirstStar = StarPath;

                    mSecondStar = StarPath;

                    mThirdStar = StarPath;

                    mForthStar = StarOutlinePath;

                    mFifthStar = StarOutlinePath;
                }
                else if (Model.NumberOfStars == 4)
                {
                    mFirstStar = StarPath;

                    mSecondStar = StarPath;

                    mThirdStar = StarPath;

                    mForthStar = StarPath;

                    mFifthStar = StarOutlinePath;
                }
                else if (Model.NumberOfStars == 5)
                {
                    mFirstStar = StarPath;

                    mSecondStar = StarPath;

                    mThirdStar = StarPath;

                    mForthStar = StarPath;

                    mFifthStar = StarPath;
                }
                else
                {
                    mFirstStar = StarOutlinePath;

                    mSecondStar = StarOutlinePath;

                    mThirdStar = StarOutlinePath;

                    mForthStar = StarOutlinePath;

                    mFifthStar = StarOutlinePath;
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RoomStarReview() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                mFirstStar = StarOutlinePath;

                mSecondStar = StarOutlinePath;

                mThirdStar = StarOutlinePath;

                mForthStar = StarOutlinePath;

                mFifthStar = StarOutlinePath;
            }
        }

        #endregion

        #region Private Methods

        private void StarButton_OnClick(uint star)
        {
            Model = new Review() 
            {
                Name = Model.Name,
                NumberOfStars = star 
            };
            OnModelChanged();
        }

        private async void OnModelChanged()
        {
            await ModelChanged.InvokeAsync(Model);
        }

        #endregion

        #region Public Events 

        /// <summary>
        /// Fires every time the <see cref="RoomStarReview.Model"/> is changed
        /// </summary>
        [Parameter]
        public EventCallback<Review> ModelChanged { get; set; }

        #endregion

    }
}

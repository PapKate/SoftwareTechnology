using System;
using System.Collections.Generic;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a hotel statistics board
    /// </summary>
    public class HotelBoardData : BoardData
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Statistics"/> property
        /// </summary>
        private readonly List<BoardStatistic> mStatistics;

        #endregion

        #region Public Properties

        /// <summary>
        /// The hotel's statistics
        /// </summary>
        public IEnumerable<BoardStatistic> Statistics { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public HotelBoardData() : base()
        {

        }

        #endregion

        #region Public Methods

        public HotelBoardData AddEventBoardStatistic(BoardStatistic hotelBoardStatistic)
        {
            mStatistics.Add(hotelBoardStatistic);
            return this;
        }

        public void CreateHotelBoardStatistics()
        {
        }

        public HotelBoardData CreatetStaffWithHighestScoreChart(ChartType type, IEnumerable<RoomReview> roomReviews, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }

        public HotelBoardData CreatetMostFrequentlyVisitedFacilityChart(ChartType type, IEnumerable<Event> events, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }

        public HotelBoardData CreatetBusiestMontChart(ChartType type, IEnumerable<RoomCheckIn> roomCheckIns, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }

        public HotelBoardData CreatetFacilitiesQualityChart(ChartType type, IEnumerable<RoomReview> roomReviews, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }

        #endregion

        #region Private Methods

        private BoardStatistic GetBusiestMonth(IEnumerable<RoomCheckIn> roomCheckIns)
        {
            return new BoardStatistic();
        }
        private StarsBoardStatistic GetStaffWithHighestScore(IEnumerable<RoomReview> roomReviews)
        {
            return new StarsBoardStatistic();
        }
        private StarsBoardStatistic GetMostFrequentlyVisitedFacility(IEnumerable<Event> events)
        {
            return new StarsBoardStatistic();
        }
        private BoardStatistic GetFacilitiesQuality(IEnumerable<RoomReview> roomReviews)
        {
            return new BoardStatistic();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a room statistics board
    /// </summary>
    public class RoomBoardData
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Statistics"/> property
        /// </summary>
        private readonly List<StarsBoardStatistic> mStatistics;

        #endregion

        #region Public Properties

        /// <summary>
        /// The rooms' statistics
        /// </summary>
        public IEnumerable<StarsBoardStatistic> Statistics { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public RoomBoardData() : base()
        {

        }

        #endregion

        #region Public Methods

        public RoomBoardData AddEventBoardStatistic(StarsBoardStatistic roomBoardStatistic)
        {
            mStatistics.Add(roomBoardStatistic);
            return this;
        }

        public void CreateRoomBoardStatistics()
        {
        }

        public RoomBoardData CreatetMostUsedRoomChart(ChartType type, IEnumerable<Room> rooms, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }

        public RoomBoardData CreatetRoomWithMostCommentsChart(ChartType type, IEnumerable<Room> rooms, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }

        public RoomBoardData CreatetTopRoomChart(ChartType type, IEnumerable<Room> rooms, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }
        public RoomBoardData CreatetMostCleanRoomChart(ChartType type, IEnumerable<Room> rooms, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }
        public RoomBoardData CreatetMostComfortableRoomChart(ChartType type, IEnumerable<Room> rooms, DateTime dateStart, DateTime dateEnd)
        {
            return this;
        }

        #endregion

        #region Private Methods

        private StarsBoardStatistic GetTopRoom(IEnumerable<Room> rooms)
        {
            return new StarsBoardStatistic();
        }

        private StarsBoardStatistic GetMostCleanRoom(IEnumerable<Room> rooms)
        {
            return new StarsBoardStatistic();
        }

        private StarsBoardStatistic GetMostComfortableRoom(IEnumerable<Room> rooms)
        {
            return new StarsBoardStatistic();
        }

        private StarsBoardStatistic GetRoomWithMostComments(IEnumerable<Room> rooms)
        {
            return new StarsBoardStatistic();
        }

        private StarsBoardStatistic GetMostUsedRoom(IEnumerable<Room> rooms)
        {
            return new StarsBoardStatistic();
        }

        #endregion
    }
}

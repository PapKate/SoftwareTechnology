using System;
using System.Collections.Generic;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents an event statistics board
    /// </summary>
    public class EventBoardData : BoardData
    {
        #region Private Members

        /// <summary>
        /// The member of the <see cref="Statistics"/> property
        /// </summary>
        private readonly List<EventBoardStatistic> mStatistics;

        #endregion

        #region Public Properties

        /// <summary>
        /// The events' statistics
        /// </summary>
        public IEnumerable<EventBoardStatistic> Statistics=> mStatistics;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventBoardData() : base()
        {

        }

        #endregion

        #region Public Methods

        public EventBoardData AddEventBoardStatistic(EventBoardStatistic eventBoardStatistic)
        {
            mStatistics.Add(eventBoardStatistic);
            return this;
        }

        public void CreateEventBoardStatistics()
        {
        }

        public void CreateTopEventsChart(ChartType type, IEnumerable<Event> events, DateTime dateStart, DateTime dateEnd)
        {

        }

        public void CreateTopHotelEventsChart(ChartType type, IEnumerable<Event> events, DateTime dateStart, DateTime dateEnd)
        {

        }

        public void CreateTopPrivateEventChart(ChartType type, IEnumerable<Event> events, DateTime dateStart, DateTime dateEnd)
        {

        }

        public void CreateMostCheckedInEventChart(ChartType type, IEnumerable<Event> events, DateTime dateStart, DateTime dateEnd)
        {

        }

        public void CreateMostReservationsForEventChart(ChartType type, IEnumerable<Event> events, DateTime dateStart, DateTime dateEnd)
        {

        }
        
        public void CreateMostFrequentlyUsedFacilityChart(ChartType type, IEnumerable<Facility> facilities, DateTime dateStart, DateTime dateEnd)
        {

        }

        #endregion

        #region Private Methods

        private EventBoardStatistic GetTopEvent(IEnumerable<Event> events)
        {
            // add
            return new EventBoardStatistic();
        }

        private EventBoardStatistic GetTopHotelEvent(IEnumerable<Event> events)
        {
            // add
            return new EventBoardStatistic();
        }

        private EventBoardStatistic GetMostCheckedInEvent(IEnumerable<Event> events)
        {
            // add
            return new EventBoardStatistic();
        }

        private EventBoardStatistic GetMostReservationsForEvent(IEnumerable<Event> events)
        {
            // add
            return new EventBoardStatistic();
        }

        private EventBoardStatistic GetMostFrequentlyUsedFacility(IEnumerable<Event> events)
        {
            // add
            return new EventBoardStatistic();
        }

        private EventBoardStatistic GetTopPrivateEvent(IEnumerable<Event> events)
        {
            // add
            return new EventBoardStatistic();
        }

        #endregion
    }
}

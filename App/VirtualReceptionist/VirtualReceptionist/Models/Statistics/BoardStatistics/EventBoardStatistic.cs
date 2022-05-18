using System;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents an event board statistic
    /// </summary>
    public class EventBoardStatistic
    {
        #region Public Properties

        /// <summary>
        /// The number of participants
        /// </summary>
        public uint Participants { get; set; }

        /// <summary>
        /// The date
        /// </summary>
        public DateTime Date { get; set; }    

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventBoardStatistic() : base()
        {

        }

        #endregion
    }
}

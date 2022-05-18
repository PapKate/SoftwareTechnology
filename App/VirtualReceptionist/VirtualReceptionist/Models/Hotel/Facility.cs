using System.Collections;
using System.Collections.Generic;

namespace VirtualReceptionist
{
    public class Facility
    {
        #region Public Properties

        /// <summary>
        /// The events
        /// </summary>
        public IEnumerable<Event> Events { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Facility() : base()
        {

        }

        #endregion
    }
}

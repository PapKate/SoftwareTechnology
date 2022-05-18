using System.Collections.Generic;

namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a floor
    /// </summary>
    public class Floor
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// The floor's rooms
        /// </summary>
        public IEnumerable<Room> Rooms { get; set; }

        /// <summary>
        /// The floor's facilities
        /// </summary>
        public IEnumerable<Facility> Facilities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Floor() : base()
        {

        }

        #endregion
    }
}

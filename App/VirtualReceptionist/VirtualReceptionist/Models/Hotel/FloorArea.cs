using System;

namespace VirtualReceptionist
{
    public abstract class FloorArea 
    {
        #region Public Properties

        /// <summary>
        /// The floor
        /// </summary>
        public Floor Floor { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The area's square meters
        /// </summary>
        public double Area { get; set; }
        
        /// <summary>
        /// The capacity
        /// </summary>
        public uint Capacity { get; set; }

        /// <summary>
        /// A flag indicating whether it is occupied
        /// </summary>
        public bool IsOccupied { get; set; }

        #endregion

        #region Constructors      

        /// <summary>
        /// Default constructor
        /// </summary>
        public FloorArea() : base()
        {

        }

        #endregion
    }
}

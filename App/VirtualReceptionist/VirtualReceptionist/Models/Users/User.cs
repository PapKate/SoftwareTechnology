using System;

namespace VirtualReceptionist
{
    /// <summary>
    ///  Represents a user
    /// </summary>
    public class User
    {
        #region Public Properties

        /// <summary>
        /// The pin
        /// </summary>
        public Pin Pin { get; set; }

        /// <summary>
        /// The phone
        /// </summary>
        public Phone Phone { get; set; }

        /// <summary>
        /// The date created
        /// </summary>
        public DateTime DateCreated { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public User() : base()
        {

        }

        #endregion
    }
}

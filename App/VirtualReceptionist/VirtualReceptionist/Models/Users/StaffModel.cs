namespace VirtualReceptionist
{
    /// <summary>
    ///  Represents a staff
    /// </summary>
    public class StaffModel
    {
        #region Public Properties

        /// <summary>
        /// The first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The hotel
        /// </summary>
        public Hotel Hotel { get; set; }

        #endregion
         
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public StaffModel() : base()
        {

        }

        #endregion
    }
}

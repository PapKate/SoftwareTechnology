namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a phone number
    /// </summary>
    public class Phone
    {
        #region Public Properties

        /// <summary>
        /// The phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The country code
        /// </summary>
        public int CountryCode{ get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor 
        /// </summary>
        public Phone() : base()
        {

        }

        #endregion
    }
}

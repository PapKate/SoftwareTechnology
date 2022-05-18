namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a PIN
    /// </summary>
    public class Pin 
    {
        #region Public Properties

        /// <summary>
        /// The pin code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// A flag indicating whether the pin is active 
        /// </summary>
        public bool IsActive { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Pin() : base()
        {

        }

        #endregion
    }
}

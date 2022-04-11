namespace VirtualReceptionist.DataModels
{
    /// <summary>
    /// The pin model
    /// </summary>
    public class PinModel : BaseModel
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
        public PinModel() : base()
        {

        }

        #endregion
    }
}

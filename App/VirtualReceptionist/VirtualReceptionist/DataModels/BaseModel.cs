namespace VirtualReceptionist
{
    /// <summary>
    /// The base model
    /// </summary>
    public class BaseModel
    {
        #region Public Properties

        /// <summary>
        /// The id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date the model was created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the model was last modified
        /// </summary>
        public DateTime DateModified { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseModel() : base()
        {

        }

        #endregion
    }
}

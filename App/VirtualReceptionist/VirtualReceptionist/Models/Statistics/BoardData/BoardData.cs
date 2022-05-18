namespace VirtualReceptionist
{
    /// <summary>
    /// Represents a statistics board
    /// </summary>
    public abstract class BoardData
    {
        #region Public Properties

        /// <summary>
        /// The title
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BoardData() : base()
        {

        }

        #endregion
    }
}

namespace VirtualReceptionist
{
    public class Review
    {
        #region Public Properties

        /// <summary>
        /// The number of stars 
        /// </summary>
        public uint NumberOfStars { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Review() : base()
        {
             
        }

        #endregion
    }
}

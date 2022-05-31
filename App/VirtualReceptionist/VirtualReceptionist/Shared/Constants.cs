namespace VirtualReceptionist
{
    public static class Constants
    {
        public const string AppName = "Virtual Receptionist";

        #region Palette

        /// <summary>
        /// White
        /// </summary>
        public const string White = "FFFFFF";
        
        /// <summary>
        /// Red crayola
        /// </summary>
        public const string Red = "ED254E";

        /// <summary>
        /// Emerald
        /// </summary>
        public const string Green = "45CB85";

        /// <summary>
        /// Yellow crayola
        /// </summary>
        public const string Yellow = "FFE66D";

        /// <summary>
        /// Cobalt blue
        /// </summary>
        public const string Blue = "1446A0";

        /// <summary>
        /// Pale purple pantone
        /// </summary>
        public const string PalePurple = "F1E3F3";

        /// <summary>
        /// Lavender blue
        /// </summary>
        public const string Lavender = "C1CEFE";

        /// <summary>
        /// Dark liver
        /// </summary>
        public const string Gray = "55505C";

        #endregion

        #region Icon paths

        public const string BalloonPath = "M13.16,12.74L14,14H12.5C12.35,16.71 12,19.41 11.5,22.08L10.5,21.92C11,19.3 11.34,16.66 11.5,14H10L10.84,12.74C8.64,11.79 7,8.36 7,6A5,5 0 0,1 12,1A5,5 0 0,1 17,6C17,8.36 15.36,11.79 13.16,12.74Z";

        public const string ExitRunPath = "M13.34,8.17C12.41,8.17 11.65,7.4 11.65,6.47A1.69,1.69 0 0,1 13.34,4.78C14.28,4.78 15.04,5.54 15.04,6.47C15.04,7.4 14.28,8.17 13.34,8.17M10.3,19.93L4.37,18.75L4.71,17.05L8.86,17.9L10.21,11.04L8.69,11.64V14.5H7V10.54L11.4,8.67L12.07,8.59C12.67,8.59 13.17,8.93 13.5,9.44L14.36,10.79C15.04,12 16.39,12.82 18,12.82V14.5C16.14,14.5 14.44,13.67 13.34,12.4L12.84,14.94L14.61,16.63V23H12.92V17.9L11.14,16.21L10.3,19.93M21,23H19V3H6V16.11L4,15.69V1H21V23M6,23H4V19.78L6,20.2V23Z";

        public const string BedPath = "M19,7H11V14H3V5H1V20H3V17H21V20H23V11A4,4 0 0,0 19,7M7,13A3,3 0 0,0 10,10A3,3 0 0,0 7,7A3,3 0 0,0 4,10A3,3 0 0,0 7,13Z";

        public const string BedEmptyPath = "M19,7H5V14H3V5H1V20H3V17H21V20H23V11A4,4 0 0,0 19,7";

        public const string CalendarHeartPath = "M19,20V9H5V20H19M16,2H18V4H19A2,2 0 0,1 21,6V20A2,2 0 0,1 19,22H5A2,2 0 0,1 3,20V6A2,2 0 0,1 5,4H6V2H8V4H16V2M12,18.17L11.42,17.64C9.36,15.77 8,14.54 8,13.03C8,11.8 8.97,10.83 10.2,10.83C10.9,10.83 11.56,11.15 12,11.66C12.44,11.15 13.1,10.83 13.8,10.83C15.03,10.83 16,11.8 16,13.03C16,14.54 14.64,15.77 12.58,17.64L12,18.17Z";

        public const string CalendarStarPath = "M19,20H5V9H19M16,2V4H8V2H6V4H5A2,2 0 0,0 3,6V20A2,2 0 0,0 5,22H19A2,2 0 0,0 21,20V6A2,2 0 0,0 19,4H18V2M10.88,13H7.27L10.19,15.11L9.08,18.56L12,16.43L14.92,18.56L13.8,15.12L16.72,13H13.12L12,9.56L10.88,13Z";

        public const string FireworkPath = "M5.8,16.59L4.5,15.28L12.26,7.5L16.5,11.74L8.72,19.5L7.29,18.09C7.04,18.16 6.8,18.28 6.63,18.5C6.57,18.57 6.5,18.65 6.5,18.74C6.42,18.88 6.38,19 6.32,19.15C6.21,19.42 6.09,19.69 5.93,19.93C5.81,20.1 5.68,20.26 5.53,20.39C5.42,20.5 5.29,20.59 5.16,20.66C5.08,20.71 5,20.76 4.9,20.79C4.3,21.04 3.63,21 3,21V19C3.23,19 3.83,19 3.9,19C4,19 4.08,19 4.16,18.94C4.18,18.92 4.19,18.91 4.21,18.89C4.28,18.81 4.34,18.7 4.39,18.6C4.47,18.42 4.53,18.24 4.6,18.06L4.64,17.96C4.76,17.69 4.9,17.45 5.08,17.23C5.18,17.1 5.3,17 5.42,16.87C5.54,16.77 5.66,16.67 5.8,16.59M21,3L19.88,11.19L12.81,4.12L21,3Z";

        public const string ChartBarPath = "M22,21H2V3H4V19H6V17H10V19H12V16H16V19H18V17H22V21M18,14H22V16H18V14M12,6H16V9H12V6M16,15H12V10H16V15M6,10H10V12H6V10M10,16H6V13H10V16Z";

        public const string MagnifyPath = "M9.5,3A6.5,6.5 0 0,1 16,9.5C16,11.11 15.41,12.59 14.44,13.73L14.71,14H15.5L20.5,19L19,20.5L14,15.5V14.71L13.73,14.44C12.59,15.41 11.11,16 9.5,16A6.5,6.5 0 0,1 3,9.5A6.5,6.5 0 0,1 9.5,3M9.5,5C7,5 5,7 5,9.5C5,12 7,14 9.5,14C12,14 14,12 14,9.5C14,7 12,5 9.5,5Z";

        public const string StarPath = "M12,17.27L18.18,21L16.54,13.97L22,9.24L14.81,8.62L12,2L9.19,8.62L2,9.24L7.45,13.97L5.82,21L12,17.27Z";

        public const string StarOutlinePath = "M12,15.39L8.24,17.66L9.23,13.38L5.91,10.5L10.29,10.13L12,6.09L13.71,10.13L18.09,10.5L14.77,13.38L15.76,17.66M22,9.24L14.81,8.63L12,2L9.19,8.63L2,9.24L7.45,13.97L5.82,21L12,17.27L18.18,21L16.54,13.97L22,9.24Z";

        public const string CreaditCardOutlinePath = "M20,8H4V6H20M20,18H4V12H20M20,4H4C2.89,4 2,4.89 2,6V18A2,2 0 0,0 4,20H20A2,2 0 0,0 22,18V6C22,4.89 21.1,4 20,4Z";

        public const string CashPath = "M3,6H21V18H3V6M12,9A3,3 0 0,1 15,12A3,3 0 0,1 12,15A3,3 0 0,1 9,12A3,3 0 0,1 12,9M7,8A2,2 0 0,1 5,10V14A2,2 0 0,1 7,16H17A2,2 0 0,1 19,14V10A2,2 0 0,1 17,8H7Z";

        #endregion
    }
}

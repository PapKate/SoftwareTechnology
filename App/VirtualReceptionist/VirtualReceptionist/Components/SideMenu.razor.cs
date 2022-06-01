using Microsoft.AspNetCore.Components;

using System.Collections.Generic;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class SideMenu
    {
        #region Private Members

        /// <summary>
        /// The button names and icons for the visitor
        /// </summary>
        private IEnumerable<KeyValuePair<string, string>> mVisitorIconTitlePairs = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Events", BalloonPath)
        };

        /// <summary>
        /// The button names and icons for the customer
        /// </summary>
        private IEnumerable<KeyValuePair<string, string>> mCustomerIconTitlePairs = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("My room", BedPath),
            new KeyValuePair<string, string>("My reservations", CalendarHeartPath),
            new KeyValuePair<string, string>("Events", BalloonPath),
            new KeyValuePair<string, string>("Reservation payments", CreaditCardOutlinePath)
        };

        /// <summary>
        /// The button names and icons for the staff
        /// </summary>
        private IEnumerable<KeyValuePair<string, string>> mStaffIconTitlePairs = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Rooms", BedEmptyPath),
            new KeyValuePair<string, string>("Room check in", BedPath),
            new KeyValuePair<string, string>("Events", BalloonPath),
            new KeyValuePair<string, string>("Event reservations", CalendarHeartPath),
            new KeyValuePair<string, string>("Event check ins", CalendarStarPath),
            new KeyValuePair<string, string>("Event creation", FireworkPath),
            new KeyValuePair<string, string>("Payments", CashPath),
            new KeyValuePair<string, string>("Statistics", ChartBarPath),
        };

        #endregion

        #region Private Properties

        /// <summary>
        /// The navigation manager
        /// </summary>
        [Inject]
        private NavigationManager NavigationManager { get; set; }
 
        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SideMenu() : base()
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Navigates to the page that the  <paramref name="title"/> is pointing to
        /// </summary>
        /// <param name="title"></param>
        private void NavigateTo(string title)
        {
            // If the exit button is clicked...
            if (title == "LogOut")
            {
                // Navigate to the login back
                NavigationManager.NavigateToLoginPage();
                // Clears the user type
                GlobalData.UserType = null;
            }
            // Else if the user is a visitor...
            else if (GlobalData.UserType == UserType.Visitor)
            {
                if (title == "Events")
                    NavigationManager.Visitor_NavigateToEventsPage();
            }
            // Else if the user is a customer...
            else if (GlobalData.UserType == UserType.Customer)
            {
                if(title == "My room")
                    NavigationManager.Customer_NavigateToMyRoomPage();
                else if (title == "My reservations")
                    NavigationManager.Customer_NavigateToMyReservationsPage();
                else if (title == "Events")
                    NavigationManager.Customer_NavigateToEventsPage();
                else if (title == "Reservation payments")
                    NavigationManager.Customer_NavigateToReservationPaymentsPage();
            }
            // Else if the user is a staff...
            else if (GlobalData.UserType == UserType.Staff)
            {
                if(title == "Rooms")
                    NavigationManager.Staff_NavigateToRoomsPage();
                else if (title == "Room check in")
                    NavigationManager.Staff_NavigateToRoomCheckInPage();
                else if (title == "Events")
                    NavigationManager.Staff_NavigateToEventsPage();
                else if (title == "Event reservations")
                    NavigationManager.Staff_NavigateToEventReservationsPage();
                else if (title == "Event check ins")
                    NavigationManager.Staff_NavigateToEventCheckInsPage();
                else if (title == "Event creation")
                    NavigationManager.Staff_NavigateToEventCreationPage();
                else if (title == "Payments")
                    NavigationManager.Staff_NavigateToPaymentsPage();
                else if (title == "Statistics")
                    NavigationManager.Staff_NavigateToStatisticsPage();
            }
        }

        #endregion
    }
}

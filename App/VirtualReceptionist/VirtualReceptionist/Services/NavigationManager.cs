using Atom;

using Microsoft.AspNetCore.Components;

using System;
using System.Linq.Expressions;

namespace VirtualReceptionist
{
    /// <summary>
    /// Extension methods for <see cref="NavigationManager"/>
    /// </summary>
    public static class NavigationManagerExtensions
    {
        /// <summary>
        /// Navigates to <paramref name="memberExpression"/>, using the <paramref name="navigationManager"/>
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        /// <param name="memberExpression">The member route</param>
        /// <param name="variableValue"></param>
        public static void NavigateTo(this NavigationManager navigationManager, Expression<Func<BlazorPagesPaths, string>> memberExpression, string variableValue = null)
        {
            // Get the member
            var member = memberExpression.GetPropertyInfo();

            // Get the routes
            var routes = DI.GetService<BlazorPagesPaths>();

            // Get the route
            var route = (string)member.GetValue(routes);
            if (!string.IsNullOrEmpty(variableValue))
                // Call the navigate to method
                navigationManager.NavigateTo(route + $"/{variableValue}");
            else
                navigationManager.NavigateTo(route);
        }

        /// <summary>
        /// Navigates to login page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void NavigateToLoginPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.LoginPagePath);

        /// <summary>
        /// Navigates to the customer's home page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Visitor_NavigateToEventsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.VisitorEventsPagePath);

        /// <summary>
        /// Navigates to the customer's home page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Customer_NavigateToHomePage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.CustomerHomePagePath);

        /// <summary>
        /// Navigates to the customer's home page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Customer_NavigateToMyRoomPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.CustomerMyRoomPagePath);

        /// <summary>
        /// Navigates to the customer's MyReservations page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Customer_NavigateToMyReservationsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.CustomerMyReservationsPagePath);

        /// <summary>
        /// Navigates to the customer's Events page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Customer_NavigateToEventsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.CustomerEventsPagePath);

        /// <summary>
        /// Navigates to the customer's ReservationPayments page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Customer_NavigateToReservationPaymentsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.CustomerReservationPaymentsPagePath);

        /// <summary>
        /// Navigates to the staff's Rooms page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToRoomsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffRoomsPagePath);

        /// <summary>
        /// Navigates to the staff's Rooms page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToRoomCheckInPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffRoomCheckInPagePath);

        /// <summary>
        /// Navigates to the staff's Events page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToEventsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffEventsPagePath);

        /// <summary>
        /// Navigates to the staff's EventReservations page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToEventReservationsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffEventReservationsPagePath);

        /// <summary>
        /// Navigates to the staff's EventCheckIns page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToEventCheckInsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffEventCheckInsPagePath);

        /// <summary>
        /// Navigates to the staff's EventCreation page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToEventCreationPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffEventCreationPagePath);

        /// <summary>
        /// Navigates to the staff's Statistics page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToStatisticsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffStatisticsPagePath);

        /// <summary>
        /// Navigates to the staff's Payments page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Staff_NavigateToPaymentsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.StaffPaymentsPagePath);
    }
}

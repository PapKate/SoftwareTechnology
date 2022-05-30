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
        public static void Customer_NavigateToHomePage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.CustomerHomePagePath);

        /// <summary>
        /// Navigates to the customer's home page
        /// </summary>
        /// <param name="navigationManager">The navigation manager</param>
        public static void Visitor_NavigateToEventsPage(this NavigationManager navigationManager) => navigationManager.NavigateTo(x => x.VisitorEventsPagePath);


    }
}

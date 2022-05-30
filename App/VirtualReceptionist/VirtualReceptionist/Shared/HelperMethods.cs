using System;

namespace VirtualReceptionist
{
    /// <summary>
    /// Contains helper methods
    /// </summary>
    public static class HelperMethods
    {
        #region Message Dialogs

        /// <summary>
        /// Shows a message dialog
        /// </summary>
        /// <param name="type">The message's type</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        public static void ShowMessage(MessageType type, string title, string message)
        {

        }

        /// <summary>
        /// Shows an information dialog
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        public static void ShowInfoMessage(string title, string message)
        {
            ShowMessage(MessageType.Information, title, message);
        }

        /// <summary>
        /// Shows an error dialog
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        public static void ShowErrorMessage(string title, string message)
        {
            ShowMessage(MessageType.Error, title, message);
        }

        #endregion

        #region Phone Messages

        /// <summary>
        /// Sends a text to a phone number
        /// </summary>
        /// <param name="phone">The phone</param>
        /// <param name="message">The message</param>
        public static void SendPhoneText(Phone phone, string message)
        {

        }

        #endregion

        #region Pin

        /// <summary>
        /// Generates a random <see cref="Pin"/>
        /// </summary>
        /// <returns></returns>
        public static Pin GeneratePin()
        {
            return new Pin();
        }

        #endregion

        #region Payments

        public static bool ThirdPartyPayment(PaymentType type, double price)
        {
            // Third party
            
            var random = new Random();
            if(random.Next(2) == 1)
                return true;

            return false;
        }

        /// <summary>
        /// Calculates the total price
        /// </summary>
        /// <param name="price"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static double CalculateTotalPrice(double price, uint multiplier)
        {
            return price * multiplier;
        }

        public static double SubmitPaymentWithCash(double price, double given)
        {
            return given - price;
        }

        public static void SubmitPaymentWithPOS()
        {

        }

        #endregion
    }
}

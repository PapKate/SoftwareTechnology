using Atom;
using Atom.Blazor.Controls;

using System;
using System.Linq;
using System.Threading.Tasks;

using static VirtualReceptionist.Constants;

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
            if(type == MessageType.Information)
            {
                ShowInfoMessage(title, message);
                return;
            }
            ShowErrorMessage(title, message);
        }

        /// <summary>
        /// Shows an information dialog
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        public static async void ShowInfoMessage(string title, string message)
        {
            await DialogHelpers.ShowInfoDialogAsync(title, message);
        }

        /// <summary>
        /// Shows an error dialog
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        public static async void ShowErrorMessage(string title, string message)
        {
            await DialogHelpers.ShowErrorDialogAsync(title, message);
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
            Console.WriteLine(message);
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

        public static async Task<bool> SubmitPaymentWithCash(double price, double given)
        {
            var result = await DialogHelpers.ShowValidationDialogAsync<PaymentWithCashDialog>("Payment with cash", $"The total price is {price.ToLocalizedCurrency()}.Pleas enter the received amount.", CashPath, x => 
            {
                x.NegativeFeddbackButtonConfigure = n =>
                {
                    n.Text = "Cancel";
                    n.BackColor = Red;
                    n.ForeColor = White;
                };
                x.PositiveFeddbackButtonConfigure = p =>
                {
                    p.Text = "Submit";
                    p.BackColor = Green;
                    p.ForeColor = White;
                };
                x.Configure = y =>
                {
                    y.Price = price;
                };
            });

            return result.Feedback;
        }

        public static bool SubmitPaymentWithPOS(PaymentType type, double price)
        {
            return ThirdPartyPayment(type, price);
        }

        #endregion
    }
}

using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Threading.Tasks;

namespace VirtualReceptionist
{
    public partial class PinPad
    {
        #region Private Members

        /// <summary>
        /// The pin pad's input text
        /// </summary>
        private string mText = string.Empty;

        #endregion

        #region Public Properties

        /// <summary>
        /// Disables pin pad's buttons if true
        /// </summary>
        [Parameter]
        public bool IsDisabled { get; set; } = false;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PinPad() : base()
        {

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the number and adds it to the text
        /// </summary>
        /// <param name="number">The button's representative number</param>
        private void NumberButtonClicked(int number)
        {
            // To the text add the number
            mText += number.ToString();
        }

        /// <summary>
        /// Removes the last character of the text
        /// </summary>
        private void BackspaceButtonClicked()
        {
            // If there is no text...
            if (mText.Length == 0)
                // Return
                return;
            // Sets text as the text minus the last character
            mText = mText.Remove(mText.Length - 1, 1);
        }

        /// <summary>
        /// On enter clicked gets the user with the specified pin if exists
        /// </summary>
        /// <returns></returns>
        private async void EnterClicked()
        {
            
            // Removes the input text
            mText = string.Empty;

        }

        #endregion

        #region Events

        /// <summary>
        /// Fires when a successful login occurs
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnSuccessfulLogIn { get; set; }

        #endregion
    }
}

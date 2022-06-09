using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

namespace VirtualReceptionist
{
    public partial class PaymentWithCashDialog
    {
        #region Private Members

        private TextInput mAmountTextInput;

        private double mChange;

        #endregion

        #region Public Properties

        [Parameter]
        public double Price { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PaymentWithCashDialog() : base()
        {

        }

        #endregion

        #region Private Methods

        private void CalculateChange(ValueChangedContext<string> context)
        {
            var amount = double.Parse(context.NewValue);

            mChange = amount - Price;
        }

        #endregion
    }
}

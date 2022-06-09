using Atom;
using Atom.Blazor.Controls;

using Microsoft.AspNetCore.Components;

using System.Collections.Generic;

using static VirtualReceptionist.Constants;

namespace VirtualReceptionist
{
    public partial class PaymentDialog
    {
        #region Private Members

        private DropDownMenu<PaymentMethodModel> mDropDownMenu;

        #endregion

        #region Public Properties

        /// <summary>
        /// The payment methods
        /// </summary>
        [Parameter]
        public IEnumerable<PaymentMethodModel> PaymentMethods { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PaymentDialog() : base()
        {

        }

        #endregion

        #region Protected Methods

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                if(PaymentMethods == null)
                {
                    var models = new List<PaymentMethodModel>()
                    {
                        new PaymentMethodModel("Visa", VisaPath, PaymentType.Visa),
                        new PaymentMethodModel("MasterCard", MasterCardPath, PaymentType.Mastercard),
                        new PaymentMethodModel("PayPal", PayPalPath, PaymentType.Paypal)
                    };

                    PaymentMethods = models;

                }
                mDropDownMenu.AddRange(PaymentMethods);
                
            }
        }

        #endregion

        #region Public Events

        /// <summary>
        /// Handles the on click event of the submit button
        /// </summary>
        [Parameter]
        public EventCallback SubmitButtonOnClick { get; set; }

        #endregion
    }

    public class PaymentMethodModel
    {
        #region Public Properties

        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The vector source
        /// </summary>
        public VectorSource VectorSource { get; set; }

        /// <summary>
        /// The payment's type
        /// </summary>
        public PaymentType PaymentType { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PaymentMethodModel(string name, VectorSource vectorSource, PaymentType paymentType) : base()
        {
            Name = name;
            VectorSource = vectorSource;
            PaymentType = paymentType;
        }

        #endregion
    }
}

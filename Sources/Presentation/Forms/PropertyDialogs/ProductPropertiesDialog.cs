using System;
using System.Windows.Forms;

namespace TrainDB {
    public partial class ProductPropertiesDialog : Form {
        /// <summary>
        ///     Product being edited
        /// </summary>
        public Product Product { get; }

        /// <summary>
        ///     Dialog constructor
        /// </summary>
        /// <param name="product">Instance of the product to be edited</param>
        public ProductPropertiesDialog(Product product) {
            InitializeComponent();
            Product = product;
            UpdateControlState();
        }

        /// <summary>
        ///     Commits the changes to the database
        /// </summary>
        /// <returns><c>true</c> if the operation succeeded</returns>
        private bool ApplyChanges() {
            try {
                if (Product.ID == 0) {
                    // inserting new product. Update control state so we can obtain the database ID
                    Product.DAO.Insert(Product);
                    UpdateControlState();
                } else {
                    // updating exiting product
                    Product.DAO.Update(Product);
                }

                return true;
            } catch (Exception exception) {
                MessageBox.Show(this, $"Could not apply changes: {exception.Message}",
                        System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        ///     Reflects changes on the product object on the form controls
        /// </summary>
        private void UpdateControlState() {
            if (Product.ID != 0)
                this.idTextBox.Text = '#' + Product.ID.ToString();

            bool emptyDescription = String.IsNullOrWhiteSpace(Product.Description);
            if (!emptyDescription)
                Text = $"'{Product.Description}' Properties";
            else
                Text = "Product Properties";

            this.descriptionTextBox.Text = Product.Description;

            this.okButton.Enabled = !emptyDescription;
            this.applyButton.Enabled = this.okButton.Enabled;
        }

        #region Form Input Event Handlers

        /// <summary>
        ///     Triggered when the description text changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnDescriptionTextBoxTextChanged(object sender, EventArgs eventArgs) {
            Product.Description = this.descriptionTextBox.Text;
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the Apply button is clicked
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnApplyButtonClick(object sender, EventArgs eventArgs) {
            ApplyChanges();
        }

        /// <summary>
        ///     Triggered when the OK button is clicked
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnOKButtonClick(object sender, EventArgs eventArgs) {
            if (ApplyChanges()) {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion
    }
}

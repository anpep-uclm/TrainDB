using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainDB {
    public partial class PricePropertiesDialog : Form {
        /// <summary>
        ///     Indicates whether or not this is an existing price on the database
        /// </summary>
        private bool didPriceExist;

        /// <summary>
        ///     If <c>true</c>, don't take into account changes in the product combo box selection
        /// </summary>
        private bool isProductComboBoxPopulating;

        /// <summary>
        ///     Price being edited
        /// </summary>
        public Price Price { get; }

        /// <summary>
        ///     Dialog constructor
        /// </summary>
        /// <returns><c>true</c> if the operation succeeded</returns>
        public PricePropertiesDialog(Price price) {
            InitializeComponent();

            this.didPriceExist = price.Product.ID != 0;
            Price = price;

            PopulateProducts();
            UpdateControlState();
        }

        /// <summary>
        ///     Commits the changes to the database
        /// </summary>
        private bool ApplyChanges() {
            try {
                if (this.didPriceExist) {
                    // updating exiting price
                    Price.DAO.Update(Price);
                } else {
                    // inserting new price
                    Price.DAO.Insert(Price);
                    this.didPriceExist = true;
                    UpdateControlState();
                }

                return true;
            } catch (Exception exception) {
                MessageBox.Show(this, $"Could not apply changes: {exception.Message}",
                        System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        ///     Reflects changes on the price object on the form controls
        /// </summary>
        private void UpdateControlState() {
            if (this.didPriceExist) {
                // set selected product item
                var products = (List<Product>) this.productComboBox.DataSource;
                this.productComboBox.SelectedIndex = products.FindIndex(t => t.ID == Price.Product.ID);
                this.datePicker.Value = Price.Date;

                this.addNewProductButton.Enabled = false;
                this.productComboBox.Enabled = false;
                this.datePicker.Enabled = false;
            }

            this.priceInput.Value = (decimal) Price.EurosPerTon;
        }

        /// <summary>
        ///     Obtains all products from the database
        /// </summary>
        private void PopulateProducts() {
            this.isProductComboBoxPopulating = true;
            this.productComboBox.DataSource = Price.Product.DAO.ReadAll();
            this.productComboBox.SelectedIndex = -1;
            this.productPropertiesButton.Enabled = this.productComboBox.Items.Count != 0;
            this.isProductComboBoxPopulating = false;

            if (!this.didPriceExist)
                this.productComboBox.SelectedIndex = 0;

        }

        #region Form Input Event Handlers

        /// <summary>
        ///     Triggered when the selected product changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>

        private void OnProductComboBoxSelectedValueChanged(object sender, EventArgs eventArgs) {
            if (!this.isProductComboBoxPopulating) {
                Price.Product = (Product) this.productComboBox.SelectedValue;
                UpdateControlState();
            }
        }

        /// <summary>
        ///     Triggered when the "Add" product button is clicked
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnAddNewTypeButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new ProductPropertiesDialog(new Product())) {
                if (dialog.ShowDialog(this) != DialogResult.Cancel) {
                    Price.Product = dialog.Product;
                    PopulateProducts();
                    UpdateControlState();
                }
            }
        }

        /// <summary>
        ///     Triggered when the "Properties" button is clicked for the selected product
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnProductPropertiesButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new ProductPropertiesDialog(Price.Product)) {
                if (dialog.ShowDialog(this) != DialogResult.Cancel) {
                    PopulateProducts();
                    UpdateControlState();
                }
            }
        }

        /// <summary>
        ///     Triggered when the price date value changes
        /// </summary>
        /// <param name="sender">Control that initiated this event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnDatePickerValueChanged(object sender, EventArgs eventArgs) {
            Price.Date = datePicker.Value;
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the value for the price input changes
        /// </summary>
        /// <param name="sender">Control that initiated this event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnPriceInputValueChanged(object sender, EventArgs eventArgs) {
            Price.EurosPerTon = (double) priceInput.Value;
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the Apply button is clicked
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnApplyButtonClick(object sender, EventArgs eventArgs) {
            ApplyChanges();
            this.applyButton.Enabled = false;
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

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainDB {
    public partial class TripPropertiesDialog : Form {
        /// <summary>
        ///     Indicates whether or not this is an existing trip on the database
        /// </summary>
        private bool didTripExist;

        /// <summary>
        ///     If <c>true</c>, don't take into account changes in the train combo box selection
        /// </summary>
        private bool isTrainComboBoxPopulating;

        /// <summary>
        ///     If <c>true</c>, don't take into account changes in the product combo box selection
        /// </summary>
        private bool isProductComboBoxPopulating;

        /// <summary>
        ///     Trip being edited
        /// </summary>
        public Trip Trip { get; }

        /// <summary>
        ///     Dialog constructor
        /// </summary>
        /// <returns><c>true</c> if the operation succeeded</returns>
        public TripPropertiesDialog(Trip trip) {
            InitializeComponent();

            this.didTripExist = !(trip.Train.ID is null);
            Trip = trip;

            PopulateTrains();
            PopulateProducts();
            UpdateControlState();
        }

        /// <summary>
        ///     Commits the changes to the database
        /// </summary>
        private bool ApplyChanges() {
            try {
                if (this.didTripExist) {
                    // updating exiting trip
                    Trip.DAO.Update(Trip);
                } else {
                    // inserting new trip
                    Trip.DAO.Insert(Trip);
                    this.didTripExist = true;
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
        ///     Reflects changes on the trip object on the form controls
        /// </summary>
        private void UpdateControlState() {
            if (this.didTripExist) {
                // set selected train item
                var trains = (List<Train>) this.trainComboBox.DataSource;
                this.trainComboBox.SelectedIndex = trains.FindIndex(t => t.ID == Trip.Train.ID);

                // set selected product item
                var products = (List<Product>) this.productComboBox.DataSource;
                this.productComboBox.SelectedIndex = products.FindIndex(t => t.ID == Trip.Product.ID);

                this.datePicker.Value = Trip.Date;

                this.addNewProductButton.Enabled = false;
                this.addNewTrainButton.Enabled = false;
                this.trainComboBox.Enabled = false;
                this.productComboBox.Enabled = false;
                this.datePicker.Enabled = false;
            }

            this.weightInput.Maximum = Trip.Train.Type.MaximumCapacity;
            this.weightInput.Value = Math.Min(Trip.TonsTransported, this.weightInput.Maximum);
        }

        /// <summary>
        ///     Obtains all trains from the database
        /// </summary>
        private void PopulateTrains() {
            this.isTrainComboBoxPopulating = true;
            this.trainComboBox.DataSource = Trip.Train.DAO.ReadAll();
            this.trainComboBox.SelectedIndex = -1;
            this.trainPropertiesButton.Enabled = this.trainComboBox.Items.Count != 0;
            this.isTrainComboBoxPopulating = false;

            if (!this.didTripExist)
                this.trainComboBox.SelectedIndex = 0;
        }

        /// <summary>
        ///     Obtains all products from the database
        /// </summary>
        private void PopulateProducts() {
            this.isProductComboBoxPopulating = true;
            this.productComboBox.DataSource = Trip.Product.DAO.ReadAll();
            this.productComboBox.SelectedIndex = -1;
            this.productPropertiesButton.Enabled = this.productComboBox.Items.Count != 0;
            this.isProductComboBoxPopulating = false;

            if (!this.didTripExist)
                this.productComboBox.SelectedIndex = 0;
        }

        #region Form Input Event Handlers

        /// <summary>
        ///     Triggered when the selected train changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>

        private void OnTrainComboBoxSelectedValueChanged(object sender, EventArgs eventArgs) {
            if (!this.isTrainComboBoxPopulating) {
                Trip.Train = (Train) this.trainComboBox.SelectedValue;
                UpdateControlState();
            }
        }

        /// <summary>
        ///     Triggered when the "Add" train button is clicked
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnAddNewTrainButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new TrainPropertiesDialog(new Train())) {
                if (dialog.ShowDialog(this) != DialogResult.Cancel)
                    Trip.Train = dialog.Train;
            }

            PopulateProducts();
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the "Properties" button is clicked for the selected train
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnTrainPropertiesButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new TrainPropertiesDialog(Trip.Train))
                dialog.ShowDialog(this);

            PopulateTrains();
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the selected product changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>

        private void OnProductComboBoxSelectedValueChanged(object sender, EventArgs eventArgs) {
            if (!this.isProductComboBoxPopulating) {
                Trip.Product = (Product) this.productComboBox.SelectedValue;
                UpdateControlState();
            }
        }

        /// <summary>
        ///     Triggered when the "Add" product button is clicked
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnAddNewProductButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new ProductPropertiesDialog(new Product())) {
                if (dialog.ShowDialog(this) != DialogResult.Cancel)
                    Trip.Product = dialog.Product;
            }

            PopulateProducts();
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the "Properties" button is clicked for the selected product
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnProductPropertiesButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new ProductPropertiesDialog(Trip.Product))
                dialog.ShowDialog(this);

            PopulateProducts();
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the trip date value changes
        /// </summary>
        /// <param name="sender">Control that initiated this event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnDatePickerValueChanged(object sender, EventArgs eventArgs) {
            Trip.Date = datePicker.Value;
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the value for the weight input changes
        /// </summary>
        /// <param name="sender">Control that initiated this event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnWeightInputValueChanged(object sender, EventArgs eventArgs) {
            Trip.TonsTransported = (long) weightInput.Value;
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

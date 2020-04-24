using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainDB {
    public partial class TrainPropertiesDialog : Form {
        /// <summary>
        ///     Indicates whether or not this is an existing train on the database
        /// </summary>
        private bool didTrainExist;

        /// <summary>
        ///     If <c>true</c>, don't take into account changes in the train type combo box selection
        /// </summary>
        private bool isTrainTypeComboBoxPopulating;

        /// <summary>
        ///     Embedded products object tab
        /// </summary>
        private ProductsTab productsTab;

        /// <summary>
        ///     Train being edited
        /// </summary>
        public Train Train { get; }

        /// <summary>
        ///     Dialog constructor
        /// </summary>
        /// <returns><c>true</c> if the operation succeeded</returns>
        public TrainPropertiesDialog(Train train) {
            InitializeComponent();

            this.didTrainExist = train.ID != null;
            Train = train;

            PopulateTrainTypes();
            UpdateControlState();

            if (this.didTrainExist) {
                this.productsTab = new ProductsTab();
                this.productsTab.TrainFilter = Train;
                this.productsTab.DateRangeFilter = (DateTime.MinValue, DateTime.MaxValue);
                productContainerTabControl.TabPages.Add(this.productsTab);
                this.productsTab.RenderItems();
                this.tripCountTextBox.Text = this.productsTab.ItemCount.ToString("N0");
            } else {
                this.mainTabControl.TabPages.RemoveByKey(this.productsTabPage.Name);
            }
        }

        /// <summary>
        ///     Commits the changes to the database
        /// </summary>
        private bool ApplyChanges() {
            try {
                if (this.didTrainExist) {
                    // updating exiting train
                    Train.DAO.Update(Train);
                } else {
                    // inserting new train
                    Train.DAO.Insert(Train);
                    this.didTrainExist = true;
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
        ///     Reflects changes on the train object on the form controls
        /// </summary>
        private void UpdateControlState() {
            bool emptyId = String.IsNullOrWhiteSpace(Train.ID);
            if (!emptyId) {
                Text = $"'{Train.ID}' Properties";
                this.idTextBox.Text = Train.ID;
                this.idTextBox.ReadOnly = this.didTrainExist;
            } else {
                Text = "Train Properties";
            }

            if (Train.Type != null) {
                // set selected train type item
                var trainTypes = (List<TrainType>) this.trainTypeComboBox.DataSource;
                this.trainTypeComboBox.SelectedIndex = trainTypes.FindIndex(t => t.ID == Train.Type.ID);
            }

            this.okButton.Enabled = !emptyId;
            this.applyButton.Enabled = this.okButton.Enabled;
        }

        /// <summary>
        ///     Obtains all train types from the database
        /// </summary>
        private void PopulateTrainTypes() {
            this.isTrainTypeComboBoxPopulating = true;
            this.trainTypeComboBox.DataSource = Train.Type.DAO.ReadAll();
            this.trainTypeComboBox.SelectedIndex = -1;
            this.trainTypePropertiesButton.Enabled = this.trainTypeComboBox.Items.Count != 0;
            this.isTrainTypeComboBoxPopulating = false;

            if (!this.didTrainExist && Train.Type?.ID == 0)
                this.trainTypeComboBox.SelectedIndex = 0;

        }

        #region Form Input Event Handlers

        /// <summary>
        ///     Triggered when the selected train type changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>

        private void OnTrainTypeComboBoxSelectedValueChanged(object sender, EventArgs eventArgs) {
            if (!this.isTrainTypeComboBoxPopulating) {
                Train.Type = (TrainType) this.trainTypeComboBox.SelectedValue;
                UpdateControlState();
            }
        }

        /// <summary>
        ///     Triggered when the train ID changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnIdTextBoxTextChanged(object sender, EventArgs eventArgs) {
            Train.ID = this.idTextBox.Text;
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the "Add" train type button is clicked
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnAddNewTypeButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new TrainTypePropertiesDialog(new TrainType())) {
                if (dialog.ShowDialog(this) != DialogResult.Cancel)
                    Train.Type = dialog.TrainType;
            }

            PopulateTrainTypes();
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the "Properties" button is clicked for the selected train type
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnTrainTypePropertiesButtonClick(object sender, EventArgs eventArgs) {
            using (var dialog = new TrainTypePropertiesDialog(Train.Type))
                dialog.ShowDialog(this);

            PopulateTrainTypes();
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

        private void OnDateFilterChanged(object sender, EventArgs eventArgs) {
            var dateStart = DateTime.MinValue;
            var dateEnd = DateTime.MaxValue;

            if (this.dateStartFilter.Checked)
                dateStart = this.dateStartFilter.Value;
            if (this.dateEndFilter.Checked)
                dateEnd = this.dateEndFilter.Value;

            try {
                this.productsTab.DateRangeFilter = (dateStart, dateEnd);
                this.tripCountTextBox.Text = this.productsTab.ItemCount.ToString("N0");
            } catch (InvalidOperationException exception) {
                MessageBox.Show(this, exception.Message.ToString(), System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

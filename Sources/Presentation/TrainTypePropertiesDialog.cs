using System;
using System.Windows.Forms;

namespace TrainDB {
    public partial class TrainTypePropertiesDialog : Form {
        /// <summary>
        ///     Train type being edited
        /// </summary>
        public TrainType TrainType { get; }

        /// <summary>
        ///     Dialog constructor
        /// </summary>
        /// <param name="trainType">Instance of the train type to be edited</param>
        public TrainTypePropertiesDialog(TrainType trainType) {
            InitializeComponent();
            TrainType = trainType;
            UpdateControlState();
        }

        /// <summary>
        ///     Commits the changes to the database
        /// </summary>
        /// <returns><c>true</c> if the operation succeeded</returns>
        private bool ApplyChanges() {
            try {
                if (TrainType.ID == 0) {
                    // inserting new train type. Update control state so we can obtain the database ID
                    TrainType.DAO.Insert(TrainType);
                    UpdateControlState();
                } else {
                    // updating exiting train type
                    TrainType.DAO.Update(TrainType);
                }

                return true;
            } catch (Exception exception) {
                MessageBox.Show(this, $"Could not apply changes: {exception.Message}",
                        System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        ///     Reflects changes on the train type object on the form controls
        /// </summary>
        private void UpdateControlState() {
            if (TrainType.ID != 0)
                this.idTextBox.Text = '#' + TrainType.ID.ToString();

            bool emptyDescription = String.IsNullOrWhiteSpace(TrainType.Description);
            if (!emptyDescription)
                Text = $"'{TrainType.Description}' Properties";
            else
                Text = "Train Type Properties";

            this.descriptionTextBox.Text = TrainType.Description;
            this.maxCapacityNumericUpDown.Value = TrainType.MaximumCapacity;

            this.okButton.Enabled = !emptyDescription;
            this.applyButton.Enabled = this.okButton.Enabled;
        }

        #region Form Input Event Handlers

        /// <summary>
        ///     Triggered when the maximum capacity value changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnMaxCapacityNumericUpDownValueChanged(object sender, EventArgs eventArgs) {
            TrainType.MaximumCapacity = (long) this.maxCapacityNumericUpDown.Value;
            UpdateControlState();
        }

        /// <summary>
        ///     Triggered when the description text changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnDescriptionTextBoxTextChanged(object sender, EventArgs eventArgs) {
            TrainType.Description = this.descriptionTextBox.Text;
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

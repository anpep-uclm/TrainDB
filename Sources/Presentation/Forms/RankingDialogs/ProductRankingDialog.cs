using System;
using System.Windows.Forms;

namespace TrainDB {
    public partial class ProductRankingDialog : Form {
        private readonly ProductRankingTab productRankingTab;

        /// <summary>
        ///     Constructor
        /// </summary>
        public ProductRankingDialog() {
            InitializeComponent();
            this.productRankingTab = new ProductRankingTab();
            this.productContainerTabControl.TabPages.Add(this.productRankingTab);
        }

        /// <summary>
        ///     Triggered when the date range filter value changes
        /// </summary>
        /// <param name="sender">Control that initiated the event</param>
        /// <param name="eventArgs"></param>
        private void OnDateFilterValueChanged(object sender, EventArgs eventArgs) {
            var dateStart = DateTime.MinValue;
            var dateEnd = DateTime.MaxValue;

            if (this.dateStartFilter.Checked)
                dateStart = this.dateStartFilter.Value;
            if (this.dateEndFilter.Checked)
                dateEnd = this.dateEndFilter.Value;

            try {
                this.productRankingTab.DateRangeFilter = (dateStart, dateEnd);
            } catch (InvalidOperationException exception) {
                MessageBox.Show(this, exception.Message.ToString(), System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace TrainDB {
    public sealed class TrainTypeRankingTab : ObjectTab {
        private (DateTime, DateTime) dateRangeFilter = (DateTime.MinValue, DateTime.MaxValue);

        /// <summary>
        ///     Backing DAO for the train types table
        /// </summary>
        private readonly TrainTypeDAO dao;

        /// <summary>
        ///     Filters products transported by trips made on this date range
        /// </summary>
        public (DateTime Start, DateTime End) DateRangeFilter {
            get => dateRangeFilter;
            set {
                if (value.Start > value.End)
                    throw new InvalidOperationException("An invalid date range was selected");
                dateRangeFilter = value;
                RenderItems();
            }
        }

        /// <summary>
        ///     Initializes the train types tab
        /// </summary>
        /// <param name="path"></param>
        public TrainTypeRankingTab(string path = null) {
            this.dao = new TrainTypeDAO(path);
            Text = "Train Type Ranking";
            ReadOnly = true;
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Delete" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryDelete(object target) {
            try {
                this.dao.Delete((TrainType) target);
            } catch (Exception exception) {
                MessageBox.Show(this, $"{exception.Message}", System.Windows.Forms.Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Insert" operation is requested
        /// </summary>
        public override void OnQueryInsert() {
            using (var dialog = new TrainTypePropertiesDialog(new TrainType()))
                dialog.ShowDialog(this);
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Properties" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryProperties(object target) {
            using (var dialog = new TrainTypePropertiesDialog((TrainType) target))
                dialog.ShowDialog(this);
            RenderItems();
        }

        /// <summary>
        ///     Adds the pertinent rows to the list view
        /// </summary>
        public override void RenderItems() {            
            ItemListView.BeginUpdate();

            ItemListView.Columns.Clear();
            ItemListView.Columns.AddRange(new[] {
                new ColumnHeader { Text = "ID" },
                new ColumnHeader { Text = "Number of Trips" },
                new ColumnHeader { Text = "Description" },
            });

            ItemListView.Items.Clear();
            foreach (var trainType in this.dao.QueryRanking(this.dateRangeFilter)) {
                ItemListView.Items.Add(new ListViewItem(new[] {
                    '#' + trainType.ID.ToString(),
                    trainType.TripCount?.ToString("N0"),
                    trainType.Description
                }) { Tag = trainType });
            }

            ItemListView.EndUpdate();

            foreach (ColumnHeader header in ItemListView.Columns) {
                // HACK: ensure the text fits the column width
                header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                header.Width += 8;
            }

            OnItemListViewSelectionChanged(this, new EventArgs());
        }
    }
}

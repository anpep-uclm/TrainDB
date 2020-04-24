using System;
using System.Windows.Forms;

namespace TrainDB {
    public sealed class TripsTab : ObjectTab {
        /// <summary>
        ///     Backing DAO for the trips table
        /// </summary>
        private readonly TripDAO dao;

        /// <summary>
        ///     Initializes the trips tab
        /// </summary>
        /// <param name="path"></param>
        public TripsTab(string path = null) {
            this.dao = new TripDAO(path);
            Text = "Trips";
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Delete" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryDelete(object target) {
            try {
                this.dao.Delete((Trip) target);
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
            using (var dialog = new TripPropertiesDialog(new Trip() { Product = new Product() }))
                dialog.ShowDialog(this);
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Properties" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryProperties(object target) {
            using (var dialog = new TripPropertiesDialog((Trip) target))
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
                new ColumnHeader { Text = "Train" },
                new ColumnHeader { Text = "Date" },
                new ColumnHeader { Text = "Product" },
                new ColumnHeader { Text = "Weight" }
            });

            ItemListView.Items.Clear();
            foreach (var trip in this.dao.ReadAll()) {
                var item = new ListViewItem(new[] {
                    trip.Train.ToString(),
                    trip.Date.ToSQLiteDateFormat(),
                    trip.Product.ToString(),
                    trip.TonsTransported.ToString("N") + " t",
                }) { Tag = trip };

                ItemListView.Items.Add(item);
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

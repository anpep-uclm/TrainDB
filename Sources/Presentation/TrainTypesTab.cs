using System;
using System.Windows.Forms;

namespace TrainDB {
    public sealed class TrainTypesTab : ObjectTab {
        /// <summary>
        ///     Backing DAO for the train types table
        /// </summary>
        private readonly TrainTypeDAO dao;

        /// <summary>
        ///     Initializes the train types tab
        /// </summary>
        /// <param name="path"></param>
        public TrainTypesTab(string path = null) {
            this.dao = new TrainTypeDAO(path);
            Text = "Train Types";
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
                new ColumnHeader { Text = "Description" },
                new ColumnHeader { Text = "Max. Capacity" }
            });

            ItemListView.Items.Clear();
            foreach (var trainType in this.dao.ReadAll()) {
                ItemListView.Items.Add(new ListViewItem(new[] {
                    '#' + trainType.ID.ToString(),
                    trainType.Description,
                    trainType.MaximumCapacity.ToString("N") + " tonnes"
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

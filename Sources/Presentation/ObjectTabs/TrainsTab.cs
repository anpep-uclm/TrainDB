using System;
using System.Windows.Forms;

namespace TrainDB {
    public sealed class TrainsTab : ObjectTab {
        /// <summary>
        ///     Backing DAO for the train table
        /// </summary>
        private readonly TrainDAO dao;

        /// <summary>
        ///     Initializes the train tab
        /// </summary>
        /// <param name="path"></param>
        public TrainsTab(string path = null) {
            this.dao = new TrainDAO(path);
            Text = "Trains";
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Delete" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryDelete(object target) {
            try {
                this.dao.Delete((Train) target);
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
            using (var dialog = new TrainPropertiesDialog(new Train()))
                dialog.ShowDialog(this);
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Properties" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryProperties(object target) {
            using (var dialog = new TrainPropertiesDialog((Train) target))
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
                new ColumnHeader { Text = "Type" },
            });

            ItemListView.Items.Clear();
            foreach (var train in this.dao.ReadAll()) {
                ItemListView.Items.Add(new ListViewItem(new[] {
                    train.ID,
                    train.Type.ToString()
                }) { Tag = train });
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

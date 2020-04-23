using System;
using System.Windows.Forms;

namespace TrainDB {
    public sealed class PricesTab : ObjectTab {
        /// <summary>
        ///     Backing DAO for the prices table
        /// </summary>
        private readonly PriceDAO dao;

        /// <summary>
        ///     Initializes the prices tab
        /// </summary>
        /// <param name="path"></param>
        public PricesTab(string path = null) {
            this.dao = new PriceDAO(path);
            Text = "Product Pricings";
            ItemListView.LabelEdit = true;
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Delete" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryDelete(object target) {
            try {
                this.dao.Delete((Price) target);
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
            using (var dialog = new PricePropertiesDialog(new Price()))
                dialog.ShowDialog(this);
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Properties" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param
        public override void OnQueryProperties(object target) {
            using (var dialog = new PricePropertiesDialog((Price) target))
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
                new ColumnHeader { Text = "Product" },
                new ColumnHeader { Text = "Date" },
                new ColumnHeader { Text = "Value (€)" }
            });

            ItemListView.Items.Clear();
            foreach (var price in this.dao.ReadAll()) {
                var item = new ListViewItem(new[] {
                    price.Product.ToString(),
                    price.Date.ToString("d"),
                    price.EurosPerTon.ToString("N")
                }) { Tag = price };

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

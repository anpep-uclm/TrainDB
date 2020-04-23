using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TrainDB {
    /// <summary>
    ///     Defines a common user interface for object tabs.
    ///     It consists of a tab page with a list view that obtains its rows from a database and allows
    ///     common operations such as insertion, deletion and updating.
    /// </summary
    /// <remarks>This class avoids duplicating the UI logic for each table in the main form.</remarks>
    public abstract class ObjectTab : TabPage {
        private readonly MenuItem newContextMenuItem;
        private readonly MenuItem refreshContextMenuItem;
        private readonly MenuItem deleteContextMenuItem;
        private readonly MenuItem propertiesContextMenuItem;

        private string statusText;

        /// <summary>
        ///     Status text that varies when the item selection changes
        /// </summary>
        public string StatusText {
            get => this.statusText;
            set {
                this.statusText = value;
                StatusTextChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Backing list view for this object type
        /// </summary>
        protected ListView ItemListView { get; private set; }

        /// <summary>
        ///     Triggered by a change on the StatusText property
        /// </summary>
        public event EventHandler StatusTextChanged;

        /// <summary>
        ///     Control constructor
        /// </summary>
        public ObjectTab() {
            // create context menu for list items
            ContextMenu = new ContextMenu(new[] {
                newContextMenuItem = new MenuItem("&New...", OnNewContextMenuItemClick) { Shortcut = Shortcut.Ins },
                refreshContextMenuItem = new MenuItem("&Refresh", OnRefreshContextMenuItemClick) { Shortcut = Shortcut.F5 },
                new MenuItem("-"),
                deleteContextMenuItem = new MenuItem("&Delete...", OnDeleteContextMenuItemClick) { Shortcut = Shortcut.Del, Enabled = false },
                propertiesContextMenuItem = new MenuItem("&Properties", OnPropertiesContextMenuItemClick) { Enabled = false }
            });

            // initialize the element list view
            ItemListView = new ListView() {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                ContextMenu = ContextMenu,
                BorderStyle = BorderStyle.None
            };

            ItemListView.ItemSelectionChanged += OnItemListViewSelectionChanged;
            ItemListView.DoubleClick += OnItemListViewDoubleClick;

            Controls.Add(ItemListView);
        }

        #region P/Invokes for ListView styling

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        #endregion

        #region Overriden Control Event Handlers

        /// <summary>
        ///     Triggered when the window handle for this control is created
        /// </summary>
        /// <param name="eventArgs">Arguments associated with this event</param>
        protected override void OnHandleCreated(EventArgs eventArgs) {
            base.OnHandleCreated(eventArgs);

            // obtain native theme style on list view items
            SetWindowTheme(ItemListView.Handle, "explorer", null);
        }

        #endregion

        #region Context Menu Event Handlers

        /// <summary>
        ///     Triggered when the "New" context menu item is clicked
        /// </summary>
        /// <param name="sender">Control that originated this event</param>
        /// <param name="eventArgs">Arguments associated to this event</param>
        private void OnNewContextMenuItemClick(object sender, EventArgs eventArgs) {
            OnQueryInsert();
        }

        /// <summary>
        ///     Triggered when the "Refresh" context menu item is clicked
        /// </summary>
        /// <param name="sender">Control that originated this event</param>
        /// <param name="eventArgs">Arguments associated to this event</param>
        private void OnRefreshContextMenuItemClick(object sender, EventArgs eventArgs) {
            RenderItems();
        }

        /// <summary>
        ///     Triggered when the "Delete" context menu item is clicked
        /// </summary>
        /// <param name="sender">Control that originated this event</param>
        /// <param name="eventArgs">Arguments associated to this event</param>
        private void OnDeleteContextMenuItemClick(object sender, EventArgs eventArgs) {
            int itemCount = ItemListView.SelectedItems.Count;
            DialogResult result =
                MessageBox.Show(Parent, $"Are you sure you want to delete {itemCount} item(s) permanently?\nThis action can't be undone.",
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                foreach (ListViewItem selectedItem in ItemListView.SelectedItems)
                    OnQueryDelete(selectedItem.Tag);
            }
        }

        /// <summary>
        ///     Triggered when the "Properties" context menu item is clicked
        /// </summary>
        /// <param name="sender">Control that originated this event</param>
        /// <param name="eventArgs">Arguments associated to this event</param>
        private void OnPropertiesContextMenuItemClick(object sender, EventArgs eventArgs) {
            OnQueryProperties(ItemListView.SelectedItems[0].Tag);
        }

        #endregion

        #region List View Event Handlers

        /// <summary>
        ///     Triggered when the list view selection changes
        /// </summary>
        /// <param name="sender">Control that triggered this event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        protected void OnItemListViewSelectionChanged(object sender, EventArgs eventArgs) {
            deleteContextMenuItem.Enabled = ItemListView.SelectedItems.Count != 0;
            propertiesContextMenuItem.Enabled = ItemListView.SelectedItems.Count == 1;

            StatusText = $"{ItemListView.Items.Count} item(s) total";
            if (ItemListView.SelectedItems.Count != 0)
                StatusText += $", {ItemListView.SelectedItems.Count} selected";
        }

        /// <summary>
        ///     Triggered when an item from the list view is activated
        /// </summary>
        /// <param name="sender">Control that triggered this event</param>
        /// <param name="eventArgs">Arguments associated with this event</param>
        private void OnItemListViewDoubleClick(object sender, EventArgs eventArgs) {
            if (ItemListView.SelectedItems.Count == 1)
                OnPropertiesContextMenuItemClick(sender, eventArgs);
        }

        #endregion

        #region Abstract methods

        /// <summary>
        ///     Adds the pertinent rows to the list view
        /// </summary>
        public abstract void RenderItems();

        /// <summary>
        ///     Triggered when the "Insert" operation is requested
        /// </summary>
        public abstract void OnQueryInsert();

        /// <summary>
        ///     Triggered when the "Delete" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param>
        public abstract void OnQueryDelete(object target);

        /// <summary>
        ///     Triggered when the "Properties" operation is requested
        /// </summary>
        /// <param name="target">The list view item associated with the request</param>
        public abstract void OnQueryProperties(object target);

        #endregion
    }
}

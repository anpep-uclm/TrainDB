using System;
using System.IO;
using System.Windows.Forms;

namespace TrainDB {

    /// <summary>
    ///     Implements the main user interface for the application
    /// </summary>
    public partial class MainWindow : Form {
        private readonly StatusBarPanel generalStatusBarPanel;
        private readonly StatusBarPanel detailsStatusBarPanel;

        /// <summary>
        ///     Form constructor
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            Text = System.Windows.Forms.Application.ProductName;
            statusBar.Panels.AddRange(new[] {
                generalStatusBarPanel = new StatusBarPanel() { Text = "Ready", AutoSize = StatusBarPanelAutoSize.Spring },
                detailsStatusBarPanel = new StatusBarPanel() { AutoSize = StatusBarPanelAutoSize.Contents }
            });
        }

        /// <summary>
        ///     Adds tabs for each object type
        /// </summary>
        private void CreateObjectTabs() {
            var objectTabs = new ObjectTab[] {
                new TrainTypesTab(),
                new TrainsTab(),
                new ProductsTab(),
                new PricesTab(),
                new TripsTab()
            };

            foreach (var tab in objectTabs) {
                tab.StatusTextChanged += OnTabStatusTextChanged;
                mainTabControl.TabPages.Add(tab);
            }
            
            OnTabChanged(mainTabControl, new EventArgs());
        }

        #region Form event handlers

        /// <summary>
        ///     Triggered before the close message is sent to the window
        /// </summary>
        /// <param name="eventArgs">Arguments for this event</param>
        protected override void OnFormClosing(FormClosingEventArgs eventArgs) {
            this.generalStatusBarPanel.Text = "Closing connection...";
            DatabaseBroker.GetInstance()?.CloseConnection();
            base.OnFormClosing(eventArgs);
        }

        #endregion

        #region Control event handlers

        /// <summary>
        ///     Triggered when the "Exit" menu item is clicked
        /// </summary>
        /// <param name="sender">Control that triggered the event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnExitMenuItemClick(object sender, EventArgs eventArgs) {
            Close();
        }

        /// <summary>
        ///     Triggered when the "Open" menu item is clicked
        /// </summary>
        /// <param name="sender">Control that triggered the event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnOpenMenuItemClick(object sender, EventArgs eventArgs) {
            if (this.openFileDialog.ShowDialog(this) == DialogResult.OK) {
                try {
                    // initialize database broker with the selected database path and open a connection
                    UseWaitCursor = true;
                    this.generalStatusBarPanel.Text = $"Opening \"{this.openFileDialog.FileName}\"...";
                    DatabaseBroker.GetInstance(this.openFileDialog.FileName).OpenConnection();

                    // update control state
                    Text = $"{Path.GetFileName(this.openFileDialog.FileName)} - {System.Windows.Forms.Application.ProductName}";
                    this.generalStatusBarPanel.Text = "Connection open";
                    this.mainTabControl.Visible = false;
                    this.toolsMenuItem.Enabled = true;

                    // recreate tabs
                    this.mainTabControl.TabPages.Clear();
                    CreateObjectTabs();
                    this.mainTabControl.Visible = true;
                } catch (Exception exception) {
                    this.generalStatusBarPanel.Text = "Could not connect to database";
                    MessageBox.Show(this, $"{this.generalStatusBarPanel.Text}: {exception.Message}",
                        System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                } finally {
                    UseWaitCursor = false;
                }
            }
        }

        /// <summary>
        ///     Triggered when the "About" menu item is clicked
        /// </summary>
        /// <param name="sender">Control that triggered the event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnAboutMenuItemClick(object sender, EventArgs eventArgs) {
            new AboutDialog().ShowDialog(this);
        }

        /// <summary>
        ///     Triggered when the "Historic Train Type Trip Ranking" menu item is clicked
        /// </summary>
        /// <param name="sender">Control that triggered the event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnTrainTypeRankingMenuItemClick(object sender, EventArgs eventArgs) {
            using (var dialog = new TrainTypeRankingDialog())
                dialog.ShowDialog(this);
        }

        /// <summary>
        ///     Triggered when the "Historic Product Ranking" menu item is clicked
        /// </summary>
        /// <param name="sender">Control that triggered the event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnProductRankingMenuItemClick(object sender, EventArgs eventArgs) {
            using (var dialog = new ProductRankingDialog())
                dialog.ShowDialog(this);
        }

        /// <summary>
        ///     Triggered when the "Most Profitable Trip" menu item is clicked
        /// </summary>
        /// <param name="sender">Control that initated this event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnMostProfitableTripMenuItemClick(object sender, EventArgs eventArgs) {
            using (var dialog = new MostProfitableTripDialog())
                dialog.ShowDialog(this);
        }

        /// <summary>
        ///     Triggered when the status text of the currently selected object tab changes
        /// </summary>
        /// <param name="sender">Control that triggered the event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnTabStatusTextChanged(object sender, EventArgs eventArgs) {
            this.detailsStatusBarPanel.Text = (mainTabControl.SelectedTab as ObjectTab)?.StatusText;
        }

        /// <summary>
        ///     Triggered when the current tab is changed
        /// </summary>
        /// <param name="sender">Control that triggered the event</param>
        /// <param name="eventArgs">Arguments for this event</param>
        private void OnTabChanged(object sender, EventArgs eventArgs) {
            // mirror the tab context menu to the "Edit" menu item
            editMenuItem.Enabled = false;
            editMenuItem.MenuItems.Clear();
            editMenuItem.MergeMenu(mainTabControl.SelectedTab.ContextMenu);
            editMenuItem.Enabled = true;

            // update status bar text
            OnTabStatusTextChanged(sender, eventArgs);
        }

        #endregion
    }
}

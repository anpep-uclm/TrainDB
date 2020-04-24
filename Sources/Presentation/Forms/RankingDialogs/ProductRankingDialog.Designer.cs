namespace TrainDB {
    partial class ProductRankingDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dateStartFilter = new System.Windows.Forms.DateTimePicker();
            this.dateEndFilter = new System.Windows.Forms.DateTimePicker();
            this.dateRangeLabel = new System.Windows.Forms.Label();
            this.mainInstructionLabel = new System.Windows.Forms.Label();
            this.productContainerTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // dateStartFilter
            // 
            this.dateStartFilter.Checked = false;
            this.dateStartFilter.CustomFormat = "yyyy-MM-dd";
            this.dateStartFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartFilter.Location = new System.Drawing.Point(129, 34);
            this.dateStartFilter.Name = "dateStartFilter";
            this.dateStartFilter.ShowCheckBox = true;
            this.dateStartFilter.Size = new System.Drawing.Size(97, 21);
            this.dateStartFilter.TabIndex = 1;
            this.dateStartFilter.ValueChanged += new System.EventHandler(this.OnDateFilterValueChanged);
            // 
            // dateEndFilter
            // 
            this.dateEndFilter.Checked = false;
            this.dateEndFilter.CustomFormat = "yyyy-MM-dd";
            this.dateEndFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndFilter.Location = new System.Drawing.Point(232, 34);
            this.dateEndFilter.Name = "dateEndFilter";
            this.dateEndFilter.ShowCheckBox = true;
            this.dateEndFilter.Size = new System.Drawing.Size(97, 21);
            this.dateEndFilter.TabIndex = 2;
            this.dateEndFilter.ValueChanged += new System.EventHandler(this.OnDateFilterValueChanged);
            // 
            // dateRangeLabel
            // 
            this.dateRangeLabel.Location = new System.Drawing.Point(12, 34);
            this.dateRangeLabel.Name = "dateRangeLabel";
            this.dateRangeLabel.Size = new System.Drawing.Size(111, 21);
            this.dateRangeLabel.TabIndex = 3;
            this.dateRangeLabel.Text = "Date Range:";
            this.dateRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainInstructionLabel
            // 
            this.mainInstructionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mainInstructionLabel.Location = new System.Drawing.Point(12, 9);
            this.mainInstructionLabel.Name = "mainInstructionLabel";
            this.mainInstructionLabel.Size = new System.Drawing.Size(317, 23);
            this.mainInstructionLabel.TabIndex = 4;
            this.mainInstructionLabel.Text = "Most transported products";
            this.mainInstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // productContainerTabControl
            // 
            this.productContainerTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.productContainerTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.productContainerTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.productContainerTabControl.Location = new System.Drawing.Point(0, 68);
            this.productContainerTabControl.Name = "productContainerTabControl";
            this.productContainerTabControl.SelectedIndex = 0;
            this.productContainerTabControl.Size = new System.Drawing.Size(341, 200);
            this.productContainerTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.productContainerTabControl.TabIndex = 18;
            // 
            // ProductRankingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 268);
            this.Controls.Add(this.productContainerTabControl);
            this.Controls.Add(this.mainInstructionLabel);
            this.Controls.Add(this.dateRangeLabel);
            this.Controls.Add(this.dateEndFilter);
            this.Controls.Add(this.dateStartFilter);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductRankingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Ranking";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateStartFilter;
        private System.Windows.Forms.DateTimePicker dateEndFilter;
        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.Label mainInstructionLabel;
        private System.Windows.Forms.TabControl productContainerTabControl;
    }
}
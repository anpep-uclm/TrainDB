namespace TrainDB {
    partial class TrainPropertiesDialog {
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
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.addNewTypeButton = new System.Windows.Forms.Button();
            this.trainTypePropertiesButton = new System.Windows.Forms.Button();
            this.trainTypeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.productsTabPage = new System.Windows.Forms.TabPage();
            this.productContainerTabControl = new System.Windows.Forms.TabControl();
            this.tripCountTextBox = new System.Windows.Forms.TextBox();
            this.dateRangeLabel = new System.Windows.Forms.Label();
            this.dateStartFilter = new System.Windows.Forms.DateTimePicker();
            this.dateEndFilter = new System.Windows.Forms.DateTimePicker();
            this.tripCountLabel = new System.Windows.Forms.Label();
            this.buttonPanel.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.productsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.applyButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(6, 344);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(325, 31);
            this.buttonPanel.TabIndex = 16;
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.Location = new System.Drawing.Point(88, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OnOKButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.Location = new System.Drawing.Point(169, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.applyButton.Location = new System.Drawing.Point(246, 4);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 7;
            this.applyButton.Text = "&Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnApplyButtonClick);
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.addNewTypeButton);
            this.generalTabPage.Controls.Add(this.trainTypePropertiesButton);
            this.generalTabPage.Controls.Add(this.trainTypeComboBox);
            this.generalTabPage.Controls.Add(this.typeLabel);
            this.generalTabPage.Controls.Add(this.idTextBox);
            this.generalTabPage.Controls.Add(this.idLabel);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(317, 312);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // addNewTypeButton
            // 
            this.addNewTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewTypeButton.Location = new System.Drawing.Point(144, 66);
            this.addNewTypeButton.Name = "addNewTypeButton";
            this.addNewTypeButton.Size = new System.Drawing.Size(75, 23);
            this.addNewTypeButton.TabIndex = 3;
            this.addNewTypeButton.Text = "Add &new…";
            this.addNewTypeButton.UseVisualStyleBackColor = true;
            this.addNewTypeButton.Click += new System.EventHandler(this.OnAddNewTypeButtonClick);
            // 
            // trainTypePropertiesButton
            // 
            this.trainTypePropertiesButton.Enabled = false;
            this.trainTypePropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.trainTypePropertiesButton.Location = new System.Drawing.Point(225, 66);
            this.trainTypePropertiesButton.Name = "trainTypePropertiesButton";
            this.trainTypePropertiesButton.Size = new System.Drawing.Size(75, 23);
            this.trainTypePropertiesButton.TabIndex = 4;
            this.trainTypePropertiesButton.Text = "&Properties…";
            this.trainTypePropertiesButton.UseVisualStyleBackColor = true;
            this.trainTypePropertiesButton.Click += new System.EventHandler(this.OnTrainTypePropertiesButtonClick);
            // 
            // trainTypeComboBox
            // 
            this.trainTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.trainTypeComboBox.FormattingEnabled = true;
            this.trainTypeComboBox.Location = new System.Drawing.Point(104, 39);
            this.trainTypeComboBox.Name = "trainTypeComboBox";
            this.trainTypeComboBox.Size = new System.Drawing.Size(196, 21);
            this.trainTypeComboBox.TabIndex = 2;
            this.trainTypeComboBox.SelectedValueChanged += new System.EventHandler(this.OnTrainTypeComboBoxSelectedValueChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.Location = new System.Drawing.Point(12, 39);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(86, 21);
            this.typeLabel.TabIndex = 10;
            this.typeLabel.Text = "Type:";
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(104, 12);
            this.idTextBox.MaxLength = 64;
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(196, 21);
            this.idTextBox.TabIndex = 1;
            this.idTextBox.TextChanged += new System.EventHandler(this.OnIdTextBoxTextChanged);
            // 
            // idLabel
            // 
            this.idLabel.Location = new System.Drawing.Point(12, 12);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(86, 21);
            this.idLabel.TabIndex = 8;
            this.idLabel.Text = "ID:";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.generalTabPage);
            this.mainTabControl.Controls.Add(this.productsTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(6, 6);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(325, 338);
            this.mainTabControl.TabIndex = 0;
            // 
            // productsTabPage
            // 
            this.productsTabPage.Controls.Add(this.productContainerTabControl);
            this.productsTabPage.Controls.Add(this.tripCountTextBox);
            this.productsTabPage.Controls.Add(this.dateRangeLabel);
            this.productsTabPage.Controls.Add(this.dateStartFilter);
            this.productsTabPage.Controls.Add(this.dateEndFilter);
            this.productsTabPage.Controls.Add(this.tripCountLabel);
            this.productsTabPage.Location = new System.Drawing.Point(4, 22);
            this.productsTabPage.Name = "productsTabPage";
            this.productsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.productsTabPage.Size = new System.Drawing.Size(317, 312);
            this.productsTabPage.TabIndex = 1;
            this.productsTabPage.Text = "Products";
            this.productsTabPage.UseVisualStyleBackColor = true;
            // 
            // productContainerTabControl
            // 
            this.productContainerTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.productContainerTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.productContainerTabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.productContainerTabControl.Location = new System.Drawing.Point(3, 64);
            this.productContainerTabControl.Name = "productContainerTabControl";
            this.productContainerTabControl.SelectedIndex = 0;
            this.productContainerTabControl.Size = new System.Drawing.Size(311, 245);
            this.productContainerTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.productContainerTabControl.TabIndex = 17;
            // 
            // tripCountTextBox
            // 
            this.tripCountTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.tripCountTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tripCountTextBox.Location = new System.Drawing.Point(104, 44);
            this.tripCountTextBox.Name = "tripCountTextBox";
            this.tripCountTextBox.ReadOnly = true;
            this.tripCountTextBox.Size = new System.Drawing.Size(196, 14);
            this.tripCountTextBox.TabIndex = 16;
            this.tripCountTextBox.Text = "0";
            // 
            // dateRangeLabel
            // 
            this.dateRangeLabel.Location = new System.Drawing.Point(12, 12);
            this.dateRangeLabel.Name = "dateRangeLabel";
            this.dateRangeLabel.Size = new System.Drawing.Size(86, 21);
            this.dateRangeLabel.TabIndex = 12;
            this.dateRangeLabel.Text = "Date Range:";
            this.dateRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateStartFilter
            // 
            this.dateStartFilter.Checked = false;
            this.dateStartFilter.CustomFormat = "yyyy-MM-dd";
            this.dateStartFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStartFilter.Location = new System.Drawing.Point(104, 12);
            this.dateStartFilter.Name = "dateStartFilter";
            this.dateStartFilter.ShowCheckBox = true;
            this.dateStartFilter.Size = new System.Drawing.Size(94, 21);
            this.dateStartFilter.TabIndex = 11;
            this.dateStartFilter.ValueChanged += new System.EventHandler(this.OnDateFilterChanged);
            // 
            // dateEndFilter
            // 
            this.dateEndFilter.Checked = false;
            this.dateEndFilter.CustomFormat = "yyyy-MM-dd";
            this.dateEndFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEndFilter.Location = new System.Drawing.Point(204, 12);
            this.dateEndFilter.Name = "dateEndFilter";
            this.dateEndFilter.ShowCheckBox = true;
            this.dateEndFilter.Size = new System.Drawing.Size(96, 21);
            this.dateEndFilter.TabIndex = 10;
            this.dateEndFilter.ValueChanged += new System.EventHandler(this.OnDateFilterChanged);
            // 
            // tripCountLabel
            // 
            this.tripCountLabel.Location = new System.Drawing.Point(12, 40);
            this.tripCountLabel.Name = "tripCountLabel";
            this.tripCountLabel.Size = new System.Drawing.Size(86, 21);
            this.tripCountLabel.TabIndex = 8;
            this.tripCountLabel.Text = "Trip Count:";
            this.tripCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrainPropertiesDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(337, 381);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.buttonPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainPropertiesDialog";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.buttonPanel.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.productsTabPage.ResumeLayout(false);
            this.productsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.Button addNewTypeButton;
        private System.Windows.Forms.Button trainTypePropertiesButton;
        private System.Windows.Forms.ComboBox trainTypeComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage productsTabPage;
        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.DateTimePicker dateStartFilter;
        private System.Windows.Forms.DateTimePicker dateEndFilter;
        private System.Windows.Forms.Label tripCountLabel;
        private System.Windows.Forms.TextBox tripCountTextBox;
        private System.Windows.Forms.TabControl productContainerTabControl;
    }
}
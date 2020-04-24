namespace TrainDB {
    partial class TripPropertiesDialog {
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.addNewTrainButton = new System.Windows.Forms.Button();
            this.trainPropertiesButton = new System.Windows.Forms.Button();
            this.trainComboBox = new System.Windows.Forms.ComboBox();
            this.trainLabel = new System.Windows.Forms.Label();
            this.priceCurrencyLabel = new System.Windows.Forms.Label();
            this.weightInput = new System.Windows.Forms.NumericUpDown();
            this.weightLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.addNewProductButton = new System.Windows.Forms.Button();
            this.productPropertiesButton = new System.Windows.Forms.Button();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weightInput)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.generalTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(6, 6);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(325, 296);
            this.mainTabControl.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.addNewTrainButton);
            this.generalTabPage.Controls.Add(this.trainPropertiesButton);
            this.generalTabPage.Controls.Add(this.trainComboBox);
            this.generalTabPage.Controls.Add(this.trainLabel);
            this.generalTabPage.Controls.Add(this.priceCurrencyLabel);
            this.generalTabPage.Controls.Add(this.weightInput);
            this.generalTabPage.Controls.Add(this.weightLabel);
            this.generalTabPage.Controls.Add(this.datePicker);
            this.generalTabPage.Controls.Add(this.addNewProductButton);
            this.generalTabPage.Controls.Add(this.productPropertiesButton);
            this.generalTabPage.Controls.Add(this.productComboBox);
            this.generalTabPage.Controls.Add(this.typeLabel);
            this.generalTabPage.Controls.Add(this.dateLabel);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(317, 270);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // addNewTrainButton
            // 
            this.addNewTrainButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewTrainButton.Location = new System.Drawing.Point(142, 42);
            this.addNewTrainButton.Name = "addNewTrainButton";
            this.addNewTrainButton.Size = new System.Drawing.Size(75, 23);
            this.addNewTrainButton.TabIndex = 16;
            this.addNewTrainButton.Text = "Add &new…";
            this.addNewTrainButton.UseVisualStyleBackColor = true;
            this.addNewTrainButton.Click += new System.EventHandler(this.OnAddNewTrainButtonClick);
            // 
            // trainPropertiesButton
            // 
            this.trainPropertiesButton.Enabled = false;
            this.trainPropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.trainPropertiesButton.Location = new System.Drawing.Point(223, 42);
            this.trainPropertiesButton.Name = "trainPropertiesButton";
            this.trainPropertiesButton.Size = new System.Drawing.Size(75, 23);
            this.trainPropertiesButton.TabIndex = 17;
            this.trainPropertiesButton.Text = "&Properties…";
            this.trainPropertiesButton.UseVisualStyleBackColor = true;
            this.trainPropertiesButton.Click += new System.EventHandler(this.OnTrainPropertiesButtonClick);
            // 
            // trainComboBox
            // 
            this.trainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.trainComboBox.FormattingEnabled = true;
            this.trainComboBox.Location = new System.Drawing.Point(102, 15);
            this.trainComboBox.Name = "trainComboBox";
            this.trainComboBox.Size = new System.Drawing.Size(196, 21);
            this.trainComboBox.TabIndex = 15;
            this.trainComboBox.SelectedValueChanged += new System.EventHandler(this.OnTrainComboBoxSelectedValueChanged);
            // 
            // trainLabel
            // 
            this.trainLabel.Location = new System.Drawing.Point(10, 15);
            this.trainLabel.Name = "trainLabel";
            this.trainLabel.Size = new System.Drawing.Size(86, 21);
            this.trainLabel.TabIndex = 18;
            this.trainLabel.Text = "Train:";
            this.trainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // priceCurrencyLabel
            // 
            this.priceCurrencyLabel.Location = new System.Drawing.Point(242, 154);
            this.priceCurrencyLabel.Name = "priceCurrencyLabel";
            this.priceCurrencyLabel.Size = new System.Drawing.Size(56, 21);
            this.priceCurrencyLabel.TabIndex = 14;
            this.priceCurrencyLabel.Text = "tonnes";
            this.priceCurrencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weightInput
            // 
            this.weightInput.Location = new System.Drawing.Point(102, 154);
            this.weightInput.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightInput.Name = "weightInput";
            this.weightInput.Size = new System.Drawing.Size(138, 21);
            this.weightInput.TabIndex = 6;
            this.weightInput.ThousandsSeparator = true;
            this.weightInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightInput.ValueChanged += new System.EventHandler(this.OnWeightInputValueChanged);
            // 
            // weightLabel
            // 
            this.weightLabel.Location = new System.Drawing.Point(10, 154);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(86, 21);
            this.weightLabel.TabIndex = 12;
            this.weightLabel.Text = "Weight:";
            this.weightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(102, 71);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(196, 21);
            this.datePicker.TabIndex = 5;
            this.datePicker.ValueChanged += new System.EventHandler(this.OnDatePickerValueChanged);
            // 
            // addNewProductButton
            // 
            this.addNewProductButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addNewProductButton.Location = new System.Drawing.Point(142, 125);
            this.addNewProductButton.Name = "addNewProductButton";
            this.addNewProductButton.Size = new System.Drawing.Size(75, 23);
            this.addNewProductButton.TabIndex = 3;
            this.addNewProductButton.Text = "Add &new…";
            this.addNewProductButton.UseVisualStyleBackColor = true;
            this.addNewProductButton.Click += new System.EventHandler(this.OnAddNewProductButtonClick);
            // 
            // productPropertiesButton
            // 
            this.productPropertiesButton.Enabled = false;
            this.productPropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.productPropertiesButton.Location = new System.Drawing.Point(223, 125);
            this.productPropertiesButton.Name = "productPropertiesButton";
            this.productPropertiesButton.Size = new System.Drawing.Size(75, 23);
            this.productPropertiesButton.TabIndex = 4;
            this.productPropertiesButton.Text = "&Properties…";
            this.productPropertiesButton.UseVisualStyleBackColor = true;
            this.productPropertiesButton.Click += new System.EventHandler(this.OnProductPropertiesButtonClick);
            // 
            // productComboBox
            // 
            this.productComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(102, 98);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(196, 21);
            this.productComboBox.TabIndex = 2;
            this.productComboBox.SelectedValueChanged += new System.EventHandler(this.OnProductComboBoxSelectedValueChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.Location = new System.Drawing.Point(10, 98);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(86, 21);
            this.typeLabel.TabIndex = 10;
            this.typeLabel.Text = "Product:";
            this.typeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateLabel
            // 
            this.dateLabel.Location = new System.Drawing.Point(10, 71);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(86, 21);
            this.dateLabel.TabIndex = 8;
            this.dateLabel.Text = "Date:";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.okButton);
            this.buttonPanel.Controls.Add(this.cancelButton);
            this.buttonPanel.Controls.Add(this.applyButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(6, 302);
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
            this.okButton.TabIndex = 7;
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
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.applyButton.Location = new System.Drawing.Point(246, 4);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 9;
            this.applyButton.Text = "&Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnApplyButtonClick);
            // 
            // TripPropertiesDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(337, 339);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.buttonPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TripPropertiesDialog";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trip Properties";
            this.mainTabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weightInput)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label priceCurrencyLabel;
        private System.Windows.Forms.NumericUpDown weightInput;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Button addNewTrainButton;
        private System.Windows.Forms.Button trainPropertiesButton;
        private System.Windows.Forms.ComboBox trainComboBox;
        private System.Windows.Forms.Label trainLabel;
        private System.Windows.Forms.Button addNewProductButton;
        private System.Windows.Forms.Button productPropertiesButton;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.Label typeLabel;
    }
}
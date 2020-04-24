namespace TrainDB {
    partial class PricePropertiesDialog {
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
            this.priceCurrencyLabel = new System.Windows.Forms.Label();
            this.priceInput = new System.Windows.Forms.NumericUpDown();
            this.priceLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.priceInput)).BeginInit();
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
            this.mainTabControl.Size = new System.Drawing.Size(325, 219);
            this.mainTabControl.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.priceCurrencyLabel);
            this.generalTabPage.Controls.Add(this.priceInput);
            this.generalTabPage.Controls.Add(this.priceLabel);
            this.generalTabPage.Controls.Add(this.datePicker);
            this.generalTabPage.Controls.Add(this.addNewProductButton);
            this.generalTabPage.Controls.Add(this.productPropertiesButton);
            this.generalTabPage.Controls.Add(this.productComboBox);
            this.generalTabPage.Controls.Add(this.typeLabel);
            this.generalTabPage.Controls.Add(this.dateLabel);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(317, 193);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // priceCurrencyLabel
            // 
            this.priceCurrencyLabel.Location = new System.Drawing.Point(235, 98);
            this.priceCurrencyLabel.Name = "priceCurrencyLabel";
            this.priceCurrencyLabel.Size = new System.Drawing.Size(63, 21);
            this.priceCurrencyLabel.TabIndex = 14;
            this.priceCurrencyLabel.Text = "EUR/tonne";
            this.priceCurrencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priceInput
            // 
            this.priceInput.DecimalPlaces = 2;
            this.priceInput.Location = new System.Drawing.Point(102, 98);
            this.priceInput.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.priceInput.Name = "priceInput";
            this.priceInput.Size = new System.Drawing.Size(127, 21);
            this.priceInput.TabIndex = 6;
            this.priceInput.ThousandsSeparator = true;
            this.priceInput.ValueChanged += new System.EventHandler(this.OnPriceInputValueChanged);
            // 
            // priceLabel
            // 
            this.priceLabel.Location = new System.Drawing.Point(10, 98);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(86, 21);
            this.priceLabel.TabIndex = 12;
            this.priceLabel.Text = "Price:";
            this.priceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.addNewProductButton.Location = new System.Drawing.Point(142, 42);
            this.addNewProductButton.Name = "addNewProductButton";
            this.addNewProductButton.Size = new System.Drawing.Size(75, 23);
            this.addNewProductButton.TabIndex = 3;
            this.addNewProductButton.Text = "Add &new…";
            this.addNewProductButton.UseVisualStyleBackColor = true;
            this.addNewProductButton.Click += new System.EventHandler(this.OnAddNewTypeButtonClick);
            // 
            // productPropertiesButton
            // 
            this.productPropertiesButton.Enabled = false;
            this.productPropertiesButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.productPropertiesButton.Location = new System.Drawing.Point(223, 42);
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
            this.productComboBox.Location = new System.Drawing.Point(102, 15);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(196, 21);
            this.productComboBox.TabIndex = 2;
            this.productComboBox.SelectedValueChanged += new System.EventHandler(this.OnProductComboBoxSelectedValueChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.Location = new System.Drawing.Point(10, 15);
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
            this.buttonPanel.Location = new System.Drawing.Point(6, 225);
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
            // PricePropertiesDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(337, 262);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.buttonPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PricePropertiesDialog";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Price Properties";
            this.mainTabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.priceInput)).EndInit();
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
        private System.Windows.Forms.Button productPropertiesButton;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Button addNewProductButton;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label priceCurrencyLabel;
        private System.Windows.Forms.NumericUpDown priceInput;
        private System.Windows.Forms.Label priceLabel;
    }
}
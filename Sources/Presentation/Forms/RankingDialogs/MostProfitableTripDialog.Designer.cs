namespace TrainDB {
    partial class MostProfitableTripDialog {
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
            this.dateRangeLabel = new System.Windows.Forms.Label();
            this.mainInstructionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trainIdTextBox = new System.Windows.Forms.TextBox();
            this.trainDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.productDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.productIdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pricePerTonneTextBox = new System.Windows.Forms.TextBox();
            this.tonnesTransportedTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.totalProfitTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateRangeLabel
            // 
            this.dateRangeLabel.Location = new System.Drawing.Point(12, 66);
            this.dateRangeLabel.Name = "dateRangeLabel";
            this.dateRangeLabel.Size = new System.Drawing.Size(111, 21);
            this.dateRangeLabel.TabIndex = 3;
            this.dateRangeLabel.Text = "Train ID:";
            this.dateRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainInstructionLabel
            // 
            this.mainInstructionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mainInstructionLabel.Location = new System.Drawing.Point(12, 9);
            this.mainInstructionLabel.Name = "mainInstructionLabel";
            this.mainInstructionLabel.Size = new System.Drawing.Size(317, 23);
            this.mainInstructionLabel.TabIndex = 4;
            this.mainInstructionLabel.Text = "Most Profitable Trip";
            this.mainInstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Train Information";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.OnLeadingLabelPaint);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Train Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trainIdTextBox
            // 
            this.trainIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trainIdTextBox.Location = new System.Drawing.Point(129, 70);
            this.trainIdTextBox.Name = "trainIdTextBox";
            this.trainIdTextBox.ReadOnly = true;
            this.trainIdTextBox.Size = new System.Drawing.Size(200, 14);
            this.trainIdTextBox.TabIndex = 7;
            // 
            // trainDescriptionTextBox
            // 
            this.trainDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trainDescriptionTextBox.Location = new System.Drawing.Point(129, 91);
            this.trainDescriptionTextBox.Name = "trainDescriptionTextBox";
            this.trainDescriptionTextBox.ReadOnly = true;
            this.trainDescriptionTextBox.Size = new System.Drawing.Size(200, 14);
            this.trainDescriptionTextBox.TabIndex = 8;
            // 
            // productDescriptionTextBox
            // 
            this.productDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productDescriptionTextBox.Location = new System.Drawing.Point(129, 156);
            this.productDescriptionTextBox.Name = "productDescriptionTextBox";
            this.productDescriptionTextBox.ReadOnly = true;
            this.productDescriptionTextBox.Size = new System.Drawing.Size(200, 14);
            this.productDescriptionTextBox.TabIndex = 13;
            // 
            // productIdTextBox
            // 
            this.productIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productIdTextBox.Location = new System.Drawing.Point(129, 135);
            this.productIdTextBox.Name = "productIdTextBox";
            this.productIdTextBox.ReadOnly = true;
            this.productIdTextBox.Size = new System.Drawing.Size(200, 14);
            this.productIdTextBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Product Description:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Product Information";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Paint += new System.Windows.Forms.PaintEventHandler(this.OnLeadingLabelPaint);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Product ID:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 21);
            this.label6.TabIndex = 14;
            this.label6.Text = "Price per Tonne:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pricePerTonneTextBox
            // 
            this.pricePerTonneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pricePerTonneTextBox.Location = new System.Drawing.Point(129, 176);
            this.pricePerTonneTextBox.Name = "pricePerTonneTextBox";
            this.pricePerTonneTextBox.ReadOnly = true;
            this.pricePerTonneTextBox.Size = new System.Drawing.Size(200, 14);
            this.pricePerTonneTextBox.TabIndex = 15;
            // 
            // tonnesTransportedTextBox
            // 
            this.tonnesTransportedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tonnesTransportedTextBox.Location = new System.Drawing.Point(129, 241);
            this.tonnesTransportedTextBox.Name = "tonnesTransportedTextBox";
            this.tonnesTransportedTextBox.ReadOnly = true;
            this.tonnesTransportedTextBox.Size = new System.Drawing.Size(200, 14);
            this.tonnesTransportedTextBox.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tonnes Transported:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label8.Location = new System.Drawing.Point(12, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(317, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Trip Information";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Paint += new System.Windows.Forms.PaintEventHandler(this.OnLeadingLabelPaint);
            // 
            // totalProfitTextBox
            // 
            this.totalProfitTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalProfitTextBox.Location = new System.Drawing.Point(129, 261);
            this.totalProfitTextBox.Name = "totalProfitTextBox";
            this.totalProfitTextBox.ReadOnly = true;
            this.totalProfitTextBox.Size = new System.Drawing.Size(200, 14);
            this.totalProfitTextBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 21);
            this.label9.TabIndex = 19;
            this.label9.Text = "Total Profit:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTextBox
            // 
            this.dateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateTextBox.Location = new System.Drawing.Point(129, 221);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.ReadOnly = true;
            this.dateTextBox.Size = new System.Drawing.Size(200, 14);
            this.dateTextBox.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 21);
            this.label10.TabIndex = 21;
            this.label10.Text = "Date:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MostProfitableTripDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 308);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.totalProfitTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tonnesTransportedTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pricePerTonneTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.productDescriptionTextBox);
            this.Controls.Add(this.productIdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trainDescriptionTextBox);
            this.Controls.Add(this.trainIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainInstructionLabel);
            this.Controls.Add(this.dateRangeLabel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MostProfitableTripDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Most Profitable Trip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dateRangeLabel;
        private System.Windows.Forms.Label mainInstructionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox trainIdTextBox;
        private System.Windows.Forms.TextBox trainDescriptionTextBox;
        private System.Windows.Forms.TextBox productDescriptionTextBox;
        private System.Windows.Forms.TextBox productIdTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pricePerTonneTextBox;
        private System.Windows.Forms.TextBox tonnesTransportedTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox totalProfitTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Label label10;
    }
}
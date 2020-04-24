using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TrainDB {
    public partial class MostProfitableTripDialog : Form {
        /// <summary>
        ///     Constructor
        /// </summary>
        public MostProfitableTripDialog() {
            InitializeComponent();

            var information = new TripDAO().QueryMostProfitableTrip();

            this.trainIdTextBox.Text = (string) information["TrainID"];
            this.trainDescriptionTextBox.Text = (string) information["TrainTypeDescription"];
            this.productIdTextBox.Text = ((long) information["ProductID"]).ToString();
            this.productDescriptionTextBox.Text = (string) information["ProductDescription"];
            this.pricePerTonneTextBox.Text = ((double) information["EurosPerTon"]).ToString("N") + " €/t";
            this.dateTextBox.Text = (string) information["TripDate"];
            this.tonnesTransportedTextBox.Text = ((long) information["TonsTransported"]).ToString("N0") + " t";
            this.totalProfitTextBox.Text = ((double) information["TripValue"]).ToString("N") + " €";
        }

        private void OnLeadingLabelPaint(object sender, PaintEventArgs eventArgs) {
            var label = (Label) sender;
            var pen = new Pen(new LinearGradientBrush(Point.Empty, new Point(label.Width, 0), BackColor, Color.DimGray));
            eventArgs.Graphics.DrawLine(pen, 0, label.Height - 1, label.Width, label.Height - 1);
        }
    }
}

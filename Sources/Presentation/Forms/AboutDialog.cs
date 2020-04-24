using System;
using System.Linq;
using System.Windows.Forms;

namespace TrainDB {
    public partial class AboutDialog : Form {
        public AboutDialog() {
            InitializeComponent();
            productNameLabel.Text = System.Windows.Forms.Application.ProductName;
            versionLabel.Text = $"Version {String.Join(".", System.Windows.Forms.Application.ProductVersion.Split('.').Take(2))}";
        }
    }
}

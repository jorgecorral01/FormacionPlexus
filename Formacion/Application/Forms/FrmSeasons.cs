using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kata1.Forms {
    public partial class FrmSeasons : Form {
        public FrmSeasons() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e){
            var clsSeason = new ClsSeason(new Clock());
            MessageBox.Show(clsSeason.GetSeason());
        }
    }
}

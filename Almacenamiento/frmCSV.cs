using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacenamiento
{
    public partial class frmCSV : MaterialForm
    {
        public frmCSV()
        {
            InitializeComponent();
        }

        private void frmCSV_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openCSV = new OpenFileDialog();
            openCSV.ShowDialog();

        }
    }
}

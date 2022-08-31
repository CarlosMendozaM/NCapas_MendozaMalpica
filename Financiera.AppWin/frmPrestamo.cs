using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financiera.AppWin
{
    public partial class frmPrestamo : Form
    {
        public frmPrestamo()
        {
            InitializeComponent();
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var frm = new frmPrestamoEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}

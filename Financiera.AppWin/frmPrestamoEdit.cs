using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Financiera.Logic;

namespace Financiera.AppWin
{
    public partial class frmPrestamoEdit : Form
    {
        public frmPrestamoEdit()
        {
            InitializeComponent();
        }

        private void grabarRegistro(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void iniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            cboCliente.DataSource = ClienteBL.Listar();
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "ID";
        }
    }
}

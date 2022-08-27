using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Financiera.Dominio;
using Financiera.Logic;

namespace Financiera.AppWin
{
    public partial class frmClienteEdit : Form
    {
        Cliente cliente;
        public frmClienteEdit(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void Iniciar_Formulario(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void cargardatos()
        {
            cboTipoDocumento.DataSource = TipoDocumentoBL.Listar();
            cboTipoDocumento.DisplayMember = "Nombre";
            cboTipoDocumento.ValueMember = "ID";

            cboTipoCliente.DataSource = TipoClienteBL.Listar();
            cboTipoCliente.DisplayMember = "Nombre";
            cboTipoCliente.ValueMember = "ID";
        }
    }
}

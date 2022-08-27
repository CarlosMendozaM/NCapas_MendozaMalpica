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
            if (cliente.ID > 0)
            {
                asignarControles();
            }
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

        private void grabarDatos(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }

        private void asignarObjeto()
        {
            this.cliente.Nombres = txtNombre.Text;
            this.cliente.Apellidos = txtApellido.Text;
            this.cliente.Direccion = txtDireccion.Text;
            this.cliente.Referencia = txtReferencia.Text;
            this.cliente.IdTipoCliente = int.Parse(cboTipoCliente.SelectedValue.ToString());
            this.cliente.IdTipoDocumento = int.Parse(cboTipoDocumento.SelectedValue.ToString());
            this.cliente.NumeroDocumento = txtNumeroDocumento.Text;
            this.cliente.Estado = chkEstado.Checked;
        }

        private void asignarControles()
        {
            txtNombre.Text = this.cliente.Nombres;
            txtApellido.Text = this.cliente.Apellidos;
            txtDireccion.Text = this.cliente.Direccion;
            txtReferencia.Text = this.cliente.Referencia;
            cboTipoCliente.SelectedValue = this.cliente.IdTipoCliente;
            cboTipoDocumento.SelectedValue = this.cliente.IdTipoDocumento;
            txtNumeroDocumento.Text = this.cliente.NumeroDocumento;
            chkEstado.Checked = this.cliente.Estado;
        }
    }
}

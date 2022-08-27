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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            var listado = ClienteBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var cliente in listado)
            {
                dgvListado.Rows.Add(cliente.ID,cliente.NombreCompleto,cliente.Direccion);
            }
        }

        private void nuevoRegistro(object sender, EventArgs e)
        {
            var nuevoCliente = new Cliente();
            var frm = new frmClienteEdit(nuevoCliente);
            if (frm.ShowDialog() == DialogResult.OK )
            {
                var exito = ClienteBL.Insertar(nuevoCliente);
                if (exito)
                {
                    MessageBox.Show("El cliente ha sido registrado","Financiera",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("El cliente no se ha podido registrar", "Financiera",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void editarRegistro(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idCliente = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var clienteEditar = ClienteBL.BuscarPorId(idCliente);
                var frm = new frmClienteEdit(clienteEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}

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
using Financiera.Dominio;

namespace Financiera.AppWin
{
    public partial class frmPrestamoEdit : Form
    {
        Prestamo prestamo;
        public frmPrestamoEdit(Prestamo prestamo)
        {
            this.prestamo = prestamo;
            InitializeComponent();
        }

        private void grabarRegistro(object sender, EventArgs e)
        {
            asignarObjeto();
            var exito = false;
            if(prestamo.ID == 0)
            {
                exito = PrestamoBL.Insertar(prestamo);
            } else
            {
                exito = PrestamoBL.Actualizar(prestamo);
            }
            if (exito)
            {
                MessageBox.Show("El prestamo ha sido registrado", "Financiera", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("No se ha podido completar la operacion", "Financiera",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iniciarFormulario(object sender, EventArgs e)
        {
            cargarDatos();
            llDetalle.Visible = prestamo.ID > 0;
            btnGrabar.Enabled = prestamo.ID == 0;
        }

        private void cargarDatos()
        {
            var listado = ClienteBL.Listar();
            listado.Insert(0, new Cliente
            {
                Nombres = "--SELECCIONE--"
            });
            cboCliente.DataSource = listado;
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "ID";
        }

        private void asignarObjeto()
        {
            prestamo.IdCliente = int.Parse(cboCliente.SelectedValue.ToString());
            prestamo.FechaDeposito = dpFechaDeposito.Value;
            prestamo.Importe = decimal.Parse(txtImporte.Text);
            prestamo.tasa = decimal.Parse(txtTaza.Text);
            prestamo.Plazo = int.Parse(txtPlazo.Text);
        }

        private void verDetalles(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new frmCuotas();
            frm.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.DocuClass
{
    public partial class DocuClassRecibir : Form
    {
        public DocuClassRecibir()
        {
            InitializeComponent();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            LoadingScreen.iniciarLoading();
            strSQL = @"SELECT DISTINCT NUMERO_DE_CAJA, CAJA_CLIENTE, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO FROM INVENTARIO_GENERAL IG 
                        LEFT JOIN TMP_CARRITO TC ON TC.NUMERO_CAJA = IG.NUMERO_DE_CAJA
                        WHERE TC.ID_TMP_CARRITO IS NULL AND USUARIO_POSEE = 'DOCUCLASS'";
            if (tbBusquedaLibre.Text != "")
            {
                strSQL = strSQL + " AND NUMERO_DE_CAJA LIKE @busqueda_libre";
            }
            strSQL = strSQL + " ORDER BY NUMERO_DE_CAJA";
            try
            {
                DataTable dt = new DataTable();

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.agregarParametroCommand("@busqueda_libre", "%" + tbBusquedaLibre.Text + "%"))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgv.DataSource = dt;

                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }

        }

        private void btEntregar_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                DocuClassFunctions.RecibirCarrito();
                actualizarCantidad();
                btBuscar_Click(sender, e);
            }
        }

        private void cbDesembolsado_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCantidad();
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strDocuClassRecibir) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strDocuClassRecibir);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strDocuClassRecibir;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells[0].Value.ToString(), Globals.strDocuClassRecibir);
                    actualizarCantidad();
                    btBuscar_Click(sender, e);
                }
            }
        }
        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

    }
}

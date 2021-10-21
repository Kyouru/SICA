using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Pagare
{
    public partial class PagareEntregar : Form
    {
        public PagareEntregar()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();

                strSQL = @"SELECT ID_PAGARE, SOLICITUD_SISGO AS SOLICITUD, DESCRIPCION_3 AS CODIGO, DESCRIPCION_4 AS NOMBRE, DESCRIPCION_5
                        FROM PAGARE PA WHERE USUARIO_POSEE = '" + Globals.Username + "'";
                strSQL += " ORDER BY SOLICITUD_SISGO DESC";

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
                //dgv.Columns["DESC_1"].Width = 250;

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strPagareEntregar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strPagareEntregar);
            actualizarCantidad();
        }
        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strPagareEntregar) + ")";
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    GlobalFunctions.AgregarCarrito("0", dgv.SelectedRows[0].Cells["ID_PAGARE"].Value.ToString(), dgv.SelectedRows[0].Cells["SOLICITUD_SISGO"].Value.ToString(), Globals.strPagareEntregar);
                    actualizarCantidad();
                }
            }
        }

        private void btEntregar_Click(object sender, EventArgs e)
        {

            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {

                    PagareFunctions.EntregarPagareCarrito();
                    actualizarCantidad();

                    //btActualizar_Click(sender, e);
                }
            }
        }
    }
}

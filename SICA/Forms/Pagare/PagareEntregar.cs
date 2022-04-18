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
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strPagareEntregar;

        public PagareEntregar()
        {
            InitializeComponent();
            Globals.CarritoSeleccionado = tipo_carrito;
            actualizarCantidad();
        }
        public void actualizarCantidad(int cantidad = -1)
        {
            if (cantidad >= 0)
            {
                cantidadcarrito = cantidad;
            }
            else
            {
                cantidadcarrito = GlobalFunctions.CantidadCarrito(tipo_carrito);
            }
            lbCantidad.Text = "(" + cantidadcarrito + ")";
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();

                strSQL = "SELECT ID_PAGARE, SOLICITUD_SISGO AS SOLICITUD, DESCRIPCION_3 AS CODIGO, DESCRIPCION_4 AS NOMBRE, DESCRIPCION_5";
                strSQL += " FROM (PAGARE PA LEFT JOIN (SELECT * FROM USUARIO WHERE ID_AREA_FK = " + Globals.IdAreaCustodia + ") U ON U.ID_USUARIO = PA.ID_USUARIO_POSEE)";
                strSQL += " LEFT JOIN TMP_CARRITO TC ON TC.ID_AUX_FK = PA.ID_PAGARE";
                strSQL += " WHERE TC.ID_TMP_CARRITO IS NULL";
                strSQL += " AND U.ID_USUARIO IS NOT NULL";
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

                actualizarCantidad();
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
            GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog();
                btBuscar_Click(sender, e);
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strPagareEntregar);
            btBuscar_Click(sender, e);
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    GlobalFunctions.AgregarCarrito("0", dgv.SelectedRows[0].Cells["ID_PAGARE"].Value.ToString(), dgv.SelectedRows[0].Cells["SOLICITUD"].Value.ToString(), Globals.strPagareEntregar);
                    btBuscar_Click(sender, e);
                }
            }
        }

        private void btEntregar_Click(object sender, EventArgs e)
        {

            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryArea = "";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    PagareFunctions.EntregarPagareCarrito();
                    actualizarCantidad(0);
                }
            }
        }
    }
}

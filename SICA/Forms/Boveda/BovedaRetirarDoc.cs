using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Boveda
{
    public partial class BovedaRetirarDoc : Form
    {
        public BovedaRetirarDoc()
        {
            InitializeComponent();
            actualizarCantidad();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            try
            {
                LoadingScreen.iniciarLoading();
                DataTable dt = new DataTable();
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, U.ID_USUARIO AS ID_BOVEDA, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.USERNAME = IG.USUARIO_POSEE)";
                strSQL = strSQL + " LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                strSQL = strSQL + " WHERE U.BOVEDA > 0 AND CUSTODIADO = 'CUSTODIADO' AND TC.ID_TMP_CARRITO IS NULL";
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY NUMERO_DE_CAJA";

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
                dgv.Columns[1].Visible = false;
                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void agregar()
        {
            if (dgv.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells["ID"].Value.ToString(), dgv.SelectedRows[0].Cells["ID_BOVEDA"].Value.ToString(), dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strBovedaRetirarDOC);
                actualizarCantidad();
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                agregar();
                actualizarCantidad();
                btBuscar_Click(sender, e);
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                BovedaFunctions.RetirarDocCarrito();
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaRetirarDOC) + ")";
                btBuscar_Click(sender, e);
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaRetirarDOC) + ")";
        }


        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strBovedaRetirarDOC);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strBovedaRetirarDOC;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }
    }
}

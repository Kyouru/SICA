using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Recibir
{
    public partial class RecibirReingreso : Form
    {
        public RecibirReingreso()
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
                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS POSEE";
                strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK) ";
                strSQL = strSQL + " LEFT JOIN USUARIO U ON U.USERNAME = IG.USUARIO_POSEE";
                strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND (CUSTODIADO = 'PRESTADO' OR CUSTODIADO = 'DEVUELTO') AND U.CUSTODIA = FALSE AND U.REAL = TRUE";

                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND USUARIO_POSEE LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";

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
                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void btRecibir_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL = TRUE";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    RecibirFunctions.ReingresoCarrito(Globals.IdUsernameSelect, observacion);
                    actualizarCantidad();
                }
            }
        }



        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strRecibirReingreso;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strRecibirReingreso);
                actualizarCantidad();
                btBuscar_Click(sender, e);
            }
        }
        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }
        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strRecibirReingreso) + ")";
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strRecibirReingreso);
            actualizarCantidad();
        }
    }
}

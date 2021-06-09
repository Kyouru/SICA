
using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Entregar
{
    public partial class EntregarDocumento : Form
    {
        string tipo_carrito = Globals.strEntregarDocumento;

        public EntregarDocumento()
        {
            InitializeComponent();
            actualizarCantidad();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL";
                                strSQL = strSQL + " AND DESCRIPCION_1 <> 'EXPEDIENTES DE CREDITO' AND DESCRIPCION_1 <> 'EXPEDIENTE DE CRÉDITO' AND USUARIO_POSEE = @usuario_posee";
            if (tbBusquedaLibre.Text != "")
                strSQL = strSQL + " AND NUMERO_DE_CAJA+DESC_CONCAT LIKE @busqueda_libre";
            strSQL = strSQL + " ORDER BY DESCRIPCION_2";
            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.agregarParametroCommand("@usuario_posee", Globals.Username))
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

        private void btEntregar_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL2 = TRUE";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    EntregarFunctions.EntregarDocumentosCarrito(observacion);
                    actualizarCantidad();

                    btBuscar_Click(sender, e);
                }
            }
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = tipo_carrito;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(tipo_carrito) + ")";
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            actualizarCantidad();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                foreach (DataGridViewRow element in dgv.SelectedRows)
                {
                    GlobalFunctions.AgregarCarrito(element.Cells[0].Value.ToString(), "0", element.Cells["CAJA"].Value.ToString(), tipo_carrito);
                }
                actualizarCantidad();
                btBuscar_Click(sender, e);
            }
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Entregar
{
    public partial class EntregarExpediente : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strEntregarExpediente;
        
        public EntregarExpediente()
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
            string strSQL;

            strSQL = @"SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, DEP.NOMBRE_DEPARTAMENTO AS DEPART, DOC.NOMBRE_DOCUMENTO AS DOC,
                        FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2,
                        DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, LE.NOMBRE_ESTADO AS CUSTODIADO, U.NOMBRE_USUARIO AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
            strSQL += " FROM ((((INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK)";
            strSQL += " LEFT JOIN LDEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = IG.ID_DEPARTAMENTO_FK)";
            strSQL += " LEFT JOIN LDOCUMENTO DOC ON DOC.ID_DOCUMENTO = IG.ID_DOCUMENTO_FK)";
            strSQL += " LEFT JOIN USUARIO U ON U.ID_USUARIO = IG.ID_USUARIO_POSEE)";
            strSQL += " LEFT JOIN LESTADO LE ON LE.ID_ESTADO = IG.ID_ESTADO_FK";
            strSQL += " WHERE TC.ID_TMP_CARRITO IS NULL";
            strSQL += " AND IG.EXPEDIENTE = 1 AND ID_USUARIO_POSEE = @username";

            if (tbBusquedaLibre.Text != "")
                strSQL += " AND NUMERO_DE_CAJA+DESC_CONCAT LIKE @busqueda_libre";
            //strSQL += " ORDER BY DESCRIPCION_2";

            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.agregarParametroCommand("@username", Globals.IdUsername.ToString()))
                    return;
                if (!Conexion.agregarParametroCommand("@busqueda_libre", "%" + tbBusquedaLibre.Text + "%"))
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
                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                actualizarCantidad(cantidadcarrito + 1);
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgv.Rows.Remove(row);
                }
                //btBuscar_Click(sender, e);
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
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    EntregarFunctions.EntregarExpedientesCarrito(observacion);
                    actualizarCantidad(0);
                }
            }
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog(this);
                btBuscar_Click(sender, e);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            //GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            btBuscar_Click(sender, e);
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (!Conexion.conectar())
                    return;
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    string strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_AUX_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (";
                    strSQL += row.Cells["ID"].Value.ToString() + ", " + 0 + ", " + Globals.IdUsername + ", '" + tipo_carrito + "', '" + row.Cells["CAJA"].Value.ToString() + "')";
                    try
                    {
                        if (!Conexion.iniciaCommand(strSQL))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                        return;
                    }
                    ++cantidadcarrito;
                }
                Conexion.cerrar();

                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgv.Rows.Remove(row);
                }
                actualizarCantidad(cantidadcarrito);
            }
        }
    }
}

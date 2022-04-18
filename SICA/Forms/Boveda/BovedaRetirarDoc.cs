using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Boveda
{
    public partial class BovedaRetirarDoc : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strBovedaRetirarDOC;
        public BovedaRetirarDoc()
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
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, U.ID_USUARIO AS ID_BOVEDA, U.NOMBRE_USUARIO AS POSEE, NUMERO_DE_CAJA AS CAJA, DEP.NOMBRE_DEPARTAMENTO AS DEPART, DOC.NOMBRE_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, LE.NOMBRE_ESTADO AS CUSTODIADO, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                strSQL += " FROM ((((INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.ID_USUARIO = IG.ID_USUARIO_POSEE)";
                strSQL += " LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL)";
                strSQL += " LEFT JOIN LDEPARTAMENTO DEP ON IG.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO)";
                strSQL += " LEFT JOIN LDOCUMENTO DOC ON IG.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO)";
                strSQL += " LEFT JOIN LESTADO LE ON LE.ID_ESTADO = IG.ID_ESTADO_FK";
                strSQL += " WHERE U.ID_AREA_FK = " + Globals.IdAreaBoveda + " AND IG.ID_ESTADO_FK = " + Globals.IdCustodiado + " AND TC.ID_TMP_CARRITO IS NULL";
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL += " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL += " ORDER BY NUMERO_DE_CAJA";

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
            DataTable dt;
            DataTable dtrepetidos = new DataTable();
            bool yaexiste;
            if (!Conexion.conectar())
                return;
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                string strSQL = "SELECT ID_INVENTARIO_GENERAL, NUMERO_DE_CAJA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, NOMBRE_USUARIO FROM (TMP_CARRITO TC";
                strSQL += " LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL)";
                strSQL += " LEFT JOIN USUARIO U ON U.ID_USUARIO = TC.ID_USUARIO_FK";
                strSQL += " WHERE ID_INVENTARIO_GENERAL_FK = " + row.Cells["ID"].Value.ToString();
                try
                {
                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                    dt = Conexion.llenarDataTable();
                    if (dt is null)
                        return;
                    if (dt.Rows.Count > 0)
                    {
                        yaexiste = true;
                        dtrepetidos.Rows.Add(dt.Rows[0]);
                    }
                    else
                    {
                        yaexiste = false;
                    }
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                    return;
                }

                if (!yaexiste)
                {
                    strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_AUX_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (";
                    strSQL += row.Cells["ID"].Value.ToString() + ", " + dgv.SelectedRows[0].Cells["ID_BOVEDA"].Value.ToString() + ", " + Globals.IdUsername + ", '" + tipo_carrito + "', '" + row.Cells["CAJA"].Value.ToString() + "')";
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
            }
            actualizarCantidad(cantidadcarrito);
            Conexion.cerrar();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgv.Rows.Remove(row);
            }

            if (dtrepetidos.Rows.Count > 0)
            {
                MessageBox.Show("Algunos Documentos se encuentra en Carrito de otro usuario");
                DataGridView dgvrepetidos = new DataGridView();
                dgvrepetidos.DataSource = dtrepetidos;
                GlobalFunctions.ExportarDataGridViewCSV(dgvrepetidos, null);
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
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                BovedaFunctions.RetirarDocCarrito();
                actualizarCantidad(0);
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            btBuscar_Click(sender, e);
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
    }
}

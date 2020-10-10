using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Boveda
{
    public partial class BovedaRetirar : Form
    {
        public BovedaRetirar()
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
                DataTable dt = new DataTable("REPORTE_VALORADOS");
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, U.ID_USUARIO, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
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
                if (cbCaja.Checked)
                {
                    string strSQL = "";
                    try
                    {
                        DataTable dt = new DataTable();
                        
                        string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                        strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                        strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.USERNAME = IG.USUARIO_POSEE)";
                        strSQL = strSQL + " LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                        strSQL = strSQL + " WHERE U.BOVEDA > 0 AND CUSTODIADO = 'CUSTODIADO' AND TC.ID_TMP_CARRITO IS NULL ";
                        strSQL = strSQL + " AND IG.ID_INVENTARIO_GENERAL = " + dgv.SelectedRows[0].Cells["ID"].Value.ToString();

                        if (!Conexion.conectar())
                            return;
                        if (!Conexion.iniciaCommand(strSQL))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;
                        dt = Conexion.llenarDataTable();
                        if (dt is null)
                            return;
                        
                        foreach (DataRow row in dt.Rows)
                        {
                            strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (" + row["ID"].ToString() + ", " + Globals.IdUsername + ", '" + Globals.strBovedaRetirar + "', '" + row["CAJA"].ToString() + "')";
                            
                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;
                        }

                        Conexion.cerrar();
                        LoadingScreen.cerrarLoading();
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                        return;
                    }
                }
                else
                {
                    GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strBovedaRetirar);
                }

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
                BovedaFunctions.RetirarCarrito();
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaRetirar) + ")";
                btBuscar_Click(sender, e);
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaRetirar) + ")";
        }


        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strBovedaRetirar);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strBovedaRetirar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }
    }
}

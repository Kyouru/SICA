using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainRecibir : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strIronMountainRecibir;
        public IronMountainRecibir()
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
        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                IronMountainFunctions.RecibirCajasCarrito();
                actualizarCantidad(0);
            }
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
                    strSQL += row.Cells[0].Value.ToString() + ", " + 0 + ", " + Globals.IdUsername + ", '" + tipo_carrito + "', '" + row.Cells["CAJA"].Value.ToString() + "')";
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
                btActualizar_Click(sender, e);
                Conexion.cerrar();
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            btActualizar_Click(sender, e);
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog();
                btActualizar_Click(sender, e);
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            try
            {

                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                strSQL = "SELECT DISTINCT IH.NUMERO_CAJA AS CAJA, IH.FECHA_INICIO AS FECHA_SOLICITUD, OBSERVACION AS USUARIO FROM INVENTARIO_HISTORICO IH";
                strSQL += " LEFT JOIN TMP_CARRITO TC ON TC.NUMERO_CAJA = IH.NUMERO_CAJA";

                strSQL += " WHERE IH.ID_USUARIO_ENTREGA_FK = " + Globals.IdIM;
                strSQL += " AND IH.ANULADO = 0";
                strSQL += " AND IH.RECIBIDO = 0";
                strSQL += " AND IH.FECHA_FIN IS NULL";
                strSQL += " AND TC.ID_TMP_CARRITO IS NULL";

                strSQL += " ORDER BY FECHA_INICIO";

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
                dgv.Columns[1].Width = 400;
                dgv.Columns[2].Width = 200;
                dgv.ClearSelection();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }
    }

}

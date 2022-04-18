using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainEnviar : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strIronMountainEnviar;
        public IronMountainEnviar()
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
                IronMountainFunctions.EnviarCajasCarrito();
                btActualizar_Click(sender, e);
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {

                if (dgv.SelectedRows.Count == 1)
                {
                    if (GlobalFunctions.verificarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.IdUsername))
                    {
                        GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                        actualizarCantidad(cantidadcarrito + 1);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea enviar la caja de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                            actualizarCantidad(cantidadcarrito + 1);
                        }
                        else
                        {
                            Globals.strnumeroCAJA = dgv.SelectedRows[0].Cells["CAJA"].Value.ToString();
                            CarritoForm vCarrito = new CarritoForm();
                            vCarrito.ShowDialog();
                        }
                    }
                    btActualizar_Click(sender, e);
                }
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgv, Globals.ExportarPath + tipo_carrito + Globals.Username + "_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".csv");
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
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, DEP.NOMBRE_DEPARTAMENTO AS DEPART, DOC.NOMBRE_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, LE.NOMBRE_ESTADO AS CUSTODIADO, U.NOMBRE_USUARIO AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                strSQL += " FROM (((((INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA)";
                strSQL += " LEFT JOIN LDEPARTAMENTO DEP ON IG.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO)";
                strSQL += " LEFT JOIN LDOCUMENTO DOC ON IG.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO)";
                strSQL += " LEFT JOIN USUARIO U ON U.ID_USUARIO = IG.ID_USUARIO_POSEE)";
                strSQL += " LEFT JOIN LESTADO LE ON LE.ID_ESTADO = IG.ID_ESTADO_FK)";
                strSQL += " WHERE IG.NUMERO_DE_CAJA <> '' AND IG.ID_USUARIO_POSEE = " + Globals.IdUsername + "";
                strSQL += " AND NUMERO_DE_CAJA NOT IN (SELECT NUMERO_CAJA FROM INVENTARIO_HISTORICO WHERE RECIBIDO = 0 AND ID_USUARIO_RECIBE_FK = " + Globals.IdIM + ")";
                strSQL += " AND TC.NUMERO_CAJA IS NULL";
                strSQL += " ORDER BY DOC.NOMBRE_DOCUMENTO";

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
                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

    }
}

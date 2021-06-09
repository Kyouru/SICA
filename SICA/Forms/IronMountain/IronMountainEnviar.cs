using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainEnviar : Form
    {
        public IronMountainEnviar()
        {
            InitializeComponent();
            actualizarCantidad();
        }
        private void actualizarCajas ()
        {
            string strSQL = "";
            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA WHERE IG.NUMERO_DE_CAJA <> '' AND IG.USUARIO_POSEE = '" + Globals.Username + "'";
                strSQL = strSQL + " AND TC.NUMERO_CAJA IS NULL";
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

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                IronMountainFunctions.EnviarCajasCarrito();
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEnviar) + ")";
                actualizarCajas();
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (GlobalFunctions.verificarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.Username))
                {
                    GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainEnviar);
                    actualizarCantidad();
                    actualizarCajas();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea enviar la caja de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                    if (dialogResult != DialogResult.Yes)
                    {
                        GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainEnviar);
                        actualizarCantidad();
                        actualizarCajas();
                    }
                    else
                    {
                        Globals.CarritoSeleccionado = Globals.strVerificarCAJA;
                        Globals.strnumeroCAJA = dgv.SelectedRows[0].Cells["CAJA"].Value.ToString();
                        CarritoForm vCarrito = new CarritoForm();
                        vCarrito.Show();
                    }
                }
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEnviar) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, Globals.CargoPath + Globals.strIronMountainEnviar + Globals.Username + "_" + DateTime.Now.ToString("yyyymmddhhmmss") + ".csv");
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strIronMountainEnviar);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainEnviar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            actualizarCajas();
        }

    }
}

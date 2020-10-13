using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Boveda
{
    public partial class BovedaGuardarCaja : Form
    {
        public BovedaGuardarCaja()
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

                DataTable dt = new DataTable("BOVEDA");

                strSQL = "SELECT DISTINCT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON TC.NUMERO_CAJA = IG.NUMERO_DE_CAJA";
                strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = '" + Globals.Username + "' AND NUMERO_DE_CAJA <> ''";

                if (tbCaja.Text != "")
                {
                    strSQL = strSQL + " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
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
        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE BOVEDA > 0";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {

                    BovedaFunctions.GuardarCajaCarrito();
                    actualizarCantidad();

                    btBuscar_Click(sender, e);
                }
            }
        }

        private void tbCaja_KeyDown(object sender, KeyEventArgs e)
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
                if (dgv.SelectedRows.Count == 1)
                {
                    if (GlobalFunctions.verificarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.Username))
                    {
                        GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strBovedaGuardarCAJA);
                        actualizarCantidad();
                        btBuscar_Click(sender, e);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea guardarlo de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                        if (dialogResult != DialogResult.Yes)
                        {
                            GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strBovedaGuardarCAJA);
                            actualizarCantidad();
                            btBuscar_Click(sender, e);
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
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaGuardarCAJA) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strBovedaGuardarCAJA);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strBovedaGuardarCAJA;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }
    }
}

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
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strBovedaGuardarCAJA;
        public BovedaGuardarCaja()
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

                DataTable dt = new DataTable("BOVEDA");

                strSQL = "SELECT DISTINCT NUMERO_DE_CAJA AS CAJA, DEP.NOMBRE_DEPARTAMENTO AS DEPART";
                strSQL += " FROM (((INVENTARIO_GENERAL IG LEFT JOIN (SELECT * FROM TMP_CARRITO WHERE TIPO = '" + tipo_carrito + "') TC ON TC.NUMERO_CAJA = IG.NUMERO_DE_CAJA)";
                strSQL += " LEFT JOIN LDEPARTAMENTO DEP ON IG.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO)";
                strSQL += " LEFT JOIN LDOCUMENTO DOC ON IG.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO)";
                strSQL += " WHERE TC.ID_TMP_CARRITO IS NULL AND IG.ID_USUARIO_POSEE = " + Globals.IdUsername + " AND NUMERO_DE_CAJA <> ''";

                if (tbCaja.Text != "")
                {
                    strSQL += " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
                }
                //strSQL += " ORDER BY NUMERO_DE_CAJA";

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
                //dgv.Columns[0].Visible = false;
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
                Globals.strQueryArea = " AND ID_AREA = " + Globals.IdAreaBoveda;
                
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    BovedaFunctions.GuardarCajaCarrito();
                    actualizarCantidad(0);
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
                /*
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    if (GlobalFunctions.verificarCaja(row.Cells["CAJA"].Value.ToString(), Globals.Username))
                    {
                        GlobalFunctions.AgregarCarrito("0", "0", row.Cells["CAJA"].Value.ToString(), tipo_carrito);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Hay documentos la caja " + row.Cells["CAJA"].Value.ToString()  + " que lo posee otro usuario\nDesea guardarlo de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalFunctions.AgregarCarrito("0", "0", row.Cells["CAJA"].Value.ToString(), tipo_carrito);
                        }
                    }
                }
                btBuscar_Click(sender, e);
                */
                
                if (dgv.SelectedRows.Count == 1)
                {
                    if (GlobalFunctions.verificarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.IdUsername))
                    {
                        GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                        btBuscar_Click(sender, e);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea guardarlo de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                            btBuscar_Click(sender, e);
                        }
                        else
                        {
                            Globals.strnumeroCAJA = dgv.SelectedRows[0].Cells["CAJA"].Value.ToString();
                            CarritoForm vCarrito = new CarritoForm();
                            vCarrito.ShowDialog();
                        }
                    }
                }
                
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

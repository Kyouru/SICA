using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.DocuClass
{
    public partial class DocuClassEntregar : Form
    {
        public DocuClassEntregar()
        {
            InitializeComponent();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            LoadingScreen.iniciarLoading();
            strSQL = @"SELECT DISTINCT NUMERO_DE_CAJA, CAJA_CLIENTE, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO FROM INVENTARIO_GENERAL IG 
                        LEFT JOIN TMP_CARRITO TC ON TC.NUMERO_CAJA = IG.NUMERO_DE_CAJA
                        WHERE TC.ID_TMP_CARRITO IS NULL AND USUARIO_POSEE = '" + Globals.Username + "' AND NUMERO_DE_CAJA <> ''";
            if (tbBusquedaLibre.Text != "")
            {
                strSQL = strSQL + " AND NUMERO_DE_CAJA LIKE @busqueda_libre";
            }
            strSQL = strSQL + " ORDER BY NUMERO_DE_CAJA";
            try
            {
                DataTable dt = new DataTable();

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
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
                DocuClassFunctions.EntregarCarrito();
                actualizarCantidad();
                btBuscar_Click(sender, e);
            }
        }

        private void cbDesembolsado_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCantidad();
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strDocuClassEntregar) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strDocuClassEntregar);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strDocuClassEntregar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    if (GlobalFunctions.verificarCaja(dgv.SelectedRows[0].Cells["NUMERO_DE_CAJA"].Value.ToString(),Globals.Username))
                    {
                        GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells["NUMERO_DE_CAJA"].Value.ToString(), Globals.strDocuClassEntregar);
                        actualizarCantidad();
                        btBuscar_Click(sender, e);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea guardarlo de todas manera?", "Incompleto", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells["NUMERO_DE_CAJA"].Value.ToString(), Globals.strDocuClassEntregar);
                            actualizarCantidad();
                            btBuscar_Click(sender, e);
                        }
                        else
                        {
                            Globals.CarritoSeleccionado = Globals.strVerificarCAJA;
                            Globals.strnumeroCAJA = dgv.SelectedRows[0].Cells["NUMERO_DE_CAJA"].Value.ToString();
                            CarritoForm vCarrito = new CarritoForm();
                            vCarrito.Show();
                        }
                    }   
                }
            }
        }
        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }
    }
}

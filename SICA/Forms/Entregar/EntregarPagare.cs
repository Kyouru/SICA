
using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Entregar
{
    public partial class EntregarPagare : Form
    {

        public EntregarPagare()
        {
            InitializeComponent();
            actualizarCantidad();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            LoadingScreen.iniciarLoading();
            if (cbDesembolsado.Checked)
            {
                strSQL = @"SELECT ID_REPORTE_VALORADOS AS ID, CIP, NOMBRE, MONTOPRESTAMO AS MONTO, SOLICITUD_SISGO AS SISGO, SIP, TIPO_PRESTAMO AS TIPO
                            , FORMAT(FECHA_OTORGADO, 'dd/MM/yyyy') AS OTORGADO, FORMAT(FECHA_CANCELACION, 'dd/MM/yyyy') AS CANCELACION, PAGARE
                            FROM REPORTE_VALORADOS RV LEFT JOIN TMP_CARRITO TC ON TC.ID_AUX_FK = RV.ID_REPORTE_VALORADOS
                            WHERE TC.ID_TMP_CARRITO IS NULL AND PAGARE = 'CUSTODIADO'";
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND CONCATENADO LIKE @busqueda_libre";
                }
                strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
            }
            else
            {
                strSQL = @"SELECT ID_PAGARE_SIN_DESEMBOLSAR AS ID, SOLICITUD_SISGO AS SISGO, DESCRIPCION_1, DESCRIPCION_2, SDESCRIPCION_3, DESCRIPCION_4
                            FROM PAGARE_SIN_DESEMBOLSAR PSD LEFT JOIN TMP_CARRITO TC ON TC.ID_AUX_FK = PSD.ID_PAGARE_SIN_DESEMBOLSAR
                            WHERE TC.ID_TMP_CARRITO IS NULL AND PAGARE = 'CUSTODIADO'";
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND CONCATENADO LIKE @busqueda_libre";
                }
                strSQL = strSQL + " AND DESEMBOLSADO = 0 ";
                strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
            }

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
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL = TRUE";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");

                    if (cbDesembolsado.Checked)
                    {
                        EntregarFunctions.EntregarPagaresCarrito(1, observacion);
                    }
                    else
                    {
                        EntregarFunctions.EntregarPagaresCarrito(0, observacion);
                    }

                    actualizarCantidad();
                    btBuscar_Click(sender, e);
                }
            }
        }

        private void cbDesembolsado_CheckedChanged(object sender, EventArgs e)
        {
            actualizarCantidad();
        }

        private void actualizarCantidad()
        {
            if (cbDesembolsado.Checked)
            {
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagare) + ")";
            }
            else
            {
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarPagareSinDesembolsar) + ")";
            }
        }
        
        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }
        
        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            if (cbDesembolsado.Checked)
            {
                GlobalFunctions.LimpiarCarrito(Globals.strEntregarPagare);
            }
            else
            {
                GlobalFunctions.LimpiarCarrito(Globals.strEntregarPagareSinDesembolsar);
            }
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strEntregarPagare;
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
                    if (cbDesembolsado.Checked)
                    {
                        GlobalFunctions.AgregarCarrito("0", dgv.SelectedRows[0].Cells[0].Value.ToString(), "", Globals.strEntregarPagare);
                    }
                    else
                    {
                        GlobalFunctions.AgregarCarrito("0", dgv.SelectedRows[0].Cells[0].Value.ToString(), "", Globals.strEntregarPagareSinDesembolsar);
                    }
                    actualizarCantidad();
                    //btBuscar_Click(sender, e);
                    dgv.SelectedRows[0].Height = 0;
                }
            }
        }

    }
}

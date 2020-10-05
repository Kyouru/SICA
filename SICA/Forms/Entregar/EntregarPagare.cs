using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("REPORTE_VALORADOS");
                sqliteConnection.Open();
                if (cbDesembolsado.Checked)
                {
                    strSQL = "SELECT ID_REPORTE_VALORADOS AS ID, CIP, NOMBRE, MONTOPRESTAMO AS MONTO, SOLICITUD_SISGO AS SISGO, SIP, TIPO_PRESTAMO AS TIPO, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS CANCELACION, PAGARE ";
                    strSQL = strSQL + ", CIP || ';' || NOMBRE || ';' || SOLICITUD_SISGO AS CONCATENADO";
                    strSQL = strSQL + " FROM REPORTE_VALORADOS RV LEFT JOIN TMP_CARRITO TC ON TC.ID_REPORTE_VALORADOS_FK = RV.ID_REPORTE_VALORADOS";
                    strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND PAGARE = 'CUSTODIADO'";
                    if (tbBusquedaLibre.Text != "")
                    {
                        strSQL = strSQL + " AND CONCATENADO LIKE '%" + tbBusquedaLibre.Text + "%'";
                    }
                    strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
                }
                else
                {
                    strSQL = "SELECT ID_PAGARE_SIN_DESEMBOLSAR AS ID, SOLICITUD_SISGO AS SISGO, DESCRIPCION_1, DESCRIPCION_2, SDESCRIPCION_3, DESCRIPCION_4";
                    strSQL = strSQL + "FROM PAGARE_SIN_DESEMBOLSAR PSD LEFT JOIN TMP_CARRITO TC ON TC.ID_REPORTE_VALORADOS_FK = PSD.ID_PAGARE_SIN_DESEMBOLSAR";
                    strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND PAGARE = 'CUSTODIADO'";
                    if (tbBusquedaLibre.Text != "")
                    {
                        strSQL = strSQL + " AND CONCATENADO LIKE '%" + tbBusquedaLibre.Text + "%'";
                    }
                    strSQL = strSQL + " AND DESEMBOLSADO = 0 ";
                    strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
                }
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    Thread t = new Thread(new ThreadStart(StartLoadingScreen));
                    t.Start();

                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgv.DataSource = dt;
                    dgv.Columns[0].Width = 0;
                    t.Abort();
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btEntregar_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {

                    if (cbDesembolsado.Checked)
                    {
                        EntregarFunctions.EntregarPagaresCarrito(1);
                    }
                    else
                    {
                        EntregarFunctions.EntregarPagaresCarrito(0);
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
            GlobalFunctions.ExportarDataGridViewExcel(dgv, "", 1, 1, true);
        }
        
        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            if (cbDesembolsado.Checked)
            {
                lbCantidad.Text = "(" + GlobalFunctions.LimpiarCarrito(Globals.strEntregarPagare) + ")";
            }
            else
            {
                lbCantidad.Text = "(" + GlobalFunctions.LimpiarCarrito(Globals.strEntregarPagareSinDesembolsar) + ")";
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
                    btBuscar_Click(sender, e);
                }
            }
        }

        public static void StartLoadingScreen()
        {
            try
            {
                Application.Run(new LoadingScreen());
            }
            catch
            {

            }
        }
    }
}

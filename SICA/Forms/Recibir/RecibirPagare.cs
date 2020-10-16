using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Recibir
{
    public partial class RecibirPagare : Form
    {
        public RecibirPagare()
        {
            InitializeComponent();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            LoadingScreen.iniciarLoading();

            string strSQL = "";
            try
            {
                DataTable dt = new DataTable("REPORTE_VALORADOS");

                strSQL = "SELECT ID_REPORTE_VALORADOS AS ID, CIP, NOMBRE, MONTOPRESTAMO AS MONTO, SOLICITUD_SISGO AS SISGO, SIP, TIPO_PRESTAMO AS TIPO, FORMAT(FECHA_OTORGADO, 'dd/MM/yyyy') AS OTORGADO, FORMAT(FECHA_CANCELACION, 'dd/MM/yyyy') AS CANCELACION, PAGARE ";
                strSQL = strSQL + " FROM REPORTE_VALORADOS";
                strSQL = strSQL + " WHERE (PAGARE = 'NO CUSTODIADO' OR PAGARE = 'PRESTADO' OR PAGARE = 'DEVUELTO' OR PAGARE = 'PROTESTO' OR PAGARE IS NULL)";
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND SOLICITUD_SISGO LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
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

        private void btRecibir_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL = TRUE";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    RecibirFunctions.RecibirPagare(dgv.SelectedRows[0].Cells["ID"].Value.ToString(), observacion);
                    //btBuscar_Click(sender, e);
                    dgv.SelectedRows[0].Height = 0;
                }
            }
        }


        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    btRecibir_Click(sender, e);
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

    }
}

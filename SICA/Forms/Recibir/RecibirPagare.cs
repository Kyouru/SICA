using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("REPORTE_VALORADOS");
                sqliteConnection.Open();

                strSQL = "SELECT ID_REPORTE_VALORADOS AS ID, CIP, NOMBRE, MONTOPRESTAMO AS MONTO, SOLICITUD_SISGO AS SISGO, SIP, TIPO_PRESTAMO AS TIPO, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS CANCELACION, PAGARE ";
                strSQL = strSQL + " FROM REPORTE_VALORADOS";
                strSQL = strSQL + " WHERE (PAGARE = 'NO CUSTODIADO' OR PAGARE = 'PRESTADO' OR PAGARE = 'PROTESTO' OR PAGARE IS NULL)";
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND SOLICITUD_SISGO LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY FECHA_OTORGADO";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgv.DataSource = dt;
                    dgv.Columns[0].Visible = false;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btRecibir_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL = 1";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    RecibirFunctions.RecibirPagare(dgv.SelectedRows[0].Cells["ID"].Value.ToString());
                    dgv.SelectedRows[0].Height = 0;
                    //btBuscarPagare_Click(sender, e);
                }
            }
        }


        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btRecibir_Click(sender, e);
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
            GlobalFunctions.ExportarDataGridViewExcel(dgv, "", 1, 1, true);
        }

    }
}

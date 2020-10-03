using Microsoft.VisualBasic;
using SICA.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    public partial class BusquedaForm : Form
    {
        public BusquedaForm()
        {
            InitializeComponent();

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void BusquedaForm_Load(object sender, EventArgs e)
        {
            //dtpFecha.Value = DateTime.Now;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA FROM INVENTARIO_GENERAL WHERE 1 = 1";
                    
                if (cbFecha.Checked)
                {
                    string fecha = DateTime.ParseExact(tbFecha.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-mm-dd");
                    strSQL = strSQL + " AND FECHA_DESDE <= '" + fecha + "' AND FECHA_HASTA >= '" + fecha + "'";
                }
                if (cbCaja.Checked)
                {
                    strSQL = strSQL + " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
                }
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";

                //MessageBox.Show(strSQL);
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                Thread t = new Thread(new ThreadStart(StartLoadingScreen));
                try
                {
                    t.Start();

                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();


                    dgvBusqueda.DataSource = dt;
                    dgvBusqueda.Columns[0].Width = 0;
                    dgvBusqueda.Columns["DESC 1"].Width = 250;

                    if (t.ThreadState == ThreadState.Running)
                    {
                        t.Abort();
                    }

                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    if (t.ThreadState == ThreadState.Running)
                    {
                        t.Abort();
                    }
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                tbFecha.Enabled = true;
                tbFecha.Focus();
            }
            else
            {
                tbFecha.Enabled = false;
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void cbCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCaja.Checked)
            {
                tbCaja.Enabled = true;
                tbCaja.Focus();
            }
            else
            {
                tbCaja.Enabled = false;
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgvBusqueda, "", 1, 1, true);
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

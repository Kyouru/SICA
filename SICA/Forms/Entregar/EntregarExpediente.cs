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

namespace SICA.Forms.Entregar
{
    public partial class EntregarExpediente : Form
    {
        public EntregarExpediente()
        {
            InitializeComponent();
        }
        private void btBuscarEXP_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA ";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL ";
                strSQL = strSQL + " AND DESCRIPCION_1 = 'EXPEDIENTES DE CREDITO' AND USUARIO_POSEE = '" + Globals.Username + "'";

                if (tbBusquedaLibreEXP.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibreEXP.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY DESCRIPCION_2";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvExpedientes.DataSource = dt;
                    dgvExpedientes.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void tbBusquedaLibreEXP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscarEXP_Click(sender, e);
            }
        }

        private void dgvExpedientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExpedientes.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgvExpedientes.SelectedRows[0].Cells[0].Value.ToString(), "0", dgvExpedientes.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strEntregarExpediente);
                lbCantidadEXP.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarExpediente) + ")";
                btBuscarEXP_Click(sender, e);
            }
        }

        private void btEntregarEXP_Click(object sender, EventArgs e)
        {
            if (lbCantidadEXP.Text != "(0)")
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    EntregarFunctions.EntregarExpedientesCarrito();
                    lbCantidadEXP.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarExpediente) + ")";

                    btBuscarEXP_Click(sender, e);
                }
            }
        }

        private void btVerCarritoEXP_Click(object sender, EventArgs e)
        {
            if (lbCantidadEXP.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strEntregarExpediente;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void tbBusquedaLibreEXP_TextChanged(object sender, EventArgs e)
        {
            lbCantidadEXP.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strEntregarExpediente) + ")";
        }

        private void btExcelEXP_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgvExpedientes, "", 1, 1, true);
        }
    
    
    }
}

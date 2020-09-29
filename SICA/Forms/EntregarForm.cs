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

namespace SICA.Forms
{
    public partial class EntregarForm : Form
    {
        public EntregarForm()
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

                dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
                dt.Columns.Add("CAJA", System.Type.GetType("System.String"));
                dt.Columns.Add("DEPART", System.Type.GetType("System.String"));
                dt.Columns.Add("DOC", System.Type.GetType("System.String"));
                dt.Columns.Add("DESDE", System.Type.GetType("System.String"));
                dt.Columns.Add("HASTA", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 1", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 2", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 3", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 4", System.Type.GetType("System.String"));
                dt.Columns.Add("CUSTODIADO", System.Type.GetType("System.String"));
                dt.Columns.Add("POSEE", System.Type.GetType("System.String"));
                dt.Columns.Add("FECHA", System.Type.GetType("System.String"));

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA FROM INVENTARIO_GENERAL WHERE DESCRIPCION_1 = 'EXPEDIENTES DE CREDITO' AND USUARIO_POSEE = '" + Globals.Username + "'";

                if (tbBusquedaLibreEXP.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibreEXP.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY DESCRIPCION_2";

                //MessageBox.Show(strSQL);
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

        private void btEntregarEXP_Click(object sender, EventArgs e)
        {
            if (dgvExpedientes.Rows.Count > 0)
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    DataTable dt = new DataTable("CARGO");
                    using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        SQLiteCommand sqliteCmd;
                        sqliteConnection.Open();
                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                        try
                        {

                            int i = 0;

                            int desc_1 = 6;
                            int desc_2 = 7;
                            int desc_3 = 8;
                            int desc_4 = 9;

                            dt.Columns.Add("#", System.Type.GetType("System.Int32"));
                            dt.Columns.Add("DEFINICION", System.Type.GetType("System.String"));
                            dt.Columns.Add("SOLICITUD", System.Type.GetType("System.String"));
                            dt.Columns.Add("COD. PRESTAMO", System.Type.GetType("System.String"));
                            dt.Columns.Add("NOMBRE SOCIO", System.Type.GetType("System.String"));

                            foreach (DataGridViewRow row in dgvExpedientes.SelectedRows)
                            {
                                dt.Rows.Add();
                                dt.Rows[i][0] = i + 1;
                                dt.Rows[i][1] = row.Cells[desc_1].Value.ToString();
                                dt.Rows[i][2] = row.Cells[desc_2].Value.ToString();
                                dt.Rows[i][3] = row.Cells[desc_3].Value.ToString();
                                dt.Rows[i][4] = row.Cells[desc_4].Value.ToString();
                                row.Height = 0;
                                i++;

                                sqliteCmd = new SQLiteCommand("UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'PRESTADO', USUARIO_POSEE = '" + Globals.UsernameSelect + "', FECHA_POSEE = '" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "' WHERE ID_INVENTARIO_GENERAL = " + row.Cells[0].Value.ToString(), sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();

                                sqliteCmd = new SQLiteCommand("INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO) VALUES (" + row.Cells[0].Value.ToString() + ", " + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();

                            }

                            sqliteTransaction.Commit();
                            sqliteConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }

                    GlobalFunctions.ArmarCargoExcel(dt, Globals.CargoPath + "CARGO_EXP_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);
                }
                
            }
        }

        private void btBuscarDOC_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                dt.Columns.Add("ID", System.Type.GetType("System.Int32"));
                dt.Columns.Add("CAJA", System.Type.GetType("System.String"));
                dt.Columns.Add("DEPART", System.Type.GetType("System.String"));
                dt.Columns.Add("DOC", System.Type.GetType("System.String"));
                dt.Columns.Add("DESDE", System.Type.GetType("System.String"));
                dt.Columns.Add("HASTA", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 1", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 2", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 3", System.Type.GetType("System.String"));
                dt.Columns.Add("DESC 4", System.Type.GetType("System.String"));
                dt.Columns.Add("CUSTODIADO", System.Type.GetType("System.String"));
                dt.Columns.Add("POSEE", System.Type.GetType("System.String"));
                dt.Columns.Add("FECHA", System.Type.GetType("System.String"));

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA FROM INVENTARIO_GENERAL WHERE DESCRIPCION_1 <> 'EXPEDIENTES DE CREDITO' AND USUARIO_POSEE = '" + Globals.Username + "'";

                if (tbBusquedaLibreDOC.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibreDOC.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY DESCRIPCION_2";

                //MessageBox.Show(strSQL);
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvDocumentos.DataSource = dt;
                    dgvDocumentos.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btEntregarDOC_Click(object sender, EventArgs e)
        {
            if (dgvDocumentos.Rows.Count > 0)
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.Show();
                if (Globals.IdUsernameSelect > 0)
                {
                    DataTable dt = new DataTable("CARGO");
                    using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        SQLiteCommand sqliteCmd;
                        sqliteConnection.Open();
                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                        try
                        {
                            int i = 0;

                            int desc_1 = 6;
                            int desc_2 = 7;
                            int desc_3 = 8;
                            int desc_4 = 9;

                            dt.Columns.Add("#", System.Type.GetType("System.Int32"));
                            dt.Columns.Add("DESCRIPCION 1", System.Type.GetType("System.String"));
                            dt.Columns.Add("DESCRIPCION 2", System.Type.GetType("System.String"));
                            dt.Columns.Add("DESCRIPCION 3", System.Type.GetType("System.String"));
                            dt.Columns.Add("DESCRIPCION 4", System.Type.GetType("System.String"));

                            foreach (DataGridViewRow row in dgvDocumentos.SelectedRows)
                            {
                                dt.Rows.Add();
                                dt.Rows[i][0] = i + 1;
                                dt.Rows[i][1] = row.Cells[desc_1].Value.ToString();
                                dt.Rows[i][2] = row.Cells[desc_2].Value.ToString();
                                dt.Rows[i][3] = row.Cells[desc_3].Value.ToString();
                                dt.Rows[i][4] = row.Cells[desc_4].Value.ToString();
                                i++;

                                sqliteCmd = new SQLiteCommand("UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'PRESTADO', USUARIO_POSEE = '" + Globals.UsernameSelect + "', FECHA_POSEE = '" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "' WHERE ID_INVENTARIO_GENERAL = " + row.Cells[0].Value.ToString(), sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();

                                sqliteCmd = new SQLiteCommand("INSERT INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN) VALUES (" + row.Cells[0].Value.ToString() + ", " + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();

                            }
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message);
                        }
                        sqliteTransaction.Commit();
                        sqliteConnection.Close();
                    }

                    GlobalFunctions.ArmarCargoExcel(dt, Globals.CargoPath + "CARGO_EXP_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);
                }
            }
        }
    }
}

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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    public partial class RecibirForm : Form
    {
        public RecibirForm()
        {
            InitializeComponent();
        }

        private void btBuscarCargo_Click(object sender, EventArgs e)
        {
            Boolean valido = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro de Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string strSQL;
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                SQLiteCommand sqliteCmd;
                SQLiteDataAdapter sqliteDataAdapter;
                try
                {
                    dt = GlobalFunctions.ConvertExcelToDataTable(ofd.FileName, 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                dgvCargo.DataSource = dt;
                dt.Columns.Add("STATUS");
                dt.Columns.Add("ID REPORTE");
                foreach (DataGridViewRow row in dgvCargo.Rows)
                {
                    if (row.Cells["CODIGO DEPARTAMENTO"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Codigo Departamento Vacío;";
                    }
                    if (row.Cells["CODIGO DOCUMENTO"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Codigo Documento Vacío;";
                    }
                    if (row.Cells["FECHA DESDE"].Value.ToString() != "" && !GlobalFunctions.IsDate(row.Cells["FECHA DESDE"].Value.ToString()))
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Fecha Desde Invalida;";
                    }
                    if (row.Cells["FECHA HASTA"].Value.ToString() != "" && !GlobalFunctions.IsDate(row.Cells["FECHA HASTA"].Value.ToString()))
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Fecha Hasta Invalida;";
                    }
                    if (row.Cells["DESCRIPCION 1"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Descripcion 1 Vacío;";
                    }
                    if (row.Cells["DESCRIPCION 2"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Descripcion 2 Vacío;";
                    }
                    if (row.Cells["QUIEN ENTREGA"].Value.ToString() == "")
                    {
                        valido = false;
                        row.Cells["STATUS"].Value = row.Cells["STATUS"].Value + "Quien Entrega Vacío;";
                    }
                    if (row.Cells["STATUS"].Value.ToString() == "" && row.Cells["DESCRIPCION 2"].Value.ToString() != "")
                    {
                        using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                        {
                            try
                            {
                                dt2 = new DataTable();
                                sqliteConnection.Open();
                                strSQL = "SELECT ID_USUARIO FROM USUARIO WHERE USERNAME = '" + row.Cells["QUIEN ENTREGA"].Value.ToString() + "'";
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                                sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                                sqliteDataAdapter.Fill(dt2);


                                strSQL = "SELECT ID_REPORTE_VALORADOS FROM REPORTE_VALORADOS WHERE SOLICITUD_SISGO = '" + row.Cells["DESCRIPCION 2"].Value.ToString().Replace("'", "''") + "'";
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                                sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                                sqliteDataAdapter.Fill(dt3);
                                sqliteConnection.Close();
                            }
                            catch (Exception ex)
                            {
                                sqliteConnection.Close();
                                MessageBox.Show(ex.Message);
                                return;
                            }
                        }
                        if (dt2.Rows.Count > 0)
                        {
                            Globals.IdUsernameSelect = Int32.Parse(dt2.Rows[0][0].ToString());
                        }
                        else
                        {
                            row.Cells["STATUS"].Value = "Quien Entrega No existe;";
                        }
                        
                        if (dt3.Rows.Count == 1)
                        {
                            row.Cells["ID REPORTE"].Value = dt3.Rows[0][0].ToString();
                            row.Cells["STATUS"].Value = row.Cells["STATUS"].Value.ToString() + "OK, Desembolsado";
                        }
                        else if (dt3.Rows.Count == 0)
                        {
                            row.Cells["STATUS"].Value = row.Cells["STATUS"].Value.ToString() + "OK, SIN desembolsar";
                        }
                        else if (dt3.Rows.Count > 1)
                        {
                            row.Cells["ID REPORTE"].Value = dt3.Rows[0][0].ToString();
                            row.Cells["STATUS"].Value = row.Cells["STATUS"].Value.ToString() + "OK, Desembolsado";
                        }
                    }
                }
            }
            if (valido)
            {
                btCargarValido.Visible = true; 
            }
        }

        private void btCargarValido_Click(object sender, EventArgs e)
        {
            SQLiteCommand sqliteCmd;
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                Boolean pagare;
                Boolean expediente;
                try
                {
                    sqliteConnection.Open();
                    SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                    foreach (DataGridViewRow row in dgvCargo.Rows)
                    {
                        if (row.Cells["PAGARE"].Value.ToString() == "SI")
                        {
                            pagare = true;
                        }
                        else
                        {
                            pagare = false;
                        }
                        if (row.Cells["EXPEDIENTE"].Value.ToString() == "SI")
                        {
                            expediente = true;
                        }
                        else
                        {
                            expediente = false;
                        }

                        if (row.Cells["STATUS"].Value.ToString() == "OK, Desembolsado")
                        {
                            if (row.Cells["DESCRIPCION 1"].Value.ToString() == "EXPEDIENTES DE CREDITO" && expediente)
                            {
                                if (!GlobalFunctions.EstadoCustodiaReporte(row.Cells["DESCRIPCION 2"].Value.ToString(), expediente, pagare, sqliteConnection))
                                {
                                    sqliteConnection.Close();
                                    return;
                                }
                            }

                            sqliteCmd = new SQLiteCommand(ArmarStrCargo(row), sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();

                            sqliteCmd = new SQLiteCommand("INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_RECIBE) VALUES (" + sqliteConnection.LastInsertRowId + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", '" + DateTime.Now.ToString("yyyy-MM-ss HH:mm:ss") + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')", sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                        }
                        else if (row.Cells["STATUS"].Value.ToString() == "OK, SIN desembolsar")
                        {
                            sqliteCmd = new SQLiteCommand(ArmarStrCargo(row), sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();

                            sqliteCmd = new SQLiteCommand("INSERT INTO SIN_DESEMBOLSAR (SOLICITUD_SISGO, PAGARE, ID_INVENTARIO_GENERAL_FK) VALUES ('" + row.Cells["DESCRIPCION 2"].Value.ToString() + "', " + expediente + ", " + pagare + ", " + sqliteConnection.LastInsertRowId + ")", sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                        }
                    }
                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Proceso Finalizado");
                    dgvCargo.DataSource = null;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void btBuscarReingreso_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, ID_REPORTE_VALORADOS_FK AS 'ID REPORTE' FROM INVENTARIO_GENERAL WHERE (CUSTODIADO = 'PRESTADO' OR CUSTODIADO = 'DEVUELTO')";

                if (tbUsuario.Text != "")
                {
                    strSQL = strSQL + " AND USUARIO_POSEE LIKE '%" + tbUsuario.Text + "%'";
                }
                if (tbBusquedaLibre.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvReingreso.DataSource = dt;
                    dgvReingreso.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private string ArmarStrCargo (DataGridViewRow row)
        {
            string strSQL;
            strSQL = "INSERT INTO INVENTARIO_GENERAL (NUMERO_DE_CAJA, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, ID_REPORTE_VALORADOS_FK, DESC_CONCAT, FECHA_POSEE, USUARIO_POSEE)";
            strSQL = strSQL + "VALUES(";
            if (row.Cells["NUMERO DE CAJA IRON MOUNTAIN"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["NUMERO DE CAJA IRON MOUNTAIN"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["CODIGO DEPARTAMENTO"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["CODIGO DEPARTAMENTO"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["CODIGO DOCUMENTO"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["CODIGO DOCUMENTO"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["FECHA DESDE"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + DateTime.ParseExact(row.Cells["FECHA DESDE"].Value.ToString(), "DD/MM/YYYY", CultureInfo.InvariantCulture) +"', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["FECHA HASTA"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + DateTime.ParseExact(row.Cells["FECHA HASTA"].Value.ToString(), "DD/MM/YYYY", CultureInfo.InvariantCulture) + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESCRIPCION 1"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESCRIPCION 1"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESCRIPCION 2"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESCRIPCION 2"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESCRIPCION 3"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESCRIPCION 3"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESCRIPCION 4"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESCRIPCION 4"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }

            if (row.Cells["ID REPORTE"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["ID REPORTE"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }

            //DESC_CONCAT
            strSQL = strSQL + "'" + row.Cells["DESCRIPCION 1"].Value.ToString() + ";" + row.Cells["DESCRIPCION 2"].Value.ToString() + ";" + row.Cells["DESCRIPCION 3"].Value.ToString() + ";" + row.Cells["DESCRIPCION 4"].Value.ToString() + ";', ";
            strSQL = strSQL + "'" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "', ";
            strSQL = strSQL + "'" + Globals.Username + "')";
            return strSQL;

        }

        private void btRecibir_Click(object sender, EventArgs e)
        {
            if (dgvReingreso.SelectedRows.Count == 1)
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.Show();
                if (Globals.IdUsernameSelect > 0)
                {
                    string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                    using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        sqliteConnection.Open();
                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                        SQLiteCommand sqliteCmd;
                        string strSQL = "";
                        try
                        {
                            strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = '" + Globals.Username + "', FECHA_POSEE = '" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "' WHERE ID_INVENTARIO_GENERAL = " + dgvReingreso.SelectedRows[0].Cells["ID"].ToString();
                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();

                            strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION)
                                 VALUES (" + dgvReingreso.SelectedRows[0].Cells["ID"].ToString() + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", '" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "', '" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "', '" + observacion + "')";

                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();

                            if (dgvReingreso.SelectedRows[0].Cells["ID REPORTE"].ToString() != "" && dgvReingreso.SelectedRows[0].Cells["DESC 1"].ToString() == "EXPEDIENTES DE CREDITO")
                            {
                                strSQL = "UPDATE REPORTE_VALORADOS SET EXPEDIENTE = 'CUSTODIADO' WHERE ID_REPORTE_VALORADOS = " + dgvReingreso.SelectedRows[0].Cells["ID REPORTE"].ToString();
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message + "\n" + strSQL);
                            return;
                        }
                        sqliteTransaction.Commit();
                        sqliteConnection.Close();
                        dgvReingreso.SelectedRows[0].Height = 0;
                        MessageBox.Show("Registrado");
                    }
                }
            }
        }
        private void btBuscarPagare_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("REPORTE_VALORADOS");
                sqliteConnection.Open();

                strSQL = "SELECT ID_REPORTE_VALORADOS AS ID, CIP, NOMBRE, MONTOPRESTAMO AS MONTO, SOLICITUD_SISGO AS SISGO, SIP, TIPO_PRESTAMO AS TIPO, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS CANCELACION, PAGARE FROM REPORTE_VALORADOS WHERE 1 = 1";

                if (tbSolicitud.Text != "")
                {
                    strSQL = strSQL + " AND SOLICITUD_SISGO LIKE '%" + tbSolicitud.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY FECHA_OTORGADO";

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvPagare.DataSource = dt;
                    dgvPagare.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btRecibirPagare_Click(object sender, EventArgs e)
        {
            RecibirPagare();
        }

        private void RecibirPagare()
        {
            if (dgvPagare.SelectedRows.Count > 0)
            {
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        sqliteConnection.Open();
                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                        SQLiteCommand sqliteCmd;
                        string strSQL = "";
                        try
                        {
                            foreach (DataGridViewRow row in dgvPagare.SelectedRows)
                            {
                                strSQL = @"INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, FECHA)
                                 VALUES (" + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + row.Cells["ID"].Value.ToString() + ", '" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "')";

                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();

                                strSQL = "UPDATE REPORTE_VALORADOS SET PAGARE = 'CUSTODIADO' WHERE ID_REPORTE_VALORADOS = " + row.Cells["ID"].Value.ToString();
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message + "\n" + strSQL);
                            return;
                        }
                        sqliteTransaction.Commit();
                        sqliteConnection.Close();
                        dgvPagare.SelectedRows[0].Height = 0;
                        MessageBox.Show("Registrado");
                    }
                }
            }
        }

        private void btCargarLetras_Click(object sender, EventArgs e)
        {

        }
    }
}

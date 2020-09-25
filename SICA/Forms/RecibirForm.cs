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
                SQLiteCommand sqliteCmd;
                SQLiteDataAdapter sqliteDataAdapter;
                dt = GlobalFunctions.ConvertExcelToDataTable(ofd.FileName, 1);
                dgvCargo.DataSource = dt;
                dt.Columns.Add("STATUS");

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
                    if (row.Cells["STATUS"].Value.ToString() == "" && row.Cells["DESCRIPCION 1"].Value.ToString() == "EXPEDIENTES DE CREDITO" && row.Cells["DESCRIPCION 2"].Value.ToString() != "")
                    {
                        using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                        {
                            dt2 = new DataTable();
                            sqliteConnection.Open();
                            strSQL = "SELECT COUNT(*) FROM REPORTE_VALORADOS WHERE SOLICITUD_SISGO = '" + row.Cells["DESCRIPCION 2"].Value.ToString() + "'";
                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                            sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                            sqliteDataAdapter.Fill(dt2);
                            sqliteConnection.Close();
                        }
                        if (dt2.Rows[0][0].ToString() == "1")
                        {
                            row.Cells["STATUS"].Value = "OK";
                        }
                        else if (dt2.Rows[0][0].ToString() == "0")
                        {
                            row.Cells["STATUS"].Value = "OK, Credito sin desembolsar";
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
            string strSQL;
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                foreach (DataGridViewRow row in dgvCargo.Rows)
                {
                    if (row.Cells["STATUS"].Value.ToString() == "OK")
                    {
                        DataTable dt = new DataTable();
                        sqliteConnection.Open();
                        strSQL = @"INSERT INTO INVENTARIO_GENERAL (NUMERO_DE_CAJA, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESC_CONCAT, USUARIO_ENTREGA, FECHA_INGRESO, USUARIO_RECIBE, USUARIO_POSEE, CUSTODIADO)
                                        VALUES (";
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
                            strSQL = strSQL + "'" + row.Cells["FECHA DESDE"].Value.ToString() + "', ";
                        }
                        else
                        {
                            strSQL = strSQL + "NULL, ";
                        }
                        if (row.Cells["FECHA HASTA"].Value.ToString() != "")
                        {
                            strSQL = strSQL + "'" + row.Cells["FECHA HASTA"].Value.ToString() + "', ";
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

                        //DESC_CONCAT
                        strSQL = strSQL + "'" + row.Cells["DESCRIPCION 1"].Value.ToString() + ";" + row.Cells["DESCRIPCION 2"].Value.ToString() + ";" + row.Cells["DESCRIPCION 3"].Value.ToString() + ";" + row.Cells["DESCRIPCION 4"].Value.ToString() + ";', ";
                        strSQL = strSQL + "'" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:dd") + "', ";
                        strSQL = strSQL + "'" + row.Cells["QUIEN ENTREGA"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + Globals.Username + "', ";
                        strSQL = strSQL + "'" + Globals.Username + "', ";
                        strSQL = strSQL + "TRUE";

                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                    }
                    else if (row.Cells["STATUS"].Value.ToString() == "OK, Credito sin desembolsar")
                    {

                    }
                }
                sqliteTransaction.Commit();
                sqliteConnection.Close();
            } 
        }
    }
}

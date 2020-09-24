using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    public partial class ImportarForm : Form
    {
        public ImportarForm()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            btCargar.Enabled = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma-Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable("REPORTE_VALORADOS_VIGENTES");
                
                using (var csvConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=" + Path.GetDirectoryName(ofd.FileName) + ";Extended Properties=\"Text;HDR=Yes;FMT=Delimited;Format=Delimited(,)\""))
                {
                    csvConnection.Open();
                    using (var csvAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + Path.GetFileName(ofd.FileName), csvConnection))
                    {
                        dt.Columns.Add("CIP", System.Type.GetType("System.String"));
                        dt.Columns.Add("NOMBRE", System.Type.GetType("System.String"));
                        dt.Columns.Add("FECHAPROGRAMACION", System.Type.GetType("System.String"));
                        dt.Columns.Add("MONTOPRESTAMO", System.Type.GetType("System.Double"));
                        dt.Columns.Add("NUMERO_DOCUMENTO", System.Type.GetType("System.String"));
                        dt.Columns.Add("PERIODO_SOLICITUD", System.Type.GetType("System.String"));
                        dt.Columns.Add("NUMERO_SOLICITUD", System.Type.GetType("System.String"));
                        dt.Columns.Add("NUMERO_CUENTA", System.Type.GetType("System.String"));
                        dt.Columns.Add("MONEDA", System.Type.GetType("System.String"));
                        dt.Columns.Add("MONTO_PRESTAMO", System.Type.GetType("System.String"));
                        dt.Columns.Add("SECTORISTA", System.Type.GetType("System.String"));
                        dt.Columns.Add("FECHA_OTORGADO", System.Type.GetType("System.String"));
                        dt.Columns.Add("FECHA_CANCELACION", System.Type.GetType("System.String"));
                        dt.Columns.Add("PAGARE", System.Type.GetType("System.String"));
                        dt.Columns.Add("EXPEDIENTE", System.Type.GetType("System.String"));
                        dt.Columns.Add("FECHA_ENTREGA", System.Type.GetType("System.String"));
                        dt.Columns.Add("FECHA_DEVOLUCION", System.Type.GetType("System.String"));
                        dt.Columns.Add("TIPO_PRESTAMO", System.Type.GetType("System.String"));
                        dt.Columns.Add("USUARIO_REGISTRO", System.Type.GetType("System.String"));
                        dt.Columns.Add("OBSERVACION", System.Type.GetType("System.String"));
                        try
                        {
                            csvAdapter.Fill(dt);
                            csvConnection.Close();
                            dgvDesembolsado.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            csvConnection.Close();
                            MessageBox.Show(ex.Message + "\n" + ofd.FileName);
                            return;
                        }
                    }
                }

                using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    DataTable dt2 = new DataTable("REPORTE_VALORADOS");
                    sqliteConnection.Open();

                    dt2.Columns.Add("CIP", System.Type.GetType("System.String"));
                    dt2.Columns.Add("NOMBRE", System.Type.GetType("System.String"));
                    dt2.Columns.Add("MONTOPRESTAMO", System.Type.GetType("System.Double"));
                    dt2.Columns.Add("PERIODO_SOLICITUD", System.Type.GetType("System.String"));
                    dt2.Columns.Add("NUMERO_SOLICITUD", System.Type.GetType("System.String"));
                    dt2.Columns.Add("MONEDA", System.Type.GetType("System.String"));
                    dt2.Columns.Add("FECHA_OTORGADO", System.Type.GetType("System.String"));
                    dt2.Columns.Add("FECHA_CANCELACION", System.Type.GetType("System.String"));
                    dt2.Columns.Add("TIPO_PRESTAMO", System.Type.GetType("System.String"));

                    SQLiteCommand sqliteCmd = new SQLiteCommand("SELECT CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, FECHA_OTORGADO, FECHA_CANCELACION, TIPO_PRESTAMO FROM REPORTE_VALORADOS", sqliteConnection);

                    try
                    {
                        sqliteCmd.ExecuteNonQuery();
                        SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                        sqliteDataAdapter.Fill(dt2);
                        sqliteConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        sqliteConnection.Close();
                        MessageBox.Show(ex.Message + "\n" + ofd.FileName);
                        return;
                    }

                    var result = from c1 in dt.AsEnumerable() join c2 in dt2.AsEnumerable() on new { X1 = c1.Field<string>("PERIODO_SOLICITUD"), X2 = c1.Field<string>("NUMERO_SOLICITUD") } equals new { X1 = c2.Field<string>("PERIODO_SOLICITUD"), X2 = c2.Field<string>("NUMERO_SOLICITUD") } into j from c2 in j.DefaultIfEmpty() where c2 == null 
                                 select new {
                                     CIP = c1.Field<string>("CIP"),
                                     NOMBRE = c1.Field<string>("NOMBRE"),
                                     MONTOPRESTAMO = c1.Field<double>("MONTOPRESTAMO"),
                                     PERIODO_SOLICITUD = c1.Field<string>("PERIODO_SOLICITUD"),
                                     NUMERO_SOLICITUD = c1.Field<string>("NUMERO_SOLICITUD"),
                                     MONEDA = c1.Field<string>("MONEDA"),
                                     FECHA_OTORGADO = c1.Field<string>("FECHA_OTORGADO"),
                                     FECHA_CANCELACION = c1.Field<string>("FECHA_CANCELACION"),
                                     TIPO_PRESTAMO = c1.Field<string>("TIPO_PRESTAMO")
                                 };
                    dgvDesembolsado.DataSource = result.ToList();
                    btCargar.Enabled = true;
                }
            }
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                SQLiteCommand sqliteCmd;
                String strSQL;
                foreach (DataGridViewRow row in dgvDesembolsado.Rows)
                {
                    strSQL = "INSERT INTO REPORTE_VALORADOS (CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, FECHA_OTORGADO, FECHA_CANCELACION, TIPO_PRESTAMO) VALUES (";

                    try
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value is null)
                            {
                                strSQL = strSQL + "NULL, ";
                            }
                            else
                            {
                                strSQL = strSQL + "'" + cell.Value.ToString().Replace("'","''") + "', ";
                            }
                        }
                        strSQL = strSQL.Substring(0, strSQL.Length - 2) + ")";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        sqliteConnection.Close();
                        MessageBox.Show(ex.Message + "\n" + strSQL);
                        return;
                    }
                }
                sqliteTransaction.Commit();
                MessageBox.Show("Carga Exitosa");
                dgvDesembolsado.DataSource = null;
                sqliteConnection.Close();
            }

        }
        private void btExportar_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(dgvDesembolsado);
        }

        /// <summary>
        /// Método que exporta a un fichero Excel el contenido de un DataGridView
        /// </summary>
        /// <param name="grd">DataGridView que contiene los datos a exportar</param>
        private void ExportarDataGridViewExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Cabeceras
                for (int j = 0; j < grd.Columns.Count; j++)
                {
                    hoja_trabajo.Cells[1, j + 1] = "'" + grd.Columns[j].HeaderText.ToString();
                }
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 1; i < grd.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        if (grd.Rows[i].Cells[j].Value != null)
                        {
                            hoja_trabajo.Cells[i + 1, j + 1] = "'" + grd.Rows[i].Cells[j].Value.ToString();
                        }
                        
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
                MessageBox.Show("Proceso Finalizado");
            }
        }

    }
}

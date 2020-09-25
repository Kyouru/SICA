using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Globalization;

namespace SICA
{
    public class GlobalFunctions
    {

        public static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        public static DataTable ConvertCsvToDataTable(string FileName)
        {
            DataTable dt = new DataTable("TABLA1");

            using (var csvConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;" + "Data Source=" + Path.GetDirectoryName(FileName) + ";Extended Properties=\"Text;HDR=Yes;FMT=Delimited;Format=Delimited(,)\""))
            {
                csvConnection.Open();
                using (var csvAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + Path.GetFileName(FileName), csvConnection))
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
                    }
                    catch (Exception ex)
                    {
                        csvConnection.Close();
                        MessageBox.Show(ex.Message + "\n" + FileName);
                    }
                }
            }
            return dt;
        }

        public static DataTable ConvertExcelToDataTable(string FileName, int index)
        {
            Microsoft.Office.Interop.Excel.Application objXL = null;
            Microsoft.Office.Interop.Excel.Workbook objWB = null;
            objXL = new Microsoft.Office.Interop.Excel.Application();
            objWB = objXL.Workbooks.Open(FileName);
            Microsoft.Office.Interop.Excel.Worksheet objSHT = objWB.Worksheets[index];

            int rows = objSHT.UsedRange.Rows.Count;
            int cols = objSHT.UsedRange.Columns.Count;
            DataTable dt = new DataTable();
            int noofrow = 1;

            for (int c = 1; c <= cols; c++)
            {
                string colname = objSHT.Cells[1, c].Text;
                dt.Columns.Add(colname);
                noofrow = 2;
            }

            for (int r = noofrow; r <= rows; r++)
            {
                DataRow dr = dt.NewRow();
                for (int c = 1; c <= cols; c++)
                {
                    dr[c - 1] = objSHT.Cells[r, c].Text;
                }

                dt.Rows.Add(dr);
            }

            objWB.Close();
            objXL.Quit();
            return dt;
        }

        public static DataTable ConvertReporteValoradosToDataTable(string strSQL)
        {
            DataTable dt = new DataTable("REPORTE_VALORADOS");

            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                sqliteConnection.Open();

                dt.Columns.Add("ID_REPORTE_VALORADOS", System.Type.GetType("System.Int32"));
                dt.Columns.Add("CIP", System.Type.GetType("System.String"));
                dt.Columns.Add("NOMBRE", System.Type.GetType("System.String"));
                dt.Columns.Add("MONTOPRESTAMO", System.Type.GetType("System.Double"));
                dt.Columns.Add("PERIODO_SOLICITUD", System.Type.GetType("System.String"));
                dt.Columns.Add("NUMERO_SOLICITUD", System.Type.GetType("System.String"));
                dt.Columns.Add("MONEDA", System.Type.GetType("System.String"));
                dt.Columns.Add("FECHA_OTORGADO", System.Type.GetType("System.String"));
                dt.Columns.Add("FECHA_CANCELACION", System.Type.GetType("System.String"));
                dt.Columns.Add("TIPO_PRESTAMO", System.Type.GetType("System.String"));

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        /// Método que exporta a un fichero Excel el contenido de un DataGridView
        public void ExportarDataGridViewExcel(DataGridView grd, string fileName)
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
            libros_trabajo.SaveAs(fileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
            libros_trabajo.Close(true);
            aplicacion.Quit();
            MessageBox.Show("Proceso Finalizado");
        }
        public static bool IsDate(Object obj)
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = DateTime.Parse(strDate);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

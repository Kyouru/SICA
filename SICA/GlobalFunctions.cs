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
using Microsoft.Office.Core;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using SICA.Forms;
using System.Threading;

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

        public static void ExportarDataGridViewExcel(DataGridView dgv, string fileName, Int32 inicio_row, Int32 inicio_col, Boolean cabecera)
        {
            if (dgv.Rows.Count > 200)
            {
                DialogResult dialogResult = MessageBox.Show("Tabla tiene mas de 200 filas\nDesea Continuar", "Muchas Filas", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            Thread t = new Thread(new ThreadStart(StartLoadingScreen));
            t.Start();

            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libros_trabajo = aplicacion.Workbooks.Add();
            hoja_trabajo =
                (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

            //Cabeceras
            if (cabecera)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    hoja_trabajo.Cells[inicio_row, j + inicio_col] = "'" + dgv.Columns[j].Name;
                }
            }

            //Recorremos el DataTable rellenando la hoja de trabajo
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j] != null)
                    {
                        if (GlobalFunctions.IsDate(dgv.Rows[i].Cells[j].Value.ToString()))
                        {
                            try
                            {
                                hoja_trabajo.Cells[i + inicio_row + 1, j + inicio_col] = DateTime.Parse(dgv.Rows[i].Cells[j].Value.ToString()).ToString("yyyy-MM-dd");
                            }
                            catch
                            {
                                hoja_trabajo.Cells[i + inicio_row + 1, j + inicio_col] = "'" +dgv.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                        else
                        {
                            hoja_trabajo.Cells[i + inicio_row + 1, j + inicio_col] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
            }
            if (fileName != "")
            {
                libros_trabajo.SaveAs(fileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                aplicacion.Workbooks.Open(fileName);
            }
            else
            {
                aplicacion.Visible = true;
            }

            t.Abort();
            //libros_trabajo.Close(true);
            //aplicacion.Quit();
        }

        public static void ArmarCargoExcel(DataTable dt, string plantilla, string fileName, Int32 inicio_row, Int32 inicio_col, Boolean cabecera)
        {
            Thread t = new Thread(new ThreadStart(StartLoadingScreen));
            t.Start();

            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            aplicacion.Visible = true;
            libros_trabajo = aplicacion.Workbooks.Open(plantilla);
            hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

            //Cabeceras
            if (cabecera)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    hoja_trabajo.Cells[inicio_row, j + inicio_col] = "'" + dt.Columns[j].ColumnName;
                }
            }

            //Recorremos el DataTable rellenando la hoja de trabajo
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        if (GlobalFunctions.IsDate(dt.Rows[i][j].ToString()))
                        {
                            try
                            {
                                hoja_trabajo.Cells[i + inicio_row + 1, j + inicio_col] = DateTime.Parse(dt.Rows[i][j].ToString()).ToString("yyyy-MM-dd");
                            }
                            catch
                            {
                                hoja_trabajo.Cells[i + inicio_row + 1, j + inicio_col] = "'" + dt.Rows[i][j].ToString();
                            }
                        }
                        else
                        {
                            hoja_trabajo.Cells[i + inicio_row + 1, j + inicio_col] = dt.Rows[i][j].ToString();
                        }
                    }
                }
            }
            libros_trabajo.SaveAs(fileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);

            t.Abort();
            //aplicacion.Workbooks.Open(fileName);
            //libros_trabajo.Close(true);
            //aplicacion.Quit();
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

        public static bool EstadoCustodiaReporte(string sisgo, bool expediente, bool pagare, SQLiteConnection sqliteConnection)
        {
            SQLiteCommand sqliteCmd;
            string strSQL = "";
            try
            {
                strSQL = "UPDATE REPORTE_VALORADOS SET ";
                if (expediente)
                {
                    strSQL = strSQL + "EXPEDIENTE = 1 ";
                    if (pagare)
                    {
                        strSQL = strSQL + ", PAGARE = 1 ";
                    }
                }
                else if (pagare)
                {
                    strSQL = strSQL + "PAGARE = 1 ";
                }
                strSQL = strSQL + "WHERE SOLICITUD_SISGO = '" + sisgo + "'";
                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                sqliteCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
        }
        
        public static bool PrestarCustodiaReporteID(List<string> idlist)
        {
            string strSQL = "";
            try
            {
                using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    sqliteConnection.Open();
                    SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                    SQLiteCommand sqliteCmd;

                    foreach (string id in idlist)
                    {
                        strSQL = "UPDATE REPORTE_VALORADOS SET CUSTODIADO = 'PRESTADO'";
                        strSQL = strSQL + "WHERE ID_REPORTE_VALORADOS = '" + id + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
        }

        public static bool AgregarCarrito(string id_inventario, string id_reporte, string caja, string tipo)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    sqliteCmd = new SQLiteCommand("INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_REPORTE_VALORADOS_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (" + id_inventario + ", " + id_reporte + ", " + Globals.IdUsername +  ", '" + tipo + "', '" + caja + "')", sqliteConnection);
                    
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
        
        public static int CantidadCarrito(string tipo)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                int n;
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();

                try
                {
                    sqliteCmd = new SQLiteCommand("SELECT COUNT(*) FROM TMP_CARRITO WHERE TIPO = '" + tipo + "' AND ID_USUARIO_FK = " + Globals.IdUsername + "", sqliteConnection);
                    n = Convert.ToInt32(sqliteCmd.ExecuteScalar());
                    sqliteConnection.Close();
                    return n;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }
        }
                
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        
        public static string SinTildes(string texto)
        {
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            //Regex reg = new Regex("[^a-zA-Z0-9]");
            //return reg.Replace(textoNormalizado, "");
            return textoNormalizado;
        }

        public static bool LimpiarCarrito(string tipo)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + tipo + "'", sqliteConnection);

                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    
        public static bool actualizarNoDesembolsados()
        {
            string strSQL = "";
            try
            {
                using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    sqliteConnection.Open();

                    DataTable dt = new DataTable();

                    SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                    SQLiteCommand sqliteCmd;
                    SQLiteDataAdapter sqliteDataAdapter;

                    strSQL = "SELECT SOLICITUD_SISGO FROM EXPEDIENTE_SIN_DESEMBOLSAR ESD LEFT JOIN REPORTE_VALORADOS RV ON ESD.SOLICITUD_SISGO = RV.SOLICITUD_SISGO WHERE ESD.DESEMBOLSADO IS NULL AND RV.ID_REPORTE_VALORADOS IS NOT NULL";
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE REPORTE_VALORADOS SET EXPEDIENTE = 'CUSTODIADO'";
                        strSQL = strSQL + "WHERE SOLICITUD_SISGO = '" + row[0].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    dt = new DataTable();
                    strSQL = "SELECT SOLICITUD_SISGO FROM PAGARE_SIN_DESEMBOLSAR ESD LEFT JOIN REPORTE_VALORADOS RV ON PSD.SOLICITUD_SISGO = RV.SOLICITUD_SISGO WHERE PSD.DESEMBOLSADO IS NULL AND RV.ID_REPORTE_VALORADOS IS NOT NULL";
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE REPORTE_VALORADOS SET PAGARE = 'CUSTODIADO'";
                        strSQL = strSQL + "WHERE SOLICITUD_SISGO = '" + row[0].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
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

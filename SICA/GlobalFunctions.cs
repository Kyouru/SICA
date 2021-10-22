using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Reflection;
using SICA.Forms;
using SimpleLogger;
using System.Diagnostics;
using System.Globalization;
using Microsoft.Office.Interop.Excel;

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

        public static System.Data.DataTable ConvertExcelToDataTable(string FileName, int index)
        {
            try
            {
                if (!File.Exists(FileName))
                    return null;

                FileInfo fi = new FileInfo(FileName);
                long filesize = fi.Length;

                Microsoft.Office.Interop.Excel.Application xlApp;
                Workbook xlWorkBook;
                Worksheet xlWorkSheet;
                Range range;
                var misValue = Type.Missing;

                // abrir el documento 
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(FileName, misValue, misValue,
                    misValue, misValue, misValue, misValue, misValue, misValue,
                    misValue, misValue, misValue, misValue, misValue, misValue);

                // seleccion de la hoja de calculo
                // get_item() devuelve object y numera las hojas a partir de 1
                xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(index);

                // seleccion rango activo
                range = xlWorkSheet.UsedRange;

                int rows = range.Rows.Count;

                System.Data.DataTable dt = new System.Data.DataTable();

                int i = 1;

                //no mas de 50 columnas
                while (i < 50 && xlWorkSheet.Cells[1, i].Text != "")
                {
                    dt.Columns.Add(Convert.ToString(xlWorkSheet.Cells[1, i].Text));
                    ++i;
                }
                --i;

                for (int row = 2; row <= rows; row++)
                {
                    DataRow newrow = dt.NewRow();
                    for (int col = 1; col <= i; col++)
                    {
                        // lectura como cadena
                        string cellText = xlWorkSheet.Cells[row, col].Text;
                        cellText = Convert.ToString(cellText);
                        //cellText = cellText.Replace("'", ""); // Comillas simples no pueden pasar en el Texto

                        newrow[col - 1] = cellText;
                    }
                    dt.Rows.Add(newrow);
                }

                xlWorkBook.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();

                // liberar
                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);

                return dt;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return null;
            }
        }

        public static void ExportarDataGridViewExcel(DataGridView dgv, string fileName)
        {
            
            if (dgv.Rows.Count > 3000)
            {
                DialogResult dialogResult = MessageBox.Show("Tabla tiene mas de 3000 filas\nDesea Continuar", "Muchas Filas", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            LoadingScreen.iniciarLoading();
            if (!Directory.Exists(Globals.ExportarPath))
            {
                Directory.CreateDirectory(Globals.ExportarPath);
            }
            if (fileName is null)
            {
                fileName = Globals.ExportarPath + "EXPORTAR_" + Globals.Username + "_" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            else
            {
                fileName = Globals.ExportarPath + fileName;
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                Worksheet xlWorkSheet = null;

                xlWorkSheet.EnableCalculation = false;

                xlApp.ScreenUpdating = false;
                xlApp.Calculation = XlCalculation.xlCalculationManual;

                xlWorkSheet = xlWorkBook.Sheets[1];
                //xlWorkSheet = xlWorkBook.ActiveSheet;

                xlWorkSheet.Name = "Mica1";

                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    xlWorkSheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xlWorkSheet.EnableCalculation = true;
                // save the application  
                xlWorkBook.SaveAs(fileName, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                xlApp.ScreenUpdating = true;
                xlApp.Calculation = XlCalculation.xlCalculationAutomatic;
                xlApp.Visible = true;
                LoadingScreen.cerrarLoading();

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }

        }
        public static void ExportarDataGridViewCSV(DataGridView dgv, string fileName)
        {
            LoadingScreen.iniciarLoading();

            if (Directory.Exists(Globals.ExportarPath))
            {
                Directory.CreateDirectory(Globals.ExportarPath);
            }
            if (fileName is null)
            {
                fileName = Globals.ExportarPath + "EXPORTAR_" + Globals.Username + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            }

            try
            {
                string[] outputCsv = new string[dgv.Rows.Count + 1];
                string columnNames = "";

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    columnNames += dgv.Columns[i].HeaderText.ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                }
                outputCsv[0] += columnNames;

                //Recorremos el DataTable rellenando la hoja de trabajo
                for (int i = 1; (i - 1) < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j] != null)
                        {
                            outputCsv[i] += dgv.Rows[i - 1].Cells[j].Value.ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
                        }
                    }
                }
                File.WriteAllLines(fileName, outputCsv, Encoding.UTF8);

                Process.Start(fileName);

                LoadingScreen.cerrarLoading();

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }

        }

        public static void ArmarCargoExcel(System.Data.DataTable dt, string nombre_cargo, string fileName, Boolean cabecera)
        {
            LoadingScreen.iniciarLoading();
            int cols;

            try
            {
                StreamWriter wr = new StreamWriter(fileName);
                cols = dt.Columns.Count;
                if (cabecera)
                {

                    wr.WriteLine();
                    wr.Write(nombre_cargo +",,,FECHA," + DateTime.Now.ToString("yyyy-MM-dd") + ",");
                    wr.WriteLine();
                    wr.WriteLine();
                }

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    wr.Write(dt.Columns[j].ColumnName + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                wr.WriteLine();

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
                                    wr.Write(DateTime.Parse(dt.Rows[i][j].ToString()).ToString("yyyy-MM-dd") + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                                }
                                catch
                                {
                                    wr.Write("'" + dt.Rows[i][j].ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                                }
                            }
                            else
                            {
                                wr.Write(dt.Rows[i][j].ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                            }
                        }
                    }
                    wr.WriteLine();
                }
                wr.Close();

                Process.Start(fileName);

                LoadingScreen.cerrarLoading();

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }

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
        
        public static bool AgregarCarrito(string id_inventario, string id_aux, string caja, string tipo)
        {
            string strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_AUX_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (" + id_inventario + ", " + id_aux + ", " + Globals.IdUsername + ", '" + tipo + "', '" + caja + "')";
            try
            {
                if (!Conexion.conectar())
                    return false;

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();

                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }

        public static int CantidadCarrito(string tipo)
        {
            int n;
            string strSQL;
            if (!Conexion.conectar())
                return 0;

            strSQL = "SELECT COUNT(*) FROM TMP_CARRITO WHERE TIPO = '" + tipo + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
            try
            {
                if (!Conexion.iniciaCommand(strSQL))
                    return 0;

                n = Convert.ToInt32(Conexion.ejecutarQueryEscalar());
                Conexion.cerrar();
                return n;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return 0;
            }
        }

        public static System.Data.DataTable ToDataTable<T>(List<T> items)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(T).Name);

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
            string strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + tipo + "'";
            try
            {
                if (!Conexion.conectar())
                    return false;

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();

                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }


        public static void casoError(Exception ex, string strSQL)
        {
            Globals.lastSQL = strSQL;
            SimpleLog.Log(ex);
            LoadingScreen.cerrarLoading();
            MessageBox.Show(ex.Message + "\n" + strSQL);
        }

        public static bool verificarCaja (string numero_caja, string usuario)
        {
            string strSQL = "SELECT COUNT(*) FROM INVENTARIO_GENERAL WHERE NUMERO_DE_CAJA = '" + numero_caja + "' AND USUARIO_POSEE <> '" + usuario + "'";
            int i = -1;
            if (!Conexion.conectar())
            {
                return false;
            }

            if (!Conexion.iniciaCommand(strSQL))
            {
                Conexion.cerrar();
                return false;
            }

            i = Conexion.ejecutarQueryEscalar();

            Conexion.cerrar();

            if (i > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int pendienteConfirmarRecepcion()
        {
            int n = -1;
            string strSQL = "";
            try
            {
                strSQL = "SELECT COUNT(*) FROM INVENTARIO_HISTORICO WHERE RECIBIDO = 0 AND ANULADO = 0 AND ID_USUARIO_RECIBE_FK = " + Globals.IdUsername;
                if (!Conexion.conectar())
                {
                    return -1;
                }

                if (!Conexion.iniciaCommand(strSQL))
                {
                    Conexion.cerrar();
                    return -1;
                }

                n = Conexion.ejecutarQueryEscalar();
                Conexion.cerrar();
                return n;

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return -1;
            }
        }

        public static void limpiarTodoCarrito()
        {
            string strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername;
            try
            {
                if (!Conexion.conectar())
                {
                    Conexion.cerrar();
                    return;
                }

                if (!Conexion.iniciaCommand(strSQL))
                {
                    Conexion.cerrar();
                    return;
                }

                if (!Conexion.ejecutarQuery())
                {
                    Conexion.cerrar();
                    return;
                }

                Conexion.cerrar();

                return;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }



        public static bool verificarSesion(int id)
        {
            System.Data.DataTable dt;
            string strSQL = "";
            try
            {
                if (!Conexion.conectar())
                {
                    Conexion.cerrar();
                    return false;
                }

                strSQL = "UPDATE USUARIO SET ULTIMA_ACTIVIDAD = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE ID_USUARIO = " + id;

                if (!Conexion.iniciaCommand(strSQL))
                {
                    Conexion.cerrar();
                    return false;
                }
                if (!Conexion.ejecutarQuery())
                {
                    Conexion.cerrar();
                    return false;
                }

                strSQL = "SELECT CERRAR_SESION FROM USUARIO WHERE ID_USUARIO = " + id;

                if (!Conexion.iniciaCommand(strSQL))
                {
                    Conexion.cerrar();
                    return false;
                }
                if (!Conexion.ejecutarQuery())
                {
                    Conexion.cerrar();
                    return false;
                }

                dt = Conexion.llenarDataTable();
                if (dt is null)
                {
                    Conexion.cerrar();
                    return false;
                }

                Conexion.cerrar();

                if (dt.Rows[0]["CERRAR_SESION"].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return true;
            }
        }
        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to release the object(object:{0})\n" + ex.Message, obj.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void cerrarExcel(Workbook xlWorkBook, Worksheet xlWorkSheet, Microsoft.Office.Interop.Excel.Application xlApp)
        {
            // cerrar
            xlWorkBook.Close(false, Type.Missing, Type.Missing);
            xlApp.Quit();

            // liberar
            ReleaseObject(xlWorkSheet);
            ReleaseObject(xlWorkBook);
            ReleaseObject(xlApp);
        }

        public static string actualizarCantidad(string tipocarrito)
        {
            string vRet;
            string strSQL = "SELECT COUNT(*) FROM TMP_CARRITO WHERE TIPO = '" + tipocarrito + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
            try
            {
                Conexion.conectar();
                Conexion.iniciaCommand(strSQL);

                vRet = "(" + Conexion.ejecutarQueryEscalar() + ")";

                Conexion.cerrar();
                return vRet;
            }
            catch
            {
                return null;
            }
        }
    }
}

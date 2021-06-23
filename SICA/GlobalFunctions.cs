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
using ExcelLibrary.SpreadSheet;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using CsvHelper;
using System.Globalization;
using System.Linq;

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

            using (var csvConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path.GetDirectoryName(FileName) + ";Extended Properties=\"Text;HDR=Yes;FMT=Delimited;Format=Delimited(,)\""))
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
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        csvConnection.Close();
                        GlobalFunctions.casoError(ex, "");
                        return null;
                    }
                }
            }
        }

        public static DataTable ConvertCsvToDataTable2(string FileName)
        {
            DataTable dt = new DataTable("TABLA1");
            try
            {
                using (var reader = new StreamReader(FileName))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        //csv.Configuration.Delimiter = ";";
                        using (var dr = new CsvDataReader(csv))
                        {
                            dt.Load(dr);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                MessageBox.Show("a");
                return null;
            }
        }
        public static DataTable ConvertExcelToDataTableOld(string FileName, int index)
        {
            try
            {
                Workbook workbook = Workbook.Load(FileName);
                Worksheet worksheet = workbook.Worksheets[index];

                DataTable dt = new DataTable();

                int j = -1, k = -1, m = -1, n = -1;

                for (int i = 0; i <= worksheet.Cells.LastColIndex; i++)
                {
                    dt.Columns.Add(worksheet.Cells[0, i].Value.ToString());
                    if (worksheet.Cells[0, i].Value.ToString() == "F_GIRO")
                    {
                        j = i;
                    }
                    if (worksheet.Cells[0, i].Value.ToString() == "F_VENCIMIENTO")
                    {
                        k = i;
                    }
                    if (worksheet.Cells[0, i].Value.ToString() == "FECHA DESDE")
                    {
                        m = i;
                    }
                    if (worksheet.Cells[0, i].Value.ToString() == "FECHA HASTA")
                    {
                        n = i;
                    }
                }

                DataRow dr;

                for (int rowIndex = worksheet.Cells.FirstRowIndex + 1; rowIndex <= worksheet.Cells.LastRowIndex; rowIndex++)
                {
                    dr = dt.NewRow();
                    for (int i = 0; i <= worksheet.Cells.LastColIndex; i++)
                    {
                        if (worksheet.Cells[rowIndex, i].Value != null)
                        {
                            if (i == j || i == k || i == m || i == n)
                            {
                                dr[i] = DateTime.FromOADate(Double.Parse(worksheet.Cells[rowIndex, i].Value.ToString())).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                dr[i] = worksheet.Cells[rowIndex, i].Value.ToString();
                            }

                        }
                        else
                        {
                            dr[i] = "";
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return null;
            }
        }
        public static DataTable ConvertExcelToDataTable(string FileName, int index)
        {
            try
            {
                Workbook workbook = Workbook.Load(FileName);
                Worksheet worksheet = workbook.Worksheets[index];

                DataTable dt = new DataTable();

                int j = -1, k = -1, m = -1, n = -1;

                for (int i = 0; i <= worksheet.Cells.LastColIndex; i++)
                {
                    dt.Columns.Add(worksheet.Cells[0, i].Value.ToString());
                    if (worksheet.Cells[0, i].Value.ToString() == "F_GIRO")
                    {
                        j = i;
                    }
                    if (worksheet.Cells[0, i].Value.ToString() == "F_VENCIMIENTO")
                    {
                        k = i;
                    }
                    if (worksheet.Cells[0, i].Value.ToString() == "FECHA DESDE")
                    {
                        m = i;
                    }
                    if (worksheet.Cells[0, i].Value.ToString() == "FECHA HASTA")
                    {
                        n = i;
                    }
                }

                DataRow dr;

                for (int rowIndex = worksheet.Cells.FirstRowIndex + 1; rowIndex <= worksheet.Cells.LastRowIndex; rowIndex++)
                {
                    dr = dt.NewRow();
                    for (int i = 0; i <= worksheet.Cells.LastColIndex; i++)
                    {
                        if (worksheet.Cells[rowIndex, i].Value != null)
                        {
                            if (i == j || i == k || i == m || i == n)
                            {
                                dr[i] = DateTime.FromOADate(Double.Parse(worksheet.Cells[rowIndex, i].Value.ToString())).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                dr[i] = worksheet.Cells[rowIndex, i].Value.ToString();
                            }

                        }
                        else
                        {
                            dr[i] = "";
                        }
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return null;
            }
        }

        //no se usa
        public static DataTable ConvertReporteValoradosToDataTable(string strSQL)
        {
            DataTable dt = new DataTable("REPORTE_VALORADOS");

            try
            {
                if (!Conexion.conectar())
                    return null;
                if (!Conexion.iniciaCommand(strSQL))
                    return null;
                if (!Conexion.ejecutarQuery())
                    return null;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return null;

                Conexion.cerrar();

                return dt;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return null;
            }
        }
        

        public static void ExportarDataGridViewExcel(DataGridView dgv, string fileName)
        {
            if (dgv.Rows.Count > 200)
            {
                DialogResult dialogResult = MessageBox.Show("Tabla tiene mas de 500 filas\nDesea Continuar", "Muchas Filas", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            if (fileName is null)
            {
                fileName = Globals.CargoPath + "EXPORTAR_" + Globals.Username + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            }    
            LoadingScreen.iniciarLoading();

            int cols;

            try
            {
                StreamWriter wr = new StreamWriter(fileName);
                cols = dgv.Columns.Count;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    wr.Write(dgv.Columns[j].Name + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                wr.WriteLine();

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
                                    wr.Write(DateTime.Parse(dgv.Rows[i].Cells[j].Value.ToString()).ToString("yyyy-MM-dd") + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                                }
                                catch
                                {
                                    wr.Write("'" + dgv.Rows[i].Cells[j].Value.ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                                }
                            }
                            else
                            {
                                wr.Write(dgv.Rows[i].Cells[j].Value.ToString() + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
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

        public static void ExportarDataGridViewExcelXLS(DataGridView dgv, string fileName, Int32 inicio_row, Int32 inicio_col, Boolean cabecera)
        {
            if (dgv.Rows.Count > 200)
            {
                DialogResult dialogResult = MessageBox.Show("Tabla tiene mas de 200 filas\nDesea Continuar", "Muchas Filas", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                LoadingScreen.iniciarLoading();

                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("Cargo");

                workbook.Worksheets.Add(worksheet);

                if (cabecera)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[inicio_row, j + inicio_col] = new Cell(dgv.Columns[j].Name);
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
                                    worksheet.Cells[i + inicio_row + 1, j + inicio_col] = new Cell(DateTime.Parse(dgv.Rows[i].Cells[j].Value.ToString()).ToString("yyyy-MM-dd"));
                                }
                                catch
                                {
                                    worksheet.Cells[i + inicio_row + 1, j + inicio_col] = new Cell("'" + dgv.Rows[i].Cells[j].Value.ToString());
                                }
                            }
                            else
                            {
                                worksheet.Cells[i + inicio_row + 1, j + inicio_col] = new Cell(dgv.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                    }
                }

                workbook.Save(fileName);

                workbook = Workbook.Load(fileName);
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return;
            }

            LoadingScreen.cerrarLoading();

            //libros_trabajo.Close(true);
            //aplicacion.Quit();
        }

        public static void ArmarCargoExcel(DataTable dt, string nombre_cargo, string fileName, Boolean cabecera)
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
        
        //no se usa
        public static bool EstadoCustodiaReporte(string sisgo, bool expediente, bool pagare, long id_inventario_general)
        {
            string strSQL = "";
            try
            {
                strSQL = "UPDATE REPORTE_VALORADOS SET";

                if (id_inventario_general > 0)
                {
                    strSQL = strSQL + " [ID_INVENTARIO_GENERAL_FK] = " + id_inventario_general + ", ";
                }

                if (expediente)
                {
                    strSQL = strSQL + " [EXPEDIENTE] = 'CUSTODIADO'";
                    if (pagare)
                    {
                        strSQL = strSQL + ", [PAGARE] = 'CUSTODIADO'";
                    }
                }
                else if (pagare)
                {
                    strSQL = strSQL + " [PAGARE] = 'CUSTODIADO'";
                }
                strSQL = strSQL + " WHERE SOLICITUD_SISGO = '" + sisgo + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
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

        //no se usa
        public static bool actualizarNoDesembolsados()
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();

                strSQL = "SELECT ID_EXPEDIENTE_TRANSITO, ESD.SOLICITUD_SISGO, ESD.ID_INVENTARIO_GENERAL_FK FROM EXPEDIENTE_TRANSITO ESD LEFT JOIN REPORTE_VALORADOS RV ON ESD.SOLICITUD_SISGO = RV.SOLICITUD_SISGO WHERE ESD.DESEMBOLSADO = FALSE AND RV.ID_REPORTE_VALORADOS IS NOT NULL";
                if (!Conexion.conectar())
                    return false;

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "UPDATE REPORTE_VALORADOS SET [EXPEDIENTE] = 'CUSTODIADO', ID_INVENTARIO_GENERAL_FK = " + row["ID_INVENTARIO_GENERAL_FK"].ToString();
                    strSQL = strSQL + " WHERE SOLICITUD_SISGO = '" + row["SOLICITUD_SISGO"].ToString() + "'";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (Conexion.ejecutarQueryReturn() > 0)
                    {
                        strSQL = "UPDATE EXPEDIENTE_TRANSITO SET [DESEMBOLSADO] = TRUE, FECHA_SALIDA = #" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
                        strSQL = strSQL + " WHERE ID_EXPEDIENTE_TRANSITO = " + row["ID_EXPEDIENTE_TRANSITO"].ToString();
                        if (!Conexion.iniciaCommand(strSQL))
                            return false;
                        if (!Conexion.ejecutarQuery())
                            return false;
                    }
                }

                dt = new DataTable();
                strSQL = "SELECT ID_PAGARE_TRANSITO, PSD.SOLICITUD_SISGO, PSD.ID_INVENTARIO_GENERAL_FK FROM PAGARE_TRANSITO PSD LEFT JOIN REPORTE_VALORADOS RV ON PSD.SOLICITUD_SISGO = RV.SOLICITUD_SISGO WHERE PSD.DESEMBOLSADO = FALSE AND RV.ID_REPORTE_VALORADOS IS NOT NULL";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "UPDATE REPORTE_VALORADOS SET [PAGARE] = 'CUSTODIADO', ID_INVENTARIO_GENERAL_FK = " + row["ID_INVENTARIO_GENERAL_FK"].ToString();
                    strSQL = strSQL + " WHERE SOLICITUD_SISGO = '" + row["SOLICITUD_SISGO"].ToString() + "'";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (Conexion.ejecutarQueryReturn() > 0)
                    {
                        strSQL = "UPDATE PAGARE_TRANSITO SET [DESEMBOLSADO] = TRUE, FECHA_SALIDA = #" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
                        strSQL = strSQL + " WHERE ID_PAGARE_TRANSITO = " + row["ID_PAGARE_TRANSITO"].ToString();
                        if (!Conexion.iniciaCommand(strSQL))
                            return false;
                        if (!Conexion.ejecutarQuery())
                            return false;
                    }
                }
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
            Conexion.cerrar();
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
                strSQL = "SELECT COUNT(*) FROM INVENTARIO_HISTORICO WHERE RECIBIDO = FALSE AND ANULADO = FALSE AND ID_USUARIO_RECIBE_FK = " + Globals.IdUsername;
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
            DataTable dt = new DataTable();
            string strSQL = "";
            try
            {
                if (!Conexion.conectar())
                {
                    Conexion.cerrar();
                    return false;
                }

                strSQL = "UPDATE USUARIO SET ULTIMA_ACTIVIDAD = #" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "# WHERE ID_USUARIO = " + id;

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

                if (dt.Rows[0]["CERRAR_SESION"].ToString() == "True")
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
    }
}

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
        public static void ExportarDataTableExcel(DataTable dt, string fileName, Int32 inicio_row, Int32 inicio_col, Boolean cabecera)
        {
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
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    hoja_trabajo.Cells[inicio_row, j + inicio_col] = "'" + dt.Columns[j].ColumnName;
                }
            }

            //Recorremos el DataTable rellenando la hoja de trabajo
            for (int i = 1; i < dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != null)
                    {
                        hoja_trabajo.Cells[i + inicio_row, j + inicio_col] = "'" + dt.Rows[i][j].ToString();
                    }
                }
            }
            libros_trabajo.SaveAs(fileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
            aplicacion.Workbooks.Open(fileName);
            //libros_trabajo.Close(true);
            //aplicacion.Quit();
        }
        public static void ArmarCargoExcel(DataTable dt, string fileName, Int32 inicio_row, Int32 inicio_col, Boolean cabecera)
        {
            Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
            Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            aplicacion.Visible = true;
            libros_trabajo = aplicacion.Workbooks.Open(Globals.PlantillaCargoPath);
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
                        hoja_trabajo.Cells[i + inicio_row + 1, j + inicio_col] = "'" + dt.Rows[i][j].ToString();
                    }
                }
            }
            libros_trabajo.SaveAs(fileName,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault);
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
                    strSQL = strSQL + "EXPEDIENTE = TRUE ";
                    if (pagare)
                    {
                        strSQL = strSQL + ", PAGARE = TRUE ";
                    }
                }
                else if (pagare)
                {
                    strSQL = strSQL + "PAGARE = TRUE ";
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

        public static bool AgregarCarrito(string id_inventario, string id_inventario_h, string caja, string tipo)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    sqliteCmd = new SQLiteCommand("INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_INVENTARIO_HISTORICO_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (" + id_inventario + ", " + id_inventario_h + ", " + Globals.IdUsername +  ", '" + tipo + "', '" + caja + "')", sqliteConnection);
                    
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

        public static bool SolicitarCarrito(string tipo)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    DataTable dt = new DataTable();
                    sqliteCmd = new SQLiteCommand("SELECT ID_INVENTARIO_GENERAL_FK AS ID, NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + tipo + "' AND ID_USUARIO_FK = " + Globals.IdUsername + "", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    foreach (DataRow row in dt.Rows)
                    {
                        string strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, FECHA_INICIO, NUMERO_CAJA, OBSERVACION) VALUES (" + row["ID"].ToString();
                        strSQL = strSQL + ", " + Globals.IdIM;
                        strSQL = strSQL + ", " + fecha + "";
                        strSQL = strSQL + ", '" + row["NUMERO_CAJA"].ToString() + "'";
                        strSQL = strSQL + ", '" + Globals.Username + "')";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + tipo + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Solicitado");
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
        public static bool SolicitarCajasCarrito()
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter sqliteDataAdapter;
                    string strSQL;
                    string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = 'IM_SOLICITAR' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = 'EN TRANSITO A CP' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    dt = new DataTable();
                    strSQL = "SELECT IG.ID_INVENTARIO_GENERAL AS ID, NUMERO_CAJA FROM INVENTARIO_GENERAL IG LEFT JOIN (SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = 'IM_SOLICITAR' AND ID_USUARIO_FK = " + Globals.IdUsername + ") CAJAS";
                    strSQL = strSQL + " ON IG.NUMERO_DE_CAJA = CAJAS.NUMERO_CAJA WHERE CAJAS.NUMERO_CAJA IS NOT NULL";

                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, FECHA_INICIO, NUMERO_CAJA, OBSERVACION) VALUES (" + row["ID"].ToString();
                        strSQL = strSQL + ", " + Globals.IdIM;
                        strSQL = strSQL + ", " + fecha + "";
                        strSQL = strSQL + ", '" + row["NUMERO_CAJA"].ToString() + "'";
                        strSQL = strSQL + ", '" + Globals.Username + "')";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = 'IM_SOLICITAR'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Solicitado");
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

        public static bool RecibirCajasCarrito()
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter sqliteDataAdapter;
                    string strSQL;
                    string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = 'IM_RECIBIR' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = '" + Globals.Username + "' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "UPDATE INVENTARIO_HISTORICO SET ID_USUARIO_RECIBE_FK = " + Globals.IdUsername + ", FECHA_FIN = " + fecha + " WHERE NUMERO_CAJA = '" + row["NUMERO_CAJA"].ToString() + "' AND ID_USUARIO_RECIBE_FK IS NULL AND FECHA_FIN IS NULL";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = 'IM_RECIBIR'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Recibido");
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

        public static bool ArmarCajasCarrito(string caja)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter sqliteDataAdapter;
                    string strSQL;
                    string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    strSQL = "UPDATE INVENTARIO_GENERAL SET NUMERO_DE_CAJA = '' WHERE NUMERO_DE_CAJA ='" + caja + "'";
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    strSQL = "SELECT ID_INVENTARIO_GENERAL_FK FROM TMP_CARRITO WHERE TIPO = 'IM_ARMAR' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "INSERT INTO ARMAR_CAJA_HISTORICO (NUMERO_CAJA, USUARIO, FECHA, ID_INVENTARIO_GENERAL_FK) VALUES ('" + caja + "', '" + Globals.Username + "', " + fecha + ", " + row["ID_INVENTARIO_GENERAL_FK"].ToString() + ")";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "UPDATE INVENTARIO_GENERAL SET NUMERO_DE_CAJA = '" + caja + "' WHERE ID_INVENTARIO_GENERAL = " + row["ID_INVENTARIO_GENERAL_FK"].ToString() + "";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = 'IM_ARMAR'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Caja " + caja + " Armada");
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

        public static bool EnviarCajasCarrito()
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter sqliteDataAdapter;
                    string strSQL;
                    string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = 'IM_ENVIAR' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = 'EN TRANSITO A CP' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    dt = new DataTable();
                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = 'IM_ENVIAR' AND ID_USUARIO_FK = " + Globals.IdUsername + "";

                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, NUMERO_CAJA, FECHA_INICIO, OBSERVACION) VALUES (";
                        strSQL = strSQL + "" + Globals.IdIM;
                        strSQL = strSQL + ", '" + row["NUMERO_CAJA"].ToString() + "'";
                        strSQL = strSQL + ", " + fecha + "";
                        strSQL = strSQL + ", '" + Globals.Username + "')";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = 'IM_ENVIAR'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Solicitud Enviada");
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
        public static bool EntregarCajasCarrito()
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                SQLiteCommand sqliteCmd;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                try
                {
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter sqliteDataAdapter;
                    string strSQL;
                    string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = 'IM_ENTREGAR' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE INVENTARIO_HISTORICO SET ID_USUARIO_ENTREGA_FK = " + Globals.IdUsername + ", FECHA_FIN = " + fecha + " WHERE NUMERO_CAJA = " + row["NUMERO_CAJA"].ToString() + " AND ID_USUARIO_ENTREGA_FK IS NULL AND FECHA_FIN IS NULL";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = 'IRON MOUNTAIN' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = 'IM_ENTREGAR'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Cajas Entregadas");
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

    }
}

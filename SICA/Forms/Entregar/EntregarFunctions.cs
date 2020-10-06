
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    class EntregarFunctions
    {
        public static bool EntregarExpedientesCarrito ()
        {
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                string strSQL = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                try
                {
                    sqliteConnection.Open();
                    SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                    SQLiteCommand sqliteCmd;

                    strSQL = "SELECT TC.ID_INVENTARIO_GENERAL_FK AS ID, IG.ID_REPORTE_VALORADOS_FK AS ID_REPORTE, '0' AS '#', DESCRIPCION_1 AS 'DEFINICION', DESCRIPCION_2 AS 'SOLICITUD', DESCRIPCION_3 AS 'COD. PRESTAMO', DESCRIPCION_4 AS 'NOMBRE SOCIO' FROM TMP_CARRITO TC";
                    strSQL = strSQL + " LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                    strSQL = strSQL + " WHERE TIPO = '" + Globals.strEntregarExpediente + "' AND ID_USUARIO_FK = " + Globals.IdUsername;

                    sqliteCmd = new SQLiteCommand(sqliteConnection);
                    sqliteCmd.CommandText = strSQL;
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, FECHA_FIN) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", " + fecha + ", " + fecha + ")";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'PRESTADO', USUARIO_POSEE = '" + Globals.UsernameSelect + "', FECHA_POSEE = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString();
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        if (row["ID_REPORTE"].ToString() != "")
                        {
                            strSQL = "UPDATE REPORTE_VALORADOS SET EXPEDIENTE = 'PRESTADO' WHERE ID_REPORTE_VALORADOS = " + row["ID_REPORTE"].ToString();
                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                        }
                    }

                    dt.Columns.Remove("ID");
                    dt.Columns.Remove("ID_REPORTE");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][0] = i + 1;
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strEntregarExpediente + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();

                    GlobalFunctions.ArmarCargoExcel(dt, Globals.PlantillaCargoExpPath, Globals.CargoPath + "CARGO_EXP_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);

                    //MessageBox.Show("Proceso Finalizado");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    Globals.t.Abort();
                    MessageBox.Show(ex.Message + "\n" + strSQL);
                    return false;
                }
            }
        }

        public static bool EntregarDocumentosCarrito()
        {
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                string strSQL = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                try
                {
                    sqliteConnection.Open();
                    SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                    SQLiteCommand sqliteCmd;

                    strSQL = "SELECT TC.ID_INVENTARIO_GENERAL_FK AS ID, IG.ID_REPORTE_VALORADOS_FK AS ID_REPORTE, '0' AS '#', STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESCRIPCION 1', DESCRIPCION_2 AS 'DESCRIPCION 2', DESCRIPCION_3 AS 'DESCRIPCION 3', DESCRIPCION_4 AS 'DESCRIPCION 4' FROM TMP_CARRITO TC";
                    strSQL = strSQL + " LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                    strSQL = strSQL + " WHERE TIPO = '" + Globals.strEntregarDocumento + "' AND ID_USUARIO_FK = " + Globals.IdUsername;

                    sqliteCmd = new SQLiteCommand(sqliteConnection);
                    sqliteCmd.CommandText = strSQL;
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, FECHA_FIN) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", " + fecha + ", " + fecha + ")";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'PRESTADO', USUARIO_POSEE = '" + Globals.UsernameSelect + "', FECHA_POSEE = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString();
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    dt.Columns.Remove("ID");
                    dt.Columns.Remove("ID_REPORTE");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][0] = i + 1;
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strEntregarDocumento + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();

                    GlobalFunctions.ArmarCargoExcel(dt, Globals.PlantillaCargoDocPath, Globals.CargoPath + "CARGO_DOC_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);

                    //MessageBox.Show("Proceso Finalizado");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    Globals.t.Abort();
                    MessageBox.Show(ex.Message + "\n" + strSQL);
                    return false;
                }
            }
        }

        public static bool EntregarPagaresCarrito(int desembolsado)
        {
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                string strSQL = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                try
                {
                    sqliteConnection.Open();
                    SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                    SQLiteCommand sqliteCmd;

                    if (desembolsado == 1)
                    {
                        strSQL = "SELECT TC.ID_REPORTE_VALORADOS_FK AS ID, '0' AS '#', RV.CIP, RV.NOMBRE, RV.MONTOPRESTAMO, RV.SOLICITUD_SISGO AS 'SISGO'";
                        strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN REPORTE_VALORADOS RV ON TC.ID_REPORTE_VALORADOS_FK = RV.ID_REPORTE_VALORADOS";
                        strSQL = strSQL + " WHERE TC.TIPO = '" + Globals.strEntregarPagare + "' AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                    }
                    else
                    {
                        strSQL = "SELECT TC.ID_PAGARE_SIN_DESEMBOLSAR AS ID, '0' AS '#', DESCRIPCION_2 AS 'DESCRIPCION 2', DESCRIPCION_3 AS 'DESCRIPCION 3', DESCRIPCION_4 AS 'DESCRIPCION 4', PSD.SOLICITUD_SISGO AS 'SISGO'";
                        strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN PAGARE_SIN_DESEMBOLSAR PSD ON TC.SOLICITUD_SISGO = PSD.SOLICITUD_SISGO";
                        strSQL = strSQL + " WHERE TC.TIPO = '" + Globals.strEntregarPagareSinDesembolsar + "' AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                    }

                    sqliteCmd = new SQLiteCommand(sqliteConnection);
                    sqliteCmd.CommandText = strSQL;
                    sqliteCmd.ExecuteNonQuery();

                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        if (desembolsado == 1)
                        {
                            strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, SOLICITUD_SISGO, FECHA) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", '" + row["SISGO"].ToString() + "', " + fecha + ")";
                        }
                        else
                        {
                            strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, SOLICITUD_SISGO, FECHA) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", '" + row["SISGO"].ToString() + "', " + fecha + ")";
                        }
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    dt.Columns.Remove("ID");

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][0] = i + 1;
                    }

                    if (desembolsado == 1)
                    {
                        sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strEntregarPagare + "'", sqliteConnection);
                    }
                    else
                    {
                        sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strEntregarPagareSinDesembolsar + "'", sqliteConnection);
                    }

                    sqliteCmd.ExecuteNonQuery();
                    sqliteTransaction.Commit();
                    sqliteConnection.Close();

                    GlobalFunctions.ArmarCargoExcel(dt, Globals.PlantillaCargoPagPath, Globals.CargoPath + "CARGO_PAG_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);

                    //MessageBox.Show("Proceso Finalizado");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    Globals.t.Abort();
                    MessageBox.Show(ex.Message + "\n" + strSQL);
                    return false;
                }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    class RecibirFunctions
    {
        public static string ArmarStrNuevoIngreso(DataGridViewRow row)
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
                strSQL = strSQL + "'" + DateTime.ParseExact(row.Cells["FECHA DESDE"].Value.ToString(), "DD/MM/YYYY", CultureInfo.InvariantCulture) + "', ";
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
            strSQL = strSQL + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
            strSQL = strSQL + "'" + Globals.Username + "')";
            return strSQL;

        }

        public static bool Reingreso(int id_inventario, int id_valodado, string tipo, string observacion)
        {
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                SQLiteCommand sqliteCmd;
                string strSQL = "";
                string fecha = "'" + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss") + "'";
                try
                {
                    strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = '" + Globals.Username + "', FECHA_POSEE = " + fecha + ", CUSTODIADO = 'CUSTODIADO' WHERE ID_INVENTARIO_GENERAL = " + id_inventario;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION)
                                VALUES (" + id_inventario + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "')";

                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    if (tipo == "EXPEDIENTES DE CREDITO")
                    {
                        strSQL = "UPDATE REPORTE_VALORADOS SET EXPEDIENTE = 'CUSTODIADO' WHERE ID_REPORTE_VALORADOS = " + id_valodado;
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }
                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message + "\n" + strSQL);
                    return false;
                }
            }
        }

        public static bool ReingresoCarrito(int entrega, string observacion)
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
                    strSQL = "SELECT ID_INVENTARIO_GENERAL_FK AS ID FROM TMP_CARRITO WHERE TIPO = '" + Globals.strRecibirReingreso + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARION_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION) VALUES (" + row["ID"].ToString() + ", " + entrega + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "')";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'CUSTODIADO', USUARIO_POSEE = '" + Globals.Username + "', FECHA_POSEE = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row[0].ToString() + "";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strRecibirReingreso + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Proceso Finalizado");
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
    
        public static bool RecibirPagare(string id_reporte_valorados)
        {
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string  fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                SQLiteCommand sqliteCmd;
                string strSQL = "";
                try
                {
                    strSQL = @"INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, FECHA)
                                VALUES (" + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + id_reporte_valorados + ", " + fecha + ")";

                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    strSQL = "UPDATE REPORTE_VALORADOS SET PAGARE = 'CUSTODIADO' WHERE ID_REPORTE_VALORADOS = " + id_reporte_valorados;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();

                    MessageBox.Show("Registrado");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message + "\n" + strSQL);
                    return false;
                }
            }
        }
    }
}

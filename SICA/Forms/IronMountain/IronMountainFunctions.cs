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
    class IronMountainFunctions
    {
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
                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainSolicitar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
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
                    strSQL = "SELECT IG.ID_INVENTARIO_GENERAL AS ID, NUMERO_CAJA FROM INVENTARIO_GENERAL IG LEFT JOIN (SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainSolicitar + "' AND ID_USUARIO_FK = " + Globals.IdUsername + ") CAJAS";
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
                    //Globals.t.Abort();
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

                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainRecibir + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
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

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainRecibir + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Recibido");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    //Globals.t.Abort();
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

                    strSQL = "SELECT ID_INVENTARIO_GENERAL_FK FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainArmar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
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

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainArmar + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Caja " + caja + " Armada");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    //.t.Abort();
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
                        strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = 'EN TRANSITO A IM' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    dt = new DataTable();
                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainEnviar + "' AND ID_USUARIO_FK = " + Globals.IdUsername + "";

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

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainEnviar + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Solicitud Enviada");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    //Globals.t.Abort();
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
                    strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainEntregar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE INVENTARIO_HISTORICO SET ID_USUARIO_ENTREGA_FK = " + Globals.IdUsername + ", FECHA_FIN = " + fecha + " WHERE NUMERO_CAJA = '" + row["NUMERO_CAJA"].ToString() + "' AND ID_USUARIO_ENTREGA_FK IS NULL AND FECHA_FIN IS NULL";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = 'IRON MOUNTAIN' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }

                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainEntregar + "'", sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();

                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    MessageBox.Show("Cajas Entregadas");
                    return true;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    //Globals.t.Abort();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

    }
}

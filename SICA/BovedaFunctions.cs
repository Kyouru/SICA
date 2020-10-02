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
    class BovedaFunctions
    {

        public static bool RetiroCarrito()
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
                    strSQL = "SELECT ID_INVENTARIO_GENERAL_FK AS ID, U.ID_USUARIO AS ID_BOVEDA";
                    strSQL = strSQL + " FROM (TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK) ";
                    strSQL = strSQL + " LEFT JOIN USUARIO U ON IG.USUARIO_POSEE = U.USERNAME ";
                    strSQL = strSQL + " WHERE TIPO = '" + Globals.strBovedaRetirar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
                    sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                    sqliteCmd.ExecuteNonQuery();
                    sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = '" + Globals.Username + "', FECHA_POSEE = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString() + "";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();

                        strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARION_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN) VALUES (" + row["ID"].ToString() + ", " + row["ID_BOVEDA"].ToString() + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ")";
                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }
                    
                    sqliteCmd = new SQLiteCommand("DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strBovedaRetirar + "'", sqliteConnection);
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


    }
}

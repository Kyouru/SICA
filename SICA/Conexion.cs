
using SICA.Forms;
using SimpleLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SICA
{
    class Conexion
    {
        public static OleDbConnection connection;
        public static OleDbCommand command;
        public static OleDbDataAdapter adapter;

        public static bool conectar()
        {
            try
            {
                connection = new OleDbConnection(Globals.Provider + Globals.DBPath);
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
                return false;
            }
        }
        public static bool iniciaCommand(string strSQL)
        {
            try
            {
                command = new OleDbCommand(strSQL, connection);
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }
        public static bool agregarParametroCommand(string nombre, string valor)
        {
            try
            {
                command.Parameters.AddWithValue(nombre, valor);
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "(" + nombre + ", " + valor + ")");
                return false;
            }
        }

        public static bool ejecutarQuery()
        {
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, command.CommandText);
                return false;
            }
        }
        public static int ejecutarQueryReturn()
        {
            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, command.CommandText);
                return 0;
            }
        }
        public static int ejecutarQueryEscalar()
        {
            try
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, command.CommandText);
                return -1;
            }
        }

        public static DataTable llenarDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                adapter = new OleDbDataAdapter(command);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, command.CommandText);
                return null;
            }
        }
        public static int lastIdInsert()
        {
            OleDbCommand cmd2 = new OleDbCommand("SELECT @@IDENTITY", connection);
            try
            {
                return Convert.ToInt32(cmd2.ExecuteScalar());
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "SELECT @@IDENTITY");
                return -1;
            }
        }
        

        public static void cerrar()
        {
            try
            {
                if (connection != null)
                    connection.Close();
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }

            try
            {
                if (connection != null)
                    connection.Dispose();
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }

            try
            {
                if (adapter != null)
                    adapter.Dispose();
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }

            try
            {
                if (command != null)
                    command.Dispose();
            }
            catch (Exception ex)
            {
                SimpleLog.Log(ex);
            }
        }
    }
}


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
                connection = new OleDbConnection(Globals.DBconnectionString);
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                //Globals.t.Abort();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
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
                //Globals.t.Abort();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
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
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
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
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
                return false;
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
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
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
                //Globals.t.Abort();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void cerrar()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
            }

            try
            {
                connection.Dispose();
            }
            catch (Exception ex)
            {
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
            }

            try
            {
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
            }

            try
            {
                command.Dispose();
            }
            catch (Exception ex)
            {
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
            }
        }
    }
}

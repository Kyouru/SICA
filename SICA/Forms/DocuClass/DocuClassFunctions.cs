using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.DocuClass
{
    class DocuClassFunctions
    {
        public static bool EntregarCarrito()
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";

            try
            {
                DataTable dt = new DataTable();

                strSQL = "SELECT NUMERO_DE_CAJA FROM TMP_CARRITO TC";
                strSQL = strSQL + " WHERE TIPO = '" + Globals.strDocuClassEntregar + "' AND ID_USUARIO_FK = " + Globals.IdUsername + "";

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
                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, NUMERO_CAJA, FECHA_INICIO, FECHA_FIN, RECIBIDO) VALUES (" + Globals.IdUsername + ", " + Globals.IdDC + ", '" + row["NUMERO_DE_CAJA"].ToString() + "', " + fecha + ", " + fecha + ", TRUE)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = 'DOCUCLASS', [FECHA_POSEE] = " + fecha + " WHERE NUMERO_DE_CAJA = '" + row["NUMERO_DE_CAJA"].ToString() + "' AND USUARIO_POSEE = '" + Globals.Username + "'";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strDocuClassEntregar + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();
                LoadingScreen.cerrarLoading();

                MessageBox.Show("Proceso Finalizado");
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }

        public static bool RecibirCarrito()
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";

            try
            {
                DataTable dt = new DataTable();

                strSQL = "SELECT NUMERO_DE_CAJA FROM TMP_CARRITO TC";
                strSQL = strSQL + " WHERE TIPO = '" + Globals.strDocuClassRecibir + "' AND ID_USUARIO_FK = " + Globals.IdUsername + "";

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
                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, NUMERO_CAJA, FECHA_INICIO, FECHA_FIN, RECIBIDO) VALUES (" + Globals.IdDC + ", " + Globals.IdUsername + ", '" + row["NUMERO_DE_CAJA"].ToString() + "', " + fecha + ", " + fecha + ", TRUE)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = '" + Globals.Username + "', [FECHA_POSEE] = " + fecha + " WHERE NUMERO_DE_CAJA = '" + row["NUMERO_DE_CAJA"].ToString() + "' AND USUARIO_POSEE = 'DOCUCLASS'";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strDocuClassRecibir + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();
                LoadingScreen.cerrarLoading();

                MessageBox.Show("Proceso Finalizado");
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }
    }
}

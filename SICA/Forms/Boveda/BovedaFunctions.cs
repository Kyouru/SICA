using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.Boveda
{
    class BovedaFunctions
    {
        public static bool RetirarDocCarrito()
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();

                string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
                strSQL = "SELECT ID_INVENTARIO_GENERAL_FK AS ID, ID_AUX_FK";
                strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK ";
                strSQL = strSQL + " WHERE TIPO = '" + Globals.strBovedaRetirarDOC + "'";

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
                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = '" + Globals.Username + "', [FECHA_POSEE] = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString() + "";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, RECIBIDO) VALUES (" + row["ID"].ToString() + ", " + row["ID_AUX_FK"].ToString() + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", TRUE)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strBovedaRetirarDOC + "'";
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

        public static bool GuardarDocCarrito()
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";

            try
            {
                DataTable dt = new DataTable();

                strSQL = "SELECT TC.ID_INVENTARIO_GENERAL_FK AS ID, IG.ID_REPORTE_VALORADOS_FK AS ID_REPORTE, '0' AS NRO, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5 FROM TMP_CARRITO TC";
                strSQL = strSQL + " LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                strSQL = strSQL + " WHERE TIPO = '" + Globals.strBovedaGuardarDOC + "' AND ID_USUARIO_FK = " + Globals.IdUsername;

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

                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, FECHA_FIN, RECIBIDO) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", " + fecha + ", " + fecha + ", TRUE)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = '" + Globals.UsernameSelect + "', [FECHA_POSEE] = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString();
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strBovedaGuardarDOC + "'";
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


        public static bool GuardarCajaCarrito()
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";

            try
            {
                DataTable dt = new DataTable();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5 FROM TMP_CARRITO TC";
                strSQL = strSQL + " LEFT JOIN INVENTARIO_GENERAL IG ON TC.NUMERO_CAJA = IG.NUMERO_DE_CAJA";
                strSQL = strSQL + " WHERE TIPO = '" + Globals.strBovedaGuardarCAJA + "' AND IG.USUARIO_POSEE = '" + Globals.Username + "'";

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
                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, NUMERO_CAJA, FECHA_INICIO, FECHA_FIN, RECIBIDO) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", '" + row["NUMERO_DE_CAJA"].ToString() + "', " + fecha + ", " + fecha + ", TRUE)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = '" + Globals.UsernameSelect + "', [FECHA_POSEE] = " + fecha + " WHERE NUMERO_DE_CAJA = '" + row["NUMERO_DE_CAJA"].ToString() + "' AND USUARIO_POSEE = '" + Globals.Username + "'";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strBovedaGuardarCAJA + "'";
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

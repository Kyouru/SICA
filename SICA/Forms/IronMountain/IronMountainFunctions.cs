using SICA.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SICA
{
    class IronMountainFunctions
    {
        public static bool SolicitarCajasCarrito()
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainSolicitar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;

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
                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = 'EN TRANSITO A CP' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                dt = new DataTable();
                strSQL = "SELECT DISTINCT NUMERO_CAJA FROM INVENTARIO_GENERAL IG LEFT JOIN (SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainSolicitar + "' AND ID_USUARIO_FK = " + Globals.IdUsername + ") CAJAS";
                strSQL += " ON IG.NUMERO_DE_CAJA = CAJAS.NUMERO_CAJA WHERE CAJAS.NUMERO_CAJA IS NOT NULL";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, FECHA_INICIO, NUMERO_CAJA, OBSERVACION) VALUES (";
                    strSQL += Globals.IdIM;
                    strSQL += ", " + fecha + "";
                    strSQL += ", '" + row["NUMERO_CAJA"].ToString() + "'";
                    strSQL += ", '" + Globals.Username + "')";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainSolicitar + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();
                LoadingScreen.cerrarLoading();
                MessageBox.Show("Solicitado");
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }

        public static bool RecibirCajasCarrito()
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainRecibir + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
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
                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = '" + Globals.Username + "', [FECHA_POSEE] = " + fecha + " WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "' AND USUARIO_POSEE = 'EN TRANSITO A CP'";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_HISTORICO SET [ID_USUARIO_RECIBE_FK] = " + Globals.IdUsername + ", [FECHA_FIN] = " + fecha + ", [RECIBIDO] = 1 WHERE NUMERO_CAJA = '" + row["NUMERO_CAJA"].ToString() + "' AND RECIBIDO = 0 AND FECHA_FIN IS NULL AND ID_USUARIO_ENTREGA_FK = " + Globals.IdIM;
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainRecibir + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();
                LoadingScreen.cerrarLoading();
                MessageBox.Show("Recibido");
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }

        public static bool ArmarCajasCarrito(string caja, bool reemplazar)
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                if (!Conexion.conectar())
                    return false;

                if (reemplazar)
                { 
                    strSQL = "UPDATE INVENTARIO_GENERAL SET [NUMERO_DE_CAJA] = '' WHERE NUMERO_DE_CAJA = '" + caja + "'";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "SELECT ID_INVENTARIO_GENERAL_FK FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainArmar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "INSERT INTO ARMAR_CAJA_HISTORICO (NUMERO_CAJA, USUARIO, FECHA, ID_INVENTARIO_GENERAL_FK) VALUES ('" + caja + "', '" + Globals.Username + "', " + fecha + ", " + row["ID_INVENTARIO_GENERAL_FK"].ToString() + ")";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [NUMERO_DE_CAJA] = '" + caja + "' WHERE ID_INVENTARIO_GENERAL = " + row["ID_INVENTARIO_GENERAL_FK"].ToString() + "";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainArmar + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();
                LoadingScreen.cerrarLoading();
                MessageBox.Show("Caja " + caja + " Armada");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
        }

        public static bool EnviarCajasCarrito()
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = 'IM_ENVIAR' AND ID_USUARIO_FK = " + Globals.IdUsername;

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
                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = 'EN TRANSITO A IM' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "'";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                dt = new DataTable();
                strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainEnviar + "' AND ID_USUARIO_FK = " + Globals.IdUsername + "";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_RECIBE_FK, NUMERO_CAJA, FECHA_INICIO, OBSERVACION) VALUES (";
                    strSQL += "" + Globals.IdIM;
                    strSQL += ", '" + row["NUMERO_CAJA"].ToString() + "'";
                    strSQL += ", " + fecha + "";
                    strSQL += ", '" + Globals.Username + "')";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainEnviar + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();
                LoadingScreen.cerrarLoading();
                MessageBox.Show("Solicitud Enviada");
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }

        public static bool EntregarCajasCarrito()
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();
                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strSQL = "SELECT DISTINCT NUMERO_CAJA FROM TMP_CARRITO WHERE TIPO = '" + Globals.strIronMountainEntregar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;

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
                    strSQL = "UPDATE INVENTARIO_HISTORICO SET [ID_USUARIO_ENTREGA_FK] = " + Globals.IdUsername + ", [FECHA_FIN] = " + fecha + ", [RECIBIDO] = 1 WHERE NUMERO_CAJA = '" + row["NUMERO_CAJA"].ToString() + "' AND RECIBIDO = 0 AND FECHA_FIN IS NULL AND ID_USUARIO_RECIBE_FK = " + Globals.IdIM;

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = 'IRON MOUNTAIN' WHERE NUMERO_DE_CAJA = '" + row["NUMERO_CAJA"].ToString() + "' AND USUARIO_POSEE = 'EN TRANSITO A IM'";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strIronMountainEntregar + "'";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();

                LoadingScreen.cerrarLoading();
                MessageBox.Show("Cajas Entregadas");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
        }

    }
}

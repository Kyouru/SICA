
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace SICA
{
    class RecibirFunctions
    {

        //PENDIENTE ArmarStrNuevoIngreso
        public static string ArmarStrNuevoIngreso(DataRow row)
        {
            string strSQL;
            strSQL = "INSERT INTO INVENTARIO_GENERAL (NUMERO_DE_CAJA, ID_DEPARTAMENTO_FK, ID_DOCUMENTO_FK, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, DESC_CONCAT, FECHA_POSEE, ID_USUARIO_POSEE, ID_ESTADO_FK, FECHA_MODIFICA, ID_USUARIO_MODIFICA, EXPEDIENTE)";
            strSQL += "VALUES (";
            if (row["NUMERO CAJA"].ToString() != "")
            {
                strSQL += "'" + row["NUMERO CAJA"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["ID DEPARTAMENTO"].ToString() != "")
            {
                strSQL += "'" + row["ID DEPARTAMENTO"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["ID DOCUMENTO"].ToString() != "")
            {
                strSQL += "'" + row["ID DOCUMENTO"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["FECHA DESDE"].ToString() != "")
            {
                strSQL += "'" + DateTime.ParseExact(row["FECHA DESDE"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["FECHA HASTA"].ToString() != "")
            {
                strSQL += "'" + DateTime.ParseExact(row["FECHA HASTA"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["DESCRIPCION 1"].ToString() != "")
            {
                strSQL += "'" + row["DESCRIPCION 1"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["DESCRIPCION 2"].ToString() != "")
            {
                strSQL += "'" + row["DESCRIPCION 2"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["DESCRIPCION 3"].ToString() != "")
            {
                strSQL += "'" + row["DESCRIPCION 3"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["DESCRIPCION 4"].ToString() != "")
            {
                strSQL += "'" + row["DESCRIPCION 4"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            if (row["DESCRIPCION 5"].ToString() != "")
            {
                strSQL += "'" + row["DESCRIPCION 5"].ToString() + "', ";
            }
            else
            {
                strSQL += "NULL, ";
            }

            /*
            if (row.Cells["ID_REPORTE"].Value.ToString() != "")
            {
                strSQL += "" + row.Cells["ID_REPORTE"].Value.ToString() + ", ";
            }
            else
            {
                strSQL += "NULL, ";
            }
            */

            //DESC_CONCAT
            strSQL += "'" + GlobalFunctions.lCadena(row["CODIGO DEPARTAMENTO"].ToString() + ";" + row["CODIGO DOCUMENTO"].ToString() + ";" + row["FECHA DESDE"].ToString() + ";" + row["FECHA HASTA"].ToString() + ";" + row["DESCRIPCION 1"].ToString() + ";" + row["DESCRIPCION 2"].ToString() + ";" + row["DESCRIPCION 3"].ToString() + ";" + row["DESCRIPCION 4"].ToString() + ";" + row["DESCRIPCION 5"].ToString()) + ";', ";
            strSQL += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
            strSQL += "" + Globals.IdUsername + ", " + Globals.IdCustodiado + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Globals.IdUsername + ", ";
            if (row["EXPEDIENTE"].ToString() == "SI")
            {
                strSQL += "1)";
            }
            else
            {
                strSQL += "0)";
            }
            return strSQL;

        }

        public static bool RecibirPagare(DataRow row, string observacion)
        {
            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            string strSQL = "SELECT * FROM PAGARE WHERE SOLICITUD_SISGO = '" + row["DESCRIPCION 2"].ToString() + "'";

            if (!Conexion.conectar())
                return false;
            if (!Conexion.iniciaCommand(strSQL))
                return false;
            if (!Conexion.ejecutarQuery())
                return false;
            DataTable dt = Conexion.llenarDataTable();

            if (dt.Rows.Count > 0)
            {
                strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO, ANULADO) VALUES (";
                strSQL += dt.Rows[0]["ID_PAGARE"].ToString() + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', 1, 0)";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                strSQL = "UPDATE PAGARE SET ID_USUARIO_POSEE = " + Globals.IdUsername + "";
                strSQL += " WHERE ID_PAGARE = " + dt.Rows[0]["ID_PAGARE"].ToString();

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
            }
            else
            {
                strSQL = "INSERT INTO PAGARE (SOLICITUD_SISGO, CODIGO_SOCIO, ID_USUARIO_POSEE, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, CONCAT) VALUES (";
                strSQL += "'" + row["DESCRIPCION 2"].ToString() + "', '" + row["DESCRIPCION 3"].ToString().Split('-')[0] + "', " + Globals.IdUsername + ", '" + row["DESCRIPCION 3"].ToString() + "', '" + row["DESCRIPCION 4"].ToString() + "', '" + row["DESCRIPCION 5"].ToString() + "', '" + row["DESCRIPCION 2"].ToString() + ";" + row["DESCRIPCION 3"].ToString() + ";" + row["DESCRIPCION 4"].ToString() + ";" + row["DESCRIPCION 5"].ToString() + "')";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())

                    return false;
                long lastinsertid = Conexion.lastIdInsert();

                strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO, ANULADO) VALUES (";
                strSQL += lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + GlobalFunctions.lCadena(observacion) + "', 1, 0)";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
            }
            //Conexion.cerrar();
            return true;
        }

        public static bool ReingresoCarrito(int entrega, string observacion)
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();

                string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strSQL = "SELECT ID_INVENTARIO_GENERAL_FK AS ID FROM TMP_CARRITO WHERE TIPO = '" + Globals.strRecibirReingreso + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
                if (!Conexion.conectar())
                    return false;
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                //MODIFICAR CUANDO TODOS TENGAN CUENTA
                foreach (DataRow row in dt.Rows)
                {

                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_AREA_ENTREGA_FK, ID_AREA_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION, RECIBIDO, ANULADO) VALUES (" + row["ID"].ToString() + ", " + entrega + ", " + Globals.IdUsername + ", " + Globals.IdArea+ ", " + Globals.IdAreaSelect + ", " + fecha + ", " + fecha + ", '" + observacion + "', 1, 0)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                    strSQL = "UPDATE INVENTARIO_GENERAL SET ID_ESTADO_FK = " + Globals.IdCustodiado + ", ID_USUARIO_POSEE = " + Globals.IdUsername + ", FECHA_POSEE = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row[0].ToString() + "";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strRecibirReingreso + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
                
                Conexion.cerrar();

                MessageBox.Show("Proceso Finalizado");
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }


        public static bool ConfirmarCarrito(string observacion)
        {
            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string strSQL = "";
            try
            {

                DataTable dt = new DataTable();
                strSQL = "SELECT ID_INVENTARIO_GENERAL_FK AS ID FROM TMP_CARRITO WHERE TIPO = '" + Globals.strRecibirConfirmar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
                if (!Conexion.conectar())
                    return false;
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                if (!Conexion.conectar())
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "UPDATE INVENTARIO_HISTORICO SET [FECHA_FIN] = " + fecha + ", [RECIBIDO] = 1, [OBSERVACION_RECIBE] = '" + GlobalFunctions.lCadena(observacion) + "' WHERE ID_INVENTARIO_GENERAL_FK = " + row["ID"].ToString() + " AND FECHA_FIN IS NULL AND RECIBIDO = 0 AND ANULADO = 0";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [ID_USUARIO_POSEE] = " + Globals.IdUsername + ", [FECHA_POSEE] = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString();

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strRecibirConfirmar + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();

                MessageBox.Show("Recibido");
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

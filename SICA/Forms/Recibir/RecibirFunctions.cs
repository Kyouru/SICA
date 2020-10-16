
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace SICA
{
    class RecibirFunctions
    {
        public static string ArmarStrNuevoIngreso(DataGridViewRow row)
        {
            string strSQL;
            strSQL = "INSERT INTO INVENTARIO_GENERAL (NUMERO_DE_CAJA, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, ID_REPORTE_VALORADOS_FK, DESC_CONCAT, FECHA_POSEE, USUARIO_POSEE, CUSTODIADO)";
            strSQL = strSQL + "VALUES(";
            if (row.Cells["NUMERO_CAJA"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["NUMERO_CAJA"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["COD_DEP"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["COD_DEP"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["COD_DOC"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["COD_DOC"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESDE"].Value.ToString() != "")
            {
                strSQL = strSQL + "#" + DateTime.ParseExact(row.Cells["DESDE"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) + "#, ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["HASTA"].Value.ToString() != "")
            {
                strSQL = strSQL + "#" + DateTime.ParseExact(row.Cells["HASTA"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture) + "#, ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESC_1"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESC_1"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESC_2"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESC_2"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESC_3"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESC_3"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }
            if (row.Cells["DESC_4"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["DESC_4"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }

            if (row.Cells["ID_REPORTE"].Value.ToString() != "")
            {
                strSQL = strSQL + "'" + row.Cells["ID_REPORTE"].Value.ToString() + "', ";
            }
            else
            {
                strSQL = strSQL + "NULL, ";
            }

            //DESC_CONCAT
            strSQL = strSQL + "'" + row.Cells["DESC_1"].Value.ToString() + ";" + row.Cells["DESC_2"].Value.ToString() + ";" + row.Cells["DESC_3"].Value.ToString() + ";" + row.Cells["DESC_4"].Value.ToString() + ";', ";
            strSQL = strSQL + "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#, ";
            strSQL = strSQL + "'" + Globals.Username + "', 'CUSTODIADO')";
            return strSQL;

        }

        public static bool ReingresoCarrito(int entrega, string observacion)
        {
            string strSQL = "";
            try
            {
                DataTable dt = new DataTable();
                string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
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

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION, RECIBIDO) VALUES (" + row["ID"].ToString() + ", " + entrega + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', TRUE)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'CUSTODIADO', USUARIO_POSEE = '" + Globals.Username + "', FECHA_POSEE = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row[0].ToString() + "";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false; ;
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

        public static bool RecibirPagare(string id_reporte_valorados, string observacion)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "";
            try
            {
                strSQL = @"INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, FECHA, OBSERVACION_RECIBE)
                            VALUES (" + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + id_reporte_valorados + ", #" + fecha + "#, '" + observacion + "')";

                if (!Conexion.conectar())
                    return false;
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                strSQL = "UPDATE REPORTE_VALORADOS SET PAGARE = 'CUSTODIADO' WHERE ID_REPORTE_VALORADOS = " + id_reporte_valorados;
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();

                MessageBox.Show("Registrado");
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
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
                    strSQL = "UPDATE INVENTARIO_HISTORICO SET [FECHA_FIN] = #" + fecha + "#, [RECIBIDO] = TRUE, [OBSERVACION_RECIBE] = '" + observacion + "' WHERE ID_INVENTARIO_GENERAL_FK = " + row["ID"].ToString() + " AND FECHA_FIN IS NULL AND RECIBIDO = FALSE AND ANULADO = FALSE";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE INVENTARIO_GENERAL SET [USUARIO_POSEE] = '" + Globals.Username + "', [FECHA_POSEE] = #" + fecha + "# WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString();

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

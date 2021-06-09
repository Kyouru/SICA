
using SimpleLogger;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SICA
{
    class EntregarFunctions
    {
        public static bool EntregarExpedientesCarrito (string observacion)
        {
            DataTable dt = new DataTable();

            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";
            int j = 0;
            strSQL = "SELECT TC.ID_INVENTARIO_GENERAL_FK AS ID, '0' AS NRO, DESCRIPCION_1 AS DEFINICION, DESCRIPCION_2 AS SOLICITUD, DESCRIPCION_3 AS COD_PRESTAMO, DESCRIPCION_4 AS NOMBRE_SOCIO";
            strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                        strSQL = strSQL + " WHERE TIPO = '" + Globals.strEntregarExpediente + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
            try
            {

                if (!Conexion.conectar())
                    return false;

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
            try
            {
                foreach (DataRow row in dt.Rows)
                {

                    strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, OBSERVACION, FECHA_FIN, RECIBIDO)
                            VALUES (" + Globals.IdUsername.ToString() + ", " + Globals.IdUsernameSelect.ToString() + ", " + row["ID"].ToString() + ", " + fecha + ", '" + observacion + "',";


                    if (!Globals.EntregarConfirmacion)
                    {
                        strSQL = strSQL + fecha + ", TRUE)";
                    }
                    else
                    {
                        strSQL = strSQL + "NULL, FALSE)";
                    }
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    

                    if (!Conexion.ejecutarQuery())
                        return false;
                    
                    strSQL = "UPDATE INVENTARIO_GENERAL SET [CUSTODIADO] = @estado, [USUARIO_POSEE] = '" + Globals.UsernameSelect + "', [FECHA_POSEE] = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString() + "";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (Globals.EntregarConfirmacion)
                    {
                        if (!Conexion.agregarParametroCommand("@estado", "CUSTODIADO"))
                            return false;
                    }
                    else
                    {
                        if (!Conexion.agregarParametroCommand("@estado", "PRESTADO"))
                            return false;
                    }
                    if (!Conexion.ejecutarQuery())
                        return false;

                    if (!Globals.EntregarConfirmacion)
                    {
                        strSQL = "UPDATE REPORTE_VALORADOS SET [EXPEDIENTE] = 'PRESTADO' WHERE SOLICITUD_SISGO = '" + row["SOLICITUD"].ToString() + "'";
                        if (!Conexion.iniciaCommand(strSQL))
                            return false;

                        if (!Conexion.ejecutarQuery())
                            return false;
                    }

                    j++;
                }

                dt.Columns.Remove("ID");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = i + 1;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = @username_select AND TIPO = @tipo_carrito";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.agregarParametroCommand("@username_select", Globals.IdUsername.ToString()))
                    return false;
                if (!Conexion.agregarParametroCommand("@tipo_carrito", Globals.strEntregarExpediente))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;
                if (!Globals.EntregarConfirmacion)
                {
                    GlobalFunctions.ArmarCargoExcel(dt, "CARGO DE EXPEDIENTES", Globals.CargoPath + "CARGO_EXP_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".csv", true);
                }
                else
                {
                    MessageBox.Show("Pendiente por recibir: " + Globals.UsernameSelect + "\nNro de Expedientes: " + j);
                }

                Conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }

        public static bool EntregarDocumentosCarrito(string observacion)
        {

            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";
            int j = 0;
            DataTable dt = new DataTable();
            try
            {
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, '0' AS NRO, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5";
                strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                strSQL = strSQL + " WHERE TIPO = @tipo_carrito AND ID_USUARIO_FK = @id_usuario";

                if (!Conexion.conectar())
                    return false;

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.agregarParametroCommand("@tipo_carrito", Globals.strEntregarDocumento))
                    return false;
                if (!Conexion.agregarParametroCommand("@id_usuario", Globals.IdUsername.ToString()))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {

                    strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, OBSERVACION, FECHA_FIN, RECIBIDO) 
                            VALUES (" + Globals.IdUsername.ToString() + ", " + Globals.IdUsernameSelect.ToString() + ", " + row["ID"].ToString() + ", " + fecha + ", '" + observacion + "', ";


                    if (!Globals.EntregarConfirmacion)
                    {
                        strSQL = strSQL + fecha + ", TRUE)";
                    }
                    else
                    {
                        strSQL = strSQL + " NULL, FALSE)";
                    }

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (!Conexion.ejecutarQuery())
                    return false;

                    if (!Globals.EntregarConfirmacion)
                    {
                        strSQL = @"UPDATE INVENTARIO_GENERAL SET [CUSTODIADO] = 'PRESTADO', [USUARIO_POSEE] = '" + Globals.UsernameSelect + "', [FECHA_POSEE] = " + fecha
                                + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString() + "";

                        if (!Conexion.iniciaCommand(strSQL))
                            return false;

                        if (!Conexion.ejecutarQuery())
                            return false;
                    }
                    j++;
                }

                dt.Columns.Remove("ID");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = i + 1;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = @username_select AND TIPO = @tipo_carrito";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.agregarParametroCommand("@username_select", Globals.IdUsername.ToString()))
                    return false;
                if (!Conexion.agregarParametroCommand("@tipo_carrito", Globals.strEntregarDocumento))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;
                if (!Globals.EntregarConfirmacion)
                {
                    GlobalFunctions.ArmarCargoExcel(dt, "CARGO DE DOCUMENTOS", Globals.CargoPath + "CARGO_DOC_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".csv", true);
                }
                else
                {
                    MessageBox.Show("Pendiente por recibir: " + Globals.UsernameSelect + "\nNro de Documentos: " + j);
                }

                Conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }

        public static bool EntregarPagaresCarrito(int desembolsado, string observacion)
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";
            DataTable dt = new DataTable();
            try
            {
                if (desembolsado == 1)
                {
                    strSQL = "SELECT TC.ID_AUX_FK AS ID, '0' AS NRO, RV.CIP, RV.NOMBRE, RV.MONTOPRESTAMO, RV.SOLICITUD_SISGO AS SISGO";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN REPORTE_VALORADOS RV ON TC.ID_AUX_FK = RV.ID_REPORTE_VALORADOS";
                    strSQL = strSQL + " WHERE TC.TIPO = '" + Globals.strEntregarPagare + "' AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                }
                else
                {
                    strSQL = "SELECT TC.ID_PAGARE_SIN_DESEMBOLSAR AS ID, '0' AS NRO, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, PSD.SOLICITUD_SISGO AS SISGO";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN PAGARE_SIN_DESEMBOLSAR PSD ON TC.SOLICITUD_SISGO = PSD.SOLICITUD_SISGO";
                    strSQL = strSQL + " WHERE TC.TIPO = '" + Globals.strEntregarPagareSinDesembolsar + "' AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                }

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
                    if (desembolsado == 1)
                    {
                        strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, SOLICITUD_SISGO, FECHA, OBSERVACION_ENTREGA) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", '" + row["SISGO"].ToString() + "', " + fecha + ", '" + observacion + "')";
                    }
                    else
                    {
                        strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_AUX_FK, SOLICITUD_SISGO, FECHA, OBSERVACION_ENTREGA) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", '" + row["SISGO"].ToString() + "', " + fecha + ", '" + observacion + "')";
                    }

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    if (desembolsado == 1)
                    {
                        strSQL = "UPDATE REPORTE_VALORADOS SET [PAGARE] = 'PRESTADO' WHERE ID_REPORTE_VALORADOS = " + row["ID"].ToString();
                    }
                    else
                    {
                        strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_AUX_FK, SOLICITUD_SISGO, FECHA) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", '" + row["SISGO"].ToString() + "', " + fecha + ")";
                    }

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                dt.Columns.Remove("ID");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = i + 1;
                }


                if (desembolsado == 1)
                {
                    strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strEntregarPagare + "'";
                }
                else
                {
                    strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strEntregarPagareSinDesembolsar + "'";
                }

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();

                GlobalFunctions.ArmarCargoExcel(dt, "CARGO DE PAGARES", Globals.CargoPath + "CARGO_PAG_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".csv", true);

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


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

            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string strSQL = "";
            int j = 0;
            strSQL = "SELECT TC.ID_INVENTARIO_GENERAL_FK AS ID, ROW_NUMBER() OVER(ORDER BY ID_INVENTARIO_GENERAL) AS NRO, DESCRIPCION_1 AS DEFINICION, DESCRIPCION_2 AS SOLICITUD, DESCRIPCION_3 AS COD_PRESTAMO, DESCRIPCION_4 AS NOMBRE_SOCIO";
            strSQL += " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                        strSQL += " WHERE TIPO = '" + Globals.strEntregarExpediente + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
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

                    strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, OBSERVACION, FECHA_FIN, RECIBIDO, ANULADO)
                            VALUES (" + Globals.IdUsername.ToString() + ", " + Globals.IdUsernameSelect.ToString() + ", " + row["ID"].ToString() + ", " + fecha + ", '" + observacion + "',";


                    if (!Globals.EntregarConfirmacion)
                    {
                        strSQL += fecha + ", 1, 0)";
                    }
                    else
                    {
                        strSQL += "NULL, 0, 0)";
                    }
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    

                    if (!Conexion.ejecutarQuery())
                        return false;
                    
                    strSQL = "UPDATE INVENTARIO_GENERAL SET [ID_ESTADO_FK] = @estado, [ID_USUARIO_POSEE] = '" + Globals.IdUsername.ToString() + "', [FECHA_POSEE] = " + fecha + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString() + "";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (Globals.EntregarConfirmacion)
                    {
                        //CUSTODIADO
                        if (!Conexion.agregarParametroCommand("@estado", "1"))
                            return false;
                    }
                    else
                    {
                        //PRESTADO
                        if (!Conexion.agregarParametroCommand("@estado", "2"))
                            return false;
                    }
                    if (!Conexion.ejecutarQuery())
                        return false;

                    j++;
                }

                dt.Columns.Remove("ID");

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = @username_select AND TIPO = @tipo_carrito";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.agregarParametroCommand("@username_select", Globals.IdUsername.ToString()))
                    return false;
                if (!Conexion.agregarParametroCommand("@tipo_carrito", Globals.strEntregarExpediente))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;

                GlobalFunctions.ExportarDataTableCSV(dt, Globals.ExportarPath + "CARGO_EXP_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".csv", "CARGO DE EXPEDIENTES", true);

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

            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string strSQL = "";
            int j = 0;
            DataTable dt = new DataTable();
            try
            {
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, ROW_NUMBER() OVER(ORDER BY ID_INVENTARIO_GENERAL) AS NRO, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5";
                strSQL += " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                strSQL += " WHERE TIPO = @tipo_carrito AND ID_USUARIO_FK = @id_usuario";

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

                    strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_AREA_ENTREGA_FK, ID_AREA_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, OBSERVACION, FECHA_FIN, RECIBIDO, ANULADO) 
                            VALUES (" + Globals.IdUsername.ToString() + ", " + Globals.IdUsernameSelect.ToString() + ", " + Globals.IdArea.ToString() + ", " + Globals.IdAreaSelect.ToString() + ", " + row["ID"].ToString() + ", " + fecha + ", '" + observacion + "', ";


                    if (!Globals.EntregarConfirmacion)
                    {
                        strSQL += fecha + ", 1, 0)";
                    }
                    else
                    {
                        strSQL += " NULL, 0, 0)";
                    }

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (!Conexion.ejecutarQuery())
                    return false;

                    if (!Globals.EntregarConfirmacion)
                    {
                        //PRESTADO
                        strSQL = @"UPDATE INVENTARIO_GENERAL SET [ID_ESTADO_FK] = 2, [ID_USUARIO_POSEE] = '" + Globals.IdUsername + "', [FECHA_POSEE] = " + fecha
                                + " WHERE ID_INVENTARIO_GENERAL = " + row["ID"].ToString() + "";

                        if (!Conexion.iniciaCommand(strSQL))
                            return false;

                        if (!Conexion.ejecutarQuery())
                            return false;
                    }
                    j++;
                }

                dt.Columns.Remove("ID");

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = @username_select AND TIPO = @tipo_carrito";

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.agregarParametroCommand("@username_select", Globals.IdUsername.ToString()))
                    return false;
                if (!Conexion.agregarParametroCommand("@tipo_carrito", Globals.strEntregarDocumento))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;

                GlobalFunctions.ExportarDataTableCSV(dt, Globals.ExportarPath + "CARGO_DOC_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".csv", "CARGO DE DOCUMENTOS", true);

                Conexion.cerrar();
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

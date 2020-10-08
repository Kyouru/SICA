
using SimpleLogger;
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
    class EntregarFunctions
    {
        public static bool EntregarExpedientesCarrito ()
        {
            DataTable dt = new DataTable();

            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "";

            strSQL = @"SELECT TC.ID_INVENTARIO_GENERAL_FK AS ID, IG.ID_REPORTE_VALORADOS_FK AS ID_REPORTE, '0' AS '#', DESCRIPCION_1 AS 'DEFINICION'
                        , DESCRIPCION_2 AS 'SOLICITUD', DESCRIPCION_3 AS 'COD. PRESTAMO', DESCRIPCION_4 AS 'NOMBRE SOCIO' FROM TMP_CARRITO TC
                        LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL
                        WHERE TIPO = @tipo_carrito AND ID_USUARIO_FK = @id_usuario";
            try
            {

                if (!Conexion.conectar())
                    return false;

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                if (!Conexion.agregarParametroCommand("@tipo_carrito", Globals.strEntregarExpediente))
                    return false;
                if (!Conexion.agregarParametroCommand("@id_usuario", Globals.IdUsername.ToString()))
                    return false;

                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                Conexion.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.cerrar();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
            try
            {
                foreach (DataRow row in dt.Rows)
                {

                    strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, FECHA_FIN)
                                VALUES (@id_usuario, @usuario_posee, @id_inventario, @fecha_inicio, @fecha_fin)";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (!Conexion.agregarParametroCommand("@id_usuario", Globals.IdUsername.ToString()))
                        return false;
                    if (!Conexion.agregarParametroCommand("@usuario_posee", Globals.IdUsernameSelect.ToString()))
                        return false;
                    if (!Conexion.agregarParametroCommand("@id_inventario", row["ID"].ToString()))
                        return false;
                    if (!Conexion.agregarParametroCommand("@fecha_inicio", fecha))
                        return false;
                    if (!Conexion.agregarParametroCommand("@fecha_fin", fecha))
                        return false;

                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = @"UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'PRESTADO', USUARIO_POSEE = @username_select, FECHA_POSEE = @fecha_posee
                                WHERE ID_INVENTARIO_GENERAL = @id_inventario";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (!Conexion.agregarParametroCommand("@username_select", Globals.UsernameSelect))
                        return false;
                    if (!Conexion.agregarParametroCommand("@fecha_posee", fecha))
                        return false;
                    if (!Conexion.agregarParametroCommand("@id_inventario", row["ID"].ToString()))
                        return false;

                    if (!Conexion.ejecutarQuery())
                        return false;

                    if (row["ID_REPORTE"].ToString() != "")
                    {
                        strSQL = "UPDATE REPORTE_VALORADOS SET EXPEDIENTE = 'PRESTADO' WHERE ID_REPORTE_VALORADOS = @id_reporte";
                        if (!Conexion.iniciaCommand(strSQL))
                            return false;

                        if (!Conexion.agregarParametroCommand("@id_reporte", row["ID_REPORTE"].ToString()))
                            return false;

                        if (!Conexion.ejecutarQuery())
                            return false;
                    }
                }

                dt.Columns.Remove("ID");
                dt.Columns.Remove("ID_REPORTE");

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

                GlobalFunctions.ArmarCargoExcel(dt, Globals.PlantillaCargoExpPath, Globals.CargoPath + "CARGO_EXP_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);

                Conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                Conexion.cerrar();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
        }

        public static bool EntregarDocumentosCarrito()
        {

            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "";
            DataTable dt = new DataTable();
            try
            {
                strSQL = @"SELECT TC.ID_INVENTARIO_GENERAL_FK AS ID, IG.ID_REPORTE_VALORADOS_FK AS ID_REPORTE, '0' AS '#', FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE
                            , FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS 'DESCRIPCION 1', DESCRIPCION_2 AS 'DESCRIPCION 2', DESCRIPCION_3 AS 'DESCRIPCION 3'
                            , DESCRIPCION_4 AS 'DESCRIPCION 4' FROM TMP_CARRITO TC
                            LEFT JOIN INVENTARIO_GENERAL IG ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL
                            WHERE TIPO = @tipo_carrito AND ID_USUARIO_FK = @id_usuario";

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

                    strSQL = @"INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, FECHA_FIN) 
                            VALUES (@id_usuario, @id_usuario_select, @id_inventario, @fecha_inicio, @fecha_fin)";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (!Conexion.agregarParametroCommand("@id_usuario", Globals.IdUsername.ToString()))
                        return false;
                    if (!Conexion.agregarParametroCommand("@id_usuario_select", Globals.IdUsernameSelect.ToString()))
                        return false;
                    if (!Conexion.agregarParametroCommand("@fecha_inicio", fecha))
                        return false;
                    if (!Conexion.agregarParametroCommand("@fecha_fin", fecha))
                        return false;

                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = @"UPDATE INVENTARIO_GENERAL SET CUSTODIADO = 'PRESTADO', USUARIO_POSEE = @usuario_posee, FECHA_POSEE = @fecha_posee
                                WHERE ID_INVENTARIO_GENERAL = @id_inventario";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;

                    if (!Conexion.agregarParametroCommand("@usuario_posee", Globals.UsernameSelect))
                        return false;
                    if (!Conexion.agregarParametroCommand("@fecha_posee", fecha))
                        return false;
                    if (!Conexion.agregarParametroCommand("@id_inventario", Globals.IdUsernameSelect.ToString()))
                        return false;

                    if (!Conexion.ejecutarQuery())
                        return false;

                }

                dt.Columns.Remove("ID");
                dt.Columns.Remove("ID_REPORTE");

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
                GlobalFunctions.ArmarCargoExcel(dt, Globals.PlantillaCargoDocPath, Globals.CargoPath + "CARGO_DOC_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);

                //MessageBox.Show("Proceso Finalizado");
                Conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                Conexion.cerrar();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
        }

        public static bool EntregarPagaresCarrito(int desembolsado)
        {
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "";
            DataTable dt = new DataTable();
            try
            {
                if (desembolsado == 1)
                {
                    strSQL = "SELECT TC.ID_REPORTE_VALORADOS_FK AS ID, '0' AS '#', RV.CIP, RV.NOMBRE, RV.MONTOPRESTAMO, RV.SOLICITUD_SISGO AS 'SISGO'";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN REPORTE_VALORADOS RV ON TC.ID_REPORTE_VALORADOS_FK = RV.ID_REPORTE_VALORADOS";
                    strSQL = strSQL + " WHERE TC.TIPO = '" + Globals.strEntregarPagare + "' AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                }
                else
                {
                    strSQL = "SELECT TC.ID_PAGARE_SIN_DESEMBOLSAR AS ID, '0' AS '#', DESCRIPCION_2 AS 'DESCRIPCION 2', DESCRIPCION_3 AS 'DESCRIPCION 3', DESCRIPCION_4 AS 'DESCRIPCION 4', PSD.SOLICITUD_SISGO AS 'SISGO'";
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
                        strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, SOLICITUD_SISGO, FECHA) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", '" + row["SISGO"].ToString() + "', " + fecha + ")";
                    }
                    else
                    {
                        strSQL = "INSERT INTO PAGARE_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_REPORTE_VALORADOS_FK, SOLICITUD_SISGO, FECHA) VALUES (" + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", '" + row["SISGO"].ToString() + "', " + fecha + ")";
                    }

                    if (!Conexion.iniciaCommand(strSQL))
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

                GlobalFunctions.ArmarCargoExcel(dt, Globals.PlantillaCargoPagPath, Globals.CargoPath + "CARGO_PAG_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 4, 1, true);

                //MessageBox.Show("Proceso Finalizado");
                Conexion.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                Conexion.cerrar();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message + "\n" + strSQL);
                return false;
            }
        }


    }
}

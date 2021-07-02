﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Pagare
{
    class PagareFunctions
    {
        public static bool RecibirPagareCarrito()
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";

            try
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                DataTable dt = new DataTable();

                strSQL = "SELECT TC.ID_AUX_FK, SOLICITUD_SISGO, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, USUARIO_POSEE FROM TMP_CARRITO TC";
                strSQL += " LEFT JOIN PAGARE PA ON TC.ID_AUX_FK = PA.ID_PAGARE";
                strSQL += " WHERE TIPO = '" + Globals.strPagareRecibir + "' AND ID_USUARIO_FK = " + Globals.IdUsername;

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
                    strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO) VALUES (";
                    strSQL += Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + row["ID"].ToString() + ", " + fecha + ", " + fecha + ", '" + observacion + "', TRUE)";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "UPDATE PAGARE SET [USUARIO_POSEE] = '" + Globals.UsernameSelect + "' WHERE ID_PAGARE = " + row["ID_AUX_FK"].ToString();
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strPagareRecibir + "'";
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
        public static bool EntregarPagareCarrito()
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";

            try
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                DataTable dt = new DataTable();

                strSQL = "SELECT TC.ID_AUX_FK, SOLICITUD_SISGO, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, USUARIO_POSEE FROM TMP_CARRITO TC";
                strSQL += " LEFT JOIN PAGARE PA ON TC.ID_AUX_FK = PA.ID_PAGARE";
                strSQL += " WHERE TIPO = '" + Globals.strPagareEntregar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;

                if (!Conexion.conectar())
                    return false;
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                strSQL = "SELECT * FROM USUARIO WHERE CUSTODIA = TRUE AND ID_USUARIO = " + Globals.IdUsernameSelect;

                if (!Conexion.iniciaCommand(strSQL))
                    return false;

                string recibido;
                if (Conexion.ejecutarQueryReturn() > 0)
                {
                    recibido = "FALSE";
                }
                else
                {
                    recibido = "TRUE";
                }

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO) VALUES (";
                    strSQL += Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + row["ID"].ToString() + ", " + fecha + ", " + fecha + ", '" + observacion + "', " + recibido +")";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strPagareEntregar + "'";
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
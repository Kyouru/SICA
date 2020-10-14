using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Letras
{
    class LetrasFunctions
    {
        public static bool EntregarCarrito(string observacion)
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";
            try
            {

                DataTable dt = new DataTable();
                strSQL = "SELECT ID_INVENTARIO_GENERAL_FK AS ID FROM TMP_CARRITO WHERE TIPO = '" + Globals.strLetrasEntregar + "' AND ID_USUARIO_FK = " + Globals.IdUsername;
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
                    strSQL = "UPDATE LETRA SET [ESTADO] = 'DEVUELTO', [UBICACION] = 'DEVUELTO' WHERE ID_LETRA = " + row["ID"].ToString();

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;

                    strSQL = "INSERT INTO LETRA_HISTORICO (ID_LETRA_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_ENTREGA)";
                    strSQL = strSQL + " VALUES (" + row["ID"].ToString() + ", " + Globals.IdUsername + ", " + Globals.IdUsernameSelect + ", " + fecha + ", " + fecha + ", '" + observacion + "')";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                strSQL = "DELETE FROM TMP_CARRITO WHERE ID_USUARIO_FK = " + Globals.IdUsername + " AND TIPO = '" + Globals.strLetrasEntregar + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;

                Conexion.cerrar();

                MessageBox.Show("Entregado");
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

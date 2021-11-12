using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Busqueda.Historico
{
    public partial class HistoricoEdicion : Form
    {
        public HistoricoEdicion()
        {
            InitializeComponent();
        }

        private void HistoricoEdicion_Load(object sender, EventArgs e)
        {

            string strSQL = "SELECT FECHA_MODIFICACION, U.NOMBRE_USUARIO AS USUARIO_MODIFICA, DEP.NOMBRE_DEPARTAMENTO AS DEPART, DOC.NOMBRE_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, NUMERO_CAJA";
            strSQL += " FROM ((INVENTARIO_ANTERIOR IA LEFT JOIN USUARIO U ON IA.ID_USUARIO_FK = U.ID_USUARIO)";
            strSQL += " LEFT JOIN LDEPARTAMENTO DEP ON IA.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO)";
            strSQL += " LEFT JOIN LDOCUMENTO DOC ON IA.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO";
            strSQL += " WHERE IA.ID_INVENTARIO_GENERAL_FK = " + Globals.IdInventario;
            strSQL += " UNION ALL";
            strSQL += " SELECT FECHA_MODIFICACION, U.NOMBRE_USUARIO AS USUARIO_MODIFICA, DEP.NOMBRE_DEPARTAMENTO AS DEPART, DOC.NOMBRE_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, NUMERO_CAJA";
            strSQL += " FROM (((INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON IG.ID_USUARIO_CREA = U.ID_USUARIO)";
            strSQL += " LEFT JOIN LDEPARTAMENTO DEP ON IG.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO)";
            strSQL += " LEFT JOIN LDOCUMENTO DOC ON IG.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO";
            strSQL += " WHERE IG.ID_INVENTARIO_GENERAL = " + Globals.IdInventario;
            strSQL += " ORDER BY FECHA_MODIFICACION ASC";
            DataTable dt = new DataTable();

            try
            {
                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;

            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }
    }
}

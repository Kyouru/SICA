using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class HistoricoForm : Form
    {
        public HistoricoForm()
        {
            InitializeComponent();
        }

        private void HistoricoForm_Load(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable("HISTORIAL");

            try
            {
                LoadingScreen.iniciarLoading();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, U1.USERNAME AS ENTREGA, U2.USERNAME AS RECIBE, FORMAT(FECHA_INICIO, 'dd/MM/yyyy hh:mm:ss') AS FECHA_ENTREGA, FORMAT(FECHA_FIN, 'dd/MM/yyyy hh:mm:ss') AS FECHA_RECIBE, NUMERO_CAJA";
                strSQL = strSQL + " FROM ((INVENTARIO_HISTORICO IH LEFT JOIN USUARIO U1 ON IH.ID_USUARIO_ENTREGA_FK = U1.ID_USUARIO) LEFT JOIN USUARIO U2 ON IH.ID_USUARIO_RECIBE_FK = U2.ID_USUARIO) LEFT JOIN INVENTARIO_GENERAL IG ON IG.ID_INVENTARIO_GENERAL = IH.ID_INVENTARIO_GENERAL_FK WHERE IH.ANULADO = FALSE AND IH.RECIBIDO = TRUE AND IG.ID_INVENTARIO_GENERAL = " + Globals.idInventarioGeneral;
                strSQL = strSQL + " ORDER BY FECHA_INICIO";

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

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }
    }
}

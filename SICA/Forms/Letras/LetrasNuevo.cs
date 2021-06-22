using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Letras
{
    public partial class LetrasNuevo : Form
    {
        public LetrasNuevo()
        {
            InitializeComponent();
        }

        private void btBuscarXLS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro Excel 97-2003 (*.xls)|*.xls|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();
                dt = GlobalFunctions.ConvertExcelToDataTableOld(ofd.FileName, 0);
                if (dt is null)
                    return;

                dgv.DataSource = dt;

                LoadingScreen.cerrarLoading();
                btCargar.Visible = true;
                //MessageBox.Show(dgv.Rows.Count + " documentos encontrados");
            }
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            try
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                if (!Conexion.conectar())
                    return;

                string strSQL = "";
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    strSQL = "INSERT INTO LETRA (SOCIO, NOMBRE, SOLICITUD, N_LIQ, NUMERO, F_GIRO, F_VENCIMIENTO, IMPORTE, ACEPTANTE, MD, ESTADO, UBICACION, FECHA_ESTADO, OBSERVACION, CONCATENADO) VALUES ";
                    strSQL = strSQL + " ('" + row.Cells["SOCIO"].Value.ToString() + "',";
                    strSQL = strSQL + " '" + row.Cells["NOMBRE"].Value.ToString() + "',";
                    strSQL = strSQL + " '" + row.Cells["SOLICITUD"].Value.ToString() + "',";
                    strSQL = strSQL + " '" + row.Cells["N_LIQ"].Value.ToString() + "',";
                    strSQL = strSQL + " '" + row.Cells["NUMERO"].Value.ToString() + "',";
                    strSQL = strSQL + " #" + row.Cells["F_GIRO"].Value.ToString() + "#,";
                    strSQL = strSQL + " #" + row.Cells["F_VENCIMIENTO"].Value.ToString() + "#,";
                    strSQL = strSQL + " " + row.Cells["IMPORTE"].Value.ToString() + ",";
                    strSQL = strSQL + " '" + row.Cells["ACEPTANTE"].Value.ToString() + "',";
                    strSQL = strSQL + " '" + row.Cells["MD"].Value.ToString() + "',";
                    strSQL = strSQL + " 'CUSTODIADO',";
                    strSQL = strSQL + " 'SAN ISIDRO',";
                    strSQL = strSQL + " #" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#,";
                    strSQL = strSQL + " '" + observacion + "',";
                    strSQL = strSQL + " '" + row.Cells["SOCIO"].Value.ToString() + ";" + row.Cells["NOMBRE"].Value.ToString() + ";" + row.Cells["SOLICITUD"].Value.ToString() + ";" + row.Cells["ACEPTANTE"].Value.ToString() + "')";

                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                }
                Conexion.cerrar();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
            }
        }
    }
}

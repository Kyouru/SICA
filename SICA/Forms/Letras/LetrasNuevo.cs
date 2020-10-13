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
                dt = GlobalFunctions.ConvertExcelToDataTable(ofd.FileName, 0);
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
                if (!Conexion.conectar())
                    return;

                string strSQL = "";
                foreach (DataRow row in dgv.Rows)
                {
                    strSQL = "INSERT INTO LETRA (SOCIO, NOMBRE, SOLICITUD, N_LIQ, NUMERO, F_GIRO, F_VENCIMIENTO, IMPORTE, ACEPTANTE, MD, ESTADO, UBICACION, FECHA_ESTADO, OBSERVACION, CONCATENADO) VALUES ";
                    strSQL = strSQL + " ('" + row["SOCIO"] + "',";
                    strSQL = strSQL + " '" + row["NOMBRE"] + "',";
                    strSQL = strSQL + " '" + row["SOLICITUD"] + "',";
                    strSQL = strSQL + " '" + row["N_LIQ"] + "',";
                    strSQL = strSQL + " '" + row["NUMERO"] + "',";
                    strSQL = strSQL + " #" + row["F_GIRO"] + "#,";
                    strSQL = strSQL + " #" + row["F_VENCIMIENTO"] + "#,";
                    strSQL = strSQL + " " + row["IMPORTE"] + ",";
                    strSQL = strSQL + " '" + row["ACEPTANTE"] + "',";
                    strSQL = strSQL + " '" + row["MD"] + "',";
                    strSQL = strSQL + " '" + row["ESTADO"] + "',";
                    strSQL = strSQL + " '" + row["UBICACION"] + "',";
                    strSQL = strSQL + " #" + row["FECHA_ESTADO"] + "#,";
                    strSQL = strSQL + " '" + row["OBSERVACION"] + "',";
                    strSQL = strSQL + " '" + row["SOCIO"] + ";" + row["NOMBRE"] + ";" + row["SOLICITUD"] + ";" + row["N_LIQ"] + "')";

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

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
        string[] arrCabecera = new string[] { "SOCIO", "NOMBRE", "SOLICITUD", "N_LIQ", "NUMERO", "F_GIRO", "F_VENCIMIENTO", "IMPORTE", "ACEPTANTE", "MD" };

        public LetrasNuevo()
        {
            InitializeComponent();
        }

        private void btBuscarCargo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Libro de Excel|*.xlsx;*.xls|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //LoadingScreen.iniciarLoading();
                bool cabeceraValida = true;
                DataTable dt;
                dt = GlobalFunctions.ConvertExcelToDataTable(ofd.FileName, 1);
                if (dt is null)
                    return;

                foreach (DataColumn col in dt.Columns)
                {
                    if (!arrCabecera.Contains(col.ColumnName))
                    {
                        MessageBox.Show(col.ColumnName);
                        cabeceraValida = false;
                    }
                }
                
                if (cabeceraValida)
                {
                    dgv.DataSource = dt;
                    btCargar.Visible = true;
                    LoadingScreen.cerrarLoading();
                }
                else
                {
                    LoadingScreen.cerrarLoading();
                    MessageBox.Show("Cabecera Incorrecta");
                }
            }
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            try
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observación (opcional):", "Observación", "");
                if (!Conexion.conectar())
                    return;

                string strSQL = "";
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    strSQL = "INSERT INTO LETRA (SOCIO, NOMBRE, SOLICITUD, N_LIQ, NUMERO, F_GIRO, F_VENCIMIENTO, IMPORTE, ACEPTANTE, MD, ESTADO, UBICACION, FECHA_ESTADO, OBSERVACION, CONCATENADO) VALUES ";
                    strSQL += " ('" + row.Cells["SOCIO"].Value.ToString() + "',";
                    strSQL += " '" + row.Cells["NOMBRE"].Value.ToString() + "',";
                    strSQL += " '" + row.Cells["SOLICITUD"].Value.ToString() + "',";
                    strSQL += " '" + row.Cells["N_LIQ"].Value.ToString() + "',";
                    strSQL += " '" + row.Cells["NUMERO"].Value.ToString() + "',";
                    strSQL += " '" + row.Cells["F_GIRO"].Value.ToString() + "',";
                    strSQL += " '" + row.Cells["F_VENCIMIENTO"].Value.ToString() + "',";
                    strSQL += " " + double.Parse(row.Cells["IMPORTE"].Value.ToString().Trim()) + ",";
                    strSQL += " '" + row.Cells["ACEPTANTE"].Value.ToString() + "',";
                    strSQL += " '" + row.Cells["MD"].Value.ToString() + "',";
                    strSQL += " 'CUSTODIADO',";
                    strSQL += " 'SAN ISIDRO',";
                    strSQL += " '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',";
                    strSQL += " '" + observacion + "',";
                    strSQL += " '" + row.Cells["SOCIO"].Value.ToString() + ";" + row.Cells["NOMBRE"].Value.ToString() + ";" + row.Cells["SOLICITUD"].Value.ToString() + ";" + row.Cells["ACEPTANTE"].Value.ToString() + "')";

                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                }
                Conexion.cerrar();
                MessageBox.Show("Proceso Completado");
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, "");
            }
        }
    }
}

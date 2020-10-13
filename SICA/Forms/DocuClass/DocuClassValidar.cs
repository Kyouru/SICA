using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.DocuClass
{
    public partial class DocuClassValidar : Form
    {
        public DocuClassValidar()
        {
            InitializeComponent();
        }

        private void btBuscarCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma-Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            string strSQL = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();
                dt = GlobalFunctions.ConvertCsvToDataTable(ofd.FileName);
                if (dt is null)
                    return;

                DataTable dt2 = new DataTable("INVENTARIO_GENERAL");

                if (!Conexion.conectar())
                    return;

                strSQL = "SELECT NUMERO_DE_CAJA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4 FROM INVENTARIO_GENERAL WHERE USUARIO_POSEE = 'DOCUCLASS'";

                if (!Conexion.iniciaCommand(strSQL))
                    return;
                if (!Conexion.ejecutarQuery())
                    return;

                dt2 = Conexion.llenarDataTable();
                if (dt2 is null)
                    return;


                var result = from c1 in dt.AsEnumerable()
                             join c2 in dt2.AsEnumerable() on c1.Field<string>("DESCRIPCION 2") equals c2.Field<string>("SOLICITUD_SISGO") into j
                             from p in j.DefaultIfEmpty()
                             select new
                             {
                                 STATUS = c1.Field<string>("STATUS"),
                                 DESC_1 = c1.Field<string>("DESCRIPCION 1"),
                                 DESC_2 = c1.Field<string>("DESCRIPCION 2"),
                                 DESC_3 = c1.Field<string>("DESCRIPCION 3"),
                                 DESC_4 = c1.Field<string>("DESCRIPCION 4"),
                                 DESEMBOLSADO = p is null ? "NO DESEMBOLSADO" : "DESEMBOLSADO",
                                 EXP_INGRESA = c1.Field<string>("EXPEDIENTE"),
                                 PAG_INGRESA = c1.Field<string>("PAGARE"),
                                 DESDE = c1.Field<string>("FECHA DESDE"),
                                 HASTA = c1.Field<string>("FECHA HASTA"),
                                 NUMERO_CAJA = c1.Field<string>("NUMERO DE CAJA IRON MOUNTAIN"),
                                 COD_DEP = c1.Field<string>("CODIGO DEPARTAMENTO"),
                                 COD_DOC = c1.Field<string>("CODIGO DOCUMENTO")
                             };

                dgv.DataSource = result.ToList();

                LoadingScreen.cerrarLoading();

                //MessageBox.Show(dgv.Rows.Count + " documentos encontrados");
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }
    }
}

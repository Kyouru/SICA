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

        private void btValidarDatosCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma-Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            string strSQL = "";
            int cant = 0;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();
                dt = GlobalFunctions.ConvertCsvToDataTable2(ofd.FileName);
                if (dt is null)
                    return;

                DataTable dt2 = new DataTable("REPORTE_VALORADOS");

                if (!Conexion.conectar())
                    return;
                strSQL = "SELECT CIP, NOMBRE, NUMERO_DOCUMENTO, MONEDA, SOLICITUD_SISGO, LEFT(TIPO_PRESTAMO, 3) AS TIPO_PRESTAMO FROM REPORTE_VALORADOS";

                if (!Conexion.iniciaCommand(strSQL))
                    return;
                if (!Conexion.ejecutarQuery())
                    return;

                dt2 = Conexion.llenarDataTable();
                if (dt2 is null)
                    return;


                var result = from c1 in dt.AsEnumerable()
                             join c2 in dt2.AsEnumerable() on c1.Field<string>("Nro de Solicitud") equals c2.Field<string>("SOLICITUD_SISGO") into j
                             from p in j.DefaultIfEmpty()
                             select new
                             {
                                 ID_DOCU = c1.Field<string>("ID"),
                                 SOCIO_DOCU = c1.Field<string>("Codigo de Socio"),
                                 SOCIO_BD = p is null ? "" : p.Field<string>("CIP"),
                                 NOMBRE_DOCU = c1.Field<string>("Nombre de Socio"),
                                 NOMBRE_BD = p is null ? "" : p.Field<string>("NOMBRE"),
                                 SISGO_DOCU = c1.Field<string>("Nro de Solicitud"),
                                 SISGO_BD = p is null ? "" : p.Field<string>("SOLICITUD_SISGO"),
                                 MD_DOCU = c1.Field<string>("Moneda"),
                                 MD_BD = p is null ? "" : p.Field<string>("MONEDA"),
                                 TIPO_DOCU = c1.Field<string>("Tipo de Prestamo"),
                                 TIPO_BD = p is null ? "" : p.Field<string>("TIPO_PRESTAMO"),
                                 FECHA = c1.Field<string>("Archived Date")
                             };

                dgv.DataSource = result.ToList();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["SISGO_BD"].Value.ToString() == "")
                    {
                        cant++;
                    }
                }

                LoadingScreen.cerrarLoading();
                if (cant > 0)
                {
                    MessageBox.Show(cant + " documentos NO encontrados");
                }
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void DocuClassValidar_Load(object sender, EventArgs e)
        {
            string strSQL = "";

            DataTable dt = new DataTable();

            try
            {
                strSQL = "SELECT DISTINCT NUMERO_DE_CAJA FROM INVENTARIO_GENERAL WHERE USUARIO_POSEE = 'DOCUCLASS'";

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                {
                    Conexion.cerrar();
                    return;
                }

                if (!Conexion.ejecutarQuery())
                {
                    Conexion.cerrar();
                    return;
                }

                dt = Conexion.llenarDataTable();
                if (dt is null)
                {
                    Conexion.cerrar();
                    return;
                }

                Conexion.cerrar();

                cmbCaja.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbCaja.Items.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }

        private void btValidarCaja_Click(object sender, EventArgs e)
        {
            if (cmbCaja.SelectedIndex >= 0)
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
                    dt = GlobalFunctions.ConvertCsvToDataTable2(ofd.FileName);
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


                    var result = from c1 in dt2.AsEnumerable()
                                 join c2 in dt.AsEnumerable() on c1.Field<string>("DESCRIPCION_2") equals c2.Field<string>("Nro de Solicitud") into j
                                 from p in j.DefaultIfEmpty()
                                 select new
                                 {
                                     DESC_1 = c1.Field<string>("DESCRIPCION_1"),
                                     DESC_2 = c1.Field<string>("DESCRIPCION_2"),
                                     DESC_3 = c1.Field<string>("DESCRIPCION_3"),
                                     DESC_4 = c1.Field<string>("DESCRIPCION_4"),
                                     DOCU_SISGO = p is null ? null : p.Field<string>("Nro de Solicitud"),
                                     FECHA_SUBIDO = p is null ? null : p.Field<string>("Archived Date")
                                 };

                    var result2 = from c1 in result
                                  group c1.DOCU_SISGO by new { X1 = c1.DESC_1, X2 = c1.DESC_2, X3 = c1.DESC_3, X4 = c1.DESC_4, X5 = c1.DOCU_SISGO } into j
                                  from p in j.DefaultIfEmpty()
                                  select new
                                  {
                                      DESC_1 = j.Key.X1,
                                      DESC_2 = j.Key.X2,
                                      DESC_3 = j.Key.X3,
                                      DESC_4 = j.Key.X4,
                                      N_DOCUMENTOS = j.Key.X5 is null? 0 : j.Count()
                                  };

                    dgv.DataSource = result2.Distinct().ToList();

                    LoadingScreen.cerrarLoading();
                }
            }
        }
    }
}


using SICA.Forms;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SICA
{
    public partial class ImportarForm : Form
    {
        public ImportarForm()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            btCargarVigentes.Visible = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma-Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();
                dt = GlobalFunctions.ConvertCsvToDataTable(ofd.FileName);
                if (dt is null)
                    return;
                DataTable dt2 = new DataTable("REPORTE_VALORADOS");
                dt2 = GlobalFunctions.ConvertReporteValoradosToDataTable("SELECT ID_REPORTE_VALORADOS, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, FORMAT(FECHA_OTORGADO, 'dd/MM/yyyy') AS FECHA_OTORGADO, FORMAT(FECHA_CANCELACION, 'dd/MM/yyyy') AS FECHA_CANCELACION, TIPO_PRESTAMO FROM REPORTE_VALORADOS");
                if (dt2 is null)
                    return;

                var result = from c1 in dt.AsEnumerable()
                             join c2 in dt2.AsEnumerable() on new { X1 = c1.Field<string>("PERIODO_SOLICITUD"), X2 = c1.Field<string>("NUMERO_SOLICITUD") } equals new { X1 = c2.Field<string>("PERIODO_SOLICITUD"), X2 = c2.Field<string>("NUMERO_SOLICITUD") } into j
                             from c2 in j.DefaultIfEmpty()
                             where c2 == null
                             select new
                             {
                                 CIP = c1.Field<string>("CIP"),
                                 NOMBRE = c1.Field<string>("NOMBRE"),
                                 MONTO = c1.Field<double>("MONTOPRESTAMO"),
                                 PERIODO = c1.Field<string>("PERIODO_SOLICITUD"),
                                 NUMERO = c1.Field<string>("NUMERO_SOLICITUD"),
                                 MD = c1.Field<string>("MONEDA"),
                                 OTORGADO = c1.Field<string>("FECHA_OTORGADO"),
                                 CANCELACION = c1.Field<string>("FECHA_CANCELACION"),
                                 TIPO = c1.Field<string>("TIPO_PRESTAMO"),
                                 SISGO = c1.Field<string>("PERIODO_SOLICITUD") + "-" + (("000" + c1.Field<string>("NUMERO_SOLICITUD")).Substring(("000" + c1.Field<string>("NUMERO_SOLICITUD")).Length - 7, 7)).Substring(0, 2) + "-" + c1.Field<string>("NUMERO_SOLICITUD").Substring(c1.Field<string>("NUMERO_SOLICITUD").Length - 5, 5)
                             };
                dgvDesembolsado.DataSource = result.ToList();
                btCargarVigentes.Visible = true;

                LoadingScreen.cerrarLoading();

                MessageBox.Show(dgvDesembolsado.Rows.Count + " nuevos expedientes");
            }
        }

        private void btBuscarCancelados_Click(object sender, EventArgs e)
        {
            btCargarCancelados.Visible = false;
            btActualizarCancelados.Visible = false;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma-Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable();
                dt = GlobalFunctions.ConvertCsvToDataTable(ofd.FileName);
                if (dt is null)
                    return;

                DataTable dt2 = new DataTable("REPORTE_VALORADOS");
                dt2 = GlobalFunctions.ConvertReporteValoradosToDataTable("SELECT ID_REPORTE_VALORADOS, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, FORMAT(FECHA_OTORGADO, 'dd/MM/yyyy') AS FECHA_OTORGADO, FORMAT(FECHA_CANCELACION, 'dd/MM/yyyy') AS FECHA_CANCELACION, TIPO_PRESTAMO FROM REPORTE_VALORADOS");
                if (dt2 is null)
                    return;

                var result = from c1 in dt.AsEnumerable()
                                join c2 in dt2.AsEnumerable() on new { X1 = c1.Field<string>("PERIODO_SOLICITUD"), X2 = c1.Field<string>("NUMERO_SOLICITUD") } equals new { X1 = c2.Field<string>("PERIODO_SOLICITUD"), X2 = c2.Field<string>("NUMERO_SOLICITUD") } into j
                                from c2 in j.DefaultIfEmpty()
                                where c2 == null
                                select new
                                {
                                    CIP = c1.Field<string>("CIP"),
                                    NOMBRE = c1.Field<string>("NOMBRE"),
                                    MONTO = c1.Field<double>("MONTOPRESTAMO"),
                                    PERIODO = c1.Field<string>("PERIODO_SOLICITUD"),
                                    NUMERO = c1.Field<string>("NUMERO_SOLICITUD"),
                                    MD = c1.Field<string>("MONEDA"),
                                    OTORGADO = c1.Field<string>("FECHA_OTORGADO"),
                                    CANCELACION = c1.Field<string>("FECHA_CANCELACION"),
                                    TIPO = c1.Field<string>("TIPO_PRESTAMO"),
                                    SISGO = c1.Field<string>("PERIODO_SOLICITUD") + "-" + (("0000000" + c1.Field<string>("NUMERO_SOLICITUD")).Substring(("0000000" + c1.Field<string>("NUMERO_SOLICITUD")).Length - 7, 7)).Substring(0, 2) + "-" + c1.Field<string>("NUMERO_SOLICITUD").Substring(c1.Field<string>("NUMERO_SOLICITUD").Length - 5, 5)
                                };
                if (result.ToList().Count > 0)
                {
                    dgvCancelados.DataSource = result.ToList();
                    dgvCancelados.Columns[1].Width = 300;
                    btCargarCancelados.Visible = true;

                    LoadingScreen.cerrarLoading();
                    MessageBox.Show("Se Encontró " + result.ToList().Count.ToString() + " Créditos Cancelados que no se encuentran en la BD");
                }
                else
                {
                    DataTable dt3 = new DataTable("REPORTE_VALORADOS_VIGENTES");
                    dt3 = GlobalFunctions.ConvertReporteValoradosToDataTable("SELECT ID_REPORTE_VALORADOS, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, FORMAT(FECHA_OTORGADO, 'dd/MM/yyyy') AS FECHA_OTORGADO, FORMAT(FECHA_CANCELACION, 'dd/MM/yyyy') AS FECHA_CANCELACION, TIPO_PRESTAMO FROM REPORTE_VALORADOS WHERE FECHA_CANCELACION = ''");
                    if (dt3 is null)
                        return;
                    var result2 = from c1 in dt.AsEnumerable()
                                    join c2 in dt3.AsEnumerable() on new { X1 = c1.Field<string>("PERIODO_SOLICITUD"), X2 = c1.Field<string>("NUMERO_SOLICITUD") } equals new { X1 = c2.Field<string>("PERIODO_SOLICITUD"), X2 = c2.Field<string>("NUMERO_SOLICITUD") }
                                    where string.IsNullOrEmpty(c2.Field<string>("FECHA_CANCELACION"))
                                    select new
                                    {
                                        ID = c2.Field<int>("ID_REPORTE_VALORADOS"),
                                        CIP = c1.Field<string>("CIP"),
                                        NOMBRE = c1.Field<string>("NOMBRE"),
                                        MONTO = c1.Field<double>("MONTOPRESTAMO"),
                                        PERIODO = c1.Field<string>("PERIODO_SOLICITUD"),
                                        NUMERO = c1.Field<string>("NUMERO_SOLICITUD"),
                                        MD = c1.Field<string>("MONEDA"),
                                        OTORGADO = c1.Field<string>("FECHA_OTORGADO"),
                                        CANCELACION = c1.Field<string>("FECHA_CANCELACION"),
                                        TIPO = c1.Field<string>("TIPO_PRESTAMO"),
                                        SISGO = c1.Field<string>("PERIODO_SOLICITUD") + "-" + (("0000000" + c1.Field<string>("NUMERO_SOLICITUD")).Substring(("0000000" + c1.Field<string>("NUMERO_SOLICITUD")).Length - 7, 7)).Substring(0, 2) + "-" + c1.Field<string>("NUMERO_SOLICITUD").Substring(c1.Field<string>("NUMERO_SOLICITUD").Length - 5, 5)
                                    };

                    dgvCancelados.DataSource = result2.ToList();
                    dgvCancelados.Columns[0].Visible = false;
                    dgvCancelados.Columns[1].Width = 50;
                    dgvCancelados.Columns[2].Width = 300;
                    btActualizarCancelados.Visible = true;

                    LoadingScreen.cerrarLoading();
                    MessageBox.Show(dgvCancelados.Rows.Count + " expedientes cancelados");
                }
            }
        }

        private void btActualizarCancelados_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            LoadingScreen.iniciarLoading();

            try
            {
                foreach (DataGridViewRow row in dgvCancelados.Rows)
                {
                    strSQL = "UPDATE REPORTE_VALORADOS SET FECHA_CANCELACION = ";
                    try
                    {
                        strSQL = strSQL + "'" + DateTime.ParseExact(row.Cells["CANCELACION"].Value.ToString(), "dd/mm/yy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' WHERE ID_REPORTE_VALORADOS = " + row.Cells["ID"].Value;
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                        return;
                    }
                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                }

                Conexion.cerrar();
                LoadingScreen.cerrarLoading();

                MessageBox.Show("Actualizacion Finalizada");
                dgvCancelados.DataSource = null;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void btCargarVigentes_Click(object sender, EventArgs e)
        {

            CargarReporteValorados(dgvDesembolsado);
        }

        private void btCargarCancelados_Click(object sender, EventArgs e)
        {
            CargarReporteValorados(dgvCancelados);
        }

        private void CargarReporteValorados(DataGridView dgv)
        {
            
            String strSQL = "";
            LoadingScreen.iniciarLoading();

            try
            {
                if (!Conexion.conectar())
                    return;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    strSQL = "INSERT INTO REPORTE_VALORADOS (CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, FECHA_OTORGADO, FECHA_CANCELACION, TIPO_PRESTAMO, SOLICITUD_SISGO, CONCATENADO) VALUES (";

                    strSQL = strSQL + "'" + row.Cells["CIP"].Value.ToString() + "', ";
                    strSQL = strSQL + "'" + row.Cells["NOMBRE"].Value.ToString().Replace("'", "''") + "', ";
                    strSQL = strSQL + row.Cells["MONTO"].Value.ToString() + ", ";
                    strSQL = strSQL + "'" + row.Cells["PERIODO"].Value.ToString() + "', ";
                    strSQL = strSQL + "'" + row.Cells["NUMERO"].Value.ToString() + "', ";
                    strSQL = strSQL + "'" + row.Cells["MD"].Value.ToString() + "', ";
                    strSQL = strSQL + "'" + DateTime.Parse(row.Cells["OTORGADO"].Value.ToString()).ToString("yyyy-MM-dd") + "', ";
                    if (row.Cells["CANCELACION"].Value is null)
                    {
                        strSQL = strSQL + "NULL, ";
                    }
                    else
                    {
                        strSQL = strSQL + "'" + DateTime.Parse(row.Cells["CANCELACION"].Value.ToString()).ToString("yyyy-MM-dd") + "', ";
                    }
                    strSQL = strSQL + "'" + row.Cells["TIPO"].Value.ToString() + "', ";
                    strSQL = strSQL + "'" + row.Cells["SISGO"].Value.ToString() + "', ";
                    strSQL = strSQL + "'" + row.Cells["CIP"].Value.ToString() + ";" + row.Cells["NOMBRE"].Value.ToString().Replace("'", "''") + ";" + row.Cells["SISGO"].Value.ToString() + ";" + row.Cells["TIPO"].Value.ToString() + "')";

                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                }
                Conexion.cerrar();
                LoadingScreen.cerrarLoading();
                MessageBox.Show("Carga Finalizada");
                dgv.DataSource = null;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }

        }
    }
}

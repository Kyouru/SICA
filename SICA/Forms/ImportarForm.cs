using Microsoft.VisualBasic;
using SICA.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                GlobalFunctions.iniciarLoading();

                DataTable dt = new DataTable();
                dt = GlobalFunctions.ConvertCsvToDataTable(ofd.FileName);

                DataTable dt2 = new DataTable("REPORTE_VALORADOS");
                dt2 = GlobalFunctions.ConvertReporteValoradosToDataTable("SELECT ID_REPORTE_VALORADOS, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS FECHA_OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS FECHA_CANCELACION, TIPO_PRESTAMO FROM REPORTE_VALORADOS");

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

                Globals.t.Abort();

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
                GlobalFunctions.iniciarLoading();
                DataTable dt = new DataTable();
                dt = GlobalFunctions.ConvertCsvToDataTable(ofd.FileName);

                using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    DataTable dt2 = new DataTable("REPORTE_VALORADOS");
                    dt2 = GlobalFunctions.ConvertReporteValoradosToDataTable("SELECT ID_REPORTE_VALORADOS, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS FECHA_OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS FECHA_CANCELACION, TIPO_PRESTAMO FROM REPORTE_VALORADOS");

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
                        Globals.t.Abort();
                        MessageBox.Show("Se Encontró " + result.ToList().Count.ToString() + " Créditos Cancelados que no se encuentran en la BD");
                    }
                    else
                    {
                        DataTable dt3 = new DataTable("REPORTE_VALORADOS_VIGENTES");
                        dt3 = GlobalFunctions.ConvertReporteValoradosToDataTable("SELECT ID_REPORTE_VALORADOS, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS FECHA_OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS FECHA_CANCELACION, TIPO_PRESTAMO FROM REPORTE_VALORADOS WHERE FECHA_CANCELACION = ''");

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
                        Globals.t.Abort();

                        MessageBox.Show(dgvCancelados.Rows.Count + " expedientes cancelados");
                    }
                }
            }
        }

        private void btActualizarCancelados_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                int id_column = -1;
                int cancelado_column = -1;
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                SQLiteCommand sqliteCmd;
                string strSQL = "";


                foreach (DataGridViewColumn col in dgvCancelados.Columns)
                {
                    if (col.HeaderText == "ID")
                    {
                        id_column = col.Index;
                    }

                    if (col.HeaderText == "CANCELACION")
                    {
                        cancelado_column = col.Index;
                    }
                }
                if (id_column >= 0 && cancelado_column >= 0)
                {
                    GlobalFunctions.iniciarLoading();
                    try
                    {
                        foreach (DataGridViewRow row in dgvCancelados.Rows)
                        {
                            strSQL = "UPDATE REPORTE_VALORADOS SET FECHA_CANCELACION = ";
                            try
                            {
                                strSQL = strSQL + "'" + DateTime.ParseExact(row.Cells[cancelado_column].Value.ToString(), "dd/mm/yy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") + "' WHERE ID_REPORTE_VALORADOS = " + row.Cells[id_column].Value;
                            }
                            catch (Exception ex)
                            {
                                sqliteConnection.Close();
                                Globals.t.Abort();
                                MessageBox.Show(ex.Message + "\n" + strSQL);
                                return;
                            }
                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                        }
                        sqliteTransaction.Commit();
                        sqliteConnection.Close();

                        Globals.t.Abort();
                        MessageBox.Show("Actualizacion Finalizada");
                        dgvCancelados.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        sqliteConnection.Close();
                        Globals.t.Abort();
                        MessageBox.Show(ex.Message + "\n" + strSQL);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error Cabecera");
                }
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
            using (SQLiteConnection sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                sqliteConnection.Open();
                SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();
                SQLiteCommand sqliteCmd;
                String strSQL = "";

                GlobalFunctions.iniciarLoading();
                try
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        strSQL = "INSERT INTO REPORTE_VALORADOS (CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, FECHA_OTORGADO, FECHA_CANCELACION, TIPO_PRESTAMO, SOLICITUD_SISGO, CONCATENADO) VALUES (";

                        strSQL = strSQL + "'" + row.Cells["CIP"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["NOMBRE"].Value.ToString() + "', ";
                        strSQL = strSQL + row.Cells["MONTO"].Value.ToString() + ", ";
                        strSQL = strSQL + "'" + row.Cells["PERIODO"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["NUMERO"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["MD"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["OTORGADO"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["CANCELACION"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["TIPO"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["SISGO"].Value.ToString() + "', ";
                        strSQL = strSQL + "'" + row.Cells["CIP"].Value.ToString() + ";" + row.Cells["NOMBRE"].Value.ToString() + ";" + row.Cells["SISGO"].Value.ToString() + ";" + row.Cells["TIPO"].Value.ToString() + ")";

                        sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        sqliteCmd.ExecuteNonQuery();
                    }
                    sqliteTransaction.Commit();
                    sqliteConnection.Close();
                    Globals.t.Abort();
                    MessageBox.Show("Carga Finalizada");
                    dgv.DataSource = null;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    Globals.t.Abort();
                    MessageBox.Show(ex.Message + "\n" + strSQL);
                }

            }

        }
    }
}

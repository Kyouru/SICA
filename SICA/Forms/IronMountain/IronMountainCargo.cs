using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainCargo : Form
    {
        public IronMountainCargo()
        {
            InitializeComponent();
        }

        private void btGenerar_Click(object sender, EventArgs e)
        {
            if (tbCargoCajas.Text != "")
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("CAJAS");
                dt.Columns.Add("NUMERO_CAJA");
                foreach (string linea in tbCargoCajas.Lines.ToList())
                {
                    if (linea != "")
                    {
                        dt.Rows.Add();
                        dt.Rows[dt.Rows.Count - 1][0] = linea;
                    }
                }

                string[] distinctLines = tbCargoCajas.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Distinct().ToArray();
                tbCargoCajas.Text = string.Join("\r\n", distinctLines);

                string strSQL = "";
                DataTable dt2 = new DataTable("INVENTARIO_GENERAL");
                try
                {

                    strSQL = "SELECT 'PY121' AS CODIGO_CLIENTE, NUMERO_DE_CAJA, CAJA_CLIENTE, 'MASTER' AS CODIGO_DIVISION, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS FECHA_DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3,";
                    strSQL = strSQL + " DESCRIPCION_4 AS DESCRIPCION_4, DESCRIPCION_5 AS DESCRIPCION_5 FROM INVENTARIO_GENERAL";

                    if (!Conexion.conectar())
                        return;
                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;

                    dt2 = Conexion.llenarDataTable();
                    if (dt2 is null)
                        return;

                    Conexion.cerrar();
                    
                    var result = from c1 in dt.AsEnumerable()
                                 join c2 in dt2.AsEnumerable() on c1.Field<string>("NUMERO_CAJA") equals c2.Field<string>("NUMERO_DE_CAJA")
                                 select new
                                 {
                                     CODIGO_CLIENTE = c2.Field<string>("CODIGO_CLIENTE"),
                                     NUMERO_DE_CAJA = c2.Field<string>("NUMERO_DE_CAJA"),
                                     CAJA_CLIENTE = c2.Field<string>("CAJA_CLIENTE"),
                                     CODIGO_DIVISION = c2.Field<string>("CODIGO_DIVISION"),
                                     CODIGO_DEPARTAMENTO = c2.Field<string>("CODIGO_DEPARTAMENTO"),
                                     CODIGO_DOCUMENTO = c2.Field<string>("CODIGO_DOCUMENTO"),
                                     FECHA_DESDE = c2.Field<string>("FECHA_DESDE"),
                                     FECHA_HASTA = c2.Field<string>("FECHA_HASTA"),
                                     DESCRIPCION_1 = c2.Field<string>("DESCRIPCION_1"),
                                     DESCRIPCION_2 = c2.Field<string>("DESCRIPCION_2"),
                                     DESCRIPCION_3 = c2.Field<string>("DESCRIPCION_3"),
                                     DESCRIPCION_4 = GlobalFunctions.SinTildes(c2.Field<string>("DESCRIPCION_4")),
                                     DESCRIPCION_5 = c2.Field<string>("DESCRIPCION_5")
                                 };
                    DataTable dt3 = new DataTable("CARGO");
                    dt3 = GlobalFunctions.ToDataTable(result.ToList());
                    GlobalFunctions.ArmarCargoExcel(dt3, "", Globals.CargoPath + "CARGO_IM_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".csv", false);

                    LoadingScreen.cerrarLoading();
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vacio");
            }
        }
    }
}

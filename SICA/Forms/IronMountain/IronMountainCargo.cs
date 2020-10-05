using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainCargo : Form
    {
        public IronMountainCargo()
        {
            InitializeComponent();
        }

        private void btGenerarCargo_Click(object sender, EventArgs e)
        {
            if (tbCargoCajas.Text != "")
            {
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

                using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                {
                    string strSQL;
                    DataTable dt2 = new DataTable("INVENTARIO_GENERAL");
                    try
                    {
                        sqliteConnection.Open();

                        strSQL = "SELECT 'PY121' AS CODIGO_CLIENTE, NUMERO_DE_CAJA, NUMERO_DE_CAJA AS 'NUMERO_DE_CAJA2', 'MASTER' AS CODIGO_DIVISION, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS FECHA_DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3,";
                        strSQL = strSQL + " REPLACE(DESCRIPCION_4, '&', ' Y ') AS DESCRIPCION_4 FROM INVENTARIO_GENERAL";
                        SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                        SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                        sqliteCmd.ExecuteNonQuery();
                        sqliteDataAdapter.Fill(dt2);
                        sqliteConnection.Close();

                        var result = from c1 in dt.AsEnumerable()
                                     join c2 in dt2.AsEnumerable() on c1.Field<string>("NUMERO_CAJA") equals c2.Field<string>("NUMERO_DE_CAJA")
                                     select new
                                     {
                                         CODIGO_CLIENTE = c2.Field<string>("CODIGO_CLIENTE"),
                                         NUMERO_DE_CAJA = c2.Field<string>("NUMERO_DE_CAJA"),
                                         NUMERO_DE_CAJA2 = c2.Field<string>("NUMERO_DE_CAJA2"),
                                         CODIGO_DIVISION = c2.Field<string>("CODIGO_DIVISION"),
                                         CODIGO_DEPARTAMENTO = c2.Field<string>("CODIGO_DEPARTAMENTO"),
                                         CODIGO_DOCUMENTO = c2.Field<string>("CODIGO_DOCUMENTO"),
                                         FECHA_DESDE = c2.Field<string>("FECHA_DESDE"),
                                         FECHA_HASTA = c2.Field<string>("FECHA_HASTA"),
                                         DESCRIPCION_1 = c2.Field<string>("DESCRIPCION_1"),
                                         DESCRIPCION_2 = c2.Field<string>("DESCRIPCION_2"),
                                         DESCRIPCION_3 = c2.Field<string>("DESCRIPCION_3"),
                                         DESCRIPCION_4 = GlobalFunctions.SinTildes(c2.Field<string>("DESCRIPCION_4"))
                                     };
                        DataTable dt3 = new DataTable("CARGO");
                        dt3 = GlobalFunctions.ToDataTable(result.ToList());
                        GlobalFunctions.ArmarCargoExcel(dt3, Globals.PlantillaCargoIMPath, Globals.CargoPath + "CARGO_IM_" + DateTime.Now.ToString("yyyymmddhhmmss") + "_" + Globals.Username + ".xlsx", 1, 1, false);
                    }
                    catch (Exception ex)
                    {
                        sqliteConnection.Close();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vacio");
            }
        }
    }
}

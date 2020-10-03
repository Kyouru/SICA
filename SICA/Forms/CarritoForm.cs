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

namespace SICA.Forms
{
    public partial class CarritoForm : Form
    {
        public CarritoForm()
        {
            InitializeComponent();
        }

        private void CarritoForm_Load(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {
                string strSQL;
                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                sqliteConnection.Open();

                if (Globals.CarritoSeleccionado == Globals.strIronMountainArmar || Globals.CarritoSeleccionado == Globals.strEntregarExpediente || Globals.CarritoSeleccionado == Globals.strEntregarDocumento || Globals.CarritoSeleccionado == Globals.strRecibirReingreso)
                {
                    strSQL = "SELECT ID_TMP_CARRITO AS ID, NUMERO_CAJA, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.TIPO = '" + Globals.CarritoSeleccionado + "'";
                    strSQL = strSQL + " ORDER BY NUMERO_CAJA";
                }
                else if (Globals.CarritoSeleccionado == Globals.strEntregarPagare)
                {
                    strSQL = "SELECT ID_TMP_CARRITO AS ID, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA, STRFTIME('%d/%m/%Y', FECHA_OTORGADO) AS OTORGADO, STRFTIME('%d/%m/%Y', FECHA_CANCELACION) AS CANCELACION, SUBSTR(TIPO_PRESTAMO, 0, 4) AS PROD, SIP";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN REPORTE_VALORADOS RV ON RV.ID_REPORTE_VALORADOS = TC.ID_REPORTE_VALORADOS_FK WHERE TC.TIPO = '" + Globals.CarritoSeleccionado + "'";
                    strSQL = strSQL + " ORDER BY OTORGADO";
                }
                else
                {
                    strSQL = "SELECT ID_TMP_CARRITO AS ID, NUMERO_CAJA, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA WHERE TC.TIPO = '" + Globals.CarritoSeleccionado + "'";
                    strSQL = strSQL + " ORDER BY NUMERO_CAJA";
                }

                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvCarrito.DataSource = dt;
                    dgvCarrito.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }
}

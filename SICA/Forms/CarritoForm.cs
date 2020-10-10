using SimpleLogger;
using System;
using System.Data;
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
            string strSQL = "";
            DataTable dt = new DataTable("INVENTARIO_GENERAL");

            
            try
            {
                LoadingScreen.iniciarLoading();

                if (Globals.CarritoSeleccionado == Globals.strIronMountainArmar || Globals.CarritoSeleccionado == Globals.strEntregarExpediente || Globals.CarritoSeleccionado == Globals.strEntregarDocumento || Globals.CarritoSeleccionado == Globals.strRecibirReingreso || Globals.CarritoSeleccionado == Globals.strBovedaRetirar)
                {
                    strSQL = "SELECT ID_TMP_CARRITO AS ID, NUMERO_CAJA, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.TIPO = '" + Globals.CarritoSeleccionado + "'";
                    strSQL = strSQL + " ORDER BY NUMERO_CAJA";
                }
                else if (Globals.CarritoSeleccionado == Globals.strEntregarPagare)
                {
                    strSQL = "SELECT ID_TMP_CARRITO AS ID, CIP, NOMBRE, MONTOPRESTAMO, PERIODO_SOLICITUD, NUMERO_SOLICITUD, MONEDA,FORMAT(FECHA_OTORGADO, 'dd/MM/yyyy') AS OTORGADO, FORMAT(FECHA_CANCELACION, 'dd/MM/yyyy') AS CANCELACION, LEFT(TIPO_PRESTAMO, 3) AS PROD, SIP";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN REPORTE_VALORADOS RV ON RV.ID_REPORTE_VALORADOS = TC.ID_REPORTE_VALORADOS_FK WHERE TC.TIPO = '" + Globals.CarritoSeleccionado + "'";
                    strSQL = strSQL + " ORDER BY FECHA_OTORGADO";
                }
                else
                {
                    strSQL = "SELECT ID_TMP_CARRITO AS ID, NUMERO_CAJA, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                    strSQL = strSQL + " FROM TMP_CARRITO TC LEFT JOIN INVENTARIO_GENERAL IG ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA WHERE TC.TIPO = '" + Globals.CarritoSeleccionado + "'";
                    strSQL = strSQL + " ORDER BY NUMERO_CAJA";
                }

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgvCarrito.DataSource = dt;
                dgvCarrito.Columns[0].Width = 0;

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }
    }
}

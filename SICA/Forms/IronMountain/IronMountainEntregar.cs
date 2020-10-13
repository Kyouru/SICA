using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainEntregar : Form
    {
        public IronMountainEntregar()
        {
            InitializeComponent();
            actualizarCantidad();
        }

        private void actualizarCajas()
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                /*strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.NUMERO_DE_CAJA = TC.NUMERO_CAJA WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = 'EN TRANSITO A IM'";
                strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";*/


                strSQL = "SELECT DISTINCT IH.NUMERO_CAJA AS CAJA, IH.FECHA_INICIO AS FECHA_SOLICITUD, OBSERVACION AS USUARIO FROM INVENTARIO_HISTORICO IH";
                strSQL = strSQL + " LEFT JOIN TMP_CARRITO TC ON TC.NUMERO_CAJA = IH.NUMERO_CAJA";

                strSQL = strSQL + " WHERE IH.ID_USUARIO_RECIBE_FK = " + Globals.IdIM;
                strSQL = strSQL + " AND IH.ANULADO = FALSE";
                strSQL = strSQL + " AND IH.RECIBIDO = FALSE";
                strSQL = strSQL + " AND IH.FECHA_FIN IS NULL";
                strSQL = strSQL + " AND TC.ID_TMP_CARRITO IS NULL";

                strSQL = strSQL + " ORDER BY FECHA_INICIO";

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

                dgv.DataSource = dt;
                //dgv.Columns[0].Visible = false;
                dgv.ClearSelection();

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return;
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                IronMountainFunctions.EntregarCajasCarrito();
                lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEntregar) + ")";
                actualizarCajas();
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                GlobalFunctions.AgregarCarrito("0", "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strIronMountainEntregar);
                actualizarCantidad();
                actualizarCajas();
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strIronMountainEntregar) + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strIronMountainEntregar);
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strIronMountainEntregar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            actualizarCajas();
        }
    }
}

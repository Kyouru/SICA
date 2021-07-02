using System;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms.IronMountain
{
    public partial class IronMountainArmar : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strIronMountainArmar;

        public IronMountainArmar()
        {
            InitializeComponent();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("INVENTARIO_GENERAL");

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA";
                strSQL += " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = '" + Globals.Username + "'";

                if (tbBusquedaLibre.Text != "")
                {
                    strSQL += " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
                }
                strSQL += " ORDER BY CODIGO_DOCUMENTO";

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
                dgv.Columns[0].Visible = false;
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
                string numero = Microsoft.VisualBasic.Interaction.InputBox("Escriba el numero de caja:", "Numero de Caja", "");
                if (numero != "")
                {
                    int n;
                    string check = "REEMPLAZAR";
                    string strSQL = "SELECT COUNT(*) FROM INVENTARIO_GENERAL WHERE NUMERO_DE_CAJA = '" + numero + "'";
                    try
                    {
                        if (!Conexion.conectar())
                            return;
                        if (!Conexion.iniciaCommand(strSQL))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;
                        n = Conexion.ejecutarQueryEscalar();
                        Conexion.cerrar();
                        LoadingScreen.cerrarLoading();
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                        return;
                    }
                    if (n > 0)
                    {
                        check = Microsoft.VisualBasic.Interaction.InputBox("La Caja no es nueva\nEscriba \"AGREGAR\" para agregar el documento o \"REEMPLAZAR\" para reemplazar el contenido", "Ya registrado", "");
                    }
                    if (check == "REEMPLAZAR")
                    {
                        IronMountainFunctions.ArmarCajasCarrito(numero, true);
                        cantidadcarrito = 0;
                        actualizarCantidad();
                        btBuscar_Click(sender, e);
                    }
                    if (check == "AGREGAR")
                    {
                        IronMountainFunctions.ArmarCajasCarrito(numero, false);
                        cantidadcarrito = 0;
                        actualizarCantidad();
                        btBuscar_Click(sender, e);
                    }

                }
            }
        }


        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (!Conexion.conectar())
                    return;
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    string strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARIO_GENERAL_FK, ID_AUX_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (";
                    strSQL += row.Cells["ID"].Value.ToString() + ", " + dgv.SelectedRows[0].Cells["ID_BOVEDA"].Value.ToString() + ", " + Globals.IdUsername + ", '" + tipo_carrito + "', '" + row.Cells["CAJA"].Value.ToString() + "')";
                    try
                    {
                        if (!Conexion.iniciaCommand(strSQL))
                            return;
                        if (!Conexion.ejecutarQuery())
                            return;
                    }
                    catch (Exception ex)
                    {
                        GlobalFunctions.casoError(ex, strSQL);
                        return;
                    }
                    ++cantidadcarrito;
                }
                Conexion.cerrar();

                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgv.Rows.Remove(row);
                }
                actualizarCantidad();
            }
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + cantidadcarrito + ")";
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            cantidadcarrito = 0;
            actualizarCantidad();
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = tipo_carrito;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

    }
}

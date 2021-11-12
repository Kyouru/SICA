using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Recibir
{
    public partial class RecibirConfirmar : Form
    {
        int cantidadcarrito = 0;
        readonly string tipo_carrito = Globals.strRecibirConfirmar;
        public RecibirConfirmar()
        {
            InitializeComponent();
            Globals.CarritoSeleccionado = tipo_carrito;
            actualizarCantidad();
        }
        public void actualizarCantidad(int cantidad = -1)
        {
            if (cantidad >= 0)
            {
                cantidadcarrito = cantidad;
            }
            else
            {
                cantidadcarrito = GlobalFunctions.CantidadCarrito(tipo_carrito);
            }
            lbCantidad.Text = "(" + cantidadcarrito + ")";
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, DEP.NOMBRE_DEPARTAMENTO AS DEPART, DOC.NOMBRE_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, DESCRIPCION_5 AS DESC_5, LE.NOMBRE_ESTADO AS CUSTODIADO, U.NOMBRE_USUARIO AS ENTREGA, FORMAT(IH.FECHA_INICIO, 'dd/MM/yyyy hh:mm:ss') AS INICIO";
                strSQL += " FROM (((((INVENTARIO_GENERAL IG LEFT JOIN (SELECT * FROM TMP_CARRITO WHERE TIPO = '" + tipo_carrito + "') TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK)";
                strSQL += " LEFT JOIN INVENTARIO_HISTORICO IH ON IH.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL)";
                strSQL += " LEFT JOIN LESTADO LE ON LE.ID_ESTADO = IG.ID_ESTADO_FK)";
                strSQL += " LEFT JOIN LDOCUMENTO DOC ON DOC.ID_DOCUMENTO = IG.ID_DOCUMENTO_FK)";
                strSQL += " LEFT JOIN LDEPARTAMENTO DEP ON DEP.ID_DEPARTAMENTO = IG.ID_DEPARTAMENTO_FK)";
                strSQL += " LEFT JOIN USUARIO U ON U.ID_USUARIO = IG.ID_USUARIO_POSEE";
                strSQL += " WHERE TC.ID_TMP_CARRITO IS NULL AND IH.ID_USUARIO_RECIBE_FK = " + Globals.IdUsername + " AND IH.RECIBIDO = 0 AND IH.ANULADO = 0";
                strSQL += " ORDER BY IH.FECHA_INICIO";

                if (!Conexion.conectar())
                    return;
                if (!Conexion.iniciaCommand(strSQL))
                    return;
                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                actualizarCantidad();
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewCSV(dgv, null);
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.ShowDialog();
                btActualizar_Click(sender, e);
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            btActualizar_Click(sender, e);
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
                    strSQL += row.Cells["ID"].Value.ToString() + ", " + 0 + ", " + Globals.IdUsername + ", '" + tipo_carrito + "', '" + row.Cells["CAJA"].Value.ToString() + "')";
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
                btActualizar_Click(sender, e);
                Conexion.cerrar();
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                RecibirFunctions.ConfirmarCarrito(observacion);
                actualizarCantidad(0);
            }
        }
    }
}

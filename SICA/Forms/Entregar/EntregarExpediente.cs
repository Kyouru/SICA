using SimpleLogger;
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

namespace SICA.Forms.Entregar
{
    public partial class EntregarExpediente : Form
    {
        string tipo_carrito = Globals.strEntregarExpediente;
        
        public EntregarExpediente()
        {
            InitializeComponent();
            actualizarCantidad();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL;

            strSQL = @"SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC,
                        FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2',
                        DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA
                        FROM INVENTARIO_GENERAL IG LEFT JOIN (SELECT * FROM TMP_CARRITO WHERE TIPO = @tipo_carrit AND ID_USUARIO_FK = @id_usuario) TC" +
                        " ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK WHERE TC.ID_TMP_CARRITO IS NULL" +
                        " AND DESCRIPCION_1 = 'EXPEDIENTES DE CREDITO' AND USUARIO_POSEE = @username";

            if (tbBusquedaLibre.Text != "")
                strSQL = strSQL + " AND DESC_CONCAT LIKE @busqueda_libre";
            strSQL = strSQL + " ORDER BY DESCRIPCION_2";

            try
            {
                DataTable dt = new DataTable();

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.agregarParametroCommand("@tipo_carrito", tipo_carrito))
                    return;
                if (!Conexion.agregarParametroCommand("@id_usuario", Globals.IdUsername.ToString()))
                    return;
                if (!Conexion.agregarParametroCommand("@username", Globals.Username))
                    return;
                if (!Conexion.agregarParametroCommand("@busqueda_libre", "%" + tbBusquedaLibre.Text + "%"))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;

                Conexion.cerrar();
            }
            catch (Exception ex)
            {
                Conexion.cerrar();
                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message + "\n" + strSQL);
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                actualizarCantidad();
                btBuscar_Click(sender, e);
            }
        }

        private void btEntregar_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL = 1";
                SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                suf.ShowDialog();
                if (Globals.IdUsernameSelect > 0)
                {
                    EntregarFunctions.EntregarExpedientesCarrito();
                    actualizarCantidad();

                    btBuscar_Click(sender, e);
                }
            }
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

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, "", 1, 1, true);
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(tipo_carrito);
            actualizarCantidad();
        }

        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(tipo_carrito) + ")";
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), tipo_carrito);
                    actualizarCantidad();
                    btBuscar_Click(sender, e);
                }
            }
        }
    }
}

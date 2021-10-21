using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Boveda
{
    public partial class BovedaRetirarCaja : Form
    {
        public BovedaRetirarCaja()
        {
            InitializeComponent();
        }
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            try
            {
                LoadingScreen.iniciarLoading();
                DataTable dt = new DataTable();
                strSQL = "SELECT U.ID_USUARIO AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, USUARIO_POSEE AS BOVEDA";
                strSQL += " FROM (INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.NOMBRE_USUARIO = IG.USUARIO_POSEE)";
                strSQL += " LEFT JOIN TMP_CARRITO TC ON TC.NUMERO_CAJA = IG.NUMERO_DE_CAJA";
                strSQL += " WHERE U.BOVEDA = 1 AND CUSTODIADO = 'CUSTODIADO' AND TC.ID_TMP_CARRITO IS NULL";
                if (tbCaja.Text != "")
                {
                    strSQL += " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
                }
                strSQL += " ORDER BY USUARIO_POSEE, NUMERO_DE_CAJA";

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
                if (dgv.SelectedRows.Count == 1)
                {
                    if (!validarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), dgv.SelectedRows[0].Cells["BOVEDA"].Value.ToString()))
                        return;
                    if (!RetirarCaja(dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), dgv.SelectedRows[0].Cells["BOVEDA"].Value.ToString(), Int32.Parse(dgv.SelectedRows[0].Cells["ID"].Value.ToString())))
                        return;
                    btBuscar_Click(sender, e);
                }
            }
        }


        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private bool validarCaja(string numero_caja, string boveda)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                if (!GlobalFunctions.verificarCaja(numero_caja, boveda))
                {
                    DialogResult dialogResult = MessageBox.Show("Hay documentos de esta caja que lo posee otro usuario\nDesea Retirarlo de todas manera?", "Caja Incompleta", MessageBoxButtons.YesNo);
                    if (dialogResult != DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool RetirarCaja (string numero_caja, string boveda, int id_boveda)
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "";
            DataTable dt;
            try
            {
                if (!Conexion.conectar())
                    return false;
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID FROM INVENTARIO_GENERAL WHERE NUMERO_DE_CAJA = '" + numero_caja + "' AND USUARIO_POSEE = '" + boveda + "'";
                if (!Conexion.iniciaCommand(strSQL))
                    return false;
                if (!Conexion.ejecutarQuery())
                    return false;
                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return false;

                foreach (DataRow row in dt.Rows)
                {
                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, ID_INVENTARIO_GENERAL_FK, FECHA_INICIO, FECHA_FIN, RECIBIDO, NUMERO_CAJA) VALUES (" + id_boveda + ", " + Globals.IdUsername + ", " + row["ID"].ToString() + ", " + fecha + ", " + fecha + ", 1, '" + numero_caja + "')";
                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }

                if (dt.Rows.Count > 0)
                {
                    strSQL = "UPDATE INVENTARIO_GENERAL SET USUARIO_POSEE = '" + Globals.Username + "', FECHA_POSEE = " + fecha + " WHERE USUARIO_POSEE = '" + boveda + "' AND NUMERO_DE_CAJA = '" + numero_caja + "'";

                    if (!Conexion.iniciaCommand(strSQL))
                        return false;
                    if (!Conexion.ejecutarQuery())
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Busqueda
{
    public partial class EditarForm : Form
    {
        string caja;
        string departamento;
        string documento;
        string fechadesde;
        string fechahasta;
        string descripcion1;
        string descripcion2;
        string descripcion3;
        string descripcion4;
        string descripcion5;

        public EditarForm()
        {
            InitializeComponent();
        }

        private void cbFechaDesde_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFechaDesde.Checked)
            {
                cbFechaDesde.Visible = true;
            }
            else
            {
                cbFechaDesde.Visible = false;
            }
        }

        private void cbFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFechaHasta.Checked)
            {
                cbFechaHasta.Visible = true;
            }
            else
            {
                cbFechaHasta.Visible = false;
            }
        }

        private void EditarForm_Load(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM DEPARTAMENTO WHERE ANULADO = FALSE ORDER BY ORDEN DESC";
            DataTable dt;

            if (!Conexion.conectar())
                return;

            if (!Conexion.iniciaCommand(strSQL))
                return;

            if (!Conexion.ejecutarQuery())
                return;

            dt = Conexion.llenarDataTable();

            cmbDepartamento.DataSource = dt;
            cmbDepartamento.DisplayMember = "NOMBRE_DEPARTAMENTO";
            cmbDepartamento.ValueMember = "ID_DEPARTAMENTO";

            strSQL = "SELECT * FROM DOCUMENTO WHERE ANULADO = FALSE ORDER BY ORDEN DESC";

            if (!Conexion.iniciaCommand(strSQL))
                return;

            if (!Conexion.ejecutarQuery())
                return;

            dt = Conexion.llenarDataTable();

            cmbDocumento.DataSource = dt;
            cmbDocumento.DisplayMember = "NOMBRE_DOCUMENTO";
            cmbDocumento.ValueMember = "ID_DOCUMENTO";

            strSQL = "SELECT * FROM (INVENTARIO_GENERAL IG LEFT JOIN DEPARTAMENTO DEP ON IG.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO) LEFT JOIN DOCUMENTO DOC ON IG.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO WHERE IG.ID_INVENTARIO_GENERAL = " + Globals.IdInventario;

            if (!Conexion.iniciaCommand(strSQL))
                return;

            if (!Conexion.ejecutarQuery())
                return;

            dt = Conexion.llenarDataTable();

            if (dt.Rows.Count > 0)
            {
                tbCaja.Text = dt.Rows[0]["NUMERO_DE_CAJA"].ToString();
                cmbDepartamento.SelectedValue = dt.Rows[0]["ID_DEPARTAMENTO_FK"].ToString();
                cmbDocumento.SelectedValue = dt.Rows[0]["ID_DOCUMENTO_FK"].ToString();
                dtpFechaDesde.Text = dt.Rows[0]["FECHA_DESDE"].ToString();
                dtpFechaHasta.Text = dt.Rows[0]["FECHA_HASTA"].ToString();
                tbDescripcion1.Text = dt.Rows[0]["DESCRIPCION_1"].ToString();
                tbDescripcion2.Text = dt.Rows[0]["DESCRIPCION_2"].ToString();
                tbDescripcion3.Text = dt.Rows[0]["DESCRIPCION_3"].ToString();
                tbDescripcion4.Text = dt.Rows[0]["DESCRIPCION_4"].ToString();
                tbDescripcion5.Text = dt.Rows[0]["DESCRIPCION_5"].ToString();

                caja = tbCaja.Text;
                departamento = cmbDepartamento.SelectedValue.ToString();
                documento = cmbDocumento.SelectedValue.ToString();
                fechadesde = dtpFechaDesde.Text;
                fechahasta = dtpFechaHasta.Text;
                descripcion1 = tbDescripcion1.Text;
                descripcion2 = tbDescripcion2.Text;
                descripcion3 = tbDescripcion3.Text;
                descripcion4 = tbDescripcion4.Text;
                descripcion5 = tbDescripcion5.Text;
            }

            Conexion.cerrar();
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            bool correcto = true;
            string strSQL = "";
            if (tbCaja.Text != "")
            {
                MessageBox.Show("Numero de Caja Vacio");
                correcto = false;
            }
            if (cmbDepartamento.SelectedIndex == -1)
            {
                MessageBox.Show("Departamento Invalido");
                correcto = false;
            }
            if (cmbDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Documento Invalido");
                correcto = false;
            }

            if (correcto)
            {
                strSQL = "INSERT INTO INVENTARIO_ANTERIOR (ID_INVENTARIO_GENERAL_FK, FECHA_MODIFICACION, ID_USUARIO_FK, NUMERO_DE_CAJA, CAJA_CLIENTE, ID_DEPARTAMENTO_FK, ID_DOCUMENTO_FK, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5) VALUES";
                strSQL += " (" + Globals.IdInventario + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " + Globals.IdUsername + ", '" + caja + "'" + ", '" + caja + "'" + ", " + departamento + "" + ", " + documento + "" + ", '" + fechadesde + "'" + ", '" + fechahasta + "'" + ", '" + descripcion1 + "'" + ", '" + descripcion2 + "'" + ", '" + descripcion3 + "'" + ", '" + descripcion4 + "'" + ", '" + descripcion5 + "')";

                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                strSQL = "UPDATE INVENTARIO_GENERAL SET";
                strSQL += " NUMERO_DE_CAJA = '" + tbCaja.Text + "',";
                strSQL += " CAJA_CLIENTE = '" + tbCaja.Text + "',";
                strSQL += " ID_DEPARTAMENTO_FK = " + Int32.Parse((cmbDepartamento.SelectedItem as DataRowView)["ID_DEPARTAMENTO"].ToString()) + ",";
                strSQL += " ID_DOCUMENTO_FK = " + Int32.Parse((cmbDocumento.SelectedItem as DataRowView)["ID_DOCUMENTO"].ToString()) + ",";
                strSQL += " DESCRIPCION_1 = '" + tbDescripcion1.Text.Replace("'", "'''") + "',";
                strSQL += " DESCRIPCION_2 = '" + tbDescripcion2.Text.Replace("'", "'''") + "',";
                strSQL += " DESCRIPCION_3 = '" + tbDescripcion3.Text.Replace("'", "'''") + "',";
                strSQL += " DESCRIPCION_4 = '" + tbDescripcion4.Text.Replace("'", "'''") + "',";
                strSQL += " DESCRIPCION_5 = '" + tbDescripcion5.Text.Replace("'", "'''") + "',";
                strSQL += " DESC_CONCAT = '" + tbDescripcion1.Text.Replace("'", "'''") + ";" + tbDescripcion2.Text.Replace("'", "'''") + ";" + tbDescripcion3.Text.Replace("'", "'''") + ";" + tbDescripcion4.Text.Replace("'", "'''") + ";" + tbDescripcion5.Text.Replace("'", "'''") + ";" + (cmbDepartamento.SelectedItem as DataRowView)["NOMBRE_DEPARTAMENTO"].ToString() + ";" + (cmbDocumento.SelectedItem as DataRowView)["NOMBRE_DOCUMENTO"].ToString() + ";'";

                if (cbFechaDesde.Checked)
                {
                    strSQL += ", FECHA_DESDE = '" + dtpFechaDesde.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (cbFechaDesde.Checked)
                {
                    strSQL += ", FECHA_HASTA = '" + dtpFechaHasta.Value.ToString("yyyy-MM-dd") + "'";
                }

                strSQL += " WHERE ID_INVENTARIO_GENERAL = " + Globals.IdInventario;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                Conexion.cerrar();

                MessageBox.Show("Actualizado");
            }
        }
    }
}

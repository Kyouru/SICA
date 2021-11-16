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
        int expediente;
        DateTime fechamodifica;
        string usuariocrea;

        public EditarForm()
        {
            InitializeComponent();
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                lbDesde.Visible = true;
                lbHasta.Visible = true;
                dtpFechaDesde.Visible = true;
                dtpFechaHasta.Visible = true;
            }
            else
            {
                lbDesde.Visible = false;
                lbHasta.Visible = false;
                dtpFechaDesde.Visible = false;
                dtpFechaHasta.Visible = false;
            }
        }

        private void EditarForm_Load(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM LDEPARTAMENTO WHERE ANULADO = 0 ORDER BY ORDEN DESC";
            try
            {
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

                strSQL = "SELECT * FROM LDOCUMENTO WHERE ANULADO = 0 ORDER BY ORDEN DESC";

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();

                cmbDocumento.DataSource = dt;
                cmbDocumento.DisplayMember = "NOMBRE_DOCUMENTO";
                cmbDocumento.ValueMember = "ID_DOCUMENTO";

                strSQL = "SELECT ID_DESCRIPCION1, TIPO_DESCRIPCION1 FROM LDESCRIPCION1 ORDER BY ORDEN ASC";
                dt = new DataTable("Listas");

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                cmbDescripcion1.DataSource = dt;
                cmbDescripcion1.DisplayMember = "NOMBRE_DESCRIPCION1";
                cmbDescripcion1.ValueMember = "TIPO_DESCRIPCION1";

                strSQL = @"SELECT *
                FROM (INVENTARIO_GENERAL IG LEFT JOIN LDEPARTAMENTO DEP ON IG.ID_DEPARTAMENTO_FK = DEP.ID_DEPARTAMENTO)
                LEFT JOIN LDOCUMENTO DOC ON IG.ID_DOCUMENTO_FK = DOC.ID_DOCUMENTO
                WHERE IG.ID_INVENTARIO_GENERAL = " + Globals.IdInventario;

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
                    cmbDescripcion1.Text = dt.Rows[0]["DESCRIPCION_1"].ToString();
                    tbDescripcion2.Text = dt.Rows[0]["DESCRIPCION_2"].ToString();
                    tbDescripcion3.Text = dt.Rows[0]["DESCRIPCION_3"].ToString();
                    tbDescripcion4.Text = dt.Rows[0]["DESCRIPCION_4"].ToString();
                    tbDescripcion5.Text = dt.Rows[0]["DESCRIPCION_5"].ToString();

                    if (dt.Rows[0]["EXPEDIENTE"].ToString() == "1")
                    {
                        cmbExpediente.Text = "SI";
                    }
                    else
                    {
                        cmbExpediente.Text = "NO";
                    }

                    caja = tbCaja.Text;
                    departamento = cmbDepartamento.SelectedValue.ToString();
                    documento = cmbDocumento.SelectedValue.ToString();
                    fechadesde = dtpFechaDesde.Text;
                    fechahasta = dtpFechaHasta.Text;
                    descripcion1 = cmbDescripcion1.Text;
                    descripcion2 = tbDescripcion2.Text;
                    descripcion3 = tbDescripcion3.Text;
                    descripcion4 = tbDescripcion4.Text;
                    descripcion5 = tbDescripcion5.Text;
                    if (dt.Rows[0]["EXPEDIENTE"].ToString() == "True")
                    {
                        expediente = 1;
                    }
                    else
                    {
                        expediente = 0;
                    }
                    fechamodifica = DateTime.Parse(dt.Rows[0]["FECHA_MODIFICA"].ToString());
                    usuariocrea = dt.Rows[0]["ID_USUARIO_MODIFICA"].ToString();
                }

                Conexion.cerrar();
            }

            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            bool correcto = true;
            string strSQL = "";
            if (tbCaja.Text == "")
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
                strSQL = "INSERT INTO INVENTARIO_ANTERIOR (ID_INVENTARIO_GENERAL_FK, NUMERO_DE_CAJA, CAJA_CLIENTE, ID_DEPARTAMENTO_FK, ID_DOCUMENTO_FK, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, EXPEDIENTE, ID_USUARIO_MODIFICA, FECHA_MODIFICA) VALUES";
                strSQL += " (" + Globals.IdInventario + ", '" + caja + "'" + ", '" + caja + "'" + ", " + departamento + "" + ", " + documento + "" + ", '" + fechadesde + "'" + ", '" + fechahasta + "'" + ", '" + GlobalFunctions.lCadena(descripcion1) + "'" + ", '" + GlobalFunctions.lCadena(descripcion2) + "'" + ", '" + GlobalFunctions.lCadena(descripcion3) + "'" + ", '" + GlobalFunctions.lCadena(descripcion4) + "'" + ", '" + GlobalFunctions.lCadena(descripcion5) + "', " + expediente  + ", " + usuariocrea + ", '" + fechamodifica + "')";
                
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
                strSQL += " DESCRIPCION_1 = '" + GlobalFunctions.lCadena(cmbDescripcion1.Text) + "',";
                strSQL += " DESCRIPCION_2 = '" + GlobalFunctions.lCadena(tbDescripcion2.Text) + "',";
                strSQL += " DESCRIPCION_3 = '" + GlobalFunctions.lCadena(tbDescripcion3.Text) + "',";
                strSQL += " DESCRIPCION_4 = '" + GlobalFunctions.lCadena(tbDescripcion4.Text) + "',";
                strSQL += " DESCRIPCION_5 = '" + GlobalFunctions.lCadena(tbDescripcion5.Text) + "',";
                strSQL += " DESC_CONCAT = '" + GlobalFunctions.lCadena(cmbDescripcion1.Text + ";" + tbDescripcion2.Text + ";" + tbDescripcion3.Text + ";" + tbDescripcion4.Text + ";" + tbDescripcion5.Text) + ";" + (cmbDepartamento.SelectedItem as DataRowView)["NOMBRE_DEPARTAMENTO"].ToString() + ";" + (cmbDocumento.SelectedItem as DataRowView)["NOMBRE_DOCUMENTO"].ToString() + ";'";

                if (cbFecha.Checked)
                {
                    strSQL += ", FECHA_DESDE = '" + dtpFechaDesde.Value.ToString("yyyy-MM-dd") + "'";
                    strSQL += ", FECHA_HASTA = '" + dtpFechaHasta.Value.ToString("yyyy-MM-dd") + "'";
                }
                else
                {
                    strSQL += ", FECHA_DESDE = NULL";
                    strSQL += ", FECHA_HASTA = NULL";
                }

                if (cmbExpediente.Text == "SI")
                {
                    strSQL += ", EXPEDIENTE = 1";
                }
                else
                {
                    strSQL += ", EXPEDIENTE = 0";
                }

                strSQL += ", FECHA_MODIFICA = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strSQL += ", ID_USUARIO_MODIFICA = '" + Globals.IdUsername + "'";

                strSQL += " WHERE ID_INVENTARIO_GENERAL = " + Globals.IdInventario;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                Conexion.cerrar();

                MessageBox.Show("Actualizado");
                this.Close();
            }
        }
    }
}

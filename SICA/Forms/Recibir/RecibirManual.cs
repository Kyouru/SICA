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
    public partial class RecibirManual : Form
    {
        public RecibirManual()
        {
            InitializeComponent();
        }

        private void RecibirManual_Load(object sender, EventArgs e)
        {

            string strSQL = "SELECT ID_DEPARTAMENTO, NOMBRE_DEPARTAMENTO FROM LDEPARTAMENTO ORDER BY ORDEN ASC";
            DataTable dt = new DataTable("Listas");
            if (!Conexion.conectar())
                return;

            if (!Conexion.iniciaCommand(strSQL))
                return;

            if (!Conexion.ejecutarQuery())
                return;

            dt = Conexion.llenarDataTable();
            if (dt is null)
                return;

            cmbCodDepartamento.DataSource = dt;
            cmbCodDepartamento.DisplayMember = "NOMBRE_DEPARTAMENTO";
            cmbCodDepartamento.ValueMember = "ID_DEPARTAMENTO";

            strSQL = "SELECT ID_DOCUMENTO, NOMBRE_DOCUMENTO FROM LDOCUMENTO ORDER BY ORDEN ASC";
            dt = new DataTable("Listas");

            if (!Conexion.iniciaCommand(strSQL))
                return;

            if (!Conexion.ejecutarQuery())
                return;

            dt = Conexion.llenarDataTable();
            if (dt is null)
                return;

            cmbCodDocumento.DataSource = dt;
            cmbCodDocumento.DisplayMember = "NOMBRE_DOCUMENTO";
            cmbCodDocumento.ValueMember = "ID_DOCUMENTO";

            strSQL = "SELECT ID_DESCRIPCION1, NOMBRE_DESCRIPCION1 FROM LDESCRIPCION1 ORDER BY ORDEN ASC";
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
            cmbDescripcion1.ValueMember = "EXPEDIENTE";

            Conexion.cerrar();

        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string strSQL = "INSERT INTO INVENTARIO_GENERAL (NUMERO_DE_CAJA, ID_DEPARTAMENTO_FK, ID_DOCUMENTO_FK, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, DESC_CONCAT, FECHA_POSEE, ID_USUARIO_POSEE, ID_ESTADO_FK, EXPEDIENTE) ";
            strSQL += "VALUES (";

            if (cmbCodDepartamento.Text != "")
            {
                if (cmbCodDocumento.Text != "")
                {
                    if (cmbDescripcion1.Text != "")
                    {
                        if (cbNumeroCaja.Checked && tbNumeroCaja.Text == "")
                        {
                            MessageBox.Show("Falta Número de Caja");
                        }
                        else
                        {
                            Globals.strQueryArea = "";
                            Globals.strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1 AND ID_AREA_FK != 1";
                            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                            suf.ShowDialog();
                            if (Globals.IdUsernameSelect > 0)
                            {
                                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");


                                DataTable dt = new DataTable();
                                dt.Columns.Add("STATUS");
                                dt.Columns.Add("NUMERO CAJA");
                                dt.Columns.Add("CODIGO DEPARTAMENTO");
                                dt.Columns.Add("CODIGO DOCUMENTO");
                                dt.Columns.Add("FECHA DESDE");
                                dt.Columns.Add("FECHA HASTA");
                                dt.Columns.Add("DESCRIPCION 1");
                                dt.Columns.Add("DESCRIPCION 2");
                                dt.Columns.Add("DESCRIPCION 3");
                                dt.Columns.Add("DESCRIPCION 4");
                                dt.Columns.Add("DESCRIPCION 5");
                                dt.Columns.Add("EXPEDIENTE");
                                dt.Columns.Add("PAGARE");
                                dt.Columns.Add("DESC_CONCAT");
                                dt.Columns.Add("ID DEPARTAMENTO");
                                dt.Columns.Add("ID DOCUMENTO");

                                DataRow row = dt.NewRow();

                                if (cbNumeroCaja.Checked)
                                {
                                    row["NUMERO CAJA"] = GlobalFunctions.lCadena(tbNumeroCaja.Text);
                                }
                                else
                                {
                                    row["NUMERO CAJA"] = "";
                                }
                                row["CODIGO DEPARTAMENTO"] = (cmbCodDepartamento.SelectedItem as DataRowView)["NOMBRE_DEPARTAMENTO"].ToString();
                                row["CODIGO DOCUMENTO"] = (cmbCodDocumento.SelectedItem as DataRowView)["NOMBRE_DOCUMENTO"].ToString();
                                row["ID DEPARTAMENTO"] = (cmbCodDepartamento.SelectedItem as DataRowView)["ID_DEPARTAMENTO"].ToString();
                                row["ID DOCUMENTO"] = (cmbCodDocumento.SelectedItem as DataRowView)["ID_DOCUMENTO"].ToString();
                                if (cbFecha.Checked)
                                {
                                    row["FECHA DESDE"] = dtpDesde.Value.ToString("yyyy-MM-dd");
                                    row["FECHA HASTA"] = dtpHasta.Value.ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    row["FECHA DESDE"] = "";
                                    row["FECHA HASTA"] = "";
                                }
                                row["DESCRIPCION 1"] = (cmbDescripcion1.SelectedItem as DataRowView)["NOMBRE_DESCRIPCION1"].ToString();


                                if (cbDescripcion2.Checked)
                                {
                                    row["DESCRIPCION 2"] = GlobalFunctions.lCadena(tbDescripcion2.Text);
                                }
                                else
                                {
                                    row["DESCRIPCION 2"] = "";
                                }

                                if (cbDescripcion3.Checked)
                                {
                                    row["DESCRIPCION 3"] = GlobalFunctions.lCadena(tbDescripcion3.Text);
                                }
                                else
                                {
                                    row["DESCRIPCION 3"] = "";
                                }

                                if (cbDescripcion4.Checked)
                                {
                                    row["DESCRIPCION 4"] = GlobalFunctions.lCadena(tbDescripcion4.Text);
                                }
                                else
                                {
                                    row["DESCRIPCION 4"] = "";
                                }


                                if (cbDescripcion5.Checked)
                                {
                                    row["DESCRIPCION 5"] = GlobalFunctions.lCadena(tbDescripcion5.Text);
                                }
                                else
                                {
                                    row["DESCRIPCION 5"] = "";
                                }

                                row["DESC_CONCAT"] = row["CODIGO DEPARTAMENTO"].ToString() + ";" + row["CODIGO DOCUMENTO"].ToString() + ";" + row["FECHA DESDE"].ToString() + ";" + row["FECHA HASTA"].ToString() + ";" + row["DESCRIPCION 1"].ToString() + ";" + row["DESCRIPCION 2"].ToString() + ";" + row["DESCRIPCION 3"].ToString() + ";" + row["DESCRIPCION 4"].ToString() + ";" + row["DESCRIPCION 5"].ToString() + ";";

                                if (cmbExpediente.Visible && cmbExpediente.Text == "SI")
                                {
                                    row["EXPEDIENTE"] = "SI";
                                }
                                else
                                {
                                    row["EXPEDIENTE"] = "NO";
                                }

                                if (cmbPagare.Visible && cmbPagare.Text == "SI")
                                {
                                    row["PAGARE"] = "SI";
                                }
                                else
                                {
                                    row["PAGARE"] = "NO";
                                }

                                /*
                                DataGridView dgv = new DataGridView();
                                dt.Columns.Add("STATUS");
                                dt.Columns.Add("NUMERO CAJA");
                                dt.Columns.Add("CODIGO DEPARTAMENTO");
                                dt.Columns.Add("CODIGO DOCUMENTO");
                                dt.Columns.Add("FECHA DESDE");
                                dt.Columns.Add("FECHA HASTA");
                                dt.Columns.Add("DESCRIPCION 1");
                                dt.Columns.Add("DESCRIPCION 2");
                                dt.Columns.Add("DESCRIPCION 3");
                                dt.Columns.Add("DESCRIPCION 4");
                                dt.Columns.Add("DESCRIPCION 5");
                                dt.Columns.Add("EXPEDIENTE");
                                dt.Columns.Add("PAGARE");
                                dt.Columns.Add("DESC_CONCAT");
                                dt.Columns.Add("ID DEPARTAMENTO");
                                dt.Columns.Add("ID DOCUMENTO");
                                dgv.Rows.Add(row.ItemArray);
                                */

                                try
                                {
                                    if (!Conexion.conectar())
                                        return;
                                    if (!Conexion.iniciaCommand(RecibirFunctions.ArmarStrNuevoIngreso(row)))
                                        return;
                                    if (!Conexion.ejecutarQuery())
                                        return;
                                    int lastinsertid = Conexion.lastIdInsert();

                                    strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO, ANULADO) VALUES (" + lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', 1, 0)";

                                    if (!Conexion.iniciaCommand(strSQL))
                                        return;
                                    if (!Conexion.ejecutarQuery())
                                        return;

                                    if (cmbPagare.Visible && cmbPagare.Text == "SI")
                                    {

                                        if (!RecibirFunctions.RecibirPagare(row, observacion))
                                            return;
                                    }
                                    Conexion.cerrar();
                                }
                                catch (Exception ex)
                                {
                                    GlobalFunctions.casoError(ex, strSQL);
                                    return;
                                }

                                MessageBox.Show("Registro Completado");
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta Descripcion 1");
                    }
                }
                else
                {
                    MessageBox.Show("Falta Codigo Documento");
                }
            }
            else
            {
                MessageBox.Show("Falta Codigo Departamento");
            }
        }

        private void cbNumeroCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNumeroCaja.Checked)
            {
                tbNumeroCaja.Visible = true;
            }
            else
            {
                tbNumeroCaja.Visible = false;
            }
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                dtpDesde.Visible = true;
                dtpHasta.Visible = true;
            }
            else
            {
                dtpDesde.Visible = false;
                dtpHasta.Visible = false;
            }
        }

        private void cbDescripcion2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion2.Checked)
            {
                tbDescripcion2.Visible = true;
            }
            else
            {
                tbDescripcion2.Visible = false;
            }
        }

        private void cbDescripcion3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion3.Checked)
            {
                tbDescripcion3.Visible = true;
            }
            else
            {
                tbDescripcion3.Visible = false;
            }
        }

        private void cbDescripcion4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion4.Checked)
            {
                tbDescripcion4.Visible = true;
            }
            else
            {
                tbDescripcion4.Visible = false;
            }
        }

        private void cbDescripcion5_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDescripcion5.Checked)
            {
                tbDescripcion5.Visible = true;
            }
            else
            {
                tbDescripcion5.Visible = false;
            }
        }

        private void cmbDescripcion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbDescripcion1.SelectedItem as DataRowView)["EXPEDIENTE"].ToString() == "1")
            {
                cmbExpediente.Text = "SI";
            }
            else
            {
                cmbExpediente.Text = "NO";
            }
        }
    }
}

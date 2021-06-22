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

            string strSQL = "SELECT * FROM LISTA WHERE (COD_LISTA <= 3) ORDER BY COD_LISTA, ORDEN_LISTA ASC";
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

            Conexion.cerrar();

            foreach (DataRow row in dt.Rows)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = row["NOMBRE_ELEMENTO"].ToString();
                item.Value = row["EXP"].ToString();

                if (row["COD_LISTA"].ToString() == "1")
                {
                    cmbCodDepartamento.Items.Add(item);
                }
                else if (row["COD_LISTA"].ToString() == "2")
                {
                    cmbCodDocumento.Items.Add(item);
                }
                else if (row["COD_LISTA"].ToString() == "3")
                {
                    cmbDescripcion1.Items.Add(item);
                }
            }

        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            string fecha = "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#";
            string strSQL = "INSERT INTO INVENTARIO_GENERAL (NUMERO_DE_CAJA, CODIGO_DEPARTAMENTO, CODIGO_DOCUMENTO, FECHA_DESDE, FECHA_HASTA, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, DESC_CONCAT, FECHA_POSEE, USUARIO_POSEE, CUSTODIADO) ";
            strSQL = strSQL + "VALUES (";

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
                            Globals.strQueryUser = "SELECT ID_USUARIO, USERNAME, CUSTODIA FROM USUARIO WHERE REAL2 = TRUE AND CUSTODIA = FALSE";
                            SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                            suf.ShowDialog();
                            if (Globals.IdUsernameSelect > 0)
                            {
                                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                                strSQL = strSQL + "'" + tbNumeroCaja.Text + "', ";

                                strSQL = strSQL + "'" + cmbCodDepartamento.Text + "', ";
                                strSQL = strSQL + "'" + cmbCodDocumento.Text + "', ";
                                if (cbFecha.Checked)
                                {
                                    strSQL = strSQL + "'" + dtpDesde.Value.ToString("yyyy-MM-dd") + "', ";
                                    strSQL = strSQL + "'" + dtpHasta.Value.ToString("yyyy-MM-dd") + "', ";
                                }
                                else
                                {
                                    strSQL = strSQL + "NULL, NULL, ";
                                }

                                strSQL = strSQL + "'" + cmbDescripcion1.Text + "', ";

                                if (cbDescripcion2.Checked)
                                {
                                    strSQL = strSQL + "'" + tbDescripcion2.Text + "', ";
                                }
                                else
                                {
                                    strSQL = strSQL + "NULL, ";
                                }

                                if (cbDescripcion3.Checked)
                                {
                                    strSQL = strSQL + "'" + tbDescripcion3.Text + "', ";
                                }
                                else
                                {
                                    strSQL = strSQL + "NULL, ";
                                }

                                if (cbDescripcion4.Checked)
                                {
                                    strSQL = strSQL + "'" + tbDescripcion4.Text + "', ";
                                }
                                else
                                {
                                    strSQL = strSQL + "NULL, ";
                                }

                                if (cbDescripcion5.Checked)
                                {
                                    strSQL = strSQL + "'" + tbDescripcion5.Text + "', ";
                                }
                                else
                                {
                                    strSQL = strSQL + "NULL, ";
                                }

                                //DESC_CONCAT
                                strSQL = strSQL + "'" + cmbDescripcion1.Text + ";" + tbDescripcion2.Text + ";" + tbDescripcion3.Text + ";" + tbDescripcion4.Text + ";" + tbDescripcion5.Text + ";', ";
                                strSQL = strSQL + "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#, ";
                                strSQL = strSQL + "'" + Globals.Username + "', 'CUSTODIADO')";

                                if (!Conexion.conectar())
                                    return;

                                if (!Conexion.iniciaCommand(strSQL))
                                    return;

                                if (!Conexion.ejecutarQuery())
                                    return;

                                int lastinsertid = Conexion.lastIdInsert();

                                strSQL = "INSERT INTO INVENTARIO_HISTORICO (ID_INVENTARIO_GENERAL_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO) VALUES (" + lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', TRUE)";

                                if (!Conexion.iniciaCommand(strSQL))
                                    return;
                                if (!Conexion.ejecutarQuery())
                                    return;

                                if (cmbExpediente.Visible && cmbExpediente.Text == "SI")
                                {
                                    strSQL = "INSERT INTO EXPEDIENTE_TRANSITO (SOLICITUD_SISGO, EXPEDIENTE, ID_INVENTARIO_GENERAL_FK, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, CONCATENADO, FECHA_ENTRADA) VALUES ('";
                                    strSQL = strSQL + tbDescripcion2.Text + "', TRUE, " + lastinsertid + ", '" + cmbDescripcion1.Text + "', '" + tbDescripcion2.Text + "', '" + tbDescripcion3.Text + "', '" + tbDescripcion4.Text + "', '" + tbDescripcion5.Text + "', '" + cmbCodDocumento.Text + ";" + cmbDescripcion1.Text + ";" + tbDescripcion2.Text + ";" + tbDescripcion3.Text + ";" + tbDescripcion4.Text + ";" + tbDescripcion5.Text + "', #" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#)";

                                    if (!Conexion.iniciaCommand(strSQL))
                                        return;
                                    if (!Conexion.ejecutarQuery())
                                        return;
                                }
                                if (cmbPagare.Visible && cmbPagare.Text == "SI")
                                {
                                    strSQL = "INSERT INTO PAGARE_TRANSITO (SOLICITUD_SISGO, PAGARE, ID_INVENTARIO_GENERAL_FK, DESCRIPCION_1, DESCRIPCION_2, DESCRIPCION_3, DESCRIPCION_4, DESCRIPCION_5, CONCATENADO, FECHA_ENTRADA) VALUES ('";
                                    strSQL = strSQL + tbDescripcion2.Text + "', TRUE, " + lastinsertid + ", '" + cmbDescripcion1.Text + "', '" + tbDescripcion2.Text + "', '" + tbDescripcion3.Text + "', '" + tbDescripcion4.Text + "', '" + tbDescripcion5.Text + "', '" + cmbCodDocumento.Text + ";" + cmbDescripcion1.Text + ";" + tbDescripcion2.Text + ";" + tbDescripcion3.Text + ";" + tbDescripcion4.Text + ";" + tbDescripcion5.Text + "', #" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#)";

                                    if (!Conexion.iniciaCommand(strSQL))
                                        return;
                                    if (!Conexion.ejecutarQuery())
                                        return;
                                }

                                Conexion.cerrar();

                                if (cmbPagare.Visible && cmbExpediente.Visible)
                                {
                                    GlobalFunctions.actualizarNoDesembolsados();
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
            if (cmbDescripcion1.SelectedIndex >= 0)
            {
                if ((cmbDescripcion1.SelectedItem as ComboboxItem).Value.ToString() == "True")
                {
                    lbPagare.Visible = true;
                    cmbPagare.Visible = true;
                    lbExpediente.Visible = true;
                    cmbExpediente.Visible = true;
                    lbDescripcion2.Text = "Solicitud:";
                    lbDescripcion3.Text = "Cod. Prestamo:";
                    lbDescripcion4.Text = "Nombre:";

                    foreach (ComboboxItem item in cmbCodDepartamento.Items)
                    {
                        if (item.Value.ToString() == "True")
                        {
                            cmbCodDepartamento.Text = item.Text;
                        }
                    }

                    foreach (ComboboxItem item in cmbCodDocumento.Items)
                    {
                        if (item.Value.ToString() == "True")
                        {
                            cmbCodDocumento.Text = item.Text;
                        }
                    }

                    cbDescripcion2.Checked = true;
                    cbDescripcion2.Enabled = false;
                    cbDescripcion3.Checked = true;
                    cbDescripcion3.Enabled = false;
                    cbDescripcion4.Checked = true;
                    cbDescripcion4.Enabled = false;
                }
                else
                {
                    lbPagare.Visible = false;
                    cmbPagare.Visible = false;
                    lbExpediente.Visible = false;
                    cmbExpediente.Visible = false;
                    lbDescripcion2.Text = "Descripción 2:";
                    lbDescripcion3.Text = "Descripción 3:";
                    lbDescripcion4.Text = "Descripción 4:";

                    cbDescripcion2.Enabled = true;
                    cbDescripcion3.Enabled = true;
                    cbDescripcion4.Enabled = true;
                }
            }
        }
    }
}

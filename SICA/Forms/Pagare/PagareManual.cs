using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms.Pagare
{
    public partial class PagareManual : Form
    {
        public PagareManual()
        {
            InitializeComponent();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            string strSQL = "INSERT INTO PAGARE (SOLICITUD_SISGO, CODIGO_SOCIO, DESCRIPCION_3, DESCRIPCION_4, USUARIO_POSEE, CONCAT) ";
            strSQL += "VALUES (";

            if (tbSolicitudSISGO.Text != "")
            {
                if (tbCodigoSocio.Text != "")
                {
                    if (tbNombre.Text != "")
                    {
                        Globals.strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1 AND ID_AREA_FK != 1";
                        SeleccionarUsuarioForm suf = new SeleccionarUsuarioForm();
                        suf.ShowDialog();
                        if (Globals.IdUsernameSelect > 0)
                        {
                            string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                            strSQL += "'" + tbSolicitudSISGO.Text + "', ";

                            strSQL += "'" + tbCodigoSocio.Text + "', ";
                            strSQL += "'" + tbCodigoSocio.Text + "', ";
                            strSQL += "'" + tbNombre.Text + "', ";
                            strSQL += "'" + Globals.Username + "', ";

                            //DESC_CONCAT
                            strSQL += "'" + tbSolicitudSISGO.Text + ";" + tbCodigoSocio.Text + ";" + tbNombre.Text + ";')";

                            if (!Conexion.conectar())
                                return;

                            if (!Conexion.iniciaCommand(strSQL))
                                return;

                            if (!Conexion.ejecutarQuery())
                                return;

                            int lastinsertid = Conexion.lastIdInsert();

                            strSQL = "INSERT INTO PAGARE_HISTORICO (ID_PAGARE_FK, ID_USUARIO_ENTREGA_FK, ID_USUARIO_RECIBE_FK, FECHA_INICIO, FECHA_FIN, OBSERVACION_RECIBE, RECIBIDO) VALUES (";
                            strSQL += lastinsertid + ", " + Globals.IdUsernameSelect + ", " + Globals.IdUsername + ", " + fecha + ", " + fecha + ", '" + observacion + "', 1)";

                            if (!Conexion.iniciaCommand(strSQL))
                                return;
                            if (!Conexion.ejecutarQuery())
                                return;

                            Conexion.cerrar();

                            MessageBox.Show("Registro Completado");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Falta Nombre");
                    }
                }
                else
                {
                    MessageBox.Show("Falta Codigo Socio");
                }
            }
            else
            {
                MessageBox.Show("Falta Solicitud SISGO");
            }
        }
    }
}

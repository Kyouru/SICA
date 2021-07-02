using SICA.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA
{
    public static class Globals
    {
        public static string lastSQL = "";

        public static String configPathDB = Application.StartupPath + "\\config";
        public static String DBPath = Application.StartupPath + "\\BD\\DB_SICA.accdb"; //caso nulo

        public static String Provider = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";
        //public static String DBconnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\\\pacifico-4\\E\\digitalizacion\\CUSTODIA\\SICA\\BD\\DB_SICA.accdb";

        public static String ExportarPath = Application.StartupPath + "\\Exportar\\";

        public static String strQueryUser = "SELECT ID_USUARIO, USERNAME FROM USUARIO WHERE REAL2 = TRUE";

        public static String DBPasswod = "Micaela";

        public static String mostrarSQL = "";

        public static Int32 IdUsername = -1;
        public static String Username = "";

        public static Int32 IdUsernameSelect = -1;
        public static String UsernameSelect = "";
        public static bool EntregarConfirmacion = false;

        public static Int32 CantidadCarrito = 0;
        public static String CarritoSeleccionado = "";

        public static Int32 IdIM = 2;
        public static Int32 IdDC = 10;

        public static String strIronMountainSolicitar = "IM_SOLICITAR";
        public static String strIronMountainRecibir = "IM_RECIBIR";
        public static String strIronMountainArmar = "IM_ARMAR";
        public static String strIronMountainEnviar = "IM_ENVIAR";
        public static String strIronMountainEntregar = "IM_ENTREGAR";

        public static String strRecibirReingreso = "RECIBIR_REINGRESO";
        public static String strRecibirConfirmar = "RECIBIR_CONFIRMAR";

        public static String strEntregarExpediente = "ENTREGAR_EXP";
        public static String strEntregarDocumento = "ENTREGAR_DOC";
        public static String strEntregarPagare = "ENTREGAR_PAG";
        public static String strEntregarPagareSinDesembolsar = "ENTREGAR_PAG_SIN";
        public static String strEntregarEstado = "PRESTADO";

        public static String strBovedaRetirarDOC = "BOVEDA_RETIRAR_DOC";
        public static String strBovedaGuardarDOC = "BOVEDA_GUARDAR_DOC";
        public static String strBovedaRetirarCAJA = "BOVEDA_RETIRAR_CAJA";
        public static String strBovedaGuardarCAJA = "BOVEDA_GUARDAR_CAJA";

        public static String strPagareRecibir = "PAGARE_RECIBIR";
        public static String strPagareEntregar = "PAGARE_ENTREGAR";

        public static String strVerificarCAJA = "VERIFICAR_CAJA";
        public static String strnumeroCAJA = "";

        public static String strDocuClassEntregar = "DOCUCLASS_ENTREGAR";
        public static String strDocuClassRecibir = "DOCUCLASS_RECIBIR";

        public static String strLetrasReingreso = "LETRAS_REINGRESO";
        public static String strLetrasEntregar = "LETRAS_ENTREGAR";

        public static String strSeleccionarUsuario = "";

    }
}

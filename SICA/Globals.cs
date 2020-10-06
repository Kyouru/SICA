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
        /*public static String DBPath = "C:\\Zona Trabajo\\Visual C#\\SICA\\BD_SICA";
        public static String CargoPath = "C:\\Zona Trabajo\\Visual C#\\SICA\\CARGO\\";
        public static String PlantillaCargoPath = "C:\\Zona Trabajo\\Visual C#\\SICA\\PLANTILLA\\CARGO.xlsx";
        public static String PlantillaCargoPagPath = "C:\\Zona Trabajo\\Visual C#\\SICA\\PLANTILLA\\CARGO PAGARE.xlsx";
        public static String PlantillaCargoIMPath = "C:\\Zona Trabajo\\Visual C#\\SICA\\PLANTILLA\\CARGO IM.xlsx";*/

        public static Thread t = new Thread(new ThreadStart(StartLoadingScreen));

        public static String DBPath = Application.StartupPath + "\\BD\\BD_SICA";
        public static String CargoPath = Application.StartupPath + "\\CARGO\\";
        public static String PlantillaCargoExpPath = Application.StartupPath + "\\PLANTILLA\\CARGO EXP.xlsx";
        public static String PlantillaCargoDocPath = Application.StartupPath + "\\PLANTILLA\\CARGO DOC.xlsx";
        public static String PlantillaCargoPagPath = Application.StartupPath + "\\PLANTILLA\\CARGO PAGARE.xlsx";
        public static String PlantillaCargoIMPath = Application.StartupPath + "\\PLANTILLA\\CARGO IM.xlsx";

        public static String strQueryUser = "SELECT ID_USUARIO, USERNAME FROM USUARIO WHERE REAL = 1";

        public static String DBPasswod = "";

        public static Int32 IdUsername = -1;
        public static String Username = "";

        public static Int32 IdUsernameSelect = -1;
        public static String UsernameSelect = "";

        public static Int32 CantidadCarrito = 0;
        public static String CarritoSeleccionado = "";

        public static Int32 IdIM = 2;

        public static String strIronMountainSolicitar = "IM_SOLICITAR";
        public static String strIronMountainRecibir = "IM_RECIBIR";
        public static String strIronMountainArmar = "IM_ARMAR";
        public static String strIronMountainEnviar = "IM_ENVIAR";
        public static String strIronMountainEntregar = "IM_ENTREGAR";

        public static String strRecibirReingreso = "RECIBIR_REINGRESO";

        public static String strEntregarExpediente = "ENTREGAR_EXP";
        public static String strEntregarDocumento = "ENTREGAR_DOC";
        public static String strEntregarPagare = "ENTREGAR_PAG";
        public static String strEntregarPagareSinDesembolsar = "ENTREGAR_PAG_SIN";
        public static String strEntregarEstado = "PRESTADO";

        public static String strBovedaRetirar = "BOVEDA_RETIRAR";
        public static String strBovedaGuardar = "BOVEDA_GUARDAR";

        public static String strSeleccionarUsuario = "";
        public static void StartLoadingScreen()
        {
            Application.Run(new LoadingScreen());
        }
    }
}

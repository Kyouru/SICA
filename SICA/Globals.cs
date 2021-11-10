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
        public static Int32 loginsuccess = 0;
        public static string lastSQL = "";

        public static String ExportarPath = Application.StartupPath + "\\Exportar\\";
        public static String strQueryUser = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE REAL = 1";

        public static String mostrarSQL = "";

        public static String user = "";
        public static String pass = "";

        public static Int32 IdArea = -1;
        public static Int32 IdInventario = -1;
        public static Int32 IdUsername = -1;
        public static String Username = "";

        public static Int32 IdAreaSelect = -1;
        public static Int32 IdUsernameSelect = -1;
        public static String UsernameSelect = "";
        public static bool EntregarConfirmacion = false;

        public static Int32 CantidadCarrito = 0;
        public static String CarritoSeleccionado = "";

        public static Int32 IdCUSTODIA = 1;
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


        //Permisos

        public static bool auBusqueda = false;
        public static bool auBusquedaHistorico = false;
        public static bool auBusquedaEditar = false;
        public static bool auEntregar = false;
        public static bool auEntregarExpediente = false;
        public static bool auEntregarDocumento = false;
        public static bool auRecibir = false;
        public static bool auRecibirNuevo = false;
        public static bool auRecibirReingreso = false;
        public static bool auRecibirConfirmar = false;
        public static bool auPagare = false;
        public static bool auPagareBuscar = false;
        public static bool auPagareRecibir = false;
        public static bool auPagareEntregar = false;
        public static bool auLetra = false;
        public static bool auLetraNuevo = false;
        public static bool auLetraEntregar = false;
        public static bool auLetraReingreso = false;
        public static bool auLetraBuscar = false;
        public static bool auIronMountain = false;
        public static bool auIronMountainSolicitar = false;
        public static bool auIronMountainRecibir = false;
        public static bool auIronMountainArmar = false;
        public static bool auIronMountainEnviar = false;
        public static bool auIronMountainEntregar = false;
        public static bool auIronMountainCargo = false;
        public static bool auBoveda = false;
        public static bool auBovedaCajaRetirar = false;
        public static bool auBovedaCajaGuardar = false;
        public static bool auBovedaDocumentoRetirar = false;
        public static bool auBovedaDocumentoGuardar = false;
    }
}

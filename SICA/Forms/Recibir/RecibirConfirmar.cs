﻿using System;
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
    public partial class RecibirConfirmar : Form
    {
        public RecibirConfirmar()
        {
            InitializeComponent();
            actualizarCantidad();
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            string strSQL = "";

            try
            {
                LoadingScreen.iniciarLoading();

                DataTable dt = new DataTable("INVENTARIO_GENERAL");
                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, FORMAT(FECHA_DESDE, 'dd/MM/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/MM/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2, DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS ENTREGA, FORMAT(IH.FECHA_INICIO, 'dd/MM/yyyy hh:mm:ss') AS INICIO";
                strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN (SELECT * FROM TMP_CARRITO WHERE TIPO = '" + Globals.strRecibirConfirmar + "') TC ON IG.ID_INVENTARIO_GENERAL = TC.ID_INVENTARIO_GENERAL_FK) LEFT JOIN INVENTARIO_HISTORICO IH ON IH.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL WHERE TC.ID_TMP_CARRITO IS NULL AND IH.ID_USUARIO_RECIBE_FK = " + Globals.IdUsername + " AND IH.RECIBIDO = FALSE AND IH.ANULADO = FALSE";
                strSQL = strSQL + " ORDER BY IH.FECHA_INICIO";

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

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgv, null);
        }

        private void btVerCarrito_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                Globals.CarritoSeleccionado = Globals.strRecibirConfirmar;
                CarritoForm vCarrito = new CarritoForm();
                vCarrito.Show();
            }
        }

        private void btLimpiarCarrito_Click(object sender, EventArgs e)
        {
            GlobalFunctions.LimpiarCarrito(Globals.strRecibirConfirmar);
            actualizarCantidad();
        }
        private void actualizarCantidad()
        {
            lbCantidad.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strRecibirConfirmar) + ")";
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                if (dgv.SelectedRows.Count == 1)
                {
                    GlobalFunctions.AgregarCarrito(dgv.SelectedRows[0].Cells[0].Value.ToString(), "0", dgv.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strRecibirConfirmar);
                    actualizarCantidad();
                    btActualizar_Click(sender, e);
                }
            }
        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            if (lbCantidad.Text != "(0)")
            {
                string observacion = Microsoft.VisualBasic.Interaction.InputBox("Escriba una observacion (opcional):", "Observación", "");
                RecibirFunctions.ConfirmarCarrito(observacion);
                actualizarCantidad();
            }
        }
    }
}

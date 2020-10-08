﻿using Microsoft.VisualBasic;
using SICA.Forms;
using SimpleLogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SICA
{
    public partial class BusquedaForm : Form
    {
        public BusquedaForm()
        {
            InitializeComponent();

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void BusquedaForm_Load(object sender, EventArgs e)
        {
            //dtpFecha.Value = DateTime.Now;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string strSQL;
            string fecha;
            if (tbFecha.Text != "")
                fecha = DateTime.ParseExact(tbFecha.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-mm-dd");
            else
                fecha = "";
            DataTable dt = new DataTable("INVENTARIO_GENERAL");
            strSQL = @"SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, 
                        FORMAT(FECHA_DESDE, 'dd/mm/yyyy') AS DESDE, FORMAT(FECHA_HASTA, 'dd/mm/yyyy') AS HASTA, DESCRIPCION_1 AS DESC_1, DESCRIPCION_2 AS DESC_2,
                        DESCRIPCION_3 AS DESC_3, DESCRIPCION_4 AS DESC_4, CUSTODIADO, USUARIO_POSEE AS POSEE, FORMAT(FECHA_POSEE, 'dd/MM/yyyy hh:mm:ss') AS FECHA
                        FROM INVENTARIO_GENERAL WHERE 1 = 1";
            if (tbBusquedaLibre.Text != "")
                strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibre.Text + "%'";
            if (tbCaja.Text != "")
                strSQL = strSQL + " AND NUMERO_DE_CAJA LIKE '%" + tbCaja.Text + "%'";
            if (tbFecha.Text != "")
                strSQL = strSQL + " AND FECHA_DESDE <= @fecha_desde AND FECHA_HASTA >= @fecha_hasta";
            strSQL = strSQL + " ORDER BY CODIGO_DOCUMENTO";
            
            LoadingScreen.iniciarLoading();

            try
            {
                if (!Conexion.conectar())
                    return;

                if (!Conexion.iniciaCommand(strSQL))
                    return;

                if (!Conexion.agregarParametroCommand("@fecha_desde", fecha))
                    return;
                if (!Conexion.agregarParametroCommand("@fecha_hasta", fecha))
                    return;

                if (!Conexion.ejecutarQuery())
                    return;

                dt = Conexion.llenarDataTable();
                if (dt is null)
                    return;

                Conexion.cerrar();

                dgvBusqueda.DataSource = dt;
                dgvBusqueda.Columns[0].Visible = false;
                dgvBusqueda.Columns["DESC_1"].Width = 250;

                LoadingScreen.cerrarLoading();
            }
            catch (Exception ex)
            {
                Conexion.cerrar();
                LoadingScreen.cerrarLoading();

                SimpleLog.Info(Environment.UserName);
                SimpleLog.Log(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void cbFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFecha.Checked)
            {
                tbFecha.Enabled = true;
                tbFecha.Focus();
            }
            else
            {
                tbFecha.Enabled = false;
            }
        }

        private void tbBusquedaLibre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                this.btBuscar_Click(sender, e);
            }
        }

        private void cbCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCaja.Checked)
            {
                tbCaja.Enabled = true;
                tbCaja.Focus();
            }
            else
            {
                tbCaja.Enabled = false;
            }
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.ExportarDataGridViewExcel(dgvBusqueda, "", 1, 1, true);
        }
    }
}

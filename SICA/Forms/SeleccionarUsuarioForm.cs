﻿using SimpleLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class SeleccionarUsuarioForm : Form
    {
        public SeleccionarUsuarioForm()
        {
            InitializeComponent();
        }


        private void SeleccionarUsuarioForm_Load(object sender, EventArgs e)
        {
            Globals.IdUsernameSelect = -1;

            string strSQL = "SELECT ID_AREA, NOMBRE_AREA FROM AREA WHERE ANULADO = 0";
            strSQL += Globals.strQueryArea;
            strSQL += " ORDER BY ORDEN";
            Globals.strQueryArea = "";

            try
            {
                DataTable dt = new DataTable("AREA");
                Dictionary<int, string> test = new Dictionary<int, string>();
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

                cmbArea.DataSource = dt;
                cmbArea.ValueMember = "ID_AREA";
                cmbArea.DisplayMember = "NOMBRE_AREA";
            }
            catch (Exception ex)
            {
                GlobalFunctions.casoError(ex, strSQL);
            }

        }

        private void btSeleccionar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex != -1)
            {
                Globals.IdUsernameSelect = Int32.Parse((cmbUsuario.SelectedItem as DataRowView)["ID_USUARIO"].ToString());
                Globals.UsernameSelect = cmbUsuario.Text.Trim();
                Globals.IdAreaSelect = Int32.Parse((cmbArea.SelectedItem as DataRowView)["ID_AREA"].ToString());
                string strSQL = "SELECT ID_AREA_FK FROM USUARIO WHERE ID_USUARIO = " + Globals.IdUsernameSelect;
                try
                {
                    if (!Conexion.conectar())
                        return;

                    if (!Conexion.iniciaCommand(strSQL))
                        return;
                    if (!Conexion.ejecutarQuery())
                        return;
                    DataTable dt = Conexion.llenarDataTable();
                    if (dt is null)
                        return;
                    Conexion.cerrar();

                    if (dt.Rows[0][0].ToString() == Globals.IdAreaCustodia.ToString())
                    {
                        Globals.EntregarConfirmacion = true;
                        Globals.strEntregarEstado = "CUSTODIADO";
                    }
                    else
                    {
                        Globals.EntregarConfirmacion = false;
                        //Globals.EntregarConfirmacion = true;
                        Globals.strEntregarEstado = "PRESTADO";
                    }
                    LoadingScreen.cerrarLoading();
                    this.Close();
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                }
            }
        }

        private void cmbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex >= 0)
            {
                string strSQL = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE  ID_USUARIO <> " + Globals.IdUsername;
                strSQL += " AND ID_AREA_FK = " + (cmbArea.SelectedItem as DataRowView)["ID_AREA"].ToString() + " ORDER BY ORDEN";

                DataTable dt = new DataTable("USUARIO");

                try
                {
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

                    cmbUsuario.DataSource = dt;
                    cmbUsuario.ValueMember = "ID_USUARIO";
                    cmbUsuario.DisplayMember = "NOMBRE_USUARIO";
                }
                catch (Exception ex)
                {
                    GlobalFunctions.casoError(ex, strSQL);
                }
            }
            else
            {
                cmbUsuario.DataSource = null;
            }
        }
    }
}

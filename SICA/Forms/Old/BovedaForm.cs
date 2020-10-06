﻿using SICA.Forms.Boveda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICA.Forms
{
    public partial class BovedaForm : Form
    {
        public BovedaForm()
        {
            InitializeComponent();
        }

        private void btBuscarRetirar_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {

                string strSQL;
                DataTable dt = new DataTable("REPORTE_VALORADOS");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, U.ID_USUARIO, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.USERNAME = IG.USUARIO_POSEE)";
                strSQL = strSQL + " LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                strSQL = strSQL + " WHERE U.BOVEDA = 1 AND CUSTODIADO = 'CUSTODIADO' AND TC.ID_TMP_CARRITO IS NULL AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                
                if (tbBusquedaLibreRetirar.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibreRetirar.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY NUMERO_DE_CAJA";
                
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                
                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvBovedaRetirar.DataSource = dt;
                    dgvBovedaRetirar.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        
        private void dgvBovedaRetirar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBovedaRetirar.SelectedRows.Count == 1)
            {
                if (cbCajaRetiro.Checked)
                {
                    using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        SQLiteCommand sqliteCmd;
                        sqliteConnection.Open();
                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                        try
                        {
                            DataTable dt = new DataTable();
                            SQLiteDataAdapter sqliteDataAdapter;
                            string strSQL;
                            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                            strSQL = strSQL + "FROM (INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.USERNAME = IG.USUARIO_POSEE)";
                            strSQL = strSQL + "LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL_FK";
                            strSQL = strSQL + "WHERE U.BOVEDA = 1 AND CUSTODIADO = 'CUSTODIADO' AND TC.ID_TMP_CARRITO IS NULL ";
                            strSQL = strSQL + " AND NUMERO_DE_CAJA = '" + dgvBovedaRetirar.SelectedRows[0].Cells["ID"].Value.ToString() + "'";
                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                            sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                            sqliteDataAdapter.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARION_GENERAL_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (" + row["ID"].ToString() + ", " + Globals.IdUsername + ", '" + Globals.strBovedaRetirar + "', '" + row["CAJA"].ToString() + "')";
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                            }

                            sqliteTransaction.Commit();
                            sqliteConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    GlobalFunctions.AgregarCarrito(dgvBovedaRetirar.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgvBovedaRetirar.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strBovedaRetirar);
                }
                
                lbCantidadRetiro.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaRetirar) + ")";
                btBuscarRetirar_Click(sender, e);
            }
        }
        
        private void btBovedaRetirar_Click(object sender, EventArgs e)
        {
            if (lbCantidadRetiro.Text != "(0)")
            {
                BovedaFunctions.RetirarCarrito();
                lbCantidadRetiro.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaRetirar) + ")";
                btBuscarRetirar_Click(sender, e);
            }
        }

        private void btBuscarGuardar_Click(object sender, EventArgs e)
        {
            using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
            {

                string strSQL;
                DataTable dt = new DataTable("BOVEDA");
                sqliteConnection.Open();

                strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                strSQL = strSQL + " FROM INVENTARIO_GENERAL IG LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL";
                strSQL = strSQL + " WHERE TC.ID_TMP_CARRITO IS NULL AND IG.USUARIO_POSEE = '" + Globals.Username + "'";

                if (tbBusquedaLibreGuardar.Text != "")
                {
                    strSQL = strSQL + " AND DESC_CONCAT LIKE '%" + tbBusquedaLibreGuardar.Text + "%'";
                }
                strSQL = strSQL + " ORDER BY NUMERO_DE_CAJA";
                
                SQLiteCommand sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);

                try
                {
                    sqliteCmd.ExecuteNonQuery();
                    SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                    sqliteDataAdapter.Fill(dt);
                    sqliteConnection.Close();

                    dgvBovedaGuardar.DataSource = dt;
                    dgvBovedaGuardar.Columns[0].Width = 0;
                }
                catch (Exception ex)
                {
                    sqliteConnection.Close();
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void dgvBovedaGuardar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBovedaGuardar.SelectedRows.Count == 1)
            {
                if (cbCajaRetiro.Checked)
                {
                    using (var sqliteConnection = new SQLiteConnection("Data Source=" + Globals.DBPath))
                    {
                        SQLiteCommand sqliteCmd;
                        sqliteConnection.Open();
                        SQLiteTransaction sqliteTransaction = sqliteConnection.BeginTransaction();

                        try
                        {
                            DataTable dt = new DataTable();
                            SQLiteDataAdapter sqliteDataAdapter;
                            string strSQL;
                            string fecha = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            strSQL = "SELECT ID_INVENTARIO_GENERAL AS ID, NUMERO_DE_CAJA AS CAJA, CODIGO_DEPARTAMENTO AS DEPART, CODIGO_DOCUMENTO AS DOC, STRFTIME('%d/%m/%Y', FECHA_DESDE) AS DESDE, STRFTIME('%d/%m/%Y', FECHA_HASTA) AS HASTA, DESCRIPCION_1 AS 'DESC 1', DESCRIPCION_2 AS 'DESC 2', DESCRIPCION_3 AS 'DESC 3', DESCRIPCION_4 AS 'DESC 4', CUSTODIADO, USUARIO_POSEE AS POSEE, STRFTIME('%d/%m/%Y %H:%M:%S', FECHA_POSEE) AS FECHA";
                            strSQL = strSQL + " FROM (INVENTARIO_GENERAL IG LEFT JOIN USUARIO U ON U.USERNAME = IG.USUARIO_POSEE)";
                            strSQL = strSQL + " LEFT JOIN TMP_CARRITO TC ON TC.ID_INVENTARIO_GENERAL_FK = IG.ID_INVENTARIO_GENERAL_FK";
                            strSQL = strSQL + " WHERE U.BOVEDA = 1 AND CUSTODIADO = 'CUSTODIADO' AND TC.ID_TMP_CARRITO IS NULL AND TC.ID_USUARIO_FK = " + Globals.IdUsername;
                            strSQL = strSQL + " AND NUMERO_DE_CAJA = '" + dgvBovedaGuardar.SelectedRows[0].Cells["ID"].Value.ToString() + "'";
                            sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                            sqliteCmd.ExecuteNonQuery();
                            sqliteDataAdapter = new SQLiteDataAdapter(sqliteCmd);
                            sqliteDataAdapter.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                strSQL = "INSERT INTO TMP_CARRITO (ID_INVENTARION_GENERAL_FK, ID_USUARIO_FK, TIPO, NUMERO_CAJA) VALUES (" + row["ID"].ToString() + ", " + Globals.IdUsername + ", '" + Globals.strBovedaGuardar + "', '" + row["CAJA"].ToString() + "')";
                                sqliteCmd = new SQLiteCommand(strSQL, sqliteConnection);
                                sqliteCmd.ExecuteNonQuery();
                            }

                            sqliteTransaction.Commit();
                            sqliteConnection.Close();
                        }
                        catch (Exception ex)
                        {
                            sqliteConnection.Close();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    GlobalFunctions.AgregarCarrito(dgvBovedaGuardar.SelectedRows[0].Cells["ID"].Value.ToString(), "0", dgvBovedaGuardar.SelectedRows[0].Cells["CAJA"].Value.ToString(), Globals.strBovedaGuardar);
                }

                lbCantidadGuardar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaGuardar) + ")";
                btBuscarGuardar_Click(sender, e);
            }
        }

        private void btBovedaGuardar_Click(object sender, EventArgs e)
        {
            if (lbCantidadRetiro.Text != "(0)")
            {
                BovedaFunctions.RetirarCarrito();
                lbCantidadGuardar.Text = "(" + GlobalFunctions.CantidadCarrito(Globals.strBovedaGuardar) + ")";
                btBuscarGuardar_Click(sender, e);
            }
        }
    }
}

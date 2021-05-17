﻿using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Mantenimientos
{
    public partial class frmSucursal : Form
    {
        string UsuarioAplicacion;
        Controlador con = new Controlador();
        clsValidaciones vali = new clsValidaciones();
        public frmSucursal(string usuario)
        {
            InitializeComponent();
            CargarComboboxPais();
            CargarComboboxEmpresa();
            CargarComboboxDepartamento();
            CargarComboboxMunicipio();
            rbHabilitado.Checked = true;
            UsuarioAplicacion = usuario;
            navegador1.Usuario = UsuarioAplicacion;
        }
        public void CargarComboboxEmpresa()
        {
            //llenado de combobox de Empresa
            cmbEmpresa.DisplayMember = "nombreEmpresa";
            cmbEmpresa.ValueMember = "pkIdEmpresa";
            cmbEmpresa.DataSource = con.funcObtenerCamposComboboxPais("pkIdEmpresa", "nombreEmpresa", "empresa", "estadoEmpresa");
            cmbEmpresa.SelectedIndex = -1;
        }
        public void CargarComboboxPais()
        {
            //llenado de combobox de Pais
            cmbPais.DisplayMember = "nombrePais";
            cmbPais.ValueMember = "pkIdPais";
            cmbPais.DataSource = con.funcObtenerCamposComboboxPais("pkIdPais", "nombrePais", "pais", "estadoPais");
            cmbPais.SelectedIndex = -1;
        }
        public void CargarComboboxDepartamento()
        {
            //llenado de combobox de Departamento
            cmbDepartamento.DisplayMember = "nombreDepar";
            cmbDepartamento.ValueMember = "pkIdDepar";
            cmbDepartamento.DataSource = con.funcObtenerCamposComboboxPais("pkIdDepar", "nombreDepar", "departamento", "estadoDepar");
            cmbDepartamento.SelectedIndex = -1;
        }
        public void CargarComboboxMunicipio()
        {
            //llenado de combobox de Departamento
            cmbMunicipalidad.DisplayMember = "nombreMuni";
            cmbMunicipalidad.ValueMember = "pkIdMuni";
            cmbMunicipalidad.DataSource = con.funcObtenerCamposComboboxPais("pkIdMuni", "nombreMuni", "municipio", "estadoMuni");
            cmbMunicipalidad.SelectedIndex = -1;
        }


        private void navegador1_Load(object sender, EventArgs e)
        {
            List<string> CamposTabla = new List<string>();
            List<Control> lista = new List<Control>();
            //llenado de  parametros para la aplicacion 
            navegador1.aplicacion = 402;
            navegador1.tbl = "sucursal";
            navegador1.campoEstado = "estadoSucursal";

            //se agregan los componentes del formulario a la lista tipo control
            foreach (Control C in this.Controls)
            {
                if (C.Tag != null)
                {
                    if (C.Tag.ToString() == "saltar")
                    {

                    }
                    else
                    {
                        if (C is TextBox)
                        {
                            lista.Add(C);
                        }
                        else if (C is ComboBox)
                        {
                            lista.Add(C);
                        }
                        else if (C is DateTimePicker)
                        {
                            lista.Add(C);
                        }
                    }
                }
            }

            navegador1.control = lista;
            navegador1.formulario = this;
            navegador1.DatosActualizar = dgvSucursal;
            navegador1.procActualizarData();
            navegador1.procCargar();
            navegador1.ayudaRuta = "AyudaES/AyudasES.chm";
            navegador1.ruta = "AyudaSucursal.html";
            rbHabilitado.Checked = true;
            rbDeshabilitado.Checked = false;
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedIndex != -1)
            {
                txtIdEmpresa.Text = cmbEmpresa.SelectedValue.ToString();
            }
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPais.SelectedIndex != -1)
            {
                txtPais.Text = cmbPais.SelectedValue.ToString();
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartamento.SelectedIndex != -1)
            {
                txtDepartamento.Text = cmbDepartamento.SelectedValue.ToString();
            }
        }

        private void cmbMunicipalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMunicipalidad.SelectedIndex != -1)
            {
                txtMunicipalidad.Text = cmbMunicipalidad.SelectedValue.ToString();
            }
        }

        private void txtNombreSucursal_TextChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "1";
        }

        private void rbDeshabilitado_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = "0";
        }

        private void txtNombreSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposLetras(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            vali.CamposNumerosYLetras(e);
        }
    }
}

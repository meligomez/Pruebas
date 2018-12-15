using Modelo.Dominio;
using Modelo.Servicio;
using PalcoNet.VentanasPorRol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class UsuarioAlta : Form
    {
        public UsuarioAlta()
        {
            InitializeComponent();
        }

		private void UsuarioAlta_Load(object sender, EventArgs e)
		{
				
		}
		private bool todosCamposCompletos()
		{
			if (txtNombre.Text.Trim() == "")
			{ 
				MessageBox.Show("Ingrese un nombre", "¡Advertencia!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				//MensajesToolTip.showToolTip("Ingrese un nombre.", txtNombre, txtNombre.Location);
				return false;
			}
			if (txtApellido.Text.Trim() == "")
			{
				MessageBox.Show("Ingrese un apellido.", "¡Advertencia!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				//MensajesToolTip.showToolTip("Ingrese un apellido.", txtApellido, txtApellido.Location);
				return false;
			}
			if (txtMail.Text.Trim() == "")
			{
				MessageBox.Show("Ingrese un Mail.", "¡Advertencia!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				//MensajesToolTip.showToolTip("Ingrese un mail.", txtMail, txtMail.Location);
				return false;
			}
			if (txtContraseña.Text.Trim() == "")
			{
				MessageBox.Show("Ingrese una contraseña.", "¡Advertencia!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				//MensajesToolTip.showToolTip("Ingrese una contraseña.", txtContraseña, txtContraseña.Location);
				return false;
			}
			if (dtpFechaNacimiento.Text.Trim() == "" || dtpFechaNacimiento.Value == null)
			{
				MessageBox.Show("Ingrese la fecha de nacimiento.", "¡Advertencia!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				//MensajesToolTip.showToolTip("Ingrese una fecha de nacimiento.", dtpFechaNacimiento, dtpFechaNacimiento.Location);
				return false;
			}
			return true;
		}
		private void btnGuardar_Click(object sender, EventArgs e)
		{
			try
			{
				if (todosCamposCompletos())
				{
					Usuario usuario = new Usuario();
					usuario.password = txtContraseña.Text;
					
					UsuarioService service = new UsuarioService();
					int resp = service.altaUsuario(usuario);
					if (resp == 0)
					{
						MessageBox.Show("Error al conectarse con la DB. No se ha creado el Usuario.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					MessageBox.Show("Usuario " + txtNombre.Text + " creado satisfactoriamente.", "Alta de Usuario",
					MessageBoxButtons.OK);
					//new UsuarioMain().Show();
					new panelContenedor(usuario).Show();
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK);
			}
		}

		private void cancelarBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnGuardar_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (todosCamposCompletos())
				{
					Usuario usuario = new Usuario();
					usuario.password = txtContraseña.Text;

					UsuarioService service = new UsuarioService();
					int resp = service.altaUsuario(usuario);
					if (resp == 0)
					{
						MessageBox.Show("Error al conectarse con la DB. No se ha creado el Usuario.", "Error al crear Nuevo Usuario",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					MessageBox.Show("Usuario " + txtNombre.Text + " creado satisfactoriamente.", "Alta de Usuario",
					MessageBoxButtons.OK);
					//new UsuarioMain().Show();
					new panelContenedor(usuario).Show();
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK);
			}
		}
	}
}

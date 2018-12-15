using Modelo.Dominio;
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
	public partial class UsuarioCambiarPsw : Form
	{
		public Usuario userCP;
		public UsuarioCambiarPsw(Usuario user)
		{
			userCP = new Usuario();
			userCP.username = user.username;
			userCP.password = user.password;
			InitializeComponent();
			lblPswAnterior.Text = user.password;
			lblUsuario.Text = user.username;
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if(textBox2.Text ==null)
			{
				MessageBox.Show("Ingrese una contraseña.");
			}
			else
			{

				if(userCP.EditarPsw(userCP, textBox2.Text)>=0)
				{
					MessageBox.Show("Contraseña cambiada exitosamente", "¡Correcto!",
							MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					panelContenedor vgral = new panelContenedor(userCP);
					vgral.Show();
					this.Hide();
				}
			}

		}

		private void cancelarBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void UsuarioCambiarPsw_Load(object sender, EventArgs e)
		{

		}
	}
}

using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
	public partial class CambiarEstadoUnaPublicacion : Form
	{
		Usuario userLog = new Usuario();
		int codigoPublicacion;
		Publicacion publicacion = new Publicacion();
		public CambiarEstadoUnaPublicacion(Usuario u, int codigoP)
		{
			userLog = u;
			codigoPublicacion = codigoP;
			InitializeComponent();
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void CambiarEstadoUnaPublicacion_Load(object sender, EventArgs e)
		{
			lblEmpleado.Text = userLog.empresa.Empresa_Cuit;
			lblPublicacion.Text = codigoPublicacion.ToString();

			cbxEstado.Items.Add("Borrador");
			cbxEstado.Items.Add("Activa/Publicada");
			cbxEstado.Items.Add("Finalizada");
			
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (cbxEstado.SelectedItem.ToString() == "Borrador")
			{
				MessageBox.Show("No se puede pasar a el estado Borrador.", "¡Error!",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			if(cbxEstado.SelectedItem.ToString() == "Activa/Publicada")
			{
				publicacion.actualizarEstado(codigoPublicacion, 1);
				MessageBox.Show("Se ha cambiado el estado correctamente!", "¡Correcto!",
				MessageBoxButtons.OK, MessageBoxIcon.None);
			}
			if(cbxEstado.SelectedItem.ToString() == "Finalizada")
			{
				publicacion.actualizarEstado(codigoPublicacion, 2);
				MessageBox.Show("Se ha cambiado el estado correctamente!", "¡Correcto!",
				MessageBoxButtons.OK, MessageBoxIcon.None);
			}
			
		}
	}
}

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

namespace PalcoNet.Abm_Grado
{
    public partial class AltaGrado : Form
    {
        public AltaGrado()
        {
            InitializeComponent();
        }

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			try
			{
				// if (todosCamposCompletos())
				if (true)
				{
					Grado grado = new Grado();

					//Carga de datos
					grado.tipo = txtTipo.Text;
					grado.porcentaje = int.Parse(txtPorcentaje.Text);
					//Alta del cliente
					int resp = grado.Alta();
					if (resp != 0)
					{
						MessageBox.Show("Error!. No se ha creado el Grado.", "Error al crear Nuevo Grado",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					else
					{
						MessageBox.Show("Grado " + txtTipo.Text + " creado correctamente! ", "Grado Creado",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK);
			}
		}

        private void label3_Click(object sender, EventArgs e)
        {

        }
	}
}

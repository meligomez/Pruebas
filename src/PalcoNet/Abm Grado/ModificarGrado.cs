using Modelo.Base;
using Modelo.Comun;
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
	public partial class ModificarGrado : Form
	{
		public ModificarGrado()
		{
			InitializeComponent();
		}

		private void ModificarGrado_Load(object sender, EventArgs e)
		{
			cargarTabla();
		}
		private void cargarTabla()
		{
			DaoSP prueba = new DaoSP();
			CargarData.cargarGridView(dataGridGrado, prueba.ConsultarConQuery("select id as 'CÓDIGO', tipo as 'DESCRIPCIÓN',porcentaje as 'COMISIÓN',estado as 'ESTADO' from dropeadores.Grado "));
		}

		private void botonBuscar_Click(object sender, EventArgs e)
		{
			string tipo;
			if (txtTipo.Text != "")
				tipo = txtTipo.Text;
			DataTable respuesta = FiltrarGrado(txtTipo.Text);
			dataGridGrado.DataSource = respuesta;
			if (dataGridGrado.CurrentRow == null)
			{
				MessageBox.Show("El Cliente requerido no se encuentra.", "Baja de Grado",
				   MessageBoxButtons.OK);

				cargarTabla();

			}
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			if (dataGridGrado.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un Grado a modificar.",
				"", MessageBoxButtons.OK);
				return;
			}
			string tipo = dataGridGrado.CurrentRow.Cells["DESCRIPCIÓN"].Value.ToString();
			string id = dataGridGrado.CurrentRow.Cells["CÓDIGO"].Value.ToString();

			DialogResult dr = MessageBox.Show("Desea Modificar el GRADO " + tipo + "?",
	   "", MessageBoxButtons.YesNo);
			switch (dr)
			{
				case DialogResult.Yes:
					ModificarGradoSeleccionado(id);
					break;

				case DialogResult.No:
					break;
			}

		}

		private void ModificarGradoSeleccionado(string id)
		{
			this.Hide();
			int codigo = Int32.Parse(id);
			new ModificarGradoElegido(codigo).Show();

		}

		private DataTable FiltrarGrado(string tipo)
		{
			DaoSP dao = new DaoSP();
			Grado grado = new Grado();
			DataTable tabla_Cliente = null;
			var final_rol = "";
			int cant = grado.existGradoEnBd(tipo);
			var posFiltro = true;
			var filtrosBusqueda = new List<string>();

			if (cant != 0)
			{

				if (tipo != "")
				{
					tabla_Cliente = dao.ObtenerDatosSP("dropeadores.[getGradoSeleccionado]", tipo);
				}

				if (tipo != "") filtrosBusqueda.Add("DESCRIPCIÓN LIKE '%" + tipo + "%'");


				foreach (var filtro in filtrosBusqueda)
				{
					if (!posFiltro)
						final_rol += " AND " + filtro;
					else
					{
						final_rol += filtro;
						posFiltro = false;
					}
				}
				if (tabla_Cliente != null)
					tabla_Cliente.DefaultView.RowFilter = final_rol;

			}
			return tabla_Cliente;
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}

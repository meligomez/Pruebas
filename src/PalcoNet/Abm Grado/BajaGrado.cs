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
	public partial class BajaGrado : Form
	{
		public BajaGrado()
		{
			InitializeComponent();
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
		private DataTable FiltrarGrado(string tipo)
		{
			DaoSP dao = new DaoSP();
			Grado grado = new Grado();
			DataTable tabla_Cliente = null;
			string tipoVacio = "";
			int cant = grado.existGrado(tipo);
			var final_rol = "";
			var posFiltro = true;
			var filtrosBusqueda = new List<string>();

			if (cant != 0)
			{
				if (tipo != tipoVacio)
				{
					tabla_Cliente = dao.ObtenerDatosSP("dropeadores.getGrado", tipo);
				}
				else
				{
					tabla_Cliente = dao.ObtenerDatosSP("dropeadores.getGrado", tipoVacio);
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
				return tabla_Cliente;
			}

			return tabla_Cliente;

		}
		private void DeleteGrado(string id)
		{
			int codigo = Int32.Parse(id);
			DaoSP dao = new DaoSP();
			int x = dao.EjecutarSP("dropeadores.deleteGrado", id);

			// updateGrid();
		}
		private void BajaGrado_Load(object sender, EventArgs e)
		{
			cargarTabla();
		}
		private void cargarTabla()
		{
			DaoSP prueba = new DaoSP();
			CargarData.cargarGridView(dataGridGrado, prueba.ConsultarConQuery("select id as 'CÓDIGO', tipo as 'DESCRIPCIÓN',porcentaje as 'COMISIÓN',estado as 'ESTADO' from dropeadores.Grado WHERE estado =1"));
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			if (dataGridGrado.CurrentRow == null)
			{
				MessageBox.Show("Seleccione el Grado que desea eliminar.",
				"", MessageBoxButtons.OK);
				return;
			}

			//var senderGrid = (DataGridView)sender;


			if (((bool)dataGridGrado.CurrentRow.Cells["estado"].Value) == false)
			{
				MessageBox.Show("Grado ya deshabilitado.",
				"", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string tipo = dataGridGrado.CurrentRow.Cells["DESCRIPCIÓN"].Value.ToString();
			string id = dataGridGrado.CurrentRow.Cells["CÓDIGO"].Value.ToString();
			DialogResult dr = MessageBox.Show("Desea dar de Baja el GRADO " + tipo + "?",
				 "", MessageBoxButtons.YesNo);
			switch (dr)
			{
				case DialogResult.Yes:
					DeleteGrado(id);
					break;

				case DialogResult.No:
					break;
			}

			{
				MessageBox.Show("Baja Grado realizado exitosamente!.",
			"", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				cargarTabla();
				return;
			}
		}
	}
}

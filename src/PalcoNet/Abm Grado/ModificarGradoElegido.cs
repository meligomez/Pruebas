using Modelo.Base;
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
	public partial class ModificarGradoElegido : Form
	{
		Grado grado_Seleccionado;
		public static DataTable obtenerTabla(int id)
		{

			DaoSP dao = new DaoSP();
			return dao.ObtenerDatosSP("dropeadores.ObtenerGradoEspecifico", id);
		}

		public ModificarGradoElegido(int id)
		{
			grado_Seleccionado = obtener(id);
			InitializeComponent();
		}
		public static Grado obtener(int id)
		{
			List<Grado> lista = transductor(obtenerTabla(id));
			if (lista.Count == 0)
				return null;
			return lista[0];
		}
		public static List<Grado> transductor(DataTable tabla)
		{
			List<Grado> lista = new List<Grado>();
			foreach (DataRow fila in tabla.Rows)
			{

				Grado grado = new Grado();
				grado.id = Convert.ToInt32(fila["CÓDIGO"]);
				grado.tipo = Convert.ToString(fila["DESCRIPCIÓN"]);
				grado.porcentaje = Convert.ToInt32(fila["COMISIÓN"]);
				grado.estado = Convert.ToBoolean(fila["ESTADO"]);

				lista.Add(grado);
			}
			return lista;
		}
		private void cargarDatos()
		{

			txtTipo.Text = grado_Seleccionado.tipo;
			txtPorcentaje.Text = grado_Seleccionado.porcentaje.ToString();
			checkBaja.Checked = grado_Seleccionado.estado;
		}
		private void ModificarGradoElegidocs_Load(object sender, EventArgs e)
		{
			cargarDatos();
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (true)
			{
				grado_Seleccionado.tipo = txtTipo.Text;
				grado_Seleccionado.porcentaje = Int32.Parse(txtPorcentaje.Text);

				if (checkBaja.Checked)
				{
					grado_Seleccionado.estado = checkBaja.Checked;
				}

				if (!Grado.actualizar(grado_Seleccionado))
				{
					MessageBox.Show("Error al modificar el GRADO.", "Error al Modificar GRADO",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show("GRADO Modificado Correctamente.", "Modificar GRADO",
					MessageBoxButtons.OK, MessageBoxIcon.None);
					ModificarGrado GRAMod = new ModificarGrado();
					GRAMod.Show();
					this.Hide();

				}
			}
		}
	}
}

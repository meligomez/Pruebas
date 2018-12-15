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

namespace PalcoNet.Abm_Rol
{
	
	public partial class RolPorFuncionalidadesModificar : Form
	{
		public int IdRol { get; set; }
		public List<int> idsFuncionalidades { get; set; }
		public string nombreRolSeleccionado { get; set; }
		public List<int> idsFuncionalidadesUpdate { get; set; }
		public RolPorFuncionalidadesModificar()
		{
			InitializeComponent();
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			idsFuncionalidadesUpdate = new List<int>();
			try
			{
				for (int i = 1; i <= dgvFuncionalidades.RowCount; i++)
				{
					if (bool.Parse(dgvFuncionalidades.Rows[i - 1].Cells["seleccion"].Value.ToString()) == true)
					{
						idsFuncionalidadesUpdate.Add(i);//lo voy seleccionando al q cumpla
							
					}


				}
				Rol rol = new Rol();
				if(txtNombreRol.Text!="" && idsFuncionalidadesUpdate.Count>0 && IdRol>0)
				{
					//Si yo hago un update esta mal, debo insertar
					//pero si inserto estaria mal xq por ahi ya hay relaciones q existen
					//y tambien eso no quiere decir que borro las que ya existian...
					int habilitado = checkHabilitado.Checked ? 1 : 0;
					rol.realizarModificacion(IdRol, idsFuncionalidadesUpdate, txtNombreRol.Text,habilitado);
					MessageBox.Show("Se ha modificado correctamente!");
					this.Hide();
				}
				else
				{

				}
				
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void RolPorFuncionalidadesModificar_Load(object sender, EventArgs e)
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ConsultarConQuery("SELECT * FROM dropeadores.Rol ");
				CargarData.cargarComboBox(comboBox1, dt, "Id_Rol", "nombre");
				DataTable roles = dao.ConsultarConQuery("SELECT * FROM dropeadores.Funcionalidad");
				CargarData.cargarGridView(dgvFuncionalidades, roles);
				CargarData.AddCheckColumn(dgvFuncionalidades, "Seleccionar");
				txtNombreRol.Text = "";
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}
		private void nombreRol_Change(object sender, EventArgs e)
		{
			limpiarDgv(dgvFuncionalidades);
			DataRowView dr = (DataRowView) (comboBox1.SelectedItem) ;
			Rol rol = new Rol();
			nombreRolSeleccionado = dr["nombre"].ToString();
			string indexseleccionado = comboBox1.SelectedValue.ToString();
			IdRol = int.Parse(indexseleccionado);
			txtNombreRol.Text = nombreRolSeleccionado;
			if(indexseleccionado !="0")
			{
				rol = rol.obtenerRol(IdRol);
				if (rol.estado == true)
				{
					checkHabilitado.Checked = true;
				}
				idsFuncionalidades=rol.BuscarFuncionalidadesPorRol(IdRol, dgvFuncionalidades);
			}

		}

		private void limpiarDgv(DataGridView dgv)
		{
			txtNombreRol.Text = "";
			for (int i = 1; i <= dgvFuncionalidades.RowCount; i++)
			{
				//lo voy seleccionando al q cumpla
				dgvFuncionalidades.Rows[i - 1].Cells["seleccion"].Value = false;
			}
			checkHabilitado.Checked = false;
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}

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
	public partial class RolEliminar : Form
	{
		public RolEliminar()
		{
			InitializeComponent();
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ConsultarConQuery("SELECT * FROM dropeadores.Rol where estado=1");
				CargarData.cargarComboBox(comboBox1, dt, "Id_Rol", "nombre");
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			
			int indexAEliminar =int.Parse(comboBox1.SelectedValue.ToString());
			Rol rol = new Rol();
			if(rol.eliminadoLogico(indexAEliminar) && rol.sacarRolATodosLosUsuarios(indexAEliminar))
			{
				MessageBox.Show("Rol eliminado correctamente.", "¡Correcto!",
								MessageBoxButtons.OK, MessageBoxIcon.None);
				this.Hide();
			}
			else
			{
				MessageBox.Show("No se pudo eliminar el rol", "Error al crear el Rol",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}

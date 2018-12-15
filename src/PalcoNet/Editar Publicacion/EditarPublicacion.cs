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

namespace PalcoNet.Editar_Publicacion
{
	public partial class EditarPublicacion : Form
	{
		Usuario userLogueado;
		public EditarPublicacion(Usuario u)
		{
			userLogueado = u;
			InitializeComponent();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				int Codigo = int.Parse(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
				//Modificando
				if (this.dataGridView1.Columns[e.ColumnIndex].Name.Equals("Editar"))
				{
					DialogResult dr = MessageBox.Show("¿Desea modificar:  " + Codigo + "?", "Modificar", MessageBoxButtons.YesNo);
					switch (dr)
					{
						case DialogResult.Yes:
							//Nuevo Form que recibe el codigo de la publicacion a modificar.
							btnEditPublic edituna = new btnEditPublic(userLogueado, Codigo);
							edituna.Show();
							this.Hide();
							break;
						case DialogResult.No: break;
					}
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void EditarPublicacion_Load(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			DaoSP dao = new DaoSP();
			//ESTADO EN CERO INDICA QUE ES BORRADOR!.
			string query = "SELECT p.id as 'Codigo',r.rubro_Descripcion as 'Rubro',g.tipo as 'Grado',p.descripcion as 'Descr. Espectaculo',stock,fechaPublicacion as 'Fecha Publicacion',fechaEspectaculo as 'Fecha Espectaculo',direccion as 'Direccion Espec.'FROM dropeadores.Publicacion p " +
				" join dropeadores.Rubro r on(r.id=p.rubroId)" +
				" join dropeadores.Grado g on(g.id=p.gradoId)"+
				" where empresaId= '" + userLogueado.empresa.Empresa_Cuit + "' and p.estado=0";
			dt = dao.ConsultarConQuery(query);
			CargarData.cargarGridView(dataGridView1, dt);
			lblEmpleado.Text = userLogueado.empresa.Empresa_Cuit;
			CargarData.AddButtonEditColumn(dataGridView1);
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}

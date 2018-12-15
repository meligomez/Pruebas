using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Dominio
{
	public class RolXFunc
	{
		public int insertarRolPorFunc(string nombre, DataGridView dgvFuncionalidades)
		{
			DaoSP dao = new DaoSP();
			DataTable dt = new DataTable();
			List<int> ChkedRow = new List<int>();
			int i = 0;
			for (i = 0; i <= dgvFuncionalidades.RowCount - 1; i++)
			{
				if (Convert.ToBoolean(dgvFuncionalidades.Rows[i].Cells["seleccion"].Value) == true)
				{
					ChkedRow.Add(i);
				}
			}
			if (ChkedRow.Count == 0)
			{
				MessageBox.Show("Debe Seleccionar al menos una funcionalidad", "Error al crear el Rol",
					 MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
			else
			{
				if (dao.EjecutarSP("dropeadores.Alta_Rol", nombre) > 0)
				{
					dt = dao.ObtenerDatosSP("dropeadores.Rol_ObtenerId");
					DataRow rowRol = dt.Rows[0];
					int idRol = int.Parse(rowRol["Id"].ToString());			
				
					foreach (int k in ChkedRow)
					{
						//Insertar en el muchos a muchos ese ID de rol y cada Funcionalidad Seleccionada
						int idFunc = int.Parse(dgvFuncionalidades.Rows[k].Cells["Id_Funcionalidad"].Value.ToString());
						if (dao.EjecutarSP("dropeadores.AltaRolPorFuncionalidad", idRol, idFunc) < 0)
						{
							MessageBox.Show("Ha ocurrido un error..", "Error al crear el Rol",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							return -1;
						}
					}
					return 0;
				}
				else
				{
					MessageBox.Show("Ha ocurrido un error", "Error al crear el Rol",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return -1;
				}
			}
		}

		internal List<int> getFuncionalidadesPorRol(int rolId)
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				List<int> resp = new List<int>();
				dt = dao.ObtenerDatosSP("dropeadores.getFuncionalidadPorRol", rolId);
				int res = 0;
				foreach (DataRow row in dt.Rows)
				{
					foreach (DataColumn column in dt.Columns)
					{
						res = int.Parse(row[column].ToString());
						resp.Add(res);
					}
				}
				return resp;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

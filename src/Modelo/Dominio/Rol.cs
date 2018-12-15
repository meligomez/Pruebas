using Modelo.Base;
using Modelo.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Modelo.Dominio
{
	public class Rol
	{
		#region Atributos
		public int Id_Rol { get; set; }
		public string nombre = "";
		public bool estado = true;
		public bool Eliminado { get; set; }
		public DateTime? FechaEliminacion { get; set; }
		//private string usr = "''";
		#endregion
		public Rol()
		{
			this.Eliminado = false;
		}
		#region Propiedades
		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		public bool Estado
		{
			get { return estado; }
			set { estado = value; }
		}

		public void realizarModificacion(int idRol, List<int> idsFuncionalidades, string nombreRolSeleccionado, int habilitado)
		{
			DaoSP dao = new DaoSP();
			RolXFunc rolxfunc = new RolXFunc();
			dao.EjecutarConQuery("UPDATE dropeadores.Rol SET nombre= '" + nombreRolSeleccionado +"', estado= "+habilitado+" WHERE Id_Rol ="+idRol);

			dao.EjecutarConQuery("delete dropeadores.FuncionalidadXRol where rolId=" + idRol);

			foreach (int unId in idsFuncionalidades)
			{
				
				if (dao.EjecutarSP("dropeadores.AltaRolPorFuncionalidad", idRol, unId) < 0)
				{
					MessageBox.Show("Ha ocurrido un error..", "Error al crear el Rol",
						MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
			}



		}

		//public string Usr
		//{
		//    get { return usr; }
		//    set { usr = value; }
		//}
		#endregion

		public bool existeRol(string nombre)
		{ 
			DaoSP dao = new DaoSP();
			DataTable dt = new DataTable();
			dt=dao.ConsultarConQuery("SELECT nombre FROM dropeadores.Rol WHERE nombre LIKE '"+nombre+"'");
			return dt.Rows.Count > 0 ? true:false ;
		}

		public bool eliminadoLogico(int indexAEliminar)
		{
			try
			{
				DaoSP dao = new DaoSP();
				int nroFilasAfectadas = dao.EjecutarConQuery(@"UPDATE dropeadores.Rol SET estado=0 WHERE Id_Rol =" + indexAEliminar);
				return nroFilasAfectadas > 0 ? true : false;
			}
			
			catch (Exception ex )
			{

				throw ex;
			}
		}

		public Rol obtenerRol(int indexRolSeleccionado)
		{
			DataTable dt = new DataTable();
			DaoSP dao = new DaoSP();
			dt = dao.ConsultarConQuery("select * from dropeadores.Rol WHERE Id_Rol="+indexRolSeleccionado);
			DataRow row = dt.Rows[0];
			return new Rol
			{
				nombre = row["nombre"].ToString(),
				estado = bool.Parse(row["estado"].ToString())
			};
		}
		public List<int> BuscarFuncionalidadesPorRol(int rolId,DataGridView dgvFuncionalidades)
		{
			List<int> ChkedRow = new List<int>();
			RolXFunc funcPorRols = new RolXFunc();
			Rol r = new Rol();

			int i = 0;
			try
			{
				List<Funcionalidad> f = new List<Funcionalidad>();
				List<int> idsFuncionalidades = new List<int>();
				idsFuncionalidades = funcPorRols.getFuncionalidadesPorRol(rolId);
				for (i = 1; i <= dgvFuncionalidades.RowCount; i++)
				{
					if (idsFuncionalidades.Contains(i))
					{
						//lo voy seleccionando al q cumpla
						dgvFuncionalidades.Rows[i - 1].Cells["seleccion"].Value = true;
					}


				}

				return idsFuncionalidades;

			}
			catch (Exception e)
			{ throw e; }

		}
		public bool sacarRolATodosLosUsuarios(int indexAEliminar)
		{
			try
			{
				DaoSP dao = new DaoSP();
				Usuario user = new Usuario();
				DataTable dt = new DataTable();
				dt = dao.ConsultarConQuery("select usuarioId from dropeadores.RolXUsuario where rolId=" + indexAEliminar);
				this.eliminadoFisicoRolesXUser(dt, indexAEliminar);
				return true;
			}
			catch (Exception ex)
			{

				throw ex ;
			}
			//se le debe quitar el rol inhabilitado a todos aquellos usuarios que lo posean.
			
		}

		private void eliminadoFisicoRolesXUser(DataTable dt, int indexAEliminar)
		{
			DaoSP dao = new DaoSP();
			foreach (DataRow row in dt.Rows)
			{
				dao.EjecutarConQuery("DELETE FROM dropeadores.RolXUsuario WHERE rolId=" + indexAEliminar + " AND usuarioId=" + row["usuarioId"]);
			}
			
		}
		//Aca queria buscar el rol logueado.. NO CREE EL SP.
		//public string obtenerRolDelUser(string username)
		//{
		//	string rol;
		//	try
		//	{
		//		DaoSP daoSP = new DaoSP();
		//		DataTable dt;
		//		dt = daoSP.ObtenerDatosSP("obtenerRolDelUser", username);
		//		return rol;
		//	}
		//	catch (Exception ex)
		//	{

		//		throw ex;
		//	}
		//}
	}

}

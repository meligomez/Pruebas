using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class TipoUbicacion
	{
		public int codigo { get; set; }
		public string descripcion { get; set; }
		public decimal precio { get; set; }



		public int darAltaPrecioPorCategoria(decimal precio, string categoria)
		{
			try
			{
				int tipoUbicacionId;
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ObtenerDatosSP("dropeadores.altaTipoUbicacion", categoria, precio);
				DataRow row = dt.Rows[0];
				tipoUbicacionId = int.Parse(row["Id"].ToString());
				return tipoUbicacionId;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}
		public int buscarCodigoCategoria(string categoria)
		{
			try
			{
				int tipoUbicacionId;
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ObtenerDatosSP("dropeadores.buscarCodigoTipoUbicacion", categoria);
				DataRow row = dt.Rows[0];
				tipoUbicacionId = int.Parse(row["codigo"].ToString());
				return tipoUbicacionId;
			}
			catch (Exception ex)
			{

				throw ex;
			}

		}

		public int getIdByDescripcion(string descripcion)
		{
			try
			{
				int Id;
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ObtenerDatosSP("dropeadores.getIdByDescripcion", descripcion);
				DataRow row = dt.Rows[0];
				Id = int.Parse(row["Id"].ToString());
				return Id;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}

	}
}

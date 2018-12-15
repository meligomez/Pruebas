using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class Ubicacion
	{
		public char fila { get; set; }
		public  int asiento { get; set; }
		public bool sinEnumerar { get; set; }
		//public decimal precio { get; set; }
		//public int tipoCodigo { get; set; }
		//public string tipoDescripcion { get; set; }
		public int estado { get; set; }
		public int publicacionId { get; set; }
		public int tipoUbicacionId { get; set; }

		public decimal precio { get; set; }

		public int altaUbicaciones(List<Ubicacion> buscarButtons, int idPublicacion)
		{
			foreach (Ubicacion unaUbicacion in buscarButtons)
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				//el estado acá indica si esa ubicacion ya fue ocupada o no....
			if( dao.EjecutarSP("dropeadores.AltaUbicacion", unaUbicacion.asiento, unaUbicacion.fila, unaUbicacion.estado,unaUbicacion.tipoUbicacionId,idPublicacion,unaUbicacion.precio)<=0)
				{
					break;
				}
			}
			return 0;
		}

		public int updatePreciosDeCategoria(int codigoPublicacion, int codigoTipoUbicacion, decimal precio)
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dao.EjecutarSP("dropeadores.UpdatePrecioUbicacion", codigoPublicacion, codigoTipoUbicacion, precio);
				return 0;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		
	}
}

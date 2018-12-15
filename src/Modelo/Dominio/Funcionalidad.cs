using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;

namespace Modelo.Dominio
{
	public class Funcionalidad
	{
		public int Id_funcionalidad { get; set; }
		public string descripcion { get; set; }

		public DataTable GetFuncionalidadesPorUsuario(int usuarioId)
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				if (usuarioId == 0)
				{
					return dt;
				}
				return dao.ObtenerDatosSP("dropeadores.GetFuncionalidades", usuarioId);
			}
			catch (Exception ex)
			{

				throw;
			}

		}
		//public List<Funcionalidad> GetListFuncionalidadesPorUsuario(int usuarioId)
		//{
		//    try
		//    {
		//        DaoSP dao = new DaoSP();
		//        DataTable dt = new DataTable();
		//        if (usuarioId == 0)
		//        {
		//            return dt;
		//        }
		//        return dao.ObtenerListadoSP<Funcionalidad>("dropeadores.GetFuncionalidades", usuarioId);
		//    }
		//    catch (Exception ex)
		//    {

		//        throw;
		//    }

		//}
	}
}
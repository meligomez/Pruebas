using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class Grado
	{
		public int id { get; set; }
		public string tipo { get; set; }
		public int porcentaje { get; set; }
		public bool estado { get; set; }

		public int existGrado(string tipo)
		{
			DataTable dt = new DataTable();
			int cant = 0;
			DaoSP dao = new DaoSP();
			dt = dao.ConsultarConQuery("select count(g.id) as 'cantidad' from dropeadores.Grado g WHERE g.estado =1 and g.tipo LIKE" + "'" + tipo + "'");

			foreach (DataRow row in dt.Rows)
			{
				cant = Convert.ToInt32(row["cantidad"]);
			}
			return cant;
		}

		public int existGradoEnBd(string tipo)
		{
			DataTable dt = new DataTable();
			int cant = 0;
			DaoSP dao = new DaoSP();
			dt = dao.ConsultarConQuery("select count(g.id) as 'cantidad' from dropeadores.Grado g WHERE g.tipo LIKE" + "'" + tipo + "'");

			foreach (DataRow row in dt.Rows)
			{
				cant = Convert.ToInt32(row["cantidad"]);
			}
			return cant;
		}

		public int Alta()
		{
			try
			{
				int retorno = 9;
				DaoSP dao = new DaoSP();
				int cant = this.existGrado(this.tipo);

				if (cant == 0)
				{
					if (dao.EjecutarSP("dropeadores.Grado_Alta", this.tipo, this.porcentaje) > 0)
					{
						retorno = 0;
					}
					else
					{
						retorno = -1;
					}
				}

				return retorno;
			}
			catch (Exception ex)
			{
				return -1;
			}
		}


		public static bool actualizar(Grado grado_Seleccionado)
		{

			DaoSP dao = new DaoSP();
			DataTable dt = new DataTable();

			string tipo = grado_Seleccionado.tipo;
			int id = grado_Seleccionado.id;
			int porcentaje = grado_Seleccionado.porcentaje;
			int campoBaja = (grado_Seleccionado.estado) ? 1 : 1;

			if (dao.EjecutarSP("dropeadores.updateGrado", id, tipo, porcentaje, campoBaja) > 0)
			{

				return true;

			}


			return false;
		}


	}
}

using Modelo.Base;
using Modelo.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Dominio
{
	public class Estadistica
	{
		
		public DataTable getClientesMasPuntosVencidos(DataGridView dataGridView1, string trimestre, string anio)
		{
			DataTable dt = new DataTable();
			
			DaoSP dao = new DaoSP();
			 dt = dao.ObtenerDatosSP("dropeadores.getClientesMasPuntosVencidos",trimestre,anio);
			return dt;
		
		}

		public DataTable getClientesMayorCompras(DataGridView dataGridView1,string trimestre, string anio)
		{
			DataTable dt = new DataTable();
			DaoSP dao = new DaoSP();
			dt = dao.ObtenerDatosSP("dropeadores.getClientesMayorCantCompras", trimestre, anio);
			return dt;
		}
		public DataTable getLocalidadesNoVendidas(DataGridView dataGridView1, string trimestre, string anio)
		{
			DataTable dt = new DataTable();
			DaoSP dao = new DaoSP();
			dt = dao.ObtenerDatosSP("dropeadores.getClientesMasPuntosVencidos", trimestre, anio);
			return dt;
		}

	}
}

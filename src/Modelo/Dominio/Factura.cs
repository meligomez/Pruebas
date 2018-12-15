using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class Factura
	{
		public int id { get; set; }
		public DateTime Fecha { get; set; }
		public decimal TotalComisionCobrada { get; set; }
		public decimal TotalEmpresaPagado { get; set; }
		//public string FormaPago { get; set; }
		public string empresaId { get; set; }

		public int altaFactura()
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt=dao.ObtenerDatosSP("dropeadores.altaFactura",this.Fecha,this.TotalComisionCobrada,this.TotalEmpresaPagado,this.empresaId);
				DataRow row2 = dt.Rows[0];
				int idFactura = int.Parse(row2["Id"].ToString());
				return idFactura;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}

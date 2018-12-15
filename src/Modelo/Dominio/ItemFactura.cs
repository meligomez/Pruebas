using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class ItemFactura
	{
		public int id { get; set; }
		public int Cantidad { get; set; }
		public decimal Monto { get; set; }
		public string descripcion { get; set; }
		public int compraId { get; set; }
		public int facturaId { get; set; }

		public void altaItem()
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ObtenerDatosSP("dropeadores.altaItem", this.Cantidad, this.Monto, this.descripcion, this.compraId,this.facturaId);
				//DataRow row2 = dt.Rows[0];
				//int idFactura = int.Parse(row2["Id"].ToString());
				
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}

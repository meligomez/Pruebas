using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class RendicionComision
	{
		public int idCompra { get; set; }
		public int idPublicacion { get; set; }
		public string descripcion { get; set; }
		public decimal porcentaje { get; set; }
		public char fila { get; set; }
		public int asiento { get; set; }
		public decimal precio { get; set; }
		public DateTime fechaCompra { get; set; }
		public decimal comisionTotalCobrada { get; set; }
		public decimal pagadoAEmpresa { get; set; }
		public string cuitEmpresa { get; set; }
		public int cantidad { get; set; }
	}
}

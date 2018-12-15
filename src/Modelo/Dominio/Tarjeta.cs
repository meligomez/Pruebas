using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class Tarjeta
	{
		public long Id { get; set; }
		public string propietario { get; set; }
		public string numero { get; set; }
		public DateTime fechaVencimiento { get; set; }
		public DateTime? fecha_vencimiento = null;
		public string descripcion { get; set; }
		public static string[] string_tipo = new string[2] { "DEBITO", "CREDITO" };

		public string Fecha_vencimiento
		{
			get { return ((DateTime)fecha_vencimiento).ToString("yyyyMMdd"); }
			set { fecha_vencimiento = DateTime.Parse(value); }
		}
		public DateTime? Fecha_vencimiento_struct
		{
			get { return fecha_vencimiento; }
			set { fecha_vencimiento = value; }
		}

		public Cliente tar_cli { get; set; }


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Comun
{
	public interface IEliminadoSuave
	{
		bool Eliminado { get; set; }
		DateTime? FechaEliminacion { get; set; }
	}
}

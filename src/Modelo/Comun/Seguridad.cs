using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Comun
{
	public class Seguridad
	{
		public bool verificarPassword(string pass, string hashPass)
		{
			try
			{
				return (HashHelpers.SHA256(pass) == hashPass ? true : false);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

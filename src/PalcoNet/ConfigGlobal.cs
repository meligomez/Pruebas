using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet
{
	public class ConfigGlobal
	{
		public DateTime getFechaSistema()
		{
			return Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaSistema"]);
		}
	}
}

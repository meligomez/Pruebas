using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modelo.Comun
{
	public class MensajesToolTip
	{
		public static void showToolTip(string msj, Control ventana)
		{
			ToolTip toolTip = new ToolTip();
			toolTip.Hide(ventana);
			toolTip.SetToolTip(ventana, "Entrada Invalida");
			toolTip.Show(msj, ventana, 50, 10, 5000);
		}

	}
}

using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Modelo.Base
{
	public class Helpers
	{
		#region Configuracion
		private static int _userID = 0;

		//private static string connectionString = ConfigurationManager.ConnectionStrings["sqlserver2008"].ConnectionString;
		private static bool isLogged = false;

		public static int userID
		{
			get { return _userID; }
			set { _userID = value; }
		}
		public static DateTime getFechaSistema()
		{
			return Convert.ToDateTime(ConfigurationSettings.AppSettings["fechaSistema"]);
		}

		public static void setAdminLoggeado(bool status)
		{
			isLogged = status;
		}

		public static bool adminLoggeado()
		{
			return isLogged;
		}
		#endregion

		#region Globales

		public static logueo infoSesion;


		public struct logueo
		{
			public Usuario User;
			public Rol Rol;
			//public Hotel Hotel;
			public logueo(Usuario a, Rol b)
			{
				User = a;
				Rol = b;
			}
			//public logueo(Usuario a, Rol b, Hotel c)
			//{
			//	User = a;
			//	Rol = b;
			//	Hotel = c;
			//}
		}

		//public static double obtenerPrecio(int codRegimen, int cantPersonas, int recargo)
		//{
		//	Regimen reg = DAORegimen.obtener(codRegimen);

		//	return (reg.Precio * cantPersonas) + recargo;
		//}

		public static int esElMismoDia(DateTime fecha1, DateTime fecha2)
		{
			int dia1 = fecha1.Day;
			int dia2 = fecha2.Day;
			int mes1 = fecha1.Month;
			int mes2 = fecha2.Month;
			int anio1 = fecha1.Year;
			int anio2 = fecha2.Year;

			if (dia1 == dia2 && mes1 == mes2 && anio1 == anio2)
				return 0; //Si son el mismo dia
			if (fecha1.CompareTo(fecha2) > 0) //Si la fecha1 es posterior a fecha2 retorna 1, vencido
				return 1;
			return -1; //La fecha es anterior
		}

		#endregion

		#region Singletons Ventanas
		private static Form ventanaAnterior;
		private static List<Form> listaVentanas = new List<Form>();
		public static Form VentanaAnterior
		{
			get { return ventanaAnterior; }
			set { ventanaAnterior = value; }
		}

		public static void deshabilitarAnterior(Form vent)
		{
			vent.Visible = false;
			ventanaAnterior = vent;
			listaVentanas.Add(vent);
		}

		public static void habilitarAnterior()
		{
			int pos = listaVentanas.Count;
			if (pos > 0)
			{
				ventanaAnterior = listaVentanas[pos - 1];
				listaVentanas.RemoveAt(pos - 1);
				ventanaAnterior.Visible = true;
			}
		}

		#endregion




	}
}

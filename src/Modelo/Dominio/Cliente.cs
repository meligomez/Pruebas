using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class Cliente
	{
		public int numeroDocumento { get; set; }
		public string nombre { get; set; }
		public string apellido { get; set; }
		public string tipoDocumento { get; set; }
		public string cuil { get; set; }
		public string mail { get; set; }
		public bool estado { get; set; }
		public DateTime fechaNacimiento { get; set; }
		private DateTime? fecha_nacimiento = null;
		public DateTime fechaCreacion { get; set; }
		public int telefono { get; set; }
        private Documento documento=new Documento();
		public Domicilio Cli_Dir { get; set; }
		public Tarjeta Cli_Tar { get; set; }
        

		public string Fecha_nacimiento
		{
			get { return ((DateTime)fecha_nacimiento).ToString("yyyyMMdd"); }
			set { fecha_nacimiento = DateTime.Parse(value); }
		}
		public DateTime? Fecha_nacimiento_struct
		{
			get { return fecha_nacimiento; }
			set { fecha_nacimiento = value; }
		}
        public DocumentoTipoEnum TipoDocu_enum
        {
            get { return documento.Tipo; }
            set { documento.Tipo = value; }
        }

		public static bool actualizar(Cliente cliente_seleccionado)
		{

			DaoSP dao = new DaoSP();
			DataTable dt, dr = new DataTable();
			int IDcliente = 000000;
			//string cadena_nula = "";
			string nombre = cliente_seleccionado.nombre;
			string apellido = cliente_seleccionado.apellido;
			string tipoDocumento = cliente_seleccionado.tipoDocumento;
			int numeroDocumento = cliente_seleccionado.numeroDocumento;
			string cuil = cliente_seleccionado.cuil;
			string email = cliente_seleccionado.mail;
			int telefono = cliente_seleccionado.telefono;
			DateTime fecha_nacimiento = cliente_seleccionado.fechaNacimiento;
			//string fecha_nacimiento = (cliente_seleccionado.Fecha_nacimiento_struct != null) ? cliente_seleccionado.Fecha_nacimiento : cadena_nula;
			string calle = cliente_seleccionado.Cli_Dir.calle;
			int numero = cliente_seleccionado.Cli_Dir.numero;
			int piso = cliente_seleccionado.Cli_Dir.piso;
			string depto = cliente_seleccionado.Cli_Dir.dpto;
			string localidad = cliente_seleccionado.Cli_Dir.localidad;
            
            string ciudad = cliente_seleccionado.Cli_Dir.ciudad;
			int cp = cliente_seleccionado.Cli_Dir.cp;
			string propietarioTar = cliente_seleccionado.Cli_Tar.propietario;
			string numeroTar = cliente_seleccionado.Cli_Tar.numero;
			DateTime fecha_vencimiento = cliente_seleccionado.Cli_Tar.fechaVencimiento;

			//  string fecha_vencimiento = (cliente_seleccionado.Cli_Tar.Fecha_vencimiento_struct != null) ? cliente_seleccionado.Cli_Tar.Fecha_vencimiento : cadena_nula;
			int campoBaja = (cliente_seleccionado.estado) ? 1 : 1;
			//SEGUIR MODIFICANDO 
			dt = dao.ConsultarConQuery("SELECT cliente_domicilio FROM dropeadores.Cliente WHERE tipoDocumento like " + "'" + tipoDocumento + "'");
			dr = dao.ConsultarConQuery("SELECT cliente_domicilio FROM dropeadores.Cliente WHERE numeroDocumento like " + "'" + numeroDocumento + "'");

			foreach (DataRow row in dt.Rows)
			{
				foreach (DataRow row1 in dr.Rows)
				{
					IDcliente = Convert.ToInt32(row["cliente_domicilio"].ToString());
				}

			}
			//TESTEARR!
			if (dao.EjecutarSP("dropeadores.updateDomicilioCliente", IDcliente, calle, numero, piso, depto, localidad, " ", cp) > 0)
			{
				if (dao.EjecutarSP("dropeadores.updateTarjetaCliente", numeroDocumento, propietarioTar, numeroTar, fecha_vencimiento) > 0)
				{

					if (dao.EjecutarSP("dropeadores.updateCliente", numeroDocumento, nombre, apellido, tipoDocumento, cuil, email, fecha_nacimiento, IDcliente, telefono, campoBaja) > 0)
					{

						return true;

					}

				}

			}

			return false;
		}


		internal int existEmpresa(string cuil, int numDni)
		{

			DataTable dt, dr, da = new DataTable();
			int cant = 0;
			DaoSP dao = new DaoSP();
			dt = dao.ConsultarConQuery("select count(c.numeroDocumento) as 'cantidad' from dropeadores.Cliente c where c.estado=1 and c.cuil LIKE" + "'" + cuil + "'");
			dr = dao.ConsultarConQuery("select count(c.numeroDocumento) as 'cantidad' from dropeadores.Cliente c where c.estado=1 and c.numeroDocumento=" + numDni);
			foreach (DataRow row in dt.Rows)
			{
				cant = Convert.ToInt32(row["cantidad"]);
			}
			foreach (DataRow row in dr.Rows)
			{
				cant = cant + Convert.ToInt32(row["cantidad"]);
			}

			return cant;

		}
		public static int updateTarj(Cliente cli)
		{
			DataTable dt, dr = new DataTable();
			DaoSP dao = new DaoSP();
			string propietarioTar = cli.Cli_Tar.propietario;
			string numeroTar = cli.Cli_Tar.numero;
			DateTime fecha_vencimiento = cli.Cli_Tar.fechaVencimiento;
			string descripcion = cli.Cli_Tar.descripcion;
			int numeroDocumento = cli.numeroDocumento;

			if (dao.EjecutarSP("dropeadores.asociarTarjetaCliente", numeroDocumento, propietarioTar, numeroTar, fecha_vencimiento, descripcion) > 0)
			{

				return 0;

			}
			else
			{

				return 1;

			}


		}
	}


}

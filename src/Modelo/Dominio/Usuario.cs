using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Modelo.Auxiliares;
using System.Net.Mail;
using Modelo.Dominio;
using Modelo.Base;
using System.Data;

namespace Modelo.Dominio
{
	public class Usuario
	{
		public string creadoPor;
		#region Atributos
		public int Id { get; set; }
		public string username { get; set; }
		public string password { get; set; } //password encriptado con SHA256
		public Cliente cliente { get; set; }

		public int cambioPsw { get; set; }

        public Empresa empresa { get; set; }
			
		public DateTime fechaCreacionPsw { get; set; }
		public int estado { get; set; }
		#endregion

		#region Propiedades
		//public string Mail
		//{
		//	get
		//	{
		//		if (mail != null)
		//			return mail.Address;
		//		else
		//			return "''";
		//	}
		//	set
		//	{
		//		if (value != "")
		//			mail = new MailAddress(value);
		//	}
		//}
		//public int Telefono
		//{
		//	get { return _telefono; }
		//	set { _telefono = value; }
		//}
		//public string Fecha_nacimiento
		//      {
		//          get { return ((DateTime)fechaNacimiento).ToString("yyyyMMdd"); }
		//          set { fechaNacimiento = DateTime.Parse(value); }
		//      }

		//public DateTime? Fecha_nacimiento_struct
		//{
		//	get { return fechaNacimiento; }
		//	set { fechaNacimiento = value; }
		//}

		#endregion

		#region Constructor
		//public Usuario()
		//{
		//	this.eliminado = false;
		//	this.habilitado = true;
		//}
		#endregion

		//public bool estoyInhabilitado() { return habilitado; }

		public int Alta()
		{
			int retorno = 9;
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				Usuario usuario = new Usuario();
				Cliente cli = new Cliente();
				Domicilio dire = cliente.Cli_Dir;
				Tarjeta tar = new Tarjeta();

				int cant = cli.existEmpresa(cliente.cuil, cliente.numeroDocumento);

				//  if (dao.EjecutarSP("dropeadores.ExistCliente",cliente.cuil,cliente.numeroDocumento)==0)
				if (cant == 0)
				{
                    
					if (dao.EjecutarSP("dropeadores.Domicilio_Cli_Alta", dire.calle, dire.numero, dire.piso, dire.dpto, dire.localidad, dire.cp) > 0)
					{
						dt = dao.ObtenerDatosSP("dropeadores.DireCli_ObtenerId");
						DataRow row = dt.Rows[0];
						int idDireClienteInsertado = int.Parse(row["Id"].ToString());
						if (dao.EjecutarSP("dropeadores.Cli_Alta", cliente.nombre, cliente.apellido, cliente.tipoDocumento, cliente.numeroDocumento, cliente.mail, cliente.fechaNacimiento, cliente.cuil, cliente.telefono, idDireClienteInsertado, this.fechaCreacionPsw) > 0)
						{
							dt = dao.ObtenerDatosSP("dropeadores.Cli_ObtenerId", idDireClienteInsertado);
							DataRow row2 = dt.Rows[0];
							int idClienteInsertado = int.Parse(row2["Id"].ToString());
							if (dao.EjecutarSP("dropeadores.Cliente_Alta_Tarjeta", cliente.Cli_Tar.propietario, cliente.Cli_Tar.numero, cliente.Cli_Tar.fechaVencimiento, cliente.numeroDocumento) > 0)
							{
								if (dao.EjecutarSP("dropeadores.Usuario_Alta", cliente.numeroDocumento, this.username, this.password, this.fechaCreacionPsw, this.creadoPor) > 0)
								{
									retorno = 0;
								}
								else
								{
									retorno = -1;
								}
							}
						}

					}
				}



				return retorno;
			}
			catch (Exception ex)
			{
				return -1;
			}
		}
		public int EditarPsw(Usuario user,string nuevaPsw)
		{
			DaoSP dao = new DaoSP();
			DataTable dt = new DataTable();
			try
			{
				if (dao.EjecutarSP("dropeadores.Usuario_UpdatePsw", user.username, nuevaPsw) > 0)
				{
					return 0;
				}
				return -1;
			 }
			catch (Exception ex)
			{

				throw ex;
			}
		}

		//public string ObtenerRol(string username)
		//{
		//	DaoSP dao = new DaoSP();
		//	DataTable dt = new DataTable();
		//	try
		//	{
		//			dt = dao.ObtenerDatosSP("dropeadores.obtenerRolDeUsuario", username);
		//			string rol;
		//		List<string> roles = new List<string>;
		//		foreach (DataRow i in dt.Rows)
		//		{
		//			rol = i["rol"].ToString();
		//			roles.Add(rol);
		//		}
		//		return 
				
		//	}
		//	catch (Exception ex)
		//	{

		//		throw ex;
		//	}
		//}





		public int AltaEmpresa()
        {
            int retorno=9;
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
                Domicilio dom = empresa.Empresa_Dom;
                Usuario usuario = new Usuario();

                if (dao.EjecutarSP("dropeadores.ExistCuitandRazonSocial", empresa.Empresa_Cuit, empresa.Empresa_razon_social) > 0)
                {
                    return 0;
                }

                if (dao.EjecutarSP("dropeadores.Domicilio_empresa_Alta", dom.calle, dom.numero, dom.piso, dom.dpto, dom.localidad, dom.cp, dom.ciudad) > 0)
                {
                    dt = dao.ObtenerDatosSP("dropeadores.DireEmp_ObtenerId");
                    DataRow row = dt.Rows[0];
                    int idDomEmpresaInsertado = int.Parse(row["Id"].ToString());
                    if (dao.EjecutarSP("dropeadores.Empresa_Alta", empresa.Empresa_Cuit, empresa.Empresa_mail, empresa.Empresa_telefono, empresa.Empresa_razon_social,idDomEmpresaInsertado) > 0)
                    {

                        dt = dao.ObtenerDatosSP("dropeadores.Emp_ObtenerId", idDomEmpresaInsertado);

                    }
                    DataRow row2 = dt.Rows[0];
                    string idEmpresaInsertada = row2["cuit"].ToString();

                    dao.EjecutarSP("dropeadores.Usuario_Alta_Empresa", idEmpresaInsertada, empresa.Empresa_Cuit, empresa.Empresa_Cuit, usuario.creadoPor);
                }
                
                
                
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}


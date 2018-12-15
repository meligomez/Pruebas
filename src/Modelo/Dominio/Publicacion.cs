using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
	public class Publicacion
	{
		public int codigo { get; set; }
		public string descripcion { get; set; }
		public int stock { get; set; }
		public DateTime fechaPublicacion { get; set; }
		public DateTime fechaEspectaculo { get; set; }
		public List<DateTime> fechaEspectaculoLote { get; set; }
		//public decimal precio { get; set; }
		public string direccion { get; set; }
		public int rubroId { get; set; }
		public int gradoId { get; set; }
		public string empresaId { get; set; } //xq es el cuit.
											  //public int ubicacionId { get; set; }

		public int estado { get; set; }
		//si el estado es 0=Borrador
		//si el estado es 1=Activa o publicada 
		//si el estado es 2=Finalizada
		public Publicacion getPublicacionByCodigo(int codigo)
		{
			try
			{
				Publicacion publicacion = new Publicacion();
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ConsultarConQuery("SELECT * FROM DROPEADORES.PUBLICACION where id= " + codigo);
				DataRow row = dt.Rows[0];
				publicacion.codigo = int.Parse(row["id"].ToString());
				publicacion.descripcion = (row["descripcion"].ToString());
				publicacion.direccion = row["direccion"].ToString();
				publicacion.empresaId = row["empresaId"].ToString();
				publicacion.estado = int.Parse(row["estado"].ToString());
				publicacion.fechaEspectaculo = DateTime.Parse(row["fechaEspectaculo"].ToString());
				publicacion.fechaPublicacion = DateTime.Parse(row["fechaPublicacion"].ToString());
				publicacion.rubroId = int.Parse(row["rubroId"].ToString());
				publicacion.gradoId = int.Parse(row["gradoId"].ToString());
				publicacion.stock = int.Parse(row["stock"].ToString());
				return publicacion;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
			
			
		}

		public int altaPublicacion()
		{
			try
			{
				int id = 0;
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				dt = dao.ObtenerDatosSP("dropeadores.altaPublicacion", descripcion, stock, fechaPublicacion, fechaEspectaculo,
					 direccion, rubroId, gradoId, empresaId, estado);
				DataRow row = dt.Rows[0];
				id = int.Parse(row["Id"].ToString());
				return id;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
			
		
		}

		public int editarPublicacion()
		{
			try
			{
				int cantAfectadas = 0;
				DaoSP dao = new DaoSP();
				//DataTable dt = new DataTable();
				string query = "UPDATE DROPEADORES.PUBLICACION set gradoId= " + this.gradoId + ", rubroId= " + this.rubroId + " ,stock= " + this.stock + ",fechaEspectaculo= '" + this.fechaEspectaculo +
						"' ,fechaPublicacion = '" + this.fechaPublicacion + "' , descripcion = '" + this.descripcion +
						"' , direccion = '" + this.direccion + "' WHERE estado= "+ this.estado +" and empresaId = '" + this.empresaId + "' and id= " + this.codigo;
				cantAfectadas = dao.EjecutarConQuery(query);
				//DataRow row = dt.Rows[0];
				//id = int.Parse(row["Id"].ToString());
				return cantAfectadas;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public int actualizarEstado(int codigoPublicacion, int estado)
		{
			try
			{
				int cantAfectadas = 0;
				DaoSP dao = new DaoSP();
				//DataTable dt = new DataTable();
				string query = "update dropeadores.Publicacion set estado= " + estado +
					" WHERE id= " + codigoPublicacion;
				cantAfectadas = dao.EjecutarConQuery(query);
				//DataRow row = dt.Rows[0];
				//id = int.Parse(row["Id"].ToString());
				return cantAfectadas;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public int getIdEstadoByName(string nombre)
		{
			if(nombre=="Borrador")
			{
				return 0;
			}
			if (nombre == "Activa" || nombre == "Publicada")
			{
				return 1;
			}
			if (nombre == "Finalizada")
			{
				return 2;
			}
			return -1;
		}

		public bool existeFechayHoraSinLote()
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				string query = "SELECT fechaEspectaculo from dropeadores.Publicacion WHERE datepart(YEAR,fechaEspectaculo)= " + (this.fechaEspectaculo).Year
					+ " AND datepart(month,fechaEspectaculo) =" + this.fechaEspectaculo.Month
					+ " AND datepart(DAY,fechaEspectaculo) =" + this.fechaEspectaculo.Day
					+ " AND datepart(HOUR,fechaEspectaculo) =" + this.fechaEspectaculo.Hour;
				dt = dao.ConsultarConQuery(query);
				return dt.Rows.Count > 0;
			}
			catch (Exception ex )
			{

				throw ex;
			}
			
		}

		public bool hayAlgunEspectaculoEnEstaFecha(DateTime fechaImportada)
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable dt = new DataTable();
				string query = "SELECT * FROM DROPEADORES.Publicacion where YEAR(fechaEspectaculo) = YEAR('"+fechaImportada +"')"
					+" AND MONTH(fechaEspectaculo) = MONTH('"+fechaImportada+"') AND DAY(fechaEspectaculo)= DAY('"+fechaImportada+"')" 
					+" AND DATEPART(HOUR,fechaEspectaculo) = DATEPART(HOUR,'"+fechaImportada+"')";
				dt = dao.ConsultarConQuery(query);
				return dt.Rows.Count > 0;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}

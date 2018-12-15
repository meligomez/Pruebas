using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Modelo.Base
{
	public class BDComun
	{
		private static string connectionString = @"Data source=localhost\SQLSERVER2012;initial catalog=GD2C2018;User id=gdEspectaculos2018; Password=gd2018";
		private string getConnectionString()
		{
			return connectionString;
		}
		//Crea el comando para realizar el Alta, Baja, Modificacion y Eliminacion de los objetos 
		protected SqlCommand CrearComandoSQL(string NomStoredProcedure)
		{
			try
			{
				SqlConnection _conexion = new SqlConnection(this.getConnectionString());
				SqlCommand _comando = new SqlCommand(NomStoredProcedure, _conexion);
				_comando.CommandType = CommandType.StoredProcedure;
				return _comando;
			}

			catch (SqlException ex)
			{
				throw ex;
			}

		}
		//Crea el comando que servira para un comando sql estandard como un select 
		protected SqlCommand CrearComando()
		{
			try
			{
				SqlConnection _conexion = new SqlConnection(this.getConnectionString());
				SqlCommand _comando = new SqlCommand();
				_comando = _conexion.CreateCommand();
				_comando.CommandType = CommandType.Text;
				return _comando;
			}
			catch (SqlException exc)
			{
				throw (exc);
			}
		}
		//Verifica un tipo de dato para retornar un apostrofe a concatenar en una query 
		protected string VerificaTipoDato(string tipo)
		{
			string spa = "";
			switch (tipo)
			{
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					"System.Int32":
					spa = "";
					break;
				case
					"System.Nullable`1[System.Int32]":
					spa = "";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					"System.String":
					spa = "'";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					"System.Char":
					spa = "'";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					 "System.Boolean":
					spa = "'";
					break;
				case
					"System.Nullable`1[System.Boolean]":
					spa = "";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					"System.Date":
					spa = "'";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					"System.DateTime":
					spa = "'";
					break;
				case
					"System.Nullable`1[System.DateTime]":
					spa = "'";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					"System.Decimal":
					spa = "";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
					"System.Double":
					spa = "";
					break;
				case  // ERROR: Case labels with binary operators are unsupported : Equality
				"System.Float":
					spa = "";
					break;
			}
			return spa;
		}
		private object[] ObtenerPropiedadesObjeto(object Objeto)
		{
			try
			{
				int cant = Objeto.GetType().GetProperties().Length;
				object[] list = new object[cant];
				int i = 0;
				foreach (PropertyInfo propiedad in Objeto.GetType().GetProperties())
				{
					list[i] = propiedad.GetValue(Objeto, null);
					//list[i] = propiedad.GetValue(Registro,null);
					i = i + 1;
				}
				return list;
			}
			catch (ApplicationException exc)
			{
				throw (exc);
			}

		}
		protected int EjecutarQuery(string query)
		{
			int resp = 0;
			SqlCommand comando = CrearComando();
			try
			{
				comando.CommandText = query;
				comando.CommandType = CommandType.Text;
				comando.Connection.Open();
				//Ejecucion
				resp = comando.ExecuteNonQuery();
				return resp;
			}
			catch (SqlException ex)
			{
				throw new Exception("Error al ejecutar Query..." + ex.Message.ToString());
				//throw ex;
			}
			finally
			{
				comando.Connection.Dispose();
				comando.Connection.Close();
			}
		}
		protected SqlDataReader ConsultarQuery(string query)
		{
			SqlCommand comando = CrearComando();
			SqlDataReader reader;
			try
			{
				comando.CommandText = query;
				comando.CommandType = CommandType.Text;
				comando.Connection.Open();
				//Ejecucion
				reader = comando.ExecuteReader();
				return reader;
			}
			catch (SqlException ex)
			{
				throw new Exception("Error al ejecutar Query..." + ex.Message.ToString());

			}
		}
	}
}

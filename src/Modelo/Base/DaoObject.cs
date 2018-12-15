using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace Modelo.Base
{
	public class DaoObject : BDComun
	{
		#region Operaciones en comun
		private string RightQUERY(string param, int length)
		{
			//start at the index based on the lenght of the sting minus
			//the specified lenght and assign it a variable
			string result = param.Substring(param.Length - length, length - 1) + ")";
			//return the result of the operation
			return result;
		}
		private string RightUpdate(string param, int length)
		{
			string result = param.Substring(param.Length - length, length - 1);
			return result;
		}
		#endregion
		#region Operaciones basicas con la BD
		//Alta retorna la cantidad de registros impactados o cero
		public int Guardar(Object obj)
		{
			string model = "";
			string id = "";
			model = obj.GetType().Name;
			string sql = "";
			string spa = "";
			string p = "(";
			string v = "(";
			int resp = 0;
			try
			{
				foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
				{
					id = model + "Id";
					if (propiedad.Name != "Id" && propiedad.Name != id)
					{
						spa = VerificaTipoDato(propiedad.PropertyType.ToString());
						p = p + propiedad.Name + ",";
						v = v + spa + propiedad.GetValue(obj, null) + spa + ",";
					}
				}
				p = RightQUERY(p, p.Length);
				v = RightQUERY(v, v.Length);
				sql = "insert into " + model + p + " Values " + v;
				/*---------Ejecucion del query-------*/
				resp = this.EjecutarQuery(sql);
			}
			catch (SqlException ex)
			{
				throw new Exception("Error al intentar ejecutarQuery..." + ex.Errors.ToString());
				//throw (ex);
			}
			return resp;
		}
		//--------------------------------------------------------------------------------------//
		//Modificar retorna la cantidad de registros impactados o cero
		public int Modificar(object obj)
		{
			string model = "";
			string id = "";
			string idEncontrado = "";
			model = obj.GetType().Name;
			string sql = "";
			sql = "update " + model + " Set ";
			string spa = "";
			//string p = "";
			string v = "";
			int _ID = 0;
			int resp = 0;
			try
			{
				foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
				{
					id = model + "Id";
					if (propiedad.Name != "Id" && propiedad.Name != id)
					{
						spa = VerificaTipoDato(propiedad.PropertyType.ToString());
						v = spa + propiedad.GetValue(obj, null) + spa;
						sql = sql + propiedad.Name + " = " + v + ",";
					}
					if (propiedad.Name == "Id" || propiedad.Name == id)
					{
						id = propiedad.Name;
						idEncontrado = propiedad.GetValue(obj, null).ToString();
						_ID = int.Parse(idEncontrado);
					}
				}
				sql = RightUpdate(sql, sql.Length);
				sql = sql + " where " + id + " = " + _ID;
				///*---------Ejecucion del query-------*/
				resp = this.EjecutarQuery(sql);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error al generar Cmd. " + ex.Message);
			}
			return resp;
		}
		////-------------------------------------------------------------------------------------//
		//Modificar retorna la cantidad de registros impactados o cero
		public int EliminadoFisico(int id, object obj)
		{
			string model = "";
			string modelId = "";
			model = obj.GetType().Name;
			int resp = 0;
			string sql = "";
			try
			{
				foreach (PropertyInfo propiedad in obj.GetType().GetProperties())
				{
					modelId = model + "Id";
					if (propiedad.Name == "ID" || propiedad.Name != modelId)
					{
						sql = "Delete " + model + " where " + modelId + "=" + id;
					}
				}
				resp = this.EjecutarQuery(sql);

			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error al generar Cmd. " + ex.Message);
			}
			return resp;
		}
		public T ObtenerUnObjeto<T>(int id)
		{
			string sql = "";
			string p = "";
			string modelId = "";
			// Se obtienen las propiedades del objeto que llena la lista                 
			PropertyInfo[] propiedades = typeof(T).GetProperties();
			Type t = typeof(T);
			foreach (PropertyInfo propiedad in propiedades)
			{
				modelId = t.Name + "Id";
				if (propiedad.Name == "Id" || propiedad.Name == modelId)
				{
					modelId = propiedad.Name;
				}
				p = p + propiedad.Name + ",";

			}
			p = RightUpdate(p, p.Length);
			sql = "select " + p + " from " + t.Name + " where " + modelId + " = " + id;
			try
			{
				SqlDataReader lector = ConsultarQuery(sql);
				// Compruebo si el lector no es nulo.         
				if (lector != null)
				{       // Si el lector tiene registros.             
					if (lector.HasRows)
					{
						// Se mapean las propiedades con los campos obtenidos.                 
						// Para que el mapeo sea correcto, los campos obtenidos tienen                 
						// que coincidir en el nombre de la propiedad. 

						Dictionary<string, int> ubicacion = new Dictionary<string, int>();
						foreach (PropertyInfo propiedad in propiedades)
						{
							for (int indice = 0; indice < lector.FieldCount; indice++)
								if ((propiedad.Name == lector.GetName(indice)) && (propiedad.CanWrite))
									ubicacion.Add(propiedad.Name, indice);
						}
						// Se crea la lista que será la respuesta del método.                 
						T instancia = (T)Activator.CreateInstance<T>();
						// Se recorren los registros del lector.                 
						while (lector.Read())
						{    // Para cada registro se instancia un nuevo objeto del                     
							 // tipo que llenará la lista.                     

							foreach (PropertyInfo propiedad in propiedades)
							{
								// Usando el mapeo que se hizo anteriormente, se ubica la columna                         
								// a la que se le asignará el valor desde el lector.                         
								int columna = -1;
								if (ubicacion.TryGetValue(propiedad.Name, out columna))
								{
									try
									{   // Si se ubicó la columna y esta tiene un valor,                    
										// se asigna dicho valor a la propiedad, en la                      
										// instancia que se está llenando                              
										if (!lector.IsDBNull(columna))
											propiedad.SetValue(instancia, lector.GetValue(columna), null);
									}
									// El cachado de error se incluye, para los casos en los que  
									// el valor obtenido no sea compatible con el tipo de dato de la                  
									// propiedad.    
									catch (SqlException exc)
									{ throw (exc); }

								}
							}
						}
						// Se cierra el lector y se envía la respuesta.
						lector.Close();
						// Se incluye la instancia dentro de la respuesta a enviar.
						return instancia;
					}
					else
					{   // En caso de que el lector no tenga registros,         
						// se cierra el lector y se regresa una lista vacía.               
						lector.Close();
						return default(T); //null;
					}
				}
				else
				{  // En caso de que el lector no se haya construido,            
				   // se regresa un valor nulo.           
					return default(T);
				}
			}
			catch (Exception exc)
			{         /* Manejo de error */
					  //return default(T);
				throw (exc);
			}
		}
		//Retorna una lista de objetos, tambien soporta la herencia. 
		public List<T> ObtenerListadoDeObjetos<T>()
		{
			string sql = "";
			string p = "";
			// Se obtienen las propiedades del objeto que llena la lista                 
			PropertyInfo[] propiedades = typeof(T).GetProperties();
			Type t = typeof(T);
			foreach (PropertyInfo propiedad in propiedades)
			{ p = p + propiedad.Name + ","; }
			p = RightUpdate(p, p.Length);
			sql = "select " + p + " from " + t.Name + " where eliminado = 0";
			try
			{
				SqlDataReader lector = ConsultarQuery(sql);
				// Si el lector no es nulo.         
				if (lector != null)
				{       // Si el lector tiene registros.             
					if (lector.HasRows)
					{   // Se obtienen las propiedades del objeto que llena la lista                 
						propiedades = typeof(T).GetProperties();
						// Se mapean las propiedades con los campos obtenidos.                 
						// Para que el mapeo sea correcto, los campos obtenidos tienen                 
						// que coincidir en el nombre de la propiedad. 

						Dictionary<string, int> ubicacion = new Dictionary<string, int>();
						foreach (PropertyInfo propiedad in propiedades)
						{
							for (int indice = 0; indice < lector.FieldCount; indice++)
								if ((propiedad.Name == lector.GetName(indice)) && (propiedad.CanWrite))
									ubicacion.Add(propiedad.Name, indice);
						}
						// Se crea la lista que será la respuesta del método.                 
						List<T> respuesta = new List<T>();
						// Se recorren los registros del lector.                 
						while (lector.Read())
						{     // Para cada registro se instancia un nuevo objeto del                     
							  // tipo que llenará la lista.                     
							T instancia = (T)Activator.CreateInstance<T>();
							foreach (PropertyInfo propiedad in propiedades)
							{   // Usando el mapeo que se hizo anteriormente, se ubica la columna                         
								// a la que se le asignará el valor desde el lector.                         
								int columna = -1;
								if (ubicacion.TryGetValue(propiedad.Name, out columna))
								{
									try
									{   // Si se ubicó la columna y esta tiene un valor,                    
										// se asigna dicho valor a la propiedad, en la                      
										// instancia que se está llenando                              
										if (!lector.IsDBNull(columna))
											propiedad.SetValue(instancia, lector.GetValue(columna), null);
									}
									// El cachado de error se incluye, para los casos en los que  
									// el valor obtenido no sea compatible con el tipo de dato de la                  
									// propiedad.    
									catch { }

								}
							}
							// Se incluye la instancia dentro de la respuesta a enviar.           
							respuesta.Add(instancia);
						}                 // Se cierra el lector y se envía la respuesta.            
						lector.Close();
						return respuesta;
					}
					else
					{   // En caso de que el lector no tenga registros,         
						// se cierra el lector y se regresa una lista vacía.               
						lector.Close();
						return new List<T>();
					}
				}
				else
				{  // En caso de que el lector no se haya construido,            
				   // se regresa un valor nulo.           
					return null;
				}
			}
			catch (Exception exc)
			{         /* Manejo de error */
					  //return null;
				throw exc;     //exc.ToString();
			}
		}

		#endregion
	}
}

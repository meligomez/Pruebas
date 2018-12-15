using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Modelo.Base
{
	public class DaoSP : BDComun
	{
		#region Operaciones en comun
		//Retorna un SqlDataReader con el nombre de la consulta y parametros en el caso de existir   
		private SqlDataReader ConsultarREADER(string StoredProcedure, params object[] Parametros)
		{
			SqlDataReader resp;
			SqlCommand _comando = CrearComandoSQL(StoredProcedure);
			try
			{
				//Abro la conexion con el SGBD
				_comando.Connection.Open();
				//Traigo los parametros de la base
				SqlCommandBuilder.DeriveParameters(_comando);
				//Pasar los parametros al array
				if (_comando.Parameters.Count != Parametros.Length + 1)
				{
					throw new ApplicationException("Cantidad de parametros pasados invalidos.");
				}
				int i = 0;
				for (i = 0; i <= Parametros.Length - 1; i++)
				{
					_comando.Parameters[i + 1].Value = Parametros[i];
				}
				//Ejecucion
				resp = _comando.ExecuteReader(); ;
				return resp;
			}
			catch (SqlException ex)
			{
				throw new Exception("Error al intentar ejecutar la consulta..." + ex.Message.ToString());
				//throw (ex);
			}

		}
        private SqlDataReader ConsultarReaderQuery(string query, params object[] Parametros)
        {
            SqlDataReader resp;
            SqlCommand _comando = CrearComandoSQL(query);
            try
            {
                //Abro la conexion con el SGBD
                _comando.Connection.Open();
                //Traigo los parametros de la base
                SqlCommandBuilder.DeriveParameters(_comando);
                //Pasar los parametros al array
                if (_comando.Parameters.Count != Parametros.Length + 1)
                {
                    throw new ApplicationException("Cantidad de parametros pasados invalidos.");
                }
                int i = 0;
                for (i = 0; i <= Parametros.Length - 1; i++)
                {
                    _comando.Parameters[i + 1].Value = Parametros[i];
                }
                //Ejecucion
                resp = _comando.ExecuteReader(); ;
                return resp;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar ejecutar la consulta..." + ex.Message.ToString());
                //throw (ex);
            }

        }
        private int EjecutarSp(SqlCommand comando, params object[] Parametros)
		{
			int cant = 0;
			try
			{
				comando.Connection.Open();
				//Traigo los parametros de la base
				SqlCommandBuilder.DeriveParameters(comando);

				//Pasar los parametros al array
				if (comando.Parameters.Count != Parametros.Length + 1)
				{
					throw new Exception("Cantidad de parametros pasados invalidos.");
				}
				int i = 0;
				for (i = 0; i <= Parametros.Length - 1; i++)
				{
					comando.Parameters[i + 1].Value = Parametros[i];
				}

				//Ejecucion
				cant = comando.ExecuteNonQuery();
				return cant;
			}
			catch (SqlException ex)
			{
				// throw new Exception("Error al ejecutar SP..." + ex.Message.ToString());
				throw (ex);
			}
			finally
			{
				comando.Connection.Dispose();
				comando.Connection.Close();
			}
		}
		#endregion
		#region Operaciones basicas con la BD
		public int EjecutarSP(string NombreStoredProcedure, params object[] Parametros)
		{
			int cant = 0;

			SqlCommand _comando = CrearComandoSQL(NombreStoredProcedure);
			try
			{
				_comando.Connection.Open();
				//Traigo los parametros de la base
				SqlCommandBuilder.DeriveParameters(_comando);
				//Pasar los parametros al array
				if (_comando.Parameters.Count != Parametros.Length + 1)
				{
					throw new ApplicationException("Cantidad de parametros pasados invalidos.");
				}
				int i = 0;
				for (i = 0; i <= Parametros.Length - 1; i++)
				{
					_comando.Parameters[i + 1].Value = Parametros[i];
				}
				//Ejecucion
				cant = _comando.ExecuteNonQuery();
				//comando.ExecuteNonQuery()
				return cant;
			}
			catch (SqlException ex)
			{
				//throw new Exception("Error al ejecutar SP..." + ex.Message.ToString());
				throw (ex);
			}
			finally
			{
				_comando.Connection.Dispose();
				_comando.Connection.Close();
			}
		}
		//Retorna un objeto, y soporta la herencia.
		public T ObtenerUnObjetoSP<T>(string NomStoredProcedure, params object[] Parametros)
		{
			try
			{
				SqlDataReader lector = ConsultarREADER(NomStoredProcedure, Parametros);
				// Compruebo si el lector no es nulo.         
				if (lector != null)
				{       // Si el lector tiene registros.             
					if (lector.HasRows)
					{   // Se obtienen las propiedades del objeto que llena la lista                 
						PropertyInfo[] propiedades = typeof(T).GetProperties();
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
			{  /* Manejo de error */
				throw exc;
			}
		}
		//Retorna una lista de objetos, tambien soporta la herencia. 
		public List<T> ObtenerListadoSP<T>(string NomStoredProcedure, params object[] Parametros)
		{
			try
			{
				SqlDataReader lector = ConsultarREADER(NomStoredProcedure, Parametros);
				// Si el lector no es nulo.         
				if (lector != null)
				{       // Si el lector tiene registros.             
					if (lector.HasRows)
					{   // Se obtienen las propiedades del objeto que llena la lista                 
						//PropertyInfo[] propiedades = ObtenerPropiedades(typeof(T));
						PropertyInfo[] propiedades = typeof(T).GetProperties();
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
						}// Se cierra el lector y se envía la respuesta.            
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
			{   /* Manejo de error */
				throw exc;
			}
		}
		//Retorna una tabla de registros con un Stored Procedure y parametros si existieran.
		public DataTable ObtenerDatosSP(string NomStoredProcedure, params object[] Parametros)
		{
			try
			{
				DataTable dt = new DataTable();
				SqlDataReader lector = ConsultarREADER(NomStoredProcedure, Parametros);
				// Si el lector no es nulo.         
				if (lector != null)
				{       // Si el lector tiene registros.             
					if (lector.HasRows)
					{
						dt.Load(lector);
					}
					// Se cierra el lector y se envía la respuesta.            
					lector.Close();
					return dt;
				}
				else
				{   // En caso de que el lector no tenga registros,         
					// se cierra el lector y se regresa una lista vacía.               
					lector.Close();
					return null;
				}
			}
			catch (Exception exc)
			{   /* Manejo de error */
				throw exc;
			}
		}
        //Retorna una tabla de registros con un Stored Procedure y parametros si existieran.
        public int EjecutarConQuery(string query)
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
        public DataTable ConsultarConQuery(string query)
        {
            SqlCommand comando = CrearComando();
            try
            {
                SqlDataReader reader;
                DataTable dt = new DataTable();
                comando.CommandText = query;
                comando.CommandType = CommandType.Text;
                comando.Connection.Open();
                //Ejecucion
                reader = comando.ExecuteReader();
                // Si el lector no es nulo.         
                if (reader != null)
                {       // Si el lector tiene registros.             
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                    // Se cierra el lector y se envía la respuesta.            
                    reader.Close();
                    return dt;
                }
                else
                {   // En caso de que el lector no tenga registros,         
                    // se cierra el lector y se regresa una lista vacía.               
                    reader.Close();
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar Query..." + ex.Message.ToString());

            }
        }


		#endregion
	}
}

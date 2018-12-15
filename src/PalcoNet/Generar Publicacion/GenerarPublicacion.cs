using Modelo.Base;
using Modelo.Comun;
using Modelo.Dominio;
using PalcoNet.VentanasPorRol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
	public partial class GenerarPublicacion : Form
	{
		public Usuario userLogueado;
		public Panel panel;
		public List<DateTime> fechasValidas = new List<DateTime>();
		Publicacion publicacion = new Publicacion();
		public GenerarPublicacion(Usuario userLog,Panel panel1)
		{
			panel = panel1;
			userLogueado = userLog;
			InitializeComponent();
	
		}
		

		private void CategoriaUbicacion_Load(object sender, EventArgs e)
		{
			//Necesito en empresa un metodo que dado el id me devuelva la razon social.
			DataTable dtGrado = new DataTable();
			DataTable dtRubro = new DataTable();
			DataTable dtTipoUbicacion = new DataTable();
			DaoSP dao = new DaoSP();
			dtGrado = dao.ConsultarConQuery("SELECT id, tipo FROM dropeadores.Grado");
			dtRubro = dao.ConsultarConQuery("SELECT id,rubro_Descripcion FROM dropeadores.Rubro");
			dtTipoUbicacion = dao.ConsultarConQuery("select distinct Ubicacion_Tipo_Descripcion,Ubicacion_Tipo_Codigo as Codigo from gd_esquema.Maestra");
			CargarData.cargarComboBox(comboRubro, dtRubro, "id", "rubro_Descripcion");
			CargarData.cargarComboBox(comboGradoPublicacion, dtGrado, "id", "tipo");
			//CargarData.cargarComboBox(comboBox1, dtTipoUbicacion, "Ubicacion_Tipo_Descripcion", "Ubicacion_Tipo_Descripcion");
			lblEstado.Visible = true;
			lblUserLogueado.Visible = true;
			btnSubirTxt.Visible = false;
			//BUSCAR LA EMPRESAAAA!!
			lblUserLogueado.Text = userLogueado.empresa.Empresa_Cuit;
			lblEstado.Text = "Borrador";
			dateTimePickerEspectaculo.Format = DateTimePickerFormat.Custom;
			dateTimePickerEspectaculo.CustomFormat = "MM/dd/yyyy hh:mm:ss";

		}

		private void changeRadioButton(object sender, EventArgs e)
		{
			groupBox1.Visible = false;
			if (radioNo.Checked)
			{
				lblFechaEspectaculo.Visible = true;
				dateTimePickerEspectaculo.Visible = true;
			}
			if (radioSi.Checked)
			{
				btnSubirTxt.Visible = true;
			}
		}

		private void btnSiguiente_Click(object sender, EventArgs e)
		{
			if (this.validarData())
			{
				try
				{
				publicacion.estado = 0;
				publicacion.descripcion = textDescripcion.Text;
				publicacion.direccion = textDireccion.Text;
				publicacion.rubroId = int.Parse(comboRubro.SelectedValue.ToString());
				publicacion.gradoId = int.Parse(comboGradoPublicacion.SelectedValue.ToString());
				publicacion.stock = int.Parse(textStock.Text);
				publicacion.fechaPublicacion = dateTimePickerPublicacion.Value;
				publicacion.empresaId = userLogueado.empresa.Empresa_Cuit;
				if (radioNo.Checked)
				{
					List<DateTime> fechasNull = new List<DateTime>();
						publicacion.fechaEspectaculoLote = fechasNull;
						
							publicacion.fechaEspectaculo = dateTimePickerEspectaculo.Value;		
					//dateTimePickerEspectaculo.Value.Hour;
				}
				if (radioSi.Checked)
				{
						publicacion.fechaEspectaculoLote=fechasValidas;
					//publicacion.fechaEspectaculo = dateTimePickerEspectaculo.Value;
					//dateTimePickerEspectaculo.Value.Hour;
				}

					CategoriaUbicacion categoria = new CategoriaUbicacion(userLogueado, publicacion);
					categoria.Dock = DockStyle.Fill;
					categoria.TopLevel = false;
					categoria.FormBorderStyle = FormBorderStyle.None;
					this.panel.Controls.Add(categoria);
					this.panel.Tag = categoria;
					categoria.Show();
						this.Hide();	
				}
				catch (Exception ex)
				{

					throw ex;
				}

			}


		}

		private bool validarData()
		{
			ConfigGlobal cg = new ConfigGlobal();
			if (radioSi.Checked)
			{
				if (fechasValidas.Count <= 0)
				{
					MessageBox.Show("Valide las fechas, ya existen otros espectaculos el mismo dia en el mismo horario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}
			if ((dateTimePickerPublicacion.Value) < cg.getFechaSistema())
			{
				MessageBox.Show("La fecha de publicacion debe ser posterior a la fecha del sistema", "¡Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (radioNo.Checked)
			{
				if (publicacion.hayAlgunEspectaculoEnEstaFecha(dateTimePickerEspectaculo.Value))
				{
					MessageBox.Show("Ya existe un espectáculo en esa fecha..", "¡Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}
			}
			if (radioNo.Checked == false && radioSi.Checked == false)
			{
				MessageBox.Show("Debe seleccionar al menos una opción para la fecha del Espectáculo.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (textDescripcion.Text == "")
			{
				MessageBox.Show("debe escribir una descripcion", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (textDireccion.Text == "")
			{
				MessageBox.Show("debe escribir una direccion", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (comboGradoPublicacion.SelectedIndex==0)
			{
				MessageBox.Show("Debe seleccionar un Grado de publicacion", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (comboRubro.SelectedIndex==0)
			{
				MessageBox.Show("Debe seleccionar un Rubro.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (textStock.Text == "")
			{
				MessageBox.Show("Ingrese algún stock.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (textStock.Text == "")
			{
				MessageBox.Show("Ingrese algún stock.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (int.Parse(textStock.Text.ToString()) > 100)
			{
				MessageBox.Show("La máxima cantidad de stock es 100", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (int.Parse(textStock.Text.ToString()) <= 0)
			{
				MessageBox.Show("La mínima cantidad de stock es 10", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (int.Parse(textStock.Text.ToString()) %10 !=0)
			{
				MessageBox.Show("El stock debe ser múltiplo de 10", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			//if (publicacion.existeFechayHoraSinLote())
			//{
			//	MessageBox.Show("Ya existe un espectaculo en esa fecha y hora, ingrese otra.", "¡Error!",
			//					MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return false;
			//}

			return true;
		}

		private void cuandoCambia(object sender, KeyPressEventArgs e)
		{
			if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
			{
				MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				e.Handled = true;
				return;
			}
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
		private void btnSubirTxt_Click(object sender, EventArgs e)
		{
			try
			{
				//creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.Filter = "Archivos de Texto (*.txt)|*.txt"; //le indicamos el tipo de filtro en este caso que busque
																   //solo los archivos excel

				dialog.Title = "Seleccione el archivo de Text";//le damos un titulo a la ventana
				dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo
											   //si al seleccionar el archivo damos Ok
				if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					List<string> FechaIncorrectas = new List<string>();
					using (StreamReader sr = new StreamReader(dialog.FileName, false))
					{
						//string[] separarFecha = horaIngresada.ToString("HH:mm:ss").Split(':');//DateTime.Now.ToString("HH:mm:ss").Split(':');
						//string hor = separarFecha[0];
						//string minutos = separarFecha[1];
						//int horas = int.Parse(hor);
						//int horas =0;
						string line;
						while ((line = sr.ReadLine()) != null)
						{
							//MessageBox.Show(line);
							DateTime fechaTxt = Convert.ToDateTime(line);
							//Valido las fechas
							ConfigGlobal conf = new ConfigGlobal();
							if (fechaTxt >= conf.getFechaSistema())
							{
								if (this.esFechaValida(fechaTxt))
								{
									fechasValidas.Add(fechaTxt);
								}
								
							}
							else { FechaIncorrectas.Add(line); }
						}
						if(fechasValidas.Count<=0)
						{
							MessageBox.Show("Valide las fechas, ya existen otros espectaculos el mismo dia en el mismo horario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}


					filtrarFechasValidas(fechasValidas);
					for (int i = 0; i <  FechaIncorrectas.Count; i++)
					{
						MessageBox.Show("Fecha incorrecta "+ FechaIncorrectas[i]);
					}
				}

				//filtrarFechasValidas(fechasValidas);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private bool esFechaValida(DateTime fechaImportada)
		{
			bool fechasDistintaHora= !fechasValidas.Contains(fechaImportada) && !(fechasValidas.Any(f => f.Hour == fechaImportada.Hour && f.Date == fechaImportada.Date));
			bool otroEspectaculoConEsaFecha = publicacion.hayAlgunEspectaculoEnEstaFecha(fechaImportada);
			return fechasDistintaHora && !otroEspectaculoConEsaFecha;
		}
			private List<DateTime> filtrarFechasValidas(List<DateTime> fechasImportadas)
		{
			List<DateTime> fechasDistintas = fechasImportadas.Distinct().ToList();
			//List<DateTime> elMismoDia = (fechasDistintas.FindAll(f => fechasDistintas.Select(x => x.Day).First() == f.Day).ToList());
			//List<DateTime> cumplenRequerimiento = new List<DateTime>();
			////List<DateTime> elMismoDia = fechasDistintas.FindAll(f => (fechasDistintas.Select(f2=>f2.Date).ToArray()).Equals(f.Date));
			////List<DateTime> mismoDiaHorasDiferentes = new List<DateTime>();
			////for (int i = 0; i < elMismoDia.Count; i++)
			////{
			////	if (elMismoDia[i].Hour != elMismoDia[i + 1].Hour)
			////	{
			////		cumplenRequerimiento.Add(elMismoDia[i]);
			////	}
			////}

			////List<DateTime> laMismaHora = elMismoDia.Where(f => (elMismoDia.Select(f2 => f2.Hour)).Equals(f.Hour)).ToList();
			//List <int> horasDeunMismoDia = elMismoDia.Select(f2 => f2.Hour).ToList().Distinct().ToList();
			//foreach (DateTime item1 in fechasImportadas)
			//{
			//	foreach (DateTime item2 in fechasImportadas)
			//	{
			//		DateTime.Compare(item1, item2);
			//	}

			//}
			
			//= fechasDistintas.Except(laMismaHora).ToList();
			return fechasDistintas;
		}
		//private void SubirExcel_Click(object sender, EventArgs e)
		//{
		//	LeerExcel();
		//    }
		//private void LeerExcel() {
		//	try
		//	{
		//		//creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
		//		OpenFileDialog dialog = new OpenFileDialog();
		//		dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
		//																		 //solo los archivos excel

		//		dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
		//		dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo
		//									   //si al seleccionar el archivo damos Ok
		//		if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		//		{
		//			LLenarGrid(dialog.FileName, "Hoja1"); //se manda a llamar al metodo
		//												  //columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//	}
		//}
		//private void LLenarGrid(string archivo, string hoja)
		//{
		//	//declaramos las variables         
		//	System.Data.OleDb.OleDbConnection conexion = null;
		//	DataSet dataSet = null;
		//	System.Data.OleDb.OleDbDataAdapter dataAdapter = null;
		//	string consultaHojaExcel = "Select * from [" + hoja + "$]";
		//	//esta cadena es para archivos excel 2007 y 2010
		//	string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";
		//	//para archivos de 97-2003 usar la siguiente cadena
		//	//string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";
		//	//Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
		//	if (string.IsNullOrEmpty(hoja))
		//	{
		//		MessageBox.Show("No hay una hoja para leer");
		//	}
		//	else
		//	{
		//		try
		//		{
		//			//Si el usuario escribio el nombre de la hoja se procedera con la busqueda
		//			conexion = new System.Data.OleDb.OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
		//			conexion.Open(); //abrimos la conexion
		//			dataAdapter = new System.Data.OleDb.OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
		//			dataSet = new DataSet(); // creamos la instancia del objeto DataSet
		//			dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
		//			procesarDatos(dataSet.Tables[0]); //le asignamos al DataGridView el contenido del dataSet
		//			conexion.Close();//cerramos la conexion
		//	    }
		//		catch (Exception ex)
		//		{
		//			//en caso de haber una excepcion que nos mande un mensaje de error
		//			MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
		//		}
		//		finally
		//		{
		//			//Funcione o no, cerramos la cadena de conexión
		//			conexion.Close();
		//		}
		//	}
		//}
		//private void procesarDatos(DataTable dt) {
		//	try
		//	{
		//		List<string> FechaIncorrectas = new List<string>();
		//		string[] separarFecha = DateTime.Now.ToString("HH:mm:ss").Split(':');
		//		string hor = separarFecha[0];
		//		//string minutos = separarFecha[1];
		//		int horas = int.Parse(hor);
		//		for (int fila = 0; fila < dt.Rows.Count - 1; fila++)
		//		{
		//				//Obtien el valor de la primera columna del excel
		//				string valor = dt.Rows[fila]["fecha"].ToString();
		//				DateTime endDate = Convert.ToDateTime(valor);
		//			//Valido las fechas
		//			if (endDate >= DateTime.Now)
		//			{
		//				//Agrego a la fecha del excel la hora inicial del campo y la voy incrementando
		//				endDate = endDate.AddHours(horas);
		//				horas = horas + 1;
		//			}
		//			else { FechaIncorrectas.Add(valor); }
		//		}
		//		for (int i = 0; i < FechaIncorrectas.Count; i++)
		//		{
		//			MessageBox.Show(FechaIncorrectas[i]);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		//en caso de haber una excepcion que nos mande un mensaje de error
		//		MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
		//	}
		//}

	}
}

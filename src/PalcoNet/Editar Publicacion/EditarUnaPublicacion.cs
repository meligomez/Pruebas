using Modelo.Base;
using Modelo.Comun;
using Modelo.Dominio;
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

namespace PalcoNet.Editar_Publicacion
{
    public partial class btnEditPublic : Form
    {
		Usuario userLogueado;
		Publicacion publicacion= new Publicacion();
		public List<DateTime> fechasValidas = new List<DateTime>();
		public btnEditPublic(Usuario user, int idpubli )
        {
			userLogueado = user;
			publicacion.codigo = idpubli;
            InitializeComponent();
        }

		private void EditarUnaPublicacion_Load(object sender, EventArgs e)
		{
			DataTable dtGrado = new DataTable();
			DataTable dtRubro = new DataTable();
			DaoSP dao = new DaoSP();
			dtGrado = dao.ConsultarConQuery("SELECT id, tipo FROM dropeadores.Grado");
			dtRubro = dao.ConsultarConQuery("SELECT id,rubro_descripcion FROM dropeadores.Rubro");
			CargarData.cargarComboBox(comboRubro, dtRubro, "id", "rubro_descripcion");
			CargarData.cargarComboBox(comboGradoPublicacion, dtGrado, "id", "tipo");
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

			publicacion= publicacion.getPublicacionByCodigo(publicacion.codigo);
			textDescripcion.Text = publicacion.descripcion;
			textDireccion.Text = publicacion.direccion;
			textStock.Text = publicacion.stock.ToString();
			estadoPublicacion.Text = "Borrador";
			dateTimePickerPublicacion.Value= publicacion.fechaPublicacion;
			comboGradoPublicacion.SelectedIndex = publicacion.gradoId;
			comboRubro.SelectedIndex = publicacion.rubroId;
			lblCodigo.Text = publicacion.codigo.ToString() ;
			lblEmpresa.Text = publicacion.empresaId;

		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show(" ", "¡Correcto!",
				MessageBoxButtons.OK, MessageBoxIcon.None);
			a.Visible = true;
			b.Visible = true;
			c.Visible = true;
			d.Visible = true;
			ee.Visible = true;
			f.Visible = true;
			g.Visible = true;
			h.Visible = true;
			i.Visible = true;
			j.Visible = true;
		//	groupBox1.Visible = true;
			lblEmpresa.Visible = true;
			lblCodigo.Visible = true;
			//lblTextLote.Visible = true;
			comboGradoPublicacion.Visible = true;
			comboRubro.Visible = true;
			textStock.Visible = true;
			dateTimePicker1.Visible = true;
			dateTimePickerPublicacion.Visible = true;
			btnEditUbicacion.Visible = false;
			textDescripcion.Visible = true;
			textDireccion.Visible = true;
			estadoPublicacion.Visible = true;
			button2.Visible = false;

		}

		private void btnEditUbicacion_Click(object sender, EventArgs e)
		{
			a.Visible = false;
			b.Visible = false;
			c.Visible = false;
			d.Visible = false;
			ee.Visible = false;
			f.Visible = false;
			g.Visible = false;
			h.Visible = false;
			i.Visible = false;
			j.Visible = false;
			//groupBox1.Visible = false;
			lblEmpresa.Visible = false;
			lblCodigo.Visible = false;
			//lblTextLote.Visible = false;
			comboGradoPublicacion.Visible = false;
			comboRubro.Visible = false;
			textStock.Visible = false;
			dateTimePicker1.Visible = false;
			dateTimePickerPublicacion.Visible = false;
			btnEditUbicacion.Visible = false;
			textDescripcion.Visible = false;
			textDireccion.Visible = false;
			estadoPublicacion.Visible = false;
			button2.Visible = false;
			MessageBox.Show("Si ud quiere modificar las ubicaciones deberá generar una nueva publicacion. sólo podrá modificar el precio por categoria.");
			DaoSP dao = new DaoSP();
			DataTable dtCategoria = new DataTable();
				comboCategoria.Visible = true;
			dtCategoria = dao.ConsultarConQuery("SELECT codigo,descripcion FROM dropeadores.TipoUbicacion");
			CargarData.cargarComboBox(comboCategoria, dtCategoria,"codigo","descripcion");
			lblTextoCategoria.Visible = true;
			lblCategoria.Visible = true;
			lblPrecio.Visible = true;
			textPrecio.Visible = true;
			btnPrecioPorCategoria.Visible = true;

		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if(validarData())
			{
				Publicacion p = new Publicacion();
				p.codigo = int.Parse(lblCodigo.Text);
				p.empresaId = lblEmpresa.Text;
				p.gradoId = int.Parse(comboGradoPublicacion.SelectedValue.ToString());
				p.rubroId = int.Parse(comboRubro.SelectedValue.ToString());
				p.stock = int.Parse(textStock.Text);
				p.fechaEspectaculo = dateTimePicker1.Value;
				p.fechaPublicacion = dateTimePickerPublicacion.Value;
				p.descripcion = textDescripcion.Text;
				p.direccion = textDireccion.Text;
				p.estado = p.getIdEstadoByName(estadoPublicacion.Text);
				
				//if (radioNo.Checked)
				//{
				//	List<DateTime> fechasNull = new List<DateTime>();
				//	publicacion.fechaEspectaculoLote = fechasNull;

				//	publicacion.fechaEspectaculo = dateTimePicker1.Value;
				//	//dateTimePickerEspectaculo.Value.Hour;
				//}
				//if (radioSi.Checked)
				//{
				//	publicacion.fechaEspectaculoLote = fechasValidas;
				//	//publicacion.fechaEspectaculo = dateTimePickerEspectaculo.Value;
				//	//dateTimePickerEspectaculo.Value.Hour;
				//}
				//NO ES POR LOTE!!!!!
				//if (publicacion.fechaEspectaculoLote.Count == 0)
				//{
					if (p.editarPublicacion() > 0)
					{
						MessageBox.Show("Cambios guardados correctamente.", "¡Correcto!",
						MessageBoxButtons.OK, MessageBoxIcon.None);
					}
					else
					{
						MessageBox.Show("Error al modificar la publicacion", "¡Error!",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				//}
				//else
				//{
				//	//es por lote. tengo q hacer un INSERT DE PUBLICACION POR CADA fecha distinta. onda lo unico q cambia es la fecha.
				//	foreach (DateTime unaFechaEspectaculo in publicacion.fechaEspectaculoLote)
				//	{
				//		publicacion.fechaEspectaculo = unaFechaEspectaculo;
				//		if (publicacion.existeFechayHoraSinLote())
				//		{
				//			if (p.editarPublicacion() > 0)
				//			{
				//				MessageBox.Show("Cambios guardados correctamente.", "¡Correcto!",
				//				MessageBoxButtons.OK, MessageBoxIcon.None);
				//			}
				//			else
				//			{
				//				MessageBox.Show("Error al modificar la publicacion", "¡Error!",
				//				MessageBoxButtons.OK, MessageBoxIcon.Error);
				//			}
				//		}
				//		else
				//		{
				//			MessageBox.Show("Error, hay fechas en las cuales ya existe otro espectáculo.", "¡Error!",
				//							MessageBoxButtons.OK, MessageBoxIcon.Error);
				//		}
				//	}
				//}
			}
			

		}

		private void changeRadioButton(object sender, EventArgs e)
		{
			//groupBox1.Visible = false;
			//if (radioNo.Checked)
			//{
			//	label7.Visible = true;
			//	dateTimePicker1.Visible = true;
			//}
			//if (radioSi.Checked)
			//{
			//	btnSubirTxt.Visible = true;
			//}
		}
		public bool validarData()
		{
			ConfigGlobal cg = new ConfigGlobal();
			//if (radioSi.Checked)
			//{
			//	if (fechasValidas.Count <= 0)
			//	{
			//		MessageBox.Show("Valide las fechas, ya existen otros espectaculos el mismo dia en el mismo horario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//		return false;
			//	}
			//}
			if ((dateTimePickerPublicacion.Value)<cg.getFechaSistema())
			{
				MessageBox.Show("La fecha de publicacion debe ser posterior a la fecha del sistema", "¡Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			//if (radioNo.Checked)
			//{
			//	if (publicacion.hayAlgunEspectaculoEnEstaFecha(dateTimePicker1.Value))
			//	{
			//		MessageBox.Show("Ya existe un espectáculo en esa fecha..", "¡Error!",
			//		MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//		return false;
			//	}
			//}
			//if (radioNo.Checked == false && radioSi.Checked == false)
			//{
			//	MessageBox.Show("Debe seleccionar al menos una opción para la fecha del Espectáculo.", "¡Advertencia!",
			//	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//	return false;
			//}
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
			if (comboGradoPublicacion.SelectedIndex == 0)
			{
				MessageBox.Show("Debe seleccionar un Grado de publicacion", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (comboRubro.SelectedIndex == 0)
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
			if (int.Parse(textStock.Text.ToString()) % 10 != 0)
			{
				MessageBox.Show("El stock debe ser múltiplo de 10", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (publicacion.hayAlgunEspectaculoEnEstaFecha(dateTimePicker1.Value))
			{
				MessageBox.Show("Ya existe un espectaculo en esa fecha y hora, ingrese otra.", "¡Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
		private void textDireccion_TextChanged(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label7_Click(object sender, EventArgs e)
		{

		}

		private void btnPrecioPorCategoria_Click(object sender, EventArgs e)
		{
			try
			{
				TipoUbicacion tu = new TipoUbicacion();
				Ubicacion u = new Ubicacion();
				u.updatePreciosDeCategoria(publicacion.codigo, int.Parse(comboCategoria.SelectedValue.ToString()), decimal.Parse(textPrecio.Text.ToString()));
				MessageBox.Show("Correcto! Se ha modificado el precio de la categoria.");
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void comboRubro_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if(comboCategoria.SelectedIndex!=0)
				{
					DaoSP dao = new DaoSP();
					TipoUbicacion tu2 = new TipoUbicacion();
					DataTable dtPrecioCategoria = new DataTable();
					dtPrecioCategoria = dao.ObtenerDatosSP("dropeadores.getPrecioDeUbicacionPorCategoria", publicacion.codigo, comboCategoria.SelectedValue);
					if(dtPrecioCategoria.Rows.Count<=0)
					{
						MessageBox.Show("No hay ubicaciones con precios pertenecientes a esa categoria.", "¡Error!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						DataRow row2 = dtPrecioCategoria.Rows[0];
						decimal precio = decimal.Parse(row2["precio"].ToString());
						textPrecio.Text = precio.ToString();
					}
					
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
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
						
					}


					filtrarFechasValidas(fechasValidas);
					for (int i = 0; i < FechaIncorrectas.Count; i++)
					{
						MessageBox.Show("Fecha incorrecta " + FechaIncorrectas[i]);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private List<DateTime> filtrarFechasValidas(List<DateTime> fechasImportadas)
		{
			List<DateTime> fechasDistintas = fechasImportadas.Distinct().ToList();
			return fechasDistintas;
		}
		private bool esFechaValida(DateTime fechaImportada)
		{
			bool fechasDistintaHora = !fechasValidas.Contains(fechaImportada) && !(fechasValidas.Any(f => f.Hour == fechaImportada.Hour && f.Date == fechaImportada.Date));
			bool otroEspectaculoConEsaFecha = publicacion.hayAlgunEspectaculoEnEstaFecha(fechaImportada);
			return fechasDistintaHora && !otroEspectaculoConEsaFecha;
		}
	}
}

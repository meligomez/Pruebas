using Modelo.Base;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
	public partial class ModificarClienteSeleccionado : Form
	{
		Cliente cliente_seleccionado;
		public ModificarClienteSeleccionado(string tipoDoc, int nroDoc)
		{
			InitializeComponent();
			DaoSP dao = new DaoSP();
			cliente_seleccionado = obtener(tipoDoc, nroDoc);
			if (cliente_seleccionado == null)
			{
				MessageBox.Show("Error al cargar el cliente.", "Error al Modificar Cliente",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Dispose();
			}

			foreach (string tipo in Documento.string_docu)
				comboTipoDoc.Items.Add(tipo);

		}
		public static DataTable obtenerTabla(string tipoDoc, int nroDoc)
		{

			DaoSP dao = new DaoSP();
			return dao.ObtenerDatosSP("dropeadores.ObtenerClienteEspecifico", tipoDoc, nroDoc);
		}
		public static List<Cliente> transductor(DataTable tabla)
		{
			List<Cliente> lista = new List<Cliente>();
			foreach (DataRow fila in tabla.Rows)
			{
				Domicilio dom = new Domicilio();
				Cliente cli = new Cliente();
				Tarjeta tar = new Tarjeta();
				cli.apellido = Convert.ToString(fila["apellido"]);
				cli.nombre = Convert.ToString(fila["nombre"]);
				cli.numeroDocumento = Convert.ToInt32(fila["numeroDocumento"]);

				cli.fechaNacimiento = Convert.ToDateTime(fila["fechaNacimiento"]);
				cli.cuil = Convert.ToString(fila["cuil"]);

				dom.calle = Convert.ToString(fila["calle"]);
				dom.piso = Convert.ToInt32(fila["piso"]);
				dom.dpto = Convert.ToString(fila["departamento"]);
				dom.localidad = Convert.ToString(fila["localidad"]);
				dom.cp = Convert.ToInt32(fila["codigoPostal"]);
				dom.numero = Convert.ToInt32(fila["numero"]);
				cli.Cli_Dir = dom;
				tar.propietario = Convert.ToString(fila["propietario"]);
				tar.numero = Convert.ToString(fila["numero"]);
				tar.fechaVencimiento = Convert.ToDateTime(fila["fechaVencimiento"]);
				cli.Cli_Tar = tar;


				//Campos Nulleables  (CHECKEAR)
				if (!(fila["telefono"] is DBNull))
					cli.telefono = Convert.ToInt32(fila["telefono"]);
				if (!(fila["mail"] is DBNull))
					cli.mail = Convert.ToString(fila["mail"]);
				//if (!(fila["empresa_razon_social"] is DBNull))
				//if (!(fila["direccionDepto"] is DBNull))
				// empresa.Direccion.calle_dpto = Convert.ToString(fila["direccionDepto"]);

				lista.Add(cli);
			}
			return lista;
		}
		private void cargarDatos()
		{
			//empresa_Seleccionada.Empresa_estado = true;
			txtNombre.Text = cliente_seleccionado.nombre;
			txtApellido.Text = cliente_seleccionado.apellido;
			txtNroIdentificacion.Text = cliente_seleccionado.numeroDocumento.ToString();
			textCUIL.Text = cliente_seleccionado.cuil;
			textTelefono.Text = cliente_seleccionado.telefono.ToString();
			textMail.Text = cliente_seleccionado.mail;
			dateTimePickerFechaNac.Value = cliente_seleccionado.fechaNacimiento;
			textDireccion.Text = cliente_seleccionado.Cli_Dir.calle;
			txtNro.Text = cliente_seleccionado.Cli_Dir.numero.ToString();
			textLocalidad.Text = cliente_seleccionado.Cli_Dir.localidad;
			//textPiso.Text = cliente_seleccionado.Cli_Dir.piso.ToString();
			// textDepto.Text = cliente_seleccionado.Cli_Dir.dpto.ToString();
			textCP.Text = cliente_seleccionado.Cli_Dir.cp.ToString();
			txtTarjProp.Text = cliente_seleccionado.Cli_Tar.propietario;
			txtTarjNum.Text = cliente_seleccionado.Cli_Tar.numero.ToString();
			dateTimePickerVenc.Value = cliente_seleccionado.Cli_Tar.fechaVencimiento;

			checkBaja.Checked = cliente_seleccionado.estado;
			if (cliente_seleccionado.Cli_Dir.dpto != "''")
				textDepto.Text = cliente_seleccionado.Cli_Dir.dpto.ToString();
			if (cliente_seleccionado.Cli_Dir.piso != -1)
				textPiso.Text = cliente_seleccionado.Cli_Dir.piso.ToString();
		}

		public static Cliente obtener(string tipoDoc, int nroDoc)
		{
			List<Cliente> lista = transductor(obtenerTabla(tipoDoc, nroDoc));
			if (lista.Count == 0)
				return null;
			return lista[0];
		}
		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void ModificarClienteElegido_Load(object sender, EventArgs e)
		{
			cargarDatos();
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}

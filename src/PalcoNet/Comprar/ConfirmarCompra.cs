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

namespace PalcoNet.Comprar
{
    public partial class ConfirmarCompra : Form
    {
		List<Ubicacion> ubicacionesSeleccionadas;
		Usuario usuario = new Usuario();
		Cliente cliente = new Cliente();
		ConfigGlobal fech = new ConfigGlobal();
		int IDtarjeta = 0;

		public ConfirmarCompra(List<Ubicacion> ubicacSeleccionadas, Usuario user)
        {
			DaoSP tj = new DaoSP();
			ubicacionesSeleccionadas = ubicacSeleccionadas;
			usuario = user;
			cliente.numeroDocumento = usuario.cliente.numeroDocumento;
			DataTable dt = new DataTable();
			string medioDePago = "";
			InitializeComponent();
			dt = tj.ConsultarConQuery("select t.descripcion as 'tipoTarjeta',Id as 'Id' from dropeadores.Cliente c join dropeadores.TarjetaCredito t on (t.clieteId=c.numeroDocumento) where c.numeroDocumento=" + usuario.cliente.numeroDocumento);

			foreach (DataRow row in dt.Rows)
			{
				medioDePago = Convert.ToString(row["tipoTarjeta"]);
				IDtarjeta = Convert.ToInt32(row["Id"]);
			}
			labelMedioPago.Text = medioDePago.ToString();
		}
		private int tieneTarjeta(Usuario user)
		{
			DataTable dt, dr, da = new DataTable();
			int cant = 0;
			DaoSP dao = new DaoSP();

			dt = dao.ConsultarConQuery("select count(clieteId) as 'cantidad' from dropeadores.TarjetaCredito t join dropeadores.Cliente c on(c.numeroDocumento=t.clieteId) join dropeadores.Usuario u on (u.clienteId=c.numeroDocumento) where u.clienteId='" + user.cliente.numeroDocumento + "'");
			foreach (DataRow row in dt.Rows)
			{
				cant = Convert.ToInt32(row["cantidad"]);
			}

			return cant;
		}
		private void cargarTabla()
		{

			ConfigGlobal fech = new ConfigGlobal();

			DaoSP prueba = new DaoSP();

			dataGridViewCompra.DataSource = ubicacionesSeleccionadas;
			dataGridViewCompra.Columns[2].Visible = false;
			dataGridViewCompra.Columns[6].Visible = false;
			dataGridViewCompra.Columns[4].Visible = false;

		}
		private int calcularPrecio()
		{
			double precioTotal = 0;
			foreach (DataGridViewRow row in dataGridViewCompra.Rows)
			{

				string fila = row.Cells[0].Value.ToString();
				string asiento = row.Cells[1].Value.ToString();
				string publicacionID = row.Cells[5].Value.ToString();
				Double precio = Convert.ToDouble(row.Cells[3].Value.ToString());
				precioTotal = precioTotal + precio;
			}
			lblImporte.Text = Convert.ToString(precioTotal);
			return 0;
		}
		private void calcularPuntos(int idCompra)
		{
			DaoSP dao = new DaoSP();
			int puntos = 5;

			if (dao.EjecutarSP("dropeadores.insertPuntos", puntos, idCompra, usuario.cliente.numeroDocumento, fech.getFechaSistema()) > 0)
			{
				MessageBox.Show("Los puntos fueron realizada con éxito");

			}
		}
		private void ConfirmarCompra_Load(object sender, EventArgs e)
        {
			cargarTabla();
			int x = calcularPrecio();
		}

		private void btnNuevoMedioPago_Click(object sender, EventArgs e)
		{
			if (tieneTarjeta(usuario) == 0)
			{
				this.Hide();
				new AsociarTarjeta(usuario).Show();
			}
			else
			{
				MessageBox.Show("Ya tiene asociado una tarjeta");
			}
		}

		private void buttonPAGAR_Click(object sender, EventArgs e)
		{
			queryComprar();
			insertarUbicacionXPublCompradoYActualizarCompra();
			//obtenerValorPuntajeCompra();
		}

		public void queryComprar()
		{
			DaoSP tj = new DaoSP();
			DataTable dt = new DataTable();
			Ubicacion ubic = new Ubicacion();
			string tipoDoc = "";
			int nroDoc = 0;
			dt = tj.ConsultarConQuery("select c.TipoDocumento as 'TIPO DOCUMENTO',  c.NumeroDocumento as 'NUMERO DOCUMENTO' from dropeadores.Cliente c join dropeadores.Usuario u on (u.clienteId=c.NumeroDocumento) where c.NumeroDocumento=" + usuario.cliente.numeroDocumento);
			foreach (DataRow row in dt.Rows)
			{
				tipoDoc = Convert.ToString(row["TIPO DOCUMENTO"]);
				nroDoc = Convert.ToInt32(row["NUMERO DOCUMENTO"]);

			}

			int cantidadUbicacionesCompradas = ubicacionesSeleccionadas.Count;
			DaoSP dao = new DaoSP();
			foreach (DataGridViewRow row in dataGridViewCompra.Rows)
			{
				ubic.fila = Convert.ToChar(row.Cells[0].Value.ToString());
				ubic.asiento = Convert.ToInt32(row.Cells[1].Value.ToString());
				ubic.publicacionId = Convert.ToInt32(row.Cells[5].Value.ToString());
				// dt = dao.ObtenerDatosSP("dropeadores.updateUbicacion", ubic.publicacionId, ubic.fila, ubic.asiento);
				if (dao.EjecutarSP("dropeadores.updateUbicacion", ubic.publicacionId, ubic.fila, ubic.asiento) > 0)
				{
					if (dao.EjecutarSP("dropeadores.InsertCompra", tipoDoc, nroDoc, fech.getFechaSistema(), IDtarjeta, cantidadUbicacionesCompradas, lblImporte.Text, ubic.fila, ubic.asiento, ubic.publicacionId) > 0)
					{
						dt = dao.ObtenerDatosSP("dropeadores.obtenerIDcompra");
						DataRow row2 = dt.Rows[0];
						int IDcompra = int.Parse(row2["Id"].ToString());
						calcularPuntos(IDcompra);
						dt = tj.ObtenerDatosSP("dropeadores.updatePuntos", usuario.cliente.numeroDocumento);

						MessageBox.Show("La compra fue realizada con éxito");

					}
				}
			}




		}

		private void insertarUbicacionXPublCompradoYActualizarCompra()
		{

		}

		private void dataGridViewCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
				
		}
	}
}

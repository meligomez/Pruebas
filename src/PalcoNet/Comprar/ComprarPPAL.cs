using Modelo.Base;
using Modelo.Comun;
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
    public partial class ComprarPPAL : Form
    {

		private bool CategoriaCargada;
		private bool UbicacionCargada;
		private DateTime fecDesde, fecHasta;
		List<String> listaCategorias = new List<String>();
		List<Ubicacion> ubicacionesSeleccionadas = new List<Ubicacion>();
		List<String> IDs = new List<String>();
		ConfigGlobal fech = new ConfigGlobal();
		Usuario usuario = new Usuario();
		DataTable dtSource = new DataTable();


		public ComprarPPAL(Usuario user)
        {
            InitializeComponent();
			usuario = user;
			string medioDePago = "";
			usuario.cliente.numeroDocumento = 35550990;
			DaoSP tj = new DaoSP();
			DataTable dt = new DataTable();
			dt = tj.ConsultarConQuery("select t.descripcion as 'tipoTarjeta' from dropeadores.Cliente c join dropeadores.TarjetaCredito t on (t.clieteId=c.numeroDocumento) where c.numeroDocumento=" + usuario.cliente.numeroDocumento);

			foreach (DataRow row in dt.Rows)
			{
				medioDePago = Convert.ToString(row["tipoTarjeta"]);
			}
			labelMedioPago.Text = medioDePago.ToString();
		}


        private void ComprarPPAL_Load(object sender, EventArgs e)
        {
			 cargarTabla();
			DaoSP dao = new DaoSP();
			dtSource = dao.ObtenerDatosSP("dropeadores.getTablaPublicacion", fech.getFechaSistema());
		}


        public void CompletarCategoríasSeleccionadas(List<String> CatElegidas)
        {
			labelCategorias.Text = "";
			listaCategorias = CatElegidas;
			for (int i = 0; i < CatElegidas.Count(); i++)
			{
				labelCategorias.Text += CatElegidas[i] + "  ";
			}
			CategoriaCargada = true;

		}
		private void cargarTabla()
		{

			DaoSP prueba = new DaoSP();

			CargarData.cargarGridView(dataGridViewCompras, prueba.ObtenerDatosSP("dropeadores.getTablaPublicacion", fech.getFechaSistema()));

			CargarData.AddButtonSeleccionar(dataGridViewCompras);
		}

		private DataTable FiltrarPublicacion(string CatElegidas, string descripcion, DateTime fechaDesde, DateTime fechaHasta, List<String> listaCat)
		{
			try
			{
				DaoSP dao = new DaoSP();
				DataTable tabla_Publicacion = new DataTable();
				tabla_Publicacion = dao.ObtenerDatosSP("dropeadores.getPublicacion", fech.getFechaSistema(), fechaDesde, fechaHasta);
				if (tabla_Publicacion == null)
				{
					cargarTabla();
				}

				var final_rol = "";
				var posFiltro = true;
				var filtrosBusqueda = new List<string>();
				var filtrosCategoria = new List<string>();
				final_rol = "(";
				if (listaCat.Count > 0)
				{
					for (int i = 0; i < listaCat.Count(); i++)
					{

						filtrosCategoria.Add("RUBRO_DESCRIPCION LIKE '%" + listaCat[i] + "%'");

					}
					foreach (var filtro in filtrosCategoria)
					{
						if (!posFiltro)
							final_rol += " OR " + filtro;
						else
						{
							final_rol += filtro;
							posFiltro = false;
						}
					}
				}
				if (descripcion != "")
				{
					final_rol += ")AND DESCRIPCION LIKE '%" + descripcion + "%'";
				}
				else
				{
					final_rol += ")";
				}

				if (tabla_Publicacion != null)
				{

					tabla_Publicacion.DefaultView.RowFilter = final_rol;
				}
				else
				{
					tabla_Publicacion = null;
					dataGridViewCompras.DataSource = null;
				}
				return tabla_Publicacion;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		private int tieneTarjeta(Usuario user)
		{
			DataTable dt = new DataTable();
			int cant = 0;
			DaoSP dao = new DaoSP();

			dt = dao.ConsultarConQuery("select count(clieteId) from dropeadores.TarjetaCredito t join dropeadores.Cliente c on(c.numeroDocumento=t.clieteId) join dropeadores.Usuario u on (u.clienteId=c.numeroDocumento) where u.username='" + user.username + "'");
			foreach (DataRow row in dt.Rows)
			{
				cant = Convert.ToInt32(row["cantidad"]);
			}

			return cant;
		}
		private void buttonCategoria_Click(object sender, EventArgs e)
        {
            ComprarPPAL comprar = this;
            SeleccionCategorias cate = new SeleccionCategorias(labelCategorias.Text, comprar);
            cate.Show();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {


            if (dateTimePickerDesde.Value.Date > dateTimePickerHasta.Value.Date)
            {
                MessageBox.Show("La segunda fecha no puede ser inferior a la primera \nFECHA 1:" + dateTimePickerDesde.Text + "\nFECHA 2:" + dateTimePickerHasta.Text);
                return;
            }
            DateTime hoy = DateTime.Today;
            if (hoy > dateTimePickerDesde.Value.Date)
            {
                MessageBox.Show("La fecha inicial no puede ser menor que la actual");
                return;
            }


            DataTable respuesta = FiltrarPublicacion(labelCategorias.Text, textDescripcion.Text, dateTimePickerDesde.Value, dateTimePickerHasta.Value, listaCategorias);
            dataGridViewCompras.DataSource = respuesta;
            if (dataGridViewCompras.CurrentRow == null)
            {

                MessageBox.Show("La empresa requerida no se encuentra.", "Baja de Empresa",
                   MessageBoxButtons.OK);

                cargarTabla();
            }

        }



        
        private void buttonPAGAR_Click(object sender, EventArgs e)
        {
			

		}


		private void labelubicaciones_Click(object sender, EventArgs e)
        {

        }

        private void labelCategorias_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			Cliente cliente = new Cliente();
			var senderGrid = (DataGridView)sender;

			if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
				e.RowIndex >= 0)
			{
				string descripcion = dataGridViewCompras.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
				string fila = dataGridViewCompras.CurrentRow.Cells["FILA"].Value.ToString();
				string asiento = dataGridViewCompras.CurrentRow.Cells["ASIENTO"].Value.ToString();
				string precio = dataGridViewCompras.CurrentRow.Cells["PRECIO"].Value.ToString();
				DialogResult dr = MessageBox.Show("Desea seleccionar el espectaculo" + descripcion + " con la fila " + fila + " asiento " + asiento + "?",
				"", MessageBoxButtons.YesNo);
				switch (dr)
				{
					case DialogResult.Yes:
						if (dataGridViewCompras.Rows.Count != 0)
						{
							String ID = dataGridViewCompras.CurrentRow.Cells["CODIGO"].Value.ToString();
							Ubicacion ubicacion = new Ubicacion();
							ubicacion.publicacionId = Convert.ToInt32(ID);
							ubicacion.fila = Convert.ToChar(fila);
							ubicacion.asiento = Convert.ToInt32(asiento);
							ubicacion.precio = decimal.Parse(precio);
							ubicacionesSeleccionadas.Add(ubicacion);
							cliente.numeroDocumento = usuario.cliente.numeroDocumento;
							MessageBox.Show("La ubicación con ID " + ID + " fue añadida");
							int rowindex = dataGridViewCompras.CurrentCell.RowIndex;
							dataGridViewCompras.Rows.RemoveAt(rowindex);
						}
						break;

					case DialogResult.No:
						break;
				}

			}
		}
		private int PageCount;
		private int maxRec;
		private int pageSize;
		private int currentPage;
		private int recNo;
		private void btnNuevoMedioPago_Click(object sender, EventArgs e)
        {

        }

        private void buttonVOLVER_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonPAGAR_Click_1(object sender, EventArgs e)
        {
			if (dataGridViewCompras.CurrentRow == null)
			{
				MessageBox.Show("Seleccione la ubicacion del espectaculo que desea comprar.",
				"", MessageBoxButtons.OK);
				return;
			}
			DialogResult dr = MessageBox.Show("Seguro que desea realizar la compra?", "", MessageBoxButtons.YesNo);
			switch (dr)
			{
				case DialogResult.Yes:
					ConfirmarCompra(ubicacionesSeleccionadas);
					break;
				case DialogResult.No: break;
			}

		}

		private void btnBuscar_Click_1(object sender, EventArgs e)
		{
			if (dateTimePickerDesde.Value.Date >= dateTimePickerHasta.Value.Date)
			{
				MessageBox.Show("La segunda fecha no puede ser inferior o igual a la primera \nFECHA 1:" + dateTimePickerDesde.Text + "\nFECHA 2:" + dateTimePickerHasta.Text);
				return;
			}

			DateTime hoy = DateTime.Today;
			if (hoy > dateTimePickerDesde.Value.Date)
			{
				MessageBox.Show("La fecha inicial no puede ser menor que la actual");
				return;
			}

			DataTable respuesta = FiltrarPublicacion(labelCategorias.Text, textDescripcion.Text, dateTimePickerDesde.Value, dateTimePickerHasta.Value, listaCategorias);
			dataGridViewCompras.DataSource = respuesta;

			if (dataGridViewCompras.CurrentRow == null)
			{

				MessageBox.Show("La empresa requerida no se encuentra.", "Baja de Empresa",
				   MessageBoxButtons.OK);

				cargarTabla();
			}
		}

		private void buttonCategoria_Click_1(object sender, EventArgs e)
		{
			ComprarPPAL comprar = this;
			SeleccionCategorias cate = new SeleccionCategorias(labelCategorias.Text, comprar);
			cate.Show();
		}

		private void txtCantPags_TextChanged(object sender, EventArgs e)
		{
			if (txtCantPags.Text == null || txtCantPags.Text == "")
			{
				MessageBox.Show("Error! Ingrese numeros!");
			}
			else
			{
				FillGrid(int.Parse(txtCantPags.Text));
			}
		}

		private void btnFirstPage_Click(object sender, EventArgs e)
		{
			if (!CheckFillButton())
			{
				return;
			}

			if ((currentPage == 1))
			{
				MessageBox.Show("Estas en la primera pagina!");
				return;
			}
			currentPage = 1;
			recNo = 0;
			LoadPage();
		}

		private void btnPreviousPage_Click(object sender, EventArgs e)
		{
			if (!CheckFillButton())
			{
				return;
			}
			currentPage = currentPage - 1;
			// Check if you are already at the first page.
			if ((currentPage < 1))
			{
				MessageBox.Show("Estas en la primera página!");
				currentPage = 1;
				return;
			}
			else
			{
				recNo = (pageSize
							* (currentPage - 1));
			}
			LoadPage();
		}

		private void btnNextPage_Click(object sender, EventArgs e)
		{
			if (!CheckFillButton())
			{
				return;
			}
			if ((pageSize == 0))
			{
				MessageBox.Show("Establezca el tamaño de la página y luego haga clic en el botón - Rellenar cuadrícula");
				return;
			}
			currentPage = (currentPage + 1);
			if ((currentPage > PageCount))
			{
				currentPage = PageCount;
				// Check if you are already at the last page.
				if ((recNo == maxRec))
				{
					MessageBox.Show("Estas en la ultima pagina!");
					return;
				}
			}
			LoadPage();
		}
		private bool CheckFillButton()
		{
			//'Check if the user clicks the "Fill Grid" button.
			if (pageSize == 0)
			{
				MessageBox.Show("Establezca el Tamaño de " +
					"página y luego haga clic en siguiente");
				return false;
			}
			return true;

		}
		private void btnLastPage_Click(object sender, EventArgs e)
		{
			if (!CheckFillButton())
			{
				return;
			}

			if ((recNo == maxRec))
			{
				MessageBox.Show("Estas en la última página!");
				return;
			}

			currentPage = PageCount;
			recNo = (pageSize
						* (currentPage - 1));
			LoadPage();
		}
		private void DisplayPageInfo()
		{
			txtDisplayPageNo.Text = "Página" + currentPage + "/" + PageCount;
		}
		//Se define la cantidad de paginas y se llama a LoadPage
		private void FillGrid(int cantPaginas)
		{
			// Set the start and max records. 
			pageSize = cantPaginas;//Cantidad de registros por pagina;
								   // txtPageSize.Text
			maxRec = dtSource.Rows.Count;
			PageCount = (maxRec / pageSize);
			//  Adjust the page number if the last page contains a partial page.
			if (((maxRec % pageSize)
						> 0))
			{
				PageCount = (PageCount + 1);
			}
			// Initial seeings
			currentPage = 1;
			recNo = 0;
			//  Display the content of the current page.
			LoadPage();
		}
		private void LoadPage()
		{
			int i;
			int startRec;
			int endRec;
			DataTable dtTemp;
			// Duplicate or clone the source table to create the temporary table.
			dtTemp = dtSource.Clone();
			if ((currentPage == PageCount))
			{
				endRec = maxRec;
			}
			else
			{
				endRec = (pageSize * currentPage);
			}
			startRec = recNo;
			if ((dtSource.Rows.Count > 0))
			{
				// Copy the rows from the source table to fill the temporary table.
				for (i = startRec; (i <= (endRec - 1)); i++)
				{
					dtTemp.ImportRow(dtSource.Rows[i]);
					recNo = (recNo + 1);
				}
			}
			dataGridViewCompras.DataSource = dtTemp;
			DisplayPageInfo();
		}
		private void ConfirmarCompra(List<Ubicacion> ubicSeleccionadas)
		{
			this.Hide();
			new ConfirmarCompra(ubicSeleccionadas, usuario).Show();

		}


	}
}

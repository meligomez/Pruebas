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

namespace PalcoNet.Generar_Rendicion_Comisiones
{ 
	public partial class GenerarRendicionComisiones : Form
    {
		public decimal total = 0;
		public decimal totalConComision = 0;
		Usuario userLog = new Usuario();
		//Variables necesarias para el manejo de paginado
		private DataTable dtSource;
		private int PageCount;
		private int maxRec;
		private int pageSize;
		private int currentPage;
		private int recNo;
		//Verifica que se tenga un tamañano de paginas definidos
		List<RendicionComision> rendicionesAPagar = new List<RendicionComision>();
        public GenerarRendicionComisiones(Usuario u)
        {
			userLog = u;
            InitializeComponent();
        }

		private void GenerarRendicionComisiones_Load(object sender, EventArgs e)
		{
			try
			{
				lblEmpresa.Text = userLog.empresa.Empresa_Cuit;
				DataTable dt = new DataTable();
				DaoSP dao = new DaoSP();
				dt = dao.ObtenerDatosSP("dropeadores.GetComprasPorEmpresa", userLog.empresa.Empresa_Cuit);
				//CargarData.cargarGridView(dataGridView1, dt);
				dtSource = dt;
				//CargarData.AddCheckColumn(dataGridView1, "seleccion");
			}
			catch (Exception ex)
			{

				throw ex;
			}
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
		//Informacion de las paginas
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
		//Concreta la carga de la grilla
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
			dataGridView1.DataSource = dtTemp;
			DisplayPageInfo();
		}
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
			try
			{
				//int Codigo = int.Parse(dataGridView1.CurrentRow.Cells["Codigo"].Value.ToString());
				//Seleccionando
				if (this.dataGridView1.Columns[e.ColumnIndex].Name.Equals("seleccion"))
				{
					RendicionComision rendicion = new RendicionComision();
					rendicion.idCompra = int.Parse(dataGridView1.CurrentRow.Cells["idCompra"].Value.ToString());
					rendicion.idPublicacion = int.Parse(dataGridView1.CurrentRow.Cells["idPublicacion"].Value.ToString());
					rendicion.descripcion = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
					rendicion.porcentaje = decimal.Parse(dataGridView1.CurrentRow.Cells["porcentaje"].Value.ToString());
					rendicion.fila = char.Parse(dataGridView1.CurrentRow.Cells["fila"].Value.ToString());
					rendicion.asiento = int.Parse(dataGridView1.CurrentRow.Cells["asiento"].Value.ToString());
					rendicion.precio = decimal.Parse(dataGridView1.CurrentRow.Cells["precio"].Value.ToString());
					rendicion.fechaCompra = DateTime.Parse(dataGridView1.CurrentRow.Cells["compra_fecha"].Value.ToString());
					totalConComision += ((decimal.Parse(dataGridView1.CurrentRow.Cells["precio"].Value.ToString()) * decimal.Parse(dataGridView1.CurrentRow.Cells["porcentaje"].Value.ToString())/100));
					total += decimal.Parse(dataGridView1.CurrentRow.Cells["precio"].Value.ToString()) - totalConComision;
					lblTotal.Text = total.ToString();
					lblTotalConComision.Text = totalConComision.ToString();
					rendicion.comisionTotalCobrada = totalConComision;
					rendicion.pagadoAEmpresa = total;
					rendicion.cuitEmpresa = userLog.empresa.Empresa_Cuit;
					rendicionesAPagar.Add(rendicion);
				}
				
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void btnPagarEmpresa_Click(object sender, EventArgs e)
		{
			for (int fila = 0; fila < int.Parse(txtCantPags.Text.ToString()) ; fila++)
			{
				RendicionComision rendicion = new RendicionComision();
				rendicion.idCompra = int.Parse(dtSource.Rows[fila]["idCompra"].ToString());
				rendicion.idPublicacion = int.Parse(dtSource.Rows[fila]["idPublicacion"].ToString());
				rendicion.descripcion = dtSource.Rows[fila]["descripcion"].ToString();
				rendicion.porcentaje = decimal.Parse(dtSource.Rows[fila]["porcentaje"].ToString());
				rendicion.fila = char.Parse(dtSource.Rows[fila]["fila"].ToString());
				rendicion.asiento = int.Parse(dtSource.Rows[fila]["asiento"].ToString());
				rendicion.cantidad = int.Parse(dtSource.Rows[fila]["compra_cantidad"].ToString());
				rendicion.precio = decimal.Parse(dtSource.Rows[fila]["precio"].ToString());
				rendicion.fechaCompra = DateTime.Parse(dtSource.Rows[fila]["compra_fecha"].ToString());
				totalConComision += ((decimal.Parse(dtSource.Rows[fila]["precio"].ToString()) * decimal.Parse(dtSource.Rows[fila]["porcentaje"].ToString()) / 100));
				total += decimal.Parse(dtSource.Rows[fila]["precio"].ToString()) - totalConComision;
				lblTotal.Text = total.ToString();
				lblTotalConComision.Text = totalConComision.ToString();
				rendicion.comisionTotalCobrada = totalConComision;
				rendicion.pagadoAEmpresa = total;
				rendicion.cuitEmpresa = userLog.empresa.Empresa_Cuit;
				rendicionesAPagar.Add(rendicion);
	
			}
			try
			{
				Factura f = new Factura();
				ConfigGlobal cg = new ConfigGlobal();
				f.empresaId = userLog.empresa.Empresa_Cuit;
				f.Fecha = cg.getFechaSistema();
				f.TotalComisionCobrada = totalConComision;
				f.TotalEmpresaPagado = total;
				//retorna el id insertado.
				int idFactura=f.altaFactura();
				ItemFactura item = new ItemFactura();
				if(idFactura>0)
				{
					foreach (RendicionComision unaRendicion in rendicionesAPagar)
					{

						item.Cantidad = unaRendicion.cantidad;
						item.Monto = unaRendicion.precio;
						item.descripcion = unaRendicion.descripcion;
						item.compraId = unaRendicion.idCompra;
						item.facturaId = idFactura;
						item.altaItem();
					}
				}
				MessageBox.Show("Se han rendido correctamente las compras!.", "¡Correcto!",
										MessageBoxButtons.OK, MessageBoxIcon.None);

				this.Hide();

			}
			catch (Exception ex)
			{

				throw ex;
			}
			//validar que cuando haya seleccionado todas no haya quedado ninguna sin seleccionar que tenga una fecha anterior.
			//validar que se hayan seleccionado la cantidad de compras a rendir que haya dicho el admin
			//PAGAR A LA EMPRESA significa crear una factura para ESA EMPRESA,
			//y agregar todos los items por esa facutra (EL MONTO DEL ITEM ES EL DE LA COMPRA MENOS LA COMISION)
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
		private void txtbox_Change(object sender, MaskInputRejectedEventArgs e)
		{

		}
		private void textBox_Change(object sender, EventArgs e)
		{
			if (txtCantPags.Text == null || txtCantPags.Text == "")
			{
				MessageBox.Show("Error! Ingrese numeros!");
			}
			else
			{
				if(int.Parse(txtCantPags.Text)>30)
				{
					MessageBox.Show("Puede rendir hasta 30 facturas!");
				}
				else
				{
					total = 0;
					totalConComision = 0;
					for (int fila = 0; fila < int.Parse(txtCantPags.Text.ToString()) ; fila++)
					{
						totalConComision += ((decimal.Parse(dtSource.Rows[fila]["precio"].ToString()) * decimal.Parse(dtSource.Rows[fila]["porcentaje"].ToString()) / 100));
						total += decimal.Parse(dtSource.Rows[fila]["precio"].ToString()) - totalConComision;
						lblTotal.Text = total.ToString();
						lblTotalConComision.Text = totalConComision.ToString();

					}

					FillGrid(int.Parse(txtCantPags.Text));
				}
			}
		}
	}
}

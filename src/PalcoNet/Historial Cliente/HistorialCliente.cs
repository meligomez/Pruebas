using Modelo.Base;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Historial_Cliente
{
    public partial class HistorialCliente : Form
    {
		Usuario userLog = new Usuario();
        public HistorialCliente(Usuario user)
        {
			userLog = user;
            InitializeComponent();
        }
		private void HistorialCliente_Load(object sender, EventArgs e)
		{ 	
			dtSource = this.getCompras(this.userLog.cliente.numeroDocumento);
			
		}
		public DataTable getCompras(int numeroDoc)
		{
			Compra comprasCliente = new Compra();
			DataTable dtPremios = new DataTable();
			DaoSP dao = new DaoSP();
			string query = "SELECT factura, compra_fecha as 'Fecha' ,compra_cantidad as 'Cantidad',"
				+ " compra_precio as 'Precio' ,compra_ubicacionFila as 'Fila' ,compra_ubicacionAsiento as 'Asiento' , p.descripcion"
				+ "  from dropeadores.Compra c"
				+ " join dropeadores.Publicacion p on( c.compra_ubicacionPublic=p.id)"
				+ " WHERE compra_numero_documento="
				+ numeroDoc;
			dtPremios = dao.ConsultarConQuery(query);
			return dtPremios;
		}
		//Variables necesarias para el manejo de paginado
		private DataTable dtSource;
		private int PageCount;
		private int maxRec;
		private int pageSize;
		private int currentPage;
		private int recNo;
		//Verifica que se tenga un tamañano de paginas definidos
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
			pageSize =cantPaginas;//Cantidad de registros por pagina;
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
		//Boton de la primera pagina
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
		//Boton de atras
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
		//Boton siguiente
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
		//Boton de la ultima pagina
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

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if(txtCantPags.Text == null || txtCantPags.Text == "")
			{
				MessageBox.Show("Error! Ingrese numeros!");
			}
			else
			{
				FillGrid(int.Parse(txtCantPags.Text));
			}
		}
			

		private void cantPags_Click(object sender, EventArgs e)
		{
			
		}

		private void txtCantPags_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
		{

		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}

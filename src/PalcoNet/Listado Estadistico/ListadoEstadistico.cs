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
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {

		int vContadorDatos = 0;
		public ListadoEstadistico()
        {
            InitializeComponent();
        }

		private void ListadoEstadistico_Load(object sender, EventArgs e)
		{
			cbxAnio.Items.Add("2015");
			cbxAnio.Items.Add("2016");
			cbxAnio.Items.Add("2017");
			cbxAnio.Items.Add("2018");
			cbxAnio.Items.Add("2019");

			cbxTrimestre.Items.Add("Primer");
			cbxTrimestre.Items.Add("Segundo");
			cbxTrimestre.Items.Add("Tercero");
			cbxTrimestre.Items.Add("Cuarto");

			cbxTipoEstadistica.Items.Add("Empresas con mayor cantidad de localidades no vendidas");
			cbxTipoEstadistica.Items.Add("Clientes con mayores puntos vencidos");
			cbxTipoEstadistica.Items.Add("Clientes con mayor cantidad de compras");
		}

		private void btnFiltroFecha_Click(object sender, EventArgs e)
		{
	
				grafico.Visible = true;
				dataGridView1.Visible = true;
				string tipoEstadistica = cbxTipoEstadistica.SelectedItem.ToString();
				string anio = cbxAnio.SelectedItem.ToString();
				string trimestre = cbxTrimestre.SelectedItem.ToString();
			
				Estadistica estadistica = new Estadistica();
				ConfigGlobal conf = new ConfigGlobal();
				DateTime fechaDelSistema = conf.getFechaSistema();
				DataTable dt = new DataTable();
			switch (tipoEstadistica)
				{
					case "Empresas con mayor cantidad de localidades no vendidas":
					//	//estadistica.getLocalidadesNoVendidas(dataGridView1,trimestre, anio);
					break;
					case "Clientes con mayores puntos vencidos":
						dt=estadistica.getClientesMasPuntosVencidos(dataGridView1, trimestre, anio);
						CargarData.cargarGridView(dataGridView1, dt);
						grafico.Series[0].ChartType = SeriesChartType.Line;
						grafico.Series[0].Name = "Puntos Vencidos por Compras";
						foreach (DataRow drow in dt.Rows)
						{
							grafico.Series[0].Points.AddXY(drow["Cantidad de compras"].ToString(), drow["Puntos Vencidos"].ToString());
						}
						
					break;
					case "Clientes con mayor cantidad de compras":
						dt=estadistica.getClientesMayorCompras(dataGridView1,trimestre, anio);
						CargarData.cargarGridView(dataGridView1, dt);
						grafico.Series[0].ChartType = SeriesChartType.Line;
						grafico.Series[0].Name = "Compras por Publicaciones";
						foreach (DataRow drow in dt.Rows)
						{
							grafico.Series[0].Points.AddXY(drow["Cantidad de compras"].ToString(), drow["Cantidad de Publicaciones"].ToString());
						}
					break;
					default:
						MessageBox.Show("Ha ocurrido un error al cargar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						break;
				}

			
		//Empresas con mayor cantidad de localidades no vendidas, dicho listado debe
		//filtrarse por grado de visibilidad de la publicación y por mes - año.Primero se
		// deberá ordenar por fecha y luego por visibilidad.

		//● Clientes con mayor cantidad de compras, agrupando las publicaciones por
		//empresa.


		}
		private void anioChange(object sender, EventArgs e)
		{
				lblTrimestre.Visible = true;
			cbxTrimestre.Visible = true;
		}
		private void trimestreChange(object sender, EventArgs e)
		{
			cbxTipoEstadistica.Visible = true;
			lblTipoEstadistica.Visible = true;
		}
		private void cbxTipoEstadisticaChange(object sender, EventArgs e)
		{
			btnFiltroFecha.Visible = true;
			
		}

		private void grafico_Click(object sender, EventArgs e)
		{

		}

		private void Filtros_Enter(object sender, EventArgs e)
		{

		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}

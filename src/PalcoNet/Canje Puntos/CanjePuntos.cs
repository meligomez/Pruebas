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

namespace PalcoNet.Canje_Puntos
{
	public partial class CanjePuntos : Form
	{
		Usuario userLogueado;
		DateTime fechaDelSistema;
		Cliente cliente = new Cliente();
		Puntos puntos = new Puntos();
		Premio premio = new Premio();
		public CanjePuntos(Usuario user)
		{
			userLogueado = user;
			InitializeComponent();
		}

		private void CanjePuntos_Load(object sender, EventArgs e)
		{
			ConfigGlobal global = new ConfigGlobal();
			int puntosVigentes = 0;
			fechaDelSistema = global.getFechaSistema();
			DaoSP dao = new DaoSP();
			lblPuntosACanjear.Visible = false;
			//Busco los puntos de ese cliente
			puntosVigentes = puntos.consultarPuntosVigentes(fechaDelSistema, userLogueado.cliente.numeroDocumento);
			lblPuntosVigentes.Text = puntosVigentes.ToString();

			//Busco los premios que pueda a llegar a canjear un cliente,
			//tener en cuenta que los premios tienen su puntaje,
			//por ende el cliente segun sus puntos es el premio que le corresponde.
			DataTable dtPremios = new DataTable();
			string query = "select distinct p.Id as IdPremio,p.descripcion as Descripcion,PuntosVigentes,p.puntos as Puntos,FechaVencimiento from dropeadores.Puntos pu, " +
			" dropeadores.Premio p where Id_Cliente =" + userLogueado.cliente.numeroDocumento +
			" and pu.PuntosVigentes > p.puntos and FechaVencimiento > '" + fechaDelSistema + "' ";
			dtPremios = dao.ConsultarConQuery(query);
			DataTable dtPremios2 = new DataTable();
			string query2 = "select distinct p.puntos as Puntos,p.descripcion  from dropeadores.Puntos pu, " +
			" dropeadores.Premio p where Id_Cliente =" + userLogueado.cliente.numeroDocumento +
			" and pu.PuntosVigentes > p.puntos and FechaVencimiento > '" + fechaDelSistema + "' ";
			dtPremios2 = dao.ConsultarConQuery(query2);
			if (dtPremios.Rows.Count<=0)
			{
				
				MessageBox.Show("No existen puntos asociados al cliente, o no existen premios para la cantidad de puntos asociados.", "Error al cargar los puntos",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				DataRow rowPremios = dtPremios.Rows[0];
				premio.Id = int.Parse(rowPremios["IdPremio"].ToString());
				premio.puntos = int.Parse(rowPremios["Puntos"].ToString());
				premio.descripcion = rowPremios["Descripcion"].ToString();
				CargarData.cargarComboBox(cbxPremios, dtPremios2, "Puntos", "descripcion");

			}


			DataTable dtcli = new DataTable();
			dtcli = dao.ConsultarConQuery("select nombre,apellido,NumeroDocumento from dropeadores.Cliente where NumeroDocumento= " + userLogueado.cliente.numeroDocumento);
			DataRow rowcli = dtcli.Rows[0];
			cliente.nombre = rowcli["nombre"].ToString();
			cliente.apellido = rowcli["apellido"].ToString();
			cliente.numeroDocumento = int.Parse(rowcli["NumeroDocumento"].ToString());
			lblCliente.Text = cliente.nombre + " " + cliente.apellido;
			lblDniCli.Text = cliente.numeroDocumento.ToString();
		}

		private void btnCanjear_Click(object sender, EventArgs e)
		{
			Puntos p = new Puntos();
			int puntosVigentesActuales = 0;
			if(int.Parse(lblPuntosACanjear.Text) < int.Parse(lblPuntosVigentes.Text))
			{
				//Premio.punto son los puntos seleccionados del cbx.
				premio.puntos = int.Parse(cbxPremios.SelectedValue.ToString());
				p.actualizarPuntaje(userLogueado.cliente.numeroDocumento, premio.puntos, premio.Id, int.Parse(lblPuntosVigentes.Text.ToString()));
				puntosVigentesActuales = puntos.consultarPuntosVigentes(fechaDelSistema, userLogueado.cliente.numeroDocumento);
				lblPuntosVigentes.Text = puntosVigentesActuales.ToString();
				lblPuntosActuales.Text = puntosVigentesActuales.ToString();
			}
			else
			{
				MessageBox.Show("El premio elegido excede los puntos vigentes.", "Error al canjear los puntos",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		
		}
		private void cbxPremios_Change(object sender, EventArgs e)
		{
			lblPuntosACanjear.Visible = true;
			lblPuntosACanjear.Text = cbxPremios.SelectedValue.ToString();
		}
		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}

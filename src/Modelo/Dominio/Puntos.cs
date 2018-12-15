using Modelo.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelo.Dominio
{
	public class Puntos
	{
		public int Id_Premio { get; set; }
		public int PuntosVigentes { get; set; }
		public DateTime FechaVencimiento { get; set; }
		public int Id_Compra { get; set; }
		public int puntos { get; set; }
		public int Id_Cliente { get; set; }


		public int actualizarPuntaje(int idCliente, int puntosParaCanjear, int idPremio, int puntosVigenteslbl)
		{
			DaoSP dao = new DaoSP();
			DataTable dtPuntosCanjeo = new DataTable();
			//pasarle cliente y puntos a restar, 
			//Los ordeno por los q ya se esten por vencer para restar esos puntos
			dtPuntosCanjeo = dao.ConsultarConQuery("select * from dropeadores.Puntos where Id_Cliente=" + idCliente + "order by FechaVencimiento asc");
			//List<Puntos> puntos = new List<Puntos>();
			Puntos p = new Puntos();
			int sumatoriaPuntosCanjeados = 0;
			int sumatoriaPuntosActuales= puntosVigenteslbl;
			//tengo q dividir la cantidad de puntos a canjear sobre los puntos x compra 
			foreach (DataRow itemRow in dtPuntosCanjeo.Rows)
			{
				//p.Id_Premio=int.Parse(itemRow["Id_Premio"].ToString());
				//puntos vigentes es la sumatoria de todos los puntos de todas las compras de ese cliente
				p.PuntosVigentes = int.Parse(itemRow["PuntosVigentes"].ToString());
				p.FechaVencimiento = DateTime.Parse(itemRow["FechaVencimiento"].ToString());
				p.Id_Compra = int.Parse(itemRow["Id_Compra"].ToString());
				//Puntos es punto por compra
				p.puntos = int.Parse(itemRow["puntos"].ToString());
				p.Id_Cliente = int.Parse(itemRow["Id_Cliente"].ToString());
				//La cantidad de puntos que tiene puede canjear cualquier cosa del comboBox.
				//fijarse q el IF anda mal xq sigue descontando, deberia parar cuando los puntos q va canjeando sea 
				//los q tiene ese premio.
				if (sumatoriaPuntosActuales - p.puntos > 0 && sumatoriaPuntosCanjeados<= puntosParaCanjear)
				{
					if (dao.EjecutarSP("dropeadores.DescontarPuntosPorCompra", p.Id_Cliente, p.Id_Compra) <= 0)
					{
						break;
					}
					sumatoriaPuntosActuales = sumatoriaPuntosActuales - p.puntos;
					sumatoriaPuntosCanjeados += p.puntos;
				}

			}
			if (dao.EjecutarSP("dropeadores.ActualizarPuntaje", idCliente, idPremio, puntosParaCanjear) <= 0)
			{
				MessageBox.Show("Ha ocurrido un error..", "Error al canjear los puntos",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
			}
			else
			{
				DataTable dtPuntosActualizados = new DataTable();
				dtPuntosActualizados = dao.ConsultarConQuery("select PuntosVigentes from dropeadores.Puntos where Id_Cliente=" + idCliente + "order by FechaVencimiento asc");
				DataRow drow = dtPuntosActualizados.Rows[0];
				sumatoriaPuntosActuales = int.Parse(drow["PuntosVigentes"].ToString());
			}

			return 0;

		}

		public int consultarPuntosVigentes(DateTime fechaDelSistema, int IdCliente)
		{
			DaoSP dao = new DaoSP();
			DataTable dtPuntos = new DataTable();
			string query = "select top 1 PuntosVigentes from dropeadores.Puntos where PuntosVigentes>0 and Id_Cliente =" + IdCliente
				+ " and FechaVencimiento > '" + fechaDelSistema + "'";
			dtPuntos = dao.ConsultarConQuery(query);
			if(dtPuntos.Rows.Count<=0)
			{
				this.PuntosVigentes = 0;

			}
			else
			{
				DataRow rowPuntos = dtPuntos.Rows[0];
				this.PuntosVigentes = int.Parse(rowPuntos["PuntosVigentes"].ToString());
			}
			
			return this.PuntosVigentes;
		}
	}
}

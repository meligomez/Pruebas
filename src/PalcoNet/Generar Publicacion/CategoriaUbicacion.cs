using Modelo.Base;
using Modelo.Comun;
using Modelo.Dominio;
using PalcoNet.VentanasPorRol;
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

namespace PalcoNet.Generar_Publicacion
{
    public partial class CategoriaUbicacion : Form
    {
		public Usuario userLogueado;
		public Publicacion publicacion;
		public bool precioAsignado=false;
		public Ubicacion ubicacion;
		List<TipoUbicacion> tiposDeUbicacionPorPublicacion= new List<TipoUbicacion>();
		public TipoUbicacion tipoUbicacion;
		int botonesSinCategoria = 0;
		TipoUbicacion tu = new TipoUbicacion();
		public CategoriaUbicacion(Usuario userLog,Publicacion publi)
        {
			userLogueado = userLog;
			publicacion = publi;

			InitializeComponent();
        }

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Close();
			Usuario user=new Usuario();
			panelContenedor menu = new panelContenedor(user);
			menu.Show();
		}

		private void GenerarPublicacion_Load(object sender, EventArgs e)
		{
			////Necesito en empresa un metodo que dado el id me devuelva la razon social.
			//DataTable dtGrado = new DataTable();
			//DataTable dtRubro = new DataTable();
			DataTable dtTipoUbicacion = new DataTable();
			DaoSP dao = new DaoSP();
			//dtGrado=dao.ConsultarConQuery("SELECT id, tipo FROM dropeadores.Grado");
			//dtRubro=dao.ConsultarConQuery("SELECT Codigo,Descripcion FROM dropeadores.Rubro");
			dtTipoUbicacion = dao.ConsultarConQuery("select distinct Ubicacion_Tipo_Descripcion,Ubicacion_Tipo_Codigo as Codigo from gd_esquema.Maestra");
			//CargarData.cargarComboBox(comboRubro, dtRubro, "Codigo", "Descripcion");
			//CargarData.cargarComboBox(comboGradoPublicacion, dtGrado, "id", "tipo");
			CargarData.cargarComboBox(comboBox1, dtTipoUbicacion, "Ubicacion_Tipo_Descripcion", "Ubicacion_Tipo_Descripcion");
			//lblEstado.Text = "Borrador";
			//lblUserLogueado.Text = userLogueado.empresa.Empresa_razon_social;

			int cantAsientos = publicacion.stock;
			if (cantAsientos % 10 != 0)
			{
				MessageBox.Show("El stock debe ser múltiplo de 10.", "¡Error!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				int cantidadDeFilasAInsertar;
				cantidadDeFilasAInsertar = cantAsientos / 10;
				if (cantAsientos % 10 != 0) { cantidadDeFilasAInsertar += 1; }
				if (cantidadDeFilasAInsertar == 1)
				{
					insertarFilaA();
				}
				if (cantidadDeFilasAInsertar == 2) { insertarFilaA(); insertarFilaB(); }
				if (cantidadDeFilasAInsertar == 3) { insertarFilaA(); insertarFilaB(); insertarFilaC(); }
				if (cantidadDeFilasAInsertar == 4)
				{
					insertarFilaA(); insertarFilaB(); insertarFilaC();
					insertarFilaD();
				}
				if (cantidadDeFilasAInsertar == 5)
				{
					insertarFilaA(); insertarFilaB(); insertarFilaC();
					insertarFilaD(); insertarFilaE();
				}
				if (cantidadDeFilasAInsertar == 6)
				{
					insertarFilaA(); insertarFilaB(); insertarFilaC();
					insertarFilaD(); insertarFilaE(); insertarFilaF();
				}
				if (cantidadDeFilasAInsertar == 7)
				{
					insertarFilaA(); insertarFilaB(); insertarFilaC();
					insertarFilaD(); insertarFilaE(); insertarFilaF(); insertarFilaG();
				}
				if (cantidadDeFilasAInsertar == 8)
				{
					insertarFilaA(); insertarFilaB(); insertarFilaC();
					insertarFilaD(); insertarFilaE(); insertarFilaF(); insertarFilaG(); insertarFilaH();
				}
				if (cantidadDeFilasAInsertar == 9)
				{
					insertarFilaA(); insertarFilaB(); insertarFilaC();
					insertarFilaD(); insertarFilaE(); insertarFilaF();
					insertarFilaG(); insertarFilaH(); insertarFilaI();
				}
				if (cantidadDeFilasAInsertar == 10)
				{
					insertarFilaA(); insertarFilaB(); insertarFilaC();
					insertarFilaD(); insertarFilaE(); insertarFilaF();
					insertarFilaG(); insertarFilaH(); insertarFilaI(); insertarFilaJ();
				}
			}


		}

		//private void changeRadioButton(object sender, EventArgs e)
		//{
		//	groupBox1.Visible = false;
		//	if(radioNo.Checked)
		//	{
		//		lblFechaEspectaculo.Visible = true;
		//		dateTimePickerEspectaculo.Visible = true;
		//	}
		//}
		private void changeStock(object sender, EventArgs e)
		{
		}
		private void changeCategoria(object sender, EventArgs e)
		{
			//MessageBox.Show("Ingrese un precio para la categoria seleccionada.", "¡!",
			//	MessageBoxButtons.OK, MessageBoxIcon.None);
			precioAsignado = false;
		}
		private void changeA1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A1);
			

		}

		private void cambiarColorButtonSegunCategoria(Button bton)
		{
			//precioAsignado = false;
			if (validarPrecioPorCategoria())
			{
				if (comboBox1.SelectedValue.ToString() == "Vip")
				{
					bton.BackColor = Color.Purple;
				}
				if (comboBox1.SelectedValue.ToString() == "Cabecera")
				{
					bton.BackColor = Color.Tomato;
				}
				if (comboBox1.SelectedValue.ToString() == "Campo")
				{
					
					bton.BackColor = Color.Yellow;
				}
				if (comboBox1.SelectedValue.ToString() == "Campo Vip")
				{
					bton.BackColor = Color.Maroon;
				}
				if (comboBox1.SelectedValue.ToString() == "Platea Alta")
				{
					bton.BackColor = Color.Beige;
				}
				if (comboBox1.SelectedValue.ToString() == "Platea Baja")
				{
					bton.BackColor = Color.Indigo;
				}
				if (comboBox1.SelectedValue.ToString() == "PullMan")
				{
					bton.BackColor = Color.Red;
				}
				if (comboBox1.SelectedValue.ToString() == "Super PullMan")
				{
					bton.BackColor = Color.Pink;
				}
			}
			else
			{
				MessageBox.Show("No se puede asignar la categoria, primero asocie un precio.s", "¡Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

		private bool validarPrecioPorCategoria()
		{
			return precioAsignado;
		}

		private void changeA2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A2);
		}
		private void changeA3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A3);
		}
		private void changeA4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A4);
		}
		private void changeA5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A5);
		}
		private void changeA6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A6);

		}
		private void changeA7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A7);
		}
		private void changeA8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A8);
		}
		private void changeA9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A9);
		}
		private void changeA10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(A10);
		}
		//Boton B
		private void changeB1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B1);
		}
		private void changeB2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B2);
		}
		private void changeB3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B3);
		}
		private void changeB4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B4);
		}
		private void changeB5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B5);
		}
		private void changeB6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B6);

		}
		private void changeB7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B7);
		}
		private void changeB8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B8);
		}
		private void changeB9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B9);
		}
		private void changeB10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(B10);
		}
		//Boton C
		private void changeC1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C1);
		}
		private void changeC2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C2);
		}
		private void changeC3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C3);
		}
		private void changeC4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C4);
		}
		private void changeC5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C5);
		}
		private void changeC6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C6);

		}
		private void changeC7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C7);
		}
		private void changeC8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C8);
		}
		private void changeC9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C9);
		}
		private void changeC10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(C10);
		}
		//Boton D
		private void changeD1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D1);
		}
		private void changeD2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D2);
		}
		private void changeD3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D3);
		}
		private void changeD4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D4);
		}
		private void changeD5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D5);
		}
		private void changeD6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D6);

		}
		private void changeD7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D7);
		}
		private void changeD8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D8);
		}
		private void changeD9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D9);
		}
		private void changeD10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(D10);
		}
		//Boton E
		private void changeE1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E1);
		}
		private void changeE2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E2);
		}
		private void changeE3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E3);
		}
		private void changeE4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E4);
		}
		private void changeE5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E5);
		}
		private void changeE6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E6);

		}
		private void changeE7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E7);
		}
		private void changeE8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E8);
		}
		private void changeE9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E9);
		}
		private void changeE10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(E10);
		}
		//Boton F
		private void changeF1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F1);
		}
		private void changeF2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F2);
		}
		private void changeF3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F3);
		}
		private void changeF4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F4);
		}
		private void changeF5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F5);
		}
		private void changeF6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F6);

		}
		private void changeF7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F7);
		}
		private void changeF8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F8);
		}
		private void changeF9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F9);
		}
		private void changeF10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(F10);
		}
		//Boton G
		private void changeG1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G1);
		}
		private void changeG2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G2);
		}
		private void changeG3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G3);
		}
		private void changeG4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G4);
		}
		private void changeG5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G5);
		}
		private void changeG6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G6);

		}
		private void changeG7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G7);
		}
		private void changeG8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G8);
		}
		private void changeG9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G9);
		}
		private void changeG10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(G10);
		}
		//Boton H
		private void changeH1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H1);
		}
		private void changeH2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H2);
		}
		private void changeH3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H3);
		}
		private void changeH4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H4);
		}
		private void changeH5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H5);
		}
		private void changeH6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H6);

		}
		private void changeH7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H7);
		}
		private void changeH8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H8);
		}
		private void changeH9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H9);
		}
		private void changeH10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(H10);
		}
		//Boton I
		private void changeI1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I1);
		}
		private void changeI2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I2);
		}
		private void changeI3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I3);
		}
		private void changeI4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I4);
		}
		private void changeI5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I5);
		}
		private void changeI6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I6);

		}
		private void changeI7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I7);
		}
		private void changeI8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I8);
		}
		private void changeI9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I9);
		}
		private void changeI10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(I10);
		}
		//Boton J
		private void changeJ1(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J1);
		}
		private void changeJ2(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J2);
		}
		private void changeJ3(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J3);
		}
		private void changeJ4(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J4);
		}
		private void changeJ5(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J5);
		}
		private void changeJ6(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J6);

		}
		private void changeJ7(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J7);
		}
		private void changeJ8(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J8);
		}
		private void changeJ9(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J9);
		}
		private void changeJ10(object sender, EventArgs e)
		{
			cambiarColorButtonSegunCategoria(J10);
		}
		private void insertarFilaA()
		{
			groupBox2.Visible = true;
			A.Visible = true;
			A1.Visible = true;
			A2.Visible = true;
			A3.Visible = true;
			A4.Visible = true;
			A5.Visible = true;
			A6.Visible = true;
			A7.Visible = true;
			A8.Visible = true;
			A9.Visible = true;
			A10.Visible = true;
		}
		private void insertarFilaB()
		{
			groupBox2.Visible = true;
			B.Visible = true;
			B1.Visible = true;
			B2.Visible = true;
			B3.Visible = true;
			B4.Visible = true;
			B5.Visible = true;
			B6.Visible = true;
			B7.Visible = true;
			B8.Visible = true;
			B9.Visible = true;
			B10.Visible = true;
		}
		private void insertarFilaC()
		{
			groupBox2.Visible = true;
			C.Visible = true;
			C1.Visible = true;
			C2.Visible = true;
			C3.Visible = true;
			C4.Visible = true;
			C5.Visible = true;
			C6.Visible = true;
			C7.Visible = true;
			C8.Visible = true;
			C9.Visible = true;
			C10.Visible = true;
		}
		private void insertarFilaD()
		{
			groupBox2.Visible = true;
			D.Visible = true;
			D1.Visible = true;
			D2.Visible = true;
			D3.Visible = true;
			D4.Visible = true;
			D5.Visible = true;
			D6.Visible = true;
			D7.Visible = true;
			D8.Visible = true;
			D9.Visible = true;
			D10.Visible = true;
		}
		private void insertarFilaE()
		{
			groupBox2.Visible = true;
			E.Visible = true;
			E1.Visible = true;
			E2.Visible = true;
			E3.Visible = true;
			E4.Visible = true;
			E5.Visible = true;
			E6.Visible = true;
			E7.Visible = true;
			E8.Visible = true;
			E9.Visible = true;
			E10.Visible = true;
		}
		private void insertarFilaF()
		{
			groupBox2.Visible = true;
			F.Visible = true;
			F1.Visible = true;
			F2.Visible = true;
			F3.Visible = true;
			F4.Visible = true;
			F5.Visible = true;
			F6.Visible = true;
			F7.Visible = true;
			F8.Visible = true;
			F9.Visible = true;
			F10.Visible = true;
		}
		private void insertarFilaG()
		{
			groupBox2.Visible = true;
			G.Visible = true;
			G1.Visible = true;
			G2.Visible = true;
			G3.Visible = true;
			G4.Visible = true;
			G5.Visible = true;
			G6.Visible = true;
			G7.Visible = true;
			G8.Visible = true;
			G9.Visible = true;
			G10.Visible = true;
		}
		private void insertarFilaH()
		{
			groupBox2.Visible = true;
			H.Visible = true;
			H1.Visible = true;
			H2.Visible = true;
			H3.Visible = true;
			H4.Visible = true;
			H5.Visible = true;
			H6.Visible = true;
			H7.Visible = true;
			H8.Visible = true;
			H9.Visible = true;
			H10.Visible = true;
		}
		private void insertarFilaJ()
		{
			groupBox2.Visible = true;
			J.Visible = true;
			J1.Visible = true;
			J2.Visible = true;
			J3.Visible = true;
			J4.Visible = true;
			J5.Visible = true;
			J6.Visible = true;
			J7.Visible = true;
			J8.Visible = true;
			J9.Visible = true;
			J10.Visible = true;
		}
		private void insertarFilaI()
		{
			groupBox2.Visible = true;
			I.Visible = true;
			I1.Visible = true;
			I2.Visible = true;
			I3.Visible = true;
			I4.Visible = true;
			I5.Visible = true;
			I6.Visible = true;
			I7.Visible = true;
			I8.Visible = true;
			I9.Visible = true;
			I10.Visible = true;
		}
		public string soloNumeros(string param)
		{

			Match m = Regex.Match(param, "(\\d+)");
			string num = string.Empty;

			if (m.Success)
			{
				num = m.Value;
			}
			return num;
		}
		private List<Ubicacion> buscarButtons()
		{
			Ubicacion ubicacion = new Ubicacion();

			TipoUbicacion tu = new TipoUbicacion();
			
			List<Ubicacion> ubicaciones = new List<Ubicacion>();
		
			foreach (Control cComponente in this.Controls)
			{
				if (cComponente is GroupBox)
				{
					foreach (Control cComponente2 in cComponente.Controls)
					{
						if (cComponente2 is Button)
						{ //    
							
							if (cComponente2.BackColor == Color.Purple)
							{
								Ubicacion ubicacion1 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion1.asiento = int.Parse(numero);
								ubicacion1.fila = cComponente2.Name[0];
								//dado una descripcion me devuelva su id 
								//ubicacion1.tipoUbicacionId= tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Vip").codigo;
								ubicacion1.tipoUbicacionId = tu.buscarCodigoCategoria("Vip");
								ubicacion1.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Vip").precio;
								ubicaciones.Add(ubicacion1);
							}
							if (cComponente2.BackColor == Color.Tomato)
							{
								Ubicacion ubicacion2 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion2.asiento = int.Parse(numero);
								ubicacion2.fila = cComponente2.Name[0];
								//ubicacion2.tipoUbicacionId = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Cabecera").codigo;
								ubicacion2.tipoUbicacionId = tu.buscarCodigoCategoria("Cabecera");
								ubicacion2.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Cabecera").precio;
								//ubicacion.tipoDescripcion = "Cabecera";
								ubicaciones.Add(ubicacion2);
							}
							if (cComponente2.BackColor == Color.Yellow)
							{
								Ubicacion ubicacion3 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion3.asiento = int.Parse(numero); 
								ubicacion3.fila = cComponente2.Name[0];
								//ubicacion3.tipoUbicacionId = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Campo").codigo;
								ubicacion3.tipoUbicacionId = tu.buscarCodigoCategoria("Campo");
								ubicacion3.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Campo").precio;
								//ubicacion.tipoDescripcion = "Campo";
								ubicaciones.Add(ubicacion3);
							}
							if (cComponente2.BackColor == Color.Maroon)
							{
								Ubicacion ubicacion4 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion4.asiento = int.Parse(numero); ;
								ubicacion4.fila = cComponente2.Name[0];
								ubicacion4.tipoUbicacionId = tu.buscarCodigoCategoria("Campo Vip");
								ubicacion4.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Campo Vip").precio;
								//ubicacion.tipoDescripcion = "Campo Vip";
								ubicaciones.Add(ubicacion4);
							}
							if (cComponente2.BackColor == Color.Beige)
							{
								Ubicacion ubicacion5 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion5.asiento = int.Parse(numero); 
								ubicacion5.fila = cComponente2.Name[0];
								//ubicacion5.tipoUbicacionId = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Platea Alta").codigo;
								ubicacion5.tipoUbicacionId = tu.buscarCodigoCategoria("Platea Alta");
								ubicacion5.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Platea Alta").precio;
								//ubicacion.tipoDescripcion = "Platea Alta";
								ubicaciones.Add(ubicacion5);
								//cantidadBotonesBeige++;
								//asientosConFila.Add(cComponente2.Name);
							}
							if (cComponente2.BackColor == Color.Indigo)
							{
								Ubicacion ubicacion6 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion6.asiento = int.Parse(numero); ;
								ubicacion6.fila = cComponente2.Name[0];
								//ubicacion6.tipoUbicacionId = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Platea Baja").codigo;
								ubicacion6.tipoUbicacionId = tu.buscarCodigoCategoria("Platea Baja");
								ubicacion6.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Platea Baja").precio;
								//ubicacion.tipoDescripcion = "Platea Baja";
								ubicaciones.Add(ubicacion6);
								//cantidadBotonesIndigo++;
								//asientosConFila.Add(cComponente2.Name);
							}
							if (cComponente2.BackColor == Color.Red)
							{
								Ubicacion ubicacion7 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion7.asiento = int.Parse(numero); ;
								ubicacion7.fila = cComponente2.Name[0];
								ubicacion7.tipoUbicacionId = tu.buscarCodigoCategoria("PullMan");
								//ubicacion7.tipoUbicacionId = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "PullMan").codigo;
								ubicacion7.tipoUbicacionId = tu.buscarCodigoCategoria("PullMan");
								ubicacion7.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "PullMan").precio;
								//ubicacion.tipoDescripcion = "PullMan";
								ubicaciones.Add(ubicacion7);
								//cantidadBotonesRed++;
								//asientosConFila.Add(cComponente2.Name);
							}
							if (cComponente2.BackColor == Color.Pink)
							{
								Ubicacion ubicacion8 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion8.asiento = int.Parse(numero); 
								ubicacion8.fila = cComponente2.Name[0];
								//ubicacion8.tipoUbicacionId = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Super PullMan").codigo;
								ubicacion8.tipoUbicacionId = tu.buscarCodigoCategoria("Super PullMan");
								ubicacion8.precio = tiposDeUbicacionPorPublicacion.First(unTipo => unTipo.descripcion == "Super PullMan").precio;
								//ubicacion.tipoDescripcion = "Super PullMan";
								ubicaciones.Add(ubicacion8);
								//cantidadBotonesPink++;
								//asientosConFila.Add(cComponente2.Name);
							}
							if(cComponente2.BackColor == Color.Silver && cComponente2.Visible==true)
							{
								Ubicacion ubicacion8 = new Ubicacion();
								string numero = soloNumeros(cComponente2.Name);
								ubicacion8.asiento = int.Parse(numero);
								ubicacion8.fila = cComponente2.Name[0];
								botonesSinCategoria++;
							}
						}
					}
				}
			}
			return ubicaciones;
		}
		private void btnGuardar_Click(object sender, EventArgs e)
		{
			if (this.validarData())
			{
				//foreach (TipoUbicacion tub in tiposDeUbicacionPorPublicacion)
				//{
				//	//no dar el alta sino buscar la categoria....
				//	//tub.codigo = tub.darAltaPrecioPorCategoria(tub.precio, tub.descripcion);
				//}

				List<Ubicacion> ubicaciones = this.buscarButtons();
				List<DateTime> fechasEspectaculos = new List<DateTime>();
				fechasEspectaculos = publicacion.fechaEspectaculoLote;

				//significa q no es por lote.
				if (fechasEspectaculos.Count==0)
				{
					
						int idPublicacionInsertado = 0;
						idPublicacionInsertado = publicacion.altaPublicacion();
						publicacion.codigo = idPublicacionInsertado;
						if (idPublicacionInsertado > 0)
						{
							Ubicacion u = new Ubicacion();
							if (u.altaUbicaciones(ubicaciones, publicacion.codigo) == 0)
							{

								MessageBox.Show("Se ha creado la publicación correctamente, el número es: " + publicacion.codigo, "¡Correcto!",
										MessageBoxButtons.OK, MessageBoxIcon.None);
								this.Hide();
							}
							else
							{
								MessageBox.Show("Error al crear la Publicacion.", "¡Error!",
										MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						else
						{
							MessageBox.Show("Error al crear la Publicacion.", "¡Error!",
										MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					
					
				}
				else
				{
					//es por lote. tengo q hacer un INSERT DE PUBLICACION POR CADA fecha distinta. onda lo unico q cambia es la fecha.
					foreach (DateTime unaFechaEspectaculo in fechasEspectaculos)
					{
						publicacion.fechaEspectaculo = unaFechaEspectaculo;
						if (publicacion.existeFechayHoraSinLote())
						{

							int idPublicacionInsertado = 0;
							idPublicacionInsertado = publicacion.altaPublicacion();
							publicacion.codigo = idPublicacionInsertado;
							if (idPublicacionInsertado > 0)
							{


								Ubicacion u = new Ubicacion();
								if (u.altaUbicaciones(ubicaciones, publicacion.codigo) == 0)
								{

									MessageBox.Show("Se ha creado la publicación correctamente, el número es: " + publicacion.codigo, "¡Correcto!",
											MessageBoxButtons.OK, MessageBoxIcon.None);
									this.Hide();
								}
								else
								{
									MessageBox.Show("Error al crear la Publicacion.", "¡Error!",
											MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
						}
						else
						{
							MessageBox.Show("Error, hay fechas en las cuales ya existe otro espectáculo.", "¡Error!",
											MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}

					
				}
				
				//asociar el id del tipo de ubicacion con la ubicacion 
				//despues tengo q dar de alta a esa publicacion 


			}
		}

		private bool validarData()
		{
			
			if(botonesSinCategoria>0)
			{
				MessageBox.Show("Debe asignarle una categoria a todos los asientos.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (textPrecio.Text == "")
			{
				MessageBox.Show("Debe ingresar un precio.", "¡Advertencia!",
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}
			private void buscarAsientos_Click(object sender, EventArgs e)
		{
			
			
		}

		private void btnPrecioPorCategoria_Click(object sender, EventArgs e)
		{
			
			if( textPrecio.Text=="")
			{
				//
				MessageBox.Show("Ingrese un precio", "¡Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				precioAsignado = false;
			}
			else
			{
				if(decimal.Parse(textPrecio.Text) <= 0)
				{
					MessageBox.Show("Ingrese un precio válido", "¡Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					precioAsignado = false;
				}
				else
				{
					//valido que no vuelva a ingresar otro precio de esa misma categoria
					if(tiposDeUbicacionPorPublicacion.Any(unTipo => unTipo.descripcion== comboBox1.SelectedValue.ToString()))
					{
						MessageBox.Show("Ya asignó un precio a esa categoria.", "¡Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						precioAsignado = true ;
					}
					else
					{
						//valido que no ponga un mismo precio a distinta categoria.
						if(tiposDeUbicacionPorPublicacion.Any(unTipo => unTipo.precio == decimal.Parse(textPrecio.Text)))
						{
							MessageBox.Show("Ya asignó ese mismo precio a otra categoria.", "¡Error!",
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							precioAsignado = false;
						}
						else
						{
							//tengo que dar de alta a esa categoria con ese precio.
							TipoUbicacion tu2 = new TipoUbicacion();
							tu2.descripcion = comboBox1.SelectedValue.ToString();
							tu2.precio = decimal.Parse(textPrecio.Text);
							tiposDeUbicacionPorPublicacion.Add(tu2);
							MessageBox.Show("Categoria: "+ comboBox1.SelectedValue.ToString()+" Precio :$"+ decimal.Parse(textPrecio.Text), "¡Correcto!",
								MessageBoxButtons.OK, MessageBoxIcon.None);
							precioAsignado = true;
						}
						
					}
					
				}
				
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void textStock_TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo.Dominio;
using PalcoNet.Abm_Cliente;
using PalcoNet.Abm_Empresa_Espectaculo;
using PalcoNet.Abm_Grado;
using PalcoNet.Abm_Rol;
using PalcoNet.Canje_Puntos;
using PalcoNet.Comprar;
using PalcoNet.Editar_Publicacion;
using PalcoNet.Generar_Publicacion;
using PalcoNet.Generar_Rendicion_Comisiones;
using PalcoNet.Historial_Cliente;
using PalcoNet.Listado_Estadistico;
using PalcoNet.Registro_de_Usuario;

namespace PalcoNet.VentanasPorRol
{
	public partial class panelContenedor : Form
	{
		string rolLogueado;
		public Usuario userLog;
		public panelContenedor(Usuario userLogueado)
		{
			userLog = userLogueado;
			//recibir por parametro el objeto del usuario logueado
			//asi puedo ejecutar un SP para encontrar el rol
			//y asi aplicar la funcion que se oculte segun el rol
			InitializeComponent();
			AplicarSeguridad();
		}
		//en el futuro debe recibir un rol
		private void AplicarSeguridad()
		{

			//if (!Usuario.IsAdmin())
			//{

			//btngrabar.Enable = false;

			//cmbproductos.Enable = false;

			//menuStrip1.Items.Remove(menuABMCliente);

			//menuStrip1.Items.Remove(menuABMEmpresa);

			//}


			DataTable dt = new DataTable();
			Funcionalidad funcionalidad = new Funcionalidad();
			dt = funcionalidad.GetFuncionalidadesPorUsuario(this.userLog.Id);
			DataTable dtFuncionalidades = new DataTable();
			DeshabilitarMenu();
			if (dt.Rows.Count > 0)
			{
				foreach (DataRow row in dt.Rows)
				{
					if (row["menu"].ToString() == "menuRegistroUsuario")
					{ menuStrip1.Items.Add(menuRegistroUsuario); }
					if (row["menu"].ToString() == "menuABMCliente")
					{ menuStrip1.Items.Add(menuABMCliente); }
					if (row["menu"].ToString() == "menuABMEmpresa")
					{ menuStrip1.Items.Add(menuABMEmpresa); }
					if (row["menu"].ToString() == "menuPublicacion")
					{ menuStrip1.Items.Add(menuPublicacion); }
					if (row["menu"].ToString() == "menuComprar")
					{ menuStrip1.Items.Add(menuComprar); }
					if (row["menu"].ToString() == "menuCliente")
					{ menuStrip1.Items.Add(menuCliente); }
					if (row["menu"].ToString() == "menuEstadisticas")
					{ menuStrip1.Items.Add(menuEstadisticas); }
					if (row["menu"].ToString() == "menuPagos")
					{ menuStrip1.Items.Add(menuPagos); }
					if (row["menu"].ToString() == "aBMRolToolStripMenuItem")
					{ menuStrip1.Items.Add(aBMRolToolStripMenuItem); }
					if (row["menu"].ToString() == "ABMGradoToolStripMenuItem")
					{ menuStrip1.Items.Add(ABMGradoToolStripMenuItem); }
					
				}
			}
			menuStrip1.Items.Add(salirToolStripMenuItem); 

		}

		private void DeshabilitarMenu()
		{

			menuStrip1.Items.Remove(salirToolStripMenuItem);
			menuStrip1.Items.Remove(menuRegistroUsuario);
			menuStrip1.Items.Remove(menuABMCliente);
			menuStrip1.Items.Remove(menuABMEmpresa);
			menuStrip1.Items.Remove(menuPublicacion);
			menuStrip1.Items.Remove(menuComprar);
			menuStrip1.Items.Remove(menuCliente);
			menuStrip1.Items.Remove(menuEstadisticas);
			menuStrip1.Items.Remove(menuPagos);
			menuStrip1.Items.Remove(aBMRolToolStripMenuItem);
			menuStrip1.Items.Remove(ABMGradoToolStripMenuItem);

		}
		// este es el formulario que se abria desde el menu del formulario MDI
		// Creando variable del formulario que contiene el menú

		//public void checkForm(Form frmHijo, Form frmPadre)
		//{
		//	bool cargado = false;
		//	foreach( Form llamado in frmPadre.MdiChildren)
		//	{
		//		if(llamado.Text == frmPadre.Text)
		//		{
		//			cargado = true;
		//			break;
		//		}
		//	}
		//	if( !cargado)
		//	{
		//		frmHijo.MdiParent = frmPadre;
		//		frmHijo.Show();
		//	}
		//}
		public void AbrirFormInPanel(object formHijo)
		{
			if (this.panel1.Controls.Count > 0)
				this.panel1.Controls.RemoveAt(0);
			Form fh = formHijo as Form;
			fh.TopLevel = false;
			fh.FormBorderStyle = FormBorderStyle.None;
			fh.Dock = DockStyle.Fill;
			this.panel1.Controls.Add(fh);
			this.panel1.Tag = fh;
			fh.Show();
		}
		private void VentanaAdmin_Load(object sender, EventArgs e)
		{
            
		}
		
		private void label3_Click(object sender, EventArgs e)
		{

		}


		private void iconMinimizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		private void iconCerrar_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Seguro que desea Cerrar Sesion?", "Alerta", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.Hide();
				Login login = new Login();
				login.Show();
			}
			else
			{
				//tus codigos
			}
		}

		private void altaUsuario_Click(object sender, EventArgs e)
		{
			UsuarioAlta altaUser = new UsuarioAlta();
			altaUser.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(altaUser);
			//altaUser.Show(this);
			//checkForm(altaUser, this);
			//this.Hide();
		}
		private void altaCliente_Click(object sender, EventArgs e)
		{
			AltaCliente altaC = new AltaCliente("admin");
			altaC.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(altaC);
			//altaC.Show();
			//checkForm(altaC, this);
			//this.Hide();
		}
		public void mostrarlogoAlCerrarForm(object sender, FormClosedEventArgs e)
		{
			mostrarlogo();
		}
		private void mostrarlogo()
		{
			AbrirFormInPanel(new FormLogo());
		}

		private void bajaCliente_Click(object sender, EventArgs e)
		{
			EliminarCliente eliminarC = new EliminarCliente();
			eliminarC.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(eliminarC);
			//eliminarC.Show();
			//this.Hide();
		}
		private void modificacionCliente_Click(object sender, EventArgs e)
		{
			ModificacionCliente modifC = new ModificacionCliente();
			modifC.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(modifC);
			//modifC.Show();
			//this.Hide();
		}
		private void altaEmpresa_Click(object sender, EventArgs e)
		{
			AltaEmpresa altaEmp = new AltaEmpresa("admin");
			altaEmp.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(altaEmp);
			//altaEmp.Show();
			//this.Hide();
		}
		private void modificacionEmpresa_Click(object sender, EventArgs e)
		{
			ModificacionEmpresa modifEmp = new ModificacionEmpresa();
			modifEmp.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(modifEmp);
			//modifEmp.Show();
			//this.Hide();
		}
		private void bajaEmpresa_Click(object sender, EventArgs e)
		{
			EliminarEmpresa eliminarEmp = new EliminarEmpresa();
			eliminarEmp.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(eliminarEmp);
			//eliminarEmp.Show();
			//this.Hide();
		}
		private void generarPublicacion_Click(object sender, EventArgs e)
		{
			GenerarPublicacion generarPubli = new GenerarPublicacion(userLog,this.panel1);
			generarPubli.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(generarPubli);
			//generarPubli.Show();
			//this.Hide();
		}
		private void editarPublicacion_Click(object sender, EventArgs e)
		{
			//editPublic.Show();
			//this.Hide();
			EditarPublicacion editPublic = new EditarPublicacion(userLog);
			editPublic.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(editPublic);
		}
		private void abmCategoria_Click(object sender, EventArgs e)
		{
			//Comprar comp = new Comprar();
			//comp.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			//AbrirFormInPanel(comp);
			//comp.Show();
			//MessageBox.Show("You are selected Comprar ");
			//this.Hide();
		}
		private void abmGradoPublicacion_Click(object sender, EventArgs e)
		{
			//Comprar comp = new Comprar();
			//comp.Show();
			//comp.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			//AbrirFormInPanel(comp);
			//MessageBox.Show("You are selected Comprar ");
			//this.Hide();
		}
		private void cambiarEstadoPublicacion_Click(object sender, EventArgs e)
		{
			CambiarEstadoPublicacion cambiarEstado = new CambiarEstadoPublicacion(userLog);
			cambiarEstado.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(cambiarEstado);
			//MessageBox.Show("You are selected Comprar ");
			//this.Hide();
		}
		private void comprar_Click(object sender, EventArgs e)
		{
            ComprarPPAL compra = new ComprarPPAL(userLog);
            compra.Show();
            AbrirFormInPanel(compra);
            //Comprar comp = new Comprar();
            //comp.Show();
            //MessageBox.Show("You are selected Comprar ");
            //this.Hide();
		}
		private void historialCliente_Click(object sender, EventArgs e)
		{
			HistorialCliente histCli = new HistorialCliente(userLog);
			histCli.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(histCli);
			//histCli.Show();
			//this.Hide();
		}
		private void canjePuntos_Click(object sender, EventArgs e)
		{
			CanjePuntos canje = new CanjePuntos(userLog);
			canje.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
				AbrirFormInPanel(canje);
			//	//canje.Show();
			//	//this.Hide();
		}
		private void generarPago_Click(object sender, EventArgs e)
		{
			GenerarRendicionComisiones rendicion = new GenerarRendicionComisiones(userLog);
			rendicion.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(rendicion);
			//rendicion.Show();
			//this.Hide();
		}
		private void listadoEstadistico_Click(object sender, EventArgs e)
		{
			ListadoEstadistico listadoEst = new ListadoEstadistico();
			listadoEst.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(listadoEst);
			//listadoEst.Show();
			//this.Hide();
		}
		private void cambiarPsw_Click(object sender, EventArgs e)
		{
			UsuarioCambiarPsw cambiarPsw = new UsuarioCambiarPsw(userLog);
			cambiarPsw.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(cambiarPsw);
			//listadoEst.Show();
			//this.Hide();
		}
		private void altaRol_Click(object sender, EventArgs e)
		{
			RolPorFuncionalidad altaRol = new RolPorFuncionalidad();
			altaRol.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(altaRol);
			//rendicion.Show();
			//this.Hide();
		}
		private void bajaRol_Click(object sender, EventArgs e)
		{
			RolEliminar bajaRol = new RolEliminar();
			bajaRol.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(bajaRol);
			//rendicion.Show();
			//this.Hide();
		}
		private void modifRol_Click(object sender, EventArgs e)
		{
			RolPorFuncionalidadesModificar modifRol = new RolPorFuncionalidadesModificar();
			modifRol.FormClosed += new FormClosedEventHandler(mostrarlogoAlCerrarForm);
			AbrirFormInPanel(modifRol);
			//rendicion.Show();
			//this.Hide();
		}
		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void menuRegistroUsuario_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
		private void salirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Close();
		}

		private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
		{

		}
		private void ABMGradoToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void altaGradoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AltaGrado altaGrado = new AltaGrado();
			altaGrado.Show();
			AbrirFormInPanel(altaGrado);

		}

		private void bajaGradoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			BajaGrado bajaGrado = new BajaGrado();
			bajaGrado.Show();
			AbrirFormInPanel(bajaGrado);
		}

		private void modificaciónGradoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ModificarGrado modGrado = new ModificarGrado();
			modGrado.Show();
			AbrirFormInPanel(modGrado);
		}
	}
}

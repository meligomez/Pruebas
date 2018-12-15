using PalcoNet.VentanasPorRol;
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
using Modelo.Servicio;
using Modelo;
using PalcoNet.Abm_Cliente;

using PalcoNet.Registro_de_Usuario;
using PalcoNet.Abm_Empresa_Espectaculo;

namespace PalcoNet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void Login_Load(object sender, EventArgs e)
		{
			Rol rol = new Rol();
			//DataTable dt = rol.ejemplo();
		}

		private void pictureBox1_Click_1(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
			Application.Exit();
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			try
			{
				Usuario usuario = new Usuario();
				usuario.username = textBox1.Text;
				usuario.password = textBox2.Text;
				UsuarioService service = new UsuarioService();
				if (todosCamposCompletos())
				{
					if(service.existeUsername(textBox1.Text))
					{
						int resp = service.login(usuario);
						if (resp == 0)
						{
							Usuario userLogueado = new Usuario();
							ConfigGlobal conf = new ConfigGlobal();
							userLogueado = service.obtenerUsuariosByName(usuario.username);

							//if (userLogueado.ObtenerRol(userLogueado.username) == "Administrador" && userLogueado.cambioPsw == 0)
							if (userLogueado.creadoPor == "admin" && userLogueado.cambioPsw == 0)
							{
								MessageBox.Show("Debe cambiar la contraseña, de lo contrario no podrá acceder a ninguna funcionalidad.", "¡Advertencia!",
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								//userLogueado.fechaCreacionPsw();
								UsuarioCambiarPsw nuevaPsw = new UsuarioCambiarPsw(userLogueado);
								nuevaPsw.Show();
							}
							else
							{

								panelContenedor vgral = new panelContenedor(userLogueado);
								vgral.Show();
								this.Hide();
							}
						}
						else
						{
							if (resp == -1)
							{
								MessageBox.Show("El usuario no existe o no está activo. No se pudo realizar el Login.", "No se pudo realizar el Login",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							else
							{
								if (resp == -2)
								{

									service.PasarAInhabilitado(textBox1.Text);
									MessageBox.Show("Usuario Inhabilitado", "No se pudo realizar el Login",
									MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
								else
								{
									MessageBox.Show("Contraseña Incorrecta. No se pudo realizar el Login.", "No se pudo realizar el Login",
										MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}

						}
					}
					else
					{
						MessageBox.Show("No existe ningun usuario con ese nombre.", "No se pudo realizar el Login",
										MessageBoxButtons.OK, MessageBoxIcon.Error);

					}
					
					

					//this.Close();

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        private bool todosCamposCompletos()
        {
            if (textBox1.Text.Trim() == "")
            {
                //MensajesToolTip.showToolTip("Ingrese un nombre.", textBox1, textBox1.Location);
                MessageBox.Show("Error, valide los datos");
                return false;
            }
            if (textBox2.Text.Trim() == "")
            {
                //MensajesToolTip.showToolTip("Ingrese un nombre.", textBox1, textBox1.Location);
                MessageBox.Show("Error, valide la contraseña");
                return false;
            }
            return true;
        }

		private void RegistrobtnCli_Click(object sender, EventArgs e)
		{
			AltaCliente altaCliente = new AltaCliente("sin Rol");
			altaCliente.Show();
			this.Hide();
		}

        private void registrarBtnEmpresa_Click(object sender, EventArgs e)
        {
			//cambio dani
            AltaEmpresa altaEmpresa = new AltaEmpresa("sin Rol");
            altaEmpresa.Show();
            this.Hide();
        }
	}
}

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

namespace PalcoNet.Abm_Rol
{
    public partial class RolPorFuncionalidad : Form
    {
        public RolPorFuncionalidad()
        {
            InitializeComponent();
        }

		private void cancelarBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DaoSP dao = new DaoSP();
			DataTable roles=dao.ConsultarConQuery("SELECT Id_Funcionalidad,descripcion FROM dropeadores.Funcionalidad");
			CargarData.cargarGridView(dgvFuncionalidades,roles);
			CargarData.AddCheckColumn(dgvFuncionalidades,"Seleccionar");
		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Rol rol = new Rol();
			try
			{
				if(todosCamposCompletos())
				{
					//Valido que el nombre del rol exista
					if (rol.existeRol(txtNombreRol.Text))
					{
						MessageBox.Show("El nombre del rol ya existe, por favor intente con otro.", "Error al crear el Rol",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						RolXFunc rolxfunc = new RolXFunc();
						if (rolxfunc.insertarRolPorFunc(txtNombreRol.Text, dgvFuncionalidades) >= 0)
						{
							MessageBox.Show("Rol creado satisfactoriamente.", "¡Correcto!",
								MessageBoxButtons.OK, MessageBoxIcon.None);
						}
					}
				}

			}
			catch (Exception ex )
			{
				throw ex;
			}
			
		}
		private bool todosCamposCompletos()
		{
			if (txtNombreRol.Text.Trim() == "")
			{
				//MensajesToolTip.showToolTip("Ingrese un nombre.", textBox1, textBox1.Location);
				MessageBox.Show("Error, debe insertar al menos un nombre");
				return false;
			}
			return true;
		}
}
}
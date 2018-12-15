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
	public partial class AsociarTarjeta : Form
	{
		Usuario user = new Usuario();
		public AsociarTarjeta(Usuario usuario)
		{
			InitializeComponent();
			user = usuario;
			comboTipoTarj.Items.Add("DEBITO");
			comboTipoTarj.Items.Add("CREDITO");
		}

		private void AsociarTarjeta_Load(object sender, EventArgs e)
		{

		}

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			Cliente cli = new Cliente();
			Tarjeta tar = new Tarjeta();
			tar.propietario = txtTarjProp.Text;
			tar.numero = txtTarjNum.Text;
			tar.fechaVencimiento = dateTimePickerVenc.Value;
			tar.descripcion = Tarjeta.string_tipo[comboTipoTarj.SelectedIndex];
			cli.numeroDocumento = user.cliente.numeroDocumento;
			cli.Cli_Tar = tar;
			int resp = Cliente.updateTarj(cli);
			if (resp != 0)
			{
				MessageBox.Show("Error!. No se ha creado la tarjeta correctamente.", "Error al actualizar Nueva tajeta",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else
			{
				MessageBox.Show("Tarjeta del cliente " + txtTarjProp.Text + " creado correctamente", "Usuario Creado",
				MessageBoxButtons.OK, MessageBoxIcon.Information);

				this.Hide();
			}
		}
	}
}

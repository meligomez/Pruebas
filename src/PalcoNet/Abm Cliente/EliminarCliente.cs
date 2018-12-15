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

namespace PalcoNet.Abm_Cliente
{
	public partial class EliminarCliente : Form
	{
		public EliminarCliente()
		{
			InitializeComponent();
            foreach (string tipo in Documento.string_docu)
                comboTipoDoc.Items.Add(tipo);
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void EliminarCliente_Load(object sender, EventArgs e)
		{
			cargarTabla();
		}
		private void cargarTabla()
		{

			DaoSP prueba = new DaoSP();

			CargarData.cargarGridView(dataGridCliente, prueba.ConsultarConQuery("SELECT nombre as 'NOMBRE',apellido as 'APELLIDO' ,tipoDocumento as 'tipoDocumento' ,numeroDocumento as 'numeroDocumento' ,mail as 'MAIL', estado as 'ESTADO' from dropeadores.Cliente WHERE estado = 1"));

			CargarData.AddButtonEliminar(dataGridCliente);


		}
		private DataTable FiltrarCliente(string nombre, string apellido, string mail, int tipoDoc, int numDoc)
		{
			DaoSP dao = new DaoSP();
			DataTable tabla_Cliente;
			int docVacio = 0;
			if (numDoc != docVacio)
			{
				tabla_Cliente = dao.ObtenerDatosSP("dropeadores.getCliente", numDoc);
			}
			else
			{
				tabla_Cliente = dao.ObtenerDatosSP("dropeadores.getCliente", docVacio);
			}

			var final_rol = "";
			var posFiltro = true;
			var filtrosBusqueda = new List<string>();
			if (nombre != "") filtrosBusqueda.Add("nombre LIKE '%" + nombre + "%'");
			if (apellido != "") filtrosBusqueda.Add("apellido LIKE '%" + apellido + "%'");
			if (mail != "") filtrosBusqueda.Add("mail LIKE '%" + mail + "%'");
			if (tipoDoc != -1) filtrosBusqueda.Add("tipoDocumento LIKE '%" + comboTipoDoc.Items[tipoDoc] + "%'");
			if (numDoc != 0) filtrosBusqueda.Add("numeroDocumento = " + numDoc);

			foreach (var filtro in filtrosBusqueda)
			{
				if (!posFiltro)
					final_rol += " AND " + filtro;
				else
				{
					final_rol += filtro;
					posFiltro = false;
				}
			}


			if (tabla_Cliente != null)
				tabla_Cliente.DefaultView.RowFilter = final_rol;
			return tabla_Cliente;



		}
		private void botonBuscar_Click(object sender, EventArgs e)
		{
			int documento;
			if (textNroIdentificacion.Text != "")
				documento = Int32.Parse(textNroIdentificacion.Text);
			else
			{
				documento = 0;
			}

			DataTable respuesta = FiltrarCliente(textNombre.Text, textApellido.Text, textEmail.Text, comboTipoDoc.SelectedIndex, documento);
			dataGridCliente.DataSource = respuesta;
			if (dataGridCliente.CurrentRow == null)
			{

				MessageBox.Show("El Cliente requerido no se encuentra.", "Baja de Cliente",
				   MessageBoxButtons.OK);

				cargarTabla();

			}
		}

		private void btCancelar_Click_1(object sender, EventArgs e)
		{
			this.Hide();
		}

        private void dataGridCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (((bool)dataGridCliente.CurrentRow.Cells["estado"].Value) == false)
                {
                    MessageBox.Show("Cliente ya deshabilitado.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string nombre = dataGridCliente.CurrentRow.Cells["nombre"].Value.ToString();
                string apellido = dataGridCliente.CurrentRow.Cells["apellido"].Value.ToString();
                string mail = dataGridCliente.CurrentRow.Cells["mail"].Value.ToString();
                string tipoDoc = dataGridCliente.CurrentRow.Cells["tipoDocumento"].Value.ToString();
                string nroDoc = dataGridCliente.CurrentRow.Cells["numeroDocumento"].Value.ToString();

                DialogResult dr = MessageBox.Show("Desea dar de Baja al cliente " + nombre + " " + apellido + "?",
           "", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        BajaCliente(tipoDoc, nroDoc);
                        MessageBox.Show("Baja cliente realizada exitosamente!.",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;

                    case DialogResult.No:
                        break;
                }

                {
                    cargarTabla();
                    return;
                }
            }

        }

       
      


        private void BajaCliente(string tipoDoc, string nroDoc)
        {

            DaoSP dao = new DaoSP();
            int documento = Int32.Parse(nroDoc);
            int x = dao.EjecutarSP("dropeadores.deleteCliente", tipoDoc, documento);

            updateGrid();
        }
        public void updateGrid()
        {
            botonBuscar_Click(null, null);
        }

        private void comboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboTipoDoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

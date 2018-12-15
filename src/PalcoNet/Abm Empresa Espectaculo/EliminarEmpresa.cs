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

namespace PalcoNet.Abm_Empresa_Espectaculo
{
	public partial class EliminarEmpresa : Form
	{
		public EliminarEmpresa()
		{
			InitializeComponent();
            //limpiar();
		}

    

        private void EliminarEmpresa_Load(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void cargarTabla() {


            DaoSP prueba = new DaoSP();

            CargarData.cargarGridView(dataGridViewEmpresa, prueba.ConsultarConQuery("select empresa_Cuit as 'CUIT',empresa_mail as 'MAIL',empresa_razon_social as 'RAZON SOCIAL',empresa_estado from dropeadores.Empresa WHERE empresa_estado=1"));

            CargarData.AddButtonEliminar(dataGridViewEmpresa);
        

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            DataTable respuesta = FiltrarEmpresa(textRazonSocial.Text, textCUIT.Text, textEmail.Text);
            dataGridViewEmpresa.DataSource = respuesta;
            if (dataGridViewEmpresa.CurrentRow == null)
            {

                MessageBox.Show("La empresa requerida no se encuentra.", "Baja de Empresa",
                   MessageBoxButtons.OK);

                cargarTabla();

            }
            
          
        }

        public void limpiar()
        {
            textRazonSocial.Text = " ";
            textCUIT.Text = " ";
            textEmail.Text = " ";
            cargarTabla();
            //dataGridViewEmpresa.DataSource = null;
            //dataGridViewEmpresa.Update();
            
        }
        private DataTable FiltrarEmpresa(string razonSocial, string cuit, string mail)
        {
            DaoSP dao = new DaoSP();
            DataTable tabla_empresa;
            Empresa emp = new Empresa();
            string cuitVacio = "00-00000000-00";
            if (cuit == "")
                tabla_empresa = dao.ObtenerDatosSP("dropeadores.getEmpresa", cuitVacio);
            else
            {
                tabla_empresa = dao.ObtenerDatosSP("dropeadores.getEmpresa", cuit);
            }
            var final_rol = "";
            var posFiltro = true;
            var filtrosBusqueda = new List<string>();

            if (cuit != "") filtrosBusqueda.Add("CUIT LIKE '%" + cuit + "%'");
            if (razonSocial != "") filtrosBusqueda.Add("'RAZONSOCIAL' LIKE '%" + razonSocial + "%'");
            if (mail != "") filtrosBusqueda.Add("MAIL LIKE '%" + mail + "%'");
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
            int cant = emp.existEmpresa(razonSocial, cuit, mail);

            if (tabla_empresa != null && cant >= 1)
            {

                // error cuando probas por filtrar por 2 campos y alguno es incorrecto
                tabla_empresa.DefaultView.RowFilter = final_rol;
            }
            else
            {
                tabla_empresa = null;
                dataGridViewEmpresa.DataSource = null;
            }
            return tabla_empresa;
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpresa.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una Empresa a dar de baja.",
                "", MessageBoxButtons.OK);
                return;
            }

            if ((bool)dataGridViewEmpresa.CurrentRow.Cells["empresa_estado"].Value)
            {
                MessageBox.Show("Empresa ya deshabilitado.",
                "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show("Baja empresa realizada exitosamente!.",
            "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            cargarTabla();

        }

        private void dataGridViewEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (((bool)dataGridViewEmpresa.CurrentRow.Cells["empresa_estado"].Value) == false)
                {
                    MessageBox.Show("Empresa ya deshabilitado.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string cuitDelete = dataGridViewEmpresa.CurrentRow.Cells["CUIT"].Value.ToString();
                string razonSocial = dataGridViewEmpresa.CurrentRow.Cells["RAZON SOCIAL"].Value.ToString();
                DialogResult dr = MessageBox.Show("Desea dar de Baja a la empresa, cuit " + cuitDelete + " " + razonSocial + "?",
                "", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        BajaEmpresa(cuitDelete);
                        break;

                    case DialogResult.No:
                        break;
                }

                {
                    MessageBox.Show("Baja empresa realizada exitosamente!.",
                "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    limpiar();
                    return;
                }
            }

        }

        private void BajaEmpresa(string cuit)
        {

            DaoSP dao = new DaoSP();

            int x = dao.EjecutarSP("dropeadores.deleteEmpresa", cuit);
            
            //updateGrid();
        }
        public void updateGrid()
        {
            botonBuscar_Click(null, null);
        }

	}
}

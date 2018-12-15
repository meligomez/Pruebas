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
	public partial class ModificacionEmpresa : Form
	{
		public ModificacionEmpresa()
		{
			InitializeComponent();
		}

        private void cargarTabla()
        {


            DaoSP prueba = new DaoSP();

            CargarData.cargarGridView(dataGridViewEmpresa, prueba.ConsultarConQuery("	select empresa_Cuit,empresa_razon_social,empresa_mail,empresa_estado from dropeadores.Empresa E join dropeadores.Domicilio D on (E.empresa_domicilio=D.id)"));



        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpresa.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una empresa a modificar.",
                "", MessageBoxButtons.OK);
                return;
            }
            string cuit = dataGridViewEmpresa.CurrentRow.Cells["CUIT"].Value.ToString();
            DialogResult dr = MessageBox.Show("Desea modificar datos de la empresa?", "", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:

                    ModificarEmpresaSeleccionada(cuit);
                    break;
                case DialogResult.No: break;
            }
        }

        private void ModificarEmpresaSeleccionada(string cuit)
        {
            this.Hide();
            new ModificarEmpresaElegida(cuit).Show();
            
        }

        private void dataGridViewEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ModificacionEmpresa_Load(object sender, EventArgs e)
        {
            DaoSP prueba = new DaoSP();

            CargarData.cargarGridView(dataGridViewEmpresa, prueba.ConsultarConQuery("select empresa_Cuit,empresa_razon_social,empresa_mail,empresa_estado from dropeadores.Empresa E join dropeadores.Domicilio D on (E.empresa_domicilio=D.id)"));
           
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

            if (cuit != "") filtrosBusqueda.Add("CUITE LIKE '%" + cuit + "%'");
            if (razonSocial != "") filtrosBusqueda.Add("RAZONSOCIAL LIKE '%" + razonSocial + "%'");
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
	}
}

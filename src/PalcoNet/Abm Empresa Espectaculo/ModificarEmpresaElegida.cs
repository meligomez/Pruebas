using Modelo.Base;
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
	public partial class ModificarEmpresaElegida : Form
	{
        Empresa empresa_Seleccionada;
        
		public ModificarEmpresaElegida(string cuit)
		{
			InitializeComponent();
            DaoSP dao = new DaoSP();
            empresa_Seleccionada = obtener(cuit);
            if (empresa_Seleccionada == null)
            {
                MessageBox.Show("Error al cargar el cliente.", "Error al Modificar Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
		}


        private void cargarDatos()
        {  //empresa_Seleccionada.Empresa_estado = true;
            textRazonSocial.Text = empresa_Seleccionada.Empresa_razon_social;
            textCUIT.Text = empresa_Seleccionada.Empresa_Cuit;
            textTelefono.Text = empresa_Seleccionada.Empresa_telefono.ToString();
            textMail.Text = empresa_Seleccionada.Empresa_mail;
            textCiudad.Text = empresa_Seleccionada.Empresa_Dom.ciudad;
            textDireccion.Text = empresa_Seleccionada.Empresa_Dom.calle;
            txtNro.Text = empresa_Seleccionada.Empresa_Dom.numero.ToString();
            textLocalidad.Text = empresa_Seleccionada.Empresa_Dom.localidad;
            textPiso.Text = empresa_Seleccionada.Empresa_Dom.piso.ToString();
            textDepto.Text = empresa_Seleccionada.Empresa_Dom.dpto.ToString();
            textCP.Text = empresa_Seleccionada.Empresa_Dom.cp.ToString();

            checkBaja.Checked = empresa_Seleccionada.Empresa_estado;
            if (empresa_Seleccionada.Empresa_Dom.calle != "''")
                textDepto.Text = empresa_Seleccionada.Empresa_Dom.dpto.ToString();
            if (empresa_Seleccionada.Empresa_Dom.piso != -1)
                textPiso.Text = empresa_Seleccionada.Empresa_Dom.piso.ToString();
        }

        private void limpiar()
        {
            textRazonSocial.Text = "";
            textCUIT.Text = "";
            textTelefono.Text="";
            textMail.Text = "";
            textCiudad.Text = "";
            textDireccion.Text = "";
            txtNro.Text = "";
            textLocalidad.Text = "";
            textPiso.Text = "";
            textDepto.Text = "";
            textCP.Text = "";
           
        }

        public static DataTable obtenerTabla(string cuit)
        {


            DaoSP dao = new DaoSP();
            return dao.ObtenerDatosSP("dropeadores.ObtenerEmpresaEspecifica", cuit);
        }

        public static Empresa obtener(string cuit)
        {
            List<Empresa> lista = transductor(obtenerTabla(cuit));
            if (lista.Count == 0)
                return null;
            return lista[0];
        }
        public static List<Empresa> transductor(DataTable tabla)
        {
            List<Empresa> lista = new List<Empresa>();
            foreach (DataRow fila in tabla.Rows)
            {
                Domicilio dom = new Domicilio();
                Empresa empresa = new Empresa();
                empresa.Empresa_Cuit = Convert.ToString(fila["empresa_Cuit"]);
                empresa.Empresa_razon_social = Convert.ToString(fila["empresa_razon_social"]);
                empresa.Empresa_estado = Convert.ToBoolean(fila["empresa_estado"]);
                dom.calle = Convert.ToString(fila["calle"]);
                dom.numero = Convert.ToInt32(fila["numero"]);
                dom.piso = Convert.ToInt32(fila["piso"]);
                dom.dpto = Convert.ToString(fila["departamento"]);
                dom.localidad = Convert.ToString(fila["localidad"]);
                dom.cp = Convert.ToInt32(fila["codigoPostal"]);
                dom.ciudad = Convert.ToString(fila["ciudad"]);

                empresa.Empresa_Dom = dom;
                //Campos Nulleables  (CHECKEAR)
                if (!(fila["empresa_telefono"] is DBNull))
                    empresa.Empresa_telefono = Convert.ToInt32(fila["empresa_telefono"]);
                if (!(fila["empresa_mail"] is DBNull))
                    empresa.Empresa_mail = Convert.ToString(fila["empresa_mail"]);
                //if (!(fila["empresa_razon_social"] is DBNull))
                //if (!(fila["direccionDepto"] is DBNull))
                // empresa.Direccion.calle_dpto = Convert.ToString(fila["direccionDepto"]);

                lista.Add(empresa);
            }
            return lista;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (true)
            {
                empresa_Seleccionada.Empresa_razon_social = textRazonSocial.Text;
                empresa_Seleccionada.Empresa_Cuit = textCUIT.Text;
                empresa_Seleccionada.Empresa_telefono = Int32.Parse(textTelefono.Text);
                empresa_Seleccionada.Empresa_mail = textMail.Text;
                empresa_Seleccionada.Empresa_Dom.ciudad = textCiudad.Text;
                empresa_Seleccionada.Empresa_Dom.calle = textDireccion.Text;
                empresa_Seleccionada.Empresa_Dom.numero = Int32.Parse(txtNro.Text);
                empresa_Seleccionada.Empresa_Dom.localidad = textLocalidad.Text;
                empresa_Seleccionada.Empresa_Dom.piso = Int32.Parse(textPiso.Text);
                empresa_Seleccionada.Empresa_Dom.dpto = textDepto.Text;
                empresa_Seleccionada.Empresa_Dom.cp = Int32.Parse(textCP.Text);

                if (textPiso.Text != "")
                    empresa_Seleccionada.Empresa_Dom.piso = Int32.Parse(textPiso.Text);
                if (textDepto.Text != "")
                    empresa_Seleccionada.Empresa_Dom.dpto = textDepto.Text;

                if (checkBaja.Checked)
                {
                    empresa_Seleccionada.Empresa_estado = checkBaja.Checked;
                }

                if (!Empresa.actualizar(empresa_Seleccionada))
                {
                    MessageBox.Show("Error al modificar la empresa.", "Error al Modificar empresa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Empresa Modificada Correctamente.", "Modificar empresa",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
                    ModificacionEmpresa empMod = new ModificacionEmpresa();
                    empMod.Show();
                    this.Hide();
                }
            }
        }

        private void ModificarEmpresaElegida_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void checkBaja_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
           // ModificacionEmpresa modEmp = new ModificacionEmpresa();
           // modEmp.Show();
            this.Hide();
        }
	}
}

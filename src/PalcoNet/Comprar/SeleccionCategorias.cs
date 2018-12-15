using Modelo.Base;
using Modelo.Comun;
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
    public partial class SeleccionCategorias : Form
    {
        ComprarPPAL compras;
        String categorias;
        List<String> lista = new List<string>();

        public SeleccionCategorias(String categoriasSelecionadas, ComprarPPAL comprar)
        {
            InitializeComponent();
            categorias = categoriasSelecionadas;
            compras = comprar;
        
        }
        private void cargarTabla()
        {
            DaoSP prueba = new DaoSP();
            CargarData.cargarGridView(dataGridViewCategoria, prueba.ConsultarConQuery("select rubro_Descripcion as 'CATEGORÍAS' from dropeadores.Rubro order by descripcion asc"));
        }
        private void SeleccionCategorias_Load(object sender, EventArgs e)
        {
            DaoSP X = new DaoSP();
            DataTable cat = X.ConsultarConQuery("select rubro_Descripcion as 'CATEGORÍAS' from dropeadores.Rubro order by rubro_Descripcion asc");
            configuracionGrilla(cat);

        }
        private void configuracionGrilla(DataTable dt)
        {
            dataGridViewCategoria.DataSource = dt;

            labelCategorias.Text += categorias;
            return;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewCategoria.CurrentCell.RowIndex;
            int columnindex = dataGridViewCategoria.CurrentCell.ColumnIndex;
            labelCategorias.Text = "";

            if (!labelCategorias.Text.Contains(dataGridViewCategoria.Rows[rowindex].Cells[columnindex].Value.ToString()))
            {
                lista.Add(dataGridViewCategoria.Rows[rowindex].Cells[columnindex].Value.ToString());
                for (int i = 0; i < lista.Count(); i++)
                {

                    labelCategorias.Text += lista[i] + " ";

                }
            }
            //Elimina las categorías de la lista
            dataGridViewCategoria.Rows.RemoveAt(rowindex);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            compras.CompletarCategoríasSeleccionadas(lista);
            this.Close();
        }

        private void labelCategorias_Click(object sender, EventArgs e)
        {

        }

		private void button1_Click_1(object sender, EventArgs e)
		{
			int rowindex = dataGridViewCategoria.CurrentCell.RowIndex;
			int columnindex = dataGridViewCategoria.CurrentCell.ColumnIndex;
			labelCategorias.Text = "";

			if (!labelCategorias.Text.Contains(dataGridViewCategoria.Rows[rowindex].Cells[columnindex].Value.ToString()))
			{
				lista.Add(dataGridViewCategoria.Rows[rowindex].Cells[columnindex].Value.ToString());
				for (int i = 0; i < lista.Count(); i++)
				{

					labelCategorias.Text += lista[i] + " ";

				}
			}
			//Elimina las categorías de la lista
			dataGridViewCategoria.Rows.RemoveAt(rowindex);
		}

		private void btnBuscar_Click_1(object sender, EventArgs e)
		{
			compras.CompletarCategoríasSeleccionadas(lista);
			this.Close();
		}
	}
}

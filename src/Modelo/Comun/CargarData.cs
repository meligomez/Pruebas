using Modelo.Base;
using Modelo.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modelo.Comun
{
	public class CargarData
	{
		/// <summary>
		/// ////
		/// </summary>
		/// <param name="combo"></param>
		/// <param name="opciones"></param>

		public static void cargarComboBox(ComboBox combo, List<Object> opciones, string _ValueMember, string _DisplayMember)
		{
			try
			{
				//Vaciar comboBox
				combo.DataSource = null;
				combo.ValueMember = _ValueMember;
				combo.DisplayMember = _DisplayMember;
				foreach (Object opcion in opciones)
				{
					combo.Items.Add(opcion);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		public static void cargarComboBox(ComboBox combo, DataTable opciones,
											string _ValueMember, string _DisplayMember)
		{
			try
			{
				//Vaciar comboBox
				combo.DataSource = null;
				DataRow newRow = opciones.NewRow();
				newRow[_ValueMember] = "0";
				newRow[_DisplayMember] = "Seleccione una opcion";
				opciones.Rows.Add(newRow);
				combo.ValueMember = _ValueMember;
				combo.DisplayMember = _DisplayMember;
				opciones.DefaultView.Sort = _ValueMember;
				combo.DataSource = opciones;
				//combo.;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
		public static void cargarGridView(DataGridView dataGrid, List<Rol> lista)
		{
			try
			{
				dataGrid.Columns.Clear();
				dataGrid.DataSource = null;
				dataGrid.DataSource = lista;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static void cargarGridView(DataGridView dataGrid, DataTable tabla)
		{
			try
			{
				dataGrid.Columns.Clear();
				dataGrid.DataSource = null;
				dataGrid.DataSource = tabla;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public static void AddCheckColumn(DataGridView dataGrid, string nombreColumna)
		{
			//Asignar la propiedad DataSource
			DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
			dataGrid.Columns.Add(chkbox);
			chkbox.HeaderText = nombreColumna;
			chkbox.Name = "seleccion";
		}
		public static void AddButtonEditColumn(DataGridView dataGrid)
		{
			DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
			btnEditar.HeaderText = "Seleccionar";
			btnEditar.Name = "Editar";
			btnEditar.Text = "Editar";
			btnEditar.UseColumnTextForButtonValue = true;
			//btnEditar.CellTemplate.Style.BackColor = Color.DarkGreen;
			dataGrid.Columns.Add(btnEditar);
			//btnEditar.DisplayIndex = 0;
	    }
		public static void AddButtonDeleteColumn(DataGridView dataGrid)
		{
			//------------Agrego el boton para eliminar un rol --------
			DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
			btnEliminar.HeaderText = "Seleccionar";
			btnEliminar.Name = "Eliminar";
			btnEliminar.Text = "Eliminar";
			btnEliminar.UseColumnTextForButtonValue = true;
			//btnEliminar.CellTemplate.Style.BackColor = Color.Red;
			dataGrid.Columns.Add(btnEliminar);
			//btnEliminar.DisplayIndex = 1;
		}

		//Esto lo agrego DANIELA 


		public static void AddButtonEliminar(DataGridView dataGrid)
        {
         
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Seleccionar";
            btnEliminar.Name = "Eliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGrid.Columns.Add(btnEliminar);
            btnEliminar.DisplayIndex = 0;
        }
		public static void AddButtonSeleccionar(DataGridView dataGrid)
		{

			DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
			btnSeleccionar.HeaderText = "Seleccionar";
			btnSeleccionar.Name = "Seleccionar";
			btnSeleccionar.Text = "Seleccionar";
			btnSeleccionar.UseColumnTextForButtonValue = true;
			dataGrid.Columns.Add(btnSeleccionar);
			btnSeleccionar.DisplayIndex = 0;
		}
	}
}

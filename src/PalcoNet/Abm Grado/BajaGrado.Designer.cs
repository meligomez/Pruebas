namespace PalcoNet.Abm_Grado
{
	partial class BajaGrado
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.botonBuscar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.dataGridGrado = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridGrado)).BeginInit();
			this.SuspendLayout();
			// 
			// txtTipo
			// 
			this.txtTipo.Location = new System.Drawing.Point(230, 77);
			this.txtTipo.Margin = new System.Windows.Forms.Padding(4);
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(106, 22);
			this.txtTipo.TabIndex = 97;
			// 
			// botonBuscar
			// 
			this.botonBuscar.Location = new System.Drawing.Point(457, 72);
			this.botonBuscar.Name = "botonBuscar";
			this.botonBuscar.Size = new System.Drawing.Size(120, 29);
			this.botonBuscar.TabIndex = 96;
			this.botonBuscar.Text = "Buscar";
			this.botonBuscar.UseVisualStyleBackColor = true;
			this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label3.Location = new System.Drawing.Point(160, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 25);
			this.label3.TabIndex = 95;
			this.label3.Text = "Tipo:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(217, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(275, 36);
			this.label7.TabIndex = 94;
			this.label7.Text = "ELIMINAR GRADO";
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(633, 376);
			this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(136, 43);
			this.btnEliminar.TabIndex = 100;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Location = new System.Drawing.Point(77, 373);
			this.btCancelar.Margin = new System.Windows.Forms.Padding(4);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(136, 46);
			this.btCancelar.TabIndex = 99;
			this.btCancelar.Text = "Cancelar";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// dataGridGrado
			// 
			this.dataGridGrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridGrado.Location = new System.Drawing.Point(60, 127);
			this.dataGridGrado.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridGrado.Name = "dataGridGrado";
			this.dataGridGrado.Size = new System.Drawing.Size(709, 233);
			this.dataGridGrado.TabIndex = 98;
			// 
			// BajaGrado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.dataGridGrado);
			this.Controls.Add(this.txtTipo);
			this.Controls.Add(this.botonBuscar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label7);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "BajaGrado";
			this.Text = "BajaGrado";
			this.Load += new System.EventHandler(this.BajaGrado_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridGrado)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Button botonBuscar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.DataGridView dataGridGrado;
	}
}
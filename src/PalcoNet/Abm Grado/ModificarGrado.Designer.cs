namespace PalcoNet.Abm_Grado
{
	partial class ModificarGrado
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
			this.label7 = new System.Windows.Forms.Label();
			this.btnModificar = new System.Windows.Forms.Button();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.btCancelar = new System.Windows.Forms.Button();
			this.botonBuscar = new System.Windows.Forms.Button();
			this.dataGridGrado = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridGrado)).BeginInit();
			this.SuspendLayout();
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(273, 26);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(254, 36);
			this.label7.TabIndex = 109;
			this.label7.Text = "Modificar GRADO";
			// 
			// btnModificar
			// 
			this.btnModificar.Location = new System.Drawing.Point(552, 379);
			this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(136, 43);
			this.btnModificar.TabIndex = 108;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
			// 
			// txtTipo
			// 
			this.txtTipo.Location = new System.Drawing.Point(325, 82);
			this.txtTipo.Margin = new System.Windows.Forms.Padding(4);
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(106, 22);
			this.txtTipo.TabIndex = 107;
			// 
			// btCancelar
			// 
			this.btCancelar.Location = new System.Drawing.Point(63, 379);
			this.btCancelar.Margin = new System.Windows.Forms.Padding(4);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(136, 46);
			this.btCancelar.TabIndex = 106;
			this.btCancelar.Text = "Cancelar";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// botonBuscar
			// 
			this.botonBuscar.Location = new System.Drawing.Point(552, 77);
			this.botonBuscar.Name = "botonBuscar";
			this.botonBuscar.Size = new System.Drawing.Size(120, 29);
			this.botonBuscar.TabIndex = 105;
			this.botonBuscar.Text = "Buscar";
			this.botonBuscar.UseVisualStyleBackColor = true;
			this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
			// 
			// dataGridGrado
			// 
			this.dataGridGrado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridGrado.Location = new System.Drawing.Point(46, 133);
			this.dataGridGrado.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridGrado.Name = "dataGridGrado";
			this.dataGridGrado.Size = new System.Drawing.Size(709, 233);
			this.dataGridGrado.TabIndex = 104;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.label3.Location = new System.Drawing.Point(255, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 25);
			this.label3.TabIndex = 103;
			this.label3.Text = "Tipo:";
			// 
			// ModificarGrado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(810, 499);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.txtTipo);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.botonBuscar);
			this.Controls.Add(this.dataGridGrado);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ModificarGrado";
			this.Text = "ModificarGrado";
			this.Load += new System.EventHandler(this.ModificarGrado_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridGrado)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button botonBuscar;
		private System.Windows.Forms.DataGridView dataGridGrado;
		private System.Windows.Forms.Label label3;
	}
}
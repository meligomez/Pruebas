namespace PalcoNet.Comprar
{
    partial class Comprar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comprar));
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textDescripcion = new System.Windows.Forms.TextBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnNuevoMedioPago = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblImporte = new System.Windows.Forms.Label();
			this.lblPuntos = new System.Windows.Forms.Label();
			this.btnComprar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
			this.pictureBox3.Location = new System.Drawing.Point(30, 28);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(65, 66);
			this.pictureBox3.TabIndex = 89;
			this.pictureBox3.TabStop = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(99, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(164, 35);
			this.label7.TabIndex = 88;
			this.label7.Text = "COMPRAR";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.dateTimePickerHasta);
			this.groupBox1.Controls.Add(this.dateTimePickerDesde);
			this.groupBox1.Controls.Add(this.textDescripcion);
			this.groupBox1.Controls.Add(this.btnBuscar);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 100);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(918, 135);
			this.groupBox1.TabIndex = 90;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos de la Publicacion";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// textDescripcion
			// 
			this.textDescripcion.Location = new System.Drawing.Point(155, 77);
			this.textDescripcion.Name = "textDescripcion";
			this.textDescripcion.Size = new System.Drawing.Size(448, 31);
			this.textDescripcion.TabIndex = 5;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Location = new System.Drawing.Point(809, 33);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(99, 35);
			this.btnBuscar.TabIndex = 4;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(521, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 24);
			this.label4.TabIndex = 3;
			this.label4.Text = "Desde";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(30, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Descripcion";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Categoria";
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 260);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(908, 236);
			this.dataGridView1.TabIndex = 91;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 526);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(286, 24);
			this.label2.TabIndex = 92;
			this.label2.Text = "Seleccione un medio de Pago";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(300, 526);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(185, 32);
			this.comboBox1.TabIndex = 93;
			// 
			// btnNuevoMedioPago
			// 
			this.btnNuevoMedioPago.Location = new System.Drawing.Point(105, 583);
			this.btnNuevoMedioPago.Name = "btnNuevoMedioPago";
			this.btnNuevoMedioPago.Size = new System.Drawing.Size(290, 42);
			this.btnNuevoMedioPago.TabIndex = 94;
			this.btnNuevoMedioPago.Text = "Asociar Medio de Pago";
			this.btnNuevoMedioPago.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(528, 519);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 24);
			this.label5.TabIndex = 95;
			this.label5.Text = "Importe total:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(448, 583);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(214, 24);
			this.label6.TabIndex = 96;
			this.label6.Text = "Puntos para el cliente:";
			// 
			// lblImporte
			// 
			this.lblImporte.AutoSize = true;
			this.lblImporte.Location = new System.Drawing.Point(668, 519);
			this.lblImporte.Name = "lblImporte";
			this.lblImporte.Size = new System.Drawing.Size(269, 24);
			this.lblImporte.TabIndex = 97;
			this.lblImporte.Text = "suma de importes(readonly)";
			// 
			// lblPuntos
			// 
			this.lblPuntos.AutoSize = true;
			this.lblPuntos.Location = new System.Drawing.Point(668, 583);
			this.lblPuntos.Name = "lblPuntos";
			this.lblPuntos.Size = new System.Drawing.Size(252, 24);
			this.lblPuntos.TabIndex = 98;
			this.lblPuntos.Text = "suma de puntos(readonly)";
			// 
			// btnComprar
			// 
			this.btnComprar.Location = new System.Drawing.Point(1072, 809);
			this.btnComprar.Margin = new System.Windows.Forms.Padding(4);
			this.btnComprar.Name = "btnComprar";
			this.btnComprar.Size = new System.Drawing.Size(136, 43);
			this.btnComprar.TabIndex = 76;
			this.btnComprar.Text = "Comprar";
			this.btnComprar.UseVisualStyleBackColor = true;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(25, 661);
			this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(136, 43);
			this.btnCancelar.TabIndex = 75;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			// 
			// dateTimePickerHasta
			// 
			this.dateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerHasta.Location = new System.Drawing.Point(685, 75);
			this.dateTimePickerHasta.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePickerHasta.Name = "dateTimePickerHasta";
			this.dateTimePickerHasta.Size = new System.Drawing.Size(189, 31);
			this.dateTimePickerHasta.TabIndex = 94;
			// 
			// dateTimePickerDesde
			// 
			this.dateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerDesde.Location = new System.Drawing.Point(598, 32);
			this.dateTimePickerDesde.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePickerDesde.Name = "dateTimePickerDesde";
			this.dateTimePickerDesde.Size = new System.Drawing.Size(189, 31);
			this.dateTimePickerDesde.TabIndex = 93;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(608, 80);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 24);
			this.label8.TabIndex = 95;
			this.label8.Text = "Hasta";
			// 
			// Comprar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(944, 715);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnComprar);
			this.Controls.Add(this.lblPuntos);
			this.Controls.Add(this.lblImporte);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnNuevoMedioPago);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.label7);
			this.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Comprar";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Comprar_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button btnNuevoMedioPago;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblImporte;
		private System.Windows.Forms.Label lblPuntos;
		private System.Windows.Forms.TextBox textDescripcion;
		private System.Windows.Forms.Button btnComprar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
		private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
	}
}
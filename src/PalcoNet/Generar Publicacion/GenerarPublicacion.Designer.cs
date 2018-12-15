namespace PalcoNet.Generar_Publicacion
{
	partial class GenerarPublicacion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarPublicacion));
			this.lblUserLogueado = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblTextLote = new System.Windows.Forms.Label();
			this.radioSi = new System.Windows.Forms.RadioButton();
			this.radioNo = new System.Windows.Forms.RadioButton();
			this.lblEstado = new System.Windows.Forms.Label();
			this.comboGradoPublicacion = new System.Windows.Forms.ComboBox();
			this.comboRubro = new System.Windows.Forms.ComboBox();
			this.textDireccion = new System.Windows.Forms.TextBox();
			this.textDescripcion = new System.Windows.Forms.TextBox();
			this.dateTimePickerEspectaculo = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerPublicacion = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.lblFechaEspectaculo = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnVolver = new System.Windows.Forms.Button();
			this.btnSiguiente = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSubirTxt = new System.Windows.Forms.Button();
			this.textStock = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblUserLogueado
			// 
			this.lblUserLogueado.AutoSize = true;
			this.lblUserLogueado.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUserLogueado.Location = new System.Drawing.Point(402, 119);
			this.lblUserLogueado.Name = "lblUserLogueado";
			this.lblUserLogueado.Size = new System.Drawing.Size(0, 24);
			this.lblUserLogueado.TabIndex = 97;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblTextLote);
			this.groupBox1.Controls.Add(this.radioSi);
			this.groupBox1.Controls.Add(this.radioNo);
			this.groupBox1.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(46, 436);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(537, 91);
			this.groupBox1.TabIndex = 96;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Forma de exposicion de la fecha del espectaculo";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// lblTextLote
			// 
			this.lblTextLote.AutoSize = true;
			this.lblTextLote.Location = new System.Drawing.Point(11, 31);
			this.lblTextLote.Name = "lblTextLote";
			this.lblTextLote.Size = new System.Drawing.Size(274, 24);
			this.lblTextLote.TabIndex = 68;
			this.lblTextLote.Text = "La fecha será dada por lote?";
			// 
			// radioSi
			// 
			this.radioSi.AutoSize = true;
			this.radioSi.Location = new System.Drawing.Point(297, 29);
			this.radioSi.Name = "radioSi";
			this.radioSi.Size = new System.Drawing.Size(47, 28);
			this.radioSi.TabIndex = 69;
			this.radioSi.TabStop = true;
			this.radioSi.Text = "Si";
			this.radioSi.UseVisualStyleBackColor = true;
			this.radioSi.CheckedChanged += new System.EventHandler(this.changeRadioButton);
			// 
			// radioNo
			// 
			this.radioNo.AutoSize = true;
			this.radioNo.Location = new System.Drawing.Point(297, 59);
			this.radioNo.Name = "radioNo";
			this.radioNo.Size = new System.Drawing.Size(58, 28);
			this.radioNo.TabIndex = 70;
			this.radioNo.TabStop = true;
			this.radioNo.Text = "No";
			this.radioNo.UseVisualStyleBackColor = true;
			this.radioNo.CheckedChanged += new System.EventHandler(this.changeRadioButton);
			// 
			// lblEstado
			// 
			this.lblEstado.AutoSize = true;
			this.lblEstado.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEstado.Location = new System.Drawing.Point(126, 156);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(0, 24);
			this.lblEstado.TabIndex = 95;
			// 
			// comboGradoPublicacion
			// 
			this.comboGradoPublicacion.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboGradoPublicacion.FormattingEnabled = true;
			this.comboGradoPublicacion.Location = new System.Drawing.Point(220, 313);
			this.comboGradoPublicacion.Name = "comboGradoPublicacion";
			this.comboGradoPublicacion.Size = new System.Drawing.Size(172, 32);
			this.comboGradoPublicacion.TabIndex = 92;
			// 
			// comboRubro
			// 
			this.comboRubro.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboRubro.FormattingEnabled = true;
			this.comboRubro.Location = new System.Drawing.Point(121, 262);
			this.comboRubro.Name = "comboRubro";
			this.comboRubro.Size = new System.Drawing.Size(172, 32);
			this.comboRubro.TabIndex = 91;
			this.comboRubro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cuandoCambia);
			// 
			// textDireccion
			// 
			this.textDireccion.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textDireccion.Location = new System.Drawing.Point(141, 224);
			this.textDireccion.Name = "textDireccion";
			this.textDireccion.Size = new System.Drawing.Size(261, 31);
			this.textDireccion.TabIndex = 90;
			// 
			// textDescripcion
			// 
			this.textDescripcion.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textDescripcion.Location = new System.Drawing.Point(166, 186);
			this.textDescripcion.Name = "textDescripcion";
			this.textDescripcion.Size = new System.Drawing.Size(236, 31);
			this.textDescripcion.TabIndex = 89;
			// 
			// dateTimePickerEspectaculo
			// 
			this.dateTimePickerEspectaculo.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerEspectaculo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerEspectaculo.Location = new System.Drawing.Point(288, 465);
			this.dateTimePickerEspectaculo.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePickerEspectaculo.Name = "dateTimePickerEspectaculo";
			this.dateTimePickerEspectaculo.Size = new System.Drawing.Size(263, 31);
			this.dateTimePickerEspectaculo.TabIndex = 88;
			this.dateTimePickerEspectaculo.Visible = false;
			// 
			// dateTimePickerPublicacion
			// 
			this.dateTimePickerPublicacion.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePickerPublicacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerPublicacion.Location = new System.Drawing.Point(255, 398);
			this.dateTimePickerPublicacion.Margin = new System.Windows.Forms.Padding(4);
			this.dateTimePickerPublicacion.Name = "dateTimePickerPublicacion";
			this.dateTimePickerPublicacion.Size = new System.Drawing.Size(189, 31);
			this.dateTimePickerPublicacion.TabIndex = 87;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(36, 119);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(366, 24);
			this.label12.TabIndex = 86;
			this.label12.Text = "Usuario responsable de la publicación:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(45, 316);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(181, 24);
			this.label11.TabIndex = 85;
			this.label11.Text = "Grado publicación:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(42, 227);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(101, 24);
			this.label10.TabIndex = 84;
			this.label10.Text = "Direccion:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(45, 266);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(70, 24);
			this.label9.TabIndex = 83;
			this.label9.Text = "Rubro:";
			// 
			// lblFechaEspectaculo
			// 
			this.lblFechaEspectaculo.AutoSize = true;
			this.lblFechaEspectaculo.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFechaEspectaculo.Location = new System.Drawing.Point(45, 470);
			this.lblFechaEspectaculo.Name = "lblFechaEspectaculo";
			this.lblFechaEspectaculo.Size = new System.Drawing.Size(289, 24);
			this.lblFechaEspectaculo.TabIndex = 81;
			this.lblFechaEspectaculo.Text = "Fecha y Hora del Espectaculo:";
			this.lblFechaEspectaculo.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(45, 402);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(212, 24);
			this.label6.TabIndex = 80;
			this.label6.Text = "Fecha de Publicacion:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(42, 192);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(123, 24);
			this.label4.TabIndex = 78;
			this.label4.Text = "Descripcion:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(42, 156);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 24);
			this.label2.TabIndex = 77;
			this.label2.Text = "Estado:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(19, 31);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(68, 59);
			this.pictureBox1.TabIndex = 100;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(103, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(366, 35);
			this.label1.TabIndex = 99;
			this.label1.Text = "GENERAR PUBLICACION";
			// 
			// btnVolver
			// 
			this.btnVolver.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnVolver.Location = new System.Drawing.Point(25, 593);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(121, 36);
			this.btnVolver.TabIndex = 102;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// btnSiguiente
			// 
			this.btnSiguiente.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSiguiente.Location = new System.Drawing.Point(502, 593);
			this.btnSiguiente.Name = "btnSiguiente";
			this.btnSiguiente.Size = new System.Drawing.Size(121, 36);
			this.btnSiguiente.TabIndex = 101;
			this.btnSiguiente.Text = "Siguiente";
			this.btnSiguiente.UseVisualStyleBackColor = true;
			this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(45, 364);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(67, 24);
			this.label17.TabIndex = 103;
			this.label17.Text = "Stock:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(227, 366);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(298, 22);
			this.label3.TabIndex = 105;
			this.label3.Text = "*El Stock debe ser Múltiplo de 10";
			// 
			// btnSubirTxt
			// 
			this.btnSubirTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.btnSubirTxt.Location = new System.Drawing.Point(49, 455);
			this.btnSubirTxt.Margin = new System.Windows.Forms.Padding(4);
			this.btnSubirTxt.Name = "btnSubirTxt";
			this.btnSubirTxt.Size = new System.Drawing.Size(181, 38);
			this.btnSubirTxt.TabIndex = 111;
			this.btnSubirTxt.Text = "Subir Txt";
			this.btnSubirTxt.UseVisualStyleBackColor = true;
			this.btnSubirTxt.Click += new System.EventHandler(this.btnSubirTxt_Click);
			// 
			// textStock
			// 
			this.textStock.Location = new System.Drawing.Point(109, 364);
			this.textStock.Mask = "99999";
			this.textStock.Name = "textStock";
			this.textStock.Size = new System.Drawing.Size(89, 23);
			this.textStock.TabIndex = 112;
			this.textStock.ValidatingType = typeof(int);
			// 
			// GenerarPublicacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(653, 640);
			this.Controls.Add(this.textStock);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnSubirTxt);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.btnSiguiente);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblUserLogueado);
			this.Controls.Add(this.lblEstado);
			this.Controls.Add(this.comboGradoPublicacion);
			this.Controls.Add(this.comboRubro);
			this.Controls.Add(this.textDireccion);
			this.Controls.Add(this.textDescripcion);
			this.Controls.Add(this.dateTimePickerEspectaculo);
			this.Controls.Add(this.dateTimePickerPublicacion);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.lblFechaEspectaculo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("Raleway", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "GenerarPublicacion";
			this.Text = "CategoriaUbicacion";
			this.Load += new System.EventHandler(this.CategoriaUbicacion_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblUserLogueado;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblTextLote;
		private System.Windows.Forms.RadioButton radioSi;
		private System.Windows.Forms.RadioButton radioNo;
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.ComboBox comboGradoPublicacion;
		private System.Windows.Forms.ComboBox comboRubro;
		private System.Windows.Forms.TextBox textDireccion;
		private System.Windows.Forms.TextBox textDescripcion;
		private System.Windows.Forms.DateTimePicker dateTimePickerEspectaculo;
		private System.Windows.Forms.DateTimePicker dateTimePickerPublicacion;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblFechaEspectaculo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Button btnSiguiente;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSubirTxt;
		private System.Windows.Forms.MaskedTextBox textStock;
	}
}
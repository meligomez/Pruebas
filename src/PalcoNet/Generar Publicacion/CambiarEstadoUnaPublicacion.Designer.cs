namespace PalcoNet.Generar_Publicacion
{
	partial class CambiarEstadoUnaPublicacion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarEstadoUnaPublicacion));
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbxEstado = new System.Windows.Forms.ComboBox();
			this.ee = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblEmpleado = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnVolver = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.lblPublicacion = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
			this.pictureBox3.Location = new System.Drawing.Point(23, 18);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(65, 66);
			this.pictureBox3.TabIndex = 93;
			this.pictureBox3.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(94, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(401, 35);
			this.label1.TabIndex = 92;
			this.label1.Text = "EDITAR UNA PUBLICACION";
			// 
			// cbxEstado
			// 
			this.cbxEstado.FormattingEnabled = true;
			this.cbxEstado.Location = new System.Drawing.Point(84, 210);
			this.cbxEstado.Name = "cbxEstado";
			this.cbxEstado.Size = new System.Drawing.Size(145, 24);
			this.cbxEstado.TabIndex = 95;
			// 
			// ee
			// 
			this.ee.AutoSize = true;
			this.ee.Location = new System.Drawing.Point(33, 213);
			this.ee.Name = "ee";
			this.ee.Size = new System.Drawing.Size(56, 17);
			this.ee.TabIndex = 94;
			this.ee.Text = "Estado:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 163);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(137, 17);
			this.label4.TabIndex = 101;
			this.label4.Text = "Publicacion a Editar:";
			// 
			// lblEmpleado
			// 
			this.lblEmpleado.AutoSize = true;
			this.lblEmpleado.Location = new System.Drawing.Point(167, 117);
			this.lblEmpleado.Name = "lblEmpleado";
			this.lblEmpleado.Size = new System.Drawing.Size(0, 17);
			this.lblEmpleado.TabIndex = 100;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 17);
			this.label2.TabIndex = 99;
			this.label2.Text = "Empleado a Cargo:";
			// 
			// btnVolver
			// 
			this.btnVolver.Location = new System.Drawing.Point(23, 280);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(113, 33);
			this.btnVolver.TabIndex = 102;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Location = new System.Drawing.Point(429, 280);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(113, 33);
			this.btnGuardar.TabIndex = 103;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// lblPublicacion
			// 
			this.lblPublicacion.AutoSize = true;
			this.lblPublicacion.Location = new System.Drawing.Point(167, 163);
			this.lblPublicacion.Name = "lblPublicacion";
			this.lblPublicacion.Size = new System.Drawing.Size(0, 17);
			this.lblPublicacion.TabIndex = 104;
			// 
			// CambiarEstadoUnaPublicacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(554, 343);
			this.Controls.Add(this.lblPublicacion);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblEmpleado);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbxEstado);
			this.Controls.Add(this.ee);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CambiarEstadoUnaPublicacion";
			this.Text = "CambiarEstadoUnaPublicacion";
			this.Load += new System.EventHandler(this.CambiarEstadoUnaPublicacion_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbxEstado;
		private System.Windows.Forms.Label ee;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblEmpleado;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Label lblPublicacion;
	}
}
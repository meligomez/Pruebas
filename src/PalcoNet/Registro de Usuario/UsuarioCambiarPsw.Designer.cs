namespace PalcoNet.Registro_de_Usuario
{
	partial class UsuarioCambiarPsw
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioCambiarPsw));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblUsuario = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.cancelarBtn = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblPswAnterior = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(95, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(361, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "CAMBIAR CONTRASEÑA";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Usuario:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(28, 142);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(201, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Contraseña Anterior:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 196);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(188, 24);
			this.label4.TabIndex = 3;
			this.label4.Text = "Nueva Contraseña:";
			// 
			// lblUsuario
			// 
			this.lblUsuario.AutoSize = true;
			this.lblUsuario.Location = new System.Drawing.Point(119, 92);
			this.lblUsuario.Name = "lblUsuario";
			this.lblUsuario.Size = new System.Drawing.Size(0, 24);
			this.lblUsuario.TabIndex = 4;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(222, 196);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(207, 31);
			this.textBox2.TabIndex = 6;
			// 
			// cancelarBtn
			// 
			this.cancelarBtn.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelarBtn.Location = new System.Drawing.Point(32, 253);
			this.cancelarBtn.Name = "cancelarBtn";
			this.cancelarBtn.Size = new System.Drawing.Size(127, 49);
			this.cancelarBtn.TabIndex = 40;
			this.cancelarBtn.Text = "Cancelar";
			this.cancelarBtn.UseVisualStyleBackColor = true;
			this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.Location = new System.Drawing.Point(450, 251);
			this.btnGuardar.Margin = new System.Windows.Forms.Padding(5);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(115, 49);
			this.btnGuardar.TabIndex = 39;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(73, 77);
			this.pictureBox1.TabIndex = 41;
			this.pictureBox1.TabStop = false;
			// 
			// lblPswAnterior
			// 
			this.lblPswAnterior.AutoSize = true;
			this.lblPswAnterior.Location = new System.Drawing.Point(235, 142);
			this.lblPswAnterior.Name = "lblPswAnterior";
			this.lblPswAnterior.Size = new System.Drawing.Size(0, 24);
			this.lblPswAnterior.TabIndex = 42;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(511, 142);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(191, 24);
			this.label6.TabIndex = 43;
			this.label6.Text = "Creada por defecto";
			// 
			// UsuarioCambiarPsw
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(749, 316);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblPswAnterior);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.cancelarBtn);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.lblUsuario);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "UsuarioCambiarPsw";
			this.Text = "UsuarioCambiarPsw";
			this.Load += new System.EventHandler(this.UsuarioCambiarPsw_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblUsuario;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button cancelarBtn;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblPswAnterior;
		private System.Windows.Forms.Label label6;
	}
}
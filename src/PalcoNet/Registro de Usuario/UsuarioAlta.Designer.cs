namespace PalcoNet.Registro_de_Usuario
{
    partial class UsuarioAlta
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioAlta));
			this.lblTipoDoc = new System.Windows.Forms.Label();
			this.cbxTipoDocumento = new System.Windows.Forms.ComboBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.txtContraseña = new System.Windows.Forms.TextBox();
			this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
			this.txtTelefono = new System.Windows.Forms.TextBox();
			this.txtMail = new System.Windows.Forms.TextBox();
			this.txtNroDoc = new System.Windows.Forms.TextBox();
			this.txtApellido = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblFechaNacimiento = new System.Windows.Forms.Label();
			this.lblTelefono = new System.Windows.Forms.Label();
			this.lblMail = new System.Windows.Forms.Label();
			this.lblNroDocumento = new System.Windows.Forms.Label();
			this.lblApellido = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.cancelarBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxRoles = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTipoDoc
			// 
			this.lblTipoDoc.AutoSize = true;
			this.lblTipoDoc.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTipoDoc.Location = new System.Drawing.Point(324, 245);
			this.lblTipoDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTipoDoc.Name = "lblTipoDoc";
			this.lblTipoDoc.Size = new System.Drawing.Size(186, 22);
			this.lblTipoDoc.TabIndex = 35;
			this.lblTipoDoc.Text = "Tipo de documento:";
			// 
			// cbxTipoDocumento
			// 
			this.cbxTipoDocumento.FormattingEnabled = true;
			this.cbxTipoDocumento.Location = new System.Drawing.Point(327, 276);
			this.cbxTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
			this.cbxTipoDocumento.Name = "cbxTipoDocumento";
			this.cbxTipoDocumento.Size = new System.Drawing.Size(282, 28);
			this.cbxTipoDocumento.TabIndex = 34;
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.Location = new System.Drawing.Point(24, 462);
			this.btnGuardar.Margin = new System.Windows.Forms.Padding(5);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(115, 37);
			this.btnGuardar.TabIndex = 33;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
			// 
			// txtContraseña
			// 
			this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtContraseña.Location = new System.Drawing.Point(327, 196);
			this.txtContraseña.Margin = new System.Windows.Forms.Padding(5);
			this.txtContraseña.Name = "txtContraseña";
			this.txtContraseña.PasswordChar = '*';
			this.txtContraseña.Size = new System.Drawing.Size(282, 30);
			this.txtContraseña.TabIndex = 32;
			// 
			// dtpFechaNacimiento
			// 
			this.dtpFechaNacimiento.Location = new System.Drawing.Point(327, 120);
			this.dtpFechaNacimiento.Margin = new System.Windows.Forms.Padding(4);
			this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
			this.dtpFechaNacimiento.Size = new System.Drawing.Size(339, 27);
			this.dtpFechaNacimiento.TabIndex = 31;
			// 
			// txtTelefono
			// 
			this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtTelefono.Location = new System.Drawing.Point(20, 411);
			this.txtTelefono.Margin = new System.Windows.Forms.Padding(5);
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(282, 30);
			this.txtTelefono.TabIndex = 30;
			// 
			// txtMail
			// 
			this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtMail.Location = new System.Drawing.Point(20, 339);
			this.txtMail.Margin = new System.Windows.Forms.Padding(5);
			this.txtMail.Name = "txtMail";
			this.txtMail.Size = new System.Drawing.Size(282, 30);
			this.txtMail.TabIndex = 29;
			// 
			// txtNroDoc
			// 
			this.txtNroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtNroDoc.Location = new System.Drawing.Point(20, 272);
			this.txtNroDoc.Margin = new System.Windows.Forms.Padding(5);
			this.txtNroDoc.Name = "txtNroDoc";
			this.txtNroDoc.Size = new System.Drawing.Size(282, 30);
			this.txtNroDoc.TabIndex = 28;
			// 
			// txtApellido
			// 
			this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtApellido.Location = new System.Drawing.Point(20, 196);
			this.txtApellido.Margin = new System.Windows.Forms.Padding(5);
			this.txtApellido.Name = "txtApellido";
			this.txtApellido.Size = new System.Drawing.Size(282, 30);
			this.txtApellido.TabIndex = 27;
			// 
			// txtNombre
			// 
			this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.txtNombre.Location = new System.Drawing.Point(20, 117);
			this.txtNombre.Margin = new System.Windows.Forms.Padding(5);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(282, 30);
			this.txtNombre.TabIndex = 26;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.Location = new System.Drawing.Point(334, 162);
			this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(113, 22);
			this.lblPassword.TabIndex = 25;
			this.lblPassword.Text = "Contraseña:";
			// 
			// lblFechaNacimiento
			// 
			this.lblFechaNacimiento.AutoSize = true;
			this.lblFechaNacimiento.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFechaNacimiento.Location = new System.Drawing.Point(324, 85);
			this.lblFechaNacimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFechaNacimiento.Name = "lblFechaNacimiento";
			this.lblFechaNacimiento.Size = new System.Drawing.Size(195, 22);
			this.lblFechaNacimiento.TabIndex = 24;
			this.lblFechaNacimiento.Text = "Fecha de nacimiento:";
			// 
			// lblTelefono
			// 
			this.lblTelefono.AutoSize = true;
			this.lblTelefono.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTelefono.Location = new System.Drawing.Point(20, 384);
			this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTelefono.Name = "lblTelefono";
			this.lblTelefono.Size = new System.Drawing.Size(93, 22);
			this.lblTelefono.TabIndex = 23;
			this.lblTelefono.Text = "Telefono:";
			// 
			// lblMail
			// 
			this.lblMail.AutoSize = true;
			this.lblMail.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMail.Location = new System.Drawing.Point(20, 312);
			this.lblMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblMail.Name = "lblMail";
			this.lblMail.Size = new System.Drawing.Size(50, 22);
			this.lblMail.TabIndex = 22;
			this.lblMail.Text = "Mail:";
			// 
			// lblNroDocumento
			// 
			this.lblNroDocumento.AutoSize = true;
			this.lblNroDocumento.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNroDocumento.Location = new System.Drawing.Point(20, 245);
			this.lblNroDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblNroDocumento.Name = "lblNroDocumento";
			this.lblNroDocumento.Size = new System.Drawing.Size(156, 22);
			this.lblNroDocumento.TabIndex = 21;
			this.lblNroDocumento.Text = "Nro. documento:";
			// 
			// lblApellido
			// 
			this.lblApellido.AutoSize = true;
			this.lblApellido.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblApellido.Location = new System.Drawing.Point(20, 162);
			this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblApellido.Name = "lblApellido";
			this.lblApellido.Size = new System.Drawing.Size(87, 22);
			this.lblApellido.TabIndex = 20;
			this.lblApellido.Text = "Apellido:";
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNombre.Location = new System.Drawing.Point(20, 85);
			this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(87, 22);
			this.lblNombre.TabIndex = 19;
			this.lblNombre.Text = "Nombre:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(99, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(272, 33);
			this.label1.TabIndex = 36;
			this.label1.Text = "ALTA DE USUARIOS";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(24, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(54, 50);
			this.pictureBox1.TabIndex = 37;
			this.pictureBox1.TabStop = false;
			// 
			// cancelarBtn
			// 
			this.cancelarBtn.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelarBtn.Location = new System.Drawing.Point(455, 460);
			this.cancelarBtn.Name = "cancelarBtn";
			this.cancelarBtn.Size = new System.Drawing.Size(127, 39);
			this.cancelarBtn.TabIndex = 38;
			this.cancelarBtn.Text = "Cancelar";
			this.cancelarBtn.UseVisualStyleBackColor = true;
			this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Raleway", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(334, 312);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 22);
			this.label2.TabIndex = 40;
			this.label2.Text = "Rol:";
			// 
			// cbxRoles
			// 
			this.cbxRoles.FormattingEnabled = true;
			this.cbxRoles.Location = new System.Drawing.Point(328, 338);
			this.cbxRoles.Margin = new System.Windows.Forms.Padding(4);
			this.cbxRoles.Name = "cbxRoles";
			this.cbxRoles.Size = new System.Drawing.Size(171, 28);
			this.cbxRoles.TabIndex = 39;
			// 
			// UsuarioAlta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(669, 510);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbxRoles);
			this.Controls.Add(this.cancelarBtn);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblTipoDoc);
			this.Controls.Add(this.cbxTipoDocumento);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.txtContraseña);
			this.Controls.Add(this.dtpFechaNacimiento);
			this.Controls.Add(this.txtTelefono);
			this.Controls.Add(this.txtMail);
			this.Controls.Add(this.txtNroDoc);
			this.Controls.Add(this.txtApellido);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.lblFechaNacimiento);
			this.Controls.Add(this.lblTelefono);
			this.Controls.Add(this.lblMail);
			this.Controls.Add(this.lblNroDocumento);
			this.Controls.Add(this.lblApellido);
			this.Controls.Add(this.lblNombre);
			this.Font = new System.Drawing.Font("Raleway", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "UsuarioAlta";
			this.Text = "Alta de Usuario";
			this.Load += new System.EventHandler(this.UsuarioAlta_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label lblTipoDoc;
		private System.Windows.Forms.ComboBox cbxTipoDocumento;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.TextBox txtContraseña;
		private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
		private System.Windows.Forms.TextBox txtTelefono;
		private System.Windows.Forms.TextBox txtMail;
		private System.Windows.Forms.TextBox txtNroDoc;
		private System.Windows.Forms.TextBox txtApellido;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblFechaNacimiento;
		private System.Windows.Forms.Label lblTelefono;
		private System.Windows.Forms.Label lblMail;
		private System.Windows.Forms.Label lblNroDocumento;
		private System.Windows.Forms.Label lblApellido;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button cancelarBtn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxRoles;
	}
}
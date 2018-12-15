namespace PalcoNet.Historial_Cliente
{
    partial class HistorialCliente
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialCliente));
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnVolver = new System.Windows.Forms.Button();
			this.panelNavegacion = new System.Windows.Forms.Panel();
			this.txtDisplayPageNo = new System.Windows.Forms.TextBox();
			this.btnFirstPage = new System.Windows.Forms.Button();
			this.btnPreviousPage = new System.Windows.Forms.Button();
			this.btnLastPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCantPags = new System.Windows.Forms.MaskedTextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panelNavegacion.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Raleway", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(85, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(369, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "HISTORIAL DE COMPRAS";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(67, 66);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 152);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(821, 259);
			this.dataGridView1.TabIndex = 2;
			// 
			// btnVolver
			// 
			this.btnVolver.Location = new System.Drawing.Point(3, 436);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(142, 39);
			this.btnVolver.TabIndex = 3;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// panelNavegacion
			// 
			this.panelNavegacion.Controls.Add(this.txtDisplayPageNo);
			this.panelNavegacion.Controls.Add(this.btnFirstPage);
			this.panelNavegacion.Controls.Add(this.btnPreviousPage);
			this.panelNavegacion.Controls.Add(this.btnLastPage);
			this.panelNavegacion.Controls.Add(this.btnNextPage);
			this.panelNavegacion.Location = new System.Drawing.Point(166, 420);
			this.panelNavegacion.Margin = new System.Windows.Forms.Padding(4);
			this.panelNavegacion.Name = "panelNavegacion";
			this.panelNavegacion.Size = new System.Drawing.Size(640, 66);
			this.panelNavegacion.TabIndex = 93;
			// 
			// txtDisplayPageNo
			// 
			this.txtDisplayPageNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.txtDisplayPageNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.txtDisplayPageNo.Location = new System.Drawing.Point(248, 18);
			this.txtDisplayPageNo.Margin = new System.Windows.Forms.Padding(4);
			this.txtDisplayPageNo.Name = "txtDisplayPageNo";
			this.txtDisplayPageNo.Size = new System.Drawing.Size(132, 28);
			this.txtDisplayPageNo.TabIndex = 88;
			// 
			// btnFirstPage
			// 
			this.btnFirstPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnFirstPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnFirstPage.Location = new System.Drawing.Point(29, 18);
			this.btnFirstPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnFirstPage.Name = "btnFirstPage";
			this.btnFirstPage.Size = new System.Drawing.Size(100, 31);
			this.btnFirstPage.TabIndex = 81;
			this.btnFirstPage.Text = "Primera";
			this.btnFirstPage.UseVisualStyleBackColor = true;
			this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
			// 
			// btnPreviousPage
			// 
			this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnPreviousPage.Location = new System.Drawing.Point(139, 18);
			this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnPreviousPage.Name = "btnPreviousPage";
			this.btnPreviousPage.Size = new System.Drawing.Size(100, 31);
			this.btnPreviousPage.TabIndex = 85;
			this.btnPreviousPage.Text = "Atrás";
			this.btnPreviousPage.UseVisualStyleBackColor = true;
			this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
			// 
			// btnLastPage
			// 
			this.btnLastPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnLastPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnLastPage.Location = new System.Drawing.Point(503, 18);
			this.btnLastPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnLastPage.Name = "btnLastPage";
			this.btnLastPage.Size = new System.Drawing.Size(100, 31);
			this.btnLastPage.TabIndex = 87;
			this.btnLastPage.Text = "Última";
			this.btnLastPage.UseVisualStyleBackColor = true;
			this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
			// 
			// btnNextPage
			// 
			this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnNextPage.Location = new System.Drawing.Point(393, 18);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(100, 31);
			this.btnNextPage.TabIndex = 86;
			this.btnNextPage.Text = "Siguiente";
			this.btnNextPage.UseVisualStyleBackColor = true;
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(315, 24);
			this.label2.TabIndex = 96;
			this.label2.Text = "Ingrese una cantidad de Páginas:";
			// 
			// txtCantPags
			// 
			this.txtCantPags.Location = new System.Drawing.Point(305, 112);
			this.txtCantPags.Mask = "99999";
			this.txtCantPags.Name = "txtCantPags";
			this.txtCantPags.Size = new System.Drawing.Size(110, 31);
			this.txtCantPags.TabIndex = 97;
			this.txtCantPags.ValidatingType = typeof(int);
			this.txtCantPags.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtCantPags_MaskInputRejected);
			this.txtCantPags.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// HistorialCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(885, 533);
			this.Controls.Add(this.txtCantPags);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panelNavegacion);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "HistorialCliente";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.HistorialCliente_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panelNavegacion.ResumeLayout(false);
			this.panelNavegacion.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Panel panelNavegacion;
		internal System.Windows.Forms.TextBox txtDisplayPageNo;
		internal System.Windows.Forms.Button btnFirstPage;
		internal System.Windows.Forms.Button btnPreviousPage;
		internal System.Windows.Forms.Button btnLastPage;
		internal System.Windows.Forms.Button btnNextPage;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox txtCantPags;
	}
}
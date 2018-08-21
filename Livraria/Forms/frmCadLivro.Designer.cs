namespace Livraria.Forms {
    partial class frmCadLivro {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbAutor = new System.Windows.Forms.ComboBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.txtSinopse = new System.Windows.Forms.RichTextBox();
            this.txtPreco = new System.Windows.Forms.MaskedTextBox();
            this.picCapa = new System.Windows.Forms.PictureBox();
            this.btnAddCategoria = new System.Windows.Forms.Button();
            this.btnImagem = new System.Windows.Forms.Button();
            this.btnAddAutor = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Título:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data de lançamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Categoria:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Autor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Preço:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sinopse:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Capa:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(15, 41);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(290, 27);
            this.txtTitulo.TabIndex = 7;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(15, 108);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(195, 30);
            this.cmbCategoria.TabIndex = 9;
            // 
            // cmbAutor
            // 
            this.cmbAutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAutor.FormattingEnabled = true;
            this.cmbAutor.Location = new System.Drawing.Point(444, 39);
            this.cmbAutor.Name = "cmbAutor";
            this.cmbAutor.Size = new System.Drawing.Size(233, 28);
            this.cmbAutor.TabIndex = 10;
            // 
            // dtpData
            // 
            this.dtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(444, 99);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(233, 28);
            this.dtpData.TabIndex = 11;
            // 
            // txtSinopse
            // 
            this.txtSinopse.Location = new System.Drawing.Point(444, 240);
            this.txtSinopse.Name = "txtSinopse";
            this.txtSinopse.Size = new System.Drawing.Size(297, 269);
            this.txtSinopse.TabIndex = 12;
            this.txtSinopse.Text = "";
            // 
            // txtPreco
            // 
            this.txtPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreco.Location = new System.Drawing.Point(16, 166);
            this.txtPreco.Mask = "00.00";
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPreco.Size = new System.Drawing.Size(70, 27);
            this.txtPreco.TabIndex = 13;
            this.txtPreco.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // picCapa
            // 
            this.picCapa.Location = new System.Drawing.Point(15, 251);
            this.picCapa.Name = "picCapa";
            this.picCapa.Size = new System.Drawing.Size(330, 297);
            this.picCapa.TabIndex = 14;
            this.picCapa.TabStop = false;
            // 
            // btnAddCategoria
            // 
            this.btnAddCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddCategoria.Location = new System.Drawing.Point(217, 105);
            this.btnAddCategoria.Name = "btnAddCategoria";
            this.btnAddCategoria.Size = new System.Drawing.Size(128, 37);
            this.btnAddCategoria.TabIndex = 15;
            this.btnAddCategoria.Text = "Add categoria";
            this.btnAddCategoria.UseVisualStyleBackColor = true;
            // 
            // btnImagem
            // 
            this.btnImagem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImagem.Location = new System.Drawing.Point(236, 197);
            this.btnImagem.Name = "btnImagem";
            this.btnImagem.Size = new System.Drawing.Size(109, 48);
            this.btnImagem.TabIndex = 16;
            this.btnImagem.Text = "Escolher imagem";
            this.btnImagem.UseVisualStyleBackColor = true;
            // 
            // btnAddAutor
            // 
            this.btnAddAutor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAutor.Location = new System.Drawing.Point(683, 34);
            this.btnAddAutor.Name = "btnAddAutor";
            this.btnAddAutor.Size = new System.Drawing.Size(96, 33);
            this.btnAddAutor.TabIndex = 17;
            this.btnAddAutor.Text = "Add autor";
            this.btnAddAutor.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvar.Location = new System.Drawing.Point(632, 538);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(109, 33);
            this.btnSalvar.TabIndex = 18;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // CadLivro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 583);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnAddAutor);
            this.Controls.Add(this.btnImagem);
            this.Controls.Add(this.btnAddCategoria);
            this.Controls.Add(this.picCapa);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtSinopse);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.cmbAutor);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CadLivro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadLivro";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picCapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbAutor;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.RichTextBox txtSinopse;
        private System.Windows.Forms.MaskedTextBox txtPreco;
        private System.Windows.Forms.PictureBox picCapa;
        private System.Windows.Forms.Button btnAddCategoria;
        private System.Windows.Forms.Button btnImagem;
        private System.Windows.Forms.Button btnAddAutor;
        private System.Windows.Forms.Button btnSalvar;
    }
}
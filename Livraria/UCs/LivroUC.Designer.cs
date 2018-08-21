namespace Livraria.UCs {
    partial class LivroUC {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.dgvLivro = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.picCapa = new System.Windows.Forms.PictureBox();
            this.colunaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaSinopse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaImagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCapa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLivro
            // 
            this.dgvLivro.AllowUserToAddRows = false;
            this.dgvLivro.AllowUserToDeleteRows = false;
            this.dgvLivro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaID,
            this.colunaTitulo,
            this.colunaPreco,
            this.colunaAutor,
            this.colunaCategoria,
            this.colunaSinopse,
            this.colunaData,
            this.colunaImagem});
            this.dgvLivro.Location = new System.Drawing.Point(0, 272);
            this.dgvLivro.Name = "dgvLivro";
            this.dgvLivro.ReadOnly = true;
            this.dgvLivro.RowTemplate.Height = 24;
            this.dgvLivro.Size = new System.Drawing.Size(882, 317);
            this.dgvLivro.TabIndex = 0;
            this.dgvLivro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivro_CellClick);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.GreenYellow;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNovo.Location = new System.Drawing.Point(755, 606);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(127, 54);
            this.btnNovo.TabIndex = 2;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Tomato;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExcluir.Location = new System.Drawing.Point(477, 606);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(127, 54);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir selecionado";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.Yellow;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAlterar.Location = new System.Drawing.Point(618, 606);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(127, 54);
            this.btnAlterar.TabIndex = 5;
            this.btnAlterar.Text = "Alterar selecionado";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // picCapa
            // 
            this.picCapa.Location = new System.Drawing.Point(3, 8);
            this.picCapa.Name = "picCapa";
            this.picCapa.Size = new System.Drawing.Size(271, 254);
            this.picCapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCapa.TabIndex = 1;
            this.picCapa.TabStop = false;
            // 
            // colunaID
            // 
            this.colunaID.DataPropertyName = "idLivro";
            this.colunaID.HeaderText = "ID";
            this.colunaID.Name = "colunaID";
            this.colunaID.ReadOnly = true;
            this.colunaID.Width = 50;
            // 
            // colunaTitulo
            // 
            this.colunaTitulo.DataPropertyName = "tituloLivro";
            this.colunaTitulo.HeaderText = "Título";
            this.colunaTitulo.Name = "colunaTitulo";
            this.colunaTitulo.ReadOnly = true;
            this.colunaTitulo.Width = 300;
            // 
            // colunaPreco
            // 
            this.colunaPreco.DataPropertyName = "precoLivro";
            this.colunaPreco.HeaderText = "Preço";
            this.colunaPreco.Name = "colunaPreco";
            this.colunaPreco.ReadOnly = true;
            // 
            // colunaAutor
            // 
            this.colunaAutor.DataPropertyName = "autorLivro";
            this.colunaAutor.HeaderText = "Autor";
            this.colunaAutor.Name = "colunaAutor";
            this.colunaAutor.ReadOnly = true;
            this.colunaAutor.Width = 250;
            // 
            // colunaCategoria
            // 
            this.colunaCategoria.DataPropertyName = "categoriaLivro";
            this.colunaCategoria.HeaderText = "Categoria";
            this.colunaCategoria.Name = "colunaCategoria";
            this.colunaCategoria.ReadOnly = true;
            this.colunaCategoria.Width = 125;
            // 
            // colunaSinopse
            // 
            this.colunaSinopse.DataPropertyName = "sinopseLivro";
            this.colunaSinopse.HeaderText = "Sinopse";
            this.colunaSinopse.Name = "colunaSinopse";
            this.colunaSinopse.ReadOnly = true;
            this.colunaSinopse.Visible = false;
            this.colunaSinopse.Width = 500;
            // 
            // colunaData
            // 
            this.colunaData.DataPropertyName = "dataLancamento";
            this.colunaData.HeaderText = "Data de lançamento";
            this.colunaData.Name = "colunaData";
            this.colunaData.ReadOnly = true;
            this.colunaData.Width = 110;
            // 
            // colunaImagem
            // 
            this.colunaImagem.HeaderText = "Imagem";
            this.colunaImagem.Name = "colunaImagem";
            this.colunaImagem.ReadOnly = true;
            this.colunaImagem.Visible = false;
            // 
            // LivroUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.picCapa);
            this.Controls.Add(this.dgvLivro);
            this.Name = "LivroUC";
            this.Size = new System.Drawing.Size(885, 673);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLivro;
        private System.Windows.Forms.PictureBox picCapa;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaSinopse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaImagem;
    }
}

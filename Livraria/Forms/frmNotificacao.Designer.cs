namespace Livraria.Forms {
    partial class frmNotificacao {
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
            this.components = new System.ComponentModel.Container();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.objImagens = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.objLista = new System.Windows.Forms.ListView();
            this.colCapa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQtdeDisp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRecomendada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.White;
            this.btnVoltar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Image = global::Livraria.Properties.Resources.Right_Arrow_20px;
            this.btnVoltar.Location = new System.Drawing.Point(0, 0);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(23, 797);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // objImagens
            // 
            this.objImagens.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.objImagens.ImageSize = new System.Drawing.Size(70, 100);
            this.objImagens.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(23, 797);
            this.panel1.TabIndex = 3;
            // 
            // objLista
            // 
            this.objLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(226)))), ((int)(((byte)(240)))));
            this.objLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.objLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCapa,
            this.colTitulo,
            this.colQtdeDisp,
            this.colRecomendada});
            this.objLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objLista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objLista.FullRowSelect = true;
            this.objLista.LargeImageList = this.objImagens;
            this.objLista.Location = new System.Drawing.Point(23, 0);
            this.objLista.MultiSelect = false;
            this.objLista.Name = "objLista";
            this.objLista.Scrollable = false;
            this.objLista.Size = new System.Drawing.Size(279, 797);
            this.objLista.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.objLista.TabIndex = 5;
            this.objLista.TileSize = new System.Drawing.Size(560, 110);
            this.objLista.UseCompatibleStateImageBehavior = false;
            this.objLista.View = System.Windows.Forms.View.Tile;
            this.objLista.DoubleClick += new System.EventHandler(this.objLista_DoubleClick);
            // 
            // colCapa
            // 
            this.colCapa.DisplayIndex = 3;
            this.colCapa.Text = "Capa";
            // 
            // colTitulo
            // 
            this.colTitulo.DisplayIndex = 0;
            this.colTitulo.Text = "Titulo";
            // 
            // colQtdeDisp
            // 
            this.colQtdeDisp.Text = "Disponivel";
            // 
            // colRecomendada
            // 
            this.colRecomendada.DisplayIndex = 1;
            this.colRecomendada.Text = "Recomendada";
            // 
            // frmNotificacao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 800);
            this.Controls.Add(this.objLista);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotificacao";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmNotificacao";
            this.Load += new System.EventHandler(this.frmNotificacao_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.ImageList objImagens;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView objLista;
        private System.Windows.Forms.ColumnHeader colQtdeDisp;
        private System.Windows.Forms.ColumnHeader colTitulo;
        private System.Windows.Forms.ColumnHeader colRecomendada;
        private System.Windows.Forms.ColumnHeader colCapa;
    }
}
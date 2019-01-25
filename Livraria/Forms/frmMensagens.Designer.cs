namespace Livraria.Forms {
    partial class frmMensagens {
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
            this.objLista = new System.Windows.Forms.ListView();
            this.colCapa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQtdeDisp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRecomendada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.objLista.Dock = System.Windows.Forms.DockStyle.Right;
            this.objLista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objLista.FullRowSelect = true;
            this.objLista.Location = new System.Drawing.Point(28, 0);
            this.objLista.MultiSelect = false;
            this.objLista.Name = "objLista";
            this.objLista.Scrollable = false;
            this.objLista.Size = new System.Drawing.Size(451, 800);
            this.objLista.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.objLista.TabIndex = 6;
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
            this.btnVoltar.Size = new System.Drawing.Size(28, 800);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmMensagens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 800);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.objLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMensagens";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmMensagens";
            this.Load += new System.EventHandler(this.frmMensagens_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView objLista;
        private System.Windows.Forms.ColumnHeader colCapa;
        private System.Windows.Forms.ColumnHeader colTitulo;
        private System.Windows.Forms.ColumnHeader colQtdeDisp;
        private System.Windows.Forms.ColumnHeader colRecomendada;
        private System.Windows.Forms.Button btnVoltar;
    }
}
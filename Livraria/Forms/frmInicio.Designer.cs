namespace Livraria.Forms {
    partial class frmInicio {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.panelSlideBar = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnGanhos = new System.Windows.Forms.Button();
            this.btnRanking = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCaixa = new System.Windows.Forms.Button();
            this.btnFunc = new System.Windows.Forms.Button();
            this.btnLivros = new System.Windows.Forms.Button();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.caixaUC2 = new Livraria.UCs.CaixaUC();
            this.homeUC1 = new Livraria.UCs.HomeUC();
            this.funcUC1 = new Livraria.UCs.FuncUC();
            this.livroUC1 = new Livraria.UCs.LivroUC();
            this.ganhosUC1 = new Livraria.UCs.GanhosUC();
            this.rankingUC1 = new Livraria.UCs.RankingUC();
            this.btnMensagens = new System.Windows.Forms.Button();
            this.btnNotificacao = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelConteudo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSlideBar
            // 
            this.panelSlideBar.BackColor = System.Drawing.Color.White;
            this.panelSlideBar.Location = new System.Drawing.Point(0, 330);
            this.panelSlideBar.Name = "panelSlideBar";
            this.panelSlideBar.Size = new System.Drawing.Size(8, 56);
            this.panelSlideBar.TabIndex = 6;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(113)))), ((int)(((byte)(174)))));
            this.panelMenu.Controls.Add(this.btnGanhos);
            this.panelMenu.Controls.Add(this.btnRanking);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.panelSlideBar);
            this.panelMenu.Controls.Add(this.btnCaixa);
            this.panelMenu.Controls.Add(this.btnFunc);
            this.panelMenu.Controls.Add(this.btnLivros);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(253, 800);
            this.panelMenu.TabIndex = 0;
            // 
            // btnGanhos
            // 
            this.btnGanhos.FlatAppearance.BorderSize = 0;
            this.btnGanhos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(36)))), ((int)(((byte)(221)))));
            this.btnGanhos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGanhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGanhos.ForeColor = System.Drawing.Color.White;
            this.btnGanhos.Image = ((System.Drawing.Image)(resources.GetObject("btnGanhos.Image")));
            this.btnGanhos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGanhos.Location = new System.Drawing.Point(6, 566);
            this.btnGanhos.Name = "btnGanhos";
            this.btnGanhos.Size = new System.Drawing.Size(243, 56);
            this.btnGanhos.TabIndex = 14;
            this.btnGanhos.Text = "   Ganhos";
            this.btnGanhos.UseVisualStyleBackColor = true;
            this.btnGanhos.Click += new System.EventHandler(this.btnGanhos_Click);
            // 
            // btnRanking
            // 
            this.btnRanking.FlatAppearance.BorderSize = 0;
            this.btnRanking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(36)))), ((int)(((byte)(221)))));
            this.btnRanking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRanking.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRanking.ForeColor = System.Drawing.Color.White;
            this.btnRanking.Image = ((System.Drawing.Image)(resources.GetObject("btnRanking.Image")));
            this.btnRanking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRanking.Location = new System.Drawing.Point(6, 505);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(243, 56);
            this.btnRanking.TabIndex = 13;
            this.btnRanking.Text = "      Ranking de vendas";
            this.btnRanking.UseVisualStyleBackColor = true;
            this.btnRanking.Click += new System.EventHandler(this.btnRanking_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(36)))), ((int)(((byte)(221)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(10, 272);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(243, 56);
            this.btnHome.TabIndex = 8;
            this.btnHome.Text = "         Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 202);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnCaixa
            // 
            this.btnCaixa.FlatAppearance.BorderSize = 0;
            this.btnCaixa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(36)))), ((int)(((byte)(221)))));
            this.btnCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaixa.ForeColor = System.Drawing.Color.White;
            this.btnCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnCaixa.Image")));
            this.btnCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaixa.Location = new System.Drawing.Point(10, 330);
            this.btnCaixa.Name = "btnCaixa";
            this.btnCaixa.Size = new System.Drawing.Size(243, 56);
            this.btnCaixa.TabIndex = 2;
            this.btnCaixa.Text = "         Caixa";
            this.btnCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCaixa.UseVisualStyleBackColor = true;
            this.btnCaixa.Click += new System.EventHandler(this.btnCaixa_Click);
            // 
            // btnFunc
            // 
            this.btnFunc.FlatAppearance.BorderSize = 0;
            this.btnFunc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(36)))), ((int)(((byte)(221)))));
            this.btnFunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFunc.ForeColor = System.Drawing.Color.White;
            this.btnFunc.Image = ((System.Drawing.Image)(resources.GetObject("btnFunc.Image")));
            this.btnFunc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFunc.Location = new System.Drawing.Point(10, 447);
            this.btnFunc.Name = "btnFunc";
            this.btnFunc.Size = new System.Drawing.Size(243, 56);
            this.btnFunc.TabIndex = 1;
            this.btnFunc.Text = "    Funcionários";
            this.btnFunc.UseVisualStyleBackColor = true;
            this.btnFunc.Click += new System.EventHandler(this.btnFunc_Click);
            // 
            // btnLivros
            // 
            this.btnLivros.FlatAppearance.BorderSize = 0;
            this.btnLivros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(36)))), ((int)(((byte)(221)))));
            this.btnLivros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLivros.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLivros.ForeColor = System.Drawing.Color.White;
            this.btnLivros.Image = ((System.Drawing.Image)(resources.GetObject("btnLivros.Image")));
            this.btnLivros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLivros.Location = new System.Drawing.Point(10, 388);
            this.btnLivros.Name = "btnLivros";
            this.btnLivros.Size = new System.Drawing.Size(243, 56);
            this.btnLivros.TabIndex = 0;
            this.btnLivros.Text = " Livros";
            this.btnLivros.UseVisualStyleBackColor = true;
            this.btnLivros.Click += new System.EventHandler(this.btnLivros_Click);
            // 
            // panelConteudo
            // 
            this.panelConteudo.Controls.Add(this.caixaUC2);
            this.panelConteudo.Controls.Add(this.homeUC1);
            this.panelConteudo.Controls.Add(this.funcUC1);
            this.panelConteudo.Controls.Add(this.livroUC1);
            this.panelConteudo.Controls.Add(this.ganhosUC1);
            this.panelConteudo.Controls.Add(this.rankingUC1);
            this.panelConteudo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelConteudo.Location = new System.Drawing.Point(253, 45);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Size = new System.Drawing.Size(947, 755);
            this.panelConteudo.TabIndex = 2;
            // 
            // caixaUC2
            // 
            this.caixaUC2.BackColor = System.Drawing.Color.White;
            this.caixaUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caixaUC2.Location = new System.Drawing.Point(0, 0);
            this.caixaUC2.Name = "caixaUC2";
            this.caixaUC2.Size = new System.Drawing.Size(947, 755);
            this.caixaUC2.TabIndex = 7;
            // 
            // homeUC1
            // 
            this.homeUC1.BackColor = System.Drawing.Color.White;
            this.homeUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeUC1.Location = new System.Drawing.Point(0, 0);
            this.homeUC1.Name = "homeUC1";
            this.homeUC1.Size = new System.Drawing.Size(947, 755);
            this.homeUC1.TabIndex = 5;
            // 
            // funcUC1
            // 
            this.funcUC1.BackColor = System.Drawing.Color.White;
            this.funcUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funcUC1.Location = new System.Drawing.Point(0, 0);
            this.funcUC1.Margin = new System.Windows.Forms.Padding(4);
            this.funcUC1.Name = "funcUC1";
            this.funcUC1.Size = new System.Drawing.Size(947, 755);
            this.funcUC1.TabIndex = 1;
            // 
            // livroUC1
            // 
            this.livroUC1.BackColor = System.Drawing.Color.White;
            this.livroUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.livroUC1.Location = new System.Drawing.Point(0, 0);
            this.livroUC1.Name = "livroUC1";
            this.livroUC1.Size = new System.Drawing.Size(947, 755);
            this.livroUC1.TabIndex = 0;
            // 
            // ganhosUC1
            // 
            this.ganhosUC1.BackColor = System.Drawing.Color.White;
            this.ganhosUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganhosUC1.Location = new System.Drawing.Point(0, 0);
            this.ganhosUC1.Name = "ganhosUC1";
            this.ganhosUC1.Size = new System.Drawing.Size(947, 755);
            this.ganhosUC1.TabIndex = 4;
            // 
            // rankingUC1
            // 
            this.rankingUC1.BackColor = System.Drawing.Color.White;
            this.rankingUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rankingUC1.Location = new System.Drawing.Point(0, 0);
            this.rankingUC1.Margin = new System.Windows.Forms.Padding(2);
            this.rankingUC1.Name = "rankingUC1";
            this.rankingUC1.Size = new System.Drawing.Size(947, 755);
            this.rankingUC1.TabIndex = 6;
            // 
            // btnMensagens
            // 
            this.btnMensagens.BackColor = System.Drawing.Color.White;
            this.btnMensagens.FlatAppearance.BorderSize = 0;
            this.btnMensagens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMensagens.ForeColor = System.Drawing.Color.Red;
            this.btnMensagens.Image = global::Livraria.Properties.Resources.Secured_Letter_30px1;
            this.btnMensagens.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMensagens.Location = new System.Drawing.Point(972, 5);
            this.btnMensagens.Name = "btnMensagens";
            this.btnMensagens.Size = new System.Drawing.Size(59, 34);
            this.btnMensagens.TabIndex = 4;
            this.btnMensagens.Text = "1";
            this.btnMensagens.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMensagens.UseVisualStyleBackColor = false;
            this.btnMensagens.Click += new System.EventHandler(this.btnMensagens_Click);
            // 
            // btnNotificacao
            // 
            this.btnNotificacao.BackColor = System.Drawing.Color.White;
            this.btnNotificacao.FlatAppearance.BorderSize = 0;
            this.btnNotificacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotificacao.ForeColor = System.Drawing.Color.Red;
            this.btnNotificacao.Image = ((System.Drawing.Image)(resources.GetObject("btnNotificacao.Image")));
            this.btnNotificacao.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNotificacao.Location = new System.Drawing.Point(1033, 6);
            this.btnNotificacao.Name = "btnNotificacao";
            this.btnNotificacao.Size = new System.Drawing.Size(54, 34);
            this.btnNotificacao.TabIndex = 3;
            this.btnNotificacao.Text = "1";
            this.btnNotificacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNotificacao.UseVisualStyleBackColor = false;
            this.btnNotificacao.Click += new System.EventHandler(this.btnNotificacao_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.White;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(1093, 6);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(45, 34);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.White;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(79)))), ((int)(((byte)(74)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.Location = new System.Drawing.Point(1149, 6);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(43, 33);
            this.btnSair.TabIndex = 0;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmInicio
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.btnMensagens);
            this.Controls.Add(this.btnNotificacao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInicio";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInicio_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmInicio_MouseClick);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelConteudo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLivros;
        private System.Windows.Forms.Button btnFunc;
        private System.Windows.Forms.Button btnCaixa;
        private System.Windows.Forms.Panel panelSlideBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panelConteudo;
        private UCs.LivroUC livroUC1;
        private System.Windows.Forms.Button btnHome;
        private UCs.FuncUC funcUC1;
        private System.Windows.Forms.Button btnNotificacao;
        private UCs.GanhosUC ganhosUC1;
        private UCs.HomeUC homeUC1;
        private UCs.RankingUC rankingUC1;
        private System.Windows.Forms.Button btnGanhos;
        private System.Windows.Forms.Button btnRanking;
        private System.Windows.Forms.Button btnMensagens;
        private UCs.CaixaUC caixaUC2;
        private System.Windows.Forms.Timer timer1;
    }
}
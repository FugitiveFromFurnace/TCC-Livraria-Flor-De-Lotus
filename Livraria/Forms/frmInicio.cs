using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.UCs;
using Livraria.ModeloDeDados.ModeloAuxiliar;

namespace Livraria.Forms {
    public partial class frmInicio : Form {

        public static string nomeFunc;
        public static int idFunc;
        //private bool isColapsed = true;
        frmNotificacao frm;
        frmMensagens frmMensagens;

        public frmInicio() {
            InitializeComponent();

            if (frmLogin.tipoFunc == 1) {
                btnGanhos.Visible = false;
                btnRanking.Visible = false;
                btnFunc.Visible = false;
            }

            home();
        }

        //aux
        public void atribuirnumeroDeNotificacoes() {
            frmNotificacao.totalNotificacao = new bllAux().retornaNumeroDeNotificacoes();
            if (frmNotificacao.totalNotificacao > 0) {
                btnNotificacao.Visible = true;
                btnNotificacao.Text = frmNotificacao.totalNotificacao.ToString();
            } else {
                btnNotificacao.Text = "";
                btnNotificacao.Visible = false;
            }

            frmMensagens.numDeMensagens = new bllAux().retornaNumeroDeMensagens();
            if (frmMensagens.numDeMensagens > 0) {
                btnMensagens.Visible = true;
                btnMensagens.Text = frmMensagens.numDeMensagens.ToString();
            } else {
                btnMensagens.Text = "";
                btnMensagens.Visible = false;
            }
        }

        private void home() {
            panelSlideBar.Height = btnHome.Height;
            panelSlideBar.Top = btnHome.Top;
            homeUC1.BringToFront();
        }

        private void caixa() {
            panelSlideBar.Height = btnCaixa.Height;
            panelSlideBar.Top = btnCaixa.Top;
            caixaUC2.BringToFront();
            caixaUC2.carregarCmb();
            caixaUC2.txtCodigoBarras.Focus();
        }

        private void livros() {
            panelSlideBar.Height = btnLivros.Height;
            panelSlideBar.Top = btnLivros.Top;
            livroUC1.atualizar();
            livroUC1.BringToFront();
        }

        private void funcionario() {
            panelSlideBar.Height = btnFunc.Height;
            panelSlideBar.Top = btnFunc.Top;
            funcUC1.atualizar();
            funcUC1.BringToFront();
        }

        private void ranking() {
            panelSlideBar.Height = btnRanking.Height;
            panelSlideBar.Top = btnRanking.Top;
            rankingUC1.carregarGrafico();
            rankingUC1.BringToFront();
        }

        private void ganhos() {
            panelSlideBar.Height = btnGanhos.Height;
            panelSlideBar.Top = btnGanhos.Top;
            ganhosUC1.carregarGrafico("diario");
            ganhosUC1.BringToFront();
        }

        private void notificacao() {
            frm = new frmNotificacao();
            frm.Location = new Point(1100, Top);
            if (frm.ShowDialog() == DialogResult.OK) {
                atribuirnumeroDeNotificacoes();
            }
        }

        private void mensagens() {
            frmMensagens = new frmMensagens();
            frmMensagens.Location = new Point(1078, Top);
            if (frmMensagens.ShowDialog() == DialogResult.OK) {
                atribuirnumeroDeNotificacoes();
            }
        }

        private void voltar() {
            new frmLogin(true).Show();
            new frmLogin().Focus();
            this.Hide();
        }

        private void atribuirCorPadrao() {
            btnHome.BackColor = Color.FromArgb(9, 113, 174);
            btnCaixa.BackColor = Color.FromArgb(9, 113, 174);
            btnLivros.BackColor = Color.FromArgb(9, 113, 174);
            btnFunc.BackColor = Color.FromArgb(9, 113, 174);
            btnRanking.BackColor = Color.FromArgb(9, 113, 174);
            btnGanhos.BackColor = Color.FromArgb(9, 113, 174);
        }

        ///////// principal //////////
        private void btnCaixa_Click(object sender, EventArgs e) {
            caixa();
        }

        private void btnRanking_Click(object sender, EventArgs e) {
            ranking();
        }

        private void btnFunc_Click(object sender, EventArgs e) {
            funcionario();
        }

        private void btnLivros_Click(object sender, EventArgs e) {
            livros();
        }

        private void btnGanhos_Click(object sender, EventArgs e) {
            ganhos();
        }

        private void btnHome_Click(object sender, EventArgs e) {
            home();
        }

        //adicionais
        private void btnVoltar_Click(object sender, EventArgs e) {
            voltar();
        }

        private void btnSair_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnNotificacao_Click(object sender, EventArgs e) {
            notificacao();
        }

        private void frmInicio_Load(object sender, EventArgs e) {
            atribuirnumeroDeNotificacoes();
        }

        private void frmInicio_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.Left) voltar();
            if (e.Control && e.KeyCode == Keys.H) home();
            if (e.Control && e.KeyCode == Keys.C) caixa();
            if (e.Control && e.KeyCode == Keys.L) livros();
            if (e.Control && e.KeyCode == Keys.N) notificacao();
            if (e.Control && e.KeyCode == Keys.M) mensagens();

            if (btnFunc.Visible) {
                if (e.Control && e.KeyCode == Keys.F) funcionario();
                if (e.Control && e.KeyCode == Keys.G) ganhos();
                if (e.Control && e.KeyCode == Keys.R) ranking();
            }

            if (e.Control && e.Alt && e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            frmMensagens.numDeMensagens = new bllAux().retornaNumeroDeMensagens();
            if (frmMensagens.numDeMensagens > 0) {
                btnMensagens.Visible = true;
                btnMensagens.Text = frmMensagens.numDeMensagens.ToString();
            } else {
                btnMensagens.Text = "";
                btnMensagens.Visible = false;
            }
        }


        private void frmInicio_MouseClick(object sender, MouseEventArgs e) {
            foreach (Form form in Application.OpenForms) {
                if (form == frm) {
                    frm.Close();
                }
            }
        }

        private void btnMensagens_Click(object sender, EventArgs e) {
            mensagens();
        }
    }
}

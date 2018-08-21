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

namespace Livraria.Forms {
    public partial class frmInicio : Form {
        public frmInicio() {
            InitializeComponent();
        }

        //principal
        private void btnCaixa_Click(object sender, EventArgs e) {         
            panelSlideBar.Height = btnCaixa.Height;
            panelSlideBar.Top = btnCaixa.Top;
            lblTitulo.Text = "Caixa";
        }

        private void btnRanking_Click(object sender, EventArgs e) {            
            panelSlideBar.Height = btnRanking.Height;
            panelSlideBar.Top = btnRanking.Top;
            lblTitulo.Text = "Ranking de Vendas";
        }

        private void btnFunc_Click(object sender, EventArgs e) {           
            panelSlideBar.Height = btnFunc.Height;
            panelSlideBar.Top = btnFunc.Top;
            lblTitulo.Text = "Funcionários";
        }

        private void btnFornecedor_Click(object sender, EventArgs e) {
            panelSlideBar.Height = btnFornecedor.Height;
            panelSlideBar.Top = btnFornecedor.Top;
            lblTitulo.Text = "Fornecedores";
        }

        private void btnLivros_Click(object sender, EventArgs e) {
            panelSlideBar.Height = btnLivros.Height;
            panelSlideBar.Top = btnLivros.Top;
            lblTitulo.Text = "Livros";
            livroUC1.BringToFront();
            
        }

        private void btnGanhos_Click(object sender, EventArgs e) {
            panelSlideBar.Height = btnGanhos.Height;
            panelSlideBar.Top = btnGanhos.Top;
            lblTitulo.Text = "Ganhos";
        }

        //adicionais
        private void btnVoltar_Click(object sender, EventArgs e) {
            new Form1().Show();
            this.Hide();
        }

        private void btnSair_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}

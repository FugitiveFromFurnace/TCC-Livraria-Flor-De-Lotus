using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.ModeloDeDados.ModeloLogin;
using Livraria.ModeloDeDados;
using Livraria.Forms;
using System.IO;

namespace Livraria {
    public partial class frmLogin : Form {
        private Funcionario func;
        private string caminhoProjeto = Application.StartupPath + "\\capas\\";
        private bool jaLogado = false;
        public static short tipoFunc;

        public frmLogin() {
            InitializeComponent();

            txtLogin.TabIndex = 0;
            txtLogin.Focus();
        }

        public frmLogin(bool b) {
            InitializeComponent();

            jaLogado = b;

            txtLogin.TabIndex = 0;
            txtLogin.Focus();
        }

        //apoio
        private void Logar() {
            try {
                func = new Funcionario(txtLogin.Text, txtSenha.Text);
                new bllLogin().logar(func);
                this.Hide();
                new frmInicio().Show();
            }
            catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //principal
        private void btnLogar_Click(object sender, EventArgs e) {
            Logar();
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Enter) {
                Logar();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Enter) {
                Logar();
            }
        }

        private void btnSair_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e) {
            if(!jaLogado){
                IList<string> lista = new bllLogin().pegarImagens();

                foreach (string url in lista) {
                    if (File.Exists(caminhoProjeto + url)) {
                        File.Move(caminhoProjeto + url, caminhoProjeto + "excluidos\\" + url);
                    }
                }

                new daoLogin().limparAntigasImagens();
            }
        }

        private void Form1_VisibleChanged(object sender, EventArgs e) {
            txtLogin.Focus();
        }

        private void btnVerSenha_Click(object sender, EventArgs e) {
            if (txtSenha.UseSystemPasswordChar) {
                btnVerSenha.BackColor = Color.FromArgb(152, 214, 250);
                txtSenha.UseSystemPasswordChar = false;
            }
            else {
                btnVerSenha.BackColor = Color.White;
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Alt && (Keys)e.KeyChar == Keys.Control && (Keys)e.KeyChar == Keys.Escape)
                Application.Exit();
        }
    }
}

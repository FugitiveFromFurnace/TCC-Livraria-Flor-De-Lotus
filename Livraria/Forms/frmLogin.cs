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
namespace Livraria {
    public partial class Form1 : Form {
        private Funcionario func;

        public Form1() {
            InitializeComponent();
        }

        //apoio
        private void Logar() {
            try {
                func = new Funcionario(txtLogin.Text, txtSenha.Text);
                new bllLogin().logar(func);
                this.Hide();
                new frmInicio().Show();
            }
            catch (LoginException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //principal
        private void btnLogar_Click(object sender, EventArgs e) {
            Logar();
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e) {
            if((Keys)e.KeyChar == Keys.Enter) {
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
    }
}

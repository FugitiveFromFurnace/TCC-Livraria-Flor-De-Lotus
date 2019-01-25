using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime;
using System.Runtime.InteropServices;
using Livraria.ModeloDeDados.ModeloFunc;
using Livraria.ModeloDeDados;

namespace Livraria.Forms.func {
    public partial class frmCadFunc : Form {

        private Funcionario func;
        private int id;
        private bool alterando = false;

        public frmCadFunc() {
            InitializeComponent();
        }

        public frmCadFunc(int id) {
            InitializeComponent();

            btnSalvar.Visible = false;
            btnAlterar.Visible = true;
            this.AcceptButton = btnAlterar;
            alterando = true;

            try {
                func = new bllFunc().pesqAlt(id);
                this.id = id;

                txtNome.Text = func.nomeFunc;
                txtEmail.Text = func.emailFunc;
                txtCPF.Text = func.cpfFunc.Substring(0, 9);
                txtDigito.Text = func.cpfFunc.Substring(9);
                txtLogin.Text = func.loginFunc;
                txtSenha.Text = func.senhaFunc;
                txtTelefone.Text = func.telefoneFunc;
                cmbTipo.SelectedIndex = cmbTipo.FindString(func.tipo);

            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            try {
                func = new Funcionario(
                    txtNome.Text,
                    txtCPF.Text.Trim(),
                    txtEmail.Text,
                    txtLogin.Text,
                    txtSenha.Text,
                    txtTelefone.Text,
                    cmbTipo.Text
                    );

                new bllFunc().cadFunc(func, txtDigito.Text.Trim());
                MessageBox.Show(txtNome.Text + " cadastrado com sucesso", "Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            try {
                func = new Funcionario(
                    id,
                    txtNome.Text,
                    txtCPF.Text.Trim(),
                    txtEmail.Text,
                    txtLogin.Text,
                    txtSenha.Text,
                    txtTelefone.Text,
                    cmbTipo.Text
                    );

                new bllFunc().altFunc(func, txtDigito.Text.Trim());
                MessageBox.Show(txtNome.Text + " alterado com sucesso", "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCadFunc_Load(object sender, EventArgs e) {
            if (alterando)
                cmbTipo.SelectedIndex = cmbTipo.FindString(func.tipo);
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            txtCPF.Clear();
            txtDigito.Clear();
            txtEmail.Clear();
            txtLogin.Clear();
            txtNome.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();
            cmbTipo.SelectedIndex = -1;
        }
    }
}

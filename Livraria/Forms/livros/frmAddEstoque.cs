using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.ModeloDeDados.ModeloLivro;

namespace Livraria.Forms {
    public partial class frmAddEstoque : Form {

        private string tituloLivro;
        private int idLivro, qtde = 0;

        public frmAddEstoque(string tituloLivro, int id) {
            InitializeComponent();

            this.tituloLivro = tituloLivro;
            this.idLivro = id;
            label1.Text = tituloLivro;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if(txtQtde.Text == "" || !int.TryParse(txtQtde.Text, out qtde)) {
                MessageBox.Show("Valor inválido para adicionar ao estoque! Digite novamente", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(string.Format("Adicionar {0} ao estoque do livro: {1}?", txtQtde.Text, tituloLivro), "Adicionar estoque", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes) {
                try {
                    new bllLivro().addEstoque(txtQtde.Text, idLivro);
                    MessageBox.Show(string.Format("Foram adicionados {0} ao estoque com sucesso", txtQtde.Text), "Adicionados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                catch(MinhaException erro) {
                    MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

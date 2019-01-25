using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.ModeloDeDados.ModeloAuxiliar;

namespace Livraria.Forms {
    public partial class frmNotificacao : Form {

        public static int totalNotificacao;

        public frmNotificacao() {
            InitializeComponent();
        }

        private string validaString(string titulo) {
            if (titulo.Length > 18)
                return titulo.Substring(0, 15) + "...";

            return titulo;
        }

        private void validaTotalDeNotificacoes() {
            if (objLista.Items.Count < 1)
                DialogResult = DialogResult.OK;
        }

        public void carregarNotificacao() {
            List<notificacao> notificacoes = new bllAux().geraNotificacoes();
            objImagens.Images.Clear();
            objLista.Items.Clear();

            foreach (notificacao n in notificacoes) {
                ListViewItem oItem;

                objImagens.Images.Add(Image.FromFile(Application.StartupPath + "\\capas\\" + n.nomeCapa));
                oItem = objLista.Items.Add(n.livroNotificacao.ToString(), validaString(n.tituloLivroNotificacao), objImagens.Images.Count - 1);

                oItem.Font = new Font("Arial", 16, FontStyle.Bold);
                oItem.UseItemStyleForSubItems = false;

                oItem.SubItems.Add("Quantidade disponível: " + n.qtdeDisponivel.ToString()).Font = new Font("Corbel", 12, FontStyle.Regular);
                oItem.SubItems.Add("Quantidade recomendada: " + n.qtdeRecomendada.ToString()).Font = new Font("Corbel", 12, FontStyle.Regular);
            }
            validaTotalDeNotificacoes();
        }

        private void frmNotificacao_Load(object sender, EventArgs e) {
            carregarNotificacao();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void objLista_DoubleClick(object sender, EventArgs e) {
            string titulo = objLista.SelectedItems[0].Text;
            if (MessageBox.Show("Deseja aumentar a quantidade em estoque do livro: " + titulo + "?", "Aumentar quantidade em estoque", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes) {
                if (new frmAddEstoque(titulo, int.Parse(objLista.SelectedItems[0].Name)).ShowDialog() == DialogResult.OK) {
                    carregarNotificacao();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.Forms;
using Livraria.ModeloDeDados.ModeloLivro;
using Livraria.ModeloDeDados;

namespace Livraria.UCs {
    public partial class LivroUC : UserControl {

        private string caminho2 = Application.StartupPath + "//capas//";
        private int idLivro;
        private string tituloLivro;

        public LivroUC() {
            InitializeComponent();
        }

        public void resizeCollumnsDGV() {
            dgvLivro.Columns["capa"].Visible = false;

            dgvLivro.Columns[0].Width = 37;
            dgvLivro.Columns[1].Width = 240;
            dgvLivro.Columns[2].Width = 147;
            dgvLivro.Columns[3].Width = 90;
            dgvLivro.Columns[4].Width = 90;
            dgvLivro.Columns[5].Width = 119;
            dgvLivro.Columns[6].Width = 94;
            dgvLivro.Columns[7].Width = 100;
            dgvLivro.Columns[8].Width = 110;
        }

        public void atualizar() {
            dgvLivro.DataSource = new bllLivro().CarregarDGV();

            picCapa.Image = null;
            btnAddEstoque.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

            resizeCollumnsDGV();
        }

        //eventos
        private void LivroUC_Load(object sender, EventArgs e) {
            atualizar();
        }

        private void dgvLivro_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                dgvLivro.Columns["capa"].Visible = true;
                string img = dgvLivro.SelectedRows[0].Cells["capa"].Value.ToString();
                dgvLivro.Columns["capa"].Visible = false;

                try {
                    picCapa.Image = Image.FromFile(caminho2 + img);
                    tituloLivro = dgvLivro.SelectedRows[0].Cells[1].Value.ToString();
                    idLivro = Convert.ToInt32(dgvLivro.SelectedRows[0].Cells[0].Value);
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnAddEstoque.Enabled = true;
                } catch (FileNotFoundException erro) {
                    MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void btnNovo_Click(object sender, EventArgs e) {
            if (new frmCadLivro().ShowDialog() == DialogResult.OK) {
                atualizar();
                txtPesquisa.Text = "Digite o titulo do livro ou sua saga";
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            if (new frmCadLivro(idLivro).ShowDialog() == DialogResult.OK) {
                atualizar();
                txtPesquisa.Text = "Digite o titulo do livro ou sua saga";
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Tem certeza que quer excluir " + tituloLivro, "Exclusão", MessageBoxButtons.YesNoCancel) == DialogResult.Yes) {
                try {
                    new bllLivro().excLivro(idLivro);
                    MessageBox.Show(tituloLivro + " excluido com sucesso", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizar();
                    picCapa.Image = null;
                    txtPesquisa.Text = "Digite o titulo do livro ou sua saga";
                } catch (MinhaException erro) {
                    MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddEstoque_Click(object sender, EventArgs e) {
            if (new frmAddEstoque(tituloLivro, idLivro).ShowDialog() == DialogResult.OK) {
                atualizar();
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e) {
            /*dgvLivro.DataSource = new bllLivro().pesqLivro(txtPesquisa.Text);

            picCapa.Image = null;*/
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e) {
            /*if ((Keys)e.KeyChar == Keys.Enter) {
                dgvLivro.DataSource = new bllLivro().pesqLivro(txtPesquisa.Text);

                picCapa.Image = null;
            }*/
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) {
            if (txtPesquisa.Text == "") {
                atualizar();
            } else if (txtPesquisa.Text != "Digite o titulo do livro ou sua saga") {
                dgvLivro.DataSource = new bllLivro().pesqLivro(txtPesquisa.Text);

                picCapa.Image = null;
            } else {
                txtPesquisa.ForeColor = Color.Gray;
            }
        }

        private void txtPesquisa_Enter(object sender, EventArgs e) {
            if (txtPesquisa.Text == "Digite o titulo do livro ou sua saga") {
                txtPesquisa.Clear();
                txtPesquisa.ForeColor = Color.Black;
            }
        }

        private void txtPesquisa_Leave(object sender, EventArgs e) {
            if (txtPesquisa.Text == "") {
                txtPesquisa.ForeColor = Color.Gray;
                txtPesquisa.Text = "Digite o titulo do livro ou sua saga";
            }
        }
    }
}

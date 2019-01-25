using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.ModeloDeDados;
using Livraria.ModeloDeDados.ModeloLivro;
using System.Globalization;
using System.IO;

namespace Livraria.Forms {
    public partial class frmCadLivro : Form {

        private Livro cadLivro;
        private int id, qtde = 0, contLivroCad;
        private string caminhoProjeto = Application.StartupPath + "\\capas\\";
        private string caminhoSite = @"C:\xampp\htdocs\SiteTCC\capas\";
        private bool antigaImg = false, alterando = false;
        private decimal preco = 0;

        public frmCadLivro() {
            InitializeComponent();

            btnAlterar.Visible = false;
            btnSalvar.Visible = true;
            dtpData.Value = DateTime.Now;

            contLivroCad = 0;

            atualizar();
            //openFileDialog1.Filter = "png files (*.png)|*.png|jpg files (*.jpg) | *.jpeg";
        }

        public frmCadLivro(int id) {
            InitializeComponent();

            this.id = id;
            lblTituloForm.Text = "Alteração de livros";

            alterando = true;
            btnAlterar.Visible = true;
            btnSalvar.Visible = false;

            cadLivro = new bllLivro().pesqAlt(id);

            atualizar();

            txtPreco.Text = cadLivro.precoLivro.ToString("F2");
            txtCodBarras.Text = cadLivro.codigoBarras;
            txtTag.Text = cadLivro.tag;
            txtQtde.Text = cadLivro.quantidadeLivro.ToString();
            txtSinopse.Text = cadLivro.sinopseLivro.ToString();
            txtTitulo.Text = cadLivro.tituloLivro;
            dtpData.Value = cadLivro.dataLancamento;
            picCapa.Image = Image.FromFile(caminhoProjeto + cadLivro.capaLivro);

            cmbAutor.SelectedIndex = cmbAutor.FindString(cadLivro.nomeAutor);
            cmbCategoria.SelectedIndex = cmbCategoria.FindString(cadLivro.nomeCategoria);
            cmbEditora.SelectedIndex = cmbEditora.FindString(cadLivro.nomeEditora);
        }

        private void validaCamposNumericos() {
            if (txtPreco.Text.Trim() != "") {
                preco = decimal.Parse(txtPreco.Text);
            }

            if (txtQtde.Text.Trim() != "") {
                qtde = int.Parse(txtQtde.Text.Trim());
            }
        }

        private void limpar() {
            txtPreco.Clear();
            txtQtde.Clear();
            txtSinopse.Clear();
            txtTitulo.Clear();
            txtCodBarras.Clear();
            txtTag.Clear();
            cmbAutor.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            cmbEditora.SelectedIndex = -1;
            dtpData.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
            picCapa.Image = null;
        }

        private void atualizar() {
            //carregar categorias
            cmbCategoria.DataSource = new bllLivro().carregarCategorias();

            //carregar autores            
            cmbAutor.DataSource = new bllLivro().carregarAutores();

            //carregar editora
            cmbEditora.DataSource = new bllLivro().carregarEditora();

            if (alterando) {
                cmbAutor.SelectedIndex = cmbAutor.FindString(cadLivro.nomeAutor);
                cmbCategoria.SelectedIndex = cmbCategoria.FindString(cadLivro.nomeCategoria);
                cmbEditora.SelectedIndex = cmbEditora.FindString(cadLivro.nomeEditora);
            }
        }

        private void desabilitaLetras(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void frmCadLivro_Load(object sender, EventArgs e) {
            atualizar();
        }

        private void btnAddAutor_Click(object sender, EventArgs e) {
            if (new frmCadSecundarios("AUT").ShowDialog() == DialogResult.OK)
                cmbAutor.DataSource = new bllLivro().carregarAutores();
        }

        private void btnAddCategoria_Click(object sender, EventArgs e) {
            if (new frmCadSecundarios("CAT").ShowDialog() == DialogResult.OK)
                cmbCategoria.DataSource = new bllLivro().carregarCategorias();
        }

        private void btnImagem_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                picCapa.ImageLocation = openFileDialog1.FileName;
                antigaImg = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            try {
                validaCamposNumericos();

                new bllLivro().validacao(txtTitulo.Text,
                    txtCodBarras.Text,
                    txtSinopse.Text,

                    (int)cmbAutor.SelectedValue,
                    (int)cmbCategoria.SelectedValue,
                    (int)cmbEditora.SelectedValue,
                    dtpData.Value.Date,
                    preco,
                    qtde,
                    Path.GetFileName(openFileDialog1.FileName));

                if (new bllLivro().validaLivroCadastrado(txtTitulo.Text))
                    if (MessageBox.Show("Livro com este titulo já cadastrado, tem certeza que deseja cadastrar mesmo assim?", "Livro já cadastrado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                cadLivro = new Livro(txtTitulo.Text,
                    txtCodBarras.Text,
                    txtSinopse.Text,
                    txtTag.Text,
                    (int)cmbAutor.SelectedValue,
                    (int)cmbCategoria.SelectedValue,
                    (int)cmbEditora.SelectedValue,
                    dtpData.Value,
                    preco,
                    qtde,
                    Path.GetFileName(openFileDialog1.FileName));

                new bllLivro().cadLivro(cadLivro);
                MessageBox.Show(txtTitulo.Text + " cadastrado com sucesso", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!Directory.Exists(caminhoProjeto))
                    Directory.CreateDirectory(caminhoProjeto);
                if (!Directory.Exists(caminhoSite))
                    Directory.CreateDirectory(caminhoSite);

                Bitmap objBit = new Bitmap(picCapa.Image, 720, 1080);
                if (Path.GetExtension(openFileDialog1.FileName) == ".jpg") {
                    objBit.Save(caminhoProjeto + cadLivro.capaLivro, ImageFormat.Jpeg);
                    objBit.Save(caminhoSite + cadLivro.capaLivro, ImageFormat.Jpeg);
                } else if (Path.GetExtension(openFileDialog1.FileName) == ".png") {
                    objBit.Save(caminhoProjeto + cadLivro.capaLivro, ImageFormat.Png);
                    objBit.Save(caminhoSite + cadLivro.capaLivro, ImageFormat.Png);
                }

                limpar();

                contLivroCad++;
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e) {
            if (contLivroCad > 0)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            string imagem;
            try {
                if (!antigaImg) imagem = cadLivro.capaLivro;
                else imagem = Path.GetFileName(openFileDialog1.FileName);

                validaCamposNumericos();

                new bllLivro().validacao(txtTitulo.Text,
                    txtCodBarras.Text,
                    txtSinopse.Text,
                    (int)cmbAutor.SelectedValue,
                    (int)cmbCategoria.SelectedValue,
                    (int)cmbEditora.SelectedValue,
                    dtpData.Value.Date,
                    preco,
                    qtde,
                    imagem);

                cadLivro = new Livro(
                    txtTitulo.Text,
                    txtCodBarras.Text,
                    txtSinopse.Text,
                    txtTag.Text,
                    (int)cmbAutor.SelectedValue,
                    (int)cmbCategoria.SelectedValue,
                    (int)cmbEditora.SelectedValue,
                    dtpData.Value.Date,
                    preco,
                    qtde,
                    imagem);
                new bllLivro().altLivro(cadLivro, id);
                MessageBox.Show(txtTitulo.Text + " alterado com sucesso", "Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (antigaImg) {
                    Bitmap objBit = new Bitmap(picCapa.Image, 720, 1080);
                    if (Path.GetExtension(openFileDialog1.FileName) == ".jpg") {
                        objBit.Save(caminhoProjeto + cadLivro.capaLivro, ImageFormat.Jpeg);
                        objBit.Save(caminhoSite + cadLivro.capaLivro, ImageFormat.Jpeg);
                    } else if (Path.GetExtension(openFileDialog1.FileName) == ".png") {
                        objBit.Save(caminhoProjeto + cadLivro.capaLivro, ImageFormat.Png);
                        objBit.Save(caminhoSite + cadLivro.capaLivro, ImageFormat.Png);
                    }
                }
                DialogResult = DialogResult.OK;
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limpar();
        }

        private void btnAddEditora_Click(object sender, EventArgs e) {
            if (new frmCadSecundarios("EDT").ShowDialog() == DialogResult.OK) {
                cmbEditora.DataSource = new bllLivro().carregarEditora();
            }
        }
    }
}

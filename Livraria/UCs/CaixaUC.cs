using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.Forms;
using Livraria.ModeloDeDados.ModeloLivro;
using Livraria.ModeloDeDados.ModeloAuxiliar;
using Livraria.ModeloDeDados.ModeloVenda;
using Livraria.ModeloDeDados;

namespace Livraria.UCs {
    public partial class CaixaUC : UserControl {

        private Livro livroCaixa;
        private string caminhoProjeto = Application.StartupPath + "\\capas\\";
        private int cont, idCliente, idPedido, numItens;
        private bool revendo = false;
        public frmInicio frm;

        public CaixaUC(frmInicio frm) {
            InitializeComponent();

            this.frm = frm;
        }

        public CaixaUC() {
            InitializeComponent();
        }

        private void desabilitaCampos() {
            txtCodigoBarras.Enabled = false;
            cmbLivros.Enabled = false;
            txtQtde.Enabled = false;
            btnAddProduto.Enabled = false;
            dgvPedidos.Enabled = false;
            btnPedidoReservado.Enabled = false;
        }

        private void habilitaCampos() {
            txtCodigoBarras.Enabled = true;
            cmbLivros.Enabled = true;
            txtQtde.Enabled = true;
            btnAddProduto.Enabled = true;
            dgvPedidos.Enabled = true;
            btnPedidoReservado.Enabled = true;
        }

        private int retornaNumeroDeItensCarrinho() {
            int numItens = 0;
            foreach (DataGridViewRow row in dgvPedidos.Rows) {
                numItens += Convert.ToInt32(row.Cells[1].Value);
            }

            return numItens;
        }

        private void limpar() {
            dgvPedidos.Rows.Clear();
            cmbLivros.SelectedIndex = -1;
            txtPrecoTotal.Clear();
            txtPrecoUnico.Clear();
            txtQtde.Clear();
            txtCodigoBarras.Clear();
            txtQtde.Enabled = false;
            picCapa.Image = null;
            lblPreco.Text = "0,00";
            revendo = false;

            habilitaCampos();
        }

        public void carregarCmb() {
            limpar();
            cont = 0;
            cmbLivros.DataSource = new bllLivro().livrosCaixa();
            cmbLivros.SelectedIndex = -1;
        }

        private void mudarPrecoTotal() {
            double preco = 0;

            foreach (DataGridViewRow linha in dgvPedidos.Rows) {
                if (preco == 0) {
                    preco = double.Parse(linha.Cells[3].Value.ToString());
                } else {
                    preco += double.Parse(linha.Cells[3].Value.ToString());
                }
            }

            lblPreco.Text = preco.ToString("F2");
        }

        private bool adicionaExistente(string titulo) {

            int qtde = 0;

            try {
                foreach (DataGridViewRow linha in dgvPedidos.Rows) {
                    if (linha.Cells[2].Value.ToString() == titulo) {
                        qtde = int.Parse(linha.Cells[1].Value.ToString());
                        qtde += int.Parse(txtQtde.Text);
                        new bllVenda().validaQtde(qtde.ToString(), long.Parse(linha.Cells[0].Value.ToString()));
                        linha.Cells[1].Value = qtde.ToString();
                        linha.Cells[3].Value = (double.Parse(linha.Cells[3].Value.ToString()) + double.Parse(txtPrecoTotal.Text)).ToString("F2");
                        mudarPrecoTotal();
                        break;
                    }
                }

                if (qtde == 0)
                    return false;
                else
                    return true;
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;
        }

        private void mudarQtdeDgv(int index, int valorMudar) {
            int antigaQtde = int.Parse(dgvPedidos.Rows[index].Cells[1].Value.ToString());
            double precoUnico = double.Parse(dgvPedidos.Rows[index].Cells[3].Value.ToString()) / antigaQtde;

            try {
                if (valorMudar == 0)
                    dgvPedidos.Rows[index].Cells[1].Value = antigaQtde - 1;
                else {
                    new bllVenda().validaQtde((antigaQtde + valorMudar).ToString(), long.Parse(dgvPedidos.Rows[index].Cells[0].Value.ToString()));
                    dgvPedidos.Rows[index].Cells[1].Value = antigaQtde + valorMudar;
                }

                dgvPedidos.Rows[index].Cells[3].Value = (int.Parse(dgvPedidos.Rows[index].Cells[1].Value.ToString()) * precoUnico).ToString("F2");
                mudarPrecoTotal();
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addProd() {
            if (txtQtde.Text != "" && txtQtde.Text != "0") {
                try {
                    new bllVenda().validaQtde(txtQtde.Text, livroCaixa.idLivro);
                    if (!adicionaExistente(livroCaixa.tituloLivro)) {
                        DataGridViewRow item = new DataGridViewRow();
                        item.CreateCells(dgvPedidos);

                        item.Cells[0].Value = livroCaixa.idLivro;
                        item.Cells[1].Value = txtQtde.Text;
                        item.Cells[2].Value = livroCaixa.tituloLivro;
                        item.Cells[3].Value = txtPrecoTotal.Text;

                        dgvPedidos.Rows.Add(item);
                    }
                } catch (MinhaException erro) {
                    MessageBox.Show(erro.Message, "Quantidade não disponível", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("Preencha a quantidade comprada", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQtde.Focus();
            }
        }

        private void btnAddProduto_Click(object sender, EventArgs e) {
            addProd();
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e) {
            if (dgvPedidos.Rows.Count == 0) {
                MessageBox.Show("Coloque pelo menos um item no carrinho", "Carrinho vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (lblVendedor.Text == "") {
                MessageBox.Show("É necessário que um funcionário esteja logado", "Login obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.idCliente = 3;

            List<Pedido> lista = new List<Pedido>();
            foreach (DataGridViewRow linha in dgvPedidos.Rows) {
                lista.Add(new Pedido(int.Parse(linha.Cells[0].Value.ToString()), int.Parse(linha.Cells[1].Value.ToString()), double.Parse(linha.Cells[3].Value.ToString()), this.idCliente));
            }

            foreach (Pedido p in lista) {
                new bllVenda().validaQtde(txtQtde.Text, int.Parse(p.idLivro.ToString()));
            }

            if (!revendo) {
                idPedido = new bllAux().novoPedido();
                new bllVenda().salvarPedido(lista, idPedido);
            }

            numItens = retornaNumeroDeItensCarrinho();

            frmFinalizarVenda frmFinalizar = new frmFinalizarVenda(idPedido, decimal.Parse(lblPreco.Text), numItens);
            DialogResult resultado = frmFinalizar.ShowDialog();
            if (resultado == DialogResult.OK && frm != null) {
                limpar();
                frm.atribuirnumeroDeNotificacoes();
            } else if (resultado == DialogResult.OK)
                limpar();
            else if (resultado == DialogResult.Cancel) {
                new bllVenda().excluirPedido(idPedido);
            }
        }

        private void cmbLivros_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbLivros.SelectedIndex != -1 && cont == 2) {
                if (txtQtde.Text != "" || txtPrecoTotal.Text != "") {
                    txtQtde.Clear();
                    txtPrecoTotal.Clear();
                }

                livroCaixa = new bllLivro().pesqCaixa((int)cmbLivros.SelectedValue);
                picCapa.ImageLocation = caminhoProjeto + livroCaixa.capaLivro;
                txtPrecoUnico.Text = livroCaixa.precoLivro.ToString();
                txtQtde.Enabled = true;
                txtQtde.Focus();
            }
        }

        private void CaixaUC_Load(object sender, EventArgs e) {
            lblVendedor.Text = frmInicio.nomeFunc;

            carregarCmb();
            limpar();
        }

        private void txtQtde_TextChanged(object sender, EventArgs e) {
            if (txtQtde.Text != "")
                txtPrecoTotal.Text = (int.Parse(txtQtde.Text) * double.Parse(txtPrecoUnico.Text)).ToString("F2");
            else
                txtPrecoTotal.Clear();
        }

        private void dgvPedidos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            mudarPrecoTotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            limpar();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == dgvPedidos.Columns[4].Index) {
                mudarQtdeDgv(e.RowIndex, 0);

                if (dgvPedidos.Rows[e.RowIndex].Cells[1].Value.ToString() == "0")
                    dgvPedidos.Rows.RemoveAt(e.RowIndex);
            }
            if (e.ColumnIndex == dgvPedidos.Columns[5].Index) {
                mudarQtdeDgv(e.RowIndex, 1);
            }
            if (e.ColumnIndex == dgvPedidos.Columns[6].Index) {
                dgvPedidos.Rows.RemoveAt(e.RowIndex);
                mudarPrecoTotal();
            }
        }

        private void cmbLivros_Click(object sender, EventArgs e) {
            cont = 2;
        }

        private void CaixaUC_VisibleChanged(object sender, EventArgs e) {
            lblVendedor.Text = frmInicio.nomeFunc;

            carregarCmb();
            limpar();
        }

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }

            if ((Keys)e.KeyChar == Keys.Enter) {
                addProd();
            }
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }

            if ((Keys)e.KeyChar == Keys.Enter) {
                try {
                    livroCaixa = new bllLivro().pesqCaixaCodBarras(txtCodigoBarras.Text);

                    picCapa.ImageLocation = caminhoProjeto + livroCaixa.capaLivro;
                    txtPrecoUnico.Text = livroCaixa.precoLivro.ToString();
                    txtPrecoTotal.Clear();
                    txtQtde.Enabled = true;
                    txtQtde.Focus();
                } catch (MinhaException erro) {
                    MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPedidoReservado_Click(object sender, EventArgs e) {
            if (lblVendedor.Text == "") {
                MessageBox.Show("É necessário que um funcionário esteja logado", "Login obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            new frmBuscaLivroReservado().ShowDialog();
        }

        private void cmbLivros_KeyPress(object sender, KeyPressEventArgs e) {
            cont = 2;
        }

        private void cmbLivros_Enter(object sender, EventArgs e) {
            cont = 2;
        }

        private void txtCodigoBarras_Enter(object sender, EventArgs e) {
            if (txtCodigoBarras.Text == "Digite o código de barras") {
                txtCodigoBarras.Clear();
                txtCodigoBarras.ForeColor = Color.Black;
            }
        }

        private void txtCodigoBarras_Leave(object sender, EventArgs e) {
            if (txtCodigoBarras.Text == "") {
                txtCodigoBarras.Text = "Digite o código de barras";
                txtCodigoBarras.ForeColor = Color.Gray;
            }
        }
    }
}

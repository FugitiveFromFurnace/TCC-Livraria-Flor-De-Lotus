using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.ModeloDeDados;
using Livraria.ModeloDeDados.ModeloVenda;

namespace Livraria.Forms {
    public partial class frmBuscaLivroReservado : Form {
        private double valorTotalPedido = 0;

        public frmBuscaLivroReservado() {
            InitializeComponent();
        }

        private void pesquisar() {
            try {
                string msg = "Valor total do pedido: R$@total";

                List<Pedido> livrosReservados = new bllVenda().pesquisaPedidoReservado(txtEmail.Text);
                objImagens.Images.Clear();
                objLista.Items.Clear();
                panel1.Visible = false;
                panel2.Visible = true;
                valorTotalPedido = 0;
                this.Size = this.MaximumSize;


                foreach (Pedido p in livrosReservados) {
                    ListViewItem oItem;

                    objImagens.Images.Add(Image.FromFile(Application.StartupPath + "\\capas\\" + p.capaLivro));
                    oItem = objLista.Items.Add(p.idPedido.ToString(), p.tituloLivro, objImagens.Images.Count - 1);

                    oItem.Font = new Font("Arial", 16, FontStyle.Bold);
                    oItem.UseItemStyleForSubItems = false;

                    oItem.SubItems.Add("Quantidade pedida: " + p.qtde.ToString()).Font = new Font("Corbel", 14, FontStyle.Regular);
                    oItem.SubItems.Add("Quantidade preço do pedido: " + (p.qtde * p.valorPedido).ToString("F2")).Font = new Font("Corbel", 14, FontStyle.Regular);

                    valorTotalPedido += p.qtde * p.valorPedido;
                }

                lblTotal.Text = msg.Replace("@total", valorTotalPedido.ToString("F2"));
            }
            catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisa_Click(object sender, EventArgs e) {
            pesquisar();
        }

        private void btnConfirmar_Click(object sender, EventArgs e) {
            string preco = lblTotal.Text;
            preco = preco.Substring(preco.IndexOf("$"));
            preco = preco.Replace("$", "");
            frmFinalizarVenda frm = new frmFinalizarVenda(int.Parse(objLista.Items[0].Name), decimal.Parse(preco), objLista.Items.Count);
            this.Close();
            frm.ShowDialog();            
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void btnPesqOutroPedido_Click(object sender, EventArgs e) {
            objImagens.Images.Clear();
            objLista.Items.Clear();
            panel2.Visible = false;
            panel1.Visible = true;
            this.Size = this.MinimumSize;
            txtEmail.Focus();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Enter)
                pesquisar();
        }
    }
}

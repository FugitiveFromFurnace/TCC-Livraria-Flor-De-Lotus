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
using Livraria.ModeloDeDados.ModeloVenda;
using Livraria.ModeloDeDados.ModeloAuxiliar;
using Livraria.ModeloDeDados;

namespace Livraria.Forms {
    public partial class frmFinalizarVenda : Form {

        private int idPedido, vezesPagamento = 0, idDesconto = 0;
        private decimal subTotal;

        public frmFinalizarVenda(int idPedido, decimal total, int qtdeItensPedido) {
            InitializeComponent();

            cmbPagamento.SelectedIndex = 0;

            this.subTotal = total;
            lblSubtotal.Text = subTotal.ToString("F2");

            if (qtdeItensPedido == 1) {
                total *= Convert.ToDecimal(0.95);
                grpDesconto.Visible = false;
            } else if (qtdeItensPedido == 2)
                total *= Convert.ToDecimal(0.90);
            else if (qtdeItensPedido == 3)
                total *= Convert.ToDecimal(0.85);
            else
                total *= Convert.ToDecimal(0.75);

            lblDesconto.Text = total.ToString("F2");
            lblTotalAPagar.Text = total.ToString("F2");

            this.idPedido = idPedido;
            txtDesconto.Focus();
        }

        private void disponibilizaParcelas(decimal total) {
            if (total <= 30) {
                panelEscolhaCredito.Visible = false;
                vezesPagamento = 1;
            } else {
                panelEscolhaCredito.Visible = true;
                int valorMinimoParcela = Convert.ToInt32(total / 30);

                switch (valorMinimoParcela) {
                    case 1: btn1x.Visible = true; break;
                    case 2: btn1x.Visible = true; btn2x.Visible = true; break;
                    case 3: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; break;
                    case 4: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; break;
                    case 5: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; btn5x.Visible = true; break;
                    case 6: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; btn5x.Visible = true; btn6x.Visible = true; break;
                    case 7: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; btn5x.Visible = true; btn6x.Visible = true; btn7x.Visible = true; break;
                    case 8: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; btn5x.Visible = true; btn6x.Visible = true; btn7x.Visible = true; btn8x.Visible = true; break;
                    case 9: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; btn5x.Visible = true; btn6x.Visible = true; btn7x.Visible = true; btn8x.Visible = true; btn9x.Visible = true; break;
                    case 10: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; btn5x.Visible = true; btn6x.Visible = true; btn7x.Visible = true; btn8x.Visible = true; btn9x.Visible = true; btn10x.Visible = true; break;
                    default: btn1x.Visible = true; btn2x.Visible = true; btn3x.Visible = true; btn4x.Visible = true; btn5x.Visible = true; btn6x.Visible = true; btn7x.Visible = true; btn8x.Visible = true; btn9x.Visible = true; btn10x.Visible = true; break;
                }
            }
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Enter) {
                try {
                    lblTotalAPagar.Text = new bllAux().buscaDesconto(txtDesconto.Text, lblSubtotal.Text, lblTotalAPagar.Text, ref idDesconto).ToString("F2");
                    decimal valorDesconto = decimal.Parse(lblSubtotal.Text) - decimal.Parse(lblTotalAPagar.Text);
                    lblDesconto.Text = (decimal.Parse(lblSubtotal.Text) - valorDesconto).ToString("F2");
                    subTotal = decimal.Parse(lblDesconto.Text);

                    if (panelEscolhaCredito.Visible)
                        disponibilizaParcelas(subTotal);
                } catch (MinhaException erro) {
                    MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbPagamento_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbPagamento.SelectedIndex == 1) {
                disponibilizaParcelas(subTotal);
            } else {
                panelEscolhaCredito.Visible = false;
                vezesPagamento = 1;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void btn1x_Click(object sender, EventArgs e) {
            vezesPagamento = 1;
        }

        private void btn2x_Click(object sender, EventArgs e) {
            vezesPagamento = 2;
        }

        private void btn3x_Click(object sender, EventArgs e) {
            vezesPagamento = 3;
        }

        private void btn4x_Click(object sender, EventArgs e) {
            vezesPagamento = 4;
        }

        private void btn5x_Click(object sender, EventArgs e) {
            vezesPagamento = 5;
        }

        private void btn6x_Click(object sender, EventArgs e) {
            vezesPagamento = 6;
        }

        private void btn7x_Click(object sender, EventArgs e) {
            vezesPagamento = 7;
        }

        private void btn8x_Click(object sender, EventArgs e) {
            vezesPagamento = 8;
        }

        private void btn9x_Click(object sender, EventArgs e) {
            vezesPagamento = 9;
        }

        private void btn10x_Click(object sender, EventArgs e) {
            vezesPagamento = 10;
        }

        private void btnFinalizar_Click(object sender, EventArgs e) {
            try {
                if (lblDesconto.Text != "0,00")
                    subTotal = decimal.Parse(lblDesconto.Text);

                if (vezesPagamento == 0) {
                    MessageBox.Show("Cliente não realizou pagamento", "Não pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Venda venda = new Venda(idPedido, frmInicio.idFunc, DateTime.Parse(DateTime.Now.ToShortDateString()), subTotal, vezesPagamento);

                new bllVenda().vender(venda);

                MessageBox.Show("Venda feita com sucesso", "Vendido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (idDesconto != 0)
                    new bllAux().desabilitarDesconto(idDesconto);

                DialogResult = DialogResult.OK;
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e) {
            if ((cmbPagamento.SelectedIndex == 0 || cmbPagamento.SelectedIndex == -1) && (vezesPagamento == 0)) {
                MessageBox.Show("Escolha a forma de pagamento", "Forma de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblTotalAPagar.Text = "0,00";
        }
    }
}

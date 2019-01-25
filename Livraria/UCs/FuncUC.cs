using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.ModeloDeDados.ModeloFunc;
using Livraria.Forms.func;

namespace Livraria.UCs {
    public partial class FuncUC : UserControl {

        private int idFunc;
        private string nomeFunc;

        public FuncUC() {
            InitializeComponent();
        }

        public void atualizar() {
            dgvFunc.DataSource = new bllFunc().carregarDGV();

            dgvFunc.Columns[0].Width = 93;
            dgvFunc.Columns[1].Width = 130;
            dgvFunc.Columns[2].Width = 109;
            dgvFunc.Columns[3].Width = 100;
            dgvFunc.Columns[4].Width = 222;
            dgvFunc.Columns[5].Width = 90;
            dgvFunc.Columns[6].Width = 100;
            dgvFunc.Columns[7].Width = 100;
        }

        private void FuncUC_Load(object sender, EventArgs e) {
            atualizar();
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            if (new frmCadFunc().ShowDialog() == DialogResult.OK)
                atualizar();
        }

        private void dgvFunc_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                idFunc = int.Parse(dgvFunc.SelectedRows[0].Cells[0].Value.ToString());
                nomeFunc = dgvFunc.SelectedRows[0].Cells[1].Value.ToString();

                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Deseja excluir o(a) " + nomeFunc + "?", "Exclusão", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes) {
                try {
                    new bllFunc().excFunc(idFunc);
                    MessageBox.Show(nomeFunc + " excluido com sucesso", "Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atualizar();
                } catch (MinhaException erro) {
                    MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            if (new frmCadFunc(idFunc).ShowDialog() == DialogResult.OK)
                atualizar();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.Forms;

namespace Livraria.UCs {
    public partial class LivroUC : UserControl {

        private string caminho2 = Application.StartupPath + "//capas//";
        private int idLivro;
        private string tituloLivro;

        public LivroUC() {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e) {
            new frmCadLivro().Show();
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            new frmAltLivro(idLivro).Show();
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Tem certeza que quer excluir " + tituloLivro, "Exclusão",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
            }
        }

        //eventos
        private void dgvLivro_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0) {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dgvLivro.Rows[index];
                dgvLivro.Columns["LivroImagem"].Visible = true;
                string img = selectedRow.Cells[7].Value.ToString();
                dgvLivro.Columns["LivroImagem"].Visible = false;

                tituloLivro = selectedRow.Cells[1].Value.ToString();
                idLivro = Convert.ToInt32(selectedRow.Cells[0].Value);
                picCapa.Image = Image.FromFile(caminho2 + img);
            }
        }
    }
}

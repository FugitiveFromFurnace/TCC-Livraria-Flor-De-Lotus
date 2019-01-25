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
    public partial class frmCadSecundarios : Form {

        private string tabela;

        public frmCadSecundarios(string tabela) {
            InitializeComponent();

            this.tabela = tabela;
        }

        private void btnSalvar_Click(object sender, EventArgs e) {
            try {
                switch (tabela) {
                    case "EDT": new bllAux().cadEditora(txtNome.Text.Trim()); break;
                    case "AUT": new bllAux().cadAutor(txtNome.Text.Trim()); break;
                    case "CAT": new bllAux().cadCategoria(txtNome.Text.Trim()); break;
                }

                MessageBox.Show(txtNome.Text + " cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch(MinhaException erro) {
                MessageBox.Show(erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

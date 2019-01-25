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
    public partial class frmClienteVenda : Form {

        public static int idCliente;

        public frmClienteVenda() {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e) {
            try {
               idCliente = new bllAux().verificaCliente(txtCPF.Text);
                if(idCliente == -1) {
                    if (MessageBox.Show("Cliente não cadastrado, deseja se cadastrar?", "Sem cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                        //form de cadastro cliente
                    }
                    else
                        this.DialogResult = DialogResult.Cancel;
                }
                else {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch(MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

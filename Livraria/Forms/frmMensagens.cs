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
using Livraria.ModeloDeDados;

namespace Livraria.Forms {
    public partial class frmMensagens : Form {
        private string email;
        public static int numDeMensagens;

        public frmMensagens() {
            InitializeComponent();
        }

        private void validaTotalDeNotificacoes() {
            if (objLista.Items.Count < 1)
                DialogResult = DialogResult.OK;
        }

        private void carregarMensagens() {
            List<Contato> contatos = new bllAux().geraMensagens();            
            objLista.Items.Clear();

            foreach (Contato c in contatos) {
                ListViewItem oItem;
                email = c.emailCliente;

                oItem = objLista.Items.Add(c.emailCliente.Replace("<", "").Replace(">", ""), c.idContato);

                oItem.Font = new Font("Arial", 16, FontStyle.Bold);
                oItem.UseItemStyleForSubItems = false;

                oItem.SubItems.Add("Mensagem: " + c.mensagemContato).Font = new Font("Corbel", 12, FontStyle.Regular);
            }

            validaTotalDeNotificacoes();
        }

        private void frmMensagens_Load(object sender, EventArgs e) {
            carregarMensagens();
        }

        private void btnVoltar_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void objLista_DoubleClick(object sender, EventArgs e) {          
            int id = objLista.SelectedItems[0].ImageIndex;
            string msg = objLista.SelectedItems[0].SubItems[1].Text;
            msg = msg.Substring(msg.IndexOf("Mensagem: ")).Trim();
            if (new frmResponderMsg(email, id, msg).ShowDialog() == DialogResult.OK) {
                carregarMensagens();
            }
        }
    }
}

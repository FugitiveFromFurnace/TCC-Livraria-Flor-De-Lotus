using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using Livraria.ModeloDeDados.ModeloAuxiliar;

namespace Livraria.Forms {
    public partial class frmResponderMsg : Form {

        private string emailCliente, emailLib;
        private int idContato;
        MailMessage mail;
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587 /* TLS */);
        MailAddress remetente, destinatario;
        public frmResponderMsg(string emailCliente, int idMensagem, string mensagem) {
            InitializeComponent();

            this.emailCliente = emailCliente;
            this.idContato = idMensagem;
            txtMensagem.Text = mensagem.Remove(0, 9).Trim();
            this.emailLib = "livrariaflorlotus@gmail.com";

            lblEmailCliente.Text = emailCliente.ToUpper();

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            emailCliente = emailCliente.Replace("<", "");

            remetente = new MailAddress(emailLib, "Livraria Flor de Lotus");
            destinatario = new MailAddress(emailCliente.Remove(emailCliente.IndexOf('>')));

            smtp.Credentials = new NetworkCredential(emailLib, "FlorLotus");

            mail = new MailMessage(remetente, destinatario);

            emailCliente = emailCliente.Remove(emailCliente.IndexOf('>'));

            fontDialog1.Font = txtResposta.Font;

        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnFonte_Click(object sender, EventArgs e) {
            if (fontDialog1.ShowDialog() == DialogResult.OK) {
                txtResposta.Font = fontDialog1.Font;
                txtMensagem.Font = fontDialog1.Font;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e) {
            if (txtResposta.Text == "") {
                MessageBox.Show("Mensagem vazia!", "Mensagem vazia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mail.Subject = "Resposta";
            mail.Body = txtResposta.Text;
            mail.IsBodyHtml = true;

            try {
                smtp.SendMailAsync(mail);
            }
            catch(Exception erro) {
                MessageBox.Show("Não é possível responder email agora, tente novamente mais tarde!", "Impossível enviar resposta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                
            }

            MessageBox.Show(string.Format("Resposta para {0} enviado!", emailCliente), "Email enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new bllAux().atualizarMensagem(idContato);

            this.DialogResult = DialogResult.OK;
        }
    }
}

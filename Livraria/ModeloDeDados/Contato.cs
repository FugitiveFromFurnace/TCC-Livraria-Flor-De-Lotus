using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Contato {

        public int idContato { get; set; }
        public int idClienteContato { get; set; }
        public string emailCliente { get; set; }
        public string mensagemContato { get; set; }
        public DateTime dataContato { get; set; }
        public int idAssunto { get; set; }

        public Contato(int idContato, string email, string mensagem) {
            this.idContato = idContato;
            this.emailCliente = email;
            this.mensagemContato = mensagem;
        }
    }
}

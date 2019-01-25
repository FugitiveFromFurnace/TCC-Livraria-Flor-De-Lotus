using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria {
    class notificacao {

        public int idNotificacao { get; set; }
        public int livroNotificacao { get; set; }
        public string tituloLivroNotificacao { get; set; }
        public int qtdeRecomendada { get; set; }
        public int qtdeDisponivel { get; set; }
        public string nomeCapa { get; set; }

        public notificacao(int livro, string titulo, int qtdeRec, int qtdeDis, string img) {
            this.livroNotificacao = livro;
            this.tituloLivroNotificacao = titulo;
            this.qtdeRecomendada = qtdeRec;
            this.qtdeDisponivel = qtdeDis;
            this.nomeCapa = img;
        }

    }
}

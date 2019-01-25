using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Pedido {

        public Int64 idPedido { get; set; }
        public Int64 idLivro { get; set; }
        public Int64 idCliente { get; set; }
        public int qtde { get; set; }
        public double valorTotalPedido { get; set; }
        public double valorPedido { get; set; }
        public string tituloLivro { get; set; }
        public string capaLivro { get; set; }

        public Pedido(int idLivro, int qtde, double valorTotal, int idCli) {
            this.idLivro = idLivro;
            this.qtde = qtde;
            this.valorTotalPedido = valorTotal;
            this.idCliente = idCli;
        }

        public Pedido(int pedido, int livro, string titulo, int qtde, string capa, double valor) {
            this.idPedido = pedido;
            this.idLivro = livro;
            this.tituloLivro = titulo;
            this.qtde = qtde;
            this.capaLivro = capa;
            this.valorPedido = valor;
        }
    }
}

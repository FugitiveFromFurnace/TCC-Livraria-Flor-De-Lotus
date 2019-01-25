using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Grafico {

        public string dataVenda { get; set; }
        public decimal valorTotal { get; set; }
        public string tituloLivro { get; set; }
        public int qtdeVendida { get; set; }

        //para grafico de ganhos
        public Grafico(string data, decimal valor) {
            this.dataVenda = data;
            this.valorTotal = valor;
        }

        //para grafico de ranking
        public Grafico(string titulo, int qtde, string data) {
            this.tituloLivro = titulo;
            this.qtdeVendida = qtde;
            this.dataVenda = data;
        }
    }
}

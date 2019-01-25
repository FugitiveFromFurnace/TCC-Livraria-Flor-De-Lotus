using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Venda {

        public Int64 idVenda { get; set; }
        public Int64 pedidoVenda { get; set; }
        public Int64 idFunc { get; set; }
        public DateTime dataVenda { get; set; }
        public decimal valorTotal { get; set; }
        public int vezesPag { get; set; }

        public Venda(int pedido, int idFuncionario, DateTime data, decimal total, int vezes) {
            this.pedidoVenda = pedido;
            this.idFunc = idFuncionario;
            this.dataVenda = data;
            this.valorTotal = total;
            this.vezesPag = vezes;
        }
    }
}

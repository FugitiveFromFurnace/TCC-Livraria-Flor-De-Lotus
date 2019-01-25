using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados.ModeloVenda {
    class bllVenda {
        internal void salvarPedido(List<Pedido> pedidos, int idPedido) {
            if (pedidos.Count == 0)
                throw new MinhaException("Nenhum pedido salvo");

            new daoVenda().salvarPedido(pedidos, idPedido);
        }

        internal void excluirPedido(int idPedido) {
            new daoVenda().excluirPedido(idPedido);
        }

        internal List<Pedido> pesquisaPedidoReservado(string email) {
            if (email == "")
                throw new MinhaException("Preencha o código");

            try {
                return new daoVenda().pesquisaPedidoReservado(email);
            }
            catch(MinhaException erro) {
                throw new MinhaException(erro.Message);
            }
        }

        internal void vender(Venda venda) {
            new daoVenda().vender(venda);
        }

        internal void validaQtde(string qtde, long id) {
            int qtdeInt = int.Parse(qtde);
            int qtdeDisp = 0;

            if (new daoVenda().validaQtde(qtdeInt, id, ref qtdeDisp))
                throw new MinhaException("Quantidade insuficiente, " + qtdeDisp + " é o máximo dispónivel");
            
        }
    }
}

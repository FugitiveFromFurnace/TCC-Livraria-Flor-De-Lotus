using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Livraria.ModeloDeDados.ModeloVenda {
    class daoVenda : Conexao{

        internal void salvarPedido(List<Pedido> pedidos, int idPedido) {
            foreach (Pedido ped in pedidos) {
                cmd = new MySqlCommand();
                cmd.CommandText = "insert into pedido(idPedido, idLivroPedido, idClientePedido, qtdePedido) value(@idPedido, @idLivro, @cliente, @qtde)";
                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                cmd.Parameters.AddWithValue("@idLivro", ped.idLivro);
                cmd.Parameters.AddWithValue("@cliente", ped.idCliente);
                cmd.Parameters.AddWithValue("@qtde", ped.qtde);
                cmd.Connection = con;

                if (cmd.ExecuteNonQuery() < 1)
                    throw new MinhaException("Erro ao salvar pedido, tente novamente");
            }
        }

        internal List<Pedido> pesquisaPedidoReservado(string email) {
            cmd.CommandText = "select idPedido, livros.idLivro, tituloLivro, qtdePedido, capaLivro, precoLivro from pedido inner join livros on pedido.idLivroPedido = livros.idLivro where pedidoFinalizado = 2 and idClientePedido = (select idCliente from cliente where emailCliente = @email)";
            cmd.Parameters.AddWithValue("@email", email);
            dados = cmd.ExecuteReader();

            List<Pedido> lista = new List<Pedido>();

            while (dados.Read()) {
                lista.Add(new Pedido(dados.GetInt16(0), dados.GetInt16(1), dados.GetString(2), dados.GetInt16(3), dados.GetString(4), dados.GetDouble(5)));
            }

            if (lista.Count == 0)
                throw new MinhaException("Pedido não encontrado!");

            return lista;
        }

        internal void excluirPedido(int idPedido) {
            cmd.CommandText = "delete from pedido where idPedido = @idPedido";
            cmd.Parameters.AddWithValue("@idPedido", idPedido);
            cmd.ExecuteNonQuery();
        }

        internal void vender(Venda venda) {
            cmd.CommandText = "call prc_Vender(@pedido, @func, @total)";
            cmd.Parameters.AddWithValue("@pedido", venda.pedidoVenda);
            cmd.Parameters.AddWithValue("@func", venda.idFunc);
            cmd.Parameters.AddWithValue("@total", venda.valorTotal);
            //cmd.Parameters.AddWithValue("@vezes", venda.vezesPag);            
            cmd.ExecuteNonQuery();
        }

        internal bool validaQtde(int qtde, long id, ref int disp) {
            cmd.CommandText = "select qtdeLivro from livros where idLivro = @id";
            cmd.Parameters.AddWithValue("@id", id);
            dados = cmd.ExecuteReader();

            if (dados.Read() && dados.GetInt16(0) < qtde) {
                disp = dados.GetInt16(0);
                return true;
            }
            else
                return false;
        }
    }
}

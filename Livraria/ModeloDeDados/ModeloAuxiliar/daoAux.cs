using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Livraria.ModeloDeDados.ModeloAuxiliar {
    class daoAux : Conexao {

        internal List<Grafico> carregarGraficoRanking() {
            cmd.CommandText = "select * from view_ranking";
            dados = cmd.ExecuteReader();
            List<Grafico> lista = new List<Grafico>();

            while (dados.Read()) {
                lista.Add(new Grafico(dados.GetString(0), dados.GetInt32(1), dados.GetString(2)));
            }

            return lista;
        }

        internal List<Contato> geraMensagens() {
            cmd.CommandText = "select * from view_mensagens where Assunto != 5";
            dados = cmd.ExecuteReader();

            List<Contato> lista = new List<Contato>();
            while (dados.Read())
                lista.Add(new Contato(dados.GetInt32(0), dados.GetString("Email"), dados.GetString("Mensagem")));

            return lista;
        }

        internal void cadAutor(string nome) {
            cmd.CommandText = "insert into autor(nomeAutor) value(@nomeAutor)";
            cmd.Parameters.AddWithValue("@nomeAutor", nome);
            cmd.ExecuteNonQuery();
        }

        internal int verificaCliente(string cpf) {
            cmd.CommandText = "select idCliente ID from cliente where cpfCliente = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            dados = cmd.ExecuteReader();

            if (!dados.HasRows)
                return -1;
            else {
                int id = int.Parse(dados["ID"].ToString());
                return id;
            }

        }

        internal int retornaNumeroDeMensagens() {
            cmd.CommandText = "select count(*) from contatos where idAssunto != 5";
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        internal List<notificacao> geraNotificacoes() {
            cmd.CommandText = "call prc_geraNotificacao()";
            dados = cmd.ExecuteReader();

            List<notificacao> lista = new List<notificacao>();
            while (dados.Read()) {
                lista.Add(new notificacao(dados.GetInt32(0), dados.GetString(1), dados.GetInt32(2), dados.GetInt32(3), dados.GetString(4)));
            }

            return lista;
        }

        internal void cadEditora(string text) {
            cmd.CommandText = "insert into editora(nomeEditora) value(@nomeEditora)";
            cmd.Parameters.AddWithValue("@nomeEditora", text);           
            cmd.ExecuteNonQuery();
        }

        internal void cadCategoria(string p) {
            cmd.CommandText = "insert into categoria(nomeCategoria) value(@nomeCategoria)";
            cmd.Parameters.AddWithValue("@nomeCategoria", p);
            cmd.ExecuteNonQuery();
        }

        internal int retornaNumeroDeNotificacoes() {
            cmd.CommandText = "call prc_geraNotificacao()";

            cmd.ExecuteNonQuery();

            cmd.CommandText = "select count(*) from notificacao";
            return int.Parse(cmd.ExecuteScalar().ToString());
        }

        internal void atualizarMensagem(int idContato) {
            cmd.CommandText = "update contatos set idAssunto = 5 where idContato = @id";
            cmd.Parameters.AddWithValue("@id", idContato);
            cmd.ExecuteNonQuery();
        }

        internal int novoPedido() {
            cmd.CommandText = "select IFNULL(max(idPedido), 0) + 1 from pedido;";
            dados = cmd.ExecuteReader();

            dados.Read();
            return dados.GetInt32(0);
        }

        internal void desabilitarDesconto(int idDesconto) {
            cmd.CommandText = "update descontos set utilizado = true where idDesconto = @id";
            cmd.Parameters.AddWithValue("@id", idDesconto);
            cmd.ExecuteNonQuery();
        }

        internal List<Grafico> carregarGrafico(string query, string periodo) {
            cmd.CommandText = query;

            dados = cmd.ExecuteReader();

            List<Grafico> lista = new List<Grafico>();

            if (periodo == "diario") {
                while (dados.Read()) {
                    lista.Add(new Grafico(dados.GetDateTime("data").ToShortDateString(), dados.GetDecimal("valor")));
                }
            } else {
                while (dados.Read()) {
                    lista.Add(new Grafico(dados.GetString("data"), dados.GetDecimal("valor")));
                }
            }

            dados.Close();
            return lista;
        }

        internal decimal buscaDesconto(string nomeDesconto, string subTotal, string totalPago, ref int IDdesconto) {
            decimal desconto, total = decimal.Parse(totalPago);

            cmd.CommandText = "select * from descontos where nomeDesconto like @desconto and utilizado = false";
            cmd.Parameters.AddWithValue("@desconto", nomeDesconto);
            dados = cmd.ExecuteReader();

            if (!dados.HasRows)
                throw new MinhaException("Cupom não encontrado");

            dados.Read();

            // retornando o id do desconto
            IDdesconto = dados.GetInt32(0);

            desconto = decimal.Parse(dados["valorDesconto"].ToString());
            if (dados.GetString("tipoDesconto") == "Direto") {
                if (desconto >= total)
                    throw new MinhaException("Cupom inválido para essa compra!");
            } else {
                desconto = decimal.Parse(subTotal) * (desconto / 100);
            }

            return total - desconto;
        }

        internal string estimativaGanhos(ref string ganhosAtual) {
            cmd.CommandText = "call prc_retornaPercentual()";
            dados = cmd.ExecuteReader();
            dados.Read();
            ganhosAtual = dados.GetString(0);
            dados.Close();

            cmd.CommandText = "select format(sum(valorTotal) / 2, '2') Total from venda where month(dataVenda) between (month(now()) - 2) and (month(now()) - 1)";
            dados = cmd.ExecuteReader();
            dados.Read();

            return dados.GetString(0);
        }
    }
}

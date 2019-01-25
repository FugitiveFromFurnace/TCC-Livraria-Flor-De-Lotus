using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados.ModeloAuxiliar {
    class bllAux {
        internal void cadAutor(string nome) {
            if (nome == "") {
                throw new MinhaException("Preencha o nome do autor");
            }
            new daoAux().cadAutor(nome);
        }

        internal void cadCategoria(string p) {
            if (p == "")
                throw new MinhaException("Preencha o nome da categoria");

            new daoAux().cadCategoria(p);
        }

        internal List<Contato> geraMensagens() {
            return new daoAux().geraMensagens();
        }

        internal List<Grafico> carregarGraficoRanking() {
            return new daoAux().carregarGraficoRanking();
        }

        internal int verificaCliente(string cpf) {
            if (cpf == "" || cpf.Length < 11)
                throw new MinhaException("Preencha o CPF corretamente");

            return new daoAux().verificaCliente(cpf);
        }

        internal List<notificacao> geraNotificacoes() {
            return new daoAux().geraNotificacoes();
        }

        internal void cadEditora(string text) {
            if (text == "")
                throw new MinhaException("Preencha o nome da editora");

            new daoAux().cadEditora(text);
        }

        internal int retornaNumeroDeMensagens() {
            return new daoAux().retornaNumeroDeMensagens();
        }

        internal int novoPedido() {
            return new daoAux().novoPedido();
        }

        internal decimal buscaDesconto(string nomeDesconto, string subTotal, string totalPago, ref int idDesconto) {
            if (nomeDesconto == "")
                throw new MinhaException("Preencha o nome do cupom");

            try {
                decimal desconto = new daoAux().buscaDesconto(nomeDesconto, subTotal, totalPago, ref idDesconto);                               

                return desconto;
            }
            catch (MinhaException e) {
                throw new MinhaException(e.Message);
            }
        }

        internal List<Grafico> carregarGrafico(string periodo) {
            string query = "";
            switch (periodo) {
                case "diario":
                    query = "select date(dataVenda) data, sum(valorTotal) valor from venda group by date(dataVenda) order by data";
                    break;
                case "mensal":
                    query = "select * from view_meses";
                    break;
                case "anual":
                    query = "select year(dataVenda) data, sum(valorTotal) valor from venda group by year(dataVenda) order by data";
                    break;
            }

            return new daoAux().carregarGrafico(query, periodo);
        }

        internal void atualizarMensagem(int idContato) {
            new daoAux().atualizarMensagem(idContato);
        }

        internal int retornaNumeroDeNotificacoes() {
            return new daoAux().retornaNumeroDeNotificacoes();
        }

        internal string estimativaGanhos(ref string percentual) {
            return new daoAux().estimativaGanhos(ref percentual);
        }

        internal void desabilitarDesconto(int idDesconto) {
            new daoAux().desabilitarDesconto(idDesconto);
        }
    }
}

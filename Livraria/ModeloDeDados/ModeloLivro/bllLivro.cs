using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace Livraria.ModeloDeDados.ModeloLivro {
    class bllLivro {
        internal void validacao(string titulo, string codBar, string sinopse, int autor, int categoria, int editora, DateTime data, decimal preco, int qtde, string path) {
            if (titulo == "" || codBar == "" || editora == -1 || sinopse == "" || qtde == 0 || preco == 0 || data.ToString() == "" || path == "")
                throw new MinhaException("Preencha todos os campos");
        }
        
        internal void excLivro(int idLivro) {
            if (idLivro < 0)
                throw new MinhaException("Item escolhido é inválido");
            int x = new daoLivro().excluirLivro(idLivro);

            if (x < 1)
                throw new MinhaException("Erro ao excluir");
        }

        internal DataTable CarregarDGV() {
            return new daoLivro().CarregarDGV();
        }

        internal DataTable carregarCategorias() {
            return new daoLivro().carregarCategorias();
        }

        internal DataTable livrosCaixa() {
            return new daoLivro().livrosCaixa();
        }

        internal DataTable carregarAutores() {
            return new daoLivro().carregarAutores();
        }


        internal DataTable carregarEditora() {
            return new daoLivro().carregarEditora();
        }

        internal Livro pesqAlt(int id) {
            return new daoLivro().pesqAlt(id);
        }

        internal void cadLivro(Livro cadLivro) {
            if (cadLivro.tituloLivro == "" || cadLivro.codigoBarras == "" || cadLivro.editoraLivro == -1 || cadLivro.sinopseLivro == "" || cadLivro.quantidadeLivro.ToString() == "" || cadLivro.precoLivro.ToString() == "" || cadLivro.dataLancamento.ToString() == "" || cadLivro.capaLivro == "")
                throw new MinhaException("Preencha todos os campos");
            
            cadLivro.dataLancamento = DateTime.Parse(string.Format("{0:yyyy/MM/dd}", cadLivro.dataLancamento));
            new daoLivro().cadLivro(cadLivro);
        }

        internal Livro pesqCaixa(int selectedValue) {
            return new daoLivro().pesqCaixa(selectedValue);
        }

        internal void addEstoque(string text, int id) {
            if (text == "")
                throw new MinhaException("Preencha a quantidade que entrará no estoque");
            new daoLivro().addEstoque(text, id);
        }                                                                                                   

        internal void altLivro(Livro cadLivro, int id) {
            if (cadLivro.tituloLivro == "" || cadLivro.codigoBarras == "" || cadLivro.editoraLivro == -1 || cadLivro.sinopseLivro == "" || cadLivro.quantidadeLivro.ToString() == "" || cadLivro.precoLivro.ToString() == "" || cadLivro.dataLancamento.ToString() == "" || cadLivro.capaLivro == "")
                throw new MinhaException("Preencha todos os campos");
            
            cadLivro.dataLancamento = DateTime.Parse(string.Format("{0:yyyy/MM/dd}", cadLivro.dataLancamento));
            new daoLivro().altLivro(cadLivro, id);
        }

        internal DataTable pesqLivro(string p) {
            return new daoLivro().pesqLivro(p);
        }

        internal Livro pesqCaixaCodBarras(string text) {
            if (text == "")
                throw new MinhaException("Insira o código de barras do produto");

            Livro livro = new daoLivro().pesqCaixaCodBarras(text);
            if (livro == null)
                throw new MinhaException("Livro não cadastrado no sistema");

            return livro;
        }

        internal bool validaLivroCadastrado(string titulo) {
            return new daoLivro().validaLivroCadastrado(titulo);
        }
    }
}

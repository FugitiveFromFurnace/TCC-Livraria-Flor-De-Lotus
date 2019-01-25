using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Livro {

        public Int64 idLivro { get; set; }
        public string tituloLivro { get; set; }
        public string sinopseLivro { get; set; }
        public string tag { get; set; }
        public string codigoBarras { get; set; }
        public Int16 autorLivro { get; set; }
        public string nomeAutor { get; set; }
        public string nomeCategoria { get; set; }        
        public Int16 categoriaLivro { get; set; }
        public Int16 editoraLivro { get; set; }
        public string nomeEditora { get; set; }       
        public DateTime dataLancamento { get; set; }
        public decimal precoLivro { get; set; }
        public Int64 quantidadeLivro { get; set; }
        public string antigaImagem { get; set; }
        public string capaLivro { get; set; }

        public Livro() {

        }

        //salvar e alterar
        public Livro(string titulo, string codBar, string sinopse, string tag, int autor, int categoria, int editora, DateTime data, decimal preco, int qtde, string urlImg) {
            this.tituloLivro = titulo;
            this.codigoBarras = codBar;
            this.sinopseLivro = sinopse;
            this.tag = tag;
            this.autorLivro = Convert.ToInt16(autor);
            this.categoriaLivro = Convert.ToInt16(categoria);
            this.editoraLivro = Convert.ToInt16(editora);
            this.dataLancamento = Convert.ToDateTime(data);
            this.precoLivro = Convert.ToDecimal(preco);
            this.quantidadeLivro = Convert.ToInt64(qtde);
            this.capaLivro = urlImg;
        }

        //pesquisa
        public Livro(int id ,string titulo, string codBar, string sinopse, string tag, string autor, string categoria, string editora, DateTime data, decimal preco, int qtde, string urlImg) {
            this.idLivro = id;
            this.tituloLivro = titulo;
            this.codigoBarras = codBar;
            this.sinopseLivro = sinopse;
            this.tag = tag;
            this.nomeAutor = autor;
            this.nomeCategoria = categoria;
            this.nomeEditora = editora;
            this.dataLancamento = Convert.ToDateTime(data);
            this.precoLivro = Convert.ToDecimal(preco);
            this.quantidadeLivro = Convert.ToInt64(qtde);
            this.capaLivro = urlImg;
        }

        //para comboBox caixa
        public Livro(int id, string titulo) {
            this.idLivro = id;
            this.tituloLivro = titulo;
        }

        //preencher caixa
        public Livro(int id, string titulo, decimal preco, string capa) {
            this.idLivro = id;
            this.tituloLivro = titulo;
            this.precoLivro = preco;
            this.capaLivro = capa;
        }

        //notificação
        public Livro(int id, string titulo, int qtde) {
            this.idLivro = id;
            this.tituloLivro = titulo;
            this.quantidadeLivro = qtde;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Livraria.ModeloDeDados.ModeloLivro {
    class daoLivro : Conexao{

        //alterar para colocar invalido
        internal int excluirLivro(int idLivro) {
            cmd.CommandText = "delete from livros where idLivro = @idLivro";
            cmd.Parameters.AddWithValue("@idLIvro", idLivro);
            cmd.Connection = con;

            return cmd.ExecuteNonQuery();
        }

        internal DataTable livrosCaixa() {
            MySqlDataAdapter adpt = new MySqlDataAdapter("select idLivro, tituloLivro from livros order by tituloLivro", con);
            DataTable table = new DataTable();

            adpt.Fill(table);

            return table;
        }

        internal Livro pesqCaixa(int selectedValue) {
            cmd.CommandText = "select idLivro, tituloLivro, precoLivro, capaLivro from livros where idLivro = @id";
            cmd.Parameters.AddWithValue("@id", selectedValue);
            cmd.Connection = con;

            dados = cmd.ExecuteReader();

            if (dados.Read())
                return new Livro(int.Parse(dados[0].ToString()),
                    dados[1].ToString(),
                    decimal.Parse(dados[2].ToString()),
                    dados[3].ToString());
            else
                return null;

        }

        internal Livro pesqAlt(int id) {
            Livro livro = null;

            cmd.CommandText = "select COD, Titulo, codigoBarras, sinopseLivro, tag, dataLancamento, Preco, Quantidade, Autor, Categoria, Capa, Editora from view_livroCompleto inner join livros on COD = idLivro where COD = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;

            dados = cmd.ExecuteReader();

            if (dados.Read()) {
                livro = new Livro(
                    dados.GetInt32("COD"),
                    dados.GetString("Titulo"),
                    dados.GetString("codigoBarras"),
                    dados.GetString("sinopseLivro"),
                    dados.GetString("tag"),
                    dados.GetString("Autor"),
                    dados.GetString("Categoria"),
                    dados.GetString("Editora"),
                    DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dados.GetString("dataLancamento"))),
                    dados.GetDecimal("Preco"),
                    dados.GetInt32("Quantidade"),
                    dados.GetString("capa"));

                livro.antigaImagem = livro.capaLivro;
            }

            return livro;
        }

        internal DataTable CarregarDGV() {
            MySqlDataAdapter adpt = new MySqlDataAdapter("select * from view_livroCompleto", con);
            DataTable table = new DataTable();

            adpt.Fill(table);

            return table;
        }

        internal Livro pesqCaixaCodBarras(string codigoBarras) {
            cmd.CommandText = "select idLivro, tituloLivro, precoLivro, capaLivro from livros where codigoBarras = @codBar";
            cmd.Parameters.AddWithValue("@codBar", codigoBarras);
            cmd.Connection = con;

            dados = cmd.ExecuteReader();

            if (dados.Read())
                return new Livro(int.Parse(dados[0].ToString()),
                    dados[1].ToString(),
                    decimal.Parse(dados[2].ToString()),
                    dados[3].ToString());
            else
                return null;
        }

        internal void altLivro(Livro cadLivro, int id) {
            cmd.CommandText = "update livros set tituloLivro = @titulo, codigoBarras = @codBar, sinopseLivro = @sinopse, tag = @tag, autorLivro = @autor, categoriaLivro = @categoria, dataLancamento = @data, precoLivro = @preco, capaLivro = @capa, qtdeLivro = @qtde, editoraLivro = @editora where idLivro = @id";
            cmd.Parameters.AddWithValue("@titulo", cadLivro.tituloLivro);
            cmd.Parameters.AddWithValue("@codBar", cadLivro.codigoBarras);
            cmd.Parameters.AddWithValue("@sinopse", cadLivro.sinopseLivro);           
            cmd.Parameters.AddWithValue("@tag", cadLivro.tag);           
            cmd.Parameters.AddWithValue("@autor", cadLivro.autorLivro);
            cmd.Parameters.AddWithValue("@categoria", cadLivro.categoriaLivro);
            cmd.Parameters.AddWithValue("@data", cadLivro.dataLancamento);
            cmd.Parameters.AddWithValue("@preco", cadLivro.precoLivro);            
            cmd.Parameters.AddWithValue("@capa", cadLivro.capaLivro);
            cmd.Parameters.AddWithValue("@qtde", cadLivro.quantidadeLivro);
            cmd.Parameters.AddWithValue("@editora", cadLivro.editoraLivro);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Connection = con;

            if (cmd.ExecuteNonQuery() <= 0)
                throw new MinhaException("Erro ao alterar, tente novamente");
        }

        internal bool validaLivroCadastrado(string titulo) {
            cmd.CommandText = "select idLivro from livros where tituloLivro like @titulo";
            cmd.Parameters.AddWithValue("@titulo", titulo);
            dados = cmd.ExecuteReader();

            return dados.HasRows ? true : false;
        }

        internal void addEstoque(string text, int id) {
            cmd.CommandText = "update livros set qtdeLivro = qtdeLivro + @qtde where idLivro = @id";
            cmd.Parameters.AddWithValue("@qtde", text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }

        internal DataTable carregarCategorias() {
            MySqlDataAdapter adpt = new MySqlDataAdapter("select * from categoria order by nomeCategoria", con);
            DataTable table = new DataTable();

            adpt.Fill(table);

            return table;
        }

        internal DataTable carregarAutores() {
            MySqlDataAdapter adpt = new MySqlDataAdapter("select * from autor order by nomeAutor", con);
            DataTable table = new DataTable();

            adpt.Fill(table);

            return table;
        }

        internal DataTable carregarEditora() {
            MySqlDataAdapter adpt = new MySqlDataAdapter("select * from editora order by nomeEditora", con);
            DataTable table = new DataTable();

            adpt.Fill(table);

            return table;
        }

        internal void cadLivro(Livro cadLivro) {
            cmd.CommandText = "insert into livros(tituloLivro, codigoBarras, tag, sinopseLivro, autorLivro, categoriaLivro, dataLancamento, precoLivro, capaLivro, qtdeLivro, editoraLivro) value(@tituloLivro, @codBar, @tag, @sinopseLivro, @autorLivro, @categoriaLivro, @dataLancamento, @precoLivro, @capaLivro, @qtdeLivro, @editoraLivro)";
            cmd.Parameters.AddWithValue("@tituloLivro", cadLivro.tituloLivro);
            cmd.Parameters.AddWithValue("@codBar", cadLivro.codigoBarras);
            cmd.Parameters.AddWithValue("@tag", cadLivro.tag);
            cmd.Parameters.AddWithValue("@sinopseLivro", cadLivro.sinopseLivro);
            cmd.Parameters.AddWithValue("@autorLivro", cadLivro.autorLivro);
            cmd.Parameters.AddWithValue("@categoriaLivro", cadLivro.categoriaLivro);
            cmd.Parameters.AddWithValue("@dataLancamento", cadLivro.dataLancamento);
            cmd.Parameters.AddWithValue("@precoLivro", cadLivro.precoLivro);
            cmd.Parameters.AddWithValue("@capaLivro", cadLivro.capaLivro);
            cmd.Parameters.AddWithValue("@qtdeLivro", cadLivro.quantidadeLivro);
            cmd.Parameters.AddWithValue("@editoraLivro", cadLivro.editoraLivro);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }

        internal DataTable pesqLivro(string p) {
            string query = "select * from view_livroCompleto where Titulo like '@pesq%' or Saga like '@pesq%' order by Titulo";
            query = query.Replace("@pesq", p);
            MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
            DataTable table = new DataTable();

            adpt.Fill(table);

            return table;
        }
    }
}

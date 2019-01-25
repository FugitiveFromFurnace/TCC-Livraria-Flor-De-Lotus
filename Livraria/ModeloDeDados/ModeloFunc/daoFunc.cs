using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Livraria.ModeloDeDados.ModeloFunc {
    class daoFunc : Conexao {

        internal DataTable carregarDGV() {
            string query = "select idFuncionario ID, nomeFuncionario nome, cpfFuncionario CPF, telefoneFuncionario Telefone, emailFuncionario Email, loginFuncionario Login, senhaFuncionario Senha, if(tipoFuncionario = 1, 'Funcionario', 'Gerente') Tipo from funcionario";
            MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
            DataTable table = new DataTable();

            adpt.Fill(table);

            return table;
        }

        internal void cadFunc(Funcionario func) {
            using (con) {
                cmd.CommandText = "insert into funcionario(nomeFuncionario, cpfFuncionario, telefoneFuncionario, emailFuncionario, loginFuncionario, senhaFuncionario, tipoFuncionario) value(@nomeFuncionario, @cpfFuncionario, @telefoneFuncionario, @emailFuncionario, @loginFuncionario, @senhaFuncionario, @tipoFuncionario)";
                cmd.Parameters.AddWithValue("@nomeFuncionario", func.nomeFunc);
                cmd.Parameters.AddWithValue("@cpfFuncionario", func.cpfFunc);
                cmd.Parameters.AddWithValue("@telefoneFuncionario", func.telefoneFunc);
                cmd.Parameters.AddWithValue("@emailFuncionario", func.emailFunc);
                cmd.Parameters.AddWithValue("@loginFuncionario", func.loginFunc);
                cmd.Parameters.AddWithValue("@senhaFuncionario", func.senhaFunc);
                cmd.Parameters.AddWithValue("@tipoFuncionario", func.tipoFunc);

                cmd.Connection = con;
                if (cmd.ExecuteNonQuery() < 1)
                    throw new MinhaException("Erro ao salvar, tente de novo");
            }
        }

        internal Funcionario pesqAlt(int id) {
            using (con) {
                cmd.CommandText = "select idFuncionario ID, nomeFuncionario Nome, cpfFuncionario CPF, emailFuncionario Email, loginFuncionario Login, senhaFuncionario Senha, telefoneFuncionario Telefone, if(tipoFuncionario = 1, 'Funcionario', 'Gerente') Tipo from funcionario where idFuncionario = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                dados = cmd.ExecuteReader();

                Funcionario funcPesq = null;

                if (dados.Read()) {
                    funcPesq = new Funcionario(
                        int.Parse(dados[0].ToString()),
                        dados[1].ToString(),
                        dados[2].ToString(),
                        dados[3].ToString(),
                        dados[4].ToString(),
                        dados[5].ToString(),
                        dados[6].ToString(),
                        dados[7].ToString());

                    return funcPesq;
                } else {
                    if (funcPesq == null)
                        throw new MinhaException("Erro ao consultar funcionário, tente novamente");
                    return funcPesq;
                }
            }
        }

        internal void altFunc(Funcionario func) {

            cmd.CommandText = "update funcionario set nomeFuncionario = @nome,cpfFuncionario = @cpf, telefoneFuncionario = @telefone, tipoFuncionario = @tipo, emailFuncionario = @email, loginFuncionario = @login, senhaFuncionario = @senha where idFuncionario = @id";
            cmd.Parameters.AddWithValue("@nome", func.nomeFunc);
            cmd.Parameters.AddWithValue("@cpf", func.cpfFunc);
            cmd.Parameters.AddWithValue("@telefone", func.telefoneFunc);
            cmd.Parameters.AddWithValue("@tipo", func.tipoFunc);
            cmd.Parameters.AddWithValue("@email", func.emailFunc);
            cmd.Parameters.AddWithValue("@login", func.loginFunc);
            cmd.Parameters.AddWithValue("@senha", func.senhaFunc);
            cmd.Parameters.AddWithValue("@id", func.idFunc);

            if (cmd.ExecuteNonQuery() < 1)
                throw new MinhaException("Erro ao alterar, tente novamente");
        }

        internal void excFunc(int idFunc) {
            cmd.CommandText = "delete from funcionario where idFuncionario = @id";
            cmd.Parameters.AddWithValue("@id", idFunc);
            cmd.Connection = con;

            if (cmd.ExecuteNonQuery() < 1)
                throw new MinhaException("Erro ao excluir, tente novamente");
        }
    }
}

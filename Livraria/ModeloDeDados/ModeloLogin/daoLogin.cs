using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Livraria.Forms;

namespace Livraria.ModeloDeDados.ModeloLogin {
    class daoLogin : Conexao{

        internal IList<string> pegarImagens() {
            using (con) {
                cmd.CommandText = "select * from antigaImagem";
                dados = cmd.ExecuteReader();

                IList<string> lista = new List<string>();
                while (dados.Read())
                    lista.Add(dados[0].ToString());

                return lista;
            }
        }

        internal void limparAntigasImagens() {
            cmd.CommandText = "delete from antigaImagem";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }

        internal void log(Funcionario func) {
            using (con) {
                cmd.CommandText = "select idFuncionario, loginFuncionario, senhaFuncionario, nomeFuncionario, tipoFuncionario from funcionario where loginFuncionario = @loginFunc and senhaFuncionario = @senhaFunc";
                cmd.Parameters.AddWithValue("@loginFunc", func.loginFunc);
                cmd.Parameters.AddWithValue("@senhaFunc", func.senhaFunc);
                cmd.Connection = con;

                dados = cmd.ExecuteReader();
                if (!dados.HasRows)
                    throw new MinhaException("Login ou senha inválidos");

                dados.Read();
                frmInicio.nomeFunc = dados[3].ToString();
                frmInicio.idFunc = int.Parse(dados[0].ToString());

                frmLogin.tipoFunc = dados.GetInt16(4);
            }
        }
    }
}

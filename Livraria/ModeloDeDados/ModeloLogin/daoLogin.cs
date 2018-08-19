using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Livraria.ModeloDeDados.ModeloLogin {
    class daoLogin {

        MySqlConnection con = new MySqlConnection();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dados;

        internal int log(Funcionario func) {
            int resultado = 0;
            using (con) {
                con.ConnectionString = "server=localhost;user=root;pwd=1234;database=livrariaFinal;port=3306";
                cmd.CommandType = CommandType.Text;
                con.Open();

                cmd.CommandText = "select loginFunc, senhaFunc from funcionario where loginFunc = @loginFunc and senhaFunc = @senhaFunc";
                cmd.Parameters.AddWithValue("@loginFunc", func.loginFunc);
                cmd.Parameters.AddWithValue("@senhaFunc", func.senhaFunc);
                cmd.Connection = con;

                dados = cmd.ExecuteReader();
                if (dados.Read())
                    if (dados["loginFunc"].ToString() == func.loginFunc && dados["senhaFunc"].ToString() == func.senhaFunc)
                        resultado = 1;

                return resultado;
            }
        }
    }
}

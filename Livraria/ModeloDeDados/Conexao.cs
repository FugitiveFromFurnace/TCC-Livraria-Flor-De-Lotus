using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Livraria.ModeloDeDados {
    class Conexao {
        protected MySqlConnection con = new MySqlConnection("server=localhost;user=root;pwd=1234;database=livrariaFinal;port=3306;sslmode=none");
        protected MySqlCommand cmd = new MySqlCommand();
        protected MySqlDataReader dados;

        public Conexao(){
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
        }

        ~Conexao() {
            con.Close();
        }

    }
}

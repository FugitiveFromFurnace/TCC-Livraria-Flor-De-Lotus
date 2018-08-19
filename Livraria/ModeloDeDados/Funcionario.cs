using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Funcionario {
        public int idFunc { get; private set; }
        public string nomeFunc { get; set; }
        public string cpfFunc { get; set; }
        public string cepFunc { get; set; }
        public string enderecoFunc { get; set; }
        public string numCasaFunc { get; set; }
        public string loginFunc { get; set; }
        public string senhaFunc { get; set; }

        public Funcionario(string login, string senha) {
            this.loginFunc = login;
            this.senhaFunc = senha;
        }

        public Funcionario() { }

    }
}

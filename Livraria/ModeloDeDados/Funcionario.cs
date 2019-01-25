using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.ModeloDeDados {
    class Funcionario {

        public int idFunc { get; private set; }
        public string nomeFunc { get; set; }
        public string cpfFunc { get; set; }        
        public string telefoneFunc { get; set; }
        public string tipo { get; set; }
        public Int16 tipoFunc { get; set; }
        public string emailFunc { get; set; }
        public string loginFunc { get; set; }
        public string senhaFunc { get; set; }

        public Funcionario(string login, string senha) {
            this.loginFunc = login;
            this.senhaFunc = senha;
        }

        //salvar
        public Funcionario(string nome, string cpf, string email, string login, string senha, string telefone, string tipo) {
            this.nomeFunc = nome;
            this.cpfFunc = cpf;
            this.emailFunc = email;
            this.loginFunc = login;
            this.senhaFunc = senha;
            this.telefoneFunc = telefone;
            this.tipoFunc = Convert.ToInt16(tipo == "Funcionário" ? 1 : 2);
        }

        public Funcionario(int id, string nome, string cpf, string email, string login, string senha, string telefone, string tipo) {
            this.idFunc = id;
            this.nomeFunc = nome;
            this.cpfFunc = cpf;
            this.emailFunc = email;
            this.loginFunc = login;
            this.senhaFunc = senha;
            this.telefoneFunc = telefone;
            this.tipo = tipo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados.ModeloLogin {
    class bllLogin {

        internal IList<string> pegarImagens() {
            return new daoLogin().pegarImagens();
        }

        internal void logar(Funcionario func) {
            if (func.loginFunc == "" || func.senhaFunc == "") {
                throw new MinhaException("Preencha todos os campos");
            }

            new daoLogin().log(func);
        }
    }
}

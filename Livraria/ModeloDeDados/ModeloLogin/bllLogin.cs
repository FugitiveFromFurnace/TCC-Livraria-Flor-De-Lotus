using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados.ModeloLogin {
    class bllLogin {
        internal void logar(Funcionario func) {
            if(func.loginFunc == "" || func.senhaFunc == "") {
                throw new LoginException("Preencha todos os campos");
            }
            int resultado = new daoLogin().log(func);
            if (resultado == 0) {
                throw new LoginException("Login ou senha inválidos");
            }
        }
    }
}

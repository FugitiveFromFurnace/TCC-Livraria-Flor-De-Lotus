using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Livraria.ModeloDeDados;

namespace Livraria.ModeloDeDados.ModeloFunc {
    class bllFunc {

        private void validacao(Funcionario func, string digitos) {
            if (func.nomeFunc == "" || func.emailFunc == "" || func.cpfFunc == "" || func.loginFunc == "" || func.senhaFunc == "" || func.tipo == "Selecione..." || (func.cpfFunc + digitos).Length != 11)
                throw new MinhaException("Preencha todos os campos corretamente");
            validaCPF(int.Parse(func.cpfFunc), digitos);

            if (func.emailFunc.IndexOf('@') == -1 || func.emailFunc.IndexOf('.') == -1)
                throw new MinhaException("Email incorreto");

            func.cpfFunc += digitos;

            func.tipoFunc = Convert.ToInt16(func.tipo == "Gerente" ? 2 : 1);

        }

        private bool validaNumIguaisCPF(string cpf) {
            int contNumIguais = 0;

            char primeiroNum = cpf[0];

            for(int i = 1; i < cpf.Length; i++) {
                if (primeiroNum == cpf[i]) {
                    contNumIguais++;
                    continue;
                }
                break;
            }

            return contNumIguais == 10 ? true : false;             
        }

        private void validaCPF(int cpf, string digito) {
            if (validaNumIguaisCPF(cpf.ToString() + digito))
                throw new MinhaException("CPF inválido");


            int cont, soma, resto, digitoObr;
            int[] _cpf = new int[10];
            int[] multiplicador = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (cont = 0; cont < 9; cont++)
                _cpf[cont] = int.Parse(cpf.ToString().Substring(cont, 1));

            for (cont = 0; cont < 9; cont++)
                _cpf[cont] = _cpf[cont] * multiplicador[cont];

            soma = _cpf.Aggregate(0, (x, y) => x + y);            

            resto = soma % 11;
            if (resto < 2)
                digitoObr = 0;
            else
                digitoObr = 11 - resto;

            if (digito.Substring(0, 1) != digitoObr.ToString()) {
                throw new MinhaException("CPF incorreto");
            }

            _cpf[9] = digitoObr;
            multiplicador = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;

            for (cont = 0; cont < 9; cont++)
                _cpf[cont] = Convert.ToInt16(cpf.ToString().Substring(cont, 1));

            for (cont = 0; cont < 10; cont++)
                _cpf[cont] = _cpf[cont] * multiplicador[cont];

            for (cont = 0; cont < 10; cont++)
                soma += _cpf[cont];

            resto = soma % 11;

            if (resto < 2)
                digitoObr = 0;
            else
                digitoObr = 11 - resto;

            if (digito.Substring(1, 1) != digitoObr.ToString())
                throw new MinhaException("CPF errado");
        }

        internal Funcionario pesqAlt(int id) {
            Funcionario func = new daoFunc().pesqAlt(id);
            if (func == null)
                throw new MinhaException("Erro ao pesquisar tente de novo");

            return func;
        }

        internal void excFunc(int idFunc) {
            new daoFunc().excFunc(idFunc);
        }

        internal DataTable carregarDGV() {
            return new daoFunc().carregarDGV();
        }

        internal void cadFunc(Funcionario func, string digitos) {
            validacao(func, digitos);

            new daoFunc().cadFunc(func);

        }

        internal void altFunc(Funcionario func, string text) {
            validacao(func, text);

            new daoFunc().altFunc(func);
        }
    }
}

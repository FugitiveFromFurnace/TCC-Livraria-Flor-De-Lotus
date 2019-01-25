using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Categoria {

        private Int32 idCategoria;
        private string nomeCategoria;

        public Int32 IdCategoria {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public string NomeCategoria {
            get { return nomeCategoria; }
            set { nomeCategoria = value; }
        }

        public Categoria(string nome, int id) {
            this.nomeCategoria = nome;
            this.idCategoria = id;
        }
    }
}

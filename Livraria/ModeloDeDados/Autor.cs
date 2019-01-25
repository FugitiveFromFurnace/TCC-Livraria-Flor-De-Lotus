using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.ModeloDeDados {
    class Autor {

        private Int32 idAutor;
        private string nomeAutor;

        public Int32 IdAutor {
            get { return idAutor; }
            set { idAutor = value; }
        }

        public string NomeAutor {
            get { return nomeAutor; }
            set { nomeAutor = value; }
        }

        public Autor(string nome, int id) {
            this.nomeAutor = nome;
            this.idAutor = Convert.ToInt16(id);
        }

    }
}

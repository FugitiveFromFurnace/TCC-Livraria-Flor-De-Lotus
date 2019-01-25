using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria {
    class MaisVendidos {

        public string imagem { get; set; }
        public string titulo { get; set; }
        public string preco { get; set; }
        public int id { get; set; }

        public MaisVendidos(string img, string titulo, string preco, int id) {
            this.imagem = img;
            this.titulo = titulo;
            this.preco = preco;
            this.id = id;
        }

    }
}

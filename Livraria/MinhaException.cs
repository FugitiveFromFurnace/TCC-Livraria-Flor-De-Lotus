using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria {
    class MinhaException : Exception {

        public MinhaException(string msg) : base(msg){
        }
    }
}

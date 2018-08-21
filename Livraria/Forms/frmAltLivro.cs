using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livraria.Forms {
    public partial class frmAltLivro : Form {

        private int idLivro;

        public frmAltLivro(int id) {
            InitializeComponent();

            this.idLivro = id;
        }
    }
}

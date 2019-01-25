using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Livraria.ModeloDeDados;
using Livraria.ModeloDeDados.ModeloAuxiliar;
using LiveCharts.Wpf;
using LiveCharts;

namespace Livraria.UCs {
    public partial class RankingUC : UserControl {
        public RankingUC() {
            InitializeComponent();
        }

        private string validaTamanhoTitutlo(string titulo) {
            char[] letras = titulo.ToCharArray();
            string novoTitulo = "";

            if (letras.Length >= 7) {
                for (int i = 0; i < 7; i++) {
                    novoTitulo += letras[i].ToString();
                }

                novoTitulo += "...";
                return novoTitulo;
            }

            return titulo;
        }

        public void carregarGrafico() {
            try {
                Func<double, string> formatFunc = (x) => string.Format("{0}", x);
                List<Grafico> lista = new bllAux().carregarGraficoRanking();

                cartesianChart1.Series.Clear();
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();

                ChartValues<int> chartv = new ChartValues<int>();
                IList<string> datasLegenda = new List<string>();
                foreach (Grafico c in lista) {

                    chartv.Add(c.qtdeVendida);

                    datasLegenda.Add(c.tituloLivro);
                }

                var converter = new System.Windows.Media.BrushConverter();
                var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#0971AE");
                var preenche = (System.Windows.Media.Brush)converter.ConvertFromString("#00000000");

                cartesianChart1.Series = new SeriesCollection { new ColumnSeries { Title = "Mais vendidos", Values = chartv, Fill = brush, } };

                brush = (System.Windows.Media.Brush)converter.ConvertFromString("#000000");
                cartesianChart1.AxisX.Add(new Axis {
                    Title = "Titulo dos livros",
                    Labels = datasLegenda,
                    Foreground = brush,
                    FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                    FontSize = 12,
                    Separator = new Separator { Step = 2}
                });

                cartesianChart1.AxisY.Add(new Axis {
                    Title = "Quantidade vendida",
                    LabelFormatter = formatFunc,
                    Foreground = brush,
                    FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                    FontSize = 12,
                });

                cartesianChart1.LegendLocation = LegendLocation.Right;

            }
            catch (Exception erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Livraria.ModeloDeDados.ModeloAuxiliar;
using Livraria.ModeloDeDados;
using LiveCharts;
using LiveCharts.Wpf;
using System.Drawing;

namespace Livraria.UCs {
    public partial class GanhosUC : UserControl {

        public GanhosUC() {
            InitializeComponent();

            rdbDiario.Checked = true;
        }

        private void mudarLabelEstimativa() {
            string estimativaMensal = "R$@ganhos";
            string percentualGanho = "";
            string mes = "Percentual de ganhos em comparação \n ao mês de @mes";
            int numMes;
            numMes = DateTime.Today.AddMonths(-1).Month;
            mes = mes.Replace("@mes", geraNomeMes(numMes));
            estimativaMensal = estimativaMensal.Replace("@ganhos", new bllAux().estimativaGanhos(ref percentualGanho));

            lblTituloPorcento.Text = mes;
            lblEstimativa.Text = estimativaMensal;
            lblPorcentagem.Text = percentualGanho;

            if (decimal.Parse(lblPorcentagem.Text.Substring(0, lblPorcentagem.Text.IndexOf("%"))) >= 0)
                lblPorcentagem.ForeColor = Color.MediumSeaGreen;
            else
                lblPorcentagem.ForeColor = Color.Red;
        }

        private string geraNomeMes(int mes) {
            string nomeMes = "";

            switch (mes) {
                case 1: nomeMes = "Janeiro"; break;
                case 2: nomeMes = "Fevereiro"; break;
                case 3: nomeMes = "Março"; break;
                case 4: nomeMes = "Abril"; break;
                case 5: nomeMes = "Maio"; break;
                case 6: nomeMes = "Junho"; break;
                case 7: nomeMes = "Julho"; break;
                case 8: nomeMes = "Agosto"; break;
                case 9: nomeMes = "Setembro"; break;
                case 10: nomeMes = "Outubro"; break;
                case 11: nomeMes = "Novembro"; break;
                case 12: nomeMes = "Dezembro"; break;
            }

            return nomeMes;
        }

        public void carregarGrafico(string radio) {
            try {
                int contLegenda = 0;

                if (rdbDiario.Checked)
                    radio = "diario";
                else if (rdbMensal.Checked)
                    radio = "mensal";
                else
                    radio = "anual";

                List<Grafico> lista = new bllAux().carregarGrafico(radio);

                cartesianChart1.Series.Clear();
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();

                ChartValues<decimal> chartv = new ChartValues<decimal>();
                IList<string> datasLegenda = new List<string>();
                foreach (Grafico c in lista) {
                    contLegenda++;

                    chartv.Add(c.valorTotal);

                    /*if (contLegenda % 5 == 0 && contLegenda != 0)
                        continue;*/

                    datasLegenda.Add(c.dataVenda);
                }

                var converter = new System.Windows.Media.BrushConverter();
                var brush = (System.Windows.Media.Brush)converter.ConvertFromString("#0971AE");
                var preenche = (System.Windows.Media.Brush)converter.ConvertFromString("#00000000");

                cartesianChart1.Series = new SeriesCollection { new LineSeries { Title = "Ganhos", Values = chartv, Stroke = brush, Fill = preenche } };

                brush = (System.Windows.Media.Brush)converter.ConvertFromString("#000000");
                cartesianChart1.AxisX.Add(new Axis {
                    Title = "Dias",
                    Labels = datasLegenda,
                    Foreground = brush,
                    FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                    FontSize = 12,
                    Separator = new Separator { Step = 2.0},
                });

                cartesianChart1.AxisY.Add(new Axis {
                    Title = "Vendas",
                    LabelFormatter = value => value.ToString("C"),
                    Foreground = brush,
                    FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                    FontSize = 12,
                });

                cartesianChart1.LegendLocation = LegendLocation.Right;

                mudarLabelEstimativa();
            } catch (MinhaException erro) {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GanhosUC_Load(object sender, EventArgs e) {
            carregarGrafico("diario");
        }

        private void rdbDiario_CheckedChanged(object sender, EventArgs e) {
            if (rdbDiario.Checked)
                carregarGrafico("diario");
        }

        private void rdbMensal_CheckedChanged(object sender, EventArgs e) {
            if (rdbMensal.Checked)
                carregarGrafico("mensal");
        }

        private void rdbAnual_CheckedChanged(object sender, EventArgs e) {
            if (rdbAnual.Checked)
                carregarGrafico("anual");
        }
    }
}

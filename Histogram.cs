using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace PowerPlan
{
    public partial class Histogram : Form
    {
        public List<double> VetorValoresHistograma = new List<double>();
        public int QuantidadeClassesHistograma;
        public int GrandezaSaida;

        public Histogram()
        {
            InitializeComponent();
        }

        public Histogram(List<double> vetor_valores_histograma, int quantidade_classes_histograma, int grandeza_saida)
        {
            InitializeComponent();

            this.VetorValoresHistograma = vetor_valores_histograma;
            this.QuantidadeClassesHistograma = quantidade_classes_histograma;
            this.GrandezaSaida = grandeza_saida;

        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Histograma_Load(object sender, EventArgs e)
        {
            List<double> ResultadoHistograma = new List<double>();
            ResultadoHistograma = FunctionsStatistical.FuncaoHistograma(this.VetorValoresHistograma, this.QuantidadeClassesHistograma, (double)0.05);

            Title title = new Title();
            title.Font = new Font("Arial", 14, FontStyle.Bold);
            title.ForeColor = Color.Brown;

            if (this.GrandezaSaida == 0)
            {
                // Option 0 – Losses
                title.Text = "Loss Histogram – Expansion Planning";
                area_grafico.Titles.Add(title);

                area_grafico.Series.Add("perdas");
                area_grafico.Series["perdas"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                area_grafico.Series["perdas"].BorderWidth = 2;

                for (int contador_classes = 0; contador_classes < ResultadoHistograma.Count(); contador_classes += 2)
                {
                    //MessageBox.Show(ResultadoHistograma[contador_classes].ToString());
                    //MessageBox.Show(ResultadoHistograma[contador_classes+1].ToString());

                    area_grafico.Series["perdas"].Points.AddXY(Math.Round(ResultadoHistograma[contador_classes], 0), ResultadoHistograma[contador_classes + 1]);
                }

                area_grafico.ChartAreas[0].AxisX.Title = "Losses [kW]";
                area_grafico.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            }
            else if (this.GrandezaSaida == 1)
            {
                title.Text = "Investment Histogram – Expansion Planning";
                area_grafico.Titles.Add(title);

                // Option 1 – Investment
                area_grafico.Series.Add("investimento");
                area_grafico.Series["investimento"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                area_grafico.Series["investimento"].BorderWidth = 2;

                for (int contador_classes = 0; contador_classes < ResultadoHistograma.Count(); contador_classes += 2)
                {
                    //MessageBox.Show(ResultadoHistograma[contador_classes].ToString());
                    //MessageBox.Show(ResultadoHistograma[contador_classes+1].ToString());

                    area_grafico.Series["investimento"].Points.AddXY(Math.Round(ResultadoHistograma[contador_classes] / 1000, 0), ResultadoHistograma[contador_classes + 1]);
                }

                area_grafico.ChartAreas[0].AxisX.Title = "Investment Cost [thousand $]";
                area_grafico.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            }

            area_grafico.ChartAreas[0].AxisY.Title = "Probability of Occurrence [%]";
            area_grafico.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            area_grafico.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
        }
    }

}

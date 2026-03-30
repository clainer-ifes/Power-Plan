using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlan
{
    public partial class Diagram : Form
    {
        public List<double> BARRAS_VetorCoordenadasX = new List<double>();
        public List<double> BARRAS_VetorCoordenadasY = new List<double>();
        public List<double> LINHAS_VetorCoordenadasX1 = new List<double>();
        public List<double> LINHAS_VetorCoordenadasY1 = new List<double>();
        public List<double> LINHAS_VetorCoordenadasX2 = new List<double>();
        public List<double> LINHAS_VetorCoordenadasY2 = new List<double>();

        public Diagram()
        {
            InitializeComponent();
        }

        public Diagram(List<double> BARRAS_vetor_coordenadas_x, List<double> BARRAS_vetor_coordenadas_y, List<double> LINHAS_vetor_coordenadas_X1, List<double> LINHAS_vetor_coordenadas_Y1, List<double> LINHAS_vetor_coordenadas_X2, List<double> LINHAS_vetor_coordenadas_Y2)
        {
            InitializeComponent();

            this.BARRAS_VetorCoordenadasX = BARRAS_vetor_coordenadas_x;
            this.BARRAS_VetorCoordenadasY = BARRAS_vetor_coordenadas_y;
            this.LINHAS_VetorCoordenadasX1 = LINHAS_vetor_coordenadas_X1;
            this.LINHAS_VetorCoordenadasY1 = LINHAS_vetor_coordenadas_Y1;
            this.LINHAS_VetorCoordenadasX2 = LINHAS_vetor_coordenadas_X2;
            this.LINHAS_VetorCoordenadasY2 = LINHAS_vetor_coordenadas_Y2;
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void Diagrama_Paint(object sender, PaintEventArgs e)
        {
            double FatorEscalaX = pictureDiagrama.Width / BARRAS_VetorCoordenadasX.Max();
            double FatorEscalaY = pictureDiagrama.Height / BARRAS_VetorCoordenadasY.Max();
            double FatorEscalaGeral = Math.Min(FatorEscalaX, FatorEscalaY);
            double DeslocamentoEmX = 0;
            double DeslocamentoEmY = 0;

            //Console.WriteLine("FatorEscalaX: " + FatorEscalaX);
            //Console.WriteLine("FatorEscalaY: " + FatorEscalaY);

            if (FatorEscalaX >= FatorEscalaY)
            {
                DeslocamentoEmX = (pictureDiagrama.Width - BARRAS_VetorCoordenadasX.Max() * FatorEscalaGeral)/2;
            }
            else
            {
                DeslocamentoEmY = (pictureDiagrama.Height - BARRAS_VetorCoordenadasY.Max() * FatorEscalaGeral) / 2;
            }


            double TamanhoCirculo = 5;

            Graphics g = pictureDiagrama.CreateGraphics();

            Brush Pincel = new SolidBrush(Color.Red);

            for (int contadorBarras = 0; contadorBarras < BARRAS_VetorCoordenadasX.Count; contadorBarras++)
            {
                g.FillEllipse(Pincel, (float)(DeslocamentoEmX + (BARRAS_VetorCoordenadasX[contadorBarras] * FatorEscalaGeral)), (float)(DeslocamentoEmY + (BARRAS_VetorCoordenadasY[contadorBarras] * FatorEscalaGeral)), (float)TamanhoCirculo, (float)TamanhoCirculo);
                
                //Console.WriteLine(contadorBarras);
            }

            Pen pen = new Pen(Color.Red, 2);
            for (int contadorLinhas = 0; contadorLinhas < LINHAS_VetorCoordenadasX1.Count; contadorLinhas++)
            {
                Point point1 = new Point((int)(DeslocamentoEmX + (TamanhoCirculo/2+1) + (LINHAS_VetorCoordenadasX1[contadorLinhas] * FatorEscalaGeral)), (int)(DeslocamentoEmY + (TamanhoCirculo / 2 + 1) + (LINHAS_VetorCoordenadasY1[contadorLinhas] * FatorEscalaGeral)));
                Point point2 = new Point((int)(DeslocamentoEmX + (TamanhoCirculo/2 + 1) + (LINHAS_VetorCoordenadasX2[contadorLinhas] * FatorEscalaGeral)), (int)(DeslocamentoEmY + (TamanhoCirculo / 2 + 1) + (LINHAS_VetorCoordenadasY2[contadorLinhas] * FatorEscalaGeral)));

                g.DrawLine(pen, point1, point2);

            }


            FunctionsDiagram.GeraArquivoRedeFormatoMATLAB(BARRAS_VetorCoordenadasX, BARRAS_VetorCoordenadasY, LINHAS_VetorCoordenadasX1, LINHAS_VetorCoordenadasY1, LINHAS_VetorCoordenadasX2, LINHAS_VetorCoordenadasY2);

        }

            private void Diagrama_Load(object sender, EventArgs e)
        {

        }
    }
}

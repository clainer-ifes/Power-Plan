using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PowerPlan
{
    static class FunctionsStatistical
    {
        //static public List<double> PDFDiscreta(int CodigoPDF, int QuantidadePontosPDF, double ValorMedio, double DesvioPadraoRelativo, double LimiteInferiorAnalisePDF, double LimiteSuperiorAnalisePDF)



        static public List<double> PDFDiscreta(int CodigoPDF, int QuantidadePontosPDF, double ValorMedio, double DesvioPadraoRelativo, double LimiteInferiorAnalisePDF, double LimiteSuperiorAnalisePDF)
        {
            //MessageBox.Show(CodigoPDF.ToString());

            double DesvioPadrao = DesvioPadraoRelativo / 100 * ValorMedio;

            List<double> RetornoFuncao = new List<double>();

            List<double> vetor_valor_x = new List<double>();
            List<double> vetor_valor_y = new List<double>();
            double LimiteInferior_Valor_X = Math.Round(ValorMedio * LimiteInferiorAnalisePDF, 0);
            double LimiteSuperior_Valor_X = Math.Round(ValorMedio * LimiteSuperiorAnalisePDF, 0);

            if (CodigoPDF == 1) // Lognormal
            {
                double parametro_mu = Math.Log(Math.Pow(ValorMedio, 2) / Math.Sqrt(Math.Pow(DesvioPadrao, 2) + Math.Pow(ValorMedio, 2)));
                double parametro_sigma = Math.Sqrt(Math.Log(Math.Pow(DesvioPadrao, 2) / Math.Pow(ValorMedio, 2) + 1));

                for (double valor_item_x = LimiteInferior_Valor_X; valor_item_x <= LimiteSuperior_Valor_X; valor_item_x += 0.01)
                {
                    vetor_valor_x.Add(valor_item_x);

                    //vetor_valor_y.Add((1 / (valor_item_x * parametro_sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp(-Math.Pow((Math.Log(valor_item_x) - parametro_mu), 2) / (2 * Math.Pow(parametro_sigma, 2))));
                    vetor_valor_y.Add(MathNet.Numerics.Distributions.LogNormal.PDF(parametro_mu, parametro_sigma, valor_item_x));
                }

                double Experanca = Math.Exp(parametro_mu + Math.Pow(parametro_sigma, 2) / 2);
            }
            else if (CodigoPDF == 2) // Gamma
            {
                double parametro_r = Math.Pow(ValorMedio / DesvioPadrao, 2);
                double parametro_lambda = ValorMedio / (Math.Pow(DesvioPadrao, 2));

                for (double valor_item_x = LimiteInferior_Valor_X; valor_item_x <= LimiteSuperior_Valor_X; valor_item_x += 0.01)
                {
                    vetor_valor_x.Add(valor_item_x);

                    vetor_valor_y.Add(MathNet.Numerics.Distributions.Gamma.PDF(parametro_r, parametro_lambda, valor_item_x));
                }

                double Experanca = parametro_r / parametro_lambda;
            }
            else if (CodigoPDF == 3) //Weibull
            {
                double parametro_beta = FunctionsStatistical.ParametroBetaWeibull(ValorMedio, DesvioPadrao, 100, 0.000001, 100);
                double parametro_sigma = ValorMedio / MathNet.Numerics.SpecialFunctions.Gamma(1 + 1 / parametro_beta);

                for (double valor_item_x = LimiteInferior_Valor_X; valor_item_x <= LimiteSuperior_Valor_X; valor_item_x += 0.01)
                {
                    vetor_valor_x.Add(valor_item_x);
                    vetor_valor_y.Add(MathNet.Numerics.Distributions.Weibull.PDF(parametro_beta, parametro_sigma, valor_item_x));
                }

                double Experanca = parametro_sigma * MathNet.Numerics.SpecialFunctions.Gamma(1 + 1 / parametro_beta);

                // Console.WriteLine(Experanca);
            }
            else if (CodigoPDF == 4) // Normal
            {
                for (double valor_item_x = LimiteInferior_Valor_X; valor_item_x <= LimiteSuperior_Valor_X; valor_item_x += 0.01)
                {
                    vetor_valor_x.Add(valor_item_x);
                    vetor_valor_y.Add(MathNet.Numerics.Distributions.Normal.PDF(ValorMedio, DesvioPadrao, valor_item_x));
                }

                double Experanca = ValorMedio;

                // Console.WriteLine(Experanca);
            }


            List<double> VetorValorRepresentativoPorFaixa = new List<double>();
            List<double> VetorProbabilidadePorFaixa = new List<double>();

            double LarguraFaixa = (vetor_valor_x.Max() - vetor_valor_x.Min()) / QuantidadePontosPDF;

            for(int contadorFaixas = 1; contadorFaixas<=QuantidadePontosPDF; contadorFaixas++)
            {
                double ProbabilidadeFaixa = 0;
                double LimiteInferiorFaixa = vetor_valor_x.Min() + LarguraFaixa * (contadorFaixas - 1);
                double LimiteSuperiorFaixa = vetor_valor_x.Min() + LarguraFaixa * (contadorFaixas);

                for(int contador_elementos_x = 0; contador_elementos_x < vetor_valor_x.Count; contador_elementos_x++)
                {
                    if ((vetor_valor_x[contador_elementos_x] > LimiteInferiorFaixa) && (vetor_valor_x[contador_elementos_x] <= LimiteSuperiorFaixa))
                    {
                        ProbabilidadeFaixa += vetor_valor_y[contador_elementos_x];
                    }
                }

                VetorProbabilidadePorFaixa.Add(ProbabilidadeFaixa);
                VetorValorRepresentativoPorFaixa.Add((LimiteInferiorFaixa + LimiteSuperiorFaixa) / 2);
            }

            double TotalTemporario = VetorProbabilidadePorFaixa.Sum();
            for (int contadorFaixas = 0; contadorFaixas < VetorProbabilidadePorFaixa.Count; contadorFaixas++)
            {
                VetorProbabilidadePorFaixa[contadorFaixas] *= 100 / TotalTemporario;

                RetornoFuncao.Add(VetorValorRepresentativoPorFaixa[contadorFaixas]);
                RetornoFuncao.Add(VetorProbabilidadePorFaixa[contadorFaixas]);
            }

            return (RetornoFuncao);

        }

        static public double ParametroBetaWeibull(double ValorMedio, double DesvioPadrao, int MaximoIteracoes, double LimiteTolerancia, double LimiteSuperiorAnaliseBeta)
        {
            double TermoConstante = (1 + Math.Pow(DesvioPadrao / ValorMedio, 2)) / 2;
            double LimiteInferiorAtualBeta = 0;
            double LimiteSuperiorAtualBeta = LimiteSuperiorAnaliseBeta;
            double BetaAtual = (LimiteInferiorAtualBeta + LimiteSuperiorAtualBeta) / 2;
            double TermoVariavelAtual = BetaAtual * MathNet.Numerics.SpecialFunctions.Gamma(2 / BetaAtual) / Math.Pow((MathNet.Numerics.SpecialFunctions.Gamma(1 / BetaAtual)), 2);
            double Tolerancia = Math.Abs(TermoVariavelAtual - TermoConstante);

            //Console.WriteLine("Beta atual: " + BetaAtual.ToString());
            //Console.WriteLine("Termo variável: " + TermoVariavelAtual.ToString());
            //Console.WriteLine("Termo constante: " + TermoConstante.ToString());
            //Console.WriteLine("Tolerância: " + Tolerancia.ToString());

            int contador_iteracoes = 1;

            while((Tolerancia>LimiteTolerancia) &&(contador_iteracoes<=MaximoIteracoes))
            {
            if (TermoVariavelAtual<TermoConstante)
                {
                    LimiteSuperiorAtualBeta = BetaAtual;
                }
                else
                {
                    LimiteInferiorAtualBeta = BetaAtual;
                }
                BetaAtual = (LimiteInferiorAtualBeta + LimiteSuperiorAtualBeta) / 2;
                TermoVariavelAtual = BetaAtual * MathNet.Numerics.SpecialFunctions.Gamma(2 / BetaAtual) / Math.Pow((MathNet.Numerics.SpecialFunctions.Gamma(1 / BetaAtual)), 2);
                Tolerancia = Math.Abs(TermoVariavelAtual - TermoConstante);

                //Console.WriteLine("******* Iteração *******: " + contador_iteracoes.ToString());
                //Console.WriteLine("Beta atual: " + BetaAtual.ToString());
                //Console.WriteLine("Termo variável: " + TermoVariavelAtual.ToString());
                //Console.WriteLine("Termo constante: " + TermoConstante.ToString());
                //Console.WriteLine("Tolerância: " + Tolerancia.ToString());

                contador_iteracoes++;

                //Console.WriteLine(BetaAtual.ToString());
           }

            return (BetaAtual);
        }


        static public List<double> FuncaoHistograma(List<double> lista_valores, int QuantidadeClasses, double MargemSeguranca)
        {
            double menor_valor = lista_valores.Min();
            double maior_valor = lista_valores.Max();

            double limite_inferior = menor_valor * (1 - MargemSeguranca);
            double limite_superior = maior_valor * (1 + MargemSeguranca);

            //MessageBox.Show(limite_inferior.ToString());
            //MessageBox.Show(limite_superior.ToString());

            double largura_classe = (limite_superior - limite_inferior) / QuantidadeClasses;

            double percentual_participacao_por_classe;
            double valor_representativo_classe;
            List<double> RetornoFuncao = new List<double>();

            for (int contador=1;contador <= QuantidadeClasses; contador++)
            {
                double limite_inferior_classe = limite_inferior + (contador - 1) * largura_classe;
                double limite_superior_classe = limite_inferior + (contador) * largura_classe;

                percentual_participacao_por_classe = (double)(lista_valores.Count(p => (p > limite_inferior_classe) && (p <= limite_superior_classe))) / lista_valores.Count()*100;
                valor_representativo_classe = ((limite_superior_classe + limite_inferior_classe) / 2);

                RetornoFuncao.Add(valor_representativo_classe);
                RetornoFuncao.Add(percentual_participacao_por_classe);

                //MessageBox.Show(contador + " / " + limite_inferior_classe.ToString() + " / " + limite_superior_classe.ToString());
                //MessageBox.Show(percentual_participacao_por_classe.ToString());
                //MessageBox.Show("rep. " + valor_representativo_classe.ToString());
            }

            return (RetornoFuncao);
        }

        static public List<double> ValoresAleatoriosInvestimento()
        {
            List<double> RetornoFuncao = new List<double>();

            RetornoFuncao.Add((double)192653);
            RetornoFuncao.Add((double)214796);
            RetornoFuncao.Add((double)241261);
            RetornoFuncao.Add((double)222329);
            RetornoFuncao.Add((double)241070);
            RetornoFuncao.Add((double)165110);
            RetornoFuncao.Add((double)213601);
            RetornoFuncao.Add((double)168076);
            RetornoFuncao.Add((double)169348);
            RetornoFuncao.Add((double)221072);
            RetornoFuncao.Add((double)153560);
            RetornoFuncao.Add((double)169267);
            RetornoFuncao.Add((double)192926);
            RetornoFuncao.Add((double)233514);
            RetornoFuncao.Add((double)185336);
            RetornoFuncao.Add((double)181639);
            RetornoFuncao.Add((double)211626);
            RetornoFuncao.Add((double)180225);
            RetornoFuncao.Add((double)164205);
            RetornoFuncao.Add((double)228665);
            RetornoFuncao.Add((double)163745);
            RetornoFuncao.Add((double)151596);
            RetornoFuncao.Add((double)172136);
            RetornoFuncao.Add((double)184401);
            RetornoFuncao.Add((double)153273);
            RetornoFuncao.Add((double)172797);
            RetornoFuncao.Add((double)179681);
            RetornoFuncao.Add((double)186026);
            RetornoFuncao.Add((double)188672);
            RetornoFuncao.Add((double)168602);
            RetornoFuncao.Add((double)228272);
            RetornoFuncao.Add((double)180099);
            RetornoFuncao.Add((double)206968);
            RetornoFuncao.Add((double)175943);
            RetornoFuncao.Add((double)218555);
            RetornoFuncao.Add((double)199264);
            RetornoFuncao.Add((double)198545);
            RetornoFuncao.Add((double)207888);
            RetornoFuncao.Add((double)176332);
            RetornoFuncao.Add((double)174516);
            RetornoFuncao.Add((double)197433);
            RetornoFuncao.Add((double)179483);
            RetornoFuncao.Add((double)248708);
            RetornoFuncao.Add((double)217010);
            RetornoFuncao.Add((double)192430);
            RetornoFuncao.Add((double)201693);
            RetornoFuncao.Add((double)216008);
            RetornoFuncao.Add((double)186304);
            RetornoFuncao.Add((double)243089);
            RetornoFuncao.Add((double)195210);
            RetornoFuncao.Add((double)211433);
            RetornoFuncao.Add((double)199174);
            RetornoFuncao.Add((double)234186);
            RetornoFuncao.Add((double)195392);
            RetornoFuncao.Add((double)164048);
            RetornoFuncao.Add((double)159567);
            RetornoFuncao.Add((double)221185);
            RetornoFuncao.Add((double)204828);
            RetornoFuncao.Add((double)243938);
            RetornoFuncao.Add((double)235923);
            RetornoFuncao.Add((double)191021);
            RetornoFuncao.Add((double)235265);
            RetornoFuncao.Add((double)249605);
            RetornoFuncao.Add((double)155920);
            RetornoFuncao.Add((double)199836);
            RetornoFuncao.Add((double)165159);
            RetornoFuncao.Add((double)241435);
            RetornoFuncao.Add((double)164350);
            RetornoFuncao.Add((double)217416);
            RetornoFuncao.Add((double)158272);
            RetornoFuncao.Add((double)237224);
            RetornoFuncao.Add((double)152821);
            RetornoFuncao.Add((double)219867);
            RetornoFuncao.Add((double)208894);
            RetornoFuncao.Add((double)230176);
            RetornoFuncao.Add((double)225000);
            RetornoFuncao.Add((double)208859);
            RetornoFuncao.Add((double)167180);
            RetornoFuncao.Add((double)202853);
            RetornoFuncao.Add((double)195671);
            RetornoFuncao.Add((double)166969);
            RetornoFuncao.Add((double)172588);
            RetornoFuncao.Add((double)249916);
            RetornoFuncao.Add((double)169805);
            RetornoFuncao.Add((double)212301);
            RetornoFuncao.Add((double)216436);
            RetornoFuncao.Add((double)163732);
            RetornoFuncao.Add((double)200828);
            RetornoFuncao.Add((double)241355);
            RetornoFuncao.Add((double)165291);
            RetornoFuncao.Add((double)229229);
            RetornoFuncao.Add((double)197970);
            RetornoFuncao.Add((double)175699);
            RetornoFuncao.Add((double)209496);
            RetornoFuncao.Add((double)204148);
            RetornoFuncao.Add((double)205907);
            RetornoFuncao.Add((double)189393);
            RetornoFuncao.Add((double)188977);
            RetornoFuncao.Add((double)213645);
            RetornoFuncao.Add((double)199297);

            return (RetornoFuncao);

        }
    }
}

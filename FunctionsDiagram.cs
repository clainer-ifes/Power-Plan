using OpenDSSengine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PowerPlan
{
    static class FunctionsDiagram
    {

        static public void GeraArquivoRedeFormatoMATLAB(List<double> MATLABCoordenadasX, List<double> MATLABCoordenadasY, List<double> MATLABCoordenadasX1, List<double> MATLABCoordenadasY1, List<double> MATLABCoordenadasX2, List<double> MATLABCoordenadasY2)
        {
            string ComandoMATLAB = "clear; \n clc; \n hFig = figure(1); \n hold on; \n grid on;";
            FunctionsTXTFile.GravaDadosArquivoTXT("network_graph.m", ComandoMATLAB, false);

            ComandoMATLAB = "xlabel('X coordinate [m]'); \n ylabel('Y coordinate [m]'); ";
            FunctionsTXTFile.GravaDadosArquivoTXT("network_graph.m", ComandoMATLAB, true);

            ComandoMATLAB = "set(gca, 'Xcolor',[0.3 0.3 0.3]); \n set(gca, 'Ycolor',[0.3 0.3 0.3]);";
            FunctionsTXTFile.GravaDadosArquivoTXT("network_graph.m", ComandoMATLAB, true);

            double LimiteInferiorX = Math.Truncate(MATLABCoordenadasX.Min() / 500)*500;
            double LimiteInferiorY = Math.Truncate(MATLABCoordenadasY.Min() / 500) * 500;
            double LimiteSuperiorX = (Math.Truncate(MATLABCoordenadasX.Max() / 500) + 1) * 500;
            double LimiteSuperiorY = (Math.Truncate(MATLABCoordenadasY.Max() / 500) + 1) * 500;

            ComandoMATLAB = "axis([" + LimiteInferiorX + ", " + LimiteSuperiorX + ", " + LimiteInferiorY + ", " + LimiteSuperiorY + "]); ";
            FunctionsTXTFile.GravaDadosArquivoTXT("network_graph.m", ComandoMATLAB, true);
            //Console.WriteLine("LimiteInferiorX: " + LimiteInferiorX);
            //Console.WriteLine("LimiteInferiorY: " + LimiteInferiorY);
            //Console.WriteLine("LimiteSuperiorX: " + LimiteSuperiorX);
            //Console.WriteLine("LimiteSuperiorY: " + LimiteSuperiorY);

            ComandoMATLAB = "set(gca, 'XTick',[" + LimiteInferiorX + ":500:" + LimiteSuperiorX + "]); \n set(gca, 'YTick',[" + LimiteInferiorY + ":500:" + LimiteSuperiorY + "]); ";
            FunctionsTXTFile.GravaDadosArquivoTXT("network_graph.m", ComandoMATLAB, true);

            int contador_trechos;
            for (contador_trechos=0; contador_trechos< MATLABCoordenadasX1.Count(); contador_trechos++)
            {
                ComandoMATLAB = "plot([" + MATLABCoordenadasX1[contador_trechos] + " " + MATLABCoordenadasX2[contador_trechos] + "], [" + MATLABCoordenadasY1[contador_trechos] + " " + MATLABCoordenadasY2[contador_trechos] + "], 'k', 'LineWidth', 2);";
                FunctionsTXTFile.GravaDadosArquivoTXT("network_graph.m", ComandoMATLAB, true);
            }

            int contador_barras;
            for (contador_barras=0;contador_barras<MATLABCoordenadasX.Count();contador_barras++)
            {
                ComandoMATLAB = "r = 3; x = " + MATLABCoordenadasX[contador_barras] + "; y = " + MATLABCoordenadasY[contador_barras] + "; th = 0:pi / 50:2 * pi; xunit = r * cos(th) + x; yunit = r * sin(th) + y; h = plot(xunit, yunit, 'k', 'LineWidth', 5);";
                FunctionsTXTFile.GravaDadosArquivoTXT("network_graph.m", ComandoMATLAB, true);
            }


        }

        static public (List<string> RETORNOCodigosBarras, List<double> RETORNOCoordenadasX, List<double> RETORNOCoordenadasY, List<string> RETORNOLineNames, List<double> RETORNOCoordenadasX1, List<double> RETORNOCoordenadasY1, List<double> RETORNOCoordenadasX2, List<double> RETORNOCoordenadasY2) GeraListasCoordenadasRede()
        {
            // *****************************
            // Collect bus coordinate data
            // *****************************
            List<string> TEMP_BARRAS_Codigos = new List<string>();
            List<double> TEMP_BARRAS_CoordenadasX = new List<double>();
            List<double> TEMP_BARRAS_CoordenadasY = new List<double>();

            var Linhas = File.ReadAllLines(VariaveisGlobaisProjeto.NomeArquivoCoordenadas);
            foreach (var Linha in Linhas)
            {
                string LinhaComoString = Linha.ToString();
                char[] charSeparators = new char[] { ' ' };
                string[] ParametrosCoordenadas = LinhaComoString.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                TEMP_BARRAS_Codigos.Add(ParametrosCoordenadas[0]);
                //Console.WriteLine("Elemento Lista: " + ParametrosCoordenadas[0]);
                TEMP_BARRAS_CoordenadasX.Add(double.Parse(ParametrosCoordenadas[1]));
                TEMP_BARRAS_CoordenadasY.Add(double.Parse(ParametrosCoordenadas[2]));

                //Console.WriteLine(ParametrosCoordenadas[0] + " / " + ParametrosCoordenadas[1] + " / " + ParametrosCoordenadas[2]);
            }
            //Console.WriteLine(CoordenadasX.Count() + " Barras");

            // *****************************
            // Collect line segment start/end coordinates
            // *****************************
            List<string> TEMP_LINHAS_LineNames = new List<string>();
            List<double> TEMP_LINHAS_CoordenadasX1 = new List<double>();
            List<double> TEMP_LINHAS_CoordenadasY1 = new List<double>();
            List<double> TEMP_LINHAS_CoordenadasX2 = new List<double>();
            List<double> TEMP_LINHAS_CoordenadasY2 = new List<double>();


            var OpenDSS = new DSS();

            if (OpenDSS.Error.Number != 0)
            {
                throw new ApplicationException($"Error in initializing OpenDSS: {OpenDSS.Error.Description}. ");
            }
            else
            {
                string file_to_open = VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado;
                var DSSText = OpenDSS.Text;
                var DSSCircuit = OpenDSS.ActiveCircuit;
                var DSSSolution = DSSCircuit.Solution;
                DSSText.Command = "Compile " + '"' + file_to_open + '"';
                DSSSolution.Solve();

                char[] charSeparators_Parametros_Linha = new char[] { '.', '_' };

                int contador_linhas = 1;
                string[] ListaDeLinhas = DSSCircuit.Lines.AllNames;
                foreach (string LinhaSelecionada in ListaDeLinhas)
                {
                    DSSCircuit.SetActiveElement("Line." + LinhaSelecionada);

                    TEMP_LINHAS_LineNames.Add(LinhaSelecionada);
                    // Console.WriteLine("Elemento Lista: " + LinhaSelecionada);

                    string nome_completo_barra_1 = DSSCircuit.ActiveElement.BusNames[0];
                    string[] ParametrosBarra1 = nome_completo_barra_1.Split(charSeparators_Parametros_Linha, StringSplitOptions.RemoveEmptyEntries);
                    string codigo_barra_1 = ParametrosBarra1[0];

                    int posicao_barra_1 = TEMP_BARRAS_Codigos.IndexOf(codigo_barra_1);
                    TEMP_LINHAS_CoordenadasX1.Add(TEMP_BARRAS_CoordenadasX[posicao_barra_1]);
                    TEMP_LINHAS_CoordenadasY1.Add(TEMP_BARRAS_CoordenadasY[posicao_barra_1]);

                    //Console.WriteLine(posicao_barra_1 + " / " + BARRAS_CoordenadasX[posicao_barra_1].ToString() + " / " + BARRAS_CoordenadasY[posicao_barra_1].ToString());

                    string nome_completo_barra_2 = DSSCircuit.ActiveElement.BusNames[1];
                    string[] ParametrosBarra2 = nome_completo_barra_2.Split(charSeparators_Parametros_Linha, StringSplitOptions.RemoveEmptyEntries);
                    string codigo_barra_2 = ParametrosBarra2[0];

                    // Console.WriteLine(nome_completo_barra_2);

                    int posicao_barra_2 = TEMP_BARRAS_Codigos.IndexOf(codigo_barra_2);
                    TEMP_LINHAS_CoordenadasX2.Add(TEMP_BARRAS_CoordenadasX[posicao_barra_2]);
                    TEMP_LINHAS_CoordenadasY2.Add(TEMP_BARRAS_CoordenadasY[posicao_barra_2]);

                    //Console.WriteLine(posicao_barra_2 + " / " + BARRAS_CoordenadasX[posicao_barra_2].ToString() + " / " + BARRAS_CoordenadasY[posicao_barra_2].ToString());


                    //Console.WriteLine("Contador: #" + contador_linhas + " / Bus #1: " + DSSCircuit.ActiveElement.BusNames[0] + " (" + codigo_barra_1 + ") / Bus #2: " + DSSCircuit.ActiveElement.BusNames[1] + "(" + codigo_barra_2 + ")");

                    contador_linhas++;
                }

            }

            return (RETORNOCodigosBarras: TEMP_BARRAS_Codigos, RETORNOCoordenadasX: TEMP_BARRAS_CoordenadasX, RETORNOCoordenadasY: TEMP_BARRAS_CoordenadasY, RETORNOLineNames: TEMP_LINHAS_LineNames, RETORNOCoordenadasX1: TEMP_LINHAS_CoordenadasX1, RETORNOCoordenadasY1: TEMP_LINHAS_CoordenadasY1, RETORNOCoordenadasX2: TEMP_LINHAS_CoordenadasX2, RETORNOCoordenadasY2: TEMP_LINHAS_CoordenadasY2);
        }


        }

    }

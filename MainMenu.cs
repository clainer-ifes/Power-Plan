using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenDSSengine;
using System.Data.SqlServerCe;
using System.IO;
using System.Diagnostics;



namespace PowerPlan
{
    public partial class PowerPlan : Form
    {

        public PowerPlan()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void executarFluxoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenDSS = new DSS();

            if (OpenDSS.Error.Number != 0)
            {
                throw new ApplicationException($"Error in initializing OpenDSS: {OpenDSS.Error.Description}. ");
            }
            else
            {
                if (VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado != "")
                {
                    //MessageBox.Show(NomeArquivoSelecionado);
                    string file_to_open = VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado;
                    var DSSText = OpenDSS.Text;
                    var DSSCircuit = OpenDSS.ActiveCircuit;
                    var DSSSolution = DSSCircuit.Solution;
                    DSSText.Command = "Compile " + '"' + file_to_open + '"';
                    DSSSolution.Solve();

                    

                    // ****************************************************
                    // Faz a leitura das correntes de cada linha (%)
                    // ****************************************************

                    Console.WriteLine("***** CARREGAMENTO DAS LINHAS [%] *****");
                    int contador_linhas = 1;
                    string[] ListaDeLinhas = DSSCircuit.Lines.AllNames;
                    foreach (string LinhaSelecionada in ListaDeLinhas)
                    {
                        DSSCircuit.SetActiveElement("Line." + LinhaSelecionada);

                        string string_correntes = "";
                        double[] ValoresCorrentes = DSSCircuit.ActiveElement.CurrentsMagAng;
                        for (int contador = 0; contador < (ValoresCorrentes.Length / 2); contador += 2)
                        {
                            string_correntes += (ValoresCorrentes[contador] / DSSCircuit.ActiveElement.NormalAmps * 100) + " [%] / ";
                        }

                        Console.WriteLine("Contador: #" + contador_linhas + " / Linha: '" + LinhaSelecionada + "' / Capacidade: '" + DSSCircuit.ActiveElement.NormalAmps + " [A] ' / Correntes: '" + string_correntes + "'");
                        //Console.WriteLine("Contador: #" + contador_linhas + " / Bus #1: " + DSSCircuit.ActiveElement.BusNames[0] + " / Bus #2: " + DSSCircuit.ActiveElement.BusNames[1]);

                        contador_linhas++;
                    }
                    Console.WriteLine("***** FIM DO CARREGAMENTO DAS LINHAS *****");


                    Console.WriteLine("***** PERDAS NAS LINHAS [kW] *****");
                    double[] Perdas = DSSCircuit.LineLosses;
                    Console.WriteLine("PERDAS: " + Perdas[0] + " [kW]");
                    Console.WriteLine("***** FIM DA ANÁLISE DE PERDAS NAS LINHAS [kW] *****");

                    Console.WriteLine("******** ANÁLISE DE TENSÃO NAS BARRAS ********");
                    int contador_barras = 1;
                    string[] ListaDeBarras = DSSCircuit.AllBusNames;
                    foreach (string BarrasSelecionada in ListaDeBarras)
                    {
                        DSSCircuit.SetActiveBus(BarrasSelecionada);

                        string string_tensoes = "";
                        double[] ValoresTensoes = DSSCircuit.ActiveBus.puVmagAngle;
                        for (int contador = 0; contador < (ValoresTensoes.Length); contador += 2)
                        {
                            string_tensoes += ValoresTensoes[contador] + " [pu] / ";
                        }

                        string string_lista_nomes_nodes = "";
                        int[] ListaNomesNodes = DSSCircuit.ActiveBus.Nodes;
                        foreach (int NodeSelecionado in ListaNomesNodes)
                        {
                            string_lista_nomes_nodes += "'" + NodeSelecionado + "' / ";
                        }

                        Console.WriteLine("Contador: #" + contador_barras + " / Barra: '" + BarrasSelecionada + " / Nós: " + string_lista_nomes_nodes + " Tensões: " + string_tensoes);

                        contador_barras++;
                    }
                    Console.WriteLine("******** FIM DA ANÁLISE DE TENSÃO NAS BARRAS ********");

                    Console.WriteLine("******** ANÁLISE DAS CARGAS INICIAIS ********");
                    int Retorno = DSSCircuit.Loads.First;
                    for (int contador_cargas = 0; contador_cargas < DSSCircuit.Loads.Count; contador_cargas++)
                    {
                        Console.WriteLine("Carga: " + DSSCircuit.Loads.Name + " / kW: " + DSSCircuit.Loads.kW + " / kvar: " + DSSCircuit.Loads.kvar);

                        Retorno = DSSCircuit.Loads.Next;
                    }
                    Console.WriteLine("******** FIM DA ANÁLISE DAS CARGAS INICIAIS ********");


                    Console.WriteLine("******** MODIFICAÇÃO DAS CARGAS ********");
                    int RetornoMod = DSSCircuit.Loads.First;
                    for (int contador_cargas = 0; contador_cargas < DSSCircuit.Loads.Count; contador_cargas++)
                    {
                        DSSCircuit.Loads.kW *= 2;
                        DSSCircuit.Loads.kvar *= 2;

                        RetornoMod = DSSCircuit.Loads.Next;
                    }
                    DSSSolution.Solve();

                    double[] PerdasMod = DSSCircuit.LineLosses;
                    Console.WriteLine("PERDAS APÓS MODIFICAÇÃO DAS CARGAS: " + PerdasMod[0] + " [kW]");

                    Console.WriteLine("******** FIM DA MODIFICAÇÃO DAS CARGAS ********");



                    Console.WriteLine("******** ANÁLISE DOS CÓDIGOS DOS TIPOS DAS LINHAS ********");
                    int Retorno2 = DSSCircuit.Lines.First;
                    for (int contador_linhas2 = 0; contador_linhas2 < DSSCircuit.Lines.Count; contador_linhas2++)
                    {
                        Console.WriteLine("Linha: " + DSSCircuit.Lines.Name + " / LineCode: " + DSSCircuit.Lines.LineCode);

                        Retorno2 = DSSCircuit.Lines.Next;
                    }
                    Console.WriteLine("******** FIM DA ANÁLISE DOS CÓDIGOS DOS TIPOS DAS LINHAS ********");


                    Console.WriteLine("******** MODIFICAÇÃO DOS CÓDIGOS DOS TIPOS DAS LINHAS ********");
                    int RetornoMod2 = DSSCircuit.Lines.First;
                    for (int contador_linhas2 = 0; contador_linhas2 < DSSCircuit.Lines.Count; contador_linhas2++)
                    {
                        DSSCircuit.Lines.LineCode = "3";

                        RetornoMod2 = DSSCircuit.Lines.Next;
                    }
                    DSSSolution.Solve();

                    double[] PerdasMod2 = DSSCircuit.LineLosses;
                    double VariacaoPerdas = PerdasMod2[0] - PerdasMod[0];
                    Console.WriteLine("PERDAS APÓS MODIFICAÇÃO DOS CÓDIGOS DOS TIPOS DAS LINHAS: " + PerdasMod2[0] + " [kW] / Variação de: " + VariacaoPerdas + " [kW]");

                    Console.WriteLine("******** FIM DA MODIFICAÇÃO DOS CÓDIGOS DOS TIPOS DAS LINHAS ********");

                }
                else
                {
                    MessageBox.Show("Rede não selecionada. Selecione uma rede antes de executar o fluxo de potência!");
                }
            }
        }

        private void abrirRedeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaixaAberturaArquivo.InitialDirectory = ProjectConstants.CONSTANTE_DiretorioInicial_OpenDSS;
            CaixaAberturaArquivo.Filter = ProjectConstants.CONSTANTE_Filtro_OpenDSS_Rede;
            CaixaAberturaArquivo.ShowDialog();
            VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado = CaixaAberturaArquivo.FileName;

            AtualizaBarraStatus();
        }

        private void CaixaAberturaArquivo_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void sobreOPowerPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About sobre = new About();
            sobre.ShowDialog();
        }

        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conductors condutores = new Conductors();
            condutores.ShowDialog();
        }

        private void PowerPlan_Load(object sender, EventArgs e)
        {
            FunctionsDatabase.InicializaBancoDados();

            DefineNomeArquivosPadrao();
        }


        private void DefineNomeArquivosPadrao()
        {
            VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado = ProjectConstants.CONSTANTE_DiretorioInicial_OpenDSS + "IEEE123Master.dss";
            VariaveisGlobaisProjeto.NomeArquivoCoordenadas = ProjectConstants.CONSTANTE_DiretorioInicial_OpenDSS + "BusCoords.dat";

            AtualizaBarraStatus();
        }

        private void AtualizaBarraStatus()
        {
            toolStripStatusLabelRede.Text = "Network file: " + VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado;
            toolStripStatusLabelCoordenadas.Text = "Coordinate file: " + VariaveisGlobaisProjeto.NomeArquivoCoordenadas;
        }


        private void recondutoramentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reconductoring recondutoramento = new Reconductoring();
            recondutoramento.ShowDialog();
        }

        private void pDFsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDFs pdfs = new PDFs();
            pdfs.ShowDialog();

        }

        private void pDFsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PDFs pdfs = new PDFs();
            pdfs.ShowDialog();
        }

        private void algoritmosDeOtimizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Algorithms algoritmos = new Algorithms();
            algoritmos.ShowDialog();
        }

        private void TesteColetaDadosOpenDSS_Click(object sender, EventArgs e)
        {


        }

        private void abrirArquivoDeCoordenadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado != "")
            {
                CaixaAberturaArquivo.InitialDirectory = ProjectConstants.CONSTANTE_DiretorioInicial_OpenDSS;
                CaixaAberturaArquivo.Filter = ProjectConstants.CONSTANTE_Filtro_OpenDSS_Coordenadas;
                CaixaAberturaArquivo.ShowDialog();
                VariaveisGlobaisProjeto.NomeArquivoCoordenadas = CaixaAberturaArquivo.FileName;

                AtualizaBarraStatus();

                //Console.WriteLine(NomeArquivoPrincipalRedeSelecionado);
                //Console.WriteLine(NomeArquivoCoordenadas);
            }
            else
            {
                MessageBox.Show("Select the main network file before selecting the coordinate file!", "Warning!");
            }
        }

        private void plotarDiagramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((VariaveisGlobaisProjeto.NomeArquivoCoordenadas != "")&&(VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado != ""))
            {
                var RetornoFuncaoCoordenadas = FunctionsDiagram.GeraListasCoordenadasRede();
                Diagram diagrama = new Diagram(RetornoFuncaoCoordenadas.RETORNOCoordenadasX, RetornoFuncaoCoordenadas.RETORNOCoordenadasY, RetornoFuncaoCoordenadas.RETORNOCoordenadasX1, RetornoFuncaoCoordenadas.RETORNOCoordenadasY1, RetornoFuncaoCoordenadas.RETORNOCoordenadasX2, RetornoFuncaoCoordenadas.RETORNOCoordenadasY2);
                diagrama.ShowDialog();
            }
            else if((VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado == ""))
            {
                MessageBox.Show("No network selected. Please select a network before running the diagram function!");
            }
            else if ((VariaveisGlobaisProjeto.NomeArquivoCoordenadas == ""))
            {
                MessageBox.Show("No coordinate file selected. Please select a coordinate file before running the diagram function!");
            }
        }

        private void otimizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado != "")
            {
                Optimization otimizacao = new Optimization();
                otimizacao.ShowDialog();
            }
            else
            {
                MessageBox.Show("No network selected. Please select a network before running the diagram function!");
            }


        }

        private void análiseDeResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query;
            query = "   SELECT      * " +
                "       FROM        ResultadosOtimizacao ";
            DataTable dados_resultados = new DataTable();
            SqlCeDataAdapter adaptador_dados_resultados = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
            adaptador_dados_resultados.Fill(dados_resultados);

            //Console.WriteLine("Quantidade de registros: " + dados_resultados.Rows.Count);

            if(dados_resultados.Rows.Count==0)
            {
                MessageBox.Show("No optimization results available for analysis.\n\nPlease use the 'Optimization' option first.");
            }
            else
            {
                ResultsAnalysis analise_resultados = new ResultsAnalysis();
                analise_resultados.ShowDialog();
            }
        }
    }
}

using OpenDSSengine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MathNet.Numerics;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.LinkLabel;
using static PowerPlan.FunctionsOptimization;

namespace PowerPlan
{
    public partial class Optimization : Form
    {
        string ValorPadraoCarregamentoAno1 = "5,00";
        string ValorPadraoCarregamentoAno2 = "5,00";
        string ValorPadraoCarregamentoAno3 = "5,00";
        string ValorPadraoCarregamentoAno4 = "5,00";
        string ValorPadraoCarregamentoAno5 = "5,00";

        struct CargaParaSelecaoAutomatica : IComparable<CargaParaSelecaoAutomatica>
        {
            public double ValorCarga { get; set; }
            public int Indice { get; set; }

            // CompareTo implementation to sort by ValorCarga
            public int CompareTo(CargaParaSelecaoAutomatica OutraCarga)
            {
                return OutraCarga.ValorCarga.CompareTo(this.ValorCarga);
            }

            public override string ToString()
            {
                return $"kW: {ValorCarga}, Índice: {Indice}";
            }
        }

        List<CargaParaSelecaoAutomatica> ListaCargasParaSelecaoAutomatica = new List<CargaParaSelecaoAutomatica>();


        public Optimization()
        {
            InitializeComponent();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RecalculaCenariosSimulados()
        {
            double QtdePontos = double.Parse(comboPontosPDF.SelectedItem.ToString());


            double QtdeCargas;
            if (checkCargasAleatorias.Checked)
            {
                QtdeCargas = double.Parse(comboQuantidadeCargasAleatorias.SelectedItem.ToString());
            }
            else
            {
                QtdeCargas = chkCargas.CheckedItems.Count;
            }
            //Console.WriteLine(QtdeCargas);

            double QtdeCenarios = Math.Pow(QtdePontos, QtdeCargas);

            txtCenariosSimulados.Text = QtdePontos.ToString() + " ^ " + QtdeCargas.ToString() + " = " + QtdeCenarios.ToString() + " scenarios.";

            if(txtDesvioPadraoRelativo.Text!="")
            {
                //Console.WriteLine(txtDesvioPadraoRelativo.Text);
                double CI = 1.645 * double.Parse(txtDesvioPadraoRelativo.Text) / 100 / Math.Pow(QtdeCenarios, 0.5);
                txtIntervaloConfianca.Text = "\u00B1 " + CI.ToString("F4") + " or " + (CI*100).ToString("F2") + "%";
            }
        }

        private void DefineCondutoresParaTeste()
        {
            checkTodosCondutores.Checked = false;
            chkCondutoresPermitidos.SetItemChecked(1, true);
            chkCondutoresPermitidos.SetItemChecked(4, true);
            chkCondutoresPermitidos.SetItemChecked(7, true);
            chkCondutoresPermitidos.SetItemChecked(9, true);
            chkCondutoresPermitidos.SetItemChecked(11, true);
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);
            var OpenDSS = new DSS();

            try
            {

                string query_PDF = "SELECT ID, Descricao FROM PDFs ORDER BY ID";
                string query_Algoritmo = "SELECT ID, Descricao FROM Algoritmos ORDER BY ID";
                string query_Condutores = "SELECT ID, Descricao, capacidade, custo FROM Condutores ORDER BY ID";

                DataTable dados_PDF = new DataTable();
                DataTable dados_Algoritmo = new DataTable();
                DataTable dados_Condutores = new DataTable();

                SqlCeDataAdapter adaptador_PDF = new SqlCeDataAdapter(query_PDF, ProjectConstants.CONSTANTE_strConection);
                SqlCeDataAdapter adaptador_Algoritmo = new SqlCeDataAdapter(query_Algoritmo, ProjectConstants.CONSTANTE_strConection);
                SqlCeDataAdapter adaptador_Condutores = new SqlCeDataAdapter(query_Condutores, ProjectConstants.CONSTANTE_strConection);

                conexao.Open();

                adaptador_PDF.Fill(dados_PDF);
                adaptador_Algoritmo.Fill(dados_Algoritmo);
                adaptador_Condutores.Fill(dados_Condutores);

                comboPDF.DataSource = dados_PDF;
                comboPDF.ValueMember = "ID";
                comboPDF.DisplayMember = "Descricao";

                comboJanelaAnalise.Items.Clear();
                comboJanelaAnalise.Items.Add("1 year (no optimization)");
                comboJanelaAnalise.Items.Add("5 years (with optimization)");
                comboJanelaAnalise.SelectedIndex = 1;

                comboAlgoritmo.DataSource = dados_Algoritmo;
                comboAlgoritmo.ValueMember = "ID";
                comboAlgoritmo.DisplayMember = "Descricao";

                txtFatorCrescimentoAno1.Text = ValorPadraoCarregamentoAno1;
                txtFatorCrescimentoAno2.Text = ValorPadraoCarregamentoAno2;
                txtFatorCrescimentoAno3.Text = ValorPadraoCarregamentoAno3;
                txtFatorCrescimentoAno4.Text = ValorPadraoCarregamentoAno4;
                txtFatorCrescimentoAno5.Text = ValorPadraoCarregamentoAno5;
                
                comboPontosPDF.Items.Clear();
                comboPontosPDF.Items.Add("1");
                comboPontosPDF.Items.Add("2");
                comboPontosPDF.Items.Add("3");
                comboPontosPDF.Items.Add("4");
                comboPontosPDF.Items.Add("5");
                comboPontosPDF.SelectedIndex = 3;

                comboUnidadeComprimento.Items.Clear();
                comboUnidadeComprimento.Items.Add("1.000 ft");
                comboUnidadeComprimento.Items.Add("km");
                comboUnidadeComprimento.SelectedIndex = 0;

                comboClassesHistograma.Items.Clear();
                comboClassesHistograma.Items.Add("3");
                comboClassesHistograma.Items.Add("4");
                comboClassesHistograma.Items.Add("5");
                comboClassesHistograma.Items.Add("6");
                comboClassesHistograma.Items.Add("7");
                comboClassesHistograma.Items.Add("8");
                comboClassesHistograma.Items.Add("9");
                comboClassesHistograma.Items.Add("10");
                comboClassesHistograma.SelectedIndex = 2;

                comboLimiteInferiorPDF.Items.Clear();
                comboLimiteInferiorPDF.Items.Add("0,25");
                comboLimiteInferiorPDF.Items.Add("0,33");
                comboLimiteInferiorPDF.Items.Add("0,50");
                comboLimiteInferiorPDF.SelectedIndex = 2;

                comboLimiteSuperiorPDF.Items.Clear();
                comboLimiteSuperiorPDF.Items.Add("1,50");
                comboLimiteSuperiorPDF.Items.Add("2,00");
                comboLimiteSuperiorPDF.SelectedIndex = 0;

                comboGrandezaSaida.Items.Clear();
                comboGrandezaSaida.Items.Add("Losses [kW]");
                comboGrandezaSaida.Items.Add("Investment cost [$]");
                comboGrandezaSaida.SelectedIndex = 0;

                txtDesvioPadraoRelativo.Text = "10,00";
                txtCarregamentoLimite.Text = "66,00";

                comboQuantidadeCargasAleatorias.Items.Clear();
                for(int contador_quantidade_cargas_aleatorias=1; contador_quantidade_cargas_aleatorias<=10; contador_quantidade_cargas_aleatorias++)
                {
                    comboQuantidadeCargasAleatorias.Items.Add(contador_quantidade_cargas_aleatorias);
                }
                comboQuantidadeCargasAleatorias.SelectedIndex = 2;

                chkCondutoresPermitidos.Items.Clear();
                foreach (DataRow linha in dados_Condutores.Rows)
                {
                    chkCondutoresPermitidos.Items.Add(linha[0] + " / " + linha[1] + " / " + linha[2] + " A");
                }
                checkTodosCondutores.Checked = true;

                DefineCondutoresParaTeste();

                string file_to_open = VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado;
                var DSSText = OpenDSS.Text;
                var DSSCircuit = OpenDSS.ActiveCircuit;
                var DSSSolution = DSSCircuit.Solution;
                DSSText.Command = "Compile " + '"' + file_to_open + '"';
                DSSSolution.Solve();

                chkCargas.Items.Clear();
                if (OpenDSS.Error.Number != 0)
                {
                    throw new ApplicationException($"Error in initializing OpenDSS: {OpenDSS.Error.Description}. ");
                }
                else
                {
                    int Retorno = DSSCircuit.Loads.First;
                    for (int contador_cargas = 0; contador_cargas < DSSCircuit.Loads.Count; contador_cargas++)
                    {
                        chkCargas.Items.Add("Load: " + DSSCircuit.Loads.Name + " / kW: " + DSSCircuit.Loads.kW + " / kvar: " + DSSCircuit.Loads.kvar);

                        CargaParaSelecaoAutomatica carga_selecao_automatica = new CargaParaSelecaoAutomatica();
                        carga_selecao_automatica.ValorCarga = DSSCircuit.Loads.kW;
                        carga_selecao_automatica.Indice = contador_cargas;
                        ListaCargasParaSelecaoAutomatica.Add(carga_selecao_automatica);

                        Retorno = DSSCircuit.Loads.Next;
                    }

                }
                checkCargasAleatorias.Checked = true;

                comboTipoAleatorio.Items.Clear();
                comboTipoAleatorio.Items.Add("Random");
                comboTipoAleatorio.Items.Add("Highest values");
                comboTipoAleatorio.SelectedIndex = 1;

                comboJanelaAnalise_SelectionChangeCommitted(null, null);

                RecalculaCenariosSimulados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            comboPDF.Focus();
        }

        private void comboPDF_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboAlgoritmo_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void Otimizacao_Load(object sender, EventArgs e)
        {
            Limpar_Click(null, null);

        }

        private void ExecutarOtimizacao_Click(object sender, EventArgs e)
        {

            if (txtFatorCrescimentoAno1.Text == "")
            {
                MessageBox.Show("Growth rate (Year #1) not provided.");
                txtFatorCrescimentoAno1.Focus();
            }
            else if ((txtFatorCrescimentoAno2.Text == "")&&(comboJanelaAnalise.SelectedIndex==1))
            {
                MessageBox.Show("Growth rate (Year #2) not provided.");
                txtFatorCrescimentoAno2.Focus();
            }
            else if ((txtFatorCrescimentoAno3.Text == "") && (comboJanelaAnalise.SelectedIndex == 1))
            {
                MessageBox.Show("Growth rate (Year #3) not provided.");
                txtFatorCrescimentoAno3.Focus();
            }
            else if ((txtFatorCrescimentoAno4.Text == "") && (comboJanelaAnalise.SelectedIndex == 1))
            {
                MessageBox.Show("Growth rate (Year #4) not provided.");
                txtFatorCrescimentoAno4.Focus();
            }
            else if ((txtFatorCrescimentoAno5.Text == "") && (comboJanelaAnalise.SelectedIndex == 1))
            {
                MessageBox.Show("Growth rate (Year #5) not provided.");
                txtFatorCrescimentoAno5.Focus();
            }
            else if (txtDesvioPadraoRelativo.Text == "")
            {
                MessageBox.Show("Relative standard deviation not provided.");
                txtDesvioPadraoRelativo.Focus();
            }
            else if ((!checkTodosCondutores.Checked) && (chkCondutoresPermitidos.CheckedItems.Count == 0))
            {
                MessageBox.Show("No allowed conductors selected.");
            }
            else if ((!checkCargasAleatorias.Checked) && (chkCargas.CheckedItems.Count == 0))
            {
                MessageBox.Show("No loads selected.");
            }
            else if (txtCarregamentoLimite.Text == "")
            {
                MessageBox.Show("Loading limit not provided.");
                txtCarregamentoLimite.Focus();
            }
            else
            {

                #region OpenDSS connection
                var OpenDSS = new DSS();

                string file_to_open = VariaveisGlobaisProjeto.NomeArquivoPrincipalRedeSelecionado;
                var DSSText = OpenDSS.Text;
                var DSSCircuit = OpenDSS.ActiveCircuit;
                var DSSSolution = DSSCircuit.Solution;
                DSSText.Command = "Compile " + '"' + file_to_open + '"';
                DSSSolution.Solve();
                #endregion


                #region Variables used throughout the process
                // ********************************
                // Variables used throughout the process
                // ********************************
                char[] SeparadorSplitBarra = new char[] { '/' };
                char[] SeparadorSplitDoisPontos = new char[] { ':' };
                char[] SeparadorSplitPontoEVirgula = new char[] { ';' };

                // ********************************
                // ********************************
                // ********************************
                #endregion

                #region If the random-loads option is checked, randomly select the loads

                if (checkCargasAleatorias.Checked)
                {
                    // Clear the current selection
                    for (int contador_itens = 0; contador_itens < chkCargas.Items.Count; contador_itens++)
                    {
                        chkCargas.SetItemChecked(contador_itens, false);
                    }

                    if (comboTipoAleatorio.SelectedIndex == 0)
                    {
                        int QuantidadeCargasAleatorias = int.Parse(comboQuantidadeCargasAleatorias.SelectedItem.ToString());
                        int IndiceMaximoSorteio = chkCargas.Items.Count;

                        //MessageBox.Show(QuantidadeCargasAleatorias.ToString());
                        //MessageBox.Show(IndiceMaximoSorteio.ToString());

                        // Randomly select and check the chosen loads
                        Random randNum = new Random();
                        for (int contador_cargas_aleatorias = 1; contador_cargas_aleatorias <= QuantidadeCargasAleatorias; contador_cargas_aleatorias++)
                        {
                            int NumeroSorteado = randNum.Next(1, (IndiceMaximoSorteio + 1));
                            // MessageBox.Show(NumeroSorteado.ToString());

                            chkCargas.SetItemChecked((NumeroSorteado - 1), true);
                        }

                        // Console.WriteLine("saída: 0");
                    }
                    else if (comboTipoAleatorio.SelectedIndex == 1)
                    {
                        // Console.WriteLine("saída: 1");
                        int QuantidadeCargasAleatorias = int.Parse(comboQuantidadeCargasAleatorias.SelectedItem.ToString());

                        ListaCargasParaSelecaoAutomatica.Sort();

                        for (int contador_cargas_aleatorias = 1; contador_cargas_aleatorias <= QuantidadeCargasAleatorias; contador_cargas_aleatorias++)
                        {
                            double CargaSelecionada = ListaCargasParaSelecaoAutomatica[contador_cargas_aleatorias - 1].ValorCarga;
                            int IndiceSelecionado = ListaCargasParaSelecaoAutomatica[contador_cargas_aleatorias - 1].Indice;

                            chkCargas.SetItemChecked(IndiceSelecionado, true);

                            // Console.WriteLine(CargaSelecionada);
                            // Console.WriteLine(IndiceSelecionado);
                        }
                    }
                }

                #endregion



                #region Generate all possible combinations of PDF points and loads

                // ********************************
                // Generates all possible combinations of PDF points and loads
                // ********************************

                string codigo_laco_for = "int total_combinacoes = 0; ";
                codigo_laco_for += "string SaidaCombinacoes; ";

                for (int contador_cargas = 1; contador_cargas <= (int)chkCargas.CheckedItems.Count; contador_cargas++)
                {
                    codigo_laco_for += "for(int contador_ponto_PDF_carga_" + contador_cargas + " = 1; contador_ponto_PDF_carga_" + contador_cargas + " <= " + comboPontosPDF.SelectedItem.ToString() + "; contador_ponto_PDF_carga_" + contador_cargas + "++) { ";
                }
                for (int contador_cargas = 1; contador_cargas <= (int)chkCargas.CheckedItems.Count; contador_cargas++)
                {
                    codigo_laco_for += "SaidaCombinacoes += contador_ponto_PDF_carga_" + contador_cargas + "; ";
                    codigo_laco_for += "SaidaCombinacoes += \";\";";

                    if (contador_cargas == (int)chkCargas.CheckedItems.Count)
                    {
                        codigo_laco_for += "SaidaCombinacoes += \"/\";";
                    }
                }
                codigo_laco_for += "total_combinacoes++; ";
                for (int contador_cargas = 1; contador_cargas <= (int)chkCargas.CheckedItems.Count; contador_cargas++)
                {
                    codigo_laco_for += " } ";
                }

                var codeToCompile = @" " + codigo_laco_for + " return SaidaCombinacoes;";
                //MessageBox.Show(codeToCompile);
                var options = ScriptOptions.Default;
                Script compiledScript = CSharpScript.Create(codeToCompile, options);
                var result = compiledScript.RunAsync();
                string SaidaAlgoritmoCombinacoes = result.Result.ReturnValue.ToString();
                //Console.WriteLine("saída: " + SaidaAlgoritmoCombinacoes);

                // ********************************
                // ********************************
                // ********************************

                #endregion



                #region Iterate over each combination, update loads, and run electrical calculations
                // ********************************
                // Iterate over each combination, update loads, and run electrical calculations
                // ********************************

                List<double> VetorValorSaidaParaHistograma = new List<double>();
                List<double> VetorProbabilidadeSaidaParaHistograma = new List<double>();

                // Clear the optimization results table
                FunctionsOptimization.LimpaTabelaResultadosOtimizacao();

                int contador_combinacoes = 0;
                string[] ListaCombinacoes = SaidaAlgoritmoCombinacoes.Split(SeparadorSplitBarra, StringSplitOptions.RemoveEmptyEntries);
                foreach(string Combinacao in ListaCombinacoes)
                {
                    // Increment the combination counter to track which one is being analyzed
                    contador_combinacoes++;

                    //Console.WriteLine("Combinação: " + Combinacao);
                    

                    if (comboJanelaAnalise.SelectedIndex== 0)
                    {
                        #region 1-year analysis window (no optimization)

                        FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "Start of Log File – 1-Year Analysis", false);

                     // For the base network, apply the load growth factor for Year #1
                     double FatorCrescimentoAno1Multiplicativo = (1 + double.Parse(txtFatorCrescimentoAno1.Text) / 100);
                    //Console.WriteLine(FatorCrescimentoAno1Multiplicativo);

                    int RetornoMod2 = DSSCircuit.Loads.First;
                    for (int contador_cargas = 0; contador_cargas < DSSCircuit.Loads.Count; contador_cargas++)
                    {
                        DSSCircuit.Loads.kW *= FatorCrescimentoAno1Multiplicativo;
                        DSSCircuit.Loads.kvar *= FatorCrescimentoAno1Multiplicativo;

                        RetornoMod2 = DSSCircuit.Loads.Next;
                    }

                    // Identify the PDF points for the current combination
                    string[] PontosSelecionadosPDFPorCarga = Combinacao.Split(SeparadorSplitPontoEVirgula, StringSplitOptions.RemoveEmptyEntries);

                    // For each load, determine its identifier and value
                    string CodigoCargaAtual = "";
                    double ValorCargaAtual = 0;
                    double ProbabilidadeCombinacao = 1;

                    int IndiceAtualCarga = 0;
                    foreach (var CargaEmAnalise in chkCargas.CheckedItems)
                    {
                        // Foreach for each load

                        int PontoPDFSelecionado = int.Parse(PontosSelecionadosPDFPorCarga[IndiceAtualCarga]);
                        // Console.WriteLine(PontoPDFAtual);

                        string[] SubItens = CargaEmAnalise.ToString().Split(SeparadorSplitBarra, StringSplitOptions.RemoveEmptyEntries);

                        // Identify the load identifier and its initial value
                        for (int contador_sub_itens = 1; contador_sub_itens <= SubItens.Count(); contador_sub_itens++)
                        {
                            string[] SubDivisao = SubItens[contador_sub_itens - 1].Split(SeparadorSplitDoisPontos, StringSplitOptions.RemoveEmptyEntries);

                            if (contador_sub_itens == 1)
                            {
                                //Console.WriteLine("Código da Carga: " + SubDivisao[1]);
                                CodigoCargaAtual = SubDivisao[1].Trim();
                            }
                            else if (contador_sub_itens == 2)
                            {
                                //Console.WriteLine("Valor da Carga: " + SubDivisao[1]);
                                ValorCargaAtual = double.Parse(SubDivisao[1]) * FatorCrescimentoAno1Multiplicativo;
                            }
                        }

                        // Apply the discrete PDF to the load
                        List<double> SaidaPDFDiscreta = new List<double>();
                        SaidaPDFDiscreta = FunctionsStatistical.PDFDiscreta((int)comboPDF.SelectedValue, int.Parse(comboPontosPDF.SelectedItem.ToString()), ValorCargaAtual, double.Parse(txtDesvioPadraoRelativo.Text), double.Parse(comboLimiteInferiorPDF.SelectedItem.ToString()), double.Parse(comboLimiteSuperiorPDF.SelectedItem.ToString()));

                        //Console.WriteLine("Resultado PDF: ");
                        //foreach (double item in SaidaPDFDiscreta)
                        //{
                        //    Console.WriteLine(item.ToString());
                        //}

                        // Retrieve values from the discrete PDF
                        double ValorCargaAposPDFDiscreta = SaidaPDFDiscreta[(PontoPDFSelecionado - 1) * 2];
                        double ProbabilidadeCargaAposPDFDiscreta = SaidaPDFDiscreta[(PontoPDFSelecionado - 1) * 2 + 1];
                        ProbabilidadeCombinacao *= ProbabilidadeCargaAposPDFDiscreta/100;

                        //Console.WriteLine("Valor Selecionado: ");

                        //Console.WriteLine("prob ind: " + ProbabilidadeCargaAposPDFDiscreta.ToString());
                        //Console.WriteLine("prob total: " + ProbabilidadeCombinacao.ToString());

                        // Update the load in OpenDSS and run the new power flow
                        int RetornoMod = DSSCircuit.Loads.First;
                        for (int contador_cargas = 0; contador_cargas < DSSCircuit.Loads.Count; contador_cargas++)
                        {
                            if(DSSCircuit.Loads.Name == CodigoCargaAtual)
                            {
                                double Fator_Multiplicativo_Carga = ValorCargaAposPDFDiscreta / DSSCircuit.Loads.kW;

                                DSSCircuit.Loads.kW *= Fator_Multiplicativo_Carga;
                                DSSCircuit.Loads.kvar *= Fator_Multiplicativo_Carga;
                            }

                            RetornoMod = DSSCircuit.Loads.Next;
                        }
                        IndiceAtualCarga++;

                    }

                    // Solve the power flow after updating the loads
                    DSSSolution.Solve();

                    // Get the output metric value and add it to the vector
                    if (comboGrandezaSaida.SelectedIndex==0)
                    {
                        // Option 0 – Losses
                        double[] PerdasMod = DSSCircuit.LineLosses;
                        VetorValorSaidaParaHistograma.Add(PerdasMod[0]);
                        // Console.WriteLine("Valor Saída: " + PerdasMod[0]);

                        VetorProbabilidadeSaidaParaHistograma.Add(ProbabilidadeCombinacao);
                        // Console.WriteLine("Probabilidade Saída: " + ProbabilidadeCombinacao);
                    }
                    else if (comboGrandezaSaida.SelectedIndex == 1)
                    {
                        // Option 1 – Investment

                        // Allowed conductors constraint
                        string string_restricao_condutores = "";
                        if (!(checkTodosCondutores.Checked))
                        {
                            string_restricao_condutores += "AND (";
                            int contador_condutores_selecionados = 0;
                            for (int contador_condutores = 1; contador_condutores  <= (int)chkCondutoresPermitidos.CheckedItems.Count; contador_condutores++)
                            {
                                contador_condutores_selecionados++;

                                string[] parametros1 = chkCondutoresPermitidos.CheckedItems[contador_condutores - 1].ToString().Split(SeparadorSplitBarra, StringSplitOptions.RemoveEmptyEntries);

                                if(contador_condutores_selecionados!=1)
                                {
                                    string_restricao_condutores += " OR ";
                                }
                                string_restricao_condutores += "CondutoresDestino.ID = " + parametros1[0] + " ";
                            }
                            string_restricao_condutores += ") ";
                        }
                        // Console.WriteLine("Rest. Cond.: " + string_restricao_condutores);


                        double ValorTotalInvestimentoCombinacao = 0;

                        // Evaluate line loading
                        int Retorno = DSSCircuit.Lines.First;
                        for (int contador_linhas = 0; contador_linhas < DSSCircuit.Lines.Count; contador_linhas++)
                        {
                                // Console.WriteLine("Linha: " + DSSCircuit.Lines.Name + " / LineCode: " + DSSCircuit.Lines.LineCode);

                            FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "LineName: " + DSSCircuit.Lines.Name + " / LineCode: " + DSSCircuit.Lines.LineCode, true);

                            DSSCircuit.SetActiveElement("Line." + DSSCircuit.Lines.Name);

                            double CapacidadeCondutorAtual;
                            if (DSSCircuit.Lines.LineCode!=null)
                                {
                                string queryCapacidadeAtual = "         SELECT      Condutores.ID, Condutores.descricao, Condutores.capacidade, Condutores.CodigoOpenDSS " +
                                "                                       FROM        Condutores " +
                                "                                       WHERE       Condutores.CodigoOpenDSS = " + DSSCircuit.Lines.LineCode + " " +
                                "                                       ";
                                DataTable dados_capacidade_atual = new DataTable();
                                SqlCeDataAdapter adaptador_capacidade_atual = new SqlCeDataAdapter(queryCapacidadeAtual, ProjectConstants.CONSTANTE_strConection);
                                SqlCeConnection conexao0 = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);
                                conexao0.Open();
                                adaptador_capacidade_atual.Fill(dados_capacidade_atual);

                                CapacidadeCondutorAtual = double.Parse(dados_capacidade_atual.Rows[0].ItemArray[2].ToString());
                                FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "Existing Conductor Capacity: " + CapacidadeCondutorAtual.ToString(), true);

                                conexao0.Close();
                                }
                            else
                                {
                                    CapacidadeCondutorAtual = ProjectConstants.CONSTANTE_CapacidadeChaves_emA;
                                }

                            bool LinhaEmSobrecarga = false;
                            string string_correntes_percentuais = "";
                            List<double> VetorCarregamentosAmperes = new List<double>();
                            double[] ValoresCorrentesFromOPENDSS = DSSCircuit.ActiveElement.CurrentsMagAng;
                            for (int contador = 0; contador < (ValoresCorrentesFromOPENDSS.Length / 2); contador += 2)
                            {
                                VetorCarregamentosAmperes.Add(ValoresCorrentesFromOPENDSS[contador]);

                                double CarregamentoPercentual = ValoresCorrentesFromOPENDSS[contador] / CapacidadeCondutorAtual * 100;
                                string_correntes_percentuais += CarregamentoPercentual + " [%] / ";

                                if (CarregamentoPercentual > double.Parse(txtCarregamentoLimite.Text))
                                {
                                    LinhaEmSobrecarga = true;
                                }
                            }

                            FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "Loading [A]:" + VetorCarregamentosAmperes.Max().ToString(), true);
                            FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "Loading [%]:" + string_correntes_percentuais, true);

                            if ((LinhaEmSobrecarga)&&(DSSCircuit.Lines.LineCode!=null))
                            {
                                SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

                                string string_ajuste_comprimento = "";
                                if (comboUnidadeComprimento.SelectedIndex == 0)
                                {
                                    // 1.000 ft
                                    string_ajuste_comprimento = " * 0.3048 * " + FunctionsFormatting.FormataNumeroSQL(DSSCircuit.Lines.Length.ToString()) + " ";
                                }
                                else if (comboUnidadeComprimento.SelectedIndex == 1)
                                {
                                    // km
                                    string_ajuste_comprimento = " * " + FunctionsFormatting.FormataNumeroSQL(DSSCircuit.Lines.Length.ToString()) + " ";
                                }
                                // Console.Write("ajuste comprimento: " + string_ajuste_comprimento);

                                string query = "        SELECT      TOP 1 CondutoresDestino.ID, CondutoresDestino.descricao, CondutoresDestino.capacidade, CondutoresDestino.CodigoOpenDSS, (Recondutoramento.custo_recondutoramento " + string_ajuste_comprimento + ") AS CustoTotalRecondutoramento " +
                                "                       FROM        Recondutoramento, Condutores AS CondutoresOrigem, Condutores AS CondutoresDestino " +
                                "                       WHERE       Recondutoramento.ID_Condutor_Origem = CondutoresOrigem.ID " +
                                "                       AND         Recondutoramento.ID_Condutor_Destino = CondutoresDestino.ID " +
                                "                       AND         CondutoresOrigem.CodigoOpenDSS = " + DSSCircuit.Lines.LineCode + " " +
                                "                       AND         CondutoresDestino.capacidade * " + FunctionsFormatting.FormataNumeroSQL(txtCarregamentoLimite.Text) + " / 100 >= " + FunctionsFormatting.FormataNumeroSQL(VetorCarregamentosAmperes.Max().ToString()) + " " +
                                "                       " + string_restricao_condutores + " " +
                                "                       ORDER BY    Recondutoramento.custo_recondutoramento ASC " +
                                "                       ";
                                // Console.WriteLine(query);
                                FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", query, true);

                                try
                                    {
                                    DataTable dados_condutores = new DataTable();
                                    SqlCeDataAdapter adaptador_condutores = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
                                    conexao.Open();
                                    adaptador_condutores.Fill(dados_condutores);

                                    if (dados_condutores.Rows.Count > 0)
                                    {
                                        foreach (DataRow linha in dados_condutores.Rows)
                                        {
                                            string string_linha = "";
                                            foreach(var item in linha.ItemArray)
                                            {
                                                string_linha += item + " / ";
                                            }
                                            // Console.WriteLine(string_linha);

                                            ValorTotalInvestimentoCombinacao += double.Parse(linha.ItemArray[4].ToString());

                                            FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "Reconductoring cost for this line: " + linha.ItemArray[4].ToString(), true);
                                            FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "OpenDSS Code for the Proposed Conductor: " + linha.ItemArray[3].ToString(), true);
                                            }
                                        }
                                    else
                                    {
                                        MessageBox.Show("No reconductoring options available for the line: '" + DSSCircuit.Lines.Name + "'. The values related to this reconductoring were not considered. ");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    conexao.Close();
                                }
                            }

                            Retorno = DSSCircuit.Lines.Next;
                        }

                        VetorValorSaidaParaHistograma.Add(ValorTotalInvestimentoCombinacao);
                        // Console.WriteLine("Valor Saída: " + ValorTotalInvestimentoCombinacao);
                        FunctionsTXTFile.GravaDadosArquivoTXT("Log1Year.txt", "Output value: " + ValorTotalInvestimentoCombinacao, true);

                        VetorProbabilidadeSaidaParaHistograma.Add(ProbabilidadeCombinacao);
                        // Console.WriteLine("Probabilidade Saída: " + ProbabilidadeCombinacao);
                    }

                        #endregion
                    }
                    else if (comboJanelaAnalise.SelectedIndex == 1)
                    {
                        #region 5-year analysis window (with optimization)

                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Start of Log File – 5-Year Analysis - " + DateTime.Now, false);

                        // Identify the PDF points for the current combination
                        string[] PontosSelecionadosPDFPorCarga = Combinacao.Split(SeparadorSplitPontoEVirgula, StringSplitOptions.RemoveEmptyEntries);

                        // For each load, determine its identifier and value
                        string CodigoCargaAtual = "";
                        double ValorCargaAtual = 0;
                        double ProbabilidadeCombinacao = 1;

                        int IndiceAtualCarga = 0;
                        foreach (var CargaEmAnalise in chkCargas.CheckedItems)
                        {
                            // Foreach for each load

                            int PontoPDFSelecionado = int.Parse(PontosSelecionadosPDFPorCarga[IndiceAtualCarga]);
                            // Console.WriteLine(PontoPDFAtual);

                            string[] SubItens = CargaEmAnalise.ToString().Split(SeparadorSplitBarra, StringSplitOptions.RemoveEmptyEntries);

                            // Identify the load identifier and its initial value
                            for (int contador_sub_itens = 1; contador_sub_itens <= SubItens.Count(); contador_sub_itens++)
                            {
                                string[] SubDivisao = SubItens[contador_sub_itens - 1].Split(SeparadorSplitDoisPontos, StringSplitOptions.RemoveEmptyEntries);

                                if (contador_sub_itens == 1)
                                {
                                    //Console.WriteLine("Código da Carga: " + SubDivisao[1]);
                                    CodigoCargaAtual = SubDivisao[1].Trim();
                                }
                                else if (contador_sub_itens == 2)
                                {
                                    // Console.WriteLine("Valor da Carga: " + SubDivisao[1]);
                                    ValorCargaAtual = double.Parse(SubDivisao[1]);
                                }
                            }

                            // Apply the discrete PDF to the load
                            List<double> SaidaPDFDiscreta = new List<double>();
                            SaidaPDFDiscreta = FunctionsStatistical.PDFDiscreta((int)comboPDF.SelectedValue, int.Parse(comboPontosPDF.SelectedItem.ToString()), ValorCargaAtual, double.Parse(txtDesvioPadraoRelativo.Text), double.Parse(comboLimiteInferiorPDF.SelectedItem.ToString()), double.Parse(comboLimiteSuperiorPDF.SelectedItem.ToString()));

                            //Console.WriteLine("Resultado PDF: ");
                            //foreach (double item in SaidaPDFDiscreta)
                            //{
                            //    Console.WriteLine(item.ToString());
                            //}

                            // Retrieve values from the discrete PDF
                            double ValorCargaAposPDFDiscreta = SaidaPDFDiscreta[(PontoPDFSelecionado - 1) * 2];
                            double ProbabilidadeCargaAposPDFDiscreta = SaidaPDFDiscreta[(PontoPDFSelecionado - 1) * 2 + 1];
                            ProbabilidadeCombinacao *= ProbabilidadeCargaAposPDFDiscreta / 100;

                            //Console.WriteLine("Valor Selecionado: ");

                            //Console.WriteLine("prob ind: " + ProbabilidadeCargaAposPDFDiscreta.ToString());
                            //Console.WriteLine("prob total: " + ProbabilidadeCombinacao.ToString());

                            // Update the load in OpenDSS
                            int RetornoMod = DSSCircuit.Loads.First;
                            for (int contador_cargas = 0; contador_cargas < DSSCircuit.Loads.Count; contador_cargas++)
                            {
                                if (DSSCircuit.Loads.Name == CodigoCargaAtual)
                                {
                                    double Fator_Multiplicativo_Carga = ValorCargaAposPDFDiscreta / DSSCircuit.Loads.kW;

                                    DSSCircuit.Loads.kW *= Fator_Multiplicativo_Carga;
                                    DSSCircuit.Loads.kvar *= Fator_Multiplicativo_Carga;
                                }

                                RetornoMod = DSSCircuit.Loads.Next;
                            }
                            IndiceAtualCarga++;

                        }

                        // Solve the power flow after updating the loads
                        DSSSolution.Solve();

                        // Determine the growth factors for each year
                        double FatorCrescimentoAno1Multiplicativo = (1 + double.Parse(txtFatorCrescimentoAno1.Text) / 100);
                        double FatorCrescimentoAno2Multiplicativo = (1 + double.Parse(txtFatorCrescimentoAno2.Text) / 100);
                        double FatorCrescimentoAno3Multiplicativo = (1 + double.Parse(txtFatorCrescimentoAno3.Text) / 100);
                        double FatorCrescimentoAno4Multiplicativo = (1 + double.Parse(txtFatorCrescimentoAno4.Text) / 100);
                        double FatorCrescimentoAno5Multiplicativo = (1 + double.Parse(txtFatorCrescimentoAno5.Text) / 100);
                        // Console.WriteLine(FatorCrescimentoAno1Multiplicativo + " / " + FatorCrescimentoAno2Multiplicativo + " / " + FatorCrescimentoAno3Multiplicativo + " / " + FatorCrescimentoAno4Multiplicativo + " / " + FatorCrescimentoAno5Multiplicativo);


                        // Console.WriteLine("Combinação #: " + contador_combinacoes);

                        // List the conductor codes of the base network
                        List<ParametrosBaseLinha> Linhas_CasoBase = new List<ParametrosBaseLinha>();
                        double ValorRecondutoramentoTodasAsLinhasDaCombinacao = 0;
                        int Retorno = DSSCircuit.Lines.First;
                        for (int contador_linhas = 0; contador_linhas < DSSCircuit.Lines.Count; contador_linhas++)
                        {
                            //Console.WriteLine("LineName: " + DSSCircuit.Lines.Name);

                            if (DSSCircuit.Lines.LineCode != null)
                            {
                                // Console.WriteLine("Name: " + DSSCircuit.Lines.Name + " / LineCode: " + DSSCircuit.Lines.LineCode);
                                FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Name: " + DSSCircuit.Lines.Name + " / LineCode: " + DSSCircuit.Lines.LineCode, true);

                                DSSCircuit.SetActiveElement("Line." + DSSCircuit.Lines.Name);

                                List<double> VetorCarregamentosAmperes = new List<double>();
                                double[] ValoresCorrentesFromOPENDSS = DSSCircuit.ActiveElement.CurrentsMagAng;
                                for (int contador = 0; contador < (ValoresCorrentesFromOPENDSS.Length / 2); contador += 2)
                                {
                                    VetorCarregamentosAmperes.Add(ValoresCorrentesFromOPENDSS[contador]);
                                }

                                ParametrosBaseLinha item_linha = new ParametrosBaseLinha();
                                item_linha.LineName = DSSCircuit.Lines.Name;
                                item_linha.LineCode = DSSCircuit.Lines.LineCode;
                                item_linha.Comprimento = DSSCircuit.Lines.Length;
                                item_linha.Carregamento_EmAmperes_Ano1 = VetorCarregamentosAmperes.Max()* FatorCrescimentoAno1Multiplicativo;
                                item_linha.Carregamento_EmAmperes_Ano2 = item_linha.Carregamento_EmAmperes_Ano1 * FatorCrescimentoAno2Multiplicativo;
                                item_linha.Carregamento_EmAmperes_Ano3 = item_linha.Carregamento_EmAmperes_Ano2 * FatorCrescimentoAno3Multiplicativo;
                                item_linha.Carregamento_EmAmperes_Ano4 = item_linha.Carregamento_EmAmperes_Ano3 * FatorCrescimentoAno4Multiplicativo;
                                item_linha.Carregamento_EmAmperes_Ano5 = item_linha.Carregamento_EmAmperes_Ano4 * FatorCrescimentoAno5Multiplicativo;

                                Linhas_CasoBase.Add(item_linha);

                                // Console.WriteLine(VetorCarregamentosAmperes.Max() + " / " + item_linha.Carregamento_EmAmperes_Ano1 + " / " + item_linha.Carregamento_EmAmperes_Ano2 + " / " + item_linha.Carregamento_EmAmperes_Ano3 + " / " + item_linha.Carregamento_EmAmperes_Ano4 + " / " + item_linha.Carregamento_EmAmperes_Ano5);
                                FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", VetorCarregamentosAmperes.Max() + " / " + item_linha.Carregamento_EmAmperes_Ano1 + " / " + item_linha.Carregamento_EmAmperes_Ano2 + " / " + item_linha.Carregamento_EmAmperes_Ano3 + " / " + item_linha.Carregamento_EmAmperes_Ano4 + " / " + item_linha.Carregamento_EmAmperes_Ano5, true);

                                double ValorRecondutoramentoDoTrecho = FunctionsOptimization.ValorRecondutoramentoOtimizadoPorTrecho_BuscaExaustiva(contador_combinacoes, item_linha, checkTodosCondutores, chkCondutoresPermitidos, comboUnidadeComprimento, double.Parse(txtCarregamentoLimite.Text));
                                ValorRecondutoramentoTodasAsLinhasDaCombinacao += ValorRecondutoramentoDoTrecho;
                                // Console.WriteLine("Valor total do trecho: " + ValorRecondutoramentoDoTrecho);
                                // Console.WriteLine("Valor total acumulado: " + ValorRecondutoramentoTodasAsLinhasDaCombinacao);

                                FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Total Segment Cost: " + ValorRecondutoramentoDoTrecho, true);
                                FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Total Accumulated Cost: " + ValorRecondutoramentoTodasAsLinhasDaCombinacao, true);
                            }

                            Retorno = DSSCircuit.Lines.Next;
                        }

                        Console.WriteLine("Total Value of the Load Combination: " + ValorRecondutoramentoTodasAsLinhasDaCombinacao);
                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Total Value of the Load Combination: " + ValorRecondutoramentoTodasAsLinhasDaCombinacao, true);

                        VetorValorSaidaParaHistograma.Add(ValorRecondutoramentoTodasAsLinhasDaCombinacao);
                        VetorProbabilidadeSaidaParaHistograma.Add(ProbabilidadeCombinacao);

                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "End of Log File – 5-Year Analysis - " + DateTime.Now, true);

                        #endregion

                    }

                    // Reset the OpenDSS circuit
                    DSSText.Command = "Compile " + '"' + file_to_open + '"';
                    DSSSolution.Solve();
                }

                #region Build the histogram

                // Build the expanded sample series.
                int MaximoPontosCurvaPDF = 10000;
                List<double> VetorValorSaidaEXPANDIDAParaHistograma = new List<double>();

                for (int contador_cenarios = 1; contador_cenarios <= VetorValorSaidaParaHistograma.Count; contador_cenarios++)
                {
                    //                     Console.WriteLine("cenário: " + contador_cenarios);

                    int QuantidadePontosPDF = int.Parse(Math.Round(VetorProbabilidadeSaidaParaHistograma[contador_cenarios - 1] * MaximoPontosCurvaPDF, 0).ToString());

                    for (int contador_pontos_PDF_expandida = 1; contador_pontos_PDF_expandida <= QuantidadePontosPDF; contador_pontos_PDF_expandida++)
                    {
                        VetorValorSaidaEXPANDIDAParaHistograma.Add(VetorValorSaidaParaHistograma[contador_cenarios - 1]);
                    }

                    //                    Console.WriteLine(QuantidadePontosPDF);
                }

                // Console.WriteLine("total pontos expandida: " + VetorValorSaidaEXPANDIDAParaHistograma.Count);
                //Console.WriteLine(VetorProbabilidadeSaidaParaHistograma.Min());

                //MessageBox.Show(comboClassesHistograma.SelectedItem.ToString());
                Histogram histograma = new Histogram(VetorValorSaidaEXPANDIDAParaHistograma, int.Parse(comboClassesHistograma.SelectedItem.ToString()), comboGrandezaSaida.SelectedIndex);
                histograma.ShowDialog();
                #endregion

                // ********************************
                // ********************************
                // ********************************

                #endregion



            }
        }

        private void txtFatorCrescimentoAno1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno1_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno1_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno1_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno2_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno3_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno4_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno5_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno2_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno3_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno4_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno5_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno2_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno3_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno4_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno5_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }

        private void txtFatorCrescimentoAno2_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno3_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno4_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void txtFatorCrescimentoAno5_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void checkTodosCondutores_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(checkTodosCondutores.Checked.ToString());

            if (checkTodosCondutores.Checked)
            {
                for(int contador_itens=0;contador_itens< chkCondutoresPermitidos.Items.Count;contador_itens++)
                {
                    chkCondutoresPermitidos.SetItemChecked(contador_itens, false);
                }
                chkCondutoresPermitidos.Enabled = false;
            }
            else
            {
                chkCondutoresPermitidos.Enabled = true;
            }
        }

        private void checkTodosCondutores_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoCheckBox((CheckBox)sender, e);

        }

        private void chkCondutoresPermitidos_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoCheckedListBox((CheckedListBox)sender, e);

        }


        private void txtDesvioPadraoRelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);

        }


        private void txtDesvioPadraoRelativo_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

            RecalculaCenariosSimulados();

        }

        private void txtDesvioPadraoRelativo_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }


        private void txtDesvioPadraoRelativo_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void chkCargas_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoCheckedListBox((CheckedListBox)sender, e);

        }

        private void checkCargasAleatorias_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoCheckBox((CheckBox)sender, e);

        }

        private void checkCargasAleatorias_CheckedChanged(object sender, EventArgs e)
        {
            for (int contador_itens = 0; contador_itens < chkCargas.Items.Count; contador_itens++)
            {
                chkCargas.SetItemChecked(contador_itens, false);
            }

            if (checkCargasAleatorias.Checked)
            {
                chkCargas.Enabled = false;
                comboQuantidadeCargasAleatorias.Enabled = true;
                comboTipoAleatorio.Enabled = true;
            }
            else
            {
                chkCargas.Enabled = true;
                comboQuantidadeCargasAleatorias.Enabled = false;
                comboTipoAleatorio.Enabled = false;
            }

            RecalculaCenariosSimulados();
        }

        private void comboPontosPDF_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboLimiteInferiorPDF_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboLimiteSuperiorPDF_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboQuantidadeCargasAleatorias_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboGrandezaSaida_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboClassesHistograma_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void txtCarregamentoLimite_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }

        private void txtCarregamentoLimite_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void txtCarregamentoLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);

        }

        private void txtCarregamentoLimite_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

        }

        private void comboUnidadeComprimento_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboJanelaAnalise_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboJanelaAnalise_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboJanelaAnalise.SelectedIndex == 0)
            {
                comboAlgoritmo.Enabled = false;
                comboAlgoritmo.SelectedIndex = -1;
                txtFatorCrescimentoAno2.Enabled = false;
                txtFatorCrescimentoAno2.Text = "";
                txtFatorCrescimentoAno3.Enabled = false;
                txtFatorCrescimentoAno3.Text = "";
                txtFatorCrescimentoAno4.Enabled = false;
                txtFatorCrescimentoAno4.Text = "";
                txtFatorCrescimentoAno5.Enabled = false;
                txtFatorCrescimentoAno5.Text = "";
                comboGrandezaSaida.Enabled = true;
            }
            else
            {
                comboAlgoritmo.Enabled = true;
                comboAlgoritmo.SelectedIndex = 0;
                txtFatorCrescimentoAno2.Enabled = true;
                txtFatorCrescimentoAno2.Text = ValorPadraoCarregamentoAno2;
                txtFatorCrescimentoAno3.Enabled = true;
                txtFatorCrescimentoAno3.Text = ValorPadraoCarregamentoAno3;
                txtFatorCrescimentoAno4.Enabled = true;
                txtFatorCrescimentoAno4.Text = ValorPadraoCarregamentoAno4;
                txtFatorCrescimentoAno5.Enabled = true;
                txtFatorCrescimentoAno5.Text = ValorPadraoCarregamentoAno5;
                comboGrandezaSaida.Enabled = false;
                comboGrandezaSaida.SelectedIndex = 1;
            }
        }

        private void comboPontosPDF_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculaCenariosSimulados();

        }

        private void comboQuantidadeCargasAleatorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculaCenariosSimulados();

        }

        private void chkCargas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            RecalculaCenariosSimulados();

        }

        private void chkCargas_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculaCenariosSimulados();

        }
    }
}

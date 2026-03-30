using MathNet.Numerics.LinearAlgebra.Factorization;
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

namespace PowerPlan
{
    public partial class ResultsAnalysis : Form
    {
        public ResultsAnalysis()
        {
            InitializeComponent();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        static public void GeraArquivoHistogramaMATLAB(int QuantidadeClasses, int LimiteEmX)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            string ComandoMATLAB = "clear; \n clc; \n DadosHistograma=[";
            FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, false);

            try
            {
                conexao.Open();

                string query = "SELECT DISTINCT      CombinacaoCargas " +
                               "FROM                 ResultadosOtimizacao " +
                               "ORDER BY             CombinacaoCargas ";
                // Console.WriteLine(query);
                DataTable dados_ListaCombinacoes = new DataTable();
                SqlCeDataAdapter adaptador_ListaCombinacoes = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
                adaptador_ListaCombinacoes.Fill(dados_ListaCombinacoes);

                foreach(DataRow linhaCombinacao in dados_ListaCombinacoes.Rows)
                {
                    //Console.WriteLine("C: " + linha.ItemArray[0]);
                    string CombinacaoAtual = linhaCombinacao.ItemArray[0].ToString();
                    double SomaInvestimentos = 0;

                    query = "SELECT      CombinacaoCargas, LineName, Min(custo_combinacao_condutores_para_o_trecho) " +
                            "FROM        ResultadosOtimizacao " +
                            "WHERE       CombinacaoCargas = " + CombinacaoAtual + " " +
                            "GROUP BY    CombinacaoCargas, LineName ";
                    //Console.WriteLine(query);
                    DataTable dados_Histograma = new DataTable();
                    SqlCeDataAdapter adaptador_Histograma = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
                    adaptador_Histograma.Fill(dados_Histograma);

                    foreach(DataRow linhaCusto in dados_Histograma.Rows)
                    {
                        SomaInvestimentos += double.Parse(linhaCusto.ItemArray[2].ToString());
                    }

                    ComandoMATLAB = FunctionsFormatting.FormataNumeroSQL(SomaInvestimentos.ToString()) + ", ";
                    FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);


                }

                ComandoMATLAB = "]; \n [Y, X] = hist(DadosHistograma, " + QuantidadeClasses + "); Y = Y / sum(Y) * 100; figure('Color',[1 1 1]); hold on; grid on; bar(X, Y, 1);  ";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);

                ComandoMATLAB = "xlabel('Investment value (in USD)'); \n ylabel('Probability of occurrence (%)'); ";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);

                ComandoMATLAB = "set(gca, 'Xcolor',[0.3 0.3 0.3]); \n set(gca, 'Ycolor',[0.3 0.3 0.3]);";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);

                ComandoMATLAB = "screenSize = get(0, 'ScreenSize'); \n width = 880; \n height = 660; \n  x = (screenSize(3) - width) / 2; \n  y = (screenSize(4) - height) / 2; \n set(gca,'FontSize', 12); \n set(gcf, 'Position', [x, y, width, height]); \n xtickformat('%,.1f'); ytickformat('%,.1f');";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);

                ComandoMATLAB = "LimiteSuperiorX = (floor(max(X)) + " + LimiteEmX + "); \n LimiteInferiorX = (floor(min(X)) - " + LimiteEmX + "); \n if (LimiteInferiorX == LimiteSuperiorX) \n LimiteSuperiorX = LimiteSuperiorX + " + LimiteEmX + "; \n LimiteInferiorX = LimiteInferiorX - " + LimiteEmX + "; \n end";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);

                ComandoMATLAB = "LimiteSuperiorY = (floor(max(Y)) + 1); \n axis([LimiteInferiorX, LimiteSuperiorX, 0, LimiteSuperiorY]);";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);

                ComandoMATLAB = "ValorLimiteINFERIORIntervaloConfianca = prctile(DadosHistograma, (100 - 95) / 2); \n plot([ValorLimiteINFERIORIntervaloConfianca ValorLimiteINFERIORIntervaloConfianca], [0 LimiteSuperiorY], 'Color', 'r', 'LineWidth', 2);";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);

                ComandoMATLAB = "ValorLimiteSUPERIORIntervaloConfianca = prctile(DadosHistograma, 100 - (100 - 95) / 2); \n plot([ValorLimiteSUPERIORIntervaloConfianca ValorLimiteSUPERIORIntervaloConfianca], [0 LimiteSuperiorY], 'Color', 'r', 'LineWidth', 2);";
                FunctionsTXTFile.GravaDadosArquivoTXT("histogram.m", ComandoMATLAB, true);
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

        static public void GeraArquivoResultadosRedeMATLAB(ComboBox combo_cenario, ComboBox combo_ano)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            var RetornoFuncaoCoordenadas = FunctionsDiagram.GeraListasCoordenadasRede();

            string ComandoMATLAB = "clear; \n clc; \n hFig = figure(1); \n screenSize = get(0, 'ScreenSize'); \n width = 880; \n height = 660; \n  x = (screenSize(3) - width) / 2; \n  y = (screenSize(4) - height) / 2; \n  set(gcf, 'Position', [x, y, width, height]); \n subplot('Position', [0.10 0.10 0.60 0.80]); \n hold on; \n grid on; xtickformat('%,.0f'); ytickformat('%,.0f');";
            FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, false);

            ComandoMATLAB = "xlabel('X coordinate (m)'); \n ylabel('Y coordinate (m)'); ";
            FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);

            ComandoMATLAB = "set(gca, 'Xcolor',[0.3 0.3 0.3]); \n set(gca, 'Ycolor',[0.3 0.3 0.3]);";
            FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);

            double LimiteInferiorX = Math.Truncate(RetornoFuncaoCoordenadas.RETORNOCoordenadasX.Min() / 500) * 500;
            double LimiteInferiorY = Math.Truncate(RetornoFuncaoCoordenadas.RETORNOCoordenadasY.Min() / 500) * 500;
            double LimiteSuperiorX = (Math.Truncate(RetornoFuncaoCoordenadas.RETORNOCoordenadasX.Max() / 500) + 1) * 500;
            double LimiteSuperiorY = (Math.Truncate(RetornoFuncaoCoordenadas.RETORNOCoordenadasY.Max() / 500) + 1) * 500;

            ComandoMATLAB = "axis([" + LimiteInferiorX + ", " + LimiteSuperiorX + ", " + LimiteInferiorY + ", " + LimiteSuperiorY + "]); ";
            FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);
            //Console.WriteLine("LimiteInferiorX: " + LimiteInferiorX);
            //Console.WriteLine("LimiteInferiorY: " + LimiteInferiorY);
            //Console.WriteLine("LimiteSuperiorX: " + LimiteSuperiorX);
            //Console.WriteLine("LimiteSuperiorY: " + LimiteSuperiorY);

            ComandoMATLAB = "set(gca, 'XTick',[" + LimiteInferiorX + ":500:" + LimiteSuperiorX + "]); \n set(gca, 'YTick',[" + LimiteInferiorY + ":500:" + LimiteSuperiorY + "]); ";
            FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);

            List<double> ID_Condutores_para_Legenda = new List<double>();

            int contador_trechos;
            for (contador_trechos = 0; contador_trechos < RetornoFuncaoCoordenadas.RETORNOCoordenadasX1.Count(); contador_trechos++)
            {
                string DescricaoCorMATLAB = "";
                string LarguraLinhaTrecho = "";
                string DetalhamentoRecondutoramento_AnoSelecionado = "";
                bool ConferenciaIDstodosIguais = true;

                try
                {
                    string query = "SELECT      TOP 1 CombinacaoCargas, LineName, ID_Condutor_Ano1, ID_Condutor_Ano2, ID_Condutor_Ano3, ID_Condutor_Ano4, ID_Condutor_Ano5, custo_combinacao_condutores_para_o_trecho, ID_Condutor_Atual, DetalhamentoRecondutoramento_Ano1, DetalhamentoRecondutoramento_Ano2, DetalhamentoRecondutoramento_Ano3, DetalhamentoRecondutoramento_Ano4, DetalhamentoRecondutoramento_Ano5 " +
                                   "FROM        ResultadosOtimizacao " +
                                   "WHERE       CombinacaoCargas = " + combo_cenario.SelectedValue + " " +
                                   "AND         LineName = '" + RetornoFuncaoCoordenadas.RETORNOLineNames[contador_trechos] + "' " +
                                   "ORDER BY    custo_combinacao_condutores_para_o_trecho ASC ";
                    Console.WriteLine(query);
                    DataTable dados_resultado = new DataTable();
                    
                    SqlCeDataAdapter adaptador_resultado = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                    conexao.Open();

                    adaptador_resultado.Fill(dados_resultado);
                    if(dados_resultado.Rows.Count > 0)
                    {
                        string ConferenciaIDsCondutor = dados_resultado.Rows[0].ItemArray[8].ToString() + " / " + dados_resultado.Rows[0].ItemArray[2].ToString() + " / " + dados_resultado.Rows[0].ItemArray[3].ToString() + " / " + dados_resultado.Rows[0].ItemArray[4].ToString() + " / " + dados_resultado.Rows[0].ItemArray[5].ToString() + " / " + dados_resultado.Rows[0].ItemArray[6].ToString() + " / " + dados_resultado.Rows[0].ItemArray[7].ToString();
                        Console.WriteLine(ConferenciaIDsCondutor);
                        List<int> LISTA_ConferenciaIDsCondutor = new List<int>();
                        LISTA_ConferenciaIDsCondutor.Add(int.Parse(dados_resultado.Rows[0].ItemArray[8].ToString()));
                        LISTA_ConferenciaIDsCondutor.Add(int.Parse(dados_resultado.Rows[0].ItemArray[2].ToString()));
                        LISTA_ConferenciaIDsCondutor.Add(int.Parse(dados_resultado.Rows[0].ItemArray[3].ToString()));
                        LISTA_ConferenciaIDsCondutor.Add(int.Parse(dados_resultado.Rows[0].ItemArray[4].ToString()));
                        LISTA_ConferenciaIDsCondutor.Add(int.Parse(dados_resultado.Rows[0].ItemArray[5].ToString()));
                        LISTA_ConferenciaIDsCondutor.Add(int.Parse(dados_resultado.Rows[0].ItemArray[6].ToString()));

                        ConferenciaIDstodosIguais = LISTA_ConferenciaIDsCondutor.All(x => x == LISTA_ConferenciaIDsCondutor[0]);

                        if(ConferenciaIDstodosIguais)
                        {
                            LarguraLinhaTrecho = "2";
                        }
                        else
                        {
                            LarguraLinhaTrecho = "5";
                        }

                        double ID_Condutor_Ano_Selecionado =0;
                        switch (combo_ano.SelectedItem.ToString())
                        {
                            case "Year #0 - Reference Case":
                                ID_Condutor_Ano_Selecionado = double.Parse(dados_resultado.Rows[0].ItemArray[8].ToString());
                                DetalhamentoRecondutoramento_AnoSelecionado = "Reference Case";
                                break;
                            case "Year #1":
                                ID_Condutor_Ano_Selecionado = double.Parse(dados_resultado.Rows[0].ItemArray[2].ToString());
                                DetalhamentoRecondutoramento_AnoSelecionado = dados_resultado.Rows[0].ItemArray[9].ToString();
                                break;
                            case "Year #2":
                                ID_Condutor_Ano_Selecionado = double.Parse(dados_resultado.Rows[0].ItemArray[3].ToString());
                                DetalhamentoRecondutoramento_AnoSelecionado = dados_resultado.Rows[0].ItemArray[10].ToString();
                                break;
                            case "Year #3":
                                ID_Condutor_Ano_Selecionado = double.Parse(dados_resultado.Rows[0].ItemArray[4].ToString());
                                DetalhamentoRecondutoramento_AnoSelecionado = dados_resultado.Rows[0].ItemArray[11].ToString();
                                break;
                            case "Year #4":
                                ID_Condutor_Ano_Selecionado = double.Parse(dados_resultado.Rows[0].ItemArray[5].ToString());
                                DetalhamentoRecondutoramento_AnoSelecionado = dados_resultado.Rows[0].ItemArray[12].ToString();
                                break;
                            case "Year #5":
                                ID_Condutor_Ano_Selecionado = double.Parse(dados_resultado.Rows[0].ItemArray[6].ToString());
                                DetalhamentoRecondutoramento_AnoSelecionado = dados_resultado.Rows[0].ItemArray[13].ToString();
                                break;
                            default:

                                break;
                        }

                        ID_Condutores_para_Legenda.Add(ID_Condutor_Ano_Selecionado);

                        query = "SELECT      ID, descricao, CorR, CorG, CorB " +
                                "FROM        CoresCondutores " +
                                "WHERE       ID = " + ID_Condutor_Ano_Selecionado + " ";
                        //Console.WriteLine(query);
                        DataTable dados_CorCondutor = new DataTable();
                        SqlCeDataAdapter adaptador_CorCondutor = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
                        adaptador_CorCondutor.Fill(dados_CorCondutor);


                        DescricaoCorMATLAB = "'Color', [" + dados_CorCondutor.Rows[0].ItemArray[2].ToString() + ", " + dados_CorCondutor.Rows[0].ItemArray[3].ToString() + ", " + dados_CorCondutor.Rows[0].ItemArray[4].ToString() + "]/255" + ", ";
                        Console.WriteLine(DescricaoCorMATLAB);
                    }
                    else
                    {
                        Console.WriteLine(RetornoFuncaoCoordenadas.RETORNOLineNames[contador_trechos]);
                        DescricaoCorMATLAB = "'Color', [0, 0, 0]/255" + ", ";
                        LarguraLinhaTrecho = "2";
                    }

                    //foreach(DataRow linha in dados_resultado.Rows)
                    //{
                    //    Console.WriteLine(linha.ItemArray[7]);
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conexao.Close();
                }

                ComandoMATLAB = "plot([" + RetornoFuncaoCoordenadas.RETORNOCoordenadasX1[contador_trechos] + " " + RetornoFuncaoCoordenadas.RETORNOCoordenadasX2[contador_trechos] + "], [" + RetornoFuncaoCoordenadas.RETORNOCoordenadasY1[contador_trechos] + " " + RetornoFuncaoCoordenadas.RETORNOCoordenadasY2[contador_trechos] + "], " + DescricaoCorMATLAB + "'LineWidth', " + LarguraLinhaTrecho + "); ";
                FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);
                //Console.WriteLine(ComandoMATLAB);

                if (!(ConferenciaIDstodosIguais))
                {
                    double CoordenadaXTexto = 0;
                    double CoordenadaYTexto = 0;

                    if(RetornoFuncaoCoordenadas.RETORNOCoordenadasX1[contador_trechos]== RetornoFuncaoCoordenadas.RETORNOCoordenadasX2[contador_trechos])
                    {
                        CoordenadaXTexto = RetornoFuncaoCoordenadas.RETORNOCoordenadasX1[contador_trechos] + 50;
                        CoordenadaYTexto = (RetornoFuncaoCoordenadas.RETORNOCoordenadasY1[contador_trechos] + RetornoFuncaoCoordenadas.RETORNOCoordenadasY2[contador_trechos]) / 2;
                    }
                    else
                    {
                        CoordenadaYTexto = RetornoFuncaoCoordenadas.RETORNOCoordenadasY1[contador_trechos] + 80;
                        CoordenadaXTexto = ((RetornoFuncaoCoordenadas.RETORNOCoordenadasX1[contador_trechos] + RetornoFuncaoCoordenadas.RETORNOCoordenadasX2[contador_trechos]) / 2) - 50;
                    }

                    ComandoMATLAB = "text(" + CoordenadaXTexto + ", " + CoordenadaYTexto + ", '" + RetornoFuncaoCoordenadas.RETORNOLineNames[contador_trechos] + "', 'FontSize', 8); ";
                    FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);
                }

                ComandoMATLAB = "fprintf('" + DetalhamentoRecondutoramento_AnoSelecionado + "'); ";
                FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);
            }



            int contador_barras;
            for (contador_barras = 0; contador_barras < RetornoFuncaoCoordenadas.RETORNOCoordenadasX.Count(); contador_barras++)
            {
                ComandoMATLAB = "r = 3; x = " + RetornoFuncaoCoordenadas.RETORNOCoordenadasX[contador_barras] + "; y = " + RetornoFuncaoCoordenadas.RETORNOCoordenadasY[contador_barras] + "; th = 0:pi / 50:2 * pi; xunit = r * cos(th) + x; yunit = r * sin(th) + y; h = plot(xunit, yunit, 'k', 'LineWidth', 3);";
                FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);
            }


            try
            {
                conexao.Open();

                List<double> ID_Condutores_para_Legenda_Sem_Repeticoes = ID_Condutores_para_Legenda.Distinct().ToList();

                string string_ID_Legenda = "";
                int contador_ID_Legenda = 0;
                foreach (double ID_Item in ID_Condutores_para_Legenda_Sem_Repeticoes)
                {
                    if (contador_ID_Legenda > 0)
                    {
                        string_ID_Legenda += " OR ";
                    }
                    else
                    {
                        string_ID_Legenda += "( ";
                    }
                    string_ID_Legenda += "CoresCondutores.ID = " + ID_Item + " ";
                    contador_ID_Legenda++;
                }
                string_ID_Legenda += ") ";
                //Console.WriteLine(string_ID_Legenda);

                string query_condutores_legenda = "SELECT      CoresCondutores.ID, CoresCondutores.descricao, CorR, CorG, CorB, Condutores.descricao " +
                                                  "FROM        CoresCondutores, Condutores " +
                                                  "WHERE       CoresCondutores.ID = Condutores.ID " +
                                                  "AND         " + string_ID_Legenda + " ";
                Console.WriteLine(query_condutores_legenda);
                DataTable dados_condutores_legenda = new DataTable();
                SqlCeDataAdapter adaptador_condutores_legenda = new SqlCeDataAdapter(query_condutores_legenda, ProjectConstants.CONSTANTE_strConection);
                adaptador_condutores_legenda.Fill(dados_condutores_legenda);


                ComandoMATLAB = "subplot('Position', [0.75 0.10 0.20 0.80]); \n hold on; \n grid on; xtickformat('%,.0f'); ytickformat('%,.0f'); set(gca, 'XTick', [], 'YTick', []); ";
                FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);

                string string_Descricao_Legenda = "";
                foreach(DataRow linha in dados_condutores_legenda.Rows)
                {
                    string_Descricao_Legenda += "'" + linha.ItemArray[5].ToString() + "', ";

                    ComandoMATLAB = "plot([10 20], [10 10], 'Color', [" + linha.ItemArray[2].ToString() + ", " + linha.ItemArray[3].ToString() + ", " + linha.ItemArray[4].ToString() + "]/ 255, 'LineWidth', 2); ";
                    FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);
                }

                ComandoMATLAB = " legend(" + string_Descricao_Legenda + " 'Location', 'best'); \n axis([0, 1, 0, 1]); \n legend('Location', 'best'); \n set(gca, 'XColor', 'none', 'YColor', 'none'); ";
                FunctionsTXTFile.GravaDadosArquivoTXT("results_chart.m", ComandoMATLAB, true);

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

        private void Exportar_Click(object sender, EventArgs e)
        {
            if(GraficoRede.Checked)
            {
                GeraArquivoResultadosRedeMATLAB(comboCenario, comboAno);
            }
            else
            {
                //Console.WriteLine("Tol: " + ToleranciaLimiteX.SelectedItem.ToString().Replace(".", ""));

                GeraArquivoHistogramaMATLAB(int.Parse(comboClassesHistograma.SelectedItem.ToString()), int.Parse(ToleranciaLimiteX.SelectedItem.ToString().Replace(".", "")));
            }

            MessageBox.Show("Results export completed successfully! \n\nFile saved at " + Application.StartupPath);

        }

        private void comboCenario_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboAno_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void AnaliseResultados_Load(object sender, EventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {

                string query = "SELECT DISTINCT CombinacaoCargas, 'Scenario #' + CAST(CombinacaoCargas AS NVARCHAR(255)) AS Descricao FROM ResultadosOtimizacao ORDER BY CombinacaoCargas";
                DataTable dados_cenario = new DataTable();

                SqlCeDataAdapter adaptador_cenario = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                conexao.Open();

                adaptador_cenario.Fill(dados_cenario);

                comboCenario.DataSource = dados_cenario;
                comboCenario.ValueMember = "CombinacaoCargas";
                comboCenario.DisplayMember = "Descricao";

                comboAno.Items.Clear();
                comboAno.Items.Add("Year #0 - Reference Case");
                comboAno.Items.Add("Year #1");
                comboAno.Items.Add("Year #2");
                comboAno.Items.Add("Year #3");
                comboAno.Items.Add("Year #4");
                comboAno.Items.Add("Year #5");
                comboAno.SelectedIndex = 0;

                GraficoRede.Checked = true;

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

                ToleranciaLimiteX.Items.Clear();
                ToleranciaLimiteX.Items.Add("1.000");
                ToleranciaLimiteX.Items.Add("10.000");
                ToleranciaLimiteX.Items.Add("100.000");
                ToleranciaLimiteX.SelectedIndex = 1;

                labelLimiteX.Text = "X-axis limit (\u00B1):";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            comboCenario.Focus();

        }

        private void AtualizaRadioButton ()
        {
            if(GraficoRede.Checked)
            {
                comboCenario.Enabled = true;
                comboAno.Enabled = true;
                comboClassesHistograma.Enabled = false;
                ToleranciaLimiteX.Enabled = false;
            }
            else
            {
                comboCenario.Enabled = false;
                comboAno.Enabled = false;
                comboClassesHistograma.Enabled = true;
                ToleranciaLimiteX.Enabled = true;

            }

        }

        private void GraficoRede_CheckedChanged(object sender, EventArgs e)
        {
            AtualizaRadioButton();

        }

        private void Histograma_CheckedChanged(object sender, EventArgs e)
        {
            AtualizaRadioButton();
        }

        private void comboClassesHistograma_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);
        }
    }
}

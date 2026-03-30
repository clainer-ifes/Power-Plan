using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PowerPlan
{
    public static class FunctionsOptimization
    {
        public struct ParametrosBaseLinha
        {
            public string LineName;
            public string LineCode;
            public double Comprimento;
            public double Carregamento_EmAmperes_Ano1;
            public double Carregamento_EmAmperes_Ano2;
            public double Carregamento_EmAmperes_Ano3;
            public double Carregamento_EmAmperes_Ano4;
            public double Carregamento_EmAmperes_Ano5;

        }


        static public void LimpaTabelaResultadosOtimizacao()
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);
            conexao.Open();

            SqlCeCommand comando = new SqlCeCommand();
            comando.Connection = conexao;

            comando.CommandText = "DELETE FROM ResultadosOtimizacao ";

            comando.ExecuteNonQuery();

            comando.Dispose();
        }

        static public double ValorRecondutoramentoOtimizadoPorTrecho_BuscaExaustiva(int ContadorCombinacaoCargas, ParametrosBaseLinha trecho, CheckBox ParametroTodosCondutores, CheckedListBox ParametroCondutoresPermitidos, ComboBox ParametroUnidadeComprimento, double ParametroCarregamentoLimite)
        {
            string texto_combinacao_CorrenteAtual = "";
            texto_combinacao_CorrenteAtual += trecho.Carregamento_EmAmperes_Ano1 + " / ";
            texto_combinacao_CorrenteAtual += trecho.Carregamento_EmAmperes_Ano2 + " / ";
            texto_combinacao_CorrenteAtual += trecho.Carregamento_EmAmperes_Ano3 + " / ";
            texto_combinacao_CorrenteAtual += trecho.Carregamento_EmAmperes_Ano4 + " / ";
            texto_combinacao_CorrenteAtual += trecho.Carregamento_EmAmperes_Ano5 + " / ";
            // Console.WriteLine(texto_combinacao_CorrenteAtual);


            // ##########################
            // Define the constant used in the process
            // ##########################
            char[] SeparadorSplitBarra = new char[] { '/' };

            // ##########################
            // Define the function return variable, initialized to 0.
            // ##########################
            List<double> Vetor_ValoresTotaisCombinacoes = new List<double>();

            // ##########################
            // Create the database connection.
            // ##########################
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);
            conexao.Open();

            // ##########################
            // Retrieve the ampacity (current-carrying capacity) of the existing conductor
            // ##########################
            string query_dados_condutor_atual = "  SELECT      Condutores.capacidade, ID " +
            "                                           FROM        Condutores " +
            "                                           WHERE       Condutores.CodigoOpenDSS = " + trecho.LineCode + "; ";
            DataTable dados_condutor_atual = new DataTable();
            SqlCeDataAdapter adaptador_dados_condutor_atual = new SqlCeDataAdapter(query_dados_condutor_atual, ProjectConstants.CONSTANTE_strConection);
            adaptador_dados_condutor_atual.Fill(dados_condutor_atual);
            double capacidade_condutor_atual = double.Parse(dados_condutor_atual.Rows[0].ItemArray[0].ToString());
            int ID_condutor_atual = int.Parse(dados_condutor_atual.Rows[0].ItemArray[1].ToString());
            //Console.WriteLine("Capacidade condutor atual: " + capacidade_condutor_atual);
            // Console.WriteLine("ID condutor atual: " + ID_condutor_atual);


            // ##########################
            // Check whether there is a restriction on the selected conductors.
            // ##########################
            string string_restricao_condutores_Disponiveis = "";
            if (!(ParametroTodosCondutores.Checked))
            {
                string_restricao_condutores_Disponiveis += "AND (CondutoresDestino.ID = " + ID_condutor_atual + " ";
                int contador_condutores_selecionados = 0;
                for (int contador_condutores = 1; contador_condutores <= (int)ParametroCondutoresPermitidos.CheckedItems.Count; contador_condutores++)
                {
                    contador_condutores_selecionados++;

                    string[] parametros1 = ParametroCondutoresPermitidos.CheckedItems[contador_condutores - 1].ToString().Split(SeparadorSplitBarra, StringSplitOptions.RemoveEmptyEntries);

                    string_restricao_condutores_Disponiveis += " OR CondutoresDestino.ID = " + parametros1[0] + " ";
                }
                string_restricao_condutores_Disponiveis += ") ";
            }
            // Console.WriteLine("Rest. Cond.: " + string_restricao_condutores);

            // ##########################
            // Build the string to apply the length adjustment
            // ##########################
            string string_ajuste_comprimento = "";
            double ComprimentoAjustado = 0;

            if (ParametroUnidadeComprimento.SelectedIndex == 0)
            {
                // 1.000 ft
                string_ajuste_comprimento = " * 0.3048 * " + FunctionsFormatting.FormataNumeroSQL(trecho.Comprimento.ToString()) + " ";
                ComprimentoAjustado = 0.3048 * trecho.Comprimento;
            }
            else if (ParametroUnidadeComprimento.SelectedIndex == 1)
            {
                // km
                string_ajuste_comprimento = " * " + FunctionsFormatting.FormataNumeroSQL(trecho.Comprimento.ToString()) + " ";
                ComprimentoAjustado = trecho.Comprimento;
            }
            // Console.WriteLine("ajuste comprimento: " + string_ajuste_comprimento);


            // ##########################
            // Select the feasible conductors for reconductoring
            // ##########################
            string query = "        SELECT      CondutoresDestino.ID, CondutoresDestino.descricao, CondutoresDestino.capacidade, CondutoresDestino.CodigoOpenDSS " +
"                       FROM        Recondutoramento, Condutores AS CondutoresOrigem, Condutores AS CondutoresDestino " +
"                       WHERE       Recondutoramento.ID_Condutor_Origem = CondutoresOrigem.ID " +
"                       AND         Recondutoramento.ID_Condutor_Destino = CondutoresDestino.ID " +
"                       AND         CondutoresOrigem.CodigoOpenDSS = " + trecho.LineCode + " " +
"                       AND         CondutoresDestino.capacidade >= " + FunctionsFormatting.FormataNumeroSQL(capacidade_condutor_atual.ToString()) + " " +
"                       " + string_restricao_condutores_Disponiveis + " " +
"                       ORDER BY    CondutoresDestino.capacidade ASC " +
"                       ";
            // Console.WriteLine(query);
            DataTable dados_condutores_Disponiveis = new DataTable();
            SqlCeDataAdapter adaptador_condutores = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
            adaptador_condutores.Fill(dados_condutores_Disponiveis);

            List<int> ID_CondutoresDisponiveis = new List<int>();
            List<double> Capacidade_CondutoresDisponiveis = new List<double>();

            string DetalhamentoRecondutoramento_Ano1;
            string DetalhamentoRecondutoramento_Ano2;
            string DetalhamentoRecondutoramento_Ano3;
            string DetalhamentoRecondutoramento_Ano4;
            string DetalhamentoRecondutoramento_Ano5;

            if (dados_condutores_Disponiveis.Rows.Count > 0)
            {
                foreach (DataRow linha in dados_condutores_Disponiveis.Rows)
                {
                    string string_linha = "";
                    foreach (var item in linha.ItemArray)
                    {
                        string_linha += item + " / ";
                    }
                    // Console.WriteLine(string_linha);

                    ID_CondutoresDisponiveis.Add(int.Parse(linha.ItemArray[0].ToString()));
                    Capacidade_CondutoresDisponiveis.Add(double.Parse(linha.ItemArray[2].ToString()));
                    //Console.WriteLine(int.Parse(linha.ItemArray[0].ToString()));
                    //Console.WriteLine(double.Parse(linha.ItemArray[2].ToString()));
                }


                // ##########################
                // Iterate over all possible conductor combinations for each year
                // ##########################
                for (int contador_ANO_1=0;contador_ANO_1< ID_CondutoresDisponiveis.Count;contador_ANO_1++)
                    for (int contador_ANO_2 = 0; contador_ANO_2 < ID_CondutoresDisponiveis.Count; contador_ANO_2++)
                        for (int contador_ANO_3 = 0; contador_ANO_3 < ID_CondutoresDisponiveis.Count; contador_ANO_3++)
                            for (int contador_ANO_4 = 0; contador_ANO_4 < ID_CondutoresDisponiveis.Count; contador_ANO_4++)
                                for (int contador_ANO_5 = 0; contador_ANO_5 < ID_CondutoresDisponiveis.Count; contador_ANO_5++)
                                {
                                    // Build the text for each ID combination
                                    string texto_combinacao_ID ="";
                                    texto_combinacao_ID += ID_CondutoresDisponiveis[contador_ANO_1] + " / ";
                                    texto_combinacao_ID += ID_CondutoresDisponiveis[contador_ANO_2] + " / ";
                                    texto_combinacao_ID += ID_CondutoresDisponiveis[contador_ANO_3] + " / ";
                                    texto_combinacao_ID += ID_CondutoresDisponiveis[contador_ANO_4] + " / ";
                                    texto_combinacao_ID += ID_CondutoresDisponiveis[contador_ANO_5] + " / ";

                                    // Build the text for each capacity combination
                                    string texto_combinacao_Capacidade = "";
                                    texto_combinacao_Capacidade += Capacidade_CondutoresDisponiveis[contador_ANO_1] + " / ";
                                    texto_combinacao_Capacidade += Capacidade_CondutoresDisponiveis[contador_ANO_2] + " / ";
                                    texto_combinacao_Capacidade += Capacidade_CondutoresDisponiveis[contador_ANO_3] + " / ";
                                    texto_combinacao_Capacidade += Capacidade_CondutoresDisponiveis[contador_ANO_4] + " / ";
                                    texto_combinacao_Capacidade += Capacidade_CondutoresDisponiveis[contador_ANO_5] + " / ";

                                    // Initialize the flag as true (valid solution)
                                    bool SolucaoValida =true;

                                    // Check whether the solution satisfies the non-decreasing capacity criterion
                                    if (Capacidade_CondutoresDisponiveis[contador_ANO_1] < capacidade_condutor_atual)
                                        SolucaoValida= false;
                                    else if (Capacidade_CondutoresDisponiveis[contador_ANO_2] < Capacidade_CondutoresDisponiveis[contador_ANO_1])
                                        SolucaoValida = false;
                                    else if (Capacidade_CondutoresDisponiveis[contador_ANO_3] < Capacidade_CondutoresDisponiveis[contador_ANO_2])
                                        SolucaoValida = false;
                                    else if (Capacidade_CondutoresDisponiveis[contador_ANO_4] < Capacidade_CondutoresDisponiveis[contador_ANO_3])
                                        SolucaoValida = false;
                                    else if (Capacidade_CondutoresDisponiveis[contador_ANO_5] < Capacidade_CondutoresDisponiveis[contador_ANO_4])
                                        SolucaoValida = false;

                                    // Check whether the solution satisfies the loading percentage criterion
                                    if ((trecho.Carregamento_EmAmperes_Ano1 / Capacidade_CondutoresDisponiveis[contador_ANO_1]) > (ParametroCarregamentoLimite / 100))
                                        SolucaoValida = false;
                                    else if ((trecho.Carregamento_EmAmperes_Ano2 / Capacidade_CondutoresDisponiveis[contador_ANO_2]) > (ParametroCarregamentoLimite / 100))
                                        SolucaoValida = false;
                                    else if ((trecho.Carregamento_EmAmperes_Ano3 / Capacidade_CondutoresDisponiveis[contador_ANO_3]) > (ParametroCarregamentoLimite / 100))
                                        SolucaoValida = false;
                                    else if ((trecho.Carregamento_EmAmperes_Ano4 / Capacidade_CondutoresDisponiveis[contador_ANO_4]) > (ParametroCarregamentoLimite / 100))
                                        SolucaoValida = false;
                                    else if ((trecho.Carregamento_EmAmperes_Ano5 / Capacidade_CondutoresDisponiveis[contador_ANO_5]) > (ParametroCarregamentoLimite / 100))
                                        SolucaoValida = false;

                                    if (SolucaoValida)
                                    {
                                        //Console.WriteLine(texto_combinacao_Capacidade);
                                        //Console.WriteLine(texto_combinacao_CorrenteAtual);

                                        // Compute the reconductoring cost for Year 1
                                        string query_Valor_Recondutoramento_ANO_1 = "      SELECT      (Recondutoramento.custo_recondutoramento " + string_ajuste_comprimento + ") AS CustoTotalRecondutoramento " +
                                            "                       FROM        Recondutoramento, Condutores AS CondutoresOrigem, Condutores AS CondutoresDestino " +
                                            "                       WHERE       Recondutoramento.ID_Condutor_Origem = CondutoresOrigem.ID " +
                                            "                       AND         Recondutoramento.ID_Condutor_Destino = CondutoresDestino.ID " +
                                            "                       AND         CondutoresOrigem.ID = " + ID_condutor_atual + " " +
                                            "                       AND         CondutoresDestino.ID = " + ID_CondutoresDisponiveis[contador_ANO_1] + " " +
                                            "                       ";
                                        // Console.WriteLine(query_Valor_Recondutoramento_ANO_1);
                                        //FuncoesArquivosTXT.GravaDadosArquivoTXT("Log5Anos.txt", query_Valor_Recondutoramento_ANO_1, true);
                                        DataTable dados_Valor_Recondutoramento_ANO_1 = new DataTable();
                                        SqlCeDataAdapter adaptador_Valor_Recondutoramento_ANO_1 = new SqlCeDataAdapter(query_Valor_Recondutoramento_ANO_1, ProjectConstants.CONSTANTE_strConection);
                                        adaptador_Valor_Recondutoramento_ANO_1.Fill(dados_Valor_Recondutoramento_ANO_1);
                                        double Valor_Recondutoramento_ANO_1 = double.Parse(dados_Valor_Recondutoramento_ANO_1.Rows[0].ItemArray[0].ToString());
                                        // Console.WriteLine("Valor recondutoramento ANO #1: " + Valor_Recondutoramento_ANO_1);
                                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Annual Reconductoring YEAR #1: " + Valor_Recondutoramento_ANO_1, true);
                                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Proposed Conductor Code YEAR #1: " + ID_CondutoresDisponiveis[contador_ANO_1], true);

                                        DetalhamentoRecondutoramento_Ano1 = "";
                                        if (Valor_Recondutoramento_ANO_1 > 0)
                                        {
                                            DetalhamentoRecondutoramento_Ano1 = @"Year #1: \n";
                                            DetalhamentoRecondutoramento_Ano1 += @"Line: " + trecho.LineName + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano1 += @"Existing Conductor: " + ID_condutor_atual + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano1 += @"Proposed Conductor: " + ID_CondutoresDisponiveis[contador_ANO_1] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano1 += @"Segment Length: " + FunctionsFormatting.FormataMoedaSQL(ComprimentoAjustado.ToString()) + @" [km] \n";
                                            DetalhamentoRecondutoramento_Ano1 += @"Reconductoring Cost: " + FunctionsFormatting.FormataMoedaSQL(Valor_Recondutoramento_ANO_1.ToString()) + @" [R$] \n\n";
                                        }

                                        // Compute the reconductoring cost for Year 2
                                        string query_Valor_Recondutoramento_ANO_2 = "      SELECT      (Recondutoramento.custo_recondutoramento " + string_ajuste_comprimento + ") AS CustoTotalRecondutoramento  " +
                                            "                       FROM        Recondutoramento, Condutores AS CondutoresOrigem, Condutores AS CondutoresDestino " +
                                            "                       WHERE       Recondutoramento.ID_Condutor_Origem = CondutoresOrigem.ID " +
                                            "                       AND         Recondutoramento.ID_Condutor_Destino = CondutoresDestino.ID " +
                                            "                       AND         CondutoresOrigem.ID = " + ID_CondutoresDisponiveis[contador_ANO_1] + " " +
                                            "                       AND         CondutoresDestino.ID = " + ID_CondutoresDisponiveis[contador_ANO_2] + " " +
                                            "                       ";
                                        DataTable dados_Valor_Recondutoramento_ANO_2 = new DataTable();
                                        SqlCeDataAdapter adaptador_Valor_Recondutoramento_ANO_2 = new SqlCeDataAdapter(query_Valor_Recondutoramento_ANO_2, ProjectConstants.CONSTANTE_strConection);
                                        adaptador_Valor_Recondutoramento_ANO_2.Fill(dados_Valor_Recondutoramento_ANO_2);
                                        double Valor_Recondutoramento_ANO_2 = double.Parse(dados_Valor_Recondutoramento_ANO_2.Rows[0].ItemArray[0].ToString());
                                        // Console.WriteLine("Valor recondutoramento ANO #2: " + Valor_Recondutoramento_ANO_2);
                                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Annual Reconductoring YEAR #2: " + Valor_Recondutoramento_ANO_2, true);

                                        DetalhamentoRecondutoramento_Ano2 = "";
                                        if (Valor_Recondutoramento_ANO_2 > 0)
                                        {
                                            DetalhamentoRecondutoramento_Ano2 = @"Year #2: \n";
                                            DetalhamentoRecondutoramento_Ano2 += @"Line: " + trecho.LineName + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano2 += @"Existing Conductor: " + ID_CondutoresDisponiveis[contador_ANO_1] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano2 += @"Proposed Conductor: " + ID_CondutoresDisponiveis[contador_ANO_2] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano2 += @"Segment Length: " + FunctionsFormatting.FormataMoedaSQL(ComprimentoAjustado.ToString()) + @" [km] \n";
                                            DetalhamentoRecondutoramento_Ano2 += @"Reconductoring Cost: " + FunctionsFormatting.FormataMoedaSQL(Valor_Recondutoramento_ANO_2.ToString()) + @" [R$] \n\n";
                                        }


                                        // Compute the reconductoring cost for Year 3
                                        string query_Valor_Recondutoramento_ANO_3 = "      SELECT      (Recondutoramento.custo_recondutoramento " + string_ajuste_comprimento + ") AS CustoTotalRecondutoramento  " +
                                            "                       FROM        Recondutoramento, Condutores AS CondutoresOrigem, Condutores AS CondutoresDestino " +
                                            "                       WHERE       Recondutoramento.ID_Condutor_Origem = CondutoresOrigem.ID " +
                                            "                       AND         Recondutoramento.ID_Condutor_Destino = CondutoresDestino.ID " +
                                            "                       AND         CondutoresOrigem.ID = " + ID_CondutoresDisponiveis[contador_ANO_2] + " " +
                                            "                       AND         CondutoresDestino.ID = " + ID_CondutoresDisponiveis[contador_ANO_3] + " " +
                                            "                       ";
                                        DataTable dados_Valor_Recondutoramento_ANO_3 = new DataTable();
                                        SqlCeDataAdapter adaptador_Valor_Recondutoramento_ANO_3 = new SqlCeDataAdapter(query_Valor_Recondutoramento_ANO_3, ProjectConstants.CONSTANTE_strConection);
                                        adaptador_Valor_Recondutoramento_ANO_3.Fill(dados_Valor_Recondutoramento_ANO_3);
                                        double Valor_Recondutoramento_ANO_3 = double.Parse(dados_Valor_Recondutoramento_ANO_3.Rows[0].ItemArray[0].ToString());
                                        // Console.WriteLine("Valor recondutoramento ANO #3: " + Valor_Recondutoramento_ANO_3);
                                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Annual Reconductoring YEAR #3: " + Valor_Recondutoramento_ANO_3, true);

                                        DetalhamentoRecondutoramento_Ano3 = "";
                                        if (Valor_Recondutoramento_ANO_3 > 0)
                                        {
                                            DetalhamentoRecondutoramento_Ano3 = @"Year #3: \n";
                                            DetalhamentoRecondutoramento_Ano3 += @"Line: " + trecho.LineName + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano3 += @"Existing Conductor: " + ID_CondutoresDisponiveis[contador_ANO_2] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano3 += @"Proposed Conductor: " + ID_CondutoresDisponiveis[contador_ANO_3] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano3 += @"Segment Length: " + FunctionsFormatting.FormataMoedaSQL(ComprimentoAjustado.ToString()) + @" [km] \n";
                                            DetalhamentoRecondutoramento_Ano3 += @"Reconductoring Cost: " + FunctionsFormatting.FormataMoedaSQL(Valor_Recondutoramento_ANO_3.ToString()) + @" [R$] \n\n";
                                        }


                                        // Compute the reconductoring cost for Year 4
                                        string query_Valor_Recondutoramento_ANO_4 = "      SELECT      (Recondutoramento.custo_recondutoramento " + string_ajuste_comprimento + ") AS CustoTotalRecondutoramento  " +
                                            "                       FROM        Recondutoramento, Condutores AS CondutoresOrigem, Condutores AS CondutoresDestino " +
                                            "                       WHERE       Recondutoramento.ID_Condutor_Origem = CondutoresOrigem.ID " +
                                            "                       AND         Recondutoramento.ID_Condutor_Destino = CondutoresDestino.ID " +
                                            "                       AND         CondutoresOrigem.ID = " + ID_CondutoresDisponiveis[contador_ANO_3] + " " +
                                            "                       AND         CondutoresDestino.ID = " + ID_CondutoresDisponiveis[contador_ANO_4] + " " +
                                            "                       ";
                                        DataTable dados_Valor_Recondutoramento_ANO_4 = new DataTable();
                                        SqlCeDataAdapter adaptador_Valor_Recondutoramento_ANO_4 = new SqlCeDataAdapter(query_Valor_Recondutoramento_ANO_4, ProjectConstants.CONSTANTE_strConection);
                                        adaptador_Valor_Recondutoramento_ANO_4.Fill(dados_Valor_Recondutoramento_ANO_4);
                                        double Valor_Recondutoramento_ANO_4 = double.Parse(dados_Valor_Recondutoramento_ANO_4.Rows[0].ItemArray[0].ToString());
                                        // Console.WriteLine("Valor recondutoramento ANO #4: " + Valor_Recondutoramento_ANO_4);
                                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Annual Reconductoring YEAR #4: " + Valor_Recondutoramento_ANO_4, true);

                                        DetalhamentoRecondutoramento_Ano4 = "";
                                        if (Valor_Recondutoramento_ANO_4 > 0)
                                        {
                                            DetalhamentoRecondutoramento_Ano4 = @"Year #4: \n";
                                            DetalhamentoRecondutoramento_Ano4 += @"Line: " + trecho.LineName + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano4 += @"Existing Conductor: " + ID_CondutoresDisponiveis[contador_ANO_3] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano4 += @"Proposed Conductor: " + ID_CondutoresDisponiveis[contador_ANO_4] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano4 += @"Segment Length: " + FunctionsFormatting.FormataMoedaSQL(ComprimentoAjustado.ToString())  + @" [km] \n";
                                            DetalhamentoRecondutoramento_Ano4 += @"Reconductoring Cost: " + FunctionsFormatting.FormataMoedaSQL(Valor_Recondutoramento_ANO_4.ToString()) + @" [R$] \n\n";
                                        }


                                        // Compute the reconductoring cost for Year 5
                                        string query_Valor_Recondutoramento_ANO_5 = "      SELECT      (Recondutoramento.custo_recondutoramento " + string_ajuste_comprimento + ") AS CustoTotalRecondutoramento  " +
                                            "                       FROM        Recondutoramento, Condutores AS CondutoresOrigem, Condutores AS CondutoresDestino " +
                                            "                       WHERE       Recondutoramento.ID_Condutor_Origem = CondutoresOrigem.ID " +
                                            "                       AND         Recondutoramento.ID_Condutor_Destino = CondutoresDestino.ID " +
                                            "                       AND         CondutoresOrigem.ID = " + ID_CondutoresDisponiveis[contador_ANO_4] + " " +
                                            "                       AND         CondutoresDestino.ID = " + ID_CondutoresDisponiveis[contador_ANO_5] + " " +
                                            "                       ";
                                        DataTable dados_Valor_Recondutoramento_ANO_5 = new DataTable();
                                        SqlCeDataAdapter adaptador_Valor_Recondutoramento_ANO_5 = new SqlCeDataAdapter(query_Valor_Recondutoramento_ANO_5, ProjectConstants.CONSTANTE_strConection);
                                        adaptador_Valor_Recondutoramento_ANO_5.Fill(dados_Valor_Recondutoramento_ANO_5);
                                        double Valor_Recondutoramento_ANO_5 = double.Parse(dados_Valor_Recondutoramento_ANO_5.Rows[0].ItemArray[0].ToString());
                                        // Console.WriteLine("Valor recondutoramento ANO #5: " + Valor_Recondutoramento_ANO_5);
                                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Annual Reconductoring YEAR #5: " + Valor_Recondutoramento_ANO_5, true);

                                        DetalhamentoRecondutoramento_Ano5 = "";
                                        if (Valor_Recondutoramento_ANO_5 > 0)
                                        {
                                            DetalhamentoRecondutoramento_Ano5 = @"Year #5: \n";
                                            DetalhamentoRecondutoramento_Ano5 += @"Line: " + trecho.LineName + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano5 += @"Existing Conductor: " + ID_CondutoresDisponiveis[contador_ANO_4] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano5 += @"Proposed Conductor: " + ID_CondutoresDisponiveis[contador_ANO_5] + @" [-] \n";
                                            DetalhamentoRecondutoramento_Ano5 += @"Segment Length: " + FunctionsFormatting.FormataMoedaSQL(ComprimentoAjustado.ToString()) + @" [km] \n";
                                            DetalhamentoRecondutoramento_Ano5 += @"Reconductoring Cost: " + FunctionsFormatting.FormataMoedaSQL(Valor_Recondutoramento_ANO_5.ToString()) + @" [R$] \n\n";
                                        }

                                        // Compute the total combination value and store it in the corresponding list
                                        double ValorTotalDestaCombinacao = Valor_Recondutoramento_ANO_1 + Valor_Recondutoramento_ANO_2 + Valor_Recondutoramento_ANO_3 + Valor_Recondutoramento_ANO_4 + Valor_Recondutoramento_ANO_5;
                                        Vetor_ValoresTotaisCombinacoes.Add(ValorTotalDestaCombinacao);
                                        // Console.WriteLine("Valor total da combinação: " + ValorTotalDestaCombinacao);
                                        FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Total Combination Value: " + ValorTotalDestaCombinacao, true);

                                        // Save the results to the database
                                        SqlCeCommand comando = new SqlCeCommand();
                                        comando.Connection = conexao;

                                        comando.CommandText = "INSERT INTO ResultadosOtimizacao (    CombinacaoCargas, " +
                                                                                                    "LineName, " +
                                                                                                    "ID_Condutor_Ano1, " +
                                                                                                    "ID_Condutor_Ano2, " +
                                                                                                    "ID_Condutor_Ano3, " +
                                                                                                    "ID_Condutor_Ano4, " +
                                                                                                    "ID_Condutor_Ano5, " +
                                                                                                    "custo_combinacao_condutores_para_o_trecho, " +
                                                                                                    "ID_Condutor_Atual, " +
                                                                                                    "DetalhamentoRecondutoramento_Ano1, " +
                                                                                                    "DetalhamentoRecondutoramento_Ano2, " +
                                                                                                    "DetalhamentoRecondutoramento_Ano3, " +
                                                                                                    "DetalhamentoRecondutoramento_Ano4, " +
                                                                                                    "DetalhamentoRecondutoramento_Ano5) " +
                                                                                                    "VALUES (" +
                                                                                                    "" + ContadorCombinacaoCargas + ", " +
                                                                                                    "'" + trecho.LineName + "', " +
                                                                                                    "" + ID_CondutoresDisponiveis[contador_ANO_1] + ", " +
                                                                                                    "" + ID_CondutoresDisponiveis[contador_ANO_2] + ", " +
                                                                                                    "" + ID_CondutoresDisponiveis[contador_ANO_3] + ", " +
                                                                                                    "" + ID_CondutoresDisponiveis[contador_ANO_4] + ", " +
                                                                                                    "" + ID_CondutoresDisponiveis[contador_ANO_5] + ", " +
                                                                                                    "" + FunctionsFormatting.FormataMoedaSQL(ValorTotalDestaCombinacao.ToString()) + ", " +
                                                                                                    "" + ID_condutor_atual + ", " +
                                                                                                    "'" + DetalhamentoRecondutoramento_Ano1 + "', " +
                                                                                                    "'" + DetalhamentoRecondutoramento_Ano2 + "', " +
                                                                                                    "'" + DetalhamentoRecondutoramento_Ano3 + "', " +
                                                                                                    "'" + DetalhamentoRecondutoramento_Ano4 + "', " +
                                                                                                    "'" + DetalhamentoRecondutoramento_Ano5 + "') ";
                                        Console.WriteLine(comando.CommandText);                                       
                                        comando.ExecuteNonQuery();
                                    }
                                    else
                                    {


                                    }
                                }

                //Console.WriteLine("Total de combinações válidas: " + Vetor_ValoresTotaisCombinacoes.Count);
                //Console.WriteLine("Valor mínimo: " + Vetor_ValoresTotaisCombinacoes.Min());

                FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Total Valid Combinations: " + Vetor_ValoresTotaisCombinacoes.Count, true);
                FunctionsTXTFile.GravaDadosArquivoTXT("Log5Years.txt", "Minimum Value: " + Vetor_ValoresTotaisCombinacoes.Min(), true);
            }
            else
            {
                MessageBox.Show("No reconductoring options available for the line: '" + trecho.LineName + "'. The values related to this reconductoring were not considered. ");
            }


            conexao.Close();

            return (Vetor_ValoresTotaisCombinacoes.Min());

        }



        static public bool SolucaoValida_GA_INCOMPLETO(List<int> Solucao)
        {

            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);
            conexao.Open();

            for (int contador_itens = 1; contador_itens <= Solucao.Count/5; contador_itens++)
            {

                string query_ano_1 = "  SELECT      Condutores.capacidade " +
                "                       FROM        Condutores " +
                "                       WHERE       Condutores.CodigoOpenDSS = " + Solucao[contador_itens-1] + "; ";
                DataTable dados_capacidade_ano1 = new DataTable();
                SqlCeDataAdapter adaptador_capacidade_ano_1 = new SqlCeDataAdapter(query_ano_1, ProjectConstants.CONSTANTE_strConection);
                adaptador_capacidade_ano_1.Fill(dados_capacidade_ano1);
                double capacidade_ano_1 = double.Parse(dados_capacidade_ano1.Rows[0].ItemArray[0].ToString());

                string query_ano_2 = "  SELECT      Condutores.capacidade " +
                "                       FROM        Condutores " +
                "                       WHERE       Condutores.CodigoOpenDSS = " + Solucao[(Solucao.Count / 5) + contador_itens - 1] + "; ";
                DataTable dados_capacidade_ano2 = new DataTable();
                SqlCeDataAdapter adaptador_capacidade_ano_2 = new SqlCeDataAdapter(query_ano_2, ProjectConstants.CONSTANTE_strConection);
                adaptador_capacidade_ano_2.Fill(dados_capacidade_ano2);
                double capacidade_ano_2 = double.Parse(dados_capacidade_ano2.Rows[0].ItemArray[0].ToString());

                string query_ano_3 = "  SELECT      Condutores.capacidade " +
                "                       FROM        Condutores " +
                "                       WHERE       Condutores.CodigoOpenDSS = " + Solucao[(Solucao.Count / 5)*2 + contador_itens - 1] + "; ";
                DataTable dados_capacidade_ano3 = new DataTable();
                SqlCeDataAdapter adaptador_capacidade_ano_3 = new SqlCeDataAdapter(query_ano_3, ProjectConstants.CONSTANTE_strConection);
                adaptador_capacidade_ano_3.Fill(dados_capacidade_ano3);
                double capacidade_ano_3 = double.Parse(dados_capacidade_ano3.Rows[0].ItemArray[0].ToString());

                string query_ano_4 = "  SELECT      Condutores.capacidade " +
                "                       FROM        Condutores " +
                "                       WHERE       Condutores.CodigoOpenDSS = " + Solucao[(Solucao.Count / 5) * 3 + contador_itens - 1] + "; ";
                DataTable dados_capacidade_ano4 = new DataTable();
                SqlCeDataAdapter adaptador_capacidade_ano_4 = new SqlCeDataAdapter(query_ano_4, ProjectConstants.CONSTANTE_strConection);
                adaptador_capacidade_ano_4.Fill(dados_capacidade_ano4);
                double capacidade_ano_4 = double.Parse(dados_capacidade_ano4.Rows[0].ItemArray[0].ToString());

                string query_ano_5 = "  SELECT      Condutores.capacidade " +
                "                       FROM        Condutores " +
                "                       WHERE       Condutores.CodigoOpenDSS = " + Solucao[(Solucao.Count / 5) * 4 + contador_itens - 1] + "; ";
                DataTable dados_capacidade_ano5 = new DataTable();
                SqlCeDataAdapter adaptador_capacidade_ano_5 = new SqlCeDataAdapter(query_ano_5, ProjectConstants.CONSTANTE_strConection);
                adaptador_capacidade_ano_5.Fill(dados_capacidade_ano5);
                double capacidade_ano_5 = double.Parse(dados_capacidade_ano5.Rows[0].ItemArray[0].ToString());

            }

            conexao.Close();

            return (true);
        }

        static public double FitnessSolucao_GA_INCOMPLETO(List<int> Solucao)
        {



            return (0);
        }


        static public List<int> GeraSolucaoInicialCondutores_GA_INCOMPLETO(int TamanhoSolucao, int ValorMinimo, int ValorMaximo)
            {
            List<int> RetornoFuncao = new List<int>();
            Random randNum = new Random();
            for (int contador_itens=1; contador_itens<= TamanhoSolucao; contador_itens++)
            {
                int NumeroSorteado = randNum.Next(ValorMinimo, ValorMaximo);
                RetornoFuncao.Add(NumeroSorteado);
            }

            return (RetornoFuncao);
        }


        static public int CodigoCondutor_Limite(string Tipo)
        {
            int CodigoCondutorLimite=0;

            string query = "        SELECT      TOP 1 Condutores.CodigoOpenDSS " +
            "                       FROM        Condutores ";
            if(Tipo=="MENOR")
            {
                query += "                       ORDER BY    Condutores.CodigoOpenDSS ASC; ";
            }
            else if(Tipo == "MAIOR")
            {
                query += "                       ORDER BY    Condutores.CodigoOpenDSS DESC; ";
            }
            //Console.WriteLine(query);

            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);
            DataTable dados_condutor_limite = new DataTable();
            SqlCeDataAdapter adaptador_condutor_limite = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
            conexao.Open();
            adaptador_condutor_limite.Fill(dados_condutor_limite);

            if (dados_condutor_limite.Rows.Count > 0)
            {
                foreach (DataRow linha in dados_condutor_limite.Rows)
                {
                    CodigoCondutorLimite = int.Parse(linha.ItemArray[0].ToString());
                }
            }
            //            // Console.WriteLine(string_linha);

            return (CodigoCondutorLimite);

        }
    }
}

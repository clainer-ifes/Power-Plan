using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace PowerPlan
{
    static class FunctionsDatabase
    {
        static public void InicializaBancoDados()
        {
            #region Inicializa Banco SQL Server CE
            SqlCeEngine db = new SqlCeEngine(ProjectConstants.CONSTANTE_strConection);

            if (!File.Exists(ProjectConstants.CONSTANTE_baseDados))
            {
                db.CreateDatabase();
            }
            db.Dispose();

            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);
            #endregion

            #region Cria Tabelas SQLServerCE
            try
            {
                conexao.Open();

                SqlCeCommand comando = new SqlCeCommand();
                comando.Connection = conexao;

                comando.CommandText = "CREATE TABLE Condutores (ID INT IDENTITY PRIMARY KEY NOT NULL, descricao NVARCHAR(255), custo MONEY, capacidade REAL, CodigoOpenDSS INT)";
                comando.ExecuteNonQuery();

                int MaximoCabos = 12;

                for(int contador_cabos=1; contador_cabos<=MaximoCabos; contador_cabos++)
                {
                    comando.CommandText = "INSERT INTO Condutores (descricao, custo, capacidade, CodigoOpenDSS) VALUES ('CA" + contador_cabos.ToString("D2") + "', " + Math.Round((52.518 * (Math.Round(130.58 * Math.Exp(0.1961 * contador_cabos))) - 7655.1)*1.2*6) + ", " + Math.Round(130.58 * Math.Exp(0.1961 * contador_cabos)) + ", " + contador_cabos + ")";
                    //MessageBox.Show(comando.CommandText);

                    comando.ExecuteNonQuery();

                }

                comando.CommandText = "     CREATE TABLE Recondutoramento " +
                    "                       (ID INT IDENTITY PRIMARY KEY NOT NULL, " +
                    "                       ID_Condutor_Origem INT NOT NULL, " +
                    "                       ID_Condutor_Destino INT NOT NULL, " +
                    "                       custo_recondutoramento MONEY" +
                    "                       )";
                comando.ExecuteNonQuery();

                for (int contador_cabos_origem = 1; contador_cabos_origem <= MaximoCabos; contador_cabos_origem++)
                {
                    for (int contador_cabos_destino = 1; contador_cabos_destino <= MaximoCabos; contador_cabos_destino++)
                    {
                        if(contador_cabos_destino > contador_cabos_origem)
                        {
                            comando.CommandText = "INSERT INTO Recondutoramento (ID_Condutor_Origem, ID_Condutor_Destino, custo_recondutoramento) VALUES (" + contador_cabos_origem + ", " + contador_cabos_destino + ", " + Math.Round((52.518 * (Math.Round(130.58 * Math.Exp(0.1961 * contador_cabos_destino))) - 7655.1) * 1.2 * 6) + ")";
                            //Console.WriteLine(comando.CommandText);
                            comando.ExecuteNonQuery();
                        }
                        else if(contador_cabos_destino == contador_cabos_origem)
                        {
                            comando.CommandText = "INSERT INTO Recondutoramento (ID_Condutor_Origem, ID_Condutor_Destino, custo_recondutoramento) VALUES (" + contador_cabos_origem + ", " + contador_cabos_destino + ", 0)";
                            //Console.WriteLine(comando.CommandText);
                            comando.ExecuteNonQuery();
                        }
                    }

                }


                //comando.CommandText = "ALTER TABLE Recondutoramento ADD CONSTRAINT RestricaoCondutor FOREIGN KEY(ID_Condutor_Origem, ID_Condutor_Destino) REFERENCES Condutores(ID), Condutores(ID) ON DELETE CASCADE ON UPDATE CASCADE";
                //comando.ExecuteNonQuery();

                //comando.CommandText = "ALTER TABLE Recondutoramento ADD CONSTRAINT RestricaoCondutorDestino FOREIGN KEY(ID_Condutor_Destino) REFERENCES Condutores(ID) ON DELETE CASCADE ON UPDATE CASCADE";
                //comando.ExecuteNonQuery();

                comando.CommandText = "CREATE TABLE PDFs (ID INT IDENTITY PRIMARY KEY NOT NULL, descricao NVARCHAR(255))";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO PDFs (descricao) VALUES ('Lognormal')";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO PDFs (descricao) VALUES ('Gamma')";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO PDFs (descricao) VALUES ('Weibull')";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO PDFs (descricao) VALUES ('Normal')";
                comando.ExecuteNonQuery();

                comando.CommandText = "CREATE TABLE Algoritmos ( ID INT IDENTITY PRIMARY KEY NOT NULL, descricao NVARCHAR(255))";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO Algoritmos (descricao) VALUES ('Exhaustive Search')";
                comando.ExecuteNonQuery();

                comando.CommandText = "CREATE TABLE ResultadosOtimizacao " +
                                                    "(CombinacaoCargas INT NOT NULL, " +
                                                    "LineName NVARCHAR(255) NOT NULL, " +
                                                    "ID_Condutor_Ano1 INT NOT NULL, " +
                                                    "ID_Condutor_Ano2 INT NOT NULL, " +
                                                    "ID_Condutor_Ano3 INT NOT NULL, " +
                                                    "ID_Condutor_Ano4 INT NOT NULL, " +
                                                    "ID_Condutor_Ano5 INT NOT NULL, " +
                                                    "custo_combinacao_condutores_para_o_trecho MONEY NOT NULL, " +
                                                    "ID_Condutor_Atual INT NOT NULL, " +
                                                    "DetalhamentoRecondutoramento_Ano1 NVARCHAR(4000) NOT NULL, " +
                                                    "DetalhamentoRecondutoramento_Ano2 NVARCHAR(4000) NOT NULL, " +
                                                    "DetalhamentoRecondutoramento_Ano3 NVARCHAR(4000) NOT NULL, " +
                                                    "DetalhamentoRecondutoramento_Ano4 NVARCHAR(4000) NOT NULL, " +
                                                    "DetalhamentoRecondutoramento_Ano5 NVARCHAR(4000) NOT NULL) ";
                comando.ExecuteNonQuery();

                comando.CommandText = "CREATE TABLE CoresCondutores (ID INT IDENTITY PRIMARY KEY NOT NULL, descricao NVARCHAR(255), CorR INT NOT NULL, CorG INT NOT NULL, CorB INT NOT NULL)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Azul', 0, 0, 255)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Verde', 0, 128, 0)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Vermelho', 255, 0, 0)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Amarelo', 255, 255, 0)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Laranja', 255, 165, 0)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Roxo', 128, 0, 128)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Ciano', 0, 255, 255)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Magenta', 255, 0, 255)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Marrom', 139, 69, 19)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Cinza', 128, 128, 128)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Rosa', 255, 192, 203)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Azul-marinho', 0, 0, 128)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Verde-limão', 50, 205, 50)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Dourado', 255, 215, 0)";
                comando.ExecuteNonQuery();

                comando.CommandText = "INSERT INTO CoresCondutores (descricao, CorR, CorG, CorB) VALUES ('Turquesa', 64, 224, 208)";
                comando.ExecuteNonQuery();

                comando.Dispose();
            }
            catch (Exception ex)
            {
                 //MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            #endregion

        }


    }
}

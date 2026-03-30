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
    public partial class Reconductoring : Form
    {
        public Reconductoring()
        {
            InitializeComponent();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtCusto.Text = "";

            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {

                string query = "SELECT ID, Descricao + '(Capacity [A]: ' + CAST(Capacidade AS NVARCHAR(255)) + ')' AS Descricao FROM Condutores ORDER BY ID";
                DataTable dados_origem = new DataTable();
                DataTable dados_destino = new DataTable();

                SqlCeDataAdapter adaptador_origem = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);
                SqlCeDataAdapter adaptador_destino = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                conexao.Open();

                adaptador_origem.Fill(dados_origem);
                adaptador_destino.Fill(dados_destino);

                comboCondutorOrigem.DataSource = dados_origem;
                comboCondutorOrigem.ValueMember = "ID";
                comboCondutorOrigem.DisplayMember = "Descricao";

                comboCondutorDestino.DataSource = dados_destino;
                comboCondutorDestino.ValueMember = "ID";
                comboCondutorDestino.DisplayMember = "Descricao";

                query = "   SELECT      Recondutoramento.ID, " +
                    "                   CAST(C1.ID AS NVARCHAR(255)) + ' - ' + C1.Descricao, " +
                    "                   CAST(C2.ID AS NVARCHAR(255)) + ' - ' + C2.Descricao, " +
                    "                   custo_recondutoramento " +
                    "       FROM        Recondutoramento " +
                    "       INNER JOIN  Condutores C1 " +
                    "       ON          Recondutoramento.ID_Condutor_Origem = C1.ID " +
                    "       INNER JOIN  Condutores C2 " +
                    "       ON          Recondutoramento.ID_Condutor_Destino = C2.ID " +
                    "       ORDER BY    Recondutoramento.ID";

//                SELECT
//    P.nome,
//    P.preco,
//    C.nome as Categoria,
//    COUNT(V.id_produto) TOTAL_VENDIDOS
//FROM
//    produto P
//INNER JOIN
//  categoria_produto C
//ON P.id_categoria = C.id
//INNER JOIN
//  venda_produto V
//ON V.id_produto = P.id

                //MessageBox.Show(query);
                DataTable dados_lista = new DataTable();

                SqlCeDataAdapter adaptador_lista = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                adaptador_lista.Fill(dados_lista);

                listaRecondutoramentos.Rows.Clear();
                listaRecondutoramentos.Columns.Clear();
                listaRecondutoramentos.Columns.Add("ID", "ID");
                listaRecondutoramentos.Columns.Add("ExistingConductor", "Existing Conductor");
                listaRecondutoramentos.Columns.Add("ProposedConductor", "Proposed Conductor");
                listaRecondutoramentos.Columns.Add("Cost", "Cost [$/km]");

                foreach (DataRow linha in dados_lista.Rows)
                {
                    listaRecondutoramentos.Rows.Add(linha.ItemArray);
                }

                listaRecondutoramentos.Columns["Cost"].DefaultCellStyle.Format = "f2";
            }
            catch (Exception ex)
            {
                listaRecondutoramentos.Rows.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            comboCondutorOrigem.Focus();
        }

        private void txtCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasMoeda((TextBox)sender, e);
        }

        private void txtCusto_Leave(object sender, EventArgs e)
        { 
            FunctionsFormatting.IncluiMascaraMoeda((TextBox)sender);
        }

        private void txtCusto_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraMoeda((TextBox)sender);
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {
                if (txtCusto.Text == "")
                {
                    MessageBox.Show("Reconductoring cost not provided.");
                    txtCusto.Focus();
                }
                else
                {
                    if(txtID.Text == "")
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        comando.CommandText = "INSERT INTO Recondutoramento (ID_Condutor_Origem, ID_Condutor_Destino, custo_recondutoramento) VALUES (" + comboCondutorOrigem.SelectedValue + ", " + comboCondutorDestino.SelectedValue + ", " + FunctionsFormatting.FormataMoedaSQL(txtCusto.Text) + ")";
                        //MessageBox.Show(comando.CommandText);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Reconductoring record added successfully!");
                        comando.Dispose();
                    }
                    else
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        string query = "UPDATE Recondutoramento SET custo_recondutoramento = " + FunctionsFormatting.FormataMoedaSQL(txtCusto.Text) + ", ID_Condutor_Origem = " + comboCondutorOrigem.SelectedValue + ", ID_Condutor_Destino = " + comboCondutorDestino.SelectedValue + "  WHERE ID LIKE " + txtID.Text;

                        comando.CommandText = query;

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Reconductoring record updated successfully!");
                        comando.Dispose();
                    }
                    Limpar_Click(null, null);

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

        private void txtCusto_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {
                if (listaRecondutoramentos.SelectedRows.Count != 0)
                {
                    if(MessageBox.Show("Are you sure you want to delete this record?", "Record Deletion", MessageBoxButtons.YesNo)== DialogResult.Yes)
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        //MessageBox.Show(listaCondutores.SelectedRows.Count.ToString());
                        int ID = (int)listaRecondutoramentos.SelectedRows[0].Cells[0].Value;

                        comando.CommandText = "DELETE FROM Recondutoramento WHERE ID = '" + ID + "'";

                        comando.ExecuteNonQuery();

                        comando.Dispose();

                        MessageBox.Show("Record deleted successfully!");
                        Limpar_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a reconductoring project to delete!");
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

        private void listaRecondutoramentos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("oi");

            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {

                if (listaRecondutoramentos.SelectedRows.Count != 0)
                {
                    int ID = (int)listaRecondutoramentos.SelectedRows[0].Cells[0].Value;

                    string query = "SELECT Recondutoramento.ID, ID_Condutor_Origem, ID_Condutor_Destino, custo_recondutoramento FROM Recondutoramento WHERE ID = " + ID;
                    DataTable dados = new DataTable();

                    SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                    conexao.Open();

                    adaptador.Fill(dados);

                    foreach (DataRow linha in dados.Rows)
                    {
                        txtID.Text = linha.ItemArray[0].ToString();
                        comboCondutorOrigem.SelectedValue = linha.ItemArray[1];
                        comboCondutorDestino.SelectedValue = linha.ItemArray[2];
                        txtCusto.Text = linha.ItemArray[3].ToString();
                    }
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

        private void Recondutoramento_Load(object sender, EventArgs e)
        {
            Limpar_Click(null, null);
        }

        private void comboCondutorOrigem_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        private void comboCondutorDestino_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoComboBox((ComboBox)sender, e);

        }

        static public void GeraArquivoCSVRecondutoramento(DataGridView ListaDeCondutores)
        {
            string LinhaCSV = "";
            FunctionsTXTFile.GravaDadosArquivoTXT("reconductoring_data.csv", LinhaCSV, false);

            string CondutorOrigemAtual = "";
            string LinhaImpressao = "";
            int nivel=1;
            foreach (DataGridViewRow row in ListaDeCondutores.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Index == 0)
                    {
                        CondutorOrigemAtual = row.Cells[1].Value.ToString();
                    }
                    //Console.WriteLine("CondutorOrigemAtual: " + CondutorOrigemAtual);

                    if(row.Cells[1].Value.ToString() == CondutorOrigemAtual)
                    {
                        LinhaImpressao += row.Cells[3].Value.ToString() + ", ";
                    }
                    else
                    {
                        string string_nivel = string.Concat(Enumerable.Repeat("-,", nivel-1));

                        FunctionsTXTFile.GravaDadosArquivoTXT("reconductoring_data.csv", string_nivel + LinhaImpressao, true);
                        LinhaImpressao = row.Cells[3].Value.ToString() + ", ";
                        nivel ++;
                    }

                    CondutorOrigemAtual = row.Cells[1].Value.ToString();
                }
            }
        }

        private void Exportar_Click(object sender, EventArgs e)
        {
            GeraArquivoCSVRecondutoramento(listaRecondutoramentos);

            MessageBox.Show("Export completed successfully! \n\nFile saved at " + Application.StartupPath);

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PowerPlan
{
    public partial class Conductors : Form
    {
        public Conductors()
        {
            InitializeComponent();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Condutores_Load(object sender, EventArgs e)
        {
            Limpar_Click(null, null);
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtDescricao.Text = "";
            txtCusto.Text = "";
            txtCapacidade.Text = "";
            txtCodigoOpenDSS.Text = "";
            listaCondutores.Rows.Clear();

            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {
                string query = "SELECT ID, Descricao, Custo, Capacidade, CodigoOpenDSS FROM Condutores ORDER BY ID";
                DataTable dados = new DataTable();

                SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                conexao.Open();

                adaptador.Fill(dados);

                listaCondutores.Columns.Clear();
                listaCondutores.Columns.Add("ID", "ID");
                listaCondutores.Columns.Add("Description", "Description");
                listaCondutores.Columns.Add("Cost", "Cost [$/km]");
                listaCondutores.Columns.Add("Capacity", "Capacity [A]");
                listaCondutores.Columns.Add("OpenDSSCode", "OpenDSS Code [-]");


                foreach (DataRow linha in dados.Rows)
                {
                    listaCondutores.Rows.Add(linha.ItemArray);
                }

                listaCondutores.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                listaCondutores.Columns["Cost"].DefaultCellStyle.Format = "f2";
                listaCondutores.Columns["Cost"].DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleLeft;

                listaCondutores.Columns["Capacity"].DefaultCellStyle.Format = "f2";
                listaCondutores.Columns["Capacity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                listaCondutores.Columns["OpenDSSCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                listaCondutores.Rows.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            txtDescricao.Focus();
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
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("Conductor description not provided.");
                    txtDescricao.Focus();
                }
                else if (txtCusto.Text == "")
                {
                    MessageBox.Show("Conductor cost not provided.");
                    txtCusto.Focus();
                }
                else if (txtCapacidade.Text == "")
                {
                    MessageBox.Show("Conductor capacity not provided.");
                    txtCapacidade.Focus();
                }
                else if (txtCodigoOpenDSS.Text == "")
                {
                    MessageBox.Show("Conductor OpenDSS code not provided.");
                    txtCodigoOpenDSS.Focus();
                }
                else
                {
                    if(txtID.Text == "")
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        comando.CommandText = "INSERT INTO Condutores(descricao, custo, capacidade, CodigoOpenDSS) VALUES ('" + txtDescricao.Text + "', " + FunctionsFormatting.FormataMoedaSQL(txtCusto.Text) + ", " + FunctionsFormatting.FormataMoedaSQL(txtCapacidade.Text) + ", " + FunctionsFormatting.FormataMoedaSQL(txtCodigoOpenDSS.Text) + ")";
                        //MessageBox.Show(comando.CommandText);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Conductor record added successfully!");
                        comando.Dispose();
                    }
                    else
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        string query = "UPDATE Condutores SET Descricao = '" + txtDescricao.Text + "', Custo = " + FunctionsFormatting.FormataMoedaSQL(txtCusto.Text) + ", Capacidade = " + FunctionsFormatting.FormataMoedaSQL(txtCapacidade.Text) + ", CodigoOpenDSS = " + FunctionsFormatting.FormataMoedaSQL(txtCodigoOpenDSS.Text) + " WHERE ID LIKE " + txtID.Text;

                        comando.CommandText = query;

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Conductor record updated successfully!");
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

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);
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
                if (listaCondutores.SelectedRows.Count != 0)
                {
                    if(MessageBox.Show("Are you sure you want to delete this record?", "Record Deletion", MessageBoxButtons.YesNo)== DialogResult.Yes)
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        //MessageBox.Show(listaCondutores.SelectedRows.Count.ToString());
                        int ID = (int)listaCondutores.SelectedRows[0].Cells[0].Value;

                        comando.CommandText = "DELETE FROM Condutores WHERE ID = '" + ID + "'";

                        comando.ExecuteNonQuery();

                        comando.Dispose();

                        MessageBox.Show("Record deleted successfully!");
                        Limpar_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a conductor to delete!");
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

        private void listaCondutores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {

                if (listaCondutores.SelectedRows.Count != 0)
                {
                    int ID = (int)listaCondutores.SelectedRows[0].Cells[0].Value;

                    string query = "SELECT ID, Descricao, Custo, Capacidade, CodigoOpenDSS FROM Condutores WHERE ID = " + ID;
                    DataTable dados = new DataTable();

                    SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                    conexao.Open();

                    adaptador.Fill(dados);

                    foreach (DataRow linha in dados.Rows)
                    {
                        txtID.Text = linha.ItemArray[0].ToString();
                        txtDescricao.Text = linha.ItemArray[1].ToString();
                        txtCusto.Text = linha.ItemArray[2].ToString();
                        txtCapacidade.Text = linha.ItemArray[3].ToString();
                        txtCodigoOpenDSS.Text = linha.ItemArray[4].ToString();
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

        private void txtCapacidade_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);
        }

        private void txtCapacidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasNumero((TextBox)sender, e);
        }

        private void txtCapacidade_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);
        }

        private void txtCapacidade_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);
        }

        private void txtCodigoOpenDSS_KeyDown(object sender, KeyEventArgs e)
        {
            FunctionsGeneral.PulaCampoTextBox((TextBox)sender, e);

        }

        private void txtCodigoOpenDSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            FunctionsFormatting.FiltraTeclasNumero((TextBox)sender, e);

        }

        private void txtCodigoOpenDSS_Leave(object sender, EventArgs e)
        {
            FunctionsFormatting.IncluiMascaraNumero((TextBox)sender);

        }

        private void txtCodigoOpenDSS_Enter(object sender, EventArgs e)
        {
            FunctionsFormatting.RetiraMascaraNumero((TextBox)sender);

        }


        static public void GeraArquivoCSVCondutores(DataGridView ListaDeCondutores)
        {
            string LinhaCSV = "ID, Description, Capacity [A]";
            FunctionsTXTFile.GravaDadosArquivoTXT("conductor_data.csv", LinhaCSV, false);

            foreach (DataGridViewRow row in ListaDeCondutores.Rows)
            {
                string LinhaImpressao;

                //object ValorID = row.Cells[0].Value;
                if (row.Cells[0].Value != null)
                {
                    LinhaImpressao = row.Cells[0].Value.ToString() + ", " + row.Cells[1].Value.ToString() + ", " + row.Cells[3].Value.ToString();
                    FunctionsTXTFile.GravaDadosArquivoTXT("conductor_data.csv", LinhaImpressao, true);
                }
            }
        }

        private void Exportar_Click(object sender, EventArgs e)
        {
            GeraArquivoCSVCondutores(listaCondutores);

            MessageBox.Show("Export completed successfully! \n\nView file at " + Application.StartupPath);
        }
    }
}

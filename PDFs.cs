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
    public partial class PDFs : Form
    {
        public PDFs()
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
            txtDescricao.Text = "";
            listaPDFs.Rows.Clear();

            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {
                string query = "SELECT ID, Descricao FROM PDFs ORDER BY ID";
                DataTable dados = new DataTable();

                SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                conexao.Open();

                adaptador.Fill(dados);

                listaPDFs.Columns.Clear();
                listaPDFs.Columns.Add("ID", "ID");
                listaPDFs.Columns.Add("Description", "Description");

                foreach (DataRow linha in dados.Rows)
                {
                    listaPDFs.Rows.Add(linha.ItemArray);
                }
            }
            catch (Exception ex)
            {
                listaPDFs.Rows.Clear();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            txtDescricao.Focus();
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {
                if (txtDescricao.Text == "")
                {
                    MessageBox.Show("PDF description not provided.");
                    txtDescricao.Focus();
                }
                else
                {
                    if(txtID.Text == "")
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        comando.CommandText = "INSERT INTO PDFs(descricao) VALUES ('" + txtDescricao.Text + "')";
                        //MessageBox.Show(comando.CommandText);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("PDF record added successfully!");
                        comando.Dispose();
                    }
                    else
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        string query = "UPDATE PDFs SET Descricao = '" + txtDescricao.Text + "' WHERE ID LIKE " + txtID.Text;

                        comando.CommandText = query;

                        comando.ExecuteNonQuery();

                        MessageBox.Show("PDF record updated successfully!");
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

        private void Excluir_Click(object sender, EventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {
                if (listaPDFs.SelectedRows.Count != 0)
                {
                    if(MessageBox.Show("Are you sure you want to delete this PDF?", "Record Deletion", MessageBoxButtons.YesNo)== DialogResult.Yes)
                    {
                        conexao.Open();

                        SqlCeCommand comando = new SqlCeCommand();
                        comando.Connection = conexao;

                        int ID = (int)listaPDFs.SelectedRows[0].Cells[0].Value;

                        comando.CommandText = "DELETE FROM PDFs WHERE ID = '" + ID + "'";

                        comando.ExecuteNonQuery();

                        comando.Dispose();

                        MessageBox.Show("Record deleted successfully!");
                        Limpar_Click(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a PDF to delete!");
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

        private void PDFs_Load(object sender, EventArgs e)
        {
            Limpar_Click(null, null);
        }

        private void listaPDFs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCeConnection conexao = new SqlCeConnection(ProjectConstants.CONSTANTE_strConection);

            try
            {

                if (listaPDFs.SelectedRows.Count != 0)
                {
                    int ID = (int)listaPDFs.SelectedRows[0].Cells[0].Value;

                    string query = "SELECT ID, Descricao FROM PDFs WHERE ID = " + ID;
                    DataTable dados = new DataTable();

                    SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, ProjectConstants.CONSTANTE_strConection);

                    conexao.Open();

                    adaptador.Fill(dados);

                    foreach (DataRow linha in dados.Rows)
                    {
                        txtID.Text = linha.ItemArray[0].ToString();
                        txtDescricao.Text = linha.ItemArray[1].ToString();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

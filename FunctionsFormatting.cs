using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlan
{
    static class FunctionsFormatting
    {
        static public string FormataMoedaSQL(string Valor)
        {
            string CustoAjustado = Valor.Replace("R$", "").Trim();
            CustoAjustado = CustoAjustado.Replace(".", "").Trim();
            CustoAjustado = CustoAjustado.Replace(",", ".").Trim();

            return CustoAjustado;
        }

        static public string FormataNumeroSQL(string Valor)
        {
            string CustoAjustado = Valor.Replace(".", "").Trim();
            CustoAjustado = CustoAjustado.Replace(",", ".").Trim();

            return CustoAjustado;
        }


        static public void RetiraMascaraMoeda(TextBox Campo)
        {
            Campo.Text = Campo.Text.Replace("R$", "").Trim();
        }

        static public void IncluiMascaraMoeda(TextBox Campo)
        {
            if (Campo.Text != "")
            {
                Campo.Text = double.Parse(Campo.Text).ToString("C2");
            }
        }

        static public void FiltraTeclasMoeda(TextBox Campo, KeyPressEventArgs Tecla)
        {
            if (!char.IsDigit(Tecla.KeyChar) && Tecla.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (Tecla.KeyChar == ',')
                {
                    Tecla.Handled = (Campo.Text.Contains(','));
                }
                else
                    Tecla.Handled = true;
            }
        }

        static public void RetiraMascaraNumero(TextBox Campo)
        {
            //Campo.Text = Campo.Text.Replace("R$", "").Trim();
        }

        static public void IncluiMascaraNumero(TextBox Campo)
        {
            if (Campo.Text != "")
            {
                //MessageBox.Show(Campo.Text);
                Campo.Text = double.Parse(Campo.Text).ToString("F2");
            }
        }

        static public void FiltraTeclasNumero(TextBox Campo, KeyPressEventArgs Tecla)
        {
            if (!char.IsDigit(Tecla.KeyChar) && Tecla.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (Tecla.KeyChar == ',')
                {
                    Tecla.Handled = (Campo.Text.Contains(','));
                }
                else
                    Tecla.Handled = true;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlan
{
    static class FunctionsGeneral
    {
        static public void PulaCampoTextBox(TextBox Campo, KeyEventArgs Tecla)
        {
            //MessageBox.Show(Tecla.KeyValue.ToString());
            if ((Tecla.KeyValue == ((int)Keys.Enter)) || (Tecla.KeyValue == ((int)Keys.Return)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        static public void PulaCampoComboBox(ComboBox Campo, KeyEventArgs Tecla)
        {
            //MessageBox.Show(Tecla.KeyValue.ToString());
            if ((Tecla.KeyValue == ((int)Keys.Enter)) || (Tecla.KeyValue == ((int)Keys.Return)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        static public void PulaCampoCheckBox(CheckBox Campo, KeyEventArgs Tecla)
        {
            //MessageBox.Show(Tecla.KeyValue.ToString());
            if ((Tecla.KeyValue == ((int)Keys.Enter)) || (Tecla.KeyValue == ((int)Keys.Return)))
            {
                SendKeys.Send("{TAB}");
            }
        }

        static public void PulaCampoCheckedListBox(CheckedListBox Campo, KeyEventArgs Tecla)
        {
            //MessageBox.Show(Tecla.KeyValue.ToString());
            if ((Tecla.KeyValue == ((int)Keys.Enter)) || (Tecla.KeyValue == ((int)Keys.Return)))
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}

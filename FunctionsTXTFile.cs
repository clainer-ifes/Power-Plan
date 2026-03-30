using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PowerPlan
{
    static class FunctionsTXTFile
    {
        static public void GravaDadosArquivoTXT(string NomeArquivo, string Texto, bool Append)
        {
            using (StreamWriter escritor = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + NomeArquivo, append: Append))
            {
                // Writes the content to the file
                escritor.WriteLine(Texto);
            }

        }


    }
}

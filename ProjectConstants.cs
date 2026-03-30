using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlan
{
    static class ProjectConstants
    {
        public static string CONSTANTE_baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
        public static string CONSTANTE_strConection = @"DataSource = " + CONSTANTE_baseDados + "; Max Database Size=4091;";
        public static string CONSTANTE_DiretorioInicial_OpenDSS = @"C:\Program Files\OpenDSS\IEEETestCases\123Bus\";
        public static string CONSTANTE_Filtro_OpenDSS_Rede = "Arquivos do OpenDSS (*.dss)|*.dss";
        public static string CONSTANTE_Filtro_OpenDSS_Coordenadas = "Arquivos de Coordenadas do OpenDSS (*.dat)|*.dat";
        public static double CONSTANTE_CapacidadeChaves_emA = 999;
    }


    static class VariaveisGlobaisProjeto
    {
        public static string NomeArquivoPrincipalRedeSelecionado = "";
        public static string NomeArquivoCoordenadas = "";

    }
}

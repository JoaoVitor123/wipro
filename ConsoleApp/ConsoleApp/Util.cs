using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    public static class Util
    {
        public static List<string> LerCSV (string caminho = @"C:\Projetos\Dados\DadosMoeda.csv")
        {
            try
            {
                string linha = "";
                List<string> linhaseparada = new List<string>();
                StreamReader reader = new StreamReader(caminho, Encoding.UTF8, true);

                while (true)
                {
                    linha = reader.ReadLine();
                    if (linha == null) break;

                    linhaseparada.Add(linha);
                }

                return linhaseparada;
            }
            catch
            {
                throw;
            }
        }

        public static void GerarCSV(List<string> MoedasLista)
        {
            var sbldr = new StringBuilder();

            sbldr.Append("ID_MOEDA;");
            sbldr.Append("DATA_REF;");
            sbldr.Append("VL_COTACAO");

            sbldr.Append("\r\n");

            foreach (string linha in MoedasLista)
            {
                var colunas = linha.Split(";");

                foreach (string column in colunas)
                {
                    sbldr.Append($"{column};");
                }

                sbldr.AppendLine();
            }

            WriteCSV(sbldr);
        }

        public static void WriteCSV(StringBuilder sbldr)
        {
            string csvpath = @$"c:\folder\Resultado_{RemocaoCaracteresEspeciais(DateTime.Now.Date.ToShortDateString())}_{RemocaoCaracteresEspeciais(DateTime.Now.ToString("HH:mm:ss"))}.csv";

            if (File.Exists(csvpath))
            {
                File.Delete(csvpath);
            }

            using (StreamWriter sw = File.CreateText(csvpath))
            {
                sw.Write(sbldr.ToString());
            }
        }

        public static string RemocaoCaracteresEspeciais(string str)
        {
            Regex rgx = new Regex(@"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]");

            return rgx.Replace(str, "");
        }
    }
}

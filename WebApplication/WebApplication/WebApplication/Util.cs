using System;
using System.IO;

namespace WebApplication
{
    public static class Util
    {
        public static bool AddFila(string texto)
        {
            try
            {
                string pasta = @"C:\folder";

                if (ValidaDiretorio(pasta))
                {
                    Escrever(pasta, texto);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
        public static bool RemoverFinal(string pasta = @"C:\folder")
        {
            int counter = 1;

            using (StreamReader reader = new StreamReader($@"{pasta}\Dados.txt"))
            {
                var readerFile = reader.ReadToEnd().Split('#');

                using (StreamWriter writer = new StreamWriter($@"{pasta}\Dados_2.txt"))
                {
                    while (readerFile.Length - 3 > counter)
                    {
                        writer.WriteLine($"#{readerFile[counter].Split("\r")[0]}");
                        counter++;
                    }
                }
            }

            File.Delete($@"{pasta}\Dados.txt");
            File.Move($@"{pasta}\Dados_2.txt", $@"{pasta}\Dados.txt");
            File.Delete($@"{pasta}\Dados_2.txt");

            return true;
        }
        public static string Ler(string pasta = @"C:\folder")
        {
            using (StreamReader Reader = new StreamReader($@"{pasta}\Dados.txt", true))
            {
                return Reader.ReadToEnd();
            }
        }
        public static string RemocaoCaracteresEspeciais(string str)
        {
            return str.Split("\r")[0];
        }
        public static void Escrever(string pasta, string texto)
        {
            using (StreamWriter writer = new StreamWriter($@"{pasta}\Dados.txt", true))
            {
                writer.WriteLine(texto);
            }
        }

        public static bool ValidaDiretorio(string pasta)
        {
            try
            {
                if (!Directory.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}

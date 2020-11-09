using ConsoleApp.Data.Model;
using ConsoleApp.REST;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var MoedasCSV = Util.LerCSV();

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Rotina(MoedasCSV);

                    Thread.Sleep(120000);
                }
            });

            thread.Start();
        }

        public static void Rotina (List<string> MoedasCSV)
        {
            WebApiClient apiClient = new WebApiClient();
            var reader = apiClient.Request();

            List<string> retornoLista = new List<string>();

            MoedasCSV.ForEach(itemCSV =>
            {
                if (DateTime.TryParse(reader.item.data_inicio, out DateTime dataInicio) &&
                    DateTime.TryParse(reader.item.data_fim, out DateTime dataFim))
                {
                    DateTime.TryParse(itemCSV.Split(';')[1], out DateTime dateMoeda);
                    var moeda = itemCSV.Split(';')[0];

                    if ((dateMoeda >= dataFim && dateMoeda <= dataInicio) || moeda == reader.item.moeda)
                    {
                        retornoLista.Add($"{itemCSV};00");
                    }
                }
            });

            Util.GerarCSV(retornoLista);
        }
    }
}

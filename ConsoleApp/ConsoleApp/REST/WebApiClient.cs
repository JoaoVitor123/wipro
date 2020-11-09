using ConsoleApp.Data.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace ConsoleApp.REST
{
    public class WebApiClient
    {
        public Retorno Request()
        {
            WebRequest request = WebRequest.Create("https://localhost:44347/api/item/GetItemFila");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Retorno));

            return (Retorno)serializer.ReadObject(responseStream);
        }
    }
}

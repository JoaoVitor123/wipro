using System.Collections.Generic;

namespace WebApplication.Data.Model
{
    public class Retorno
    {
        public bool valido { get; set; }
        public string mensagem { get; set; }
        public Item item { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication.Data.Model;

namespace WebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpPost("AddItemFila")]
        public Retorno AddItemFila ([FromBody]List<Item> itens)
        {
            try
            {
                foreach (var item in itens)
                {
                    if (DateTime.TryParse(item.data_inicio, out DateTime t) &&
                        DateTime.TryParse(item.data_fim, out DateTime t2))
                    {
                        Util.AddFila($"#{item.moeda}");
                        Util.AddFila($"#{item.data_inicio}");
                        Util.AddFila($"#{item.data_fim};");
                    }
                }

                return new Retorno
                {
                    valido = true
                };
            }
            catch (Exception e)
            {
                return new Retorno
                {
                    valido = false,
                    mensagem = e.Message
                };
            }
        }

        [HttpGet("GetItemFila")]
        public Retorno GetItemFila ()
        {
            try
            {
                var itens = Util.Ler().Split(';');

                var item = itens[itens.Length -2].Split('#');

                Util.RemoverFinal();

                return new Retorno()
                {
                    valido = true,
                    item = new Item()
                    {
                        moeda = Util.RemocaoCaracteresEspeciais(item[1]),
                        data_inicio = Util.RemocaoCaracteresEspeciais(item[2]),
                        data_fim = Util.RemocaoCaracteresEspeciais(item[3])
                    }
                };
            }
            catch (Exception e)
            {
                return new Retorno()
                {
                    valido = false,
                    mensagem = e.Message,
                    item = new Item()
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneradorUI_Demo.Modelos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeneradorUI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    public class ListsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create()
        {
            String datos;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                datos = await reader.ReadToEndAsync();
            }
            var ObjectoJson = JsonConvert.DeserializeObject<JObject>(datos);
            var datosSerializados = new ListModel
            {
                elementoId = (string)ObjectoJson["elementoId"],
                elementoName = (string)ObjectoJson["elementoName"],
                elementoFormato = (string)ObjectoJson["elementoFormato"],
                elementoEvento = (string)ObjectoJson["elementoEvento"],
                datosMostrar = ObjectoJson["datosMostrar"].Select(d => new DatosLista((string)d["Etiqueta"], (string)d["Value"])).ToList()
            };
            return await datosSerializados.GenerateView();
        }
    }
}
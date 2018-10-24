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
    public class TablesController : ControllerBase
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
            var ObjectoSerializado = new TableModel
            {
                elementoId = (string)ObjectoJson["elementoId"],
                elementoName = (string)ObjectoJson["elementoName"],
                elementoEvento = (string)ObjectoJson["elementoEvento"],
                elementoFormato = (string)ObjectoJson["elementoFormato"],
                Encabezado = ObjectoJson["encabezado"].Select(e => new HeaderTable((string)e["tituloColumna"])).ToList(),
                Contenido = ObjectoJson["contenidoTabla"].Select(b => new BodyTable
                {
                    datosFila = b["contenidoFila"].Select(f => new Fild((string)f["contenidoColumna"])).ToList()
                }).ToList()
            };

            return await ObjectoSerializado.GenerateView();
        }
    }
}
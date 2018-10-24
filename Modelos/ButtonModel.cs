using GeneradorUI_Demo.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorUI_Demo.Modelos
{
    public class ButtonModel : IGenerate
    {
        public String elementoId { get; set; }
        public String elementoName { get; set; }
        public String elementoFormato { get; set; }
        public String elementoEvento { get; set; }
        public String elementoContenido { get; set; }
        public String ElementoTipo { get; set; }

        public async Task<string> GenerateView()
        {
            ValidarDatos();
            String codigoHTML = $"id='{elementoId}' name='{elementoName}' {GenerarEstilo()} {elementoEvento}";
            codigoHTML = GenerarTipo(codigoHTML);
            return codigoHTML;
        }

        // Crea el tipo de Etiqueta requerida
        String GenerarTipo(string codigoHTML)
        {
            switch (ElementoTipo.ToLower())
            {
                case "link":
                    codigoHTML = $"<a {codigoHTML}>{elementoContenido}</a>";
                    break;
                case "input":
                    codigoHTML = $"<input type='submit' {codigoHTML} value='{elementoContenido}'/>";
                    break;
                default:
                    codigoHTML = $"<button {codigoHTML}>{elementoContenido}</button>";
                    break;
            }
            return codigoHTML;
        }

        // Seleccionar el formato del boton
        String GenerarEstilo()
        {
            String claseEstilo = String.Empty;
            switch (elementoFormato.ToLower())
            {
                case "ayuda":
                    claseEstilo = "btn btn-info";
                    break;
                case "guardar":
                    claseEstilo = "btn btn-success";
                    break;
                case "regresar":
                    claseEstilo = "btn btn-default";
                    break;
                case "cancelar":
                    claseEstilo = "btn btn-danger";
                    break;
                case "link":
                    claseEstilo = "btn btn-link";
                    break;
                default:
                    claseEstilo = "btn";
                    break;
            }
            return claseEstilo;
        }

        public void ValidarDatos()
        {
            if (elementoId == null) elementoId = String.Empty;
            if (elementoName == null) elementoName = String.Empty;
            if (elementoFormato == null) elementoFormato = String.Empty;
            if (elementoEvento == null) elementoEvento = String.Empty;
            if (elementoContenido == null) elementoContenido = String.Empty;
            if (ElementoTipo == null) ElementoTipo = String.Empty;
        }
    }
}

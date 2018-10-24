using GeneradorUI_Demo.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorUI_Demo.Modelos
{
    public class InputModel : IGenerate
    {
        public String elementoId { get; set; }
        public String elementoName { get; set; }
        public String elementoFormato { get; set; }
        public String elementoEvento { get; set; }
        public String elementoLabel { get; set; }
        public String elementoTipo { get; set; }
        public String elementoPlaceHolder { get; set; }

        public async Task<string> GenerateView()
        {
            ValidarDatos();
            String contenidoLabel = elementoLabel == String.Empty ? String.Empty : $"<label for='{elementoId}'>{elementoLabel}</label>";
            String contenidoInput = $"<input type='{elementoTipo}' id='{elementoId}' name='{elementoName}' {GenerarEstilo()} {elementoEvento} {PlaceHolder()} />";
            return contenidoLabel == String.Empty ? contenidoInput : $"{contenidoLabel}{contenidoInput}";
        }

        // Selección estilo
        String GenerarEstilo()
        {
            String claseFormato = String.Empty;
            switch (elementoFormato.ToLower())
            {
                case "control large":
                    claseFormato = "class='form-control' aria-label='Large'";
                    break;
                case "form-control":
                    claseFormato = "class='form-control'";
                    break;
                default:
                    claseFormato = String.Empty;
                    break;
            }
            return claseFormato;
        }

        // Generar etiqueta Place Holder
        String PlaceHolder()
        {
            String placeHolder = String.Empty;
            if (!elementoPlaceHolder.Equals(String.Empty))
            {
                placeHolder = $"placeholder={elementoPlaceHolder}";
            }
            return placeHolder;
        }

        public void ValidarDatos()
        {
            if (elementoId == null) elementoId = String.Empty;
            if (elementoName == null) elementoName = String.Empty;
            if (elementoFormato == null) elementoFormato = String.Empty;
            if (elementoEvento == null) elementoEvento = String.Empty;
            if (elementoLabel == null) elementoLabel = String.Empty;
            if (elementoTipo == null) elementoTipo = String.Empty;
            if (elementoPlaceHolder == null) elementoPlaceHolder = String.Empty;
        }
    }
}

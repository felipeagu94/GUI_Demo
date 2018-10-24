using GeneradorUI_Demo.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorUI_Demo.Modelos
{
    public class ListModel : IGenerate
    {
        public String elementoId { get; set; }
        public String elementoName { get; set; }
        public String elementoFormato { get; set; }
        public String elementoEvento { get; set; }
        public List<DatosLista> datosMostrar { get; set; }

        public ListModel() { }

        public async Task<string> GenerateView()
        {
            ValidarDatos();
            String codigoHtml = $"<select {GenerarEstilo()} id='{elementoId}' name='{elementoName}' {elementoEvento} title='Seleccione una opción'>";
            foreach (var datoActual in datosMostrar)
            {
                codigoHtml = $"{codigoHtml}<option value='{datoActual.Value}'>{datoActual.Etiqueta}</option>";
            }
            codigoHtml = $"{codigoHtml}</select>";
            return codigoHtml;
        }

        // Selección estilo
        String GenerarEstilo()
        {
            String claseFormato = String.Empty;
            switch (elementoFormato.ToLower())
            {
                case "form-control":
                    claseFormato = "class='selectpicker form-control'";
                    break;
                case "busqueda simple":
                    claseFormato = "class='selectpicker' data-live-search='true'";
                    break;
                case "busqueda control":
                    claseFormato = "class='selectpicker form-control' data-live-search='true'";
                    break;
                default:
                    claseFormato = "class='selectpicker'";
                    break;
            }
            return claseFormato;
        }

        public void ValidarDatos()
        {
            if (elementoId == null) elementoId = String.Empty;
            if (elementoName == null) elementoName = String.Empty;
            if (elementoFormato == null) elementoFormato = String.Empty;
            if (elementoEvento == null) elementoEvento = String.Empty;
        }
    }

    // Estructura de datos para la lista contenedora de los campos
    public class DatosLista
    {
        public String Etiqueta { get; private set; }
        public String Value { get; private set; }

        public DatosLista(string nombrePais, string value)
        {
            Etiqueta = nombrePais;
            Value = value;
        }
    }
}

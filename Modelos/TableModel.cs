using GeneradorUI_Demo.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorUI_Demo.Modelos
{
    public class TableModel : IGenerate
    {
        public String elementoId { get; set; }
        public String elementoName { get; set; }
        public String elementoFormato { get; set; }
        public String elementoEvento { get; set; }
        public List<HeaderTable> Encabezado { get; set; }
        public List<BodyTable> Contenido { get; set; }

        public async Task<string> GenerateView()
        {
            ValidarDatos();
            String contenidoHTML = $"<table id='{elementoId}' name='{elementoName}' {elementoEvento} {GenerarEstilo()}>";
            // contenido tabla
            contenidoHTML = GenerarEncabezado(contenidoHTML);
            contenidoHTML = GenerarCuerpo(contenidoHTML);
            // etiqueta cierre
            contenidoHTML = $"{contenidoHTML}</table>";
            return contenidoHTML;
        }

        // Selección estilo
        String GenerarEstilo()
        {
            String claseFormato = "table";
            Dictionary<String, String> formatos = new Dictionary<String, String>
            {
                { "form-control", "form-control" },
                { "oscura", "table-dark"},
                { "striped", "table-striped" },
                { "bordeada", "table-bordered" },
                { "hover", "table-hover" }
            };
            foreach (var formato in formatos)
            {
                if (elementoFormato.ToLower().Contains(formato.Key))
                {
                    claseFormato = $"{claseFormato} {formato.Value}";
                }
            }
            return claseFormato;
        }

        // Genera las filas con los datos de la tabla
        String GenerarCuerpo(string contenidoHTML)
        {
            contenidoHTML = $"{contenidoHTML}<tbody>";
            foreach (var datosContenido in Contenido)
            {
                contenidoHTML = GenerarFila(contenidoHTML, datosContenido);
            }
            contenidoHTML = $"{contenidoHTML}</tbody>";
            return contenidoHTML;
        }

        // Genera la fila con los datos descriptos
        String GenerarFila(string contenidoHTML, BodyTable datosContenido)
        {
            contenidoHTML = $"{contenidoHTML}<tr>";
            foreach (var datoColumna in datosContenido.datosFila)
            {
                contenidoHTML = $"{contenidoHTML}<td>{datoColumna.datoColumna}</td>";
            }
            contenidoHTML = $"{contenidoHTML}</tr>";
            return contenidoHTML;
        }

        // Genera los encabezado de la Tabla
        String GenerarEncabezado(string contenidoHTML)
        {
            contenidoHTML = $"{contenidoHTML}<thead><tr>";
            foreach (var datosEncabezado in Encabezado)
            {
                contenidoHTML = $"{contenidoHTML}<th>{datosEncabezado.tituloColumna}</th>";
            }
            contenidoHTML = $"{contenidoHTML}</tr></thead>";
            return contenidoHTML;
        }

        public void ValidarDatos()
        {
            if (elementoId == null) elementoId = String.Empty;
            if (elementoName == null) elementoName = String.Empty;
            if (elementoFormato == null) elementoFormato = String.Empty;
            if (elementoEvento == null) elementoEvento = String.Empty;
        }
    }
    // Clase contenedora los encabezados
    public class HeaderTable
    {
        public String tituloColumna { get; private set; }

        public HeaderTable(string titulo)
        {
            tituloColumna = titulo;
        }
    }
    // Clase contenedora de la estructura de las filas
    public class BodyTable
    {
        public List<Fild> datosFila { get; set; }
    }
    // Clase contenedora de los datos de cada fila
    public class Fild
    {
        public String datoColumna { get; private set; }

        public Fild(string valorDato)
        {
            datoColumna = valorDato;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneradorUI_Demo.Contratos
{
    public interface IGenerate
    {
        Task<string> GenerateView();
        void ValidarDatos();
    }
}

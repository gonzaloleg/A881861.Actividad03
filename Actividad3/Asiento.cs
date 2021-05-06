using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class Asiento
    {
        internal static void Agregar()
        {
            Auxiliar.ValidarCodigo("Ingrese el código de cuenta", 11, 34);
        }
    }
}
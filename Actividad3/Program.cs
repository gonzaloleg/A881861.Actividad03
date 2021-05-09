using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para comenzar. \n");            
            Console.ReadKey();
            Asiento.Agregar();
        }
    }
}

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
            Console.WriteLine("Presione una tecla para visualizar comenzar.\n");            
            Console.ReadKey();
            

            bool salir = false;
            int opcion;
            do
            {
                Console.WriteLine("1. Ingresar un nuevo asiento");
                Console.WriteLine("2. Grabar en Diario.txt y salir");
                opcion = Auxiliar.ValidarOpcion("Ingrese opción:", 1, 2);

                switch (opcion)
                {
                    case 1:
                        Auxiliar.MostrarPlan();
                        break;
                }

            } while (!salir);
        }
    }
}

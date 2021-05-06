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
        private Asiento (decimal debe, decimal haber, int codigoCuenta, DateTime fecha, int numero)
        {
            Debe = debe;
            Haber = haber;
            CodigoCuenta = codigoCuenta;
            Fecha = fecha;
            Numero = numero;
        }
        public decimal Debe { get; }
        public int Numero { get; }
        public decimal Haber { get; }
        public int CodigoCuenta { get; }
        public DateTime Fecha { get; } 

        internal static void Agregar()
        {
            int codigoCuenta = Auxiliar.ValidarCodigo("Ingrese el código de cuenta", 11, 34);
            int numero;
            Console.WriteLine("Ingrese la fecha del asiento (formato DD/MM/AAAA):");
            
            string ingreso = Console.ReadLine();
            while (!DateTime.TryParse(ingreso, out DateTime fecha))
            {
                Console.WriteLine("Ingreso incorrecto. Formato esperado: DD/MM/AAAA");
                continue;
            }

            //FALTA HACER DEBE HABER...............

             
        }
    }
}
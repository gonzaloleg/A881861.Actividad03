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
        public static List<Asiento> asientos = new List<Asiento>();
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

        internal static void Listar()
        {
            foreach (Asiento asiento in asientos)
            {
                Console.Write(asiento.Numero + " ");
                Console.Write(asiento.Fecha + " ");
                Console.Write(asiento.CodigoCuenta + " ");
                Console.Write(asiento.Debe + " ");
                Console.Write(asiento.Haber);
                Console.WriteLine();

            }
        }
       

        public int CodigoCuenta { get; }
        public DateTime Fecha { get; } 

        internal static void Agregar()
        {
            int codigoCuenta = Auxiliar.ValidarCodigo("Ingrese el código de cuenta", 11, 34);
            int numero = 1;
            
            DateTime fecha = Auxiliar.ValidarFecha("Ingrese la fecha del asiento (formato MM/DD/AAAA):");                   

            decimal debe = Auxiliar.ValidarMonto("Ingrese el monto para el debe:", 0, decimal.MaxValue);
            decimal haber = Auxiliar.ValidarMonto("Ingrese el monto para el haber:", 0, decimal.MaxValue);

            Asiento nuevoAsiento = new Asiento(debe, haber, codigoCuenta, fecha, numero);

            asientos.Add(nuevoAsiento);

        }


    }
}
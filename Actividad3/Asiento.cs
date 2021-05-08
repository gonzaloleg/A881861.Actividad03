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

        string diario = "Diario.txt";
        public decimal Debe { get; }
        public int Numero { get; }
        public decimal Haber { get; }
        public int CodigoCuenta { get; }
        public DateTime Fecha { get; }

        public void LevantarArchivo()
        {
            if (File.Exists(diario))
            {
                using (var reader = new StreamReader(diario))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var elDiario = new Diario(linea);
                        unDiario.Add(elDiario);
                    }
                }
            }
        }


        internal static void Listar()
        {
            foreach (Asiento asiento in asientos)
            {
                Console.Write(asiento.Numero + "|");
                Console.Write(asiento.Fecha + "|");
                Console.Write(asiento.CodigoCuenta + "|");
                Console.Write(asiento.Debe + "|");
                Console.Write(asiento.Haber);
                Console.WriteLine();                
            }
        }       

        internal static void Agregar()
        {
            int codigoCuenta = Auxiliar.ValidarOpcion("Ingrese el código de cuenta", 11, 34);
            int numero = 1;
            
            DateTime fecha = Auxiliar.ValidarFecha("Ingrese la fecha del asiento (formato MM/DD/AAAA):");                   
                                                                              //Tope arbitrario
            decimal debe = Auxiliar.ValidarMonto("Ingrese el monto para el debe:", 0, 99999999);
            decimal haber = Auxiliar.ValidarMonto("Ingrese el monto para el haber:", 0, 99999999);

            Asiento nuevoAsiento = new Asiento(debe, haber, codigoCuenta, fecha, numero);

            asientos.Add(nuevoAsiento);

        }

        

    }
}
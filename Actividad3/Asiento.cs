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

        const string diario = "Diario.txt";
        public decimal Debe { get; }
        public int Numero { get; }
        public decimal Haber { get; }
        public int CodigoCuenta { get; }
        public DateTime Fecha { get; }

        internal static void LlenarDiario()
        {
            if (File.Exists(diario))
            {
                using (var reader = new StreamReader(diario))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var update = new Asiento(linea);
                        asientos.Add(update);
                    }
                }
            }
        }
        public Asiento(string linea)
        {
            var datos = linea.Split('|');
            Numero = int.Parse(datos[0]);
            Fecha = DateTime.Parse(datos[1]);
            CodigoCuenta = int.Parse(datos[2]);
            Debe = decimal.Parse(datos[3]);
            Haber = decimal.Parse(datos[4]);
        }

        internal static int ObtenerUltimoNumero()
        {
            if (asientos.Count > 0) 
            { 
            int index = (asientos[asientos.Count - 1].Numero);
            return index;
            }
            else
            {
                return 0;
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
        internal static void Grabar()
        {
            using (var writer = new StreamWriter(diario, append: false))
            {
                foreach (var asiento in asientos)
                {
                    var linea = asiento.GetLinea();
                    writer.WriteLine(linea);
                }
            }
        }
        private object GetLinea() 
        { 
          return  $"{Numero}|{Fecha}|{CodigoCuenta}|{Debe}|{Haber}";
        }

        internal static void Agregar()
        {
            Auxiliar.MostrarPlan();
            decimal acumuladorDebe = 0;
            decimal acumuladorHaber = 0;
            LlenarDiario();
            int numero = ObtenerUltimoNumero() + 1;

            int codigoCuenta = Auxiliar.ValidarOpcion("Ingrese el código de cuenta", 11, 34);                       
            DateTime fecha = Auxiliar.ValidarFecha("Ingrese la fecha del asiento (formato MM/DD/AAAA):");                   
                                                                              //Tope arbitrario
            decimal debe = Auxiliar.ValidarMonto("Ingrese el monto para el debe:", 0, 99999999);
            acumuladorDebe = acumuladorDebe + debe;
            decimal haber = Auxiliar.ValidarMonto("Ingrese el monto para el haber:", 0, 99999999);
            acumuladorHaber = acumuladorHaber + haber;

            Asiento nuevoAsiento = new Asiento(debe, haber, codigoCuenta, fecha, numero);

            asientos.Add(nuevoAsiento);

            Console.WriteLine("Agregar movimiento destino:");
            codigoCuenta = Auxiliar.ValidarOpcion("Ingrese el código de cuenta", 11, 34);
            debe = Auxiliar.ValidarMonto("Ingrese el monto para el debe:", 0, 99999999);
            acumuladorDebe = acumuladorDebe+debe;
            haber = Auxiliar.ValidarMonto("Ingrese el monto para el haber:", 0, 99999999);
            acumuladorHaber = acumuladorHaber+haber;
            Asiento nuevoMovimiento = new Asiento(debe, haber, codigoCuenta, fecha, numero);

            asientos.Add(nuevoMovimiento);

            bool salir = false;
            
            do
            {
                Console.WriteLine("¿Desea ingresar otro movimiento para el asiento en curso?");
                int opcion = Auxiliar.ValidarOpcion("1- SI         2-NO (GRABAR ASIENTO EN DIARIO)", 1, 2);

                if (opcion == 1)
                {
                    Console.WriteLine("¿Cuantos movimientos más desea incorporar al asiento?");
                    string ingreso = Console.ReadLine();
                    int cantidad = 0;
                    if (!int.TryParse(ingreso, out cantidad))
                    {
                        Console.WriteLine("Debe ingresar un número.");
                        continue;
                    }
                    
                    for (int i = 0; i < cantidad; i++)
                    {
                        codigoCuenta = Auxiliar.ValidarOpcion("Ingrese el código de cuenta", 11, 34);
                        debe = Auxiliar.ValidarMonto("Ingrese el monto para el debe:", 0, 99999999);
                        acumuladorDebe = acumuladorDebe + debe;
                        haber = Auxiliar.ValidarMonto("Ingrese el monto para el haber:", 0, 99999999);
                        acumuladorHaber = acumuladorHaber + haber;
                        Asiento nuevoMovimiento2 = new Asiento(debe, haber, codigoCuenta, fecha, numero);
                        asientos.Add(nuevoMovimiento2);

                    }
                    if (acumuladorHaber == acumuladorDebe)
                    {
                        Grabar();
                        Console.WriteLine("Asiento grabado en Diario.txt");
                        salir = true;
                    }
                    else
                    {
                        Console.WriteLine("Principio contable no cumplido (Debe no es igual a Haber). Asiento descartado.");
                        asientos.RemoveRange(asientos.Count - (cantidad + 2), cantidad + 2);
                        salir = true;
                    }


                }
                if (opcion == 2)
                {
                    if (acumuladorDebe == acumuladorHaber)
                    {
                        Grabar();
                        Console.WriteLine("El asiento ha sido grabado exitosamente en Diario.txt.");
                        salir = true;
                    }
                    else
                    {
                        asientos.Remove(nuevoAsiento);
                        asientos.Remove(nuevoMovimiento);                        
                        Console.WriteLine("Principio contable no cumplido (Debe no es igual a Haber). Asiento descartado.");                        
                        salir = true;                       
                    }
                }
                

            } while (!salir);

            salir = false;

            do
            {
                Console.WriteLine("¿Desea ingresar otro asiento?");
                int opcion2 = Auxiliar.ValidarOpcion("1- SI         2-NO (SALIR)", 1, 2);

                if (opcion2 == 1)
                {
                    Agregar();
                }
                if (opcion2 == 2)
                {
                    salir = true;
                }

            } while (!salir);

        }
        
    }
}
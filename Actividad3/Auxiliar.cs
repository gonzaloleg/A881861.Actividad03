﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad3
{
    internal class Auxiliar
    {
        const string archivo = "plandecuentas.txt";

        internal static void MostrarPlan()
        {    
                using (var reader = new StreamReader(archivo))

                {
                    while (!reader.EndOfStream) 
                    { 
                    var linea = reader.ReadLine();
                    Console.WriteLine(linea);
                    }
                }
                       
        }

        internal static int ValidarCodigo(string mensaje, int min , int max)
        {
            int res;

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine($"\nNo puede ingresar un valor menor a : {min} \nNo puede ingresar un valor mayor a: {max}");

                if (!int.TryParse(Console.ReadLine(), out res))
                {
                    Console.WriteLine("Por favor ingrese un número válido.");
                    res = -1;
                }

            } while (res < min || res > max);

            return res;
        }

        internal static DateTime ValidarFecha(string mensaje)
        {
            DateTime valor;
            bool ok = false;
            
            do
            {
                Console.WriteLine(mensaje);
                if (!DateTime.TryParse(Console.ReadLine(), out valor))
                {
                    Console.WriteLine("Ingreso inválido. Formato MM/DD/AAAA.");
                }
                else if (valor > DateTime.Now)
                {
                    Console.WriteLine("El asiento no puede registrarse en el futuro.");
                }
                else
                {
                    ok = true;
                }
            } while (!ok);

            return valor;

        }

        internal static decimal ValidarMonto(string mensaje, int min, decimal max)
        {
            int res;

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine($"\nNo puede ingresar un valor menor a : {min} \nNo puede ingresar un valor mayor a: {max}");

                if (!int.TryParse(Console.ReadLine(), out res))
                {
                    Console.WriteLine("Por favor ingrese un número válido.");
                    res = -1;
                }

            } while (res < min || res > max);

            return res;
        }
    }
}
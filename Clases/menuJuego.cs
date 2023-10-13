using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta.Clases
{
    internal class menuJuego
    {
        cliente persona = new cliente();

        public bool menuMostrar()
        {
            int opc = seleccionar();

            return ejecutar(opc);

        }

        public int seleccionar()
        {
            string? opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opcion");
                Console.WriteLine("1) Apostar");
                Console.WriteLine("2) Consultar estadisticas");
                Console.WriteLine("3) Salir");
                opcion = Console.ReadLine();
                if(opcion != "1" && opcion != "2" && opcion != "3")
                {
                    Console.WriteLine("Opcion invalida, presione ENTER para continuar");
                    Console.ReadLine();
                    opcion = null;
                }
            } while (opcion == null);

            return Int32.Parse(opcion);
        }

        public bool ejecutar(int seleccion)
        {
            switch (seleccion)
            {
                case 1:
                    int modo = seleccionarAP();
                    int inversion = agregarMonto();
                    return persona.ejecutarApuesta(modo, inversion);
                case 2:
                    persona.Datos();
                    return true;
                case 3:
                    Salida();
                    return false;
                default:
                    return false;
            }
        }
        public int seleccionarAP()
        {
            string? opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Seleccione el tipo de apuesta a realizar");
                Console.WriteLine("1) Numero específico");
                Console.WriteLine("2) Por color");
                Console.WriteLine("3) Par o impar");
                opcion = Console.ReadLine();
                if (opcion != "1" && opcion != "2" && opcion != "3")
                {
                    Console.WriteLine("Opcion invalida, presione para continuar");
                    Console.ReadLine();
                    opcion = null;
                }
            } while (opcion == null);
            return Int32.Parse(opcion);
        }

        public int agregarMonto() { 
            string? opcion;
            int monto;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Cuanto desea apostar?");
                    Console.WriteLine("La apuesta debe de ser en multiplos de 10");
                    opcion = Console.ReadLine();
                } while (opcion == null);
                monto = Int32.Parse(opcion);
            } while ((monto % 10) != 0 || monto < 10);//si no se selecciono un monto multiplo de 10

            return monto;
        }

        public void Salida()
        {
            Console.WriteLine("Estadisticas finales:");
            persona.Datos();
        }
    }
}

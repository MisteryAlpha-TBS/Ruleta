using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta.Clases
{
    internal class Apuesta
    {
        public List<int> listaBlack = new List<int>(){ 2, 4, 6, 8, 10, 11, 13, 15, 17,
              20, 22, 24, 26, 28, 29, 31, 33, 35 };
        public List<int> listaRed = new List<int>() { 1, 3, 5, 7, 9, 12, 14, 16,
             18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        public estadisticas? estadisticas;

        public bool apuestaMode(int modo)
        {
            Random random = new Random();
            int numWiner = random.Next(0, 37);
            estadisticas.num.Append(numWiner);
            estadisticas.tiradas++;

            switch (modo)
            {
                case 1:
                    return apuestaNum(numWiner);
                case 2:
                    return ApuestaColor(numWiner);
                case 3:
                    return apuestaPar(numWiner);
                default:
                    Console.WriteLine("ERROR");
                    return false;
            }
        }

        public bool apuestaNum(int nuemro)
            {
                if (nuemro == seleccionNum())
                {
                estadisticas.win++;
                ImprimirNumero(nuemro);
                    return true;
                }
                ImprimirNumero(nuemro);
                estadisticas.lose++;
                return false;

            }

         int seleccionNum()
            {
            string? num;
                do{
                    Console.Clear();
                    Console.WriteLine("Ingrese un numero del 0 al 36");
                    num = Console.ReadLine();

                if(Int32.Parse(num)<0 && Int32.Parse(num) >36)
                    {
                        num = null;
                    }
                } while (num == null);
            return Int32.Parse(num);
          }

        public bool seleccionColor()
        {
            string? opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("Selecciona un color");
                Console.WriteLine("1) Rojo");
                Console.WriteLine("2) Negro");
                opcion = Console.ReadLine();
                if (opcion != "1" && opcion != "2")
                { // si no se selecciona una opcion valida
                    Console.WriteLine("Opcion invalida, presione para continuar");
                    Console.ReadLine();
                    opcion = null;
                }
            } while (opcion == null);

            if (opcion == "1")
                return true;
            else
                return false;
        }

        public bool ApuestaColor(int numGan)
        {
            // true red false black
            bool color = seleccionColor(); // el usuario hace la seleccion de su apuesta
            ImprimirNumero(numGan);
            if ((Color(numGan) == "negro" && color == false)
            || (Color(numGan) == "rojo" && color == true))
            {
                return true;
            }
            return false;
        }



        public int seleccionPar()
        {
            string? num;
            do
            {
                Console.Clear();
                Console.WriteLine("(1)Par\n(2)Impar");
                num = Console.ReadLine();
                if ( num != "1" && num != "2")
                {
                    Console.WriteLine("Opcion incorrecta");
                    num = null;
                }
            } while (num == null);
            if(num == "1")
            {
                estadisticas.tiradasPar++;
            }
            else
            {
                estadisticas.tiradasImpar++;
            }
            return Int32.Parse(num);

        }

        public int par(int numero)
        {
            if(numero%2 == 0)
            {
                return 1;
            }
            return 2;
        }

        public bool apuestaPar(int numeroGan)
        {
            int selec = seleccionPar();
            if(par(numeroGan) == selec)
            {
                ImprimirNumero(numeroGan);
                estadisticas.win++;
                return true;
            }
            ImprimirNumero(numeroGan);
            estadisticas.lose++;
            return false;
        }

        public void ImprimirNumero(int numero)
        {
            Console.WriteLine("Y el numero es...");
            if (numero == 0)
            {
                Console.WriteLine("0, sin color");
            }
            else
            {

                Console.WriteLine($"{numero}, {Color(numero)}");
            }
        }

        public string Color(int numero)
        {
            // retorna 0 si el numero no tiene color, 1 si es negro y 2 si es rojo
            if (numero == 0)
                return "na";
            if (DefinirColor(listaBlack, numero))
                return "negro";
            if (DefinirColor(listaRed, numero))
                return "rojo";
            return "error"; // si retorna 3 ocurrio un error
        }

        bool DefinirColor(List<int> lista, int numero)
        {
            foreach (int n in lista)
            {
                if (n == numero)
                {
                    return true;
                }
            }
            return false;
        }


    }


    }



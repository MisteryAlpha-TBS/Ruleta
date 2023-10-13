using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta.Clases
{
    internal class cliente
    {
        public int dinero;
        public Apuesta apuesta = new Apuesta();

        public cliente()
        {
            this.dinero = 300;
            this.apuesta.estadisticas = new estadisticas(this.dinero);
        }

        public bool ejecutarApuesta (int modoAP, int inversion)
        {
            this.dinero -= inversion;
            apuesta.estadisticas.ganancia = this.dinero;
            if (apuesta.apuestaMode(modoAP))
            {
                Console.WriteLine("***¡¡GANASTE!!***");
                AgregarPremio(inversion, modoAP);
                return true;
            }
            else
            {
                Console.WriteLine("Has perdido :(");
                if(this.dinero < 10)
                {
                    Console.WriteLine("Dinero insuficiente");
                    Console.WriteLine("Juego Terminado");
                    return false;
                }
                else
                {
                    Console.WriteLine("Vuelve a probar suerte");
                    return true;
                }
            }

        }

        public void AgregarPremio(int money, int caso) {
            switch (caso)
            {
                case 1:
                    this.dinero += (money * 10);
                    break;
                case 2:
                    this.dinero += (money * 5);
                    break;
                case 3:
                    this.dinero += (money * 2);
                    break;
            }
            apuesta.estadisticas.ganancia = this.dinero;
        }

        public void Datos()
        {
            Console.Clear();
            Console.WriteLine($"Dinero Actual: {apuesta.estadisticas.ganancia}");
            Console.WriteLine($"Numero de tiradas hasta ahora: {apuesta.estadisticas.tiradas}");
            Console.WriteLine($"Numero de victorias: {apuesta.estadisticas.win}");
            Console.WriteLine($"Numero de tiradas perdidas: {apuesta.estadisticas.lose}");
            Console.WriteLine($"Numero de tiradas a par: {apuesta.estadisticas.tiradasPar}");
            Console.WriteLine($"Numero de tiradas a impar: {apuesta.estadisticas.tiradasImpar}");
            Console.WriteLine($"Numero de tiradas a color negro: {apuesta.estadisticas.tiradasBlack}");
            Console.WriteLine($"Numero de tiradas a color rojo: {apuesta.estadisticas.tiradasRed}");
            Console.Write("Numeros Ganadores: ");
            foreach (int i in apuesta.estadisticas.num) { Console.Write($"{apuesta.estadisticas.num[i]}, "); }
        }
       
    }
}

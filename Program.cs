using Ruleta.Clases;

menuJuego menu = new menuJuego();

Console.WriteLine("Bienvenido al Casino");
do
{
    Console.WriteLine();
    Console.Write("Presione enter para continuar");
    Console.ReadLine();
} while (menu.menuMostrar());

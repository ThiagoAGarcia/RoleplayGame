using System;
using System.Collections;

namespace RoleplayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Elf with the proper constructor
            Elfo elfo = new Elfo("Galadriel");
            
            
            // Add Hechizos to Elf
            elfo.AgregarHechizo(Hechizo.TormentaElectrica);
            elfo.AgregarHechizo(Hechizo.RayoDeHielo);
            

            // Add Hechizo to Elf
            elfo.AgregarHechizo(Hechizo.BolaDeFuego);

            // Create a Dwarf
            Enano enano = new Enano("Thorin");
            

            // Add Items to Dwarf
            enano.AgregarItem(Item.Espada);
            enano.AgregarItem(Item.Armadura);

            // Create a Wizard
            Mago mago = new Mago("Gandalf");

            // Add Hechizos to Wizard
            mago.AgregarHechizo(Hechizo.RayoDeHielo);
            mago.AgregarHechizo(Hechizo.BolaDeFuego);

            // Elf heals
            elfo.Curar(20);
            Console.WriteLine($"Elfo vida: {elfo.Vida}");

            // Wizard attacks Elf
            elfo.RecibirAtaque(mago.ValorAtaque(), mago.Nombre);
            Console.WriteLine($"Elfo vida: {elfo.Vida}");
            
            elfo.Curar(20);
            Console.WriteLine($"Elfo vida: {elfo.Vida}");
        }
    }
}

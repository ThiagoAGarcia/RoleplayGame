using System;
using System.Collections;

namespace RoleplayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Elfo elfo = new Elfo("Legolas");
            Enano enano = new Enano("Gimli");
            Mago mago = new Mago("Gandalf");

            // Crear y agregar items
            Item espada = Item.Espada;
            Item escudo = Item.Escudo;
            Item arco = Item.Arco;
            Item armadura = Item.Armadura;

            elfo.AgregarItem(arco);
            elfo.AgregarItem(escudo);

            enano.AgregarItem(espada);
            enano.AgregarItem(armadura);
            
            mago.Estudiar(12);

            mago.AgregarItem(espada);
            mago.AgregarHechizo(Hechizo.BolaDeFuego);
            mago.AgregarHechizo(Hechizo.RayoDeHielo);
            
            Console.WriteLine("\nAtaques y hechizos:");
            
            
            int ataqueElfo = elfo.ValorAtaque();
            enano.RecibirAtaque(ataqueElfo, elfo.Nombre);
            
            int ataqueEnano = enano.ValorAtaque();
            mago.RecibirAtaque(ataqueEnano, enano.Nombre);
            
            Hechizo hechizo = Hechizo.BolaDeFuego;
            int ataqueMago = mago.ValorAtaque(hechizo: hechizo);
            elfo.RecibirAtaque(ataqueMago, mago.Nombre);
            elfo.Curar(30);
           
        }
        
    }
}
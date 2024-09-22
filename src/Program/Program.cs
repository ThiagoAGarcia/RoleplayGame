using System;
using System.Collections;

namespace RoleplayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IPersonaje elfo = new Elfo("Legolas");
            IPersonaje enano = new Enano("Gimli");
            IPersonaje mago = new Mago("Gandalf");

            // Crear y agregar items
            ItemAtaque espada = Items.Espada;
            ItemDefensa escudo = Items.Escudo;
            ItemAtaque arco = Items.Arco;
            ItemDefensa armadura = Items.Armadura;

            elfo.AgregarItemAtaque(arco);
            enano.AgregarItemAtaque(espada);
            mago.AgregarItemDefensa(armadura);
            mago.AgregarItemAtaque(espada);
            
            
            if (mago is Mago magoPersonaje)
            {
                magoPersonaje.AgregarHechizo(Hechizo.BolaDeFuego);
                magoPersonaje.AgregarHechizo(Hechizo.RayoDeHielo);
            }
            

            Console.WriteLine("\nAtaques y hechizos:");
            
            // Simular ataques y curaciones
            int ataqueElfo = elfo.ValorAtaque();
            enano.RecibirAtaque(ataqueElfo, elfo.Nombre);
            
            int ataqueEnano = enano.ValorAtaque();
            mago.RecibirAtaque(ataqueEnano, enano.Nombre);
            
            Hechizo hechizo = Hechizo.BolaDeFuego;
            
            
            if (mago is Mago magoPersonajeParaAtaque)
            {
                int ataqueMago = magoPersonajeParaAtaque.ValorAtaque(hechizo);
                elfo.RecibirAtaque(ataqueMago, mago.Nombre);
            }

            if (elfo is Elfo elfoPersonaje)
            {
                elfoPersonaje.Curar(20);
            }
        }
    }
}
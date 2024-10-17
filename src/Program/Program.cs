using System;

namespace RoleplayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ICurador elfo = new Elfo("Legolas");
            IPersonaje enano = new Enano("Gimli");
            IHechicero mago = new Mago("Gandalf");
            IPersonaje troll = new Troll("Scabbers", true);
            
            ItemAtaque espada = Items.Espada;
            ItemDefensa escudo = Items.Escudo;
            ItemAtaque arco = Items.Arco;
            ItemDefensa armadura = Items.Armadura;
            ItemMagico varita = Items.varita;
            ItemAtaque paloGigante = Items.PaloGigante;

            elfo.AgregarItemAtaque(arco);
            enano.AgregarItemAtaque(espada);
            mago.AgregarItemDefensa(armadura);
            mago.AgregarItemAtaque(espada);
            troll.AgregarItemAtaque(paloGigante);
            
            mago.AgregarItemMagico(varita);
            mago.AgregarHechizo(Hechizo.BolaDeFuego);
            mago.AgregarHechizo(Hechizo.RayoDeHielo);

            Console.WriteLine("\nAtaques y hechizos:");
            
            int ataqueElfo = elfo.ValorAtaque();
            enano.RecibirAtaque(elfo);

            int ataqueEnano = enano.ValorAtaque();
            mago.RecibirAtaque(enano);

            int ataqueTroll = troll.ValorAtaque();
            elfo.RecibirAtaque(troll);
            
            Hechizo hechizo = Hechizo.BolaDeFuego;
            elfo.RecibirHechizo(mago, hechizo);
            
            elfo.Curar(20);
        }
    }
}
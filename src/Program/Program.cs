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
            IHechicero magoOscuro = new Mago("Black Gandalf");
            IPersonaje troll = new Troll("Scabbers", true);

            ItemAtaque espada = Items.Espada;
            ItemDefensa escudo = Items.Escudo;
            ItemAtaque arco = Items.Arco;
            ItemDefensa armadura = Items.Armadura;
            ItemMagico varita = Items.varita;
            ItemAtaque paloGigante = Items.PaloGigante;
            ItemMagico grimorio = Items.grimorio;

        elfo.AgregarItemAtaque(arco);
            enano.AgregarItemAtaque(espada);
            mago.AgregarItemDefensa(armadura);
            mago.AgregarItemAtaque(espada);
            troll.AgregarItemAtaque(paloGigante);
            
            mago.AgregarItemMagico(varita);
            magoOscuro.AgregarItemMagico(grimorio);
            mago.AgregarHechizo(Hechizo.BolaDeFuego);
            mago.AgregarHechizo(Hechizo.RayoDeHielo);
            magoOscuro.AgregarHechizo(Hechizo.BolaDeFuego);
            

            Console.WriteLine("\nAtaques y hechizos:");
            
            int ataqueElfo = elfo.ValorAtaque();
            enano.RecibirAtaque(elfo);

            int ataqueEnano = enano.ValorAtaque();
            mago.RecibirAtaque(enano);

            int ataqueTroll = troll.ValorAtaque();
            elfo.RecibirAtaque(troll);
            
            Hechizo hechizo = Hechizo.BolaDeFuego;
            elfo.RecibirHechizo(mago, hechizo);

            magoOscuro.ListarHechizos();
            
            elfo.Curar(20, mago);
        }
    }
}
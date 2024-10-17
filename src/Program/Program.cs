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

            IAtaque espada = Items.Espada;
            IDefensa escudo = Items.Escudo;
            IAtaque arco = Items.Arco;
            IDefensa armadura = Items.Armadura;
            IItemMagico varita = Items.varita;
            IAtaque paloGigante = Items.PaloGigante;
            IItemMagico grimorio = Items.grimorio;

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
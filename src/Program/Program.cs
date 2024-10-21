using System;

namespace RoleplayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ICurador elfo = new Elfo("Legolas");
            IPersonajeHero enano = new Enano("Gimli");
            IHechiceroHero mago = new Mago("Gandalf");
            IHechiceroEnemigo magoOscuro = new MagoOscuro("Black Gandalf");
            IPersonajeEnemigo troll = new Troll("Scabbers", true);

            IAtaque espada = Items.Espada;
            IDefensa escudo = Items.Escudo;
            IAtaque arco = Items.Arco;
            IDefensa armadura = Items.Armadura;
            IItemMagicoHero varita = Items.varita;
            IAtaque paloGigante = Items.PaloGigante;
            IItemMagicoEnemigo grimorio = Items.grimorio;

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
            enano.RecibirAtaque(troll);

            int ataqueEnano = enano.ValorAtaque();
            mago.RecibirAtaque(troll);

            int ataqueTroll = troll.ValorAtaque();
            elfo.RecibirAtaque(troll);
            
            Hechizo hechizo = Hechizo.BolaDeFuego;
            elfo.RecibirHechizo(magoOscuro, hechizo);

            magoOscuro.ListarHechizos();
            
            elfo.Curar(20, mago);
        }
    }
}
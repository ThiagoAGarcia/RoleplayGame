using System;

namespace RoleplayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Elfo elfo = new Elfo("Legolas");
            Enano enano = new Enano("Gimli");
            Mago mago = new Mago("Gandalf");
            MagoOscuro magoOscuro = new MagoOscuro("Black Gandalf"); 
            Troll troll = new Troll("Scabbers", true);

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

           Console.WriteLine("Encuentro de combate:");
            BattleEncounter encuentro = new BattleEncounter(new List<PersonajeHero> { elfo, enano, mago }, new List<PersonajeEnemigo> { troll, magoOscuro });
            encuentro.DoEncounter();
        }
    }
}
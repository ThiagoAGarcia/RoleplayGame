using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
    [TestFixture]
    public class DragonTests
    {
        [Test]
        public void CrearDragon_ConVidaYAtaque_Correctos()
        {
            AtaquesDragon ataquesDragon = new AtaquesDragon("LanzaLLamas", 30);
            Dragon dragon = new Dragon("Smaug");

            Assert.AreEqual("Smaug", dragon.Nombre);
            Assert.AreEqual(200, dragon.VerVida());
            Assert.AreEqual(20, dragon.VerAtaque());
        }

        [Test]
        public void DragonUsarAtaqueFuego_ReduceVidaObjetivo()
        {
            AtaquesDragon ataquesDragon = new AtaquesDragon("Ataque Cola", 30);
            Dragon dragon = new Dragon("Smaug");
            PersonajeHero objetivo = new PersonajeHero { Nombre = "Guerrero", Vida = 100, Ataque = 15 };
            dragon.AgregarAtaque(ataquesDragon);
            dragon.RealizarAtaque(objetivo, ataquesDragon);

            Assert.AreEqual(50, objetivo.VerVida());
        }

        [Test]
        public void DragonUsarAtaqueCola_ReduceVidaObjetivo()
        {
            AtaquesDragon ataquesDragon = new AtaquesDragon("Llamarada", 30);
            
            AtaquesDragon Ataque2 = new AtaquesDragon("bomba", 50);
            Dragon dragon = new Dragon("Smaug");
            PersonajeHero objetivo = new PersonajeHero { Nombre = "Caballero", Vida = 100, Ataque = 10 };
            dragon.AgregarAtaque(ataquesDragon);

            dragon.RealizarAtaque(objetivo, ataquesDragon);

            Assert.AreEqual(50, objetivo.VerVida());
            dragon.RealizarAtaque(objetivo, Ataque2);
            Assert.AreEqual(50, objetivo.VerVida());
        }

        [Test]
        public void PersonajeRecibirAtaque_ReduceVidaCorrectamente()
        {
           
            PersonajeEnemigo atacante = new MagoOscuro("miguel") ;
            PersonajeHero defensor = new PersonajeHero { Nombre = "Elfo", Vida = 100, Ataque = 15 };

            
            defensor.RecibirAtaque(atacante);

            Assert.AreEqual(92, defensor.VerVida());
        }
    }
}

using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
    [TestFixture]
    public class RoleplayGameTests
    {
        [Test]
        public void CrearDragon_ConVidaYAtaque_Correctos()
        {
            AtaquesDragon ataquesDragon = new AtaquesDragon(50, 30);
            Dragon dragon = new Dragon("Smaug", 100, 25, ataquesDragon);

            Assert.AreEqual("Smaug", dragon.Nombre);
            Assert.AreEqual(100, dragon.VerVida());
            Assert.AreEqual(25, dragon.VerAtaque());
        }

        [Test]
        public void DragonUsarAtaqueFuego_ReduceVidaObjetivo()
        {
            AtaquesDragon ataquesDragon = new AtaquesDragon(50, 30);
            Dragon dragon = new Dragon("Smaug", 100, 25, ataquesDragon);
            Personaje objetivo = new Personaje { Nombre = "Guerrero", Vida = 100, Ataque = 15 };

            dragon.UsarAtaqueFuego(objetivo);

            Assert.AreEqual(50, objetivo.VerVida(), "La vida del objetivo debería haberse reducido a 50 después del ataque de fuego.");
        }

        [Test]
        public void DragonUsarAtaqueCola_ReduceVidaObjetivo()
        {
            AtaquesDragon ataquesDragon = new AtaquesDragon(50, 30);
            Dragon dragon = new Dragon("Smaug", 100, 25, ataquesDragon);
            Personaje objetivo = new Personaje { Nombre = "Caballero", Vida = 100, Ataque = 10 };

            dragon.UsarAtaqueCola(objetivo);

            Assert.AreEqual(70, objetivo.VerVida(), "La vida del objetivo debería haberse reducido a 70 después del ataque con la cola.");
        }

        [Test]
        public void PersonajeRecibirAtaque_ReduceVidaCorrectamente()
        {
            // Arrange
            Personaje atacante = new Personaje { Nombre = "Orco", Vida = 80, Ataque = 20 };
            Personaje defensor = new Personaje { Nombre = "Elfo", Vida = 100, Ataque = 15 };

            // Act
            defensor.RecibirAtaque(atacante);

            Assert.AreEqual(80, defensor.VerVida(), "La vida del defensor debería haberse reducido correctamente después del ataque.");
        }
    }
}

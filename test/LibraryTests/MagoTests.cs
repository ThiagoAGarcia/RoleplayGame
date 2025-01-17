using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class MagoTests
    {
        Mago mago = new Mago("pepe");
        Enano enano = new Enano("rancio");

        IAtaque espada = Items.Espada;
        IDefensa escudo = Items.Escudo;
        

        [SetUp]
        public void Setup()
        {
            mago = new Mago("Gandalf");
            espada = Items.Espada;
            escudo = Items.Escudo;
            enano = new Enano("Brok");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Gandalf", mago.Nombre);
            Assert.AreEqual(150, mago.Vida);
            Assert.AreEqual(10, mago.Ataque);
        }

        [Test]
        public void TestAgregarHechizo()
        {
            var hechizo = Hechizo.BolaDeFuego;
            mago.AgregarHechizo(hechizo);

            Assert.AreEqual(1, mago.HechizosCount);
            Assert.AreEqual(hechizo.Ataque, ((Hechizo)mago.VerHechizo(0)).Ataque);
        }

        [Test]
        public void TestAgregarItem()
        {
            mago.AgregarItemAtaque(espada);
            mago.AgregarItemDefensa(escudo);
            Assert.AreEqual(2, mago.ItemsCount);
        }

        [Test]
        public void TestValorAtaque()
        {
            mago.AgregarItemAtaque(espada);
            int valorAtaque = mago.ValorAtaque();

            Assert.AreEqual(40, valorAtaque);
        }
    }
}
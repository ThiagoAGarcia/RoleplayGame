using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class MagoOscuroTests
    {
        MagoOscuro mago = new MagoOscuro("pepe");
        Enano enano = new Enano("rancio");
        Mago magoNormal = new Mago("rancio");

        IAtaque espada = Items.Espada;
        IDefensa escudo = Items.Escudo;
        

        [SetUp]
        public void Setup()
        {
            mago = new MagoOscuro("Gandalf");
            magoNormal = new Mago("carlito");
            magoNormal.AgregarHechizo(Hechizo.BolaDeFuego);
            espada = Items.Espada;
            escudo = Items.Escudo;
            enano = new Enano("Brok");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Gandalf", mago.Nombre);
            Assert.AreEqual(190, mago.Vida);
            Assert.AreEqual(8, mago.Ataque);
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

            Assert.AreEqual(38, valorAtaque);
        }
        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            mago.RecibirAtaque(enano);
            
            Assert.AreEqual(160, mago.Vida);
        }
        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            mago.AgregarItemDefensa(escudo);
            mago.RecibirAtaque(enano);
            
            Assert.AreEqual(165, mago.Vida);
        }
        [Test]
        public void TestRecibirHechizo()
        {
            mago.AgregarItemDefensa(escudo);
            mago.RecibirHechizo(magoNormal, Hechizo.BolaDeFuego);
            
            Assert.AreEqual(145, mago.Vida);
        }
    }
}
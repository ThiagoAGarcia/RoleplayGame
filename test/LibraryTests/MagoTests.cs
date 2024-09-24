using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class MagoTests
    {
        private Mago mago;
        private ItemAtaque espada;
        private ItemDefensa escudo;
        private Enano enano;

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
            Assert.AreEqual("Gandalaf", mago.Nombre);
            Assert.AreEqual(150, Mago.Vida);
            Assert.AreEqual(10, Mago.Ataque);
        }

        [Test]
        public void TestAgregarHechizo()
        {
            var hechizo = Hechizo.BolaDeFuego;
            mago.AgregarHechizo(hechizo);

            Assert.AreEqual(1, mago.Hechizos.Count);
            Assert.AreEqual(hechizo.Ataque, ((Hechizo)mago.Hechizos[0]).Ataque);
        }

        [Test]
        public void TestAgregarItem()
        {
            mago.AgregarItemAtaque(espada);
            mago.AgregarItemDefensa(escudo);
            Assert.AreEqual(2, mago.Items.Count); 
        }

        [Test]
        public void TestValorAtaque()
        {
            mago.AgregarItemAtaque(espada); 
            int valorAtaque = mago.ValorAtaque();

            Assert.AreEqual(50, valorAtaque);
        }
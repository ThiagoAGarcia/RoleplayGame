using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
    public class EnanoTests
    {
        private Enano enano;

        [SetUp]
        public void Setup()
        {
            enano = new Enano("Thorin");
        }

        [Test]
        public void TestInicializacionEnano()
        {
            Assert.AreEqual("Thorin", enano.Nombre);
            Assert.AreEqual(150, enano.Vida);
            Assert.AreEqual(20, enano.Ataque);
        }

        [Test]
        public void TestAgregarItem()
        {
            enano.AgregarItem(Item.Espada);
            enano.AgregarItem(Item.Escudo);

            Assert.AreEqual(2, enano.Item.Count); 
        }

        [Test]
        public void TestValorAtaque()
        {
            enano.AgregarItem(Item.Espada); 
            enano.AgregarItem(Item.Arco); 
            int valorAtaque = enano.ValorAtaque();

            Assert.AreEqual(75, valorAtaque); 
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            enano.RecibirAtaque(30, "Orco");

            Assert.AreEqual(120, enano.Vida); 
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            enano.AgregarItem(Item.Escudo); 
            enano.RecibirAtaque(60, "Orco");

            Assert.AreEqual(140, enano.Vida); 
        }
    }
}
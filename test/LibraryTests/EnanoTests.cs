using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGameTests
{
    public class EnanoTests
    {
        private Enano enano;
        private Mago mago;
        private ItemAtaque espada;
        private ItemDefensa escudo;

        [SetUp]
        public void Setup()
        {
            enano = new Enano("Thorin");
            mago = new Mago("Saruman");
            espada = Items.Espada;  
            escudo = Items.Escudo;  
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
            enano.AgregarItemAtaque(Items.Espada); 
            enano.AgregarItemDefensa(Items.Escudo); 

            Assert.AreEqual(2, enano.Items.Count);
        }

        [Test]
        public void TestValorAtaque()
        {
            enano.AgregarItemAtaque(Items.Espada); 
            enano.AgregarItemAtaque(Items.Arco); 
            int valorAtaque = enano.ValorAtaque();

            Assert.AreEqual(75, valorAtaque); 
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            enano.RecibirAtaque(mago);

            Assert.AreEqual(120, enano.Vida);
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            enano.AgregarItemDefensa(Items.Escudo); 
            enano.RecibirAtaque(mago);

            Assert.AreEqual(140, enano.Vida);
        }
    }
}
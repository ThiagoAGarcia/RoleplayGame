using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGameTests
{
    public class EnanoTests
    {
        Mago mago = new Mago("pepe");
        Enano enano = new Enano("rancio");
        
        IAtaque espada = Items.Espada;
        IDefensa escudo = Items.Escudo;
        IAtaque arco = Items.Arco;
        IDefensa armadura = Items.Armadura;
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
            Assert.AreEqual(200, enano.VerVida());
            Assert.AreEqual(30, enano.VerAtaque());
        }

        [Test]
        public void TestAgregarItem()
        {
            enano.AgregarItemAtaque(Items.Espada); 
            enano.AgregarItemDefensa(Items.Escudo); 

            Assert.AreEqual(2, enano.ItemsCount);
        }

        [Test]
        public void TestValorAtaque()
        {
            enano.AgregarItemAtaque(Items.Espada); 
            enano.AgregarItemAtaque(Items.Arco); 
            int valorAtaque = enano.ValorAtaque();

            Assert.AreEqual(85, valorAtaque); 
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            enano.RecibirAtaque(mago);

            Assert.AreEqual(190, enano.VerVida());
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            enano.AgregarItemDefensa(Items.Escudo); 
            enano.RecibirAtaque(mago);

            Assert.AreEqual(200, enano.VerVida());
        }
    }
}
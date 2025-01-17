using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGameTests
{
    public class EnanoTests
    {
        MagoOscuro mago = new MagoOscuro("pepe");
        Enano enano = new Enano("rancio");
        
        IAtaque espada = Items.Espada;
        IDefensa escudo = Items.Escudo;
        
        [SetUp]
        public void Setup()
        {
            enano = new Enano("Thorin");
            mago = new MagoOscuro("Saruman");
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

            Assert.AreEqual(192, enano.VerVida());
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            enano.AgregarItemDefensa(Items.Escudo); 
            enano.RecibirAtaque(mago);

            Assert.AreEqual(197, enano.VerVida());
        }
    }
}
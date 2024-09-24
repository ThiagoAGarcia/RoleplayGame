using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGameTests
{
    public class EnanoTests
    {
        Mago mago = new Mago("pepe");
        Enano enano = new Enano("rancio");
        
        ItemAtaque espada = Items.Espada;
        ItemDefensa escudo = Items.Escudo;
        ItemAtaque arco = Items.Arco;
        ItemDefensa armadura = Items.Armadura;
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

            Assert.AreEqual(2, enano.ItemsCount);
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
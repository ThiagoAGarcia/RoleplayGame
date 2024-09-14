using NUnit.Framework;
using RoleplayGame;

namespace RoleplayGameTests
{
    public class ElfoTests
    {
        private Elfo elfo;
        private Item espada;
        private Item escudo;

        [SetUp]
        public void Setup()
        {
            elfo = new Elfo("Legolas");
            espada = Item.Espada;  
            escudo = Item.Escudo;  
        }

        [Test]
        public void TestInicializacionElfo()
        {
            Assert.AreEqual("Legolas", elfo.Nombre);
            Assert.AreEqual(200, elfo.Vida);
            Assert.AreEqual(20, elfo.Ataque);
            Assert.AreEqual(100, elfo.Mana);
        }

        [Test]
        public void TestCargarMana()
        {
            var resultado = elfo.CargarMana(50);
            Assert.AreEqual("Se cargo 50", resultado);
            Assert.AreEqual(150, elfo.Mana);

            resultado = elfo.CargarMana(200);
            Assert.AreEqual("No se puede cargar mas mana del que el personaje posee", resultado);
        }

        [Test]
        public void TestAgregarItem()
        {
            elfo.AgregarItem(espada);
            elfo.AgregarItem(escudo);
            Assert.AreEqual(2, elfo.Item.Count);
        }

        [Test]
        public void TestCurar()
        {
            elfo.Vida = 180;
            elfo.Curar(15);
            Assert.AreEqual(195, elfo.Vida);

            elfo.Curar(25);  
            Assert.AreEqual(195, elfo.Vida); 
        }

        [Test]
        public void TestValorAtaqueConItem()
        {
            elfo.AgregarItem(espada); 
            int valorAtaque = elfo.ValorAtaque();

            Assert.AreEqual(50, valorAtaque); 
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            elfo.RecibirAtaque(40, "Orco");
            Assert.AreEqual(160, elfo.Vida); 
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            elfo.AgregarItem(escudo);  
            elfo.RecibirAtaque(60, "Orco");

            Assert.AreEqual(190, elfo.Vida);
        }
    }
}
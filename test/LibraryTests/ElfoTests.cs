using RoleplayGame;

namespace RoleplayGameTests
{
    public class ElfoTests
    {
        Elfo _elfo = new Elfo("pepe");
        Enano enano = new Enano("rancio");
        
        ItemAtaque espada = Items.Espada;
        ItemDefensa escudo = Items.Escudo;
        ItemAtaque arco = Items.Arco;
        ItemDefensa armadura = Items.Armadura;

        [SetUp]
        public void Setup()
        {
            _elfo = new Elfo("Legolas");
           
            enano = new Enano("Gimli"); 
        }

        [Test]
        public void TestInicializacionElfo()
        {
            Assert.AreEqual("Legolas", _elfo.Nombre);
            Assert.AreEqual(200, Elfo.Vida);
            Assert.AreEqual(20, Elfo.Ataque);
            Assert.AreEqual(100, _elfo.Mana);
        }

        [Test]
        public void TestCargarMana()
        {
            var resultado = _elfo.CargarMana(50);
            Assert.AreEqual("Se cargo 50", resultado);
            Assert.AreEqual(150, _elfo.Mana);

            resultado = _elfo.CargarMana(200);
            Assert.AreEqual("No se puede cargar mas mana del que el personaje posee", resultado);
        }

        [Test]
        public void TestAgregarItem()
        {
            _elfo.AgregarItemAtaque(espada);
            _elfo.AgregarItemDefensa(escudo);
            Assert.AreEqual(2, _elfo.ItemsCount); 
        }

        [Test]
        public void TestCurar()
        {
            Elfo.Vida = 180;
            _elfo.Curar(15);
            Assert.AreEqual(195, Elfo.Vida);

            _elfo.Curar(25);  
            Assert.AreEqual(195, Elfo.Vida); 
        }

        [Test]
        public void TestValorAtaqueConItem()
        {
            _elfo.AgregarItemAtaque(espada); 
            int valorAtaque = _elfo.ValorAtaque();

            Assert.AreEqual(50, valorAtaque); 
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            _elfo.RecibirAtaque(enano);
            Assert.AreEqual(160, Elfo.Vida); 
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            _elfo.AgregarItemDefensa(escudo);  
            _elfo.RecibirAtaque(enano);

            Assert.AreEqual(190, Elfo.Vida);
        }
    }
}
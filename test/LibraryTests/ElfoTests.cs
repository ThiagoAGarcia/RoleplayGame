using RoleplayGame;

namespace RoleplayGameTests
{
    public class ElfoTests 
    {
        private Elfo elfo;
        private ItemAtaque espada;
        private ItemDefensa escudo;
        private Enano enano;
        
         espada = Items.Espada;  
                    escudo = Items.Escudo;  
        

        [SetUp]
        public void Setup()
        {
            elfo = new Elfo("Legolas");
           
            enano = new Enano("Gimli"); 
        }

        [Test]
        public void TestInicializacionElfo()
        {
            Assert.AreEqual("Legolas", elfo.Nombre);
            Assert.AreEqual(200, Elfo.Vida);
            Assert.AreEqual(20, Elfo.Ataque);
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
            elfo.AgregarItemAtaque(espada);
            elfo.AgregarItemDefensa(escudo);
            Assert.AreEqual(2, elfo.Items.Count); 
        }

        [Test]
        public void TestCurar()
        {
            Elfo.Vida = 180;
            elfo.Curar(15);
            Assert.AreEqual(195, Elfo.Vida);

            elfo.Curar(25);  
            Assert.AreEqual(195, Elfo.Vida); 
        }

        [Test]
        public void TestValorAtaqueConItem()
        {
            elfo.AgregarItemAtaque(espada); 
            int valorAtaque = elfo.ValorAtaque();

            Assert.AreEqual(50, valorAtaque); 
        }

        [Test]
        public void TestRecibirAtaqueSinDefensa()
        {
            elfo.RecibirAtaque(enano);
            Assert.AreEqual(160, Elfo.Vida); 
        }

        [Test]
        public void TestRecibirAtaqueConDefensa()
        {
            elfo.AgregarItemDefensa(escudo);  
            elfo.RecibirAtaque(enano);

            Assert.AreEqual(190, Elfo.Vida);
        }
    }
}
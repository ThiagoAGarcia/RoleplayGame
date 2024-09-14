using RoleplayGame;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class MagoTests
    {
        [Test]
        public void TestConstructor()
        {
            var mago = new Mago("MagoDeOz");
            Assert.AreEqual("MagoDeOz", mago.Nombre);
            Assert.AreEqual(150, mago.Vida);
            Assert.AreEqual(20, mago.Ataque);
        }

        [Test]
        public void TestAgregarHechizo()
        {
            var mago = new Mago("MagoDeOz");
            var hechizo = new Hechizo("Fuego", 30);
            mago.AgregarHechizo(hechizo);

            Assert.AreEqual(1, mago.Hechizos.Count);
            Assert.AreEqual(30, ((Hechizo)mago.Hechizos[0]).Ataque);
        }

        [Test]
        public void TestAgregarItem()
        {
            var mago = new Mago("MagoDeOz");
            var item = new Item("Varita", 10, 5);
            mago.AgregarItem(item);

            Assert.AreEqual(1, mago.Item.Count);
            Assert.AreEqual(10, ((Item)mago.Item[0]).Ataque);
        }

        [Test]
        public void TestValorAtaque()
        {
            var mago = new Mago("MagoDeOz");
            var hechizo = new Hechizo("Fuego", 30);
            var item = new Item("Varita", 10, 5);

            mago.AgregarHechizo(hechizo);
            mago.AgregarItem(item);

            Assert.AreEqual(60, mago.ValorAtaque());
        }

        [Test]
        public void TestRecibirAtaque()
        {
            var mago = new Mago("MagoDeOz");
            var item = new Item("Escudo", 0, 20);
            mago.AgregarItem(item);

            mago.RecibirAtaque(50, "Orco");

            Assert.AreEqual(150 - 50 + 20, mago.Vida); 
        }
    }
}
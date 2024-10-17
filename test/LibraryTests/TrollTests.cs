using RoleplayGame;
using NUnit.Framework;

namespace RoleplayGame.Tests
{
    [TestFixture]
    public class TrollTests
    {
        Troll troll = new Troll("Gartinch", false);
        Enano enano = new Enano("Enaneirho");
        
        IDefensa escudo = Items.Escudo;
        IAtaque paloGigante = Items.PaloGigante;

        [SetUp]
        public void Setup()
        {
            troll = troll;
            paloGigante = Items.PaloGigante;
            escudo = Items.Escudo;
            enano = enano;
        }

        [Test]
        public void TestConstructorTroll()
        {
            Assert.AreEqual("Gartinch", troll.Nombre);
            Assert.AreEqual(150, troll.Vida);
            Assert.AreEqual(15, troll.Ataque);
        }
        
        [Test]
        public void TestAgregarItem()
        {
            troll.AgregarItemAtaque(paloGigante);
            troll.AgregarItemDefensa(escudo);
            Assert.AreEqual(2, troll.ItemsCount);
        }

        [Test]
        public void TestValorAtaque()
        {
            troll.AgregarItemAtaque(paloGigante);
            int valorAtaque = troll.ValorAtaque();

            Assert.AreEqual(65, valorAtaque);
        }
    }
}
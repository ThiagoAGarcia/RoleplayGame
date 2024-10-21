using RoleplayGame;

namespace LibraryTests_;

public class EsqueletoTests
{
    Esqueleto _esqueleto = new Esqueleto("esqueleto");
    Enano enano = new Enano("brok");
    private Mago mago = new Mago("miguel");
    
    IAtaque espada = Items.Espada;
    IDefensa escudo = Items.Escudo;
    
    
    [SetUp]
    public void Setup()
    {
        _esqueleto = new Esqueleto("esqueleto");
        enano = new Enano("brok");
        mago = new Mago("miguel");
        espada = Items.Espada;
        escudo = Items.Escudo;
        mago.AgregarHechizo(Hechizo.BolaDeFuego);
        
    }

    [Test]
    public void TestConstructorEsqueletos()
    {
        Assert.AreEqual("esqueleto", _esqueleto.Nombre);
        Assert.AreEqual(100, _esqueleto.Vida);
        Assert.AreEqual(40, _esqueleto.Ataque);
        Assert.AreEqual(100, _esqueleto.vidaInicial);
        Assert.AreEqual(40, _esqueleto.ValorPV);
    }
    [Test]
    public void TestAgregarItem()
    {
        _esqueleto.AgregarItemAtaque(espada);
        _esqueleto.AgregarItemDefensa(escudo);
        Assert.AreEqual(2, _esqueleto.ItemsCount);
    }
    [Test]
    public void TestValorAtaque()
    {
        _esqueleto.AgregarItemAtaque(espada);
        int valorAtaque = _esqueleto.ValorAtaque();
        Assert.AreEqual(70, valorAtaque);
    }
    [Test]
    public void TestRecibirAtaque()
    {
        enano.AgregarItemAtaque(espada);
        enano.AgregarItemDefensa(escudo);
        _esqueleto.RecibirAtaque(enano);
        Assert.AreEqual(100, _esqueleto.Vida);
    }

    [Test]
    public void TestRecibirHechizos()
    {
        
        _esqueleto.RecibirHechizo(mago, Hechizo.BolaDeFuego);
        Assert.AreEqual(50, _esqueleto.Vida);
    }
}
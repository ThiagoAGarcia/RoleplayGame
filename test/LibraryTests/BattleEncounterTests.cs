using RoleplayGame;

namespace LibraryTests_;

public class BattleEncounterTests
{
    Enano enano = new Enano("enano");
    MagoOscuro mago_oscuro = new MagoOscuro("mago oscuro");
    Mago mago = new Mago("mago");
    Troll troll = new Troll("Troll", true);
    List<PersonajeHero> heroes = new List<PersonajeHero>();
    List<PersonajeEnemigo> enemigos = new List<PersonajeEnemigo>();
    BattleEncounter encuentro;
    IAtaque espada = Items.Espada;
    IDefensa escudo = Items.Escudo;
    IItemMagicoHero varita = Items.varita;
    IItemMagicoEnemigo grimorio = Items.grimorio;

    [SetUp]
    public void Setup()
    {
        heroes = new List<PersonajeHero>();
        enemigos = new List<PersonajeEnemigo>();
        heroes.Add(enano);
        heroes.Add(mago);
        enemigos.Add(mago_oscuro);
        enemigos.Add(troll);
        encuentro = new BattleEncounter(heroes, enemigos);
        espada = Items.Espada;
        escudo = Items.Escudo;
        varita = Items.varita;
        grimorio = Items.grimorio;
    }

    [Test]
    public void TestConstructorEncounter()
    {
        Assert.AreEqual(heroes, encuentro.Heroes);
        Assert.AreEqual(enemigos, encuentro.Enemigos);
    }

    [Test]
    public void TestDoEncounter()
    {
        // Configurar items y atributos iniciales
        enano.AgregarItemAtaque(espada);
        enano.AgregarItemDefensa(escudo);
        mago.AgregarItemMagico(varita);
        mago_oscuro.AgregarItemMagico(grimorio);


        // Ejecutar el encuentro
        encuentro.DoEncounter();

        // Verificar resultados esperados
        Assert.LessOrEqual(enano.Vida, 200);
        Assert.LessOrEqual(mago.Vida, 150);
        Assert.LessOrEqual(mago_oscuro.Vida, 190);
        Assert.LessOrEqual(troll.Vida, 150);
    }
}
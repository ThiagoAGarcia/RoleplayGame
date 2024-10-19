namespace RoleplayGame;

public interface IItemMagicoHero : IMagico
{
    string Nombre { get; set; }
    int Ataque { get; set; }

    bool EsMagico { get; set; }

    public void MejorarHechizos(IHechiceroHero personaje);
}
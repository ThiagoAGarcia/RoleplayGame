namespace RoleplayGame;

public interface IItemMagicoHero : IMagico
{
    string Nombre { get; set; }
    int Ataque { get; set; }

    public void MejorarHechizos(IHechiceroHero personaje);
}
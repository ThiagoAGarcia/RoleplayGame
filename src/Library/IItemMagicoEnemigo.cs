namespace RoleplayGame;

public interface IItemMagicoEnemigo : IMagico
{
    string Nombre { get; set; }
    int Ataque { get; set; }

    public void MejorarHechizos(IHechiceroEnemigo personaje);
}
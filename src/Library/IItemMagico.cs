namespace RoleplayGame;

public interface IItemMagico : IMagico
{
    string Nombre { get; set; }
    int Ataque { get; set; }

    public void MejorarHechizos(IHechicero personaje);
}
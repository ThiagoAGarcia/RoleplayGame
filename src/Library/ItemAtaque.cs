namespace RoleplayGame;

public class ItemAtaque : IAtaque
{
    public string Nombre { get; set; }
    public int Ataque { get; set; }

    public int ObtenerAtaque() => Ataque;
}

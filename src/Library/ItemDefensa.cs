namespace RoleplayGame;

public class ItemDefensa : IDefensa
{
    public string Nombre { get; set; }
    public int Defensa { get; set; }

    public int ObtenerDefensa()
    {
        return Defensa;
    }
}

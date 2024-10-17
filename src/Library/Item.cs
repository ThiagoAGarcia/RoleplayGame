namespace RoleplayGame;

public class Item : IAtaque, IDefensa, IItemMagico
{
    public string Nombre { get; set; }
    public int Ataque { get; set; }
    public int Defensa { get; set; }
    
    public void MejorarHechizos(IHechicero personaje)
    {
        personaje.subirAtaqueHechizos(Ataque);
        Console.WriteLine($"Se han buffeado los hechizos de {personaje.Nombre} en {Ataque} puntos de ataque");
        
    }

    public int ObtenerAtaque()
    {
        return Ataque;
    }
    
    public int ObtenerDefensa()
    {
        return Defensa;
    }
}

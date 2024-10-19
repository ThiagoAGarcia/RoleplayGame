namespace RoleplayGame;

public class Item : IAtaque, IDefensa, IItemMagicoHero, IItemMagicoEnemigo
{
    public string Nombre { get; set; }
    public int Ataque { get; set; }
    public int Defensa { get; set; }
    
    public bool EsMagico { get; set; }
    
    public void MejorarHechizos(IHechiceroHero personaje)
    {
        personaje.subirAtaqueHechizos(Ataque);
        Console.WriteLine($"Se han buffeado los hechizos de {personaje.Nombre} en {Ataque} puntos de ataque");
        
    }
    public void MejorarHechizos(IHechiceroEnemigo personaje)
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

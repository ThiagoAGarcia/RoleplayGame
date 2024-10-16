namespace RoleplayGame;

public class ItemMagico
{
    public string Nombre { get; set; }
    public int Ataque { get; set; }
    
    public void MejorarHechizos(IHechicero personaje)
    {
        personaje.subirAtaqueHechizos(Ataque);
    }
}
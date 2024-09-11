
namespace Personajes;

public class Enano
{
    private string name;

    public string Name
    {
        get { return name;}
        set { name = value; }
    }
    
    private int hp;

    private int attack;

    private int defense;

    public Enano(string name)
    {
        this.name = Name;
        this.hp = 120;
        this.attack = 40;
        this.defense = 10;
    }

    public int RecibirAtaque(int ataque)
    {
        hp = hp - (ataque - defense);
        Console.WriteLine("AAAAAH, Has atacado al enano");
        return hp;
    }

    public string ObtenerAtaque()
    {
        return $"El valor de ataque es de: {attack}";
    }
    
    public void EquiparItem()
}
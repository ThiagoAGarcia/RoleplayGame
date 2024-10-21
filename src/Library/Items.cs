namespace RoleplayGame;

// Ejemplos de objetos
public static class Items 
{
    public static IAtaque Espada { get; } = new Item { Nombre = "Espada", Ataque = 30, EsMagico = false };
    public static IDefensa Escudo { get; } = new Item { Nombre = "Escudo", Defensa = 5, EsMagico = false};
    public static IAtaque Arco { get; } = new Item { Nombre = "Arco", Ataque = 25, EsMagico = false};
    public static IDefensa Armadura { get; } = new Item { Nombre = "Armadura", Defensa = 4, EsMagico = false};
    public static IItemMagicoHero varita { get; } = new Item { Nombre = "Varita", Ataque = 50, EsMagico = true};

    public static IAtaque PaloGigante { get; } = new Item { Nombre = "Palo Gigante", Ataque = 25, EsMagico = false};
    
   
    public static IItemMagicoEnemigo grimorio { get; } = new Item { Nombre = "grimorio", Ataque = 100, EsMagico = true};
}
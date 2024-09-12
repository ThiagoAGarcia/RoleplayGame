namespace Program;

public class Items
{
    // Diccionarios para los items de ataque y defensa
    private Dictionary<string, int> attackItems;
    private Dictionary<string, int> defenseItems;

    // Constructor para inicializar los diccionarios
    public Items()
    {
        attackItems = new Dictionary<string, int>();
        defenseItems = new Dictionary<string, int>();

        // Agregar algunos items de ataque y defensa como ejemplo
        attackItems.Add("Espada", 50);
        attackItems.Add("Arco", 30);
        defenseItems.Add("Escudo", 40);
        defenseItems.Add("Armadura", 60);
    }

    // Método para obtener el valor de ataque de un item
    public int GetAttackValue(string itemName)
    {
        if (attackItems.ContainsKey(itemName))
        {
            return attackItems[itemName];
        }
        else
        {
            Console.WriteLine("El item de ataque no existe.");
            return 0;
        }
    }

    // Método para obtener el valor de defensa de un item
    public int GetDefenseValue(string itemName)
    {
        if (defenseItems.ContainsKey(itemName))
        {
            return defenseItems[itemName];
        }
        else
        {
            Console.WriteLine("El item de defensa no existe.");
            return 0;
        }
    }

    // Método para agregar un nuevo item de ataque
    public void AddAttackItem(string itemName, int attackValue)
    {
        if (!attackItems.ContainsKey(itemName))
        {
            attackItems.Add(itemName, attackValue);
            Console.WriteLine($"{itemName} ha sido añadido a los items de ataque.");
        }
        else
        {
            Console.WriteLine("El item de ataque ya existe.");
        }
    }

    // Método para agregar un nuevo item de defensa
    public void AddDefenseItem(string itemName, int defenseValue)
    {
        if (!defenseItems.ContainsKey(itemName))
        {
            defenseItems.Add(itemName, defenseValue);
            Console.WriteLine($"{itemName} ha sido añadido a los items de defensa.");
        }
        else
        {
            Console.WriteLine("El item de defensa ya existe.");
        }
    }
}


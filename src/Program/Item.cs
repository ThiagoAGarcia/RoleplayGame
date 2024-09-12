namespace RoleplayGame;

public class Item
{
    public string Nombre { get; set; }

    public int Valor { get; set; }

    public Item(string nombre, int valor)
    {
        this.Nombre = nombre;
        this.Valor = valor;
    }

}
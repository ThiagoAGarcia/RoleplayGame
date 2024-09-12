namespace RoleplayGame;

public class Enano
{
    public string Nombre { get; set; }
    
    public Array Items
    {
        get { return this.Items; }
        set { this.Items = value; }
    }
    public int Vida { get; set; }
    
    public int ValorAtaque (Item ataque)
    {
        int valor = 0;
        foreach (Item item in Items)
        {
            valor += item.Valor;
        }
        return valor;
    }
    
    public void RecibirAtaque(int ataque)
    {
        Vida -= ataque;
    }
}
using System.Collections;
namespace RoleplayGame;

public class Elfo
{
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }
    
    public ArrayList Hechizos { get; set; } = new ArrayList();
    
    public void AgregarHechizo(Hechizo hechizo)
    {
        Hechizos.Add(hechizo); // Agregar el objeto completo Hechizo
    }

    public void curar(int curar)
    {
        Vida += curar;
    }

    public int ValorAtaque()
    {
        int valor = Ataque;
        foreach (Hechizo item in Hechizos)
        {
            valor += item.Ataque;
        }
        return valor;
    }

    public void RecibirAtaque(int ataque)
    {
        Vida -= ataque;
    }
}
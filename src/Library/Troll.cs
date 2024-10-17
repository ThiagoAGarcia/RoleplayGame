using System.Reflection.PortableExecutable;
using Microsoft.VisualBasic;

namespace RoleplayGame;

public class Troll : Personaje
{
    private bool EsGigante;
    
    public Troll(string nombre, bool esGigante)
    {
        this.Nombre = nombre;
        vidaInicial = 150;
        Vida = 150;
        Ataque = 15;
        this.EsGigante = esGigante;
    }

    private void Gigante()
    {
        if (EsGigante == true)
        {
            Ataque += 10;
            Vida -= 30;
            Nombre += "Gigante";
        }
    }
}
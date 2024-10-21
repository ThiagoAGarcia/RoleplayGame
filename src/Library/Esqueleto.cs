namespace RoleplayGame;

public class Esqueleto : PersonajeEnemigo
{
   
    
    public Esqueleto(string nombre)
    {
        Nombre = nombre;
        Vida = 100;
        Ataque = 40;
        vidaInicial = 100;
        ValorPV = 40;
    }

    //Este recibir un ataque tiene un problema lo veremos despues en clase.
    public override void RecibirAtaque(IPersonajeHero ataque)
    {
        Vida -= 0;
    }
   
    
    
    
}
namespace RoleplayGame;

public class Esqueleto : PersonajeEnemigo
{
   
    
    public Esqueleto(string nombre)
    {
        Nombre = nombre;
        Vida = 100;
        Ataque = 10;
        vidaInicial = 100;
        ValorPV = 30;
    }

    
    public override void RecibirAtaque(IPersonajeHero ataque)
    {
        int defensaTotal = 0;
            
        foreach (var item in items_defensa)
        {
            if (item is IDefensa itemDefensa)
            {
                defensaTotal += itemDefensa.Defensa;
            }
        }
        
        foreach(var item  in ataque.ItemsAtaque)
        {
            if(item is IItemMagicoHero itemMagico)
            {
                ;int danioRecibido = Math.Max(0, ataque.ValorAtaque() - defensaTotal);
                Vida -= danioRecibido;
                
                Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño de {ataque.Nombre}. Vida actual: {Vida}.");
            }
            else
            {
                Console.WriteLine("Esqueleto solo recibe daño de ataques magicos");
            }
        }
       
         
      
       
        if (VerEstado() == true)
        {
            ataque.ConseguirPV(ValorPV);
            Console.WriteLine($"{Nombre} ha muerto y ha otorgado {ValorPV} puntos de vida a {ataque.Nombre}");
        } 

        
    }
   
    
    
    
}
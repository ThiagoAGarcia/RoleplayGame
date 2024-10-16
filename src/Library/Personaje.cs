namespace RoleplayGame;
using System;
using System.Collections;

public class Personaje
{
    public string Nombre { get; set; }
        public static int Vida;
        public static int Ataque;
       

        public int vidaInicial;
        
        private ArrayList items = new ArrayList();
        
        public int VerVida()
        {
            return Vida;
        }
        public int VerAtaque()
        {
            return Ataque;
        }
        public int ItemsCount
        {
            get { return items.Count; }
        }
        
        public int ValorAtaque()
        {
            int valor = Ataque;
            
            foreach (var item in items)
            {
                if (item is ItemAtaque itemAtaque)
                {
                    valor += itemAtaque.Ataque;
                }
            }

            return valor;
        }
        public void RecibirHechizo(IHechicero hechiceroAtacante, Hechizo hechizo)
        {
            hechiceroAtacante.ValorAtaqueHechizos(hechizo);
            int defensaTotal = 0;
            foreach (var item in items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }
            
            if (hechiceroAtacante.Mana >= hechizo.GastoMana)
            {
                hechiceroAtacante.Mana -= hechizo.GastoMana;
                
                int danioRecibido = Math.Max(0, hechizo.Ataque - defensaTotal);
                Vida -= danioRecibido;

                Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño del hechizo {hechizo.Nombre} de {hechiceroAtacante.Nombre}. Vida actual: {Vida}.");
            }
            else
            {
                Console.WriteLine($"{hechiceroAtacante.Nombre} intentó usar el hechizo {hechizo.Nombre}, pero no tiene suficiente mana.");
            }
        }

        public void RecibirAtaque(IPersonaje ataque)
        {
            int defensaTotal = 0;
            
            foreach (var item in items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }
            
            int danioRecibido = Math.Max(0, ataque.ValorAtaque() - defensaTotal);
            Vida -= danioRecibido;

            Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño de {ataque.Nombre}. Vida actual: {Vida}.");
        }
        
        public void AgregarItemAtaque(ItemAtaque item)
        {
            items.Add(item);
        }

        public void AgregarItemDefensa(ItemDefensa item2)
        {
            items.Add(item2);
        }
}
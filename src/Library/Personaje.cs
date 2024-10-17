namespace RoleplayGame;
using System;
using System.Collections;

public class Personaje : IPersonaje
{
    public string Nombre { get; set; }
        public static int Vida;
        public static int Ataque;
        
        public int vidaInicial;
        
      
        
        private List<ItemAtaque> items_ataque = new List<ItemAtaque>();
        private List<ItemDefensa> items_defensa = new List<ItemDefensa>();
        public int VerVidaInicial()
        {
            return vidaInicial;
        }
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
            get { return items_ataque.Count() + items_defensa.Count(); }
        }

        public void CambiarVida(int vida)
        {
            Vida = vida;
        }

        public int ValorAtaque()
        {
            int valor = Ataque;
            
            foreach (var item in items_ataque)
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
            foreach (var item in items_defensa)
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
            
            foreach (var item in items_defensa)
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
            items_ataque.Add(item);
        }

        public void AgregarItemDefensa(ItemDefensa item2)
        {
            items_defensa.Add(item2);
        }
}
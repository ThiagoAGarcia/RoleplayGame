using System;
using System.Collections;

namespace RoleplayGame
{
    public class Enano : IPersonaje
    {
        private IPersonaje _personajeImplementation;
        public string Nombre { get; set; }
        private ArrayList items { get; set; } = new ArrayList();
        public int Vida { get; set; }
        
        public int Ataque { get; set; }
        
        public Enano(string nombre)
        {
            Nombre = nombre;
            Vida = 250;
            Ataque = 50;
        }
        public void AgregarItemAtaque(ItemAtaque item)
        {
            items.Add(item);
        }
        public void AgregarItemDefensa(ItemDefensa item2)
        {
            items.Add(item2);
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
            int defensaTotal = 0;
    
            // Calcular la defensa total del personaje basado en sus ítems de defensa
            foreach (var item in items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }

            // Verificar si el hechicero tiene suficiente mana para lanzar el hechizo
            if (hechiceroAtacante.Mana >= hechizo.GastoMana)
            {
                hechiceroAtacante.Mana -= hechizo.GastoMana;
        
                // Calcular el daño del hechizo restando la defensa
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

    }
}
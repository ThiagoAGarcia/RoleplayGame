using System;
using System.Collections;

namespace RoleplayGame
{
    public class Mago
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public ArrayList Hechizos { get; set; } = new ArrayList();
        
        public ArrayList Item { get; set; } = new ArrayList();

        public Mago(string nombre)
        {
            Nombre = nombre;
            Vida = 150;
            Ataque = 20;
        }
        
        public void AgregarHechizo(Hechizo hechizo)
        {
            Hechizos.Add(hechizo);
        }
        public void AgregarItem(Item item)
        {
            Item.Add(item);
        }
        

        public int ValorAtaque()
        {
            int valor = Ataque;
            foreach (Hechizo item in Hechizos)
            {
                valor += item.Ataque;
            }
            foreach (Item item in Item)
            {
                valor += item.Ataque;
            }
            return valor;
        }

        public void RecibirAtaque(int ataque, string atacante)
        {
            int vida = Vida;
            foreach (Item item in Item)
            {
                vida += item.Defensa;
            }
            
            Vida -= ataque;
            Console.WriteLine($"{Nombre} recibió {ataque} puntos de daño de {atacante}. Vida actual: {Vida}.");
        }
    }
}
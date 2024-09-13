using System;
using System.Collections;

namespace RoleplayGame
{
    public class Enano
    {
        public string Nombre { get; set; }
        public ArrayList Item { get; set; } = new ArrayList();
        public int Vida { get; set; }
        
        public int Ataque { get; set; }
        
        public Enano(string nombre)
        {
            Nombre = nombre;
            Vida = 250;
            Ataque = 50;
        }
        public void AgregarItem(Item item)
        {
            Item.Add(item);
        }

        public int ValorAtaque()
        {
            int valor = Ataque;
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
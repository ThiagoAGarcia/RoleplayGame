using System;
using System.Collections;

namespace RoleplayGame
{
    public class Enano : IPersonaje
    {
        private IPersonaje _personajeImplementation;
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
        public void AgregarItem(ItemAtaque item, ItemDefensa item2)
        {
            Item.Add(item);
            Item.Add(item2);
        }

        public int ValorAtaque()
        {
            int valor = Ataque;
            foreach (ItemAtaque item in Item)
            {
                valor += item.Ataque;
            }
            return valor;
        }

        public void RecibirAtaque(int ataque, string atacante)
        {
            int vida = Vida;
            foreach (ItemDefensa item in Item)
            {
                vida += item.Defensa;
            }
            
            Vida -= ataque;
            Console.WriteLine($"{Nombre} recibió {ataque} puntos de daño de {atacante}. Vida actual: {Vida}.");
        }
    }
}
using System;
using System.Collections;

namespace RoleplayGame
{
    public class Enano
    {
        public string Nombre { get; set; }
        public ArrayList Items { get; set; } = new ArrayList();
        public int Vida { get; set; }
        
        public int Ataque { get; set; }
        
        public Enano(string nombre)
        {
            Nombre = nombre;
            Vida = 150;
            Ataque = 20;
        }
        public void AgregarItem(Item item)
        {
            Items.Add(item);
        }

        public int ValorAtaque()
        {
            int valor = Ataque;
            foreach (Item item in Items)
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
}
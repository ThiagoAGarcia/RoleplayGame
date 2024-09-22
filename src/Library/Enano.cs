using System;
using System.Collections;

namespace RoleplayGame
{
    public class Enano : IPersonaje
    {
        private IPersonaje _personajeImplementation;
        public string Nombre { get; set; }
        public ArrayList Items { get; set; } = new ArrayList();
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
            Items.Add(item);
        }
        public void AgregarItemDefensa(ItemDefensa item2)
        {
            Items.Add(item2);
        }


        public int ValorAtaque()
        {
            int valor = Ataque;
            
            foreach (var item in Items)
            {
                if (item is ItemAtaque itemAtaque)
                {
                    valor += itemAtaque.Ataque;
                }
            }

            return valor;
        }


        public void RecibirAtaque(int ataque, string atacante)
        {
            int defensaTotal = 0;
            
            foreach (var item in Items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }
            
            int danioRecibido = Math.Max(0, ataque - defensaTotal);
            Vida -= danioRecibido;

            Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño de {atacante}. Vida actual: {Vida}.");
        }

    }
}
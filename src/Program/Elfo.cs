using System;
using System.Collections;

namespace RoleplayGame
{
    public class Elfo
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }

        public int vida_inicial; // No inicializar directamente aquí

        public ArrayList Hechizos { get; set; } = new ArrayList();
        public ArrayList Item { get; set; } = new ArrayList();
        
        // Constructor para inicializar vida_inicial
        public Elfo(string nombre)
        {
            Nombre = nombre;
            Vida = 200;
            Ataque = 20;
            vida_inicial = 200;
        }

        public void AgregarHechizo(Hechizo hechizo)
        {
            Hechizos.Add(hechizo);
        }
        public void AgregarItem(Item item)
        {
            Item.Add(item);
        }

        public void Curar(int curar)
        {
            if ((Vida + curar) > vida_inicial)
            {
                Console.WriteLine($"{Nombre} intentó curarse, pero no puede curarse más de su vida base.");
            }
            else
            {
                Vida += curar;
                Console.WriteLine($"{Nombre} se curó {curar} puntos de vida. Vida actual: {Vida}/{vida_inicial}.");
            }
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
            Vida -= ataque;
            Console.WriteLine($"{Nombre} recibió {ataque} puntos de daño de {atacante}. Vida actual: {Vida}.");
        }
    }
}
using System;
using System.Collections;

namespace RoleplayGame
{
    public class Elfo
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        
        public int Mana { get; set; }

        public int vidaInicial;
        
        public int ManaInicial;

        public ArrayList Hechizos { get; set; } = new ArrayList();
        public ArrayList Item { get; set; } = new ArrayList();
        
        // Constructor para inicializar vida_inicial
        public Elfo(string nombre)
        {
            Nombre = nombre;
            Vida = 200;
            Ataque = 20;
            vidaInicial = 200;
            Mana = 100;
            ManaInicial = 100;
        }

        public string CargarMana(int mana)
        {
            if (mana > ManaInicial)
            {
                return("No se puede cargar mas mana del que el personaje posee");
            }
            else
            {
                Mana += mana;
                return ($"Se cargo {mana}");
            }
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
            if ((Vida + curar) > vidaInicial || curar > 20)
            {
                Console.WriteLine($"{Nombre} intentó curarse, pero no puede curarse más de su vida base o mas de 20 puntos de vida por turno.");
            }
            else
            {
                Vida += curar;
                Console.WriteLine($"{Nombre} se curó {curar} puntos de vida. Vida actual: {Vida}/{vidaInicial}.");
            }
        }

        public int ValorAtaque(Hechizo hechizo = null)
        {
            int valor = Ataque;
            
            if (hechizo != null)
            {
                if (Mana >= hechizo.GastoMana)
                {
                    Mana -= hechizo.GastoMana;
                    valor += hechizo.Ataque;
                }
                else
                {
                    Console.WriteLine($"{Nombre} no tiene suficiente mana para usar el hechizo {hechizo.Nombre}.");
                }
            }
            else
            {
                foreach (Item i in Item)
                {
                    valor += i.Ataque;
                }
               
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
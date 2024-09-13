using System;
using System.Collections;

namespace RoleplayGame
{
    public class Mago
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        
        public int Mana { get; set; }

        public int ManaInicial;
        public ArrayList Hechizos { get; set; } = new ArrayList();
        
        public ArrayList Item { get; set; } = new ArrayList();

        public Mago(string nombre)
        {
            Nombre = nombre;
            Vida = 150;
            Ataque = 20;
            Mana = 100;
            ManaInicial = 100;
        }
        
        public void AgregarHechizo(Hechizo hechizo)
        {
            Hechizos.Add(hechizo);
        }
        public void AgregarItem(Item item)
        {
            Item.Add(item);
        }
        
        public void Estudiar(int increment)
        {
            ManaInicial += increment;
        }


        public int ValorAtaque(Hechizo hechizo = null, Item item = null)
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

            if (item != null)
            {
                
                foreach (Item i in Item)
                {
                    valor += i.Ataque;
                }
            
            }
            return valor;
        }

        public string CargarMana(int mana)
        {
            if (mana > ManaInicial)
            {
                return ("No se puede cargar mas mana del que el personaje posee");
            }
            else
            {
                Mana += mana;
                return ($"Se cargo {mana}");
            }
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
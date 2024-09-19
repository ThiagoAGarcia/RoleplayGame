using System;
using System.Collections;

namespace RoleplayGame
{
    public class Mago : IPersonaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        
        public int Mana { get; set; }

        public int vidaInicial;
        
        public int ManaInicial;

        public ArrayList Hechizos { get; set; } = new ArrayList();
        public ArrayList Item { get; set; } = new ArrayList();
        
        
        public Mago(string nombre)
        {
            Nombre = nombre;
            Vida = 150;
            Ataque = 10;
            vidaInicial = 150;
            Mana = 150;
            ManaInicial = 150;
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

        public void AgregarItem(ItemAtaque item, ItemDefensa item2)
        {
            Item.Add(item);
            Item.Add(item2);
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
                foreach (ItemAtaque i in Item)
                {
                    valor += i.Ataque;
                }
               
            }
            return valor;
        }

        public int ValorAtaque()
        {
            return ValorAtaque(null);
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

        public void Estudiar(int estudio)
        {
            if (estudio > ManaInicial)
            {
                Console.WriteLine("No se puede estudiar mas de lo que el personaje posee");
            }
            else
            {
                Mana += estudio;
                Console.WriteLine($"Se estudio {estudio}");
            }
        }
    }
}
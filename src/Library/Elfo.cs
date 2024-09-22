using System;
using System.Collections;

namespace RoleplayGame
{
    public class Elfo : IPersonaje, IElfo
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        
        public int Mana { get; set; }

        public int vidaInicial;
        
        public int ManaInicial;

        public ArrayList Hechizos { get; set; } = new ArrayList();
        public ArrayList Items { get; set; } = new ArrayList();
        
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

        public void AgregarItemAtaque(ItemAtaque item)
        {
            Items.Add(item);
        }
        public void AgregarItemDefensa(ItemDefensa item2)
        {
            Items.Add(item2);
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
                foreach (ItemAtaque i in Items)
                {
                    valor += i.Ataque;
                }
               
            }
            return valor;
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
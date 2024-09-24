using System;
using System.Collections;

namespace RoleplayGame
{
    public class Mago : IPersonaje, IHechicero
    {
        public string Nombre { get; set; }
        public static int Vida;
        public static int Ataque;

        public int Mana { get; set; }

        public int vidaInicial;
        
        public int ManaInicial;

        private ArrayList hechizos = new ArrayList();
        private ArrayList items = new ArrayList();
        
        
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
            hechizos.Add(hechizo);
        }
        public void AgregarItemAtaque(ItemAtaque item)
        {
            items.Add(item);
        }
        public void AgregarItemDefensa(ItemDefensa item2)
        {
            items.Add(item2);
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

        public int ValorAtaqueHechizos(Hechizo hechizo = null)
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
            
            return valor;
        }

        public int ValorAtaque()
        {
            int valor = Ataque;
            
            foreach (var item in items)
            {
                if (item is ItemAtaque itemAtaque)
                {
                    valor += itemAtaque.Ataque;
                }
            }

            return valor;
        }


        public void RecibirAtaque(IPersonaje ataque)
        {
            int defensaTotal = 0;
            
            foreach (var item in items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }
            
            
            int danioRecibido = Math.Max(0, ataque.ValorAtaque() - defensaTotal);
            Vida -= danioRecibido;

            Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño de {ataque.Nombre}. Vida actual: {Vida}.");
        }
        
        public void RecibirHechizo(IHechicero hechiceroAtacante, Hechizo hechizo)
        {
            int defensaTotal = 0;
    
            // Calcular la defensa total del personaje basado en sus ítems de defensa
            foreach (var item in items)
            {
                if (item is ItemDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }

            // Verificar si el hechicero tiene suficiente mana para lanzar el hechizo
            if (hechiceroAtacante.Mana >= hechizo.GastoMana)
            {
                hechiceroAtacante.Mana -= hechizo.GastoMana;
        
                // Calcular el daño del hechizo restando la defensa
                int danioRecibido = Math.Max(0, hechizo.Ataque - defensaTotal);
                Vida -= danioRecibido;

                Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño del hechizo {hechizo.Nombre} de {hechiceroAtacante.Nombre}. Vida actual: {Vida}.");
            }
            else
            {
                Console.WriteLine($"{hechiceroAtacante.Nombre} intentó usar el hechizo {hechizo.Nombre}, pero no tiene suficiente mana.");
            }
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
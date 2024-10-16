using System;
using System.Collections;

namespace RoleplayGame
{
    public class Mago : Personaje,IPersonaje, IHechicero
    {
        

        public int Mana { get; set; }
        
        public int ManaInicial;

        private ArrayList hechizos = new ArrayList();
        
        public int HechizosCount
        {
            get { return hechizos.Count; }
        }
        
        
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
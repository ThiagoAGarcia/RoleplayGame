using System;
using System.Collections;

namespace RoleplayGame
{
    public class Mago : Personaje, IHechicero
    {
        

        public int Mana { get; set; }
        
        public int ManaInicial;
        
        private List<IItemMagico> itemsMagicos = new List<IItemMagico>();

        private List<Hechizo> hechizos = new List<Hechizo>();
        
        public int HechizosCount
        {
            get { return hechizos.Count; }
        }
        public void ListarHechizos()
        {
            for (int i = 0; i < hechizos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {hechizos[i].Nombre}");
            }
        }

        
        public object VerHechizo(int indice)
        {
            return hechizos[indice];
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

        public void AgregarItemMagico(IItemMagico itemMagico)
        {
            itemsMagicos.Add(itemMagico);
        }
        
        public int ValorAtaqueHechizos(Hechizo hechizo = null)
        {
            int valor = Ataque;
            foreach (var items in itemsMagicos)
            {
                items.MejorarHechizos(this);
            }
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

        public void subirAtaqueHechizos(int ataque){
            foreach (var hechizos in hechizos)
            {
                hechizos.Ataque += ataque;
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
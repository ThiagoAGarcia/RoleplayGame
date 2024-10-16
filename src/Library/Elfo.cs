using System;
using System.Collections;

namespace RoleplayGame
{

    public class Elfo : Personaje, ICurador, IHechicero
    {
    public int Mana { get; set; }
    public int ManaInicial;

    private List<Hechizo> hechizos = new List<Hechizo>();
    
    private List<ItemMagico> itemsMagicos = new List<ItemMagico>();

    public int HechizosCount
    {
        get { return hechizos.Count; }
    }

        public List<Hechizo> Hechizos
        {
            get { return hechizos; }
        }
        public Elfo(string nombre)
        {
            Nombre = nombre;
            Vida = 200;
            Ataque = 20;
            vidaInicial = 200;
            Mana = 100;
            ManaInicial = 100;
        }
        public void subirAtaqueHechizos(int ataque){
            foreach (var Hechizos in hechizos)
            {
                Hechizos.Ataque += ataque;
            }
            
        }
        
        public string CargarMana(int mana)
        {
            if (Mana + mana > ManaInicial)
            {
                return ("No se puede cargar mas mana del que el personaje posee");
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
        
        public void AgregarItemMagico(ItemMagico itemMagico)
        {
            itemsMagicos.Add(itemMagico);
        }

        public void Curar(int curar)
        {
            if ((Vida + curar) > vidaInicial || curar > 20)
            {
                Console.WriteLine(
                    $"{Nombre} intentó curarse, pero no puede curarse más de su vida base o mas de 20 puntos de vida por turno.");
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
    }
}
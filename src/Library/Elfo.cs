using System;
using System.Collections;

namespace RoleplayGame
{

    public class Elfo : PersonajeHero, ICurador
    {
    public int Mana { get; set; }
    public int ManaInicial;

    private List<Hechizo> hechizos = new List<Hechizo>();
    
    private List<IItemMagicoHero> itemsMagicos = new List<IItemMagicoHero>();

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
            PV = 0;
        }
        public void ListarHechizos()
        {
            for (int i = 0; i < hechizos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {hechizos[i].Nombre}");
            }
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
        
        public void AgregarItemMagico(IItemMagicoHero itemMagicoHero)
        {
            itemsMagicos.Add(itemMagicoHero);
        }

        public void Curar(int curar, IPersonajeHero Curado)
        {
            if ((Curado.VerVida() + curar) > Curado.VerVidaInicial() || curar > 20)
            {
                Console.WriteLine(
                    $"{Nombre} intentó curar a {Curado.Nombre}, pero no puede curar más de su vida base o mas de 20 puntos de vida por turno.");
            }
            else
            {
                Curado.CambiarVida(VerVida() + curar);
                Console.WriteLine($"{Nombre} curó a {Curado.Nombre} en {curar} puntos de vida. Vida actual: {Curado.VerVida()}/{Curado.VerVidaInicial()}.");
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
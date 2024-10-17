using System.Collections;
namespace RoleplayGame
{
    public interface IHechicero : IPersonaje
    {
        string Nombre {get; set; }
        int Mana { get; set; }
        void AgregarItemMagico(IItemMagico itemMagico);
        void AgregarHechizo(Hechizo hechizo);
        int ValorAtaqueHechizos(Hechizo hechizo);
        
        void subirAtaqueHechizos(int ataque);

        public void ListarHechizos();
    }
}
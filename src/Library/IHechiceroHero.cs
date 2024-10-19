using System.Collections;
namespace RoleplayGame
{
    public interface IHechiceroHero : IPersonajeHero
    {
        string Nombre {get; set; }
        int Mana { get; set; }
        void AgregarItemMagico(IItemMagicoHero itemMagicoHero);
        void AgregarHechizo(Hechizo hechizo);
        int ValorAtaqueHechizos(Hechizo hechizo);
        
        void subirAtaqueHechizos(int ataque);

        public void ListarHechizos();
    }
}
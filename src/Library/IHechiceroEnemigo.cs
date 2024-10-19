using System.Collections;
namespace RoleplayGame
{
    public interface IHechiceroEnemigo : IPersonajeEnemigo
    {
        string Nombre {get; set; }
        int Mana { get; set; }
        void AgregarItemMagico(IItemMagicoEnemigo itemMagicoHero);
        void AgregarHechizo(Hechizo hechizo);
        int ValorAtaqueHechizos(Hechizo hechizo);
        
        void subirAtaqueHechizos(int ataque);

        public void ListarHechizos();
    }
}
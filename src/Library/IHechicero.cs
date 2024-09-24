using System.Collections;
namespace RoleplayGame
{
    public interface IHechicero
    {
        string Nombre {get; set; }
        int Mana { get; set; }
        void AgregarHechizo(Hechizo hechizo);
        int ValorAtaqueHechizos(Hechizo hechizo);
    }
}
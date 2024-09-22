using System.Collections;
namespace RoleplayGame
{
    public interface IHechicero
    {
        ArrayList Hechizos { get; set; }
        void AgregarHechizo(Hechizo hechizo);
        int ValorAtaque(Hechizo hechizo);
    }
}
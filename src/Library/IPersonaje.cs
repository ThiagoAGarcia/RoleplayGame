using System;

namespace RoleplayGame
{
    public interface IPersonaje
    {
        string Nombre { get; set; }
        static int Vida;
        static int Ataque;

        void AgregarItemAtaque(ItemAtaque item);
        
        void AgregarItemDefensa(ItemDefensa item);
        
        int ValorAtaque();
        void RecibirAtaque(IPersonaje ataque);

        void RecibirHechizo(IHechicero hechiceroAtacante, Hechizo hechizo);
    }
}
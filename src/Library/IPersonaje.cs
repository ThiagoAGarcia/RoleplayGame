using System;

namespace RoleplayGame
{
    public interface IPersonaje
    {
        string Nombre { get; set; }
        int Vida { get; set; }
        int Ataque { get; set; }

        void AgregarItemAtaque(ItemAtaque item);
        
        void AgregarItemDefensa(ItemDefensa item);
        
        int ValorAtaque();
        void RecibirAtaque(int ataque, string atacante);
    }
}
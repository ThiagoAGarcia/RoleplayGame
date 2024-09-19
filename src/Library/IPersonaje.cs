using System;

namespace RoleplayGame
{
    public interface IPersonaje
    {
        string Nombre { get; set; }
        int Vida { get; set; }
        int Ataque { get; set; }

        void AgregarItem(ItemAtaque item, ItemDefensa item2);
        int ValorAtaque();
        void RecibirAtaque(int ataque, string atacante);
    }
}
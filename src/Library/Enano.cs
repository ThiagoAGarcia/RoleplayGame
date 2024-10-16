using System;
using System.Collections;

namespace RoleplayGame
{
    public class Enano : Personaje, IPersonaje
    {
        public Enano(string nombre)
        {
            Nombre = nombre;
            Vida = 200;
            Ataque = 30;
            vidaInicial = 200;
        }
    }
}
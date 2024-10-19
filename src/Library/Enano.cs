using System;
using System.Collections;

namespace RoleplayGame
{
    public class Enano : PersonajeHero
    {
        public Enano(string nombre)
        {
            Nombre = nombre;
            Vida = 200;
            Ataque = 30;
            vidaInicial = 200;
            PV = 0;
        }
    }
}
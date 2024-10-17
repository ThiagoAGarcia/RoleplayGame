﻿namespace RoleplayGame
{
    using System;

    public class Dragon : Personaje
    {
        public AtaquesDragon Ataques { get; set; }

        public Dragon(string nombre, int vidaInicial, int ataque, AtaquesDragon ataques)
        {
            this.Nombre = nombre;
            CambiarVida(vidaInicial);
            Ataque = ataque;
            this.Ataques = ataques;
        }
        
        public void UsarAtaqueFuego(IPersonaje objetivo)
        {
            Ataques.AtacarConFuego(objetivo, this);
        }

        public void UsarAtaqueCola(IPersonaje objetivo)
        {
            Ataques.AtacarConCola(objetivo, this);
        }
    }
}
﻿using System;
using System.Collections;

namespace RoleplayGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Elf with the proper constructor
            Elfo elfo = new Elfo("Galadriel", 100, 10);

            // Create some Items
            Item espada = new Item("Espada", 5);
            Item escudo = new Item("Escudo", 3);
            Hechizo rayo = new Hechizo
            {
                Nombre = "Rayo",
                Ataque = 20
            };

            Hechizo viento = new Hechizo
            {
                Nombre = "Viento",
                Ataque = 12
            };

            // Add Hechizos to Elf
            elfo.AgregarHechizo(rayo);
            elfo.AgregarHechizo(viento);

            // Create a Hechizo
            Hechizo fuego = new Hechizo
            {
                Nombre = "Fuego",
                Ataque = 15
            };

            // Add Hechizo to Elf
            elfo.AgregarHechizo(fuego);

            // Create a Dwarf
            Enano enano = new Enano
            {
                Nombre = "Thorin",
                Vida = 120,
                Ataque = 12
            };

            // Create some Items
            Item hacha = new Item("Hacha", 7);
            Item armadura = new Item("Armadura", 4);

            // Add Items to Dwarf
            enano.AgregarItem(hacha);
            enano.AgregarItem(armadura);

            // Create a Wizard
            Mago mago = new Mago
            {
                Nombre = "Gandalf",
                Vida = 80,
                Ataque = 18
            };

            // Add Hechizos to Wizard
            mago.AgregarHechizo(rayo);
            mago.AgregarHechizo(viento);

            // Elf heals
            elfo.Curar(20);
            Console.WriteLine($"Elfo vida: {elfo.Vida}");

            // Wizard attacks Elf
            elfo.RecibirAtaque(mago.ValorAtaque(), mago.Nombre);
            Console.WriteLine($"Elfo vida: {elfo.Vida}");
            
            elfo.Curar(20);
            Console.WriteLine($"Elfo vida: {elfo.Vida}");
        }
    }
}

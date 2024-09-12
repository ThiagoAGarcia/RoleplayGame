using System;
using System.Collections;

namespace RoleplayGame;

public class Elfo
{
    public string Nombre { get; set; }
    public int Vida { get; set; }
    public int Ataque { get; set; }

    public int vida_inicial; // No inicializar directamente aquí

    public ArrayList Hechizos { get; set; } = new ArrayList();
    
    // Constructor para inicializar vida_inicial
    public Elfo(string nombre, int vida, int ataque)
    {
        Nombre = nombre;
        Vida = vida;
        Ataque = ataque;
        vida_inicial = vida; // Inicializar vida_inicial con el valor correcto
    }

    public void AgregarHechizo(Hechizo hechizo)
    {
        Hechizos.Add(hechizo);
    }

    public void curar(int curar)
    {
        if (Vida + curar > vida_inicial)
        {
            Console.WriteLine("Error: no puede curarse más de su vida base.");
        }
        else
        {
            Vida += curar;
        }
    }

    public int ValorAtaque()
    {
        int valor = Ataque;
        foreach (Hechizo item in Hechizos)
        {
            valor += item.Ataque;
        }
        return valor;
    }

    public void RecibirAtaque(int ataque)
    {
        Vida -= ataque;
    }
}
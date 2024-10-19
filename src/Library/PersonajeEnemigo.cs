﻿namespace RoleplayGame;

public class PersonajeEnemigo : IPersonajeEnemigo
{
    public string Nombre { get; set; }
        public int Vida;
        public int Ataque;

        public int ValorPV;

        public bool Muerto;
        
        public void ComprobarEstado()
        {
            if(Vida <= 0)
            {
                Muerto = true;
            }
        }

        public bool VerEstado()
        {
            return Muerto;
        }

        public int vidaInicial;
        
        private List<IAtaque> items_ataque = new List<IAtaque>();
        private List<IDefensa> items_defensa = new List<IDefensa>();
        
        public int VerVidaInicial()
        {
            return vidaInicial;
        }
        
        public int ObtenerPv()
        {
            return ValorPV;
        }
        public int VerVida()
        {
            return Vida;
        }
        
        public void CambiarVida(int vida)
        {
            Vida = vida;
            
        }
        public int VerAtaque()
        {
            return Ataque;
        }
        public int ItemsCount
        {
            get { return items_ataque.Count() + items_defensa.Count(); }
        }
        
        public int ValorAtaque()
        {
            int valor = Ataque;
            
            foreach (var item in items_ataque)
            {
                if (item is IAtaque itemAtaque)
                {
                    valor += itemAtaque.ObtenerAtaque();
                }
            }

            return valor;
        }
        public void RecibirHechizo(IHechiceroHero atacante, Hechizo hechizo)
        {
            atacante.ValorAtaqueHechizos(hechizo);
            int defensaTotal = 0;
            foreach (var item in items_defensa)
            {
                if (item is IDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }
            
            if (atacante.Mana >= hechizo.GastoMana)
            {
                atacante.Mana -= hechizo.GastoMana;
                
                int danioRecibido = Math.Max(0, hechizo.Ataque - defensaTotal);
                Vida -= danioRecibido;
                
                ComprobarEstado();

                if (VerEstado() == true)
                {
                    atacante.ConseguirPV(ValorPV);
                } 
                
                Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño del hechizo {hechizo.Nombre} de {atacante.Nombre}. Vida actual: {Vida}.");
            }
            else
            {
                Console.WriteLine($"{atacante.Nombre} intentó usar el hechizo {hechizo.Nombre}, pero no tiene suficiente mana.");
            }
        }

        public void RecibirAtaque(IPersonajeHero ataque)
        {
            int defensaTotal = 0;
            
            foreach (var item in items_defensa)
            {
                if (item is IDefensa itemDefensa)
                {
                    defensaTotal += itemDefensa.Defensa;
                }
            }
            
            int danioRecibido = Math.Max(0, ataque.ValorAtaque() - defensaTotal);
            Vida -= danioRecibido;
            
            if (VerEstado() == true)
            {
                ataque.ConseguirPV(ValorPV);
            } 


            Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño de {ataque.Nombre}. Vida actual: {Vida}.");
        }
        
        public void AgregarItemAtaque(IAtaque item)
        {
            items_ataque.Add(item);
        }

        public void AgregarItemDefensa(IDefensa item2)
        {
            items_defensa.Add(item2);
        }
}
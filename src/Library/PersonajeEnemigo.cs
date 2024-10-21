namespace RoleplayGame;

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
        
        protected List<IAtaque> itemsAtaque = new List<IAtaque>();
        protected List<IDefensa> itemsDefensa = new List<IDefensa>();
        
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
            get { return itemsAtaque.Count() + itemsDefensa.Count(); }
        }
        
        public int ValorAtaque()
        {
            int valor = Ataque;
    
            foreach (var item in itemsAtaque)
            {
                valor += item.ObtenerAtaque();
            }

            return valor;
        }

        public void RecibirHechizo(IHechiceroHero atacante, Hechizo hechizo)
        {
            atacante.ValorAtaqueHechizos(hechizo);
            int defensaTotal = 0;
            foreach (var item in itemsDefensa)
            {
                    defensaTotal += item.Defensa;
            }
            
            if (atacante.Mana >= hechizo.GastoMana)
            {
                atacante.Mana -= hechizo.GastoMana;
                
                if (defensaTotal > hechizo.Ataque)
                {
                    defensaTotal = hechizo.Ataque;
                }
               
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

        public virtual void RecibirAtaque(IPersonajeHero ataque)
        {
            int defensaTotal = 0;
            
            foreach (var item in itemsDefensa)
            {
                defensaTotal += item.Defensa;
            }
            
            int danioRecibido = Math.Max(0, ataque.ValorAtaque() - defensaTotal);
            Vida -= danioRecibido;
           
            
            Console.WriteLine($"{Nombre} recibió {danioRecibido} puntos de daño de {ataque.Nombre}. Vida actual: {Vida}.");
            
            if (VerEstado() == true)
            {
                ataque.ConseguirPV(ValorPV);
                Console.WriteLine($"{Nombre} ha muerto y ha otorgado {ValorPV} puntos de victoria a {ataque.Nombre}");
            } 
            
        }
        
        public void AgregarItemAtaque(IAtaque item)
        {
            itemsAtaque.Add(item);
        }

        public void AgregarItemDefensa(IDefensa item2)
        {
            itemsDefensa.Add(item2);
        }
}
namespace RoleplayGame
{
    public class Dragon : PersonajeEnemigo
    {
        private List<AtaquesDragon> Ataques  = new List<AtaquesDragon>();

        public Dragon(string nombre)
        {
            Nombre = nombre;
            Vida = 200;
            Ataque = 20;
            ValorPV = 80;
        }

            public void AgregarAtaque(AtaquesDragon ataque)
            {
                Ataques.Add(ataque);
            }
            public void VerAtaques()
            {
                foreach (var ataque in Ataques)
                {
                    Console.WriteLine(ataque.Nombre);
                }
            }

        public void RealizarAtaque(IPersonajeHero objetivo, AtaquesDragon ataque)
        {
            if (Ataques.Contains(ataque))
            {
                objetivo.CambiarVida(objetivo.VerVida()-(Ataque + ataque.Ataque));
            }
            else
            {
                Console.WriteLine("El ataque no esta en tu lista de ataques");
            }
        }
    }
}
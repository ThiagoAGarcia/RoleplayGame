namespace RoleplayGame
{
    public class AtaquesDragon
    {
        public int AtaqueFuego { get; set; }
        public int AtaqueCola { get; set; }

        public AtaquesDragon(int ataqueFuego, int ataqueCola)
        {
            this.AtaqueFuego = ataqueFuego;
            this.AtaqueCola = ataqueCola;
        }

        public void AtacarConFuego(IPersonaje objetivo, Dragon dragon)
        {
            Console.WriteLine($"{dragon.Nombre} lanza fuego a {objetivo.Nombre}, infligiendo {AtaqueFuego} puntos de daño.");
            objetivo.CambiarVida(objetivo.VerVida() - AtaqueFuego);
        }

        public void AtacarConCola(IPersonaje objetivo, Dragon dragon)
        {
            Console.WriteLine($"{dragon.Nombre} ataca con su cola a {objetivo.Nombre}, infligiendo {AtaqueCola} puntos de daño.");
            objetivo.CambiarVida(objetivo.VerVida() - AtaqueCola);
        }
    }
}
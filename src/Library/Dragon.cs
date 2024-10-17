namespace RoleplayGame
{
    public class Dragon : Personaje
    {
        public AtaquesDragon Ataques { get; set; }

        public Dragon(string nombre, int vida, int ataque, AtaquesDragon ataques)
        {
            this.Nombre = nombre;
            this.Vida = vida;
            this.Ataque = ataque;
            this.Ataques = ataques;
        }

        public void UsarAtaqueFuego(IPersonaje objetivo)
        {
            this.Ataques.AtacarConFuego(objetivo, this);
        }

        public void UsarAtaqueCola(IPersonaje objetivo)
        {
            this.Ataques.AtacarConCola(objetivo, this);
        }
    }
}
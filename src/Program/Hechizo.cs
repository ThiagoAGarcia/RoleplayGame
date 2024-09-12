namespace RoleplayGame
{
    public class Hechizo
    {
        public string Nombre { get; set; }
        public int Ataque { get; set; }

        // Hechizos fijos
        public static Hechizo BolaDeFuego { get; } = new Hechizo { Nombre = "Bola de Fuego", Ataque = 50 };
        public static Hechizo RayoDeHielo { get; } = new Hechizo { Nombre = "Rayo de Hielo", Ataque = 40 };
        public static Hechizo TormentaElectrica { get; } = new Hechizo { Nombre = "Tormenta Eléctrica", Ataque = 60 };
    }
}
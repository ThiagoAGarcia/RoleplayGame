namespace RoleplayGame
{
    public class Hechizo : IAtaque, IDefensa
    {
        public string Nombre { get; set; }
        public int Ataque { get; set; }
        
        public int Defensa { get; set; }
        
        public int GastoMana { get; set; }
    
        public int ObtenerAtaque() => Ataque;
        
        public int ObtenerDefensa() => Defensa;
        
        // Hechizos fijos
        public static Hechizo BolaDeFuego { get; } = new Hechizo { Nombre = "Bola de Fuego", Ataque = 50, GastoMana = 10};
        public static Hechizo RayoDeHielo { get; } = new Hechizo { Nombre = "Rayo de Hielo", Ataque = 40, GastoMana = 5 };
        public static Hechizo TormentaElectrica { get; } = new Hechizo { Nombre = "Tormenta Eléctrica", Ataque = 60, GastoMana = 20 };
    }
}